using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinformMVCExample.Controller;

namespace WinformMVCExample.CommonInterface
{
    interface IControllerable
    {
        void SetController(IController controller);
    }
}
