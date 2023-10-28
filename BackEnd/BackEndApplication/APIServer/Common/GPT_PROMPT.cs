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
            var result = new List<string>();
            foreach (var c in cacDong)
            {
                if(!Validation.checkStringIsEmpty(c) )
                {
                    result.Add(c.Trim());
                }
            }
            return result.ToArray();
        }

        // Prompt Education
        public static string MatchingEducationForRecruiter(JobDescription jobDescription, CurriculumVitae curriculumVitae)
        {
            string prompt = @"hãy so sánh các yêu cầu bên trái và các đáp ứng bên phải sau, mỗi ý so sánh dưới đấy sẽ bao gồm nhiều cặp vế, mỗi cặp vế sẽ có một vế 1 so sánh với một vế 2 tương ứng, nếu bên vế 2 có đáp ứng bên vế 1 thì cặp vế đó trả về 1 còn không thì trả về 0, và nếu trong một ý so sánh có một hoặc nhiều cặp vế trả về 1 thì cả ý so sánh sẽ trả về 1 và ngược lại. Có các ý so sánh sau: " + Environment.NewLine;

            if (!Validation.checkStringIsEmpty(jobDescription.EducationRequirement) &&
                curriculumVitae.Educations.Any())
            {
                var exp = processStr(jobDescription.EducationRequirement);
                for (int i = 0; i < exp.Length; i++)
                {
                    prompt += "- Ý so sánh " + (i + 1) + ":" + Environment.NewLine;
                    foreach (var e in curriculumVitae.Educations)
                    {
                        prompt += "+ Vế 1: 'Yêu cầu học vấn: " + exp[i] + "' và Vế 2: 'Trường đại học: " + e.SchoolName + " với chuyên nghành: " + e.MajorName + ", trong tình trạng:" + (e.StillLearning == true ? "đang học" : "đã tốt nghiệp") + "' " + Environment.NewLine;
                    }
                }
                prompt += "Vui lòng chỉ trả lời bằng một mảng int kết quả với từng 'ý so sánh' trên chứ không phải từng 'vế' và không có bất kỳ giải thích nào" + Environment.NewLine;
            }
            return prompt;
        }

        //public static string PromptForRecruiter(JobDescription jobDescription, CurriculumVitae curriculumVitae)
        //{
        //    string prompt = "";
        //    string eduNumber = "";
        //    string expNumber = "";
        //    string skillNumber = "";
        //    //Education prompt
        //    if (!Validation.checkStringIsEmpty(jobDescription.EducationRequirement) &&
        //        curriculumVitae.Educations.Any())
        //    {
        //        var eduRequire = processStr(jobDescription.EducationRequirement);

        //        for (int i = 0; i < eduRequire.Length; i++)
        //        {
        //            if (i > 0)
        //            {
        //                prompt += $"\"education{i + 1}\" :  Các nội dung tương tự như các vế trái ở education1 có thoả mãn \"{eduRequire[i]}\"" + Environment.NewLine;
        //            }
        //            else
        //            {
        //                foreach (var e in curriculumVitae.Educations)
        //                {
        //                    prompt += $"\"education{i + 1}\" : \"{e.SchoolName} - {e.MajorName} - {e.Description}\" có đáp ứng \"{eduRequire[i]}\"" + Environment.NewLine;

        //                }
        //            }
        //            eduNumber += $"\"education{i + 1}\":TrueOrFalse, ";

        //        }
        //    }

        //    //Job experience prompt
        //    if (!Validation.checkStringIsEmpty(jobDescription.ExperienceRequirement) &&
        //        curriculumVitae.JobExperiences.Any())
        //    {
        //        var expRequire = processStr(jobDescription.ExperienceRequirement);
        //        for (int i = 0; i < expRequire.Length; i++)
        //        {
        //            if (i > 0)
        //            {
        //                prompt += $"\"jobExperience{i + 1}\" : Các nội dung tương tự như các vế trái ở jobExperience1 có thoả mãn \"{expRequire[i]}\"" + Environment.NewLine;
        //            }
        //            else
        //            {
        //                foreach (var e in curriculumVitae.JobExperiences)
        //                {
        //                    var ExpDescriptionSplit = processStr(e.Description);
        //                    for (int j = 0; j < ExpDescriptionSplit.Length; j++)
        //                    {
        //                        prompt += $"\"jobExperience{i + 1}\" : \"{ExpDescriptionSplit[j]}\" có đáp ứng \"{expRequire[i]}\"" + Environment.NewLine;
        //                    }
        //                }
        //            }
        //            expNumber += $"\"jobExperience{i + 1}\":TrueOrFalse, ";
        //        }
        //    }

        //    //Skill prompt
        //    if (!Validation.checkStringIsEmpty(jobDescription.SkillRequirement) &&
        //        curriculumVitae.Skills.Any())
        //    {
        //        var skillRequire = processStr(jobDescription.SkillRequirement);

        //        for (int i = 0; i < skillRequire.Length; i++)
        //        {
        //            if (i > 0)
        //            {
        //                prompt += $"\"skill{i + 1}\" : Các nội dung tương tự như các vế trái ở skill1 có thoả mãn \"{skillRequire[i]}\"" + Environment.NewLine;
        //            }
        //            else
        //            {
        //                foreach (var s in curriculumVitae.Skills)
        //                {
        //                    prompt += $"\"skill{i + 1}\" : \"{s.Title} - {s.SkillDescription}\" có đáp ứng \"{skillRequire[i]}\"" + Environment.NewLine;

        //                }
        //            }
        //            skillNumber += $"\"skill{i + 1}\":TrueOrFalse, ";
        //        }
        //    }

        //    prompt += $"Lưu ý: Nếu 1 trong tất cả các key cùng tên mà trả về true thì cả tiêu chí đó sẽ là true (ví dụ có \"education1\":true, \"education1\":false thì kết quả cuối cùng là \"education1\":true). Trả lời đúng theo các đầu mục theo form json sau và không giải thích gì thêm:{{ {eduNumber + expNumber + skillNumber} }}";
        //    return prompt;
        //}

        public static string PromptForRecruiter(JobDescription jobDescription, CurriculumVitae curriculumVitae)
        {
            string prompt = "";
            string eduNumber = "";
            string expNumber = "";
            string skillNumber = "";
            //Education prompt
            if (!Validation.checkStringIsEmpty(jobDescription.EducationRequirement) &&
                curriculumVitae.Educations.Any())
            {
                var eduRequire = processStr(jobDescription.EducationRequirement);
                prompt += "- educationRequirements:\"";
                for (int i = 0; i < eduRequire.Length; i++)
                {
                    prompt += $"{eduRequire[i]}" + Environment.NewLine;

                }
                prompt += " \" " + Environment.NewLine;
                var educationsList = curriculumVitae.Educations.ToList();
                for (int i = 0; i < educationsList.Count; i++)
                {
                    prompt += $"+ \"education{i + 1}\" : \"{educationsList[i].SchoolName} - {educationsList[i].MajorName} - {educationsList[i].Description}\" có đáp ứng 1 trong các ý trong educationRequirements không?" + Environment.NewLine;
                    eduNumber += $"\"education{i + 1}\":TrueOrFalse, ";

                }
            }

            //Job experience prompt
            if (!Validation.checkStringIsEmpty(jobDescription.ExperienceRequirement) &&
                curriculumVitae.JobExperiences.Any())
            {
                var expRequire = processStr(jobDescription.ExperienceRequirement);
                prompt += "- experienceRequirements:\"";
                for (int i = 0; i < expRequire.Length; i++)
                {
                    prompt += $"{expRequire[i]}" + Environment.NewLine;
                }
                prompt += " \" " + Environment.NewLine;
                int totalExperienceCount = 1;
                foreach (var e in curriculumVitae.JobExperiences)
                {
                    var ExpDescriptionSplit = processStr(e.Description);
                    for (int j = 0; j < ExpDescriptionSplit.Length; j++)
                    {
                        prompt += $"+ \"jobExperience{totalExperienceCount}\" : \"{ExpDescriptionSplit[j]}\" có đáp ứng 1 trong các ý trong experienceRequirements không?" + Environment.NewLine;
                        expNumber += $"\"jobExperience{totalExperienceCount}\":TrueOrFalse, ";
                        totalExperienceCount++;
                    }
                }
            }

            //Skill prompt
            if (!Validation.checkStringIsEmpty(jobDescription.SkillRequirement) &&
                curriculumVitae.Skills.Any())
            {
                var skillRequire = processStr(jobDescription.SkillRequirement);
                prompt += "- skillRequirements:\"";

                for (int i = 0; i < skillRequire.Length; i++)
                {
                    prompt += $"{skillRequire[i]}" + Environment.NewLine;
                }
                prompt += " \" " + Environment.NewLine;
                var skillsList = curriculumVitae.Skills.ToList();
                for (int i = 0; i < skillsList.Count; i++)
                {
                    prompt += $"+ \"skill{i + 1}\" : \"{skillsList[i].Title} - {skillsList[i].SkillDescription}\" có đáp ứng 1 trong các ý trong skillRequirements không?" + Environment.NewLine;
                    skillNumber += $"\"skill{i + 1}\":TrueOrFalse, ";

                }
            }

            prompt += $"Yêu cầu chỉ trả lời đúng theo các đầu mục theo form json sau và không giải thích gì thêm:{{ {eduNumber + expNumber + skillNumber} }}";
            return prompt;
        }

        public static string PromptForCandidate(JobDescription jobDescription, CurriculumVitae curriculumVitae)
        {
            string prompt = "";
            string eduNumber = "";
            string expNumber = "";
            string skillNumber = "";
            //Education prompt
            if (!Validation.checkStringIsEmpty(jobDescription.EducationRequirement) &&
                curriculumVitae.Educations.Any())
            {
                prompt += $"- educations:\"";
                var educationsList = curriculumVitae.Educations.ToList();
                for (int i = 0; i < educationsList.Count; i++)
                {
                    prompt += $"{educationsList[i].SchoolName} - {educationsList[i].MajorName} - {educationsList[i].Description}" + Environment.NewLine;
                }
                prompt += " \" " + Environment.NewLine;

                var eduRequire = processStr(jobDescription.EducationRequirement);
                for (int i = 0; i < eduRequire.Length; i++)
                {
                    prompt += $"+ \"education{i + 1}\" : 1 trong các ý ở educations có đáp ứng \"{eduRequire[i]}\" không?" + Environment.NewLine;
                    
                    eduNumber += $"\"education{i + 1}\":TrueOrFalse, ";
                }
            }

            //Job experience prompt
            if (!Validation.checkStringIsEmpty(jobDescription.ExperienceRequirement) &&
                curriculumVitae.JobExperiences.Any())
            {

                prompt += $"- experiences:\"";
                foreach (var e in curriculumVitae.JobExperiences)
                {
                    var ExpDescriptionSplit = processStr(e.Description);
                    for (int j = 0; j < ExpDescriptionSplit.Length; j++)
                    {
                        prompt += $"{ExpDescriptionSplit[j]}" + Environment.NewLine;
                    }
                }
                prompt += " \" " + Environment.NewLine;

                var expRequire = processStr(jobDescription.ExperienceRequirement);
                for (int i = 0; i < expRequire.Length; i++)
                {
                    prompt += $"+ \"experience{i + 1}\" : 1 trong các ý ở experiences có đáp ứng \"{expRequire[i]}\" không?" + Environment.NewLine;
                    expNumber += $"\"jobExperience{i + 1}\":TrueOrFalse, ";
                }
            }

            //Skill prompt
            if (!Validation.checkStringIsEmpty(jobDescription.SkillRequirement) &&
                curriculumVitae.Skills.Any())
            {
                prompt += $"- skills:\"";
                var skillsList = curriculumVitae.Skills.ToList();
                for (int i = 0; i < skillsList.Count; i++)
                {
                    prompt += $"{skillsList[i].Title} - {skillsList[i].SkillDescription}" + Environment.NewLine;
                }
                prompt += " \" " + Environment.NewLine;

                var skillRequire = processStr(jobDescription.SkillRequirement);

                for (int i = 0; i < skillRequire.Length; i++)
                {
                    prompt += $"+ \"skill{i + 1}\" : 1 trong các ý ở skills có đáp ứng \"{skillRequire[i]}\" không?" + Environment.NewLine;
                    skillNumber += $"\"skill{i + 1}\":TrueOrFalse, ";
                }
            }

            prompt += $"Yêu cầu chỉ trả lời đúng theo các đầu mục theo form json sau và không giải thích gì thêm:{{ {eduNumber + expNumber + skillNumber} }}";
            return prompt;
        }
    }
}

