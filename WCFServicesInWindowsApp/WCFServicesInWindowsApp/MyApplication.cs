using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCFServicesInWindowsApp
{
    public partial class WCFService : Form
    {
        public WCFService()
        {
            InitializeComponent();
        }

        private void btnClick_Click(object sender, System.EventArgs e)
        {
            // Call or invoke the WCF service
            ServiceReference1.Service1Client service1Client = new ServiceReference1.Service1Client();
            string userName = service1Client.GetUserName(txtName.Text);
            if(!String.IsNullOrEmpty(userName))
            {
                lblResponseName.Visible = true;
                lblResponseName.Text = userName;
            }
            else
            {
                MessageBox.Show("Please provide user name!!!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
