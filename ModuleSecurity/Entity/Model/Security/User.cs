using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    internal class User
    {
        public int Id {  get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }
        public Boolean State { get; set; }
    }
}
