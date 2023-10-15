using APIServer.Models.Entity;

namespace APIServer.Common
{
    public static class GPT_PROMPT
    {
        public static string MATCHING_FOR_RECUITER(JobDescription jobDescription, CurriculumVitae cv)
        {
            string prompt = @"hãy so sánh các yêu cầu bên trái và các đáp ứng bên phải sau, 
với mỗi một vế 1 so sánh với một vế 2 tương ứng, nếu bên vế 2 có đáp ứng bên vế 1 hãy trả về 1 còn 
không thì trả về 0 cho tất cả các so sánh sau, yêu cầu trả về 1 array int chỉ có dạng [0, 1], 
không yêu cầu giải thích hay các thông tin liên quan: " +
Environment.NewLine;
            if (!Validation.checkStringIsEmpty(jobDescription.ExperienceRequirement) &&
                cv.JobExperiences.Any())
            {
                var exp = processStr(jobDescription.ExperienceRequirement);
                foreach (var o in exp)
                {
                    foreach (var e in cv.JobExperiences)
                    {
                        var str = processStr(e.Description);
                        foreach (var s in str)
                        {
                            prompt += "Vế 1: '" + o + "' và Vế 2: '" + e.ToString() + s.Trim() + "' " + Environment.NewLine;
                        }
                    }
                }
            }
            return prompt + "không yêu cầu giải thích, chỉ cần kết quả dưới dạng int array[]";
        }

        public static string[] processStr(string input)
        {
            string[] cacDong = input.Split('\n');
            return cacDong;
        }
    }
}
