using devBlog.Models;

namespace devBlog.Models
{
	public class Role
	{
		public Guid RoleID { get; set; }
        public string RoleName { get; set; }
	}
}

//### 5. **Role**

//-**RoleID * *: `int` or `Guid` (Primary Key, auto-generated).
//- **RoleName**: `string` (max length 50). Name of the role (e.g., "Blogger", "Admin"). Unique.