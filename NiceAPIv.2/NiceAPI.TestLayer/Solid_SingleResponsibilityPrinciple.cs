using NUnit.Framework;

namespace NiceAPI.TestLayer
{
    public class Solid_SingileResponsibilityPrinciple
    {
        public class Employee
        {
            //Single responsibility principle 
            public int EmployeeId { get; set; }
            public string EmployeeName { get; set; }
            /// <summary> 
            /// Employee Tablosuna kayýt. iþlemi için kullanýlan metod 
            /// </summary> 
            /// <param name="em">Employee Nesnesi</param> 
            public bool InsertIntoEmployeeTable(Employee em)
            {
                // Employee Tablosuna kayýt. 
                return true;
            }
            /// <summary> 
            /// Rapor oluþturmak için kullanýlan metod 
            /// </summary> 
            /// <param name="em"></param> 
            public void RaporOlustur(Employee em)
            {
                // Crystal report kullanýlarak rapor oluþturma. 
            }
        }
    }
}