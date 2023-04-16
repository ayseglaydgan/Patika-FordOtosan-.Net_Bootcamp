//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace NiceAPI.TestLayer
//{
//    public class ExtensionHelper
//    {
//        public string ToFormattedPrice(decimal amount)
//        {
//            return amount.ToString("#,##0.00");
//        }
//    }

//    public class ExtensionTest
//    {
//        [Test]
//        public void Test_Is_greater_then()
//        {
//            int age = 12;
//            bool compare = age.IsGreaterThan(11);
//            if (!compare)
//            {
//                Assert.Fail();
//            }
//        }

//        [Test]
//        public void Test_formart_salary()
//        {
//            decimal salary = 50;
//            string formart = salary.ToFormattedPrice();
//            if (string.IsNullOrEmpty(formart))
//            {
//                Assert.Fail();
//            }
//        }

//        [Test]
//        public void Test_formart_salary_oldway()
//        {
//            decimal salary = 50;
//            ExtensionHelper extensionHelper = new ExtensionHelper();
//            string formart = extensionHelper.ToFormattedPrice(salary);
//            if (string.IsNullOrEmpty(formart))
//            {
//                Assert.Fail();
//            }
//        }

//        public void Test_get_first_3_chars_ofname()
//        {
//            string str = "Hello World";
//            str = str.GetFirstThreeCharacters();

//            if (str != "Hel")
//            {
//                Assert.Fail();
//            }
//        }
//    }
//}
