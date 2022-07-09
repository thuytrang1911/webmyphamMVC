using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhamOBJ
{
    public class UserOBJ
    {
        public string MaNV { get; set; }
        public string Pas { get; set; }
        public string Role { get; set; }
        public string Action { get; set; }
        public UserOBJ(string manv, string pas, string role, string action)
        {
            this.MaNV = manv;
            this.Pas = pas;
            this.Role = role;
            this.Action = action;
        }
        public UserOBJ() { }
    }
}
