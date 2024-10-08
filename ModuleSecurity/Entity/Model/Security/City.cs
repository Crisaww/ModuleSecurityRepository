﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ? UpdateAt { get; set; }
        public DateTime ? DeleteAt { get; set; }

        public int DepartmentId {  get; set; }
        public Department Department { get; set; }
        public string Population { get; set; }
        public DateTime YearFundation { get; set; }
        
    }
}
