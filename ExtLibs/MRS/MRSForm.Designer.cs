namespace MRS
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
            this.myLabel1 = new MissionPlanner.Controls.MyLabel();
            this.myLabel2 = new MissionPlanner.Controls.MyLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.myButton1 = new MissionPlanner.Controls.MyButton();
            this.myLabel3 = new MissionPlanner.Controls.MyLabel();
            this.myButton2 = new MissionPlanner.Controls.MyButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
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
            // myLabel2
            // 
            this.myLabel2.Location = new System.Drawing.Point(12, 84);
            this.myLabel2.Name = "myLabel2";
            this.myLabel2.resize = false;
            this.myLabel2.Size = new System.Drawing.Size(75, 23);
            this.myLabel2.TabIndex = 1;
            this.myLabel2.Text = "Sessions:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(93, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(255, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(93, 84);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 3;
            // 
            // myButton1
            // 
            this.myButton1.Location = new System.Drawing.Point(93, 42);
            this.myButton1.Name = "myButton1";
            this.myButton1.Size = new System.Drawing.Size(75, 23);
            this.myButton1.TabIndex = 4;
            this.myButton1.Text = "Get Sessions";
            this.myButton1.UseVisualStyleBackColor = true;
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
            // myButton2
            // 
            this.myButton2.Location = new System.Drawing.Point(139, 227);
            this.myButton2.Name = "myButton2";
            this.myButton2.Size = new System.Drawing.Size(75, 23);
            this.myButton2.TabIndex = 6;
            this.myButton2.Text = "Start";
            this.myButton2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(93, 204);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(179, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Confirm waypoint before sending";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(94, 115);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 9;
            // 
            // MRSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 262);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.myButton2);
            this.Controls.Add(this.myLabel3);
            this.Controls.Add(this.myButton1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
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
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private MissionPlanner.Controls.MyButton myButton1;
        private MissionPlanner.Controls.MyLabel myLabel3;
        private MissionPlanner.Controls.MyButton myButton2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboBox3;
    }
}