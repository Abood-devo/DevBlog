using devBlog.Models;

namespace devBlog.Models
{
	public class Topic
	{
		public Guid TopicID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
	}
}

//### **Topic**

//-**TopicID * *: `int` or `Guid` (Primary Key, auto-generated).
//- **Name**: `string` (max length 100). Required, unique.
//- **Description**: `string` (max length 500). Optional.
//- **CreatedAt**: `DateTime`. Timestamp when the topic was created.
//- **UpdatedAt**: `DateTime`. Timestamp of the last update.