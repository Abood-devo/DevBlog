using BusinessLogic.DTOs;
using DataAccess.Entities;
namespace BusinessLogic.Extensions
{
    public static class BlogPostTagExtensions
    {
        public static BlogPostTagDTO ToDTO(this BlogPostTag blogPostTag)
        {
            return new BlogPostTagDTO
            {
                BlogPostID = blogPostTag.BlogPostID,
                BlogPost = blogPostTag.BlogPost,

                TagID = blogPostTag.TagID,
                Tag = blogPostTag.Tag
    };
        }
        public static BlogPostTag ToEntity(this BlogPostTagDTO blogPostTagDTO)
        {
            return new BlogPostTag
            {
                BlogPostID = blogPostTagDTO.BlogPostID,
                BlogPost = blogPostTagDTO.BlogPost,

                TagID = blogPostTagDTO.TagID,
                Tag = blogPostTagDTO.Tag
            };
        }
    }
}
