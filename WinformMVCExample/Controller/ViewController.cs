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
    class ViewController
    {
        private ILoginView view = null;

        private readonly string testId = "testid";
        private readonly string testPw = "test123";

        public ViewController(ILoginView view)
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
                MessageBox.Show("로그인 성공");
            }
            else
            {
                MessageBox.Show("아이디 비밀번호를 확인해주세요");
            }
        }
    }
}
