using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Watch.Me.Models.Entities
{
    public class Video
    {
        public int Id { get; set; }
        public string VideoTitle { get; set; }
        public string Url { get; set; }
        public bool IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedOn { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        
    }
}