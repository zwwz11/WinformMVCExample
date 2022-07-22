using System.Collections.Generic;
using WinformMVCExample.Model;
using WinformMVCExample.View;

namespace WinformMVCExample.Controller
{
    class UserListController : IController
    {
        private IUserListView view = null;
        User loginUser = null;
        Dictionary<string, User> store = null;
        public Dictionary<string, User> Store { get { return store; } }

        public UserListController(IUserListView view, Dictionary<string, User> store, User loginUser)
        {
            this.view = view;
            this.loginUser = loginUser;
            this.store = store;

            view.SetController(this);
            view.SetUserAuthComboBox();
            view.InitControlByAuth(loginUser.UserAuth);
            view.LoadGridView();
        }

        public void RegisterUser()
        {
            if (string.IsNullOrWhiteSpace(view.Id))
                return;

            if (CanRegisterUser())
            {
                User user = new User()
                {
                    Id = view.Id,
                    Pw = view.Pw,
                    UserName = view.UserName,
                    Age = view.Age,
                    UserSex = view.UserSex,
                    Phone = view.Phone,
                    UserAuth = view.UserAuth
                };

                this.store.Add(user.Id, user);
                NewUser();
                view.LoadGridView();
            }
            else
            {
                view.ShowMessageBox("이미 등록된 유저입니다.");
            }
        }

        public bool CanRegisterUser()
        {
            return !this.store.ContainsKey(view.Id);
        }

        public void SelectedUserChanged(string id)
        {
            User user = this.store[id];
            view.Id = user.Id;
            view.Pw = user.Pw;
            view.UserName = user.UserName;
            view.Age = user.Age;
            view.UserSex = user.UserSex;
            view.Phone = user.Phone;

            view.IsNew = false;
        }

        public void NewUser()
        {
            view.Id = string.Empty;
            view.Pw = string.Empty;
            view.UserName = string.Empty;
            view.UserSex = eUser.UserSex.MALE;
            view.Age = 0;
            view.Phone = string.Empty;
            view.IsNew = true;
        }

        public void UpdateUser(string id)
        {
            User targetUser = this.store[id];
            targetUser.Pw = view.Pw;
            targetUser.UserName = view.UserName;
            targetUser.Age = view.Age;
            targetUser.UserSex = view.UserSex;
            targetUser.Phone = view.Phone;
            targetUser.UserAuth = view.UserAuth;

            view.IsNew = false;
            view.LoadGridView();
        }

        public void RemoveUser(string id)
        {
            if(store.ContainsKey(id))
            {
                store.Remove(id);
                NewUser();
                view.LoadGridView();
            }
        }

        public void Logout()
        {
            view.CloseWithDialogResult(System.Windows.Forms.DialogResult.Retry);
        }

    }
}
