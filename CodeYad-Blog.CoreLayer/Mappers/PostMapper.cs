using CodeYad_Blog.CoreLayer.DTOs.Posts;
using CodeYad_Blog.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog.CoreLayer.Mappers
{
    public class PostMapper
    {
        public static Post MapCreateDtoToPost(CreatePostDto dto)
        {
            return new Post()
            {
                Description = dto.Description,
                CategoryId = dto.CategoryId,
                Slug = dto.Slug,
                Title = dto.Title,
                UserId = dto.UserId,
                Visit = 0,
                IsDelete = false,
            };
        }
        public static PostDto MapToDto(Post post)
        {
            return new PostDto()
            {
                Description = post.Description,
                CategoryId = post.CategoryId,
                Slug = post.Slug,
                Title = post.Title,
                UserId = post.UserId,
                Visit = post.Visit,
                CreationDate = post.CreationDate,
                Category = CategoryMapper.Map(post.Category),
                ImageName = post.ImageName,
                PostId = post.Id
            };
        }
        public static Post EditPost(EditPostDto dto, Post post) 
        { 
            post.Description = dto.Description;
            post.CategoryId = dto.CategoryId;
            post.Slug = dto.Slug;
            post.Title = dto.Title;
            return post;
        }
    }
}
