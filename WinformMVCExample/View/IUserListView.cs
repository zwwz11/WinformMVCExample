using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinformMVCExample.CommonInterface;
using WinformMVCExample.Controller;
using static WinformMVCExample.Model.eUser;

namespace WinformMVCExample.View
{
    interface IUserListView : IMessageable
    {
        void SetController(UserListController controller);
        bool IsNew { get; set; }
        string Id { get; set; }
        string Pw { get; set; }
        string UserName { get; set; }
        int Age { get; set; }
        string Phone { get; set; }
        UserSex UserSex { get; set; }

        void LoadGridView();
    }
}
