using APIServer.Models.Entity;
using OpenAI_API.Chat;
using OpenAI_API;
using OpenAI_API.Models;

namespace APIServer.Common
{
    public static class GPT_PROMPT
    {

        public static string[] processStr(string input)
        {
            string[] cacDong = input.Split('\n');
            var result = new List<string>();
            foreach (var c in cacDong)
            {
                if (!Validation.checkStringIsEmpty(c))
                {
                    result.Add(c.Trim());
                }
            }
            return result.ToArray();
        }

        public static int GetExperienceMonths(string fromDateStr, string toDateStr)
        {
            // Chuyển đổi chuỗi ngày thành đối tượng DateTime
            DateTime fromDate = ParseDateString(fromDateStr);
            DateTime toDate = ParseDateString(toDateStr);

            // Tính số tháng giữa hai ngày
            int soThang = ((toDate.Year - fromDate.Year) * 12) + toDate.Month - fromDate.Month;

            return soThang;
        }
        public static DateTime ParseDateString(string dateString)
        {
            if (DateTime.TryParseExact(dateString, "MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime result))
            {
                return result;
            }
            else if (DateTime.TryParseExact(dateString, "yyyy", null, System.Globalization.DateTimeStyles.None, out result))
            {
                return result;
            }
            else if (DateTime.TryParseExact(dateString, "M/yyyy", null, System.Globalization.DateTimeStyles.None, out result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException("Định dạng ngày không hợp lệ.");
            }
        }

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
                var eduRequire = processStr(Validation.ConvertHTMLToData(jobDescription.EducationRequirement));
                prompt += "- educationRequirements:\"";
                for (int i = 0; i < eduRequire.Length; i++)
                {
                    prompt += $"{eduRequire[i].Trim()}" + Environment.NewLine;

                }
                prompt += " \" " + Environment.NewLine;
                var educationsList = curriculumVitae.Educations.ToList();
                for (int i = 0; i < educationsList.Count; i++)
                {
                    prompt += $"+ \"education{i + 1}\" : \"{educationsList[i].SchoolName.Trim()} - {educationsList[i].MajorName.Trim()} - {educationsList[i].Description.Trim()}\" có đáp ứng 1 trong các ý trong educationRequirements không?" + Environment.NewLine;
                    eduNumber += $"\"education{i + 1}\":trueOrfalse, ";

                }
            }

            //Job experience prompt
            if (!Validation.checkStringIsEmpty(jobDescription.ExperienceRequirement) &&
                curriculumVitae.JobExperiences.Any())
            {
                var expRequire = processStr(Validation.ConvertHTMLToData(jobDescription.ExperienceRequirement));
                prompt += "- experienceRequirements:\"";
                for (int i = 0; i < expRequire.Length; i++)
                {
                    prompt += $"{expRequire[i].Trim()}" + Environment.NewLine;
                }
                prompt += " \" " + Environment.NewLine;
                int totalExperienceCount = 1;
                foreach (var e in curriculumVitae.JobExperiences)
                {
                    var ExpDescriptionSplit = processStr(e.Description);
                    for (int j = 0; j < ExpDescriptionSplit.Length; j++)
                    {
                        prompt += $"+ \"jobExperience{totalExperienceCount}\" : \"{ExpDescriptionSplit[j].Trim()}\" có đáp ứng 1 trong các ý trong experienceRequirements không?" + Environment.NewLine;
                        expNumber += $"\"jobExperience{totalExperienceCount}\":trueOrfalse, ";
                        totalExperienceCount++;
                    }
                }
                string experienceMonth = "";
                foreach (var e in curriculumVitae.JobExperiences)
                {
                    experienceMonth += $"Đã làm tại vị trí công việc {e.Position.Trim()} được {GetExperienceMonths(e.FromDate, e.ToDate)} tháng; ";
                }
                prompt += $"+ \"jobExperience{totalExperienceCount}\" : \"{experienceMonth.Trim()}\" có đáp ứng 1 trong các ý trong experienceRequirements không?" + Environment.NewLine;
                expNumber += $"\"jobExperience{totalExperienceCount}\":trueOrfalse, ";
            }

            //Skill prompt
            if (!Validation.checkStringIsEmpty(jobDescription.SkillRequirement) &&
                curriculumVitae.Skills.Any())
            {
                var skillRequire = processStr(Validation.ConvertHTMLToData(jobDescription.SkillRequirement));
                prompt += "- skillRequirements:\"";

                for (int i = 0; i < skillRequire.Length; i++)
                {
                    prompt += $"{skillRequire[i].Trim()}" + Environment.NewLine;
                }
                prompt += " \" " + Environment.NewLine;
                var skillsList = curriculumVitae.Skills.ToList();
                for (int i = 0; i < skillsList.Count; i++)
                {
                    prompt += $"+ \"skill{i + 1}\" : \"{skillsList[i].Title.Trim()} - {skillsList[i].SkillDescription.Trim()}\" có đáp ứng 1 trong các ý trong skillRequirements không?" + Environment.NewLine;
                    if (i < skillsList.Count - 1)
                    {
                        skillNumber += $"\"skill{i + 1}\":trueOrfalse, ";
                    }
                    else skillNumber += $"\"skill{i + 1}\":trueOrfalse ";

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
                    eduNumber += $"\"education{i + 1}\":trueOrfalse, ";
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
                    expNumber += $"\"jobExperience{i + 1}\":trueOrfalse, ";
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
                    skillNumber += $"\"skill{i + 1}\":trueOrfalse, ";
                }
            }

            prompt += $"Yêu cầu chỉ trả lời đúng theo các đầu mục theo form json sau và không giải thích gì thêm:{{ {eduNumber + expNumber + skillNumber} }}";
            return prompt;
        }

        public static async Task<string> GetResult(string prompt)
        {
            try
            {
                string apiKey = Validation.readKey();
                var api = new OpenAIAPI(apiKey);
                var result = await api.Chat.CreateChatCompletionAsync(new ChatRequest()
                {
                    Model = Model.GPT4,
                    //Temperature = 0f,
                    MaxTokens = 150,
                    Messages = new ChatMessage[] {
            new ChatMessage(ChatMessageRole.User, prompt)
        }
                });

                if (result != null)
                {
                    var arr = result.Choices;
                    var rs = "";
                    foreach (var choice in arr)
                    {
                        rs += choice.Message.Content;
                    }
                    return rs;
                }
                else
                {
                    return "not found";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }
    }
}

