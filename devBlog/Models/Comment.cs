namespace devBlog.Models
{
	public class Comment
	{
		public Guid CommentID { get; set; }
        public string Content { get; set; }
        public Guid AuthorID { get; set; }
        public Guid BlogPostID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User Author { get; set; }
        public BlogPost BlogPost { get; set; }
	}
}


//###  **Comment**

//-**CommentID * *: `int` or `Guid` (Primary Key, auto-generated).
//- **Content**: `string` (type `TEXT` in SQL). The text of the comment.
//- **AuthorID**: `int` or `Guid` (Foreign Key referencing `User.UserID`).
//- **BlogPostID**: `int` or `Guid` (Foreign Key referencing `BlogPost.BlogPostID`).
//- **CreatedAt**: `DateTime`. Timestamp when the comment was created.
//- **UpdatedAt**: `DateTime`. Timestamp of the last update.