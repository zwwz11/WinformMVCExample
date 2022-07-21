using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformMVCExample.Model;
using WinformMVCExample.View;

namespace WinformMVCExample.Controller
{
    class LoginController
    {
        private ILoginView view = null;

        private readonly string testId = "testid";
        private readonly string testPw = "test123";

        public LoginController(ILoginView view)
        {
            this.view = view;
            view.SetController(this);
        }

        public void Login()
        {
            /*
             * 유효성 테스트
             * ID = testid
             * PW = test123 
             */

            if(this.view.Id == testId && this.view.Pw == testPw)
            {
                (this.view as Login).DialogResult = DialogResult.OK;
                (this.view as Login).Close();
            }
            else
            {
                view.ShowMessageBox("아이디 비밀번호를 확인해주세요");
            }
        }
    }
}
