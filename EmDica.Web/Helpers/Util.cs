using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmDica.Web.Helpers
{
    public class Util
    {
        public static string ConverteDataHorarioBrasilia(DateTime data)
        {
            string dataRetorno = string.Empty;

            DateTime timeUtc = DateTime.UtcNow;
            TimeZoneInfo kstZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            DateTime dateTimeBrasilia = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, kstZone);

            dataRetorno = string.Format("{0}-{1}-{2} {3}:{4}:{5}",
                dateTimeBrasilia.Year,
                dateTimeBrasilia.Month.ToString().PadLeft(2,'0'),
                dateTimeBrasilia.Day.ToString().PadLeft(2, '0'),
                dateTimeBrasilia.Hour.ToString().PadLeft(2, '0'),
                dateTimeBrasilia.Minute.ToString().PadLeft(2, '0'),
                dateTimeBrasilia.Second.ToString().PadLeft(2, '0')
                );

            return dataRetorno;
        }

        public static string ConverteDataBrasilia(DateTime data)
        {
            string dataRetorno = string.Empty;

            DateTime timeUtc = DateTime.UtcNow;
            TimeZoneInfo kstZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            DateTime dateTimeBrasilia = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, kstZone);

            dataRetorno = string.Format("{0}-{1}-{2}",
                dateTimeBrasilia.Year,
                dateTimeBrasilia.Month.ToString().PadLeft(2, '0'),
                dateTimeBrasilia.Day.ToString().PadLeft(2, '0')                
                );

            return dataRetorno;
        }

    }
}