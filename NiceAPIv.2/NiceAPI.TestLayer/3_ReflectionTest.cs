using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NiceAPI.TestLayer
{
    

   
    public class Student
        {
            public int RollNo { get; set; }
            public string Name { get; set; }

            public Student()
            {
                RollNo = 0;
                Name = string.Empty;
            }

            public Student(int rno, string n)
            {
                RollNo = rno;
                Name = n;
            }

            public void displayData()
            {
                Console.WriteLine("Roll Number : {0}", RollNo);
                Console.WriteLine("Name : {0}", Name);
            }
        }
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
        }

        public class ReflectionTest
        {
            [Test]
            public void Test0()
            {
                int a = 10;
                Type type = a.GetType();
                Console.WriteLine(type);
                // System.Int32

                Type t = typeof(System.String);
                Console.WriteLine(t.Assembly);
                //mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089


                Type t2 = typeof(System.String);
                Console.WriteLine(t2.FullName); // System.String
                Console.WriteLine(t2.BaseType); // System.Object
                Console.WriteLine(t2.IsClass);//  true 
                Console.WriteLine(t2.IsEnum); //  false
                Console.WriteLine(t2.IsInterface); //  false
            }

            [Test]
            public void Test5()
            {
                List<string> propList = new List<string>();
                User o = new User();
                o.GetType().GetProperties().ToList().ForEach(p =>
                {
                    propList.Add(p.Name);
                });

                foreach (var item in propList)
                {
                    Console.WriteLine(item);
                }

            }


            [Test]
            public void Test3()
            {
                var user = new User
                {
                    Id = 1,
                    Name = "Recep",
                    Surname = "Yesil"
                };

                var nameProperty = user.GetType().GetProperty("Name");

                var name = nameProperty.GetValue(user, null);
                nameProperty.SetValue(user, "Mahmut", null);
                name = nameProperty.GetValue(user, null);


                SetValue(user, "Name", "Cengiz");
                SetValue(user, "Name", 5);

            }
            private static void SetValue(object container, string propertyName, object value)
            {
                container.GetType().GetProperty(propertyName).SetValue(container, value, null);
            }
            private static void SetValue2(object container, string propertyName, object value)
            {
                var propertyInfo = container.GetType().GetProperty(propertyName);
                propertyInfo.SetValue(container, Convert.ChangeType(value, propertyInfo.PropertyType), null);
            }

            private static object GetValue(object container, string propertyName)
            {
                return container.GetType().GetProperty(propertyName).GetValue(container, null);
            }


            [Test]
            public void Test1()
            {
                // Declare Instance of class Assembly
                // Call the GetExecutingAssembly method
                // to load the current assembly
                Assembly executing = Assembly.GetExecutingAssembly();

                // Array to store types of the assembly
                Type[] types = executing.GetTypes();
                foreach (var item in types)
                {
                    // Display each type
                    Console.WriteLine("Class : {0}", item.Name);

                    // Array to store methods
                    MethodInfo[] methods = item.GetMethods();
                    foreach (var method in methods)
                    {
                        // Display each method
                        Console.WriteLine("--> Method : {0}", method.Name);

                        // Array to store parameters
                        ParameterInfo[] parameters = method.GetParameters();
                        foreach (var arg in parameters)
                        {
                            // Display each parameter
                            Console.WriteLine("----> Parameter : {0} Type : {1}",
                                                    arg.Name, arg.ParameterType);
                        }
                    }
                }

            }

        }
    }
