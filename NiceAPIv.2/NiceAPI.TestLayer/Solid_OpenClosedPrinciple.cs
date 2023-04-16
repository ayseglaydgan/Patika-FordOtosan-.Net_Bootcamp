
namespace NiceAPI.TestLayer
{
    public class Solid_OpenClosedPrinciple
    {

        public string RaporTipi { get; private set; }

        public void RaporOlustur(Employee em)
        {
            if (RaporTipi == "CRS")
            {
                // Crystal Report ile rapor oluştur 
            }
            if (RaporTipi == "PDF")
            {
                // PDF formatında rapor oluştur 
            }
        }
        public class Employee
        {
        }





        // open closed principle
        abstract class Rapor
        {
            public int RaporId { get; set; }
            public string RaporAdi { get; set; }

            /// <summary> 
            /// Method to generate report 
            /// </summary> 
            /// <param name="em"></param> 
            public abstract void RaporOlustur(Employee em);
            // Override edilecek olan metodumuzdur. Bu metod farklı tipte raporlamalar için kullanılacaktır. 
        }
        class CrystalReportOlustur : Rapor
        {
            public override void RaporOlustur(Employee em)
            {
                // Crystal Report ile rapor oluştur 
            }
        }
        class PDFRaporOlustur : Rapor
        {
            public override void RaporOlustur(Employee em)
            {
                // PDF ile rapor oluştur 
            }
        }









    }

}
