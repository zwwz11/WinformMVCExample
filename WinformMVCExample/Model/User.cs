using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformMVCExample.Model
{
    class User
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public eUser.UserSex Sex { get; set; }
        public string name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
    }
}
