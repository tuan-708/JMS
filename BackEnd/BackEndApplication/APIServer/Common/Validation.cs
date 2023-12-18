using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace APIServer.Common
{
    public class Validation
    {
        public static DateTime convertDateTime(string? input)
        {
            try
            {
                input = input.Trim();
                var date = DateTime.Parse(input);
                return date;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool checkStringIsEmpty(params string[] inputs)
        {
            try
            {
                foreach (var input in inputs)
                {
                    if (string.IsNullOrEmpty(input) && string.IsNullOrWhiteSpace(input))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch { return true; }
        }

        public static string readKey()
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\Common\\gptKey.txt";
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                return lines[0];
            }
            catch (IOException e)
            {
                return null;
            }
            catch(IndexOutOfRangeException e)
            {
                return null;
            }
        }

        public static int CalculateAge(DateTime ngaySinh)
        {
            DateTime ngayHienTai = DateTime.Now;
            int tuoi = ngayHienTai.Year - ngaySinh.Year;
            if (ngayHienTai.Month < ngaySinh.Month || (ngayHienTai.Month == ngaySinh.Month && ngayHienTai.Day < ngaySinh.Day))
            {
                tuoi--;
            }
            return tuoi;
        }

        public static bool IsPhoneNumberValid(string phoneNumber)
        {
            return phoneNumber.Length == 10 && phoneNumber.All(char.IsDigit) ? 
                true : throw new Exception("Phone number not valid");
        }

        public static int? ConvertInt(string? input)
        {
            try
            {
                return int.Parse((string)input.Trim());
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static float checkPercentMatchingFromJSON(string? json)
        {
            if (checkStringIsEmpty(json))
            {
                throw new Exception("Input not valid");
            }
            try
            {
                float pcEdu = 25, pcS = 35, pcExp = 40;
                float countS = 0, countExp = 0, countEdu = 0;
                var jObj = JObject.Parse(json);
                var lstS = GetValuesByKey(jObj, "skill");
                var lstExp = GetValuesByKey(jObj, "Exp");
                var lstEdu = GetValuesByKey(jObj, "edu");
                //Console.WriteLine(lstEdu.Count);
                //Console.WriteLine(lstExp.Count);
                //Console.WriteLine(lstS.Count);
                foreach (var o in lstS)
                {
                    if (o.ToLower() == "true")
                        countS++;
                }
                foreach (var o in lstExp)
                {
                    if (o.ToLower() == "true")
                        countExp++;
                }
                foreach (var o in lstEdu)
                {
                    if (o.ToLower() == "true")
                        countEdu++;
                }

                float result = countS / lstS.Count * pcS +
                    countEdu / lstEdu.Count * pcEdu +
                    countExp / lstExp.Count * pcExp;
                return result / 100;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static List<string> GetValuesByKey(JObject jsonObject, string key)
        {
            List<string> values = new List<string>();
            foreach (JProperty property in jsonObject.Properties())
            {
                if (property.Name.ToLower().Contains(key.ToLower()))
                {
                    values.Add(property.Value.ToString());
                }
            }
            return values;
        }

        public static string ConvertHTMLToData(string html)
        {
            string rs = "";
            // Tìm vị trí bắt đầu và kết thúc của thẻ <li>
            int startIndex = html.IndexOf("<li>");
            int endIndex = html.IndexOf("</li>");

            if (startIndex == -1 || endIndex == -1) return html;

            while (startIndex >= 0 && endIndex >= 0)
            {
                // Lấy nội dung trong thẻ <li>
                string liText = html.Substring(startIndex + 4, endIndex - startIndex - 4);

                // Tiếp tục tìm các thẻ <li> khác
                startIndex = html.IndexOf("<li>", endIndex + 5);
                endIndex = html.IndexOf("</li>", endIndex + 5);
                rs += liText + Environment.NewLine;
            }
            return rs;
        }
    }
}
