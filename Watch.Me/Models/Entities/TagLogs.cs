using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Watch.Me.Models.Entities
{
    public class TagLogs
    {
        public int Id { get; set; }
        public bool Searched { get; set; }
        public DateTime SearchDate { get; set; }   

            
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Tag Tag { get; set; } 

        public TagLogs()
        {
            SearchDate = DateTime.Now;         // by default when model is created will have current System.Time
        }
    }
}