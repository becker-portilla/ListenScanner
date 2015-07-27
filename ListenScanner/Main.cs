using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace ListenScanner
{
    public partial class Main : Form
    {
        private const string NONE = "NINGUNO";
        private const string KEY_DEVICEID = "deviceId";

        private const string STATUS_DEVICE = "Dispositivo: {0}";
        private const string STATUS_SERVICE = "Servicio: {0}";
        private const string STATUS_ADDRESS = "Dirección: {0}";
        private const string MESSAGE_NINGUNO = "No hay ningún dispositivo conectado.";
        private const string MESSAGE_ACTIVATED = "Activado";
        private const string MESSAGE_DEACTIVATED = "Desactivado";
        private const string MESSAGE_RUN_AS_ADMIN = "Debe ejecutar la aplicación con permisos de administrador.";
        private const string MESSAGE_ERROR_CAPTION = "Error";

        public static string DeviceID;

        private bool exit = false;
        private bool silence = false;

        private string DeviceIdConfig
        {
            get
            {
                return ConfigurationManager.AppSettings.AllKeys.Contains(KEY_DEVICEID) ? ConfigurationManager.AppSettings.Get(KEY_DEVICEID) : string.Empty;
            }
            set
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                if (settings[KEY_DEVICEID] == null)
                {
                    settings.Add(KEY_DEVICEID, value);
                }
                else
                {
                    settings[KEY_DEVICEID].Value = value;
                }

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
        }

        public Main()
        {
            InitializeComponent();
            oSvc = new ServiceHost(typeof(ListenScanner.ScannerService));
        }

        public Main(bool silenceStart)
        {
            InitializeComponent();
            oSvc = new ServiceHost(typeof(ListenScanner.ScannerService));
            silence = silenceStart;
        }

        private ServiceHost oSvc;

        private void btnStart_Click(object sender, EventArgs e)
        {
            string device = ((KeyValuePair<string, string>)cbDevices.SelectedItem).Key;
            if (device != NONE)
            {
                DeviceIdConfig = device;
                try
                {
                    StartService();
                }
                catch //TODO detectar solo la excepcion de privilegios
                {
                    MessageBox.Show(MESSAGE_RUN_AS_ADMIN, MESSAGE_ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(MESSAGE_NINGUNO, MESSAGE_ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopService();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.btnStop.Enabled = false;
            LoadDevices();
            LoadStatus();

            if (silence)
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                Minimize();
            }
        }

        private void LoadDevices()
        {
            List<WIA.DeviceInfo> devicesInfo = WIAScanner.GetDevicesInfo();
            cbDevices.ValueMember = "key";
            cbDevices.DisplayMember = "value";

            cbDevices.Items.Clear();

            foreach (WIA.DeviceInfo d in devicesInfo)
            { 
                this.cbDevices.Items.Add(new KeyValuePair<string, string>(d.DeviceID, 
                        Convert.ToString(d.Properties[3].get_Value())));  // el 3 es la descripcion del dispositivo idem el 6, el 2 es la fabrica
            }

            if (devicesInfo.Count == 0)
            {
                this.cbDevices.Items.Add(new KeyValuePair<string, string>(NONE, NONE));
            }

            int indexDevice = cbDevices.Items.IndexOf(new KeyValuePair<string, string>(DeviceIdConfig, string.Empty));

            if (string.IsNullOrEmpty(DeviceIdConfig) || indexDevice < 0)
                cbDevices.SelectedIndex = 0;
            else
                cbDevices.SelectedIndex = indexDevice;
        }

        private void btnRefreshDevices_Click(object sender, EventArgs e)
        {
            LoadDevices();
            LoadStatus();
        }

        private void StartService()
        {
            oSvc.Open();
            DeviceID = DeviceIdConfig;
            this.btnStart.Enabled = false;
            this.btnStop.Enabled = true;
            this.cbDevices.Enabled = false;
            this.btnRefreshDevices.Enabled = false;
            LoadStatus();
        }

        private void StopService()
        {
            if(oSvc.State == CommunicationState.Opened)
                oSvc.Close();
            btnStop.Enabled = false;
            btnStart.Enabled = true;
            this.cbDevices.Enabled = true;
            this.btnRefreshDevices.Enabled = true;
            LoadStatus();
        }

        private void LoadStatus()
        {
            lblDeviceStatus.Text = string.Format(STATUS_DEVICE, ((KeyValuePair<string, string>)cbDevices.SelectedItem).Value);
            lblServiceStatus.Text = string.Format(STATUS_SERVICE, (oSvc.State == CommunicationState.Opened ? MESSAGE_ACTIVATED : MESSAGE_DEACTIVATED));
            lblAddressStatus.Text = string.Format(STATUS_ADDRESS, oSvc.BaseAddresses.FirstOrDefault().AbsoluteUri);
        }

        private void menuOpen_Click(object sender, EventArgs e)
        {
            ShowApp();
        }

        private void menuStartService_Click(object sender, EventArgs e)
        {
            StartService();
        }

        private void menuStopService_Click(object sender, EventArgs e)
        {
            StopService();
        }

        private void menuClose_Click(object sender, EventArgs e)
        {
            exit = true;
            StopService();
            Application.Exit();
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            Minimize();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !exit;
            this.WindowState = FormWindowState.Minimized;
            Minimize();
        }

        private void Minimize()
        {
            Minimize(silence);
        }

        private void Minimize(bool silence)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notify.Icon = this.Icon;
                notify.ContextMenuStrip = this.menuNotify;
                notify.Text = this.Text;
                notify.Visible = true;
                this.Visible = false;

                notify.BalloonTipIcon = ToolTipIcon.Info;
                notify.BalloonTipTitle = this.Text;

                if (!silence)
                {
                    notify.BalloonTipText = "La aplicación ha quedado ocultada en el área de notificación.";
                    notify.ShowBalloonTip(8);
                }
            }
        }

        private void ShowApp()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            notify.Visible = false;
            silence = false;
            this.ShowInTaskbar = true;
        }
    }
}
