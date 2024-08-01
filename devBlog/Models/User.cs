using devBlog.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Principal;
using System.Xml.Linq;
using System.Xml;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.ComponentModel.DataAnnotations;

namespace devBlog.Models
{
	public class User
	{
	}
}

//UserID: int or Guid(Primary Key, auto - generated).
//Username: string(max length 256).Unique.
//Email: string(max length 256).Unique.
//PasswordHash: string(max length 256).Store hashed and salted password.
//Role: string(max length 50).Values might include "Blogger" or "Admin".
//CreatedAt: DateTime.Timestamp of when the account was created.
//UpdatedAt: DateTime.Timestamp of the last update to the account.