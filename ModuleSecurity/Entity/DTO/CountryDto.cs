using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Population { get; set; }
        public string Capital { get; set; }
        public string Coin { get; set; }
        public string Official_language { get; set; }
        public bool State { get; set; }
    }
}
