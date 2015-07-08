using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MissionPlanner.Plugin;
using System.Windows.Forms;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;

namespace TestProject
{
    public class MPPlugin : Plugin
    {
        private string _Name = "MPPlugin";
        private string _Version = "0.1";
        private string _Author = "Nils Högberg";

        public override string Name { get { return _Name; } }

        public override string Version { get { return _Version; } }

        public override string Author { get { return _Author; } }

        private IFirebaseClient fbc;

        public override bool Init()
        {
            try
            {
                IFirebaseConfig fbConfig = new FirebaseConfig();
                fbConfig.BasePath = "https://vivid-inferno-8989.firebaseio.com/";
                fbc = new FirebaseClient(fbConfig);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        public override bool Loaded()
        {
            ToolStripMenuItem item = new ToolStripMenuItem("MPPlugin");
            item.Click += item_Click;
            Host.FDMenuMap.Items.Add(item);

            return true;
        }

        private void item_Click(object sender, EventArgs e)
        {
            var response = fbc.Get("Sessions");
            Console.WriteLine(response.Body);
        }

        public override bool Exit()
        {
            return true;
        }
    }
}