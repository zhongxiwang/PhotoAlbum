using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.Core.Model
{
    public class PhotoAlbumModel
    {
        public PhotoAlbumModel()
        {
            Id = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 相册名称
        /// </summary>
        public string Name { get; set; }

        public string Cover { get; set; }
        public string Id { get;  set; }
        public string Description { get; set; } 
        public DateTime CreateTime { get; set; }
        public int Total { get; set; }
        
    }
}
