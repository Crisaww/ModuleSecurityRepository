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
        public string RoleId { get; set; }
        public string UserId { get; set; }
    }
}