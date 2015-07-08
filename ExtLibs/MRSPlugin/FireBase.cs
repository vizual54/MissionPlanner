using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.EventStreaming;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
//using System.Reflection;
using FireSharp.Response;
//using FireSharp.EventStreaming;

namespace MRSPlugin
{
    public delegate void OrderReceivedEventHandler(object sender, OrderUpdate e);

    public class FireBase : IDisposable
    {
        private string _url;
        private IFirebaseClient _fireBaseClient;
        private IFirebaseConfig _fireBaseConfig;
        private OrderUpdate _currentOrder;
        private string _sessionId; // = "A_20150422_130427";
        private string _agentId;
        private Task orderSubscription;

        public event OrderReceivedEventHandler OrderReveived;

        public string FireBaseUrl { get { return _url; } }

        public FireBase(string url)
        {
            _url = url;

            _fireBaseConfig = new FirebaseConfig
            {
                BasePath = _url
            };

            _fireBaseClient = new FirebaseClient(_fireBaseConfig);
            
        }

        public void Dispose()
        {
            _fireBaseClient = null;
            _fireBaseConfig = null;
            _currentOrder = null;
        }

        public void Disconnect()
        {
            _fireBaseClient = null;
            _fireBaseClient = new FirebaseClient(_fireBaseConfig);
        }

        public void OnOrderReceived(OrderUpdate e)
        {
            if (OrderReveived != null)
                OrderReveived(this, e);
        }
        
        public IList<string> GetSessions()
        {
            var response = _fireBaseClient.Get("Sessions");
            var dic = JsonConvert.DeserializeObject<Dictionary<string, Session>>(response.Body);
            
            var list = new List<string>();

            foreach (var item in dic)
	        {
                list.Add(item.Value.Id);
	        }

            return list; 
        }

        public IList<string> GetAgents(string sessionId)
        {
            IList<string> list = new List<string>();
            var response = _fireBaseClient.Get("SessionUpdates/" + sessionId + "/AgentUpdates");

            /* Detta funkar med, gent id som key
             * Kan få ut mer data kanske
            Dictionary<string, object> result = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Body);

            foreach (var item in result)
            {
                Console.WriteLine(item.Key + " : " + item.Value);
            }
            */

            JObject jObject = JObject.Parse(response.Body);
            JsonReader reader = jObject.CreateReader();
            while (reader.Read())
            {
                if (reader.Value != null)
                {
                    list.Add((string)reader.Value);
                    reader.Skip();
                }
            }

            return list;
        }

        public void OrdersChanged(ValueRootAddedEventHandler<Dictionary<string, OrderUpdate>> args)
        {

        }
        
        public void OrderSubscribeStart(string session, string agentId)
        {
            _sessionId = session;
            _agentId = agentId;
            orderSubscription = new Task(Subscribe);
            orderSubscription.Start();
        }

        public void OrderSubscribeStop()
        {
            orderSubscription.Dispose();
        }

        public async void Subscribe()
        {
            await _fireBaseClient.OnChangeGetAsync<Dictionary<string, OrderUpdate>>("SessionUpdates/" + _sessionId + "/OrderUpdates",
                (sender, args) =>
                {
                    // Orders are sorted with the last order given order coming first
                    foreach (var item in args)
                    {
                        if (item.Value.Receiver == _agentId)
                        {
                            if (_currentOrder == null || _currentOrder.TimeStamp < item.Value.TimeStamp)
                            {
                                _currentOrder = item.Value;
                                Console.WriteLine("New order received");
                                OnOrderReceived(item.Value);
                            }
                        }
                    }
                }
                );
             
        }



        public void OrderSubscribe(string session, string agentId)
        {
            _sessionId = session;
            _agentId = agentId;
            orderSubscription = _fireBaseClient.OnChangeGetAsync<Dictionary<string, OrderUpdate>>("SessionUpdates/" + _sessionId + "/OrderUpdates",
                (sender, args) => OrderEventHandler(args));
        }

        private void OrderEventHandler(Dictionary<string, OrderUpdate> args)
        {
            foreach (var item in args)
            {
                if (item.Value.Receiver == _agentId)
                {
                    if (_currentOrder == null || _currentOrder.TimeStamp < item.Value.TimeStamp)
                    {
                        _currentOrder = item.Value;
                        Console.WriteLine("New order received");
                        OnOrderReceived(item.Value);
                    }
                }
            }
        }
    }

    [DataContract]
    public class Session
    {
        [DataMember(Name = "city")]
        public string City { get; set; }
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "timestamp")]
        public long TimeStamp { get; set; }
    }

    [DataContract]
    public class AgentUpdate
    {
        [DataMember(Name = "city")]
        public string City { get; set; }
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "timestamp")]
        public long TimeStamp { get; set; }
    }

    [DataContract]
    public class OrderUpdate
    {
        [DataMember(Name = "data")]
        public string Data { get; set; }
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "logictime")]
        public int LogicTime { get; set; }
        [DataMember(Name = "receiver")]
        public string Receiver { get; set; }
        [DataMember(Name = "status")]
        public string Status { get; set; }
        [DataMember(Name = "timestamp")]
        public long TimeStamp { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "owner")]
        public string Owner { get; set; }
        [DataMember(Name = "lat")]
        public string Lat { get; set; }
        [DataMember(Name = "long")]
        public string Long { get; set; }
    }
}
