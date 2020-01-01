using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RLmmr
{
    public class Utils
    {
        public static int GetRawMMR(string input)
        {
            try
            {
                string sub2 = input.Substring(0, input.Length - 12);
                sub2 = sub2.Replace(",", "");

                string resultString = Regex.Match(sub2, @"\d+").Value;

                return Convert.ToInt32(resultString);
            }
            catch
            {
                return -1;
            }

            return -1;
        }
        public class Web
        {
            private static HtmlWeb _web = new HtmlWeb();
            private static HtmlDocument _selectedDocument;

            public static void Navigate(string url)
            {
                _selectedDocument = _web.Load(url);
            }
          
            public static string GetHtmlAttribute(string xpath, string attribute)
            {
                return _selectedDocument.DocumentNode
                    .SelectSingleNode(xpath)
                    .GetAttributeValue(attribute, "notfound");
            }

            public static string GetNodeHtml(string xpath)
            {
                return _selectedDocument.DocumentNode.SelectSingleNode(xpath).OuterHtml;
            }

            /// <summary>
            /// Gets inner text of element.
            /// </summary>
            /// <param name="xpath">Xpath of element</param>
            /// <returns></returns>
            public static string GetInnerText(string xpath)
            {
                try
                {
                    return _selectedDocument.DocumentNode.SelectSingleNode(xpath).InnerText;
                }
                catch
                {
                    return null;
                }

            }

            /// <summary>
            /// Gets vehicle property based on querys.
            /// </summary>
            /// <param name="type">Type to be queried</param>
            /// <returns></returns>
            public static object VehicleProperty(string type)
            {
                //bildata
                HtmlNodeCollection dataNodes = _selectedDocument.DocumentNode.SelectNodes("//*[@id=\"box-data\"]/div/div/ul/li");
                //teknisk data
              

                return null;
            }
        }

    }
}
