using System.Text.RegularExpressions;

namespace ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = IsValidEmail("thanhthanh@thanh.huo");
            Console.WriteLine("Hello, World! " + a);
            testCutStr();
        }

        static bool IsValidEmail(string email)
        {
            // Define a regular expression pattern for a valid email address
            string pattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";

            // Use the Regex class to check if the email matches the pattern
            return Regex.IsMatch(email, pattern);
        }

        static void testCutStr()
        {
            string input = "abc {cdef} ghi {jkl} mno";

            // Sử dụng Regex để tìm cặp {} đầu tiên trong chuỗi
            Match match = Regex.Match(input, @"\{([^}]+)\}");

            if (match.Success)
            {
                // Lấy giá trị bên trong cặp {}
                string innerText = match.Groups[1].Value;
                Console.WriteLine(innerText);
            }
            else
            {
                Console.WriteLine("Không tìm thấy cặp {} trong chuỗi.");
            }
        }
    }
}