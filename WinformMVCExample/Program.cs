using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformMVCExample.Controller;
using WinformMVCExample.View;

namespace WinformMVCExample
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Login loginForm = new Login();
            ViewController controller = new ViewController(loginForm);
            Application.Run(loginForm);
        }
    }
}
