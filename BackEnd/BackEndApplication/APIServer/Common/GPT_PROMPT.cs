using APIServer.Models.Entity;

namespace APIServer.Common
{
    public static class GPT_PROMPT
    {
//        public static string MATCHING_FOR_RECUITER(JobDescription jobDescription, CurriculumVitae cv)
//        {
//            string prompt = @"hãy so sánh các yêu cầu bên trái và các đáp ứng bên phải sau, 
//với mỗi một vế 1 so sánh với một vế 2 tương ứng, nếu bên vế 2 có đáp ứng bên vế 1 hãy trả về 1 còn 
//không thì trả về 0 cho tất cả các so sánh sau, yêu cầu trả về 1 array int chỉ có dạng [0, 1], 
//không yêu cầu giải thích hay các thông tin liên quan: " +
//Environment.NewLine;
//            if (!Validation.checkStringIsEmpty(jobDescription.ExperienceRequirement) &&
//                cv.JobExperiences.Any())
//            {
//                var exp = processStr(jobDescription.ExperienceRequirement);
//                foreach (var o in exp)
//                {
//                    foreach (var e in cv.JobExperiences)
//                    {
//                        //var str = processStr(e.Description);
//                        //foreach (var s in str)
//                        //{
//                        //    prompt += "Vế 1: '" + o + "' và Vế 2: '" + e.ToString() + s.Trim() + "' " + Environment.NewLine;
//                        //}
//                        prompt += "Vế 1: '" + o + "' và Vế 2: '" + e.ToString() + "' " + Environment.NewLine;
//                    }
//                }
//            }
//            return prompt + "không yêu cầu giải thích, chỉ cần kết quả dưới dạng int array[]";
//        }

        public static string[] processStr(string input)
        {
            string[] cacDong = input.Split('\n');
            return cacDong;
        }

        // Prompt Education
        public static string MatchingEducationForRecruiter(JobDescription jobDescription, CurriculumVitae curriculumVitae)
        {
            string prompt = @"hãy so sánh các yêu cầu bên trái và các đáp ứng bên phải sau, mỗi ý so sánh dưới đấy sẽ bao gồm nhiều cặp vế, mỗi cặp vế sẽ có một vế 1 so sánh với một vế 2 tương ứng, nếu bên vế 2 có đáp ứng bên vế 1 hãy cặp vế đó trả về 1 còn không thì trả về 0 cho tất cả các cặp vế so sánh, và nếu trong một ý so sánh có một hoặc nhiều cặp vế trả về 1 thì cả ý so sánh sẽ trả về 1 và ngược lại. Vui lòng chỉ trả lời bằng một mảng int kết quả với format [0, 1] mà không có bất kỳ giải thích nào: " + Environment.NewLine; ;
             
            if (!Validation.checkStringIsEmpty(jobDescription.EducationRequirement) &&
                curriculumVitae.Educations.Any())
            {
                var exp = processStr(jobDescription.EducationRequirement);
                for(int i = 0; i < exp.Length; i++)
                {
                    prompt += "- Ý so sánh " + (i + 1) + ":" + Environment.NewLine;
                    foreach (var e in curriculumVitae.Educations)
                    {
                        prompt += "+ Vế 1: 'Yêu cầu học vấn: " + exp[i] + "' và Vế 2: 'Trường đại học: " + e.SchoolName + " với chuyên nghành: " + e.MajorName + ", trong tình trạng:" + (e.StillLearning ==  true ? "đang học" : "đã tốt nghiệp") + "' " + Environment.NewLine;
                    }
                }
            }
            return prompt;
        }

        // Prompt Experience
        public static string MatchingExperienceForRecruiter(JobDescription jobDescription, CurriculumVitae curriculumVitae)
        {
            string prompt = @"hãy so sánh các yêu cầu bên trái và các đáp ứng bên phải sau, mỗi ý so sánh dưới đấy sẽ bao gồm nhiều cặp vế, mỗi cặp vế sẽ có một vế 1 so sánh với một vế 2 tương ứng, nếu bên vế 2 có đáp ứng bên vế 1 hãy cặp vế đó trả về 1 còn không thì trả về 0 cho tất cả các cặp vế so sánh, và nếu trong một ý so sánh có một hoặc nhiều cặp vế trả về 1 thì cả ý so sánh sẽ trả về 1 và ngược lại. Vui lòng chỉ trả lời bằng một mảng int kết quả với format [0, 1] mà không có bất kỳ giải thích nào: " + Environment.NewLine; ;

            if (!Validation.checkStringIsEmpty(jobDescription.ExperienceRequirement) &&
                curriculumVitae.JobExperiences.Any())
            {
                var exp = processStr(jobDescription.ExperienceRequirement);
                for (int i = 0; i < exp.Length; i++)
                {
                    prompt += "- Ý so sánh " + (i + 1) + ":" + Environment.NewLine;

                    foreach (var e in curriculumVitae.JobExperiences)
                    {
                        prompt += "+ Vế 1: 'Yêu cầu kinh nghiệm: " + exp[i] + "' và Vế 2: 'Kinh nghiệm làm việc: Đã làm việc tại " + e.ComapanyName + " với vị trí " + e.Title + " và với công việc đã từng làm như sau" + e.Description + "' " + Environment.NewLine;
                    }
                }
            }

            return prompt;
        }

        // Prompt Skill
        public static string MatchingSkillForRecruiter(JobDescription jobDescription, CurriculumVitae curriculumVitae)
        {
            string prompt = @"hãy so sánh các yêu cầu bên trái và các đáp ứng bên phải sau, mỗi ý so sánh dưới đấy sẽ bao gồm nhiều cặp vế, mỗi cặp vế sẽ có một vế 1 so sánh với một vế 2 tương ứng, nếu bên vế 2 có đáp ứng bên vế 1 hãy cặp vế đó trả về 1 còn không thì trả về 0 cho tất cả các cặp vế so sánh, và nếu trong một ý so sánh có một hoặc nhiều cặp vế trả về 1 thì cả ý so sánh sẽ trả về 1 và ngược lại. Vui lòng chỉ trả lời bằng một mảng int kết quả với format [0, 1] mà không có bất kỳ giải thích nào: " + Environment.NewLine; ;

            if (!Validation.checkStringIsEmpty(jobDescription.SkillRequirement) &&
                curriculumVitae.Skills.Any())
            {
                var exp = processStr(jobDescription.SkillRequirement);
                for (int i = 0; i < exp.Length; i++)
                {
                    prompt += "- Ý so sánh " + (i + 1) + ":" + Environment.NewLine;
                    foreach (var e in curriculumVitae.Skills)
                    {
                        prompt += "+ Vế 1: 'Yêu cầu kỹ nămg: " + exp[i] + "' và Vế 2: 'Kỹ năng: " + e.Title + ". Chi tiết kỹ năng: " + e.SkillDescription + "' " + Environment.NewLine;
                    }
                }
            }

            return prompt;
        }
    }
}
