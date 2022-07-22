using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformMVCExample.CommonInterface;
using WinformMVCExample.Controller;
using WinformMVCExample.Model;
using static WinformMVCExample.Model.eUser;

namespace WinformMVCExample.View
{
    public partial class UserList : Form, IUserListView
    {
        private UserListController controller;

        public bool IsNew { get { return !txtId.ReadOnly; } set { txtId.ReadOnly = !value; } }
        public string Id { get { return txtId.Text; } set { txtId.Text = value; } }
        public string Pw { get { return txtPw.Text; } set { txtPw.Text = value; } }
        public string UserName { get { return txtName.Text; } set { txtName.Text = value; } }
        public string Phone { get { return txtPhone.Text; } set { txtPhone.Text = value; } }
        public int Age
        {
            get
            {
                int age = 0;
                if(int.TryParse(txtAge.Text, out age))
                {
                    return age;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                txtAge.Text = $"{value}";
            }
        }
        public UserSex UserSex
        {
            get
            {
                if(rbtnMale.Checked)
                {
                    return UserSex.MALE;
                }
                else if(rbtnFemale.Checked)
                {
                    return UserSex.FEMALE;
                }
                else
                {
                    return UserSex.MALE;
                }
            }
            set
            {
                UserSex userSex;
                if(Enum.TryParse($"{value}", out userSex))
                {
                    switch(userSex)
                    {
                        case UserSex.MALE:
                            rbtnMale.Checked = true;
                            break;
                        case UserSex.FEMALE:
                            rbtnFemale.Checked = true;
                            break;
                    }
                }
            }
        }


        public UserList()
        {
            InitializeComponent();
        }
        void IControllerable.SetController(IController controller)
        {
            this.controller = controller as UserListController;
            this.controller.NewUser();
        }
        public void LoadGridView()
        {
            lvUserList.Items.Clear();
            foreach(User user in this.controller.Store.Values)
            {
                ListViewItem item = new ListViewItem(user.Id);
                item.SubItems.Add(user.Pw);
                item.SubItems.Add(user.UserName);
                item.SubItems.Add(user.Age.ToString());
                item.SubItems.Add(user.Phone);
                item.SubItems.Add(user.UserSex.ToString());
                lvUserList.Items.Add(item);
            }
        }
        public void ShowMessageBox(string message)
        {
            MessageBox.Show(message);
        }



        private void btnNew_Click(object sender, EventArgs e)
        {
            this.controller.NewUser();
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.controller.RegisterUser();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(txtId.ReadOnly == false)
                return;

            if (lvUserList.SelectedItems.Count <= 0)
                return;

            this.controller.UpdateUser(lvUserList.SelectedItems[0].SubItems[0].Text);
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lvUserList.SelectedItems.Count <= 0)
                return;

            this.controller.RemoveUser(lvUserList.SelectedItems[0].SubItems[0].Text);
        }
        private void rbtnUserSex_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtnMale.Checked)
            {
                rbtnFemale.Checked = false;
            }
            else
            {
                rbtnFemale.Checked = true;
            }
        }
        private void lvUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvUserList.SelectedItems.Count <= 0)
                return;

            this.controller.SelectedUserChanged(lvUserList.SelectedItems[0].SubItems[0].Text);
        }
    }
}
