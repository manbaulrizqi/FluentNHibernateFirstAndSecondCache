using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCacheTesting.Tables
{
    public class Employee
    {
        public virtual long ID { get; set; }
        public virtual string Name { get; set; }
        public virtual Department Department { get; set; }
    }
}
