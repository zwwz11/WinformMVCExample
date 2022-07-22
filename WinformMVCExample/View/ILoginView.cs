using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinformMVCExample.CommonInterface;
using WinformMVCExample.Controller;

namespace WinformMVCExample.View
{
    interface ILoginView : IMessageable, IControllerable
    {
        string Id { get; set; }
        string Pw { get; set; }
    }
}
