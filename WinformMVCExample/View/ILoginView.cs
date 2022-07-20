using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinformMVCExample.Controller;

namespace WinformMVCExample.View
{
    interface ILoginView
    {
        string Id { get; set; }
        string Pw { get; set; }
        void SetController(ViewController controller);
    }
}
