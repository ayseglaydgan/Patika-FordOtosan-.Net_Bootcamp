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
            /// Employee Tablosuna kay�t. i�lemi i�in kullan�lan metod 
            /// </summary> 
            /// <param name="em">Employee Nesnesi</param> 
            public bool InsertIntoEmployeeTable(Employee em)
            {
                // Employee Tablosuna kay�t. 
                return true;
            }
            /// <summary> 
            /// Rapor olu�turmak i�in kullan�lan metod 
            /// </summary> 
            /// <param name="em"></param> 
            public void RaporOlustur(Employee em)
            {
                // Crystal report kullan�larak rapor olu�turma. 
            }
        }
    }
}