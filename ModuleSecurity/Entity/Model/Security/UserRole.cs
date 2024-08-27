using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class UserRole
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime ? DeleteAt { get; set; }
        public bool State { get; set; }

        public string RoleId { get; set; }
        public string Role { get; set; }

        public string UserId { get; set; }
        public string User { get; set; }
    }
}

