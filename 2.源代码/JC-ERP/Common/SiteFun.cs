using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class SiteFun
    {
        /// <summary>
        /// 过滤非法字符串
        /// </summary>
        /// <param name="parStr"></param>
        /// <returns></returns>
        public static string cutechar(string parStr)
        {
            parStr = parStr.Trim();
            parStr = parStr.Replace("(", "（");
            parStr = parStr.Replace(")", "）");
            parStr = parStr.Replace(",", "，");
            parStr = parStr.Replace("*", "﹡");
            parStr = parStr.Replace("--", "－－");
            parStr = parStr.Replace("'", "''");
            parStr = parStr.Replace("%", "[%]");
            //parStr = parStr.Replace("=", "[=]");

            string[] arrErrorStr =
                {
                "exec,ＥＸＥＣ",
                "select,ＳＥＬＥＣＴ",
                "update,ＵＰＤＡＴＥ",
                "insert,ＩＮＳＥＲＴ",
                "delete,ＤＥＬＥＴＥ",
                "script,ＳＣＲＩＰＴ",
                "like,ＬＩＫＥ",
                "iframe,ＩＦＲＡＭＥ",
                "frame,ＦＲＡＭＥ"
            };
            for (int i = 0; i < arrErrorStr.Length; i++)
            {
                string[] arrTemp = arrErrorStr[i].Split(',');
                while (parStr.ToLower().Contains(arrTemp[0]))
                {
                    int numLength = arrTemp[0].Length;
                    int numTemp = parStr.ToLower().IndexOf(arrTemp[0]);
                    parStr = parStr.Remove(numTemp, numLength).Insert(numTemp, arrTemp[1]);
                }
            }
            return parStr;
        }

        /// <summary>
        /// 验证删除的id集合是否符合规范
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public static bool CheckIds(string ids)
        {
            bool bResult = true;
            int id = 0;
            string[] idsStr = ids.Split(',');
            foreach(string s in idsStr)
            {
                if (Int32.TryParse(s, out id) && id > 0)
                {
                    continue;
                }
                else
                {
                    bResult = false;
                    break;
                }
            }
            return bResult;
        }
    }
}
