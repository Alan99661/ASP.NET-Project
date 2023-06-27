using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Api.Contracts;

namespace VideoGameApplication.Api.Models
{
    public class ApiSearchGame : IApiModel
    {
        public List<ApiScreenshot> Short_screenshots { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
