using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Database;

namespace VideoGameApplication.Servises.CrudOperations
{
    public class ScreenshotCrudOperations
    {
        private readonly VideoGameDBContext context;
        private readonly IMapper mapper;

        public ScreenshotCrudOperations(VideoGameDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
    }
}
