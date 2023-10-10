using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Core.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Country() { }
        public Country(int id, string name) 
        {
            Id = id;
            Name = name;
        }
        

    }
}
