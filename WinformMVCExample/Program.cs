using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformMVCExample.Controller;
using WinformMVCExample.Model;
using WinformMVCExample.View;

namespace WinformMVCExample
{
    static class Program
    {
        static Dictionary<string, User> store = new Dictionary<string, User>();
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            User user = new User();
            user.Id = "admin";
            user.Pw = "1234";
            user.UserName = "Test";
            user.Age = 20;
            user.UserSex = eUser.UserSex.MALE;
            user.Phone = "010-0000-0000";
            user.UserAuth = eUser.UserAuth.ADMIN;
            store.Add(user.Id, user);

            while(true)
            {
                Login loginForm = new Login();
                LoginController controller = new LoginController(loginForm, store);
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    User loginUser = store[loginForm.Id];
                    UserList userListForm = new UserList();
                    UserListController userListController = new UserListController(userListForm, store, loginUser);
                    Application.Run(userListForm);

                    if (userListForm.DialogResult == DialogResult.Retry)
                    {
                        continue;
                    }
                    else
                    {
                        Application.Exit();
                        break;
                    }
                }
                else
                {
                    Application.Exit();
                    break;
                }
            }
        }
    }
}
