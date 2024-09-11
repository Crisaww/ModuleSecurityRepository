using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
    public class UserDto
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public bool State { get; set; }
        public string PersonId { get; set; }
    }
}
