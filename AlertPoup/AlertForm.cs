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
        static Queue<Tuple<Action<string, AlertType>, string, AlertType>> _queueAlert = new Queue<Tuple<Action<string, AlertType>, string, AlertType>>();

        private int x;
        private int y;

        private int _maxSecondsVisible = (int)TimeSpan.FromSeconds(5).TotalMilliseconds;
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
        public int MaxAlertDisplayed { get; set; } = 3;

        public AlertForm()
        {
            InitializeComponent();

            (new Aparence.DropShadow()).ApplyShadows(this);

            this.ShowInTaskbar = false;
        }

        public void ShowAlert(string message, AlertType type)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;

            message = TruncateMessage(message);

            int alertVisiblesCount = Application.OpenForms.Cast<Form>().Where(frm => frm.Name.Contains("alertTag")).Count();

            if (alertVisiblesCount >= MaxAlertDisplayed)
            {
                AddAlertInQueue(message, type);
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

                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);

                    break;
                }
            }

            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            ChangeTypeAlert(type);

            this.lblMessage.Text = message;

            this.Show();
            this.State = AlertState.start;

            this.timer1.Interval = 1;
            this.timer1.Start();
        }

        private void AddAlertInQueue(string message, AlertType type)
        {
            _queueAlert.Enqueue(new Tuple<Action<string, AlertType>, string, AlertType>(
                                                   delegate (string messageParam, AlertType typeParam) { ShowAlert(message, type); },
                                                   message,
                                                   type));
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
                    this.lblTitulo.Text = "Sucesso";
                    this.imgIcon.Image = Resources.ok_45px;
                    this.BackColor = Color.SeaGreen;
                    break;
                case AlertType.Info:
                    this.lblTitulo.Text = "Informação";
                    this.imgIcon.Image = Resources.info_45px;
                    this.BackColor = Color.RoyalBlue;
                    break;
                case AlertType.Warning:
                    this.lblTitulo.Text = "Aviso";
                    this.imgIcon.Image = Resources.warning_shield_45px;
                    this.BackColor = Color.DarkOrange;
                    break;
                case AlertType.Erro:
                    this.lblTitulo.Text = "Erro";
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

        private static void CallAlertOfQueue()
        {
            if (_queueAlert.Count > 0)
            {
                var callback = _queueAlert.Peek();
                callback.Item1.Invoke(callback.Item2, callback.Item3);
                _queueAlert.Dequeue();
            }
        }
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

    //class CallbackAler
    //{
    //    private string _message;
    //    private AlertType _alertType;

    //    public CallbackAler(string message, AlertType type)
    //    {
    //        _message = message;
    //        _alertType = type;
    //    }

    //    public void Show()
    //    {

    //    }
    //}


    //public enum Operation
    //{
    //    Sum,
    //    Subtract,
    //    Multiply
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var opManager = new OperationManager(20, 10);
    //        var result = opManager.Execute(Operation.Sum);
    //        Console.WriteLine($"The result of the operation is {result}");
    //        Console.ReadKey();
    //    }
    //}
    //public class OperationManager
    //{
    //    private int _first;
    //    private int _second;
    //    public OperationManager(int first, int second)
    //    {
    //        _first = first;
    //        _second = second;
    //    }
    //    private int Sum()
    //    {
    //        return _first + _second;
    //    }
    //    private int Subtract()
    //    {
    //        return _first - _second;
    //    }
    //    private int Multiply()
    //    {
    //        return _first * _second;
    //    }
    //    public int Execute(Operation operation)
    //    {
    //        switch (operation)
    //        {
    //            case Operation.Sum:
    //                return Sum();
    //            case Operation.Subtract:
    //                return Subtract();
    //            case Operation.Multiply:
    //                return Multiply();
    //            default:
    //                return -1; //just to simulate
    //        }
    //    }
    //}


}
