using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRSPlugin
{
    
    public partial class MRSForm : Form
    {
        private FireBase _fireBase;
        public bool IsSubscribing { get; private set; }
        public bool ConfirmWP { get; private set; }
        public string SelectedSession { get; private set; }
        public string SelectedAgent { get; private set; }

        public MRSForm(FireBase fireBase)
        {
            _fireBase = fireBase;
            InitializeComponent();
            urlComboBox.Items.Add(_fireBase.FireBaseUrl);
            urlComboBox.SelectedIndex = 0;
        }

        private void getSessionsButton_Click(object sender, EventArgs e)
        {
            sessionsComboBox.Items.Clear();
            var sessions = _fireBase.GetSessions();
            sessionsComboBox.Items.AddRange(sessions.ToArray<string>());
            if (sessionsComboBox.Items.Count >= 0)
                sessionsComboBox.SelectedIndex = 0;
        }

        private void agentsComboBox_DropDown(object sender, EventArgs e)
        {
            agentsComboBox.Items.Clear();
            if (sessionsComboBox.SelectedText != null || sessionsComboBox.SelectedText != "")
            {
                var agents = _fireBase.GetAgents(sessionsComboBox.SelectedItem.ToString());
                agentsComboBox.Items.AddRange(agents.ToArray<string>());
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            stopButton.Enabled = true;
            ConfirmWP = confirmCheckBox.Checked;
            
            SelectedAgent = agentsComboBox.SelectedItem.ToString();
            SelectedSession = sessionsComboBox.SelectedItem.ToString();
            //_fireBase.OrderSubscribeStart(SelectedSession, SelectedAgent);
            _fireBase.OrderSubscribe(SelectedSession, SelectedAgent);
            IsSubscribing = true;
            this.Hide();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = true;
            stopButton.Enabled = false;
            IsSubscribing = false;
            _fireBase.Disconnect();
            sessionsComboBox.Items.Clear();
            sessionsComboBox.ResetText();
            agentsComboBox.Items.Clear();
            agentsComboBox.ResetText();
        }
    }
}
