using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JITWeatherService.Dao
{
    public class ReadingsQueryResult
    {
        public int RdngID { get; set; }
        public string Zip { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int Days { get; set; }
        public int RUnitID { get; set; }
        public int WnpUnitID { get; set; }
        public double B1 { get; set; }
        public double B2 { get; set; }
        public int B3 { get; set; }
        public double B4 { get; set; }
        public int B5 { get; set; }
    }

    /*
     * 	select b.Zip, r.DateStart,  r.DateEnd, r.Days, r.UnitID as rUnitID, w.UnitID as wnpUnitID,
	  w.B1, w.B2, w.B3, w.B4, w.B5
	from Readings r join WthNormalParams w on r.AccID = w.AccID
	  join Accounts a on a.AccID = r.AccID
	  join Buildings b on b.BldID = a.BldID
	where r.UtilId = w.UtilId
	  and r.DateStart >= '12-1-2016'
	order by DateStart;
    */
}
