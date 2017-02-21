using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace DemoAppPortable.BusinessLayer.Contracts
{
    public abstract class BaseEntity : IEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


    }
}
