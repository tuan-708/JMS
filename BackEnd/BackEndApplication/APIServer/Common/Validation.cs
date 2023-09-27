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
                throw new ArgumentNullException("wrong format date");
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
    }
}
