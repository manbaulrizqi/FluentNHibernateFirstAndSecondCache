using FirstCacheTesting.Tables;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCacheTesting.TablesMaps
{
    public class DepartmentMap : ClassMap<Department>
    {
        public DepartmentMap()
        {
            Cache.ReadWrite();
            Table("department");
            Id(x => x.ID);
            Map(x => x.Name);
            HasMany(x => x.Employees)
                .KeyColumn("departmentid")
                .LazyLoad()
                .Inverse()
                .Cascade.All();
        }
    }
}
