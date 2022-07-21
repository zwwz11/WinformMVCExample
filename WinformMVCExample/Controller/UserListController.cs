using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinformMVCExample.Model;
using WinformMVCExample.View;

namespace WinformMVCExample.Controller
{
    class UserListController
    {
        IUserListView view = null;
        Dictionary<string, User> store = new Dictionary<string, User>();
        public Dictionary<string, User> Store { get { return store; } }

        public UserListController(IUserListView view)
        {
            this.view = view;
            view.SetController(this);
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
                    Phone = view.Phone
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

    }
}
