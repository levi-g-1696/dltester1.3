using System;
using System.Drawing;
using System.Windows.Forms;
using Entities.Models;
using Entities;
using System.Text.RegularExpressions;
using System.Net;

namespace UI
{
    public delegate void DestSaveEventHanler(Destination dest, Editmode saveMode);
    public partial class Form_Destination_NewEdit : Form, IForm
    {

        public static event DestSaveEventHanler SaveAction;
        Editmode saveMode;
        Form_DestinationsView form_Dest;
        public Form_Destination_NewEdit(Editmode editmode, Form_DestinationsView form_DestArg)
        {
            InitializeComponent();
            form_Dest = form_DestArg;
            saveMode = editmode;
            if (editmode == Editmode.New) // empty form
            {
                cmbPotocol.SelectedIndex = 1;
                UISessionValue.Destination.Protocolid = 21;
                UISessionValue.Destination.ProtocolType = "FTP";
                UISessionValue.Destination.DestinationId = 0;

                txtVirPath.Text = "/";
            }
            else  // edit an exist
            {
                txtVirPath.Text = UISessionValue.Destination.VirtualPath;
                txtUser.Text = UISessionValue.Destination.SrvUser;
                txtPassword.Text = UISessionValue.Destination.SrvPassword;
                txtName.Text = UISessionValue.Destination.Name;
                txtIP.Text = UISessionValue.Destination.Ipaddress;
                cmbPotocol.Text = UISessionValue.Destination.ProtocolType;
                txtPort.Text = UISessionValue.Destination.Port.ToString();
            }
        }

        private void txtIPaddress_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)

        {
            if (UIinputValidation())
            {
                switch (cmbPotocol.SelectedIndex)

                {
                    case (0):
                        UISessionValue.Destination.Protocolid = 445;
                        UISessionValue.Destination.ProtocolType = "SMB";
                        break;
                    case (1):
                        UISessionValue.Destination.Protocolid = 21;
                        UISessionValue.Destination.ProtocolType = "FTP";
                        break;
                    case (2):
                        UISessionValue.Destination.Protocolid = 22;
                        UISessionValue.Destination.ProtocolType = "SFTP";
                        break;
                }
                int x = 0;

                Int32.TryParse(txtPort.Text, out x);
                UISessionValue.Destination.Port = x;
                UISessionValue.Destination.VirtualPath = txtVirPath.Text;
                UISessionValue.Destination.SrvUser = txtUser.Text;
                UISessionValue.Destination.SrvPassword = txtPassword.Text;
                UISessionValue.Destination.Name = txtName.Text;
                UISessionValue.Destination.Ipaddress = txtIP.Text;
                Save();
                RefreshPreviousWindow();
                this.Close();
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
        }

        //###########################################################
        public bool UIinputValidation()
        {
            int p;
            bool isValid = true;
            IPAddress ip;

            //===================  Name ======================
            string regexName = "^([a-zA-Z][a-zA-Z0-9' ]{0,49})$";
            if (!Regex.Match(txtName.Text, regexName).Success)
            {
                txtName.BackColor = Color.Salmon;
                isValid = false;
            }

            //==================== Port  ==========

            if (!int.TryParse(txtPort.Text, out p))

            {

                txtPort.BackColor = Color.Salmon;
                isValid = false;
            }


            else
            {
                int.TryParse(txtPort.Text, out p);
                if ((p > 65535) || (p < 0))
                {
                    isValid = false;
                    txtPort.BackColor = Color.Salmon;
                }
            }
            //======================== ipAddress ================
            bool b = IPAddress.TryParse(txtIP.Text, out ip);

            if (!b)
            {
                txtIP.BackColor = Color.Salmon;
                isValid = false;
            }

            //===================  user =============
            if (!Regex.Match(txtUser.Text, regexName).Success)
            {
                txtUser.BackColor = Color.Salmon;
                isValid = false;
            }

            //================== PASSWORD ===============
            
            if (txtPassword.Text.Length<3)
            {
                txtPassword.BackColor = Color.Salmon;
                isValid = false;
            }

            return isValid;
        }



        public void Save()
        {
            SaveAction(UISessionValue.Destination, saveMode);
        }

        public void RefreshPreviousWindow()
        {
            form_Dest.DestGridRefresh();
        }
    }
}
