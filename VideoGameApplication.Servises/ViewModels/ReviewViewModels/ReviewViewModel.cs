using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Models.Entities;

namespace VideoGameApplication.Servises.ViewModels.ReviewViewModels
{
    internal class ReviewViewModel
    {
        public string Id { get; set; }
        public User User { get; set; }
        public Game Game { get; set; }
        public string Content { get; set; }
    }
}
