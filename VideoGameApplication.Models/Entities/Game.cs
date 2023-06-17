using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Models.BaseClasses;

namespace VideoGameApplication.Models.Entities
{
    public class Game : BaseModel
    {
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Description { get; set; }
        public virtual List<Developer> Developers { get; set; }
        public virtual List<Review>? Reviews { get; set; }
        public virtual List<Platform>? Platforms { get; set; }
        public virtual List<Genre>? Genres { get; set; }
        public virtual List<Screenshot>?  Screenshots { get; set; }
        public string? BackgroundImageUrl { get; set; }
        public int? MetacriticRating { get; set; }
        public string? GameWebsite { get; set; }

    }
}
