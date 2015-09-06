using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Watch.Me.Models.ViewModels
{
    public class DisplayedVideosViewModel
    {
        public int Id { get; set; }
        public string VideoTitle { get; set; }
        public string Url { get; set; }

        public List<DisplayedVideosViewModel> ReccomendedVideos { get; set; }
        public List<DisplayedVideosViewModel> RecentVideos { get; set; }
        public List<DisplayedVideosViewModel> PopularVideos { get; set; }
    }
}