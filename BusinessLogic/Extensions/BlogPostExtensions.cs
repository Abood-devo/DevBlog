using BusinessLogic.DTOs;
using DataAccess.Entities;

namespace BusinessLogic.Extensions
{
    public static class BlogPostExtensions
    {
        public static BlogPostDTO ToDTO(this BlogPost blogPost)
        {
            return new BlogPostDTO
            {
                BlogPostID = blogPost.BlogPostID,
                Title = blogPost.Title,
                Content = blogPost.Content,
                Description = blogPost.Description,
                CreationDate = blogPost.CreationDate,
                CoverPhotoUrl = blogPost.CoverPhotoUrl,
                Author = blogPost.Author,
                AuthorID = blogPost.AuthorID,
                IsPublished = blogPost.IsPublished,
                IsApproved = blogPost.IsApproved
            };
        }

        public static BlogPost ToEntity(this BlogPostDTO blogPostDTO)
        {
            return new BlogPost
            {
                BlogPostID = blogPostDTO.BlogPostID,
                Title = blogPostDTO.Title,
                Content = blogPostDTO.Content,
                Description = blogPostDTO.Description,
                CoverPhotoUrl = blogPostDTO.CoverPhotoUrl,
                CreationDate = blogPostDTO.CreationDate,
                Author = blogPostDTO.Author,
                AuthorID = blogPostDTO.AuthorID,
                IsPublished = blogPostDTO.IsPublished,
                IsApproved = blogPostDTO.IsApproved
            };
        }
    }

}
