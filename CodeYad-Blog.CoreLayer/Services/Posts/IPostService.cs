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
        PostFilterDto GetPostByFilter(PostFilterParams filterParams);
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

        public PostFilterDto GetPostByFilter(PostFilterParams filterParams)
        {
            var result = _context.Posts.OrderByDescending(d => d.CreationDate).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filterParams.CategorySlug))
                result = result.Where(r => r.Category.Slug == filterParams.CategorySlug);

            if (!string.IsNullOrWhiteSpace(filterParams.Title))
                result = result.Where(r => r.Title.Contains(filterParams.Title));

            var skip = (filterParams.PageId - 1) * filterParams.Take;
            var pageCount = result.Count() / filterParams.Take;
            return new PostFilterDto()
            {
                Posts = result.Skip(skip).Take(filterParams.Take)
                .Select(post=>PostMapper.MapToDto(post)).ToList(),
                FilterParams = filterParams,
                PageCount = pageCount
            };

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
