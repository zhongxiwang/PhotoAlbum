using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAlbum.ViewModel
{

    public class QueryParam
    {
        public string KeyWord { get; set; }
        /// <summary>
        /// image width
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 图片高度
        /// </summary>
        public int Height { get; set; }

        public int Size { get; set; }

    }
}
