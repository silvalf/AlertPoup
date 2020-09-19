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
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void Alert(string message, AlertType type)
        {
            var formAlert = new AlertForm();

            formAlert.MaxSecondsVisible = TryConvertInt(txtMaxSecondsVisible.Text);
            formAlert.MaxAlertDisplayed = TryConvertInt(txtMaxAlertsVisible.Text);
            formAlert.Direction = rdoShowBottom.Checked ? AlertDirection.Bottom : AlertDirection.Top;

            if (chkWithTitle.Checked)
            {
                formAlert.ShowAlert(txtTitle.Text, message, type);
            }
            else
            {
                formAlert.ShowAlert(message, type);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Alert(txtMessage.Text, AlertType.Success);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Alert(txtMessage.Text, AlertType.Info);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Alert(txtMessage.Text, AlertType.Warning);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Alert(txtMessage.Text, AlertType.Erro);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            txtMaxSecondsVisible.Text = $"{trackMaxSecondsVisible.Value}";
        }

        private void trackMaxAlertsVisible_ValueChanged(object sender, EventArgs e)
        {
            txtMaxAlertsVisible.Text = $"{trackMaxAlertsVisible.Value}";
        }

        private void txtMaxAlertsVisible_TextChanged(object sender, EventArgs e)
        {
            var value = TryConvertInt(txtMaxAlertsVisible.Text);
            if (value < trackMaxAlertsVisible.Minimum || value > trackMaxAlertsVisible.Maximum)
            {
                MessageBox.Show($"The minimum value is {trackMaxAlertsVisible.Maximum} and the maximum value is {trackMaxAlertsVisible.Maximum}");
                txtMaxAlertsVisible.Text = "0";
            }
        }

        private void txtMaxSecondsVisible_TextChanged(object sender, EventArgs e)
        {
            var value = TryConvertInt(txtMaxSecondsVisible.Text);
            if (value < trackMaxSecondsVisible.Minimum || value > trackMaxAlertsVisible.Maximum)
            {
                MessageBox.Show($"The minimum value is {trackMaxSecondsVisible.Maximum} and the maximum value is {trackMaxSecondsVisible.Maximum}");
                txtMaxAlertsVisible.Text = "0";
            }
        }

        private int TryConvertInt(string text)
        {
            int value;
            int.TryParse(text, out value);
            return value;
        }
    }
}
