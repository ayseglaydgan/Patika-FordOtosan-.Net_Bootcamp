//using NiceAPI.BaseClass;
//using NUnit.Framework;
//using System;
//using System.Reflection;

//namespace NiceAPI.TestLayer
//{
//    [MySpecial]
//    [Obsolete("Use new class")]
//    public class AttTest
//    {

//    }

//    [Help("Use this TestCase3")]
//    public class TestCase3
//    {
//        [Help("Use this TestCase3 4", Topic = "Göster")]
//        public void Print(string text) { }
//    }
//    public class AttributeTest
//    {
//        [Test]
//        public void Test1()
//        {
//            var old = new OldExtensionMethod();
//            var neew = new AttTest();
//        }

//        [Test]
//        [Help("Use this method", Topic = "Göster")]
//        public void Test2(string text)
//        {
//        }


//        [Test]
//        public void Test3()
//        {
//            ShowHelpHint(typeof(TestCase3));
//            ShowHelpHint(typeof(TestCase3).GetMethod("Show"));
//        }

//        void ShowHelpHint(MemberInfo attr)
//        {
//            HelpAttribute y = Attribute.GetCustomAttribute(attr, typeof(HelpAttribute)) as HelpAttribute;

//            if (y == null)
//            {
//                Console.WriteLine("{0}  no help", attr);
//            }
//            else
//            {
//                Console.WriteLine("{0} help", attr);
//                Console.WriteLine(" Url={0} Topic={1}", y.Url, y.Topic);
//            }
//        }

//    }
//}

