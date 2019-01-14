using System;
using System.Collections.Generic;
using TagLib;

namespace TagLibTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var target = TagLib.File.Create(@"/Users/saken649/Music/01 キラリ覚醒☆リインカーネーション.m4a");
            var tags = target.Tag;
            //ReadTags(tags);
            WriteTags(target);
        }

        private static void ReadTags(Tag tags)
        {
            var props = typeof(Tag).GetProperties();
            foreach (var prop in props)
            {
                var key = prop.Name;
                var val = prop.GetValue(tags, null);
                var propType = prop.PropertyType.FullName;
                if (propType == "System.String[]")
                {
                    var strarr = (string[])val;
                    var str = "";
                    foreach (var v in strarr)
                    {
                        str += v;
                    }
                    Console.WriteLine(key + ": " + str);
                }
                //else if (key == "Pictures")
                //{
                //    Console.WriteLine("");
                //}
                else
                {
                    Console.WriteLine(key + ": " + val);
                }
            }
            Console.WriteLine("");
        }

        private static void WriteTags(File target)
        {
            // 曲名
            target.Tag.Title = "キラリ覚醒☆リインカーネーション(full ver)";
            target.Tag.TitleSort = "きらりかくせい";
            // アーティスト
            target.Tag.Performers = "青葉りんか".Split(new char[] { ';' });
            target.Tag.PerformersSort = "りんか".Split(new char[] { ';' });
            // 年
            target.Tag.Year = uint.Parse("2019");
            // カバー
            List<Picture> pics = new List<Picture>();
            var ipath = "/Users/saken649/Music/test_rinka.jpg";
            if (!string.IsNullOrEmpty(ipath))
            {
                foreach (string path in ipath.Split(new char[] { ';'}))
                {
                    pics.Add(new Picture(path));
                }
            }
            target.Tag.Pictures = pics.ToArray();

            // save
            target.Save();
        }
    }
}
