using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Watch.Me.Models.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
        
    }
}