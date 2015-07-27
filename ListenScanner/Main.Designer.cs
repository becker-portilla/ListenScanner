namespace ListenScanner
{
    partial class Main
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStartService = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStopService = new System.Windows.Forms.ToolStripMenuItem();
            this.gbConfig = new System.Windows.Forms.GroupBox();
            this.btnRefreshDevices = new System.Windows.Forms.Button();
            this.cbDevices = new System.Windows.Forms.ComboBox();
            this.lblDevice = new System.Windows.Forms.Label();
            this.gbEstatus = new System.Windows.Forms.GroupBox();
            this.lblAddressStatus = new System.Windows.Forms.Label();
            this.lblServiceStatus = new System.Windows.Forms.Label();
            this.lblDeviceStatus = new System.Windows.Forms.Label();
            this.menuNotify.SuspendLayout();
            this.gbConfig.SuspendLayout();
            this.gbEstatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(78, 47);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 37);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Iniciar Servicio";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(192, 47);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 37);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Detener Servicio";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // notify
            // 
            this.notify.ContextMenuStrip = this.menuNotify;
            this.notify.Text = "notifyIcon1";
            // 
            // menuNotify
            // 
            this.menuNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpen,
            this.menuClose,
            this.toolStripSeparator1,
            this.menuStartService,
            this.menuStopService});
            this.menuNotify.Name = "menuNotify";
            this.menuNotify.Size = new System.Drawing.Size(160, 120);
            // 
            // menuOpen
            // 
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.Size = new System.Drawing.Size(156, 22);
            this.menuOpen.Text = "Abrir";
            this.menuOpen.Click += new System.EventHandler(this.menuOpen_Click);
            // 
            // menuClose
            // 
            this.menuClose.Name = "menuClose";
            this.menuClose.Size = new System.Drawing.Size(156, 22);
            this.menuClose.Text = "Cerrar";
            this.menuClose.Click += new System.EventHandler(this.menuClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(153, 6);
            // 
            // menuStartService
            // 
            this.menuStartService.Name = "menuStartService";
            this.menuStartService.Size = new System.Drawing.Size(156, 22);
            this.menuStartService.Text = "Iniciar Servicio";
            this.menuStartService.Click += new System.EventHandler(this.menuStartService_Click);
            // 
            // menuStopService
            // 
            this.menuStopService.Name = "menuStopService";
            this.menuStopService.Size = new System.Drawing.Size(159, 22);
            this.menuStopService.Text = "Detener Servicio";
            this.menuStopService.Click += new System.EventHandler(this.menuStopService_Click);
            // 
            // gbConfig
            // 
            this.gbConfig.Controls.Add(this.btnRefreshDevices);
            this.gbConfig.Controls.Add(this.cbDevices);
            this.gbConfig.Controls.Add(this.lblDevice);
            this.gbConfig.Controls.Add(this.btnStop);
            this.gbConfig.Controls.Add(this.btnStart);
            this.gbConfig.Location = new System.Drawing.Point(12, 13);
            this.gbConfig.Name = "gbConfig";
            this.gbConfig.Size = new System.Drawing.Size(358, 90);
            this.gbConfig.TabIndex = 4;
            this.gbConfig.TabStop = false;
            this.gbConfig.Text = "Configuración";
            // 
            // btnRefreshDevices
            // 
            this.btnRefreshDevices.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshDevices.Image")));
            this.btnRefreshDevices.Location = new System.Drawing.Point(307, 14);
            this.btnRefreshDevices.Name = "btnRefreshDevices";
            this.btnRefreshDevices.Size = new System.Drawing.Size(30, 30);
            this.btnRefreshDevices.TabIndex = 2;
            this.btnRefreshDevices.UseVisualStyleBackColor = true;
            this.btnRefreshDevices.Click += new System.EventHandler(this.btnRefreshDevices_Click);
            // 
            // cbDevices
            // 
            this.cbDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDevices.FormattingEnabled = true;
            this.cbDevices.Location = new System.Drawing.Point(78, 20);
            this.cbDevices.Name = "cbDevices";
            this.cbDevices.Size = new System.Drawing.Size(214, 21);
            this.cbDevices.TabIndex = 1;
            // 
            // lblDevice
            // 
            this.lblDevice.AutoSize = true;
            this.lblDevice.Location = new System.Drawing.Point(7, 20);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(64, 13);
            this.lblDevice.TabIndex = 0;
            this.lblDevice.Text = " Dispositivo:";
            // 
            // gbEstatus
            // 
            this.gbEstatus.Controls.Add(this.lblAddressStatus);
            this.gbEstatus.Controls.Add(this.lblServiceStatus);
            this.gbEstatus.Controls.Add(this.lblDeviceStatus);
            this.gbEstatus.Location = new System.Drawing.Point(12, 111);
            this.gbEstatus.Name = "gbEstatus";
            this.gbEstatus.Size = new System.Drawing.Size(358, 97);
            this.gbEstatus.TabIndex = 5;
            this.gbEstatus.TabStop = false;
            this.gbEstatus.Text = "Estado";
            // 
            // lblAddressStatus
            // 
            this.lblAddressStatus.AutoSize = true;
            this.lblAddressStatus.Location = new System.Drawing.Point(19, 63);
            this.lblAddressStatus.Name = "lblAddressStatus";
            this.lblAddressStatus.Size = new System.Drawing.Size(58, 13);
            this.lblAddressStatus.TabIndex = 5;
            this.lblAddressStatus.Text = "Dirección: ";
            // 
            // lblServiceStatus
            // 
            this.lblServiceStatus.AutoSize = true;
            this.lblServiceStatus.Location = new System.Drawing.Point(26, 40);
            this.lblServiceStatus.Name = "lblServiceStatus";
            this.lblServiceStatus.Size = new System.Drawing.Size(51, 13);
            this.lblServiceStatus.TabIndex = 4;
            this.lblServiceStatus.Text = "Servicio: ";
            // 
            // lblDeviceStatus
            // 
            this.lblDeviceStatus.AutoSize = true;
            this.lblDeviceStatus.Location = new System.Drawing.Point(13, 19);
            this.lblDeviceStatus.Name = "lblDeviceStatus";
            this.lblDeviceStatus.Size = new System.Drawing.Size(64, 13);
            this.lblDeviceStatus.TabIndex = 3;
            this.lblDeviceStatus.Text = "Dispositivo: ";
            // 
            // Main
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 219);
            this.Controls.Add(this.gbEstatus);
            this.Controls.Add(this.gbConfig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Scanner Remote";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.menuNotify.ResumeLayout(false);
            this.gbConfig.ResumeLayout(false);
            this.gbConfig.PerformLayout();
            this.gbEstatus.ResumeLayout(false);
            this.gbEstatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.NotifyIcon notify;
        private System.Windows.Forms.ContextMenuStrip menuNotify;
        private System.Windows.Forms.GroupBox gbConfig;
        private System.Windows.Forms.Button btnRefreshDevices;
        private System.Windows.Forms.ComboBox cbDevices;
        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.GroupBox gbEstatus;
        private System.Windows.Forms.Label lblDeviceStatus;
        private System.Windows.Forms.Label lblServiceStatus;
        private System.Windows.Forms.Label lblAddressStatus;
        private System.Windows.Forms.ToolStripMenuItem menuOpen;
        private System.Windows.Forms.ToolStripMenuItem menuClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuStartService;
        private System.Windows.Forms.ToolStripMenuItem menuStopService;
    }
}

