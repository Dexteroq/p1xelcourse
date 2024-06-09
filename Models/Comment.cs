using CourseWork.Areas.Identity.Data;

namespace CourseWork.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; } 
        public DateTime DatePosted { get; set; } 
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }

}
