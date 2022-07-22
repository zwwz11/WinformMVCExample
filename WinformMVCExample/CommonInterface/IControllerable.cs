using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformMVCExample.CommonInterface
{
    interface IControllerable
    {
        void SetController(IController controller);
    }
}
