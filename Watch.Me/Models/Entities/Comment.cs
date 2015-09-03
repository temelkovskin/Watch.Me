using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Watch.Me.Models.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public DateTime DateCreated { get; set; }
        public Comment()
        {
            DateCreated = DateTime.Now;         // by default when model is created will have current System.Time
        }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Video> Videos { get; set; } 
    }
}