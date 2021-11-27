using FA.JustBlog.Core.Models;
using FA.JustBlog.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core
{
    public class JustBlogInitializer: CreateDatabaseIfNotExists<JustBlogContext>
    {
        public void SeedData(JustBlogContext context)
        {
            base.Seed(context);

            if (context.Posts.Any() && context.Categories.Any() && context.Tags.Any() && context.PostTags.Any() && context.Comments.Any())
                return;
            //Category
            
            var category1 = new Category()
            {
                Name = "Xã hội",
                UrlSlug = "xa-hoi",
                Description = "Liên quan tới vấn đề xã hội",
                Posts = new List<Post>()
            };
            var category2 = new Category()
            {
                Name = "Thế giới",
                UrlSlug = "the-gioi",
                Description = "Liên quan tới vẫn dề thế giới",
                Posts = new List<Post>()
            };
            var category3 = new Category()
            {
                Name = "Kinh doanh",
                UrlSlug = "kinh-doanh",
                Description = "Liên quan tới vấn đề kinh doanh",
                Posts = new List<Post>()
            };
            List<Category> categories = new List<Category>() { category1, category2, category3 };

            //Post
            var post1 = new Post()
            {
                Title = "Tài xế hất văng cảnh sát cơ động để trốn khai báo y tế",
                ShortDescription = "(Dân trí) - Lái xe đến chốt kiểm dịch, khi được chiến sĩ cảnh sát cơ động hướng dẫn dừng xe vào khai báo y tế, tài xế đã tăng ga tông ngã chiến sĩ cảnh sát rồi bỏ chạy.",
                PostContent = "Trước đó, khoảng 21h15 ngày 17/11, tại chốt kiểm soát dịch Covid-19 Dốc Xây (đóng trên QL1A đoạn qua phường Nam Sơn, TP Tam Điệp), khi lực lượng chức năng đang làm nhiệm vụ, một chiếc xe ô tô con nhãn hiệu Vinfast Lux 2.0 màu đen đi hướng từ tỉnh Thanh Hóa vào Ninh Bình.Lúc này,             chiến sĩ CSCĐ và một cán bộ Thanh tra giao thông(Sở GTVT tỉnh Ninh Bình) đang làm nhiệm vụ ra hiệu lệnh hướng dẫn tài xế này cho xe vào lề đường để khai báo y tế theo quy định phòng chống dịch của tỉnh Ninh Bình. Khi điều khiển xe đến gần điểm đứng của công an, tài xế đã không chấp hành hiệu lệnh, tăng ga chạy qua chốt.Chiếc xe đã hất văng chiến sĩ CSCĐ rồi bỏ chạy theo hướng từ thành phố Tam Điệp đi thành phố Ninh Bình. Cú tông khiến chiến sĩ CSCĐ bị ngã xuống đường dẫn đến bị chấn thương.Nạn nhân sau đó được đưa đến cấp cứu, điều trị tại bệnh viện Đồng Giao, thành phố Tam Điệp. Trao đổi với PV Dân trí, lãnh đạo Công an thành phố Tam Điệp cho biết, cơ quan Công an đã xác định được chiếc xe và tài xế gây ra vụ việc.Khi làm rõ hành vi của tài xế này sẽ cung cấp thông tin cụ thể cho phóng viên Vụ việc đang được Công an thành phố Tam Điệp,tỉnh Ninh Bình điều tra làm rõ.",
                UrlSlug = "tai-xe-hat-vang-canh-sat-co-dong-de-tron-khai-bao-y-te",
                Published = true,
                PostedOn = DateTime.Now,
                Modified = false,
                ViewCount = 1,
                RateCount = 1,
                TotalRate = 1
            };

            var post2 = new Post()
            {
                Title = "Các đại sứ châu Âu ủng hộ thúc đẩy luật pháp quốc tế trong vấn đề Biển Đông",
                ShortDescription = "(Dân trí) - Các nhà ngoại giao nước ngoài nhấn mạnh tầm quan trọng của luật pháp quốc tế trong việc giải quyết vấn đề Biển Đông và các vùng biển quốc tế hiện nay.",
                PostContent = "Sáng 18/11, tại Hà Nội, Học viện Ngoại giao đã khai mạc Hội thảo khoa học quốc tế về Biển Đông lần thứ 13 với chủ đề Nhìn lại quá khứ vì một tương lai tươi sáng hơn. Hội thảo có sự tham dự trực tiếp của hơn 180 đại biểu cùng hơn 400 đại biểu đăng ký tham dự trực tuyến, trong đó có gần 60 diễn giả, là các chuyên gia uy tín từ 30 quốc gia trên các châu lục, 90 đại biểu từ các cơ quan đại diện nước ngoài tại Việt Nam (bao gồm 15 đại sứ). Thông qua các phiên thảo luận trong ngày làm việc đầu tiên, những vấn đề nổi cộm như cạnh tranh Mỹ - Trung, vai trò trung tâm của ASEAN, luật pháp quốc tế… đã được nhấn mạnh xuyên suốt các bài phát biểu của các diễn giả. Đánh giá về chủ đề năm nay, Đại sứ Thụy Sĩ tại Việt Nam Ivo Sieber nhận định: Nhìn lại quá khứ vì một tương lai tươi sáng hơn là một chủ đề rất quan trọng và mở ra nhiều vấn đề để bàn luận. Đây là thách thức rất lớn đối với toàn khu vực, thậm chí nó vượt ra khỏi phạm vi khu vực, trở thành một vấn đề toàn cầu với các nội hàm như tự do hàng hải, sử dụng tài nguyên biển… Như chúng ta đã lắng nghe sáng nay, có rất nhiều quan điểm khác nhau đến từ các học giả. Vì vậy, tôi nghĩ hội thảo năm nay là một nền tảng rất hữu ích để các học giả trên thế giới cùng thảo luận về vấn đề này. Trong các phiên đầu của hội thảo, các diễn giả đã tập trung giải quyết các câu hỏi về bối cảnh thế giới, nêu bật bản chất phức tạp của tình hình Biển Đông hiện nay và cho rằng Biển Đông không chỉ là tài sản riêng của bất kỳ quốc gia nào mà là tài sản chung của toàn thế giới.",
                UrlSlug = "cac-dai-su-chau-au-ung-ho-thuc-day-luat-phap-quoc-te-trong-van-de-bien-dong",
                Published = true,
                PostedOn = DateTime.Now,
                Modified = false,
                ViewCount = 2,
                RateCount = 2,
                TotalRate = 2
            };

            var post3 = new Post()
            {
                Title = "TPHCM kiến nghị dùng quỹ bình ổn xăng dầu để bình ổn giá cả",
                ShortDescription = "(Dân trí) - Để kéo mặt bằng giá trở lại,Sở Công Thương TPHCM sẽ kiến nghị Bộ Công Thương sử dụng quỹ bình ổn xăng,dầu.",
                PostContent = "Để bình ổn giá cả hàng hóa, Sở Công Thương đã có chương trình hỗ trợ các doanh nghiệp khôi phục sản xuất. Khi lượng hàng gia tăng, giá cả thị trường sẽ được ổn định lại.Ngoài ra,thành phố cũng triển khai một số kích cầu từ nay đến cuối năm như khuyến mãi,kết nối hàng hóa giữa TPHCM và các tỉnh,thành phố.Đặc biệt,Sở Công Thương sẽ kiến nghị Bộ Công Thương sử dụng quỹ bình ổn xăng,dầu để kéo mặt bằng giá trở lại.Bà Nguyễn Thị Kim Ngọc chia sẻ thêm,hiện tại, thành phố đã có 177 / 234 chợ truyền thống được hoạt động lại.Dự kiến từ nay đến cuối tháng 11,từng quận, huyện sẽ có phương án hoạt động lại tất cả chợ theo với điều kiện an toàn trong tình hình mới.Với mục tiêu đảm bảo an toàn phòng, chống dịch và đảm bảo cung ứng hàng hóa, Sở Công Thương sẽ làm việc với các đơn vị, quận, huyện, thành phố Thủ Đức để các chợ truyền thống còn lại được mở cửa trong thời gian sớm nhất, Phó Giám đốc Sở Công Thương khẳng định.",
                UrlSlug = "tphcm-kien-nghi-dung-quy-binh-on-xang-dau-de-binh-on-gia-ca",
                Published = true,
                PostedOn = DateTime.Now,
                Modified = false,
                ViewCount = 3,
                RateCount = 3,
                TotalRate = 3
            };
            List<Post> posts = new List<Post>() { post1, post2, post3 };

            //Tag
            var tag1 = new Tag()
            {
                Name = "Xã hội",
                UrlSlug = "xa-hoi",
                Description = "Liên quan tới vấn đề xã hội",
                Count = 1
            };

            var tag2 = new Tag()
            {
                Name = "Thế giới",
                UrlSlug = "the-gioi",
                Description = "Liên quan tới vẫn dề thế giới",
                Count = 2
            };

            var tag3 = new Tag()
            {
                Name = "Kinh doanh",
                UrlSlug = "kinh-doanh",
                Description = "Liên quan tới vấn đề kinh doanh",
                Count = 3
            };
            List<Tag> tags = new List<Tag>() { tag1, tag2, tag3 };

            //PostTag
            var postTag = new PostTag()
            {
                PostId = post1.Id,
                TagId = tag1.Id
            };
            var postTag1 = new PostTag()
            {
                PostId = post2.Id,
                TagId = tag2.Id
            }; 
            var postTag2 = new PostTag()
            {
                PostId = post3.Id,
                TagId = tag3.Id
            };
            List<PostTag> postTags = new List<PostTag>() { postTag, postTag1, postTag2 };

            //Comment
            var comment1 = new Comment()
            {
                Name = "Comment 1",
                Email = "Email 1",
                CommentHeader = "Cmt Header 1",
                CommentText = "Cmt Text 1",
                CommentTime = DateTime.Now
            };

            var comment2 = new Comment()
            {
                Name = "Comment 2",
                Email = "Email 2",
                CommentHeader = "Cmt Header 2",
                CommentText = "Cmt Text 2",
                CommentTime = DateTime.Now
            };

            var comment3 = new Comment()
            {
                Name = "Comment 3",
                Email = "Email 3",
                CommentHeader = "Cmt Header 3",
                CommentText = "Cmt Text 3",
                CommentTime = DateTime.Now
            };
            List<Comment> comments = new List<Comment>() { comment1, comment2, comment3 };


            category1.Posts.Add(post1);
            category2.Posts.Add(post2);
            category3.Posts.Add(post3);

            post1.Comments.Add(comment1);
            post2.Comments.Add(comment1);
            post2.Comments.Add(comment2);
            post3.Comments.Add(comment1);
            post3.Comments.Add(comment2);
            post3.Comments.Add(comment3);

            postTag.Posts = post1;
            postTag.Tags = tag1;
            postTag1.Posts = post2;
            postTag1.Tags = tag2;
            postTag2.Posts = post3;
            postTag2.Tags = tag3;

            context.Categories.AddRange(categories);
            context.Posts.AddRange(posts);
            context.Comments.AddRange(comments);
            context.Tags.AddRange(tags);
            //context.PostTags.AddRange(postTags);

            context.SaveChanges();
        }

    }
}
