﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
    public class UserRoleDto
    {
        public int Id { get; set; }
        public bool State { get; set; }
        public string ? Role { get; set; }
        public int RoleId { get; set; }
        public string ? User { get; set; }
        public int UserId { get; set; }
    }
}
