using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceAPI.TestLayer
{
    public class Solid_LiskovSubstitutionPrinciple
    {
        public abstract class Kus
        {
            public abstract string Uc();
            public abstract string Yuru();
        }
        public class Tavuk : Kus
        {
            public override string Uc()
            {
                throw new NotImplementedException();
            }
            public override string Yuru()
            {
                return "Yürüdü..";
            }
        }
        public class Guvercin : Kus
        {
            public override string Uc()
            {
                return "Uçtu..";
            }
            public override string Yuru()
            {
                return "Yürüdü..";
            }
        }
        void Test_()
        {
            Kus kanatli = new Guvercin();
            kanatli.Uc();
            kanatli.Yuru();
            kanatli = new Tavuk();
            kanatli.Uc(); //Bu metod çağırıldığında throw new NotImplementedException() 
                          //hatası fırlatacaktır. Çünkü kullanılmakta fakat metodun içi boş olduğu için bu durum oluşmuştur. 
            kanatli.Yuru();
        }



        // liskov
        public interface IUcanlar
        {
            string Uc();
        }
        public interface IYuruyenler
        {
            string Yuru();
        }
        public class TavukLiskov : IYuruyenler
        {
            public string Yuru()
            {
                return "Yürüdü..";
            }
        }
        public class GuvercinLiskov : IYuruyenler, IUcanlar
        {
            public string Uc()
            {
                return "Uçtu..";
            }
            public string Yuru()
            {
                return "Yürüdü..";
            }
        }
    }
}
