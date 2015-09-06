using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Watch.Me.Models.Entities
{
    public class EmotionsAboutVideo
    {
        public int Id { get; set; }
        public bool Love { get; set; }
        public bool? Dislike { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Video Video { get; set; }
    }
}