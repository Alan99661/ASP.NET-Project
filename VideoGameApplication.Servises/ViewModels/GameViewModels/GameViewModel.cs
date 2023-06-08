using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Models.Entities;

namespace VideoGameApplication.Servises.ViewModels.GameViewModels
{
    public class GameViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Description { get; set; }
        public List<Developer>? Developers { get; set; }
        public List<Review>? Reviews { get; set; }
        public List<Platform>? Platforms { get; set; }
        public List<Genre>? Genres { get; set; }
        public List<Screenshot>? Screenshots { get; set; }
        public string? BackgroundImageUrl { get; set; }
        public int? MetacriticRating { get; set; }
        public string GameWebsite { get; set; }
    }
}
