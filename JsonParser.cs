using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NicoQueryAPI
{
    public class ContentJsonParser
    {
        /// <summary>
        /// 検索結果の数(≠取得した結果数)
        /// </summary>
        public readonly int total;
        public readonly List<Dictionary<string, string>> result;

        private ContentJsonParser(List<Dictionary<string, string>> list, int total)
        {
            this.result = list;
            this.total = total;
        }

        public int Count()
        {
            return result.Count;
        }

        private static readonly Regex regex = new Regex(@"^\s*""(.*)"":\s*(.*)", RegexOptions.Multiline);
        public static ContentJsonParser Create(string json)
        {
            Console.WriteLine(json);
            try
            {
                var line = json.Split('\n')
                    .Where(j => j != "")
                    .Select(j => JObject.Parse(j));

                int total = int.Parse(
                        line.First(j => j["values"] != null && j["type"].ToString() == "stats")
                            ["values"]
                            [0]
                            ["total"]
                            .ToString()
                            );

                if (total == 0)
                    return new ContentJsonParser(new List<Dictionary<string, string>>(), 0);

                var d = line.First(j => j["values"] != null && j["type"].ToString() == "hits")
                    ["values"]
                    .Select(j =>
                    {
                        var matches = regex.Matches(j.ToString());
                        return Enumerable.Range(0, matches.Count)
                            .Select(i => new { tag = matches[i].Groups[1].Value, value = matches[i].Groups[2].Value })
                            .ToDictionary(s => s.tag, v => v.value);
                    })
                    .ToList();

                return new ContentJsonParser(d, total);
                }
            catch (Exception e)
            {
                throw new Exception("ParseError", e);
            }
        }
    }

    public class TagJsonParser
    {
        private readonly List<string> result;
        private TagJsonParser(List<string> list)
        {
            this.result = list;
        }

        public static TagJsonParser Create(string json)
        {
            Console.WriteLine(json);
            try
            {
                var line = json.Split('\n')
                    .Where(j => j != "")
                    .Select(j => JObject.Parse(j));

                if (line.Any(j => j["values"] == null))
                    return new TagJsonParser(new List<string>());

                return new TagJsonParser(
                    line
                    .First(j => j["values"] != null)
                    ["values"]
                    .Select(j => j["tag"].ToString())
                    .ToList()
                    );
            }
            catch (Exception e)
            {
                throw new Exception("ParseError", e);
            }
        }
    }
}
