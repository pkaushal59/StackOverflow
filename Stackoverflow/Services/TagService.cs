using Stackoverflow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stackoverflow.Services
{
    public class TagService
    {
        List<Tag> tags;

        public TagService()
        {
            tags = [];
        }

        public int AddTag(string tag, int userId)
        {
            var newTag = new Tag(){
                TagId =tags.Count + 1,
                Desc = tag,
                UserId = userId
            };
            tags.Add(newTag);
            return newTag.TagId;
        }

        public List<Tag> GetTags(string tag)
        {
           return [.. tags.Where(x=>x.Desc == tag)];    
        }

        internal List<Tag> GetTagsByUserId(int userId)
        {
            return [.. tags.Where(x => x.UserId == userId)];
        }

        
    }
}
