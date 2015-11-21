using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payroll_Lapshin1515;
using System.Text;

namespace PayrollTest_Lapshin1515
{
    [TestClass]
    public class PayrollTest_Lapshin1515
    {
        [TestMethod]
        public void TestEmployee()
        {
            int empId = 1;
            Employee e = new Employee(empId, "Bob", "Home");
            Assert.AreEqual("Bob", e.Name);
            Assert.AreEqual("Home", e.Address);
            Assert.AreEqual(empId, e.EmpId);
        }

        [TestMethod]
        public void TestEmployeeToString()
        {
            int empId = 1;
            Employee e = new Employee(empId, "Bob", "Home");

            StringBuilder builder = new StringBuilder();
            builder.Append("Emp#: ").Append(empId).Append("   ");
            builder.Append("Bob").Append("   ");
            builder.Append("Home").Append("   ");
            builder.Append("Paid ").Append(e.Classification).Append("   ");
            builder.Append(e.Schedule);
            builder.Append(" by ").Append(e.Method);

            Assert.AreEqual(e.ToString(), builder.ToString());
        }
       
        [TestMethod]

        public void TestAddSalariedEmployee()
        {
            int empId = 1;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bob", "Home", 1000.00);
            t.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Bob", e.Name);
            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is SalariedClassification);
            SalariedClassification sc = pc as SalariedClassification;
            Assert.AreEqual(1000.00, sc.Salary, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is MonthlySchedule);
            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }

        [TestMethod]

        public void TestAddHourlyEmployee()
        {
            int empId = 1;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bob", "Home", 8.5);
            t.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Bob", e.Name);
            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is HourlyClassification);
            HourlyClassification sc = pc as HourlyClassification;
            Assert.AreEqual(8.5, sc.HourlyRate, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is WeeklySchedule);
            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }


        [TestMethod]

        public void TestAddCommissionedEmployee()
        {
            int empId = 1;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "Bob", "Home", 1000.00, 0.50);
            t.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Bob", e.Name);
            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is CommissionedClassification);
            CommissionedClassification sc = pc as CommissionedClassification;
            Assert.AreEqual(1000, sc.Salary, .001);
            Assert.AreEqual(0.50, sc.CommissionRate, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is BiweeklySchedule);
            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }


    }
}
