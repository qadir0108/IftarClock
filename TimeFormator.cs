using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DigitalClock
{
    public static class TimeFormator
    {
        static Random random = new Random();
        private static string GetRandomHexNumber(int digits)
        {
            byte[] buffer = new byte[digits / 2];
            random.NextBytes(buffer);
            string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
            if (digits % 2 == 0)
                return result;
            return result + random.Next(16).ToString("X");
        }
        private static string GetRandomUnicodeString()
        {
            string codePoint = "26" + GetRandomHexNumber(2);
            int code = int.Parse(codePoint, System.Globalization.NumberStyles.HexNumber);
            string unicodeString = char.ConvertFromUtf32(code);
            return unicodeString;
        }
        public static string PrintFormat(this TimeSpan timeSpan)
        {
            return timeSpan.Seconds < 0 || timeSpan.Minutes < 0 || timeSpan.Hours < 0
                ? "       ---" :
                //string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
                string.Format("{0:D2}:{1:D2}", timeSpan.Hours, timeSpan.Minutes);
        }

        static string isoFormat = "yyyy-MM-ddTHH:mm:ss'+00:00'";

        public static DateTime ToIsoFormat(this string isoTimeString)
        {
            return DateTime.ParseExact(isoTimeString, isoFormat , CultureInfo.InvariantCulture);
        }

        static string dataFormat = "HHmmss";
        public static string ToDataFormat(this DateTime dateTime)
        {
            return dateTime.ToString(dataFormat);
        }

        public static DateTime FromDataFormat(this string inputDateTime)
        {
            return DateTime.ParseExact(inputDateTime, dataFormat, CultureInfo.InvariantCulture);
        }
    }
}
