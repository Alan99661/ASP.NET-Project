using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Models.BaseClasses;

namespace VideoGameApplication.Models.Entities
{
    internal class Game : BaseModel
    {
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Description { get; set; }
        public List<Developer> Developers { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Platform> Platforms { get; set; }
        public List<Genre> Genres { get; set; }
        public int? MetacriticRating { get; set; }

    }
}
