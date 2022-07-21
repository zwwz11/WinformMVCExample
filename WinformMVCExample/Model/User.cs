using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WinformMVCExample.Model.eUser;

namespace WinformMVCExample.Model
{
    public class User
    {
        public string Id { get; set; }
        public string Pw { get; set; }
        public UserSex UserSex { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
    }
}
