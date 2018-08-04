using System;

namespace JITWeatherService.Dao
{
    public class WthNormalParams
    {
        public int AccID { get; set; }
        public int UtilID { get; set; }
        public int UnitID { get; set; }
        public int WstID { get; set; }
        public string ZipW { get; set; }
        public decimal B1 { get; set; }
        public decimal B2 { get; set; }
        public int B3 { get; set; }
        public decimal B4 { get; set; }
        public int B5 { get; set; }
        public decimal R2 { get; set; }
        public DateTime EndDate { get; set; }
        public int EMoID { get; set; }
        public int MoCt { get; set; }

        public int DaysInYear { get; set; }
    }
}
