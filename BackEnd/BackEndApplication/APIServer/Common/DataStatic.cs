using APIServer.Models.Entity;

namespace APIServer.Common
{
    public class DataStatic
    {
        public static Gender[] allGender()
        {
            var rs = new Gender[3];
            rs[0] = new Gender
            {
                GenderId = 1,
                Title = "None",
            };
            rs[1] = new Gender
            {
                GenderId = 2,
                Title = "Male",
            };
            rs[2] = new Gender
            {
                GenderId = 3,
                Title = "Female",
            };
            return rs;
        }
    }
}
