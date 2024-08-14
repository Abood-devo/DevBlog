using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.DTOs;
using DataAccess.Entities;

namespace BusinessLogic.Extensions
{
    public static class TagExtensions
    {
        public static TagDTO ToDTO(this Tag tag)
        {
            return new TagDTO
            {
                TagID = tag.TagID,
                Name = tag.Name
            };
        }
        public static Tag ToEntity(this TagDTO tagDTO)
        {
            return new Tag
            {
                TagID = tagDTO.TagID,
                Name = tagDTO.Name
            };
        }
    }
}
