using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
    public class CityDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Population { get; set; }
        public string ? Department { get; set; }
        public int DepartmentId { get; set; }
        public DateTime YearFundation { get; set; }
      
    }
}
