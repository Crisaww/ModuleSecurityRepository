﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ? UpdateAt { get; set; }
        public DateTime ? DeleteAt { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public string Population { get; set; }
        public string Capital { get; set; }
    }
}
