using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Models.Entities;

namespace VideoGameApplication.Servises.ViewModels.GameViewModels
{
    public class GameAddModel
    {
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Description { get; set; }
        public List<string> DeveloperIds { get; set; }
        public List<string> ReviewIds { get; set; }
        public List<string> PlatformIds { get; set; }
        public List<string> GenreIds { get; set; }
        public List<string> ScreenshotIds { get; set; }
        public string ScreenshotId { get; set; }
        public int? MetacriticRating { get; set; }
        public string GameWebsite { get; set; }
    }
}
