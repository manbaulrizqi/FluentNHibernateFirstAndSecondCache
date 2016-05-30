using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCacheTesting.Tables
{
    public class Department
    {
        public virtual long ID { get; set; }
        public virtual string Name { get; set; }
        public virtual ISet<Employee> Employees { get; set; }
        public Department()
        {
            Employees = new HashSet<Employee>();
        }
    }
}
