using Newtonsoft.Json.Linq;
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
                    var o = input.Trim();
                    if (string.IsNullOrEmpty(o) && string.IsNullOrWhiteSpace(o))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch { return true; }
        }

        public static string processStringGpt(string input)
        {
            Match match = Regex.Match(input, @"\{([^}]+)\}");

            if (match.Success)
            {
                string innerText = match.Groups[1].Value.Trim();
                return "{" + innerText + "}";
            }
            else
            {
                return input;
            }
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
                JObject jsonObject = JObject.Parse(json);
                float trueVal = 0;
                foreach (var property in jsonObject.Properties())
                {
                    if(property.Value.ToString().ToLower() == "true")
                    {
                        trueVal++;
                    } 
                }
                return trueVal / jsonObject.Properties().Count();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string ConvertHTMLToData(string html)
        {
            string rs = "";
            // Tìm vị trí bắt đầu và kết thúc của thẻ <li>
            int startIndex = html.IndexOf("<li>");
            int endIndex = html.IndexOf("</li>");

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
