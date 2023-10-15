namespace APIServer.Common
{
    public static class GPT_PROMPT
    {
        public static string MATCHING_FOR_RECUITER()
        {
            string prompt = @"hãy so sánh các yêu cầu bên trái và các đáp ứng bên phải sau, với
 mỗi 1 dòng là 1 lần so sánh, nếu bên phải có đáp ứng bên trái hãy trả về 1 còn không thì trả về 0 
cho tất cả các dòng sau, yêu cầu trả về 1 array int có dạng [0, 1]: " + Environment.NewLine;

            return prompt;
        }
    }
}
