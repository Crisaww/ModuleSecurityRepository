using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class View
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime ? DeleteAt { get; set; }
        public bool State { get; set; }
        public string Route { get; set; }

        public string ModuleId { get; set; }
        public string Module{ get; set; }

       
    }
}

