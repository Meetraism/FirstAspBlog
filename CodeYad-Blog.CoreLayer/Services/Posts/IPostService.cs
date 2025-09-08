using CodeYad_Blog.CoreLayer.DTOs.Posts;
using CodeYad_Blog.CoreLayer.Mappers;
using CodeYad_Blog.CoreLayer.Utilities;
using CodeYad_Blog.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CodeYad_Blog.CoreLayer.Services.Posts
{
    public interface IPostService
    {
        OperationResult CreatePost(CreatePostDto command);
        OperationResult EditPost(EditPostDto command);
        PostDto GetPostById(int id);
        bool IsSlugExist(string slug);
    }
    public class PostService : IPostService
    {
        private readonly BlogContext _context;
        public PostService(BlogContext context)
        {  _context = context; }
        public OperationResult CreatePost(CreatePostDto command)
        {
            var post = PostMapper.MapCreateDtoToPost(command);
            _context.Posts.Add(post);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public OperationResult EditPost(EditPostDto command)
        {
            var post = _context.Posts.FirstOrDefault(c=>c.Id == command.PostId);
            if (post == null)    
                return OperationResult.NotFound();

            PostMapper.EditPost(command, post);
            //_context.Posts.Update(post);
            _context.SaveChanges();
            return OperationResult.Success();
            
        }

        public PostDto GetPostById(int id)
        {
            var post = _context.Posts.FirstOrDefault(c => c.Id == id);
            return PostMapper.MapToDto(post);
        }

        public bool IsSlugExist(string slug)
        {
            return _context.Posts.Any(c => c.Slug == slug.ToSlug());
        }
    }
}
