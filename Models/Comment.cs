using System.ComponentModel.DataAnnotations.Schema;
using CourseWork.Areas.Identity.Data;

namespace CourseWork.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }

        public string UserName { get; set; }

        public ApplicationUser User { get; set; } // Reference to the user
    }
}
