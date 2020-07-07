using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAlbum.ViewModel
{
    public class ImageGroupQueryParam
    {
        public DateTime FirstYear { get; set; }
        public DateTime LastYear { get; set; }
        public string KeyWord { get; set; }

    }
}
