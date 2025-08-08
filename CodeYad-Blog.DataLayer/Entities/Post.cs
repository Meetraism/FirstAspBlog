using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog.DataLayer.Entities
{
    public class Post: BaseEntity<int>
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public string Discription { get; set; }
        public int Visit { get; set; }
        [Required]
        [MaxLength(100)]
        public string Slug { get; set; }

        #region Relations

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public ICollection<PostComment> PostComments { get; set; }

        #endregion
    }
}
