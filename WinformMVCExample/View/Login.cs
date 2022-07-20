using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformMVCExample.Controller;
using WinformMVCExample.View;

namespace WinformMVCExample
{
    public partial class Login : Form, ILoginView
    {
        ViewController controller;

        public string Id { get { return txtId.Text; } set { txtId.Text = value; } }
        public string Pw { get { return txtPw.Text; } set { txtPw.Text = value; } }


        public Login()
        {
            InitializeComponent();
        }

        void ILoginView.SetController(ViewController controller)
        {
            this.controller = controller;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.controller.Login();
        }

    }
}
