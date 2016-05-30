using FirstCacheTesting.Tables;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCacheTesting.TablesMaps
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Cache.ReadWrite();
            Table("employee");
            Id(x => x.ID);
            Map(x => x.Name);
            References(x => x.Department, "departmentid");
        }
    }
}
