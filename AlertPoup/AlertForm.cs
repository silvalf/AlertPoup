using AlertPoup.Extensions;
using AlertPoup.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace AlertPoup
{
    public partial class AlertForm : Form
    {
        static Queue<Tuple<AlertDelegate, AlertParameters>> _queueAlert = new Queue<Tuple<AlertDelegate, AlertParameters>>();

        delegate void AlertDelegate(string title, string message, AlertType type);

        private int x;
        private int y;

        private int _maxSecondsVisible = (int)TimeSpan.FromSeconds(5).TotalMilliseconds;

        public string Title { get; private set; }

        public int MaxSecondsVisible
        {
            get
            {
                return _maxSecondsVisible;
            }
            set
            {
                _maxSecondsVisible = (int)TimeSpan.FromSeconds(value).TotalMilliseconds;
            }
        }

        public AlertState State { get; private set; }

        public AlertDirection Direction { get; set; } = AlertDirection.Bottom;

        public int MaxAlertDisplayed { get; set; } = 3;

        public AlertForm()
        {
            InitializeComponent();

            (new Aparence.DropShadow()).ApplyShadows(this);

            this.ShowInTaskbar = false;
        }

        public void Configure(IConfigurationAlert configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            this.MaxAlertDisplayed = configuration.MaxAlertDisplayed;
            this.MaxSecondsVisible = configuration.MaxSecondsVisible;
            this.Direction = configuration.Direction;
            this.lblTitle.Text = configuration.Title;
        }

        public void ShowAlert(string message, AlertType type)
        {
            Title = Enum.GetName(typeof(AlertType), type);
            ShowAlert(Title, message, type);
        }

        public void ShowAlert(string title, string message, AlertType type)
        {
            Title = title;

            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;

            message = TruncateMessage(message);

            int alertVisiblesCount = Application.OpenForms.Cast<Form>().Where(frm => frm.Name.Contains("alertTag")).Count();

            if (alertVisiblesCount >= MaxAlertDisplayed)
            {
                AddAlertInQueue(Title, message, type);
                return;
            }

            string alertname;

            for (int i = 1; i <= MaxAlertDisplayed; i++)
            {
                alertname = $"alertTag{i}";
                var form = (AlertForm)Application.OpenForms[alertname];

                if (form == null)
                {
                    this.Name = alertname;

                    DefineDirectionAndLocation(i, Direction);

                    break;
                }
            }

            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            ChangeTypeAlert(type);

            this.lblTitle.Text = Title;
            this.lblMessage.Text = message;

            this.Show();
            this.State = AlertState.start;

            this.timer1.Interval = 1;
            this.timer1.Start();
        }

        private void DefineDirectionAndLocation(int countAlertVisible, AlertDirection direction)
        {
            const int padding = 5;

            switch (direction)
            {
                case AlertDirection.Bottom:
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * countAlertVisible - padding * countAlertVisible;
                    this.Location = new Point(this.x, this.y);
                    break;
                case AlertDirection.Top:
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = this.Height * countAlertVisible + padding * countAlertVisible;
                    this.Location = new Point(this.x, this.y);
                    break;
                default:
                    break;
            }
        }

        private static string TruncateMessage(string message)
        {
            message = message.Trim();
            if (message.Length > 39)
            {
                message = message.Substring(0, 36);
                message = message.Trim();
                message += "...";
            }
            return message;
        }

        private void ChangeTypeAlert(AlertType type)
        {
            switch (type)
            {
                case AlertType.Success:
                    this.imgIcon.Image = Resources.ok_45px;
                    this.BackColor = Color.SeaGreen;
                    break;
                case AlertType.Info:
                    this.imgIcon.Image = Resources.info_45px;
                    this.BackColor = Color.RoyalBlue;
                    break;
                case AlertType.Warning:
                    this.imgIcon.Image = Resources.warning_shield_45px;
                    this.BackColor = Color.DarkOrange;
                    break;
                case AlertType.Erro:
                    this.imgIcon.Image = Resources.sad_cloud_45px;
                    this.BackColor = Color.DarkRed;
                    break;
                default:
                    break;
            }
        }

        public void ShowAlert(string message)
        {
            ShowAlert(message, AlertType.Info);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OnClose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (State)
            {
                case AlertState.wait: OnWait(); break;
                case AlertState.start: OnStart(); break;
                case AlertState.close: OnClose(); break;
                default:
                    break;
            }
        }

        private void OnStart()
        {
            this.timer1.Interval = 1;
            this.Opacity += 0.1;

            if (this.x < this.Location.X)
            {
                this.Left--;
            }
            else
            {
                if (this.Opacity == 1.0)
                {
                    State = AlertState.wait;
                }
            }
        }

        private void OnWait()
        {
            this.timer1.Interval = MaxSecondsVisible;
            State = AlertState.close;
        }

        private void OnClose()
        {
            this.timer1.Interval = 1;
            this.Opacity -= 0.1;

            this.Left -= 3;
            if (base.Opacity == 0.0)
            {
                base.Close();

                CallAlertOfQueue();
            }

            State = AlertState.close;

        }

        private void AddAlertInQueue(string title, string message, AlertType type)
        {
            var delegateItem = new Tuple<AlertDelegate, AlertParameters>
                (item1: ShowAlert,
                item2: new AlertParameters
                {
                    Title = title,
                    Message = message,
                    AlertType = type
                });
            _queueAlert.Enqueue(delegateItem);
        }

        private static void CallAlertOfQueue()
        {
            if (_queueAlert.Count > 0)
            {
                var callback = _queueAlert.Peek();

                var method = callback.Item1;
                var parameters = callback.Item2;
                method(parameters.Title, parameters.Message, parameters.AlertType);
          
                _queueAlert.Dequeue();
            }
        }
    }

    public class AlertParameters
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public AlertType AlertType { get; set; }
    }

    public enum AlertState
    {
        wait,
        start,
        close,

    }

    public enum AlertType
    {
        Success,
        Info,
        Warning,
        Erro
    }

    public enum AlertDirection
    {
        Bottom,
        Top
    }

}
