using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Api.Contracts;

namespace VideoGameApplication.Api.Models
{
    public class APIsearchGame : IAPIModel
    {
        public List<APIScreenshot> Short_screenshots { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
