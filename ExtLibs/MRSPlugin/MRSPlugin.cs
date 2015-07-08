using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using MissionPlanner;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using MissionPlanner.Utilities;
//using ProjNet.CoordinateSystems;
//using ProjNet.CoordinateSystems.Transformations;
using MissionPlanner.Plugin;
using MissionPlanner.GCSViews;
using MissionPlanner.Controls;
using System.Configuration;

namespace MRSPlugin
{
    public class MRS : Plugin
    {
        private string _Name = "MRS";
        private string _Version = "0.1";
        private string _Author = "Nils Högberg";
        private string _url;
        private string _agentId;
        private FireBase _fireBase;
        private MRSForm _mrsForm;
        private static GMapOverlay mrsOverlay;

        public override string Name { get { return _Name; } }

        public override string Version { get { return _Version; } }

        public override string Author { get { return _Author; } }

        public override bool Init()
        {

            _url = ConfigurationManager.AppSettings["url"];
            _agentId = ConfigurationManager.AppSettings["agentId"];
            loopratehz = 1f;
            _fireBase = new FireBase(_url);
            _fireBase.OrderReveived += _fireBase_OrderReveived;

            mrsOverlay = new GMapOverlay("MRS");
            FlightData.mymap.Overlays.Add(mrsOverlay);

            return true;
        }
        
        void _fireBase_OrderReveived(object sender, OrderUpdate e)
        {
            string altitude = MainV2.comPort.MAV.GuidedMode.z.ToString();

            Locationwp wp = new Locationwp()
            {
                alt = float.Parse("30,0"),
                lat = double.Parse("58,391324"),
                lng = double.Parse("15,564804"),
            };

            if (_mrsForm.ConfirmWP)
            {
                addWaypointToMap("MRS order", wp.lng, wp.lat, (int)wp.alt, Color.Blue, mrsOverlay);

                if (DialogResult.Cancel == InputBox.Show("Confirm waypoint and altitude", "Confirm waypoint and altitude.\nEnter new altitude:", ref altitude))
                    return;
            }
            
            /*
            Locationwp gotohere = new Locationwp();
            gotohere.id = (byte)MAVLink.MAV_CMD.WAYPOINT;
            gotohere.alt = (float)(MainV2.comPort.MAV.GuidedMode.z); // back to m
            gotohere.lat = double.Parse("58,391324");
            gotohere.lng = double.Parse("15,564804");
            */
            //GMapProvider theMap = Host.FDMapType;

            //Host.comPort.setGuidedModeWP(wp);
            SendWaypoint(wp);
            ClearWaypointsFromMap();
        }

        private void ClearWaypointsFromMap()
        {
            mrsOverlay.Markers.Clear();
        }

        private void SendWaypoint(Locationwp waypoint)
        {
            try
            {
                Host.comPort.setGuidedModeWP(waypoint);
            }
            catch (Exception ex)
            {
                Host.comPort.giveComport = false;
                CustomMessageBox.Show(Strings.CommandFailed + ex.Message, Strings.ERROR);
            }
        }

        private void addWaypointToMap(string tag, double lng, double lat, int alt, Color? color, GMapOverlay overlay)
        {
            try
            {
                PointLatLng point = new PointLatLng(lat, lng);
                GMarkerGoogle m = new GMarkerGoogle(point, GMarkerGoogleType.green);
                m.ToolTipMode = MarkerTooltipMode.Always;
                m.ToolTipText = tag;
                m.Tag = tag;

                GMapMarkerRect mBorders = new GMapMarkerRect(point);
                {

                    mBorders.InnerMarker = m;
                    try
                    {
                        mBorders.wprad = (int)(float.Parse(MissionPlanner.MainV2.config["TXT_WPRad"].ToString()) / CurrentState.multiplierdist);
                    }
                    catch { }
                    if (color.HasValue)
                    {
                        mBorders.Color = color.Value;
                    }
                }

                overlay.Markers.Add(m);
                overlay.Markers.Add(mBorders);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public override bool Loaded()
        {
            //ToolStripLabel item = new ToolStripLabel("MRS");
            ToolStripMenuItem item = new ToolStripMenuItem("MRS");
            item.Click += item_Click;

            Host.FDMenuMap.Items.Add(item);

            return true; 
        }

        private void item_Click(object sender, EventArgs e)
        {
            SetupUI(0);
        }

        public bool SetupUI(int gui = 0)
        {
            if (gui == 0)
            {
                if (_mrsForm == null)
                {
                    _mrsForm = new MRSForm(_fireBase);
                }

                _mrsForm.Show();
            }

            return true;
        }

        public override bool Exit()
        {
            _fireBase.OrderReveived -= _fireBase_OrderReveived;
            return true;
        }
    }
}
