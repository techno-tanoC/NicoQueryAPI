using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace NicoQueryAPI
{
    public class NicoQuery
    {
        public string query_string { get; set; }
        public Service service { get; set; }
        public Search search { get; set; }
        public QueryParams join { get; set; }
        public SortBy sort_by { get; set; }
        public List<Filter> filters { get; set; }
        public Order order { get; set; }
        public int from { get; set; }
        private int size;
        public int Size
        {
            set
            {
                if (0 > value || value > 100)
                    throw new ArgumentOutOfRangeException("\"size\" is from 0 to 100.");
                else
                    this.size = value;
            }
        }
        public const string issure = "NicoQueryAPI.NET(Devloping)";
        public const string reason = "ma9";

        public NicoQuery()
        {
            sort_by = SortBy._popular;
            order = Order.desc;
            from = 0;
            size = 10;
        }

        public string ToJSON()
        {
            return "{\n" +
                "\"query\":\"" + query_string + "\"," +
                "\n" +
                "\"service\":[\"" + service.ToString().Replace(", ", "\", \"") + "\"]," +
                "\n" +
                "\"search\":[\"" + search.ToString().Replace(", ", "\", \"") + "\"]," +
                "\n" +
                "\"join\":[\"" + join.ToString().Replace(", ", "\", \"") + "\"]," +
                "\n" +
                "\"filters\":[\n    " + string.Join(",\n    ", filters.Select(f => f.ToString())) + "]," +
                "\n" +
                "\"sort_by\":\"" + "start_time" + "\"," +
                "\n" +
                "\"order\":\"" + order + "\"," +
                "\n" +
                "\"from\":" + from + "," +
                "\n" +
                "\"size\":" + size + "," +
                "\n" +
                "\"issure\":\"" + issure + "\"," +
                "\n" +
                "\"reason\":\"" + reason + "\"" +
                "\n}";
        }

        private static readonly Encoding enc = Encoding.UTF8;
        public string Execute()
        {
            try
            {
                var bytes = enc.GetBytes(this.ToJSON());
                var req = WebRequest.Create("http://api.search.nicovideo.jp/api/");
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = bytes.Length;

                using (var stream = req.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                    using (var resStream = req.GetResponse().GetResponseStream())
                    using (var sr = new System.IO.StreamReader(resStream, enc))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            catch
            {
                throw new Exception();
            }
        }
    }
    
}
