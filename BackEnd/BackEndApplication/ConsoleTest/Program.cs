using AI.Dev.OpenAI.GPT;
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

            string text = "hãy so sánh các yêu cầu bên trái và các đáp ứng bên phải sau, \r\nvới mỗi một vế 1 so sánh với một vế 2 tương ứng, nếu bên vế 2 có đáp ứng bên vế 1 hãy trả về 1 còn \r\nkhông thì trả về 0 cho tất cả các so sánh sau, yêu cầu trả về 1 array int chỉ có dạng [0, 1], \r\nkhông yêu cầu giải thích hay các thông tin liên quan: \r\nVế 1: '- Tối thiểu 2 năm kinh nghiệm dẫn dắt đội nhóm từ 5 người, đã từng chạy hiệu quả ngân sách từ 5 tỷ/tháng với tỷ lệ chuyển đổi <20% CPQC/DT' và Vế 2: 'Đã từng là: Digital Marketing, tại công ty: Công ty Bất động sản CV 365, từ 11/2018 đến 05/2019, với vị trí: nhân viên tạm thời, với mô tả như sau: - Triển khai các công việc cụ thể trong quảng cáo Google adwords, Facebook ads, Zalo, Email marketing, youtube theo từng chiến dịch quảng bá của công ty dưới sự phân công của Trưởng phòng.' \r\nVế 1: '- Tối thiểu 2 năm kinh nghiệm dẫn dắt đội nhóm từ 5 người, đã từng chạy hiệu quả ngân sách từ 5 tỷ/tháng với tỷ lệ chuyển đổi <20% CPQC/DT' và Vế 2: 'Đã từng là: Digital Marketing, tại công ty: Công ty Bất động sản CV 365, từ 11/2018 đến 05/2019, với vị trí: nhân viên tạm thời, với mô tả như sau: - Quản trị nội dung và tối ưu SEO Onpage, SEO Offpage website công ty: đi baclink, tối ưu onpage: Title, thẻ des, hình ảnh, internal theo mô hình... Kéo traffic, tạo signal.... chuẩn seo theo kế hoạch của trưởng phòng.' \r\nVế 1: '- Tối thiểu 2 năm kinh nghiệm dẫn dắt đội nhóm từ 5 người, đã từng chạy hiệu quả ngân sách từ 5 tỷ/tháng với tỷ lệ chuyển đổi <20% CPQC/DT' và Vế 2: 'Đã từng là: Digital Marketing, tại công ty: Công ty Bất động sản CV 365, từ 11/2018 đến 05/2019, với vị trí: nhân viên tạm thời, với mô tả như sau: - Viết bài seeding, lập các tài khoản và tham gia vào nhóm để chia sẻ bài viết...' \r\nVế 1: '- Tối thiểu 2 năm kinh nghiệm dẫn dắt đội nhóm từ 5 người, đã từng chạy hiệu quả ngân sách từ 5 tỷ/tháng với tỷ lệ chuyển đổi <20% CPQC/DT' và Vế 2: 'Đã từng là: Digital Marketing, tại công ty: Công ty Bất động sản CV 365, từ 11/2018 đến 05/2019, với vị trí: nhân viên tạm thời, với mô tả như sau: - Quản lý nội dung kênh youtube của công ty: Lên ý tưởng và viết kịch bản video.' \r\nVế 1: '- Tối thiểu 2 năm kinh nghiệm dẫn dắt đội nhóm từ 5 người, đã từng chạy hiệu quả ngân sách từ 5 tỷ/tháng với tỷ lệ chuyển đổi <20% CPQC/DT' và Vế 2: 'Đã từng là: Digital Marketing, tại công ty: Công ty Bất động sản CV 365, từ 11/2018 đến 05/2019, với vị trí: nhân viên tạm thời, với mô tả như sau: -Hỗ trợ các kế hoạch truyền thông, triển khai POSM do phòng Marketing tổ chức' \r\nVế 1: '- Tối thiểu 2 năm kinh nghiệm dẫn dắt đội nhóm từ 5 người, đã từng chạy hiệu quả ngân sách từ 5 tỷ/tháng với tỷ lệ chuyển đổi <20% CPQC/DT' và Vế 2: 'Đã từng là: Digital Marketing, tại công ty: Công ty Bất động sản CV 365, từ 11/2018 đến 05/2019, với vị trí: nhân viên tạm thời, với mô tả như sau: - Phối hợp với bộ phận IT tối ưu giao diện người dùng cũng như hành vi khách hàng' \r\nVế 1: '- Tối thiểu 2 năm kinh nghiệm dẫn dắt đội nhóm từ 5 người, đã từng chạy hiệu quả ngân sách từ 5 tỷ/tháng với tỷ lệ chuyển đổi <20% CPQC/DT' và Vế 2: 'Đã từng là: Digital Marketing, tại công ty: Công ty Bất động sản CV 365, từ 11/2018 đến 05/2019, với vị trí: nhân viên tạm thời, với mô tả như sau: - Tổng kết và báo cáo định kỳ tháng công việc hoàn thành sau mỗi chiến dịch.' \r\nVế 1: '- Tối thiểu 2 năm kinh nghiệm dẫn dắt đội nhóm từ 5 người, đã từng chạy hiệu quả ngân sách từ 5 tỷ/tháng với tỷ lệ chuyển đổi <20% CPQC/DT' và Vế 2: 'Đã từng là: Digital Marketing, tại công ty: Công ty Bất động sản CV 365, từ 11/2018 đến 05/2019, với vị trí: nhân viên tạm thời, với mô tả như sau: Công ty CV365' \r\nVế 1: '- Tối thiểu 2 năm kinh nghiệm dẫn dắt đội nhóm từ 5 người, đã từng chạy hiệu quả ngân sách từ 5 tỷ/tháng với tỷ lệ chuyển đổi <20% CPQC/DT' và Vế 2: 'Đã từng là: Nhân viên Content – Marketing, tại công ty: Công ty Cổ phần kiến trúc và nội thất CV365, từ 02/2018 đến 05/2018, với vị trí: nhân viên tạm thời, với mô tả như sau: - Biên tập nội dung viết bài chuẩn SEO về dịch vụ của công ty.' \r\nVế 1: '- Tối thiểu 2 năm kinh nghiệm dẫn dắt đội nhóm từ 5 người, đã từng chạy hiệu quả ngân sách từ 5 tỷ/tháng với tỷ lệ chuyển đổi <20% CPQC/DT' và Vế 2: 'Đã từng là: Nhân viên Content – Marketing, tại công ty: Công ty Cổ phần kiến trúc và nội thất CV365, từ 02/2018 đến 05/2018, với vị trí: nhân viên tạm thời, với mô tả như sau: - Viết bài chia sẻ kinh nghiệm kiến thức về lĩnh vực tuyển dụng, xin việc theo kế hoạch của bộ phận SEO.' \r\nVế 1: '- Tối thiểu 2 năm kinh nghiệm dẫn dắt đội nhóm từ 5 người, đã từng chạy hiệu quả ngân sách từ 5 tỷ/tháng với tỷ lệ chuyển đổi <20% CPQC/DT' và Vế 2: 'Đã từng là: Nhân viên Content – Marketing, tại công ty: Công ty Cổ phần kiến trúc và nội thất CV365, từ 02/2018 đến 05/2018, với vị trí: nhân viên tạm thời, với mô tả như sau: - Quản trị nội dung Fanpage, Group trên các trang mạng xã hội của công ty.' \r\nkhông yêu cầu giải thích, chỉ cần kết quả dưới dạng int array[]";

            // 5 tokens => [21339, 352, 301, 11, 4751]
            List<int> tokens = GPT3Tokenizer.Encode(text);
            Console.WriteLine(tokens.Count);
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