namespace DZ_1_1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            bt_Start = new Button();
            MyProcess = new System.Diagnostics.Process();
            SuspendLayout();
            // 
            // bt_Start
            // 
            bt_Start.Location = new Point(316, 176);
            bt_Start.Name = "bt_Start";
            bt_Start.Size = new Size(140, 30);
            bt_Start.TabIndex = 0;
            bt_Start.Text = "Start Notepad";
            bt_Start.UseVisualStyleBackColor = true;
            bt_Start.Click += bt_Start_Click;
            // 
            // MyProcess
            // 
            MyProcess.StartInfo.Domain = "";
            MyProcess.StartInfo.LoadUserProfile = false;
            MyProcess.StartInfo.Password = null;
            MyProcess.StartInfo.StandardErrorEncoding = null;
            MyProcess.StartInfo.StandardInputEncoding = null;
            MyProcess.StartInfo.StandardOutputEncoding = null;
            MyProcess.StartInfo.UseCredentialsForNetworkingOnly = false;
            MyProcess.StartInfo.UserName = "";
            MyProcess.SynchronizingObject = this;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(bt_Start);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button bt_Start;
        private System.Diagnostics.Process MyProcess;
    }
}
