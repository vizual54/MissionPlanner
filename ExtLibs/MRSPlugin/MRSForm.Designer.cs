namespace MRSPlugin
{
    partial class MRSForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.urlComboBox = new System.Windows.Forms.ComboBox();
            this.sessionsComboBox = new System.Windows.Forms.ComboBox();
            this.confirmCheckBox = new System.Windows.Forms.CheckBox();
            this.agentsComboBox = new System.Windows.Forms.ComboBox();
            this.startButton = new MissionPlanner.Controls.MyButton();
            this.myLabel3 = new MissionPlanner.Controls.MyLabel();
            this.getSessionsButton = new MissionPlanner.Controls.MyButton();
            this.myLabel2 = new MissionPlanner.Controls.MyLabel();
            this.myLabel1 = new MissionPlanner.Controls.MyLabel();
            this.stopButton = new MissionPlanner.Controls.MyButton();
            this.SuspendLayout();
            // 
            // urlComboBox
            // 
            this.urlComboBox.FormattingEnabled = true;
            this.urlComboBox.Location = new System.Drawing.Point(93, 15);
            this.urlComboBox.Name = "urlComboBox";
            this.urlComboBox.Size = new System.Drawing.Size(255, 21);
            this.urlComboBox.TabIndex = 2;
            // 
            // sessionsComboBox
            // 
            this.sessionsComboBox.FormattingEnabled = true;
            this.sessionsComboBox.Location = new System.Drawing.Point(93, 84);
            this.sessionsComboBox.Name = "sessionsComboBox";
            this.sessionsComboBox.Size = new System.Drawing.Size(121, 21);
            this.sessionsComboBox.TabIndex = 3;
            // 
            // confirmCheckBox
            // 
            this.confirmCheckBox.AutoSize = true;
            this.confirmCheckBox.Checked = true;
            this.confirmCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.confirmCheckBox.Location = new System.Drawing.Point(93, 204);
            this.confirmCheckBox.Name = "confirmCheckBox";
            this.confirmCheckBox.Size = new System.Drawing.Size(179, 17);
            this.confirmCheckBox.TabIndex = 7;
            this.confirmCheckBox.Text = "Confirm waypoint before sending";
            this.confirmCheckBox.UseVisualStyleBackColor = true;
            // 
            // agentsComboBox
            // 
            this.agentsComboBox.FormattingEnabled = true;
            this.agentsComboBox.Location = new System.Drawing.Point(94, 115);
            this.agentsComboBox.Name = "agentsComboBox";
            this.agentsComboBox.Size = new System.Drawing.Size(121, 21);
            this.agentsComboBox.TabIndex = 9;
            this.agentsComboBox.DropDown += new System.EventHandler(this.agentsComboBox_DropDown);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(93, 227);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // myLabel3
            // 
            this.myLabel3.Location = new System.Drawing.Point(12, 114);
            this.myLabel3.Name = "myLabel3";
            this.myLabel3.resize = false;
            this.myLabel3.Size = new System.Drawing.Size(75, 23);
            this.myLabel3.TabIndex = 5;
            this.myLabel3.Text = "Agents:";
            // 
            // getSessionsButton
            // 
            this.getSessionsButton.Location = new System.Drawing.Point(93, 42);
            this.getSessionsButton.Name = "getSessionsButton";
            this.getSessionsButton.Size = new System.Drawing.Size(75, 23);
            this.getSessionsButton.TabIndex = 4;
            this.getSessionsButton.Text = "Get Sessions";
            this.getSessionsButton.UseVisualStyleBackColor = true;
            this.getSessionsButton.Click += new System.EventHandler(this.getSessionsButton_Click);
            // 
            // myLabel2
            // 
            this.myLabel2.Location = new System.Drawing.Point(12, 84);
            this.myLabel2.Name = "myLabel2";
            this.myLabel2.resize = false;
            this.myLabel2.Size = new System.Drawing.Size(75, 23);
            this.myLabel2.TabIndex = 1;
            this.myLabel2.Text = "Sessions:";
            // 
            // myLabel1
            // 
            this.myLabel1.Location = new System.Drawing.Point(13, 13);
            this.myLabel1.Name = "myLabel1";
            this.myLabel1.resize = false;
            this.myLabel1.Size = new System.Drawing.Size(75, 23);
            this.myLabel1.TabIndex = 0;
            this.myLabel1.Text = "Firebase url:";
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(174, 227);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 6;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // MRSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 262);
            this.Controls.Add(this.agentsComboBox);
            this.Controls.Add(this.confirmCheckBox);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.myLabel3);
            this.Controls.Add(this.getSessionsButton);
            this.Controls.Add(this.sessionsComboBox);
            this.Controls.Add(this.urlComboBox);
            this.Controls.Add(this.myLabel2);
            this.Controls.Add(this.myLabel1);
            this.Name = "MRSForm";
            this.Text = "MRSForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MissionPlanner.Controls.MyLabel myLabel1;
        private MissionPlanner.Controls.MyLabel myLabel2;
        private System.Windows.Forms.ComboBox urlComboBox;
        private System.Windows.Forms.ComboBox sessionsComboBox;
        private MissionPlanner.Controls.MyButton getSessionsButton;
        private MissionPlanner.Controls.MyLabel myLabel3;
        private MissionPlanner.Controls.MyButton startButton;
        private System.Windows.Forms.CheckBox confirmCheckBox;
        private System.Windows.Forms.ComboBox agentsComboBox;
        private MissionPlanner.Controls.MyButton stopButton;
    }
}