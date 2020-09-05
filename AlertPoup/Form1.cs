using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace AlertPoup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            
        }

        private void Alert(string message, AlertType type)
        {
            var formAlert = new AlertForm();

            formAlert.MaxAlertDisplayed = 10;
            formAlert.MaxSecondsVisible = 6;
            formAlert.ShowAlert(message, type);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Alert("Test Success. Mensagem grande texto cumprido", AlertType.Success);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Alert("Test Info", AlertType.Info);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Alert("Test Warning", AlertType.Warning);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Alert("Test Error", AlertType.Erro);
        }
    }
}
