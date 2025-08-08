using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog.DataLayer.Entities
{
    public class PostComment : BaseEntity<int>  // Keep PostComment Id as int for any reason if needed
    {
        public int PostId { get; set; }  // Ensure that PostId is 'long', matching Post.Id
        public int UserId { get; set; }
        [Required]
        public string Text { get; set; }

        #region Relations
        [ForeignKey("PostId")]
        public Post Post { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        #endregion
    }

}
