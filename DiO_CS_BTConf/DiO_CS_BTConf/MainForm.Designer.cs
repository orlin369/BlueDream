namespace DiO_CS_BTConf
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnSetName = new System.Windows.Forms.Button();
            this.btnSetPin = new System.Windows.Forms.Button();
            this.mnuBar = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statBar = new System.Windows.Forms.StatusStrip();
            this.lblIsConnected = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblType = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.btnSetBoudRate = new System.Windows.Forms.Button();
            this.cmbBoudRate = new System.Windows.Forms.ComboBox();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.btnEnterCommandMode = new System.Windows.Forms.Button();
            this.btnSetAll = new System.Windows.Forms.Button();
            this.txtRawMessage = new System.Windows.Forms.TextBox();
            this.btnSendRaw = new System.Windows.Forms.Button();
            this.btnExitCommandMode = new System.Windows.Forms.Button();
            this.mnuBar.SuspendLayout();
            this.statBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSetName
            // 
            this.btnSetName.Location = new System.Drawing.Point(12, 56);
            this.btnSetName.Name = "btnSetName";
            this.btnSetName.Size = new System.Drawing.Size(75, 23);
            this.btnSetName.TabIndex = 0;
            this.btnSetName.Text = "Set Name";
            this.btnSetName.UseVisualStyleBackColor = true;
            this.btnSetName.Click += new System.EventHandler(this.btnSetName_Click);
            // 
            // btnSetPin
            // 
            this.btnSetPin.Location = new System.Drawing.Point(12, 85);
            this.btnSetPin.Name = "btnSetPin";
            this.btnSetPin.Size = new System.Drawing.Size(75, 23);
            this.btnSetPin.TabIndex = 1;
            this.btnSetPin.Text = "Set Pin";
            this.btnSetPin.UseVisualStyleBackColor = true;
            this.btnSetPin.Click += new System.EventHandler(this.btnSetPin_Click);
            // 
            // mnuBar
            // 
            this.mnuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.connectionToolStripMenuItem});
            this.mnuBar.Location = new System.Drawing.Point(0, 0);
            this.mnuBar.Name = "mnuBar";
            this.mnuBar.Size = new System.Drawing.Size(552, 24);
            this.mnuBar.TabIndex = 6;
            this.mnuBar.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.typeToolStripMenuItem,
            this.portsToolStripMenuItem});
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.connectionToolStripMenuItem.Text = "Connection";
            // 
            // typeToolStripMenuItem
            // 
            this.typeToolStripMenuItem.Name = "typeToolStripMenuItem";
            this.typeToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.typeToolStripMenuItem.Text = "Type";
            // 
            // portsToolStripMenuItem
            // 
            this.portsToolStripMenuItem.Name = "portsToolStripMenuItem";
            this.portsToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.portsToolStripMenuItem.Text = "Ports";
            // 
            // statBar
            // 
            this.statBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblIsConnected,
            this.lblType});
            this.statBar.Location = new System.Drawing.Point(0, 430);
            this.statBar.Name = "statBar";
            this.statBar.Size = new System.Drawing.Size(552, 22);
            this.statBar.TabIndex = 7;
            this.statBar.Text = "statusStrip1";
            // 
            // lblIsConnected
            // 
            this.lblIsConnected.Name = "lblIsConnected";
            this.lblIsConnected.Size = new System.Drawing.Size(97, 17);
            this.lblIsConnected.Text = "Connected: False";
            // 
            // lblType
            // 
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(68, 17);
            this.lblType.Text = "Type: HC06";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(93, 58);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 8;
            this.txtName.Text = "HC-06";
            // 
            // txtPin
            // 
            this.txtPin.Location = new System.Drawing.Point(93, 87);
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(100, 20);
            this.txtPin.TabIndex = 9;
            this.txtPin.Text = "1234";
            this.txtPin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPin_KeyUp);
            // 
            // btnSetBoudRate
            // 
            this.btnSetBoudRate.Location = new System.Drawing.Point(12, 114);
            this.btnSetBoudRate.Name = "btnSetBoudRate";
            this.btnSetBoudRate.Size = new System.Drawing.Size(75, 23);
            this.btnSetBoudRate.TabIndex = 10;
            this.btnSetBoudRate.Text = "Set Boud";
            this.btnSetBoudRate.UseVisualStyleBackColor = true;
            this.btnSetBoudRate.Click += new System.EventHandler(this.btnSetBoudRate_Click);
            // 
            // cmbBoudRate
            // 
            this.cmbBoudRate.FormattingEnabled = true;
            this.cmbBoudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200 "});
            this.cmbBoudRate.Location = new System.Drawing.Point(93, 116);
            this.cmbBoudRate.Name = "cmbBoudRate";
            this.cmbBoudRate.Size = new System.Drawing.Size(100, 21);
            this.cmbBoudRate.TabIndex = 11;
            // 
            // lstLog
            // 
            this.lstLog.FormattingEnabled = true;
            this.lstLog.Location = new System.Drawing.Point(12, 169);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(528, 225);
            this.lstLog.TabIndex = 29;
            // 
            // btnEnterCommandMode
            // 
            this.btnEnterCommandMode.Location = new System.Drawing.Point(12, 27);
            this.btnEnterCommandMode.Name = "btnEnterCommandMode";
            this.btnEnterCommandMode.Size = new System.Drawing.Size(75, 23);
            this.btnEnterCommandMode.TabIndex = 30;
            this.btnEnterCommandMode.Text = "Enter CM";
            this.btnEnterCommandMode.UseVisualStyleBackColor = true;
            this.btnEnterCommandMode.Click += new System.EventHandler(this.btnEnterCommandMode_Click);
            // 
            // btnSetAll
            // 
            this.btnSetAll.Location = new System.Drawing.Point(12, 143);
            this.btnSetAll.Name = "btnSetAll";
            this.btnSetAll.Size = new System.Drawing.Size(181, 23);
            this.btnSetAll.TabIndex = 31;
            this.btnSetAll.Text = "Set All";
            this.btnSetAll.UseVisualStyleBackColor = true;
            this.btnSetAll.Click += new System.EventHandler(this.btnSetAll_Click);
            // 
            // txtRawMessage
            // 
            this.txtRawMessage.Location = new System.Drawing.Point(12, 400);
            this.txtRawMessage.Name = "txtRawMessage";
            this.txtRawMessage.Size = new System.Drawing.Size(447, 20);
            this.txtRawMessage.TabIndex = 32;
            // 
            // btnSendRaw
            // 
            this.btnSendRaw.Location = new System.Drawing.Point(465, 397);
            this.btnSendRaw.Name = "btnSendRaw";
            this.btnSendRaw.Size = new System.Drawing.Size(75, 23);
            this.btnSendRaw.TabIndex = 33;
            this.btnSendRaw.Text = "Send";
            this.btnSendRaw.UseVisualStyleBackColor = true;
            this.btnSendRaw.Click += new System.EventHandler(this.btnSendRaw_Click);
            // 
            // btnExitCommandMode
            // 
            this.btnExitCommandMode.Location = new System.Drawing.Point(93, 27);
            this.btnExitCommandMode.Name = "btnExitCommandMode";
            this.btnExitCommandMode.Size = new System.Drawing.Size(75, 23);
            this.btnExitCommandMode.TabIndex = 35;
            this.btnExitCommandMode.Text = "Exit CM";
            this.btnExitCommandMode.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 452);
            this.Controls.Add(this.btnExitCommandMode);
            this.Controls.Add(this.btnSendRaw);
            this.Controls.Add(this.txtRawMessage);
            this.Controls.Add(this.btnSetAll);
            this.Controls.Add(this.btnEnterCommandMode);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.cmbBoudRate);
            this.Controls.Add(this.btnSetBoudRate);
            this.Controls.Add(this.txtPin);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.statBar);
            this.Controls.Add(this.mnuBar);
            this.Controls.Add(this.btnSetPin);
            this.Controls.Add(this.btnSetName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Blue Dream";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mnuBar.ResumeLayout(false);
            this.mnuBar.PerformLayout();
            this.statBar.ResumeLayout(false);
            this.statBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSetName;
        private System.Windows.Forms.Button btnSetPin;
        private System.Windows.Forms.MenuStrip mnuBar;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statBar;
        private System.Windows.Forms.ToolStripStatusLabel lblIsConnected;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.Button btnSetBoudRate;
        private System.Windows.Forms.ComboBox cmbBoudRate;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.ToolStripStatusLabel lblType;
        private System.Windows.Forms.ToolStripMenuItem typeToolStripMenuItem;
        private System.Windows.Forms.Button btnEnterCommandMode;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.Button btnSetAll;
        private System.Windows.Forms.TextBox txtRawMessage;
        private System.Windows.Forms.Button btnSendRaw;
        private System.Windows.Forms.Button btnExitCommandMode;
    }
}

