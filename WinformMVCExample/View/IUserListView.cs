using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformMVCExample.CommonInterface;
using WinformMVCExample.Controller;
using static WinformMVCExample.Model.eUser;

namespace WinformMVCExample.View
{
    interface IUserListView : IMessageable, IControllerable
    {
        bool IsNew { get; set; }
        string Id { get; set; }
        string Pw { get; set; }
        string UserName { get; set; }
        int Age { get; set; }
        string Phone { get; set; }
        UserSex UserSex { get; set; }
        UserAuth UserAuth { get; set; }

        void LoadGridView();
        void InitControlByAuth(UserAuth userAuth);
        void SetUserAuthComboBox();
        void CloseWithDialogResult(DialogResult dialogResult);
    }
}
