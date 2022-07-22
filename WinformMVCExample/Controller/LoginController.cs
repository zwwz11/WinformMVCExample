using System.Collections.Generic;
using System.Windows.Forms;
using WinformMVCExample.Model;
using WinformMVCExample.View;

namespace WinformMVCExample.Controller
{
    class LoginController : IController
    {
        private ILoginView view = null;
        private Dictionary<string, User> store = null;

        public LoginController(ILoginView view, Dictionary<string, User> store)
        {
            this.view = view;
            this.store = store;
            view.SetController(this);
        }

        public void Login()
        {
            if(store.ContainsKey(this.view.Id))
            {
                if(this.view.Pw == store[this.view.Id].Pw)
                {
                    (this.view as Login).DialogResult = DialogResult.OK;
                    (this.view as Login).Close();
                }
                else
                {
                    view.ShowMessageBox("비밀번호를 확인해주세요!");
                }
            }
            else
            {
                view.ShowMessageBox("존재하지 않는 아이디입니다!");
            }
        }
    }
}
