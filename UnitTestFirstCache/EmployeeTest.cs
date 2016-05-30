using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using FirstCacheTesting;
using FirstCacheTesting.Tables;
using System.Linq;
using Memcached.ClientLibrary;

namespace UnitTestFirstCache
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void ShouldNotFireMultipleQueriesWhenEntitiesAreFetchedUsingIdentifiers()
        {
     
            ISession session = NHibernateSessionHelper.OpenSession();
            //Loading the employee with ID = 1.
            var employeeUsingTheFirstQuery = session.Get<Employee>(1L);
            //Reloading the employee with ID = 1.
            var employeeUsingTheSecondQuery = session.Get<Employee>(1L);
            //Asserting that the employee loaded from the first query 
            //is references equals to the employee loaded from the second query.
            Assert.AreSame(employeeUsingTheFirstQuery, employeeUsingTheSecondQuery);
        }
        [TestMethod]
        public void ShouldNotFireMultipleQueriesWhenEntitiesWithGivenIdentifiersAreAlreadyLoaded()
        {
            ISession session = NHibernateSessionHelper.OpenSession();
            //Loading the department with ID = 1.
            var department = session.Get<Department>(1L);
            //Asserting that the department has 1 employee.
            Assert.IsTrue(department.Employees.Count == 3);

            //Getting the first employee of the billing department
            Employee firstEmployeeOfTheBillingDepartment =
                                         department.Employees.First();
            //Asserting that the ID of the first employee of Billing department is 1
            Assert.IsTrue(firstEmployeeOfTheBillingDepartment.ID == 1L);
            //Trying to fetch the employee with ID = 1 from the DB again.
            Employee employee = session.Get<Employee>(1L);
        }
    }
}
