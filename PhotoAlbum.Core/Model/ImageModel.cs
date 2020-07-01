using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.Core.Model
{

    public class ImageModel
    {
        public string Name { get; set; }
        public string filename { get; set; }
        /// <summary>
        /// 地址，人物，简单说明
        /// </summary>
        public Dictionary<string,string> Properties { get; set; }
        public string Md5 { get; set; }
        public long Size { get; set; }
        public long Width { get; set; }
        public long Height { get; set; }
        public string CreateTime { get; set; }
        /// <summary>
        /// 场景视频
        /// </summary>
        public string Video { get; set; }
    }
}
