﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Lapshin1515
{
    public class PayrollDatabase
    {
        private static Hashtable employees = new Hashtable();

        public static void AddEmployee(int id, Employee employee)
        {
            employees[id] = employee;
        }

        public static Employee GetEmployee(int id)
        {
            return employees[id] as Employee;
        }
    }
}
