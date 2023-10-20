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
            return phoneNumber.Length == 10 && phoneNumber.All(char.IsDigit);
        }

        public static int ConvertInt(string? input)
        {
            try
            {
                return int.Parse((string) input.Trim());
            }
            catch (Exception e)
            {
                throw new Exception("Input number not valid");
            }
        }
    }
}
