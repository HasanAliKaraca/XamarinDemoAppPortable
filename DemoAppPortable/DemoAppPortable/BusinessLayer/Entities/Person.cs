using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoAppPortable.BusinessLayer.Contracts;

namespace DemoAppPortable.BusinessLayer.Entities
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
