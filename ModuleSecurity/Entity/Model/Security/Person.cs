using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    internal class Person
    {
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public String Type_document {  get; set; }
        public String Document { get; set; }
        public DateTime Birth_of_date {  get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }
        public String Phone {  get; set; }
        public Boolean State {  get; set; }
    }
}
