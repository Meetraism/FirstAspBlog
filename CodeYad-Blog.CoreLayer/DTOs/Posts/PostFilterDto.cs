using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog.CoreLayer.DTOs.Posts
{
    public class PostFilterDto
    {
        public List<PostDto> Posts { get; set; }
        public PostFilterParams FilterParams { get; set; }
        public int PageCount { get; set; }
    }
    public class PostFilterParams
    {
        public string Title { get; set; }
        public string CategorySlug { get; set; }
        public int PageId { get; set; }
        public int Take { get; set; }
    }
}
