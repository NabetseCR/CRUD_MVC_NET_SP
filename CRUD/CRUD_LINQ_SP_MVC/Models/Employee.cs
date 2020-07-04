using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_LINQ_SP_MVC.Models
{
    public class Employee
    {
        //Attributes
        public int emid { get; set; }
        public string emname { get; set; }
        public string email { get; set; }
        public int salary { get; set; }
    }
}