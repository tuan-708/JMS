using System.Text.RegularExpressions;

namespace ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = IsValidEmail("thanhthanh@thanh.huo");
            Console.WriteLine("Hello, World! " + a);
        }

        static bool IsValidEmail(string email)
        {
            // Define a regular expression pattern for a valid email address
            string pattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";

            // Use the Regex class to check if the email matches the pattern
            return Regex.IsMatch(email, pattern);
        }
    }
}