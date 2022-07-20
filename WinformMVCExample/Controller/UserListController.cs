using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinformMVCExample.View;

namespace WinformMVCExample.Controller
{
    class UserListController
    {
        IUserListView view = null;

        public UserListController(IUserListView view)
        {
            this.view = view;
            view.SetController(this);
        }
    }
}
