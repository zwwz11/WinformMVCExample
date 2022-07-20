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

namespace WinformMVCExample.View
{
    public partial class UserList : Form, IUserListView
    {
        private UserListController controller;

        public UserList()
        {
            InitializeComponent();
        }

        void IUserListView.SetController(UserListController controller)
        {
            this.controller = controller;
        }
    }
}
