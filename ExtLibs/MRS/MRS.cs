using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using MissionPlanner;
//using GMap.NET;
//using GMap.NET.WindowsForms;
//using GMap.NET.WindowsForms.Markers;
//using MissionPlanner.Utilities;
//using ProjNet.CoordinateSystems;
//using ProjNet.CoordinateSystems.Transformations;
using MissionPlanner.Plugin;
using System.Configuration;

namespace MRS
{
    public class MRS : Plugin
    {
        private string _Name = "MRS";
        private string _Version = "0.1";
        private string _Author = "Nils Högberg";
        private string _url;
        private string _agentId;

        public override string Name { get { return _Name; } }

        public override string Version { get { return _Version; } }

        public override string Author { get { return _Author; } }

        public override bool Init()
        {
            //var fireBaseConfig = ConfigurationManager.AppSettings;
            //_url = ConfigurationManager.AppSettings["url"];
            //_agentId = ConfigurationManager.AppSettings["agentId"];
            loopratehz = 1f;

            return true;
        }

        public override bool Loaded()
        {
            ToolStripLabel item = new ToolStripLabel("MRS");
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
                MRSForm form = new MRSForm();
                form.Show();
            }

            return true;
        }

        public override bool Exit()
        {
            return true;
        }
    }
}
