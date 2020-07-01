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
        
        /// <summary>
        /// 真实路径名称
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 封面
        /// </summary>
        public string Cover { get; set; }
        /// <summary>
        /// Group Id
        /// </summary>
        public string Id { get;  set; }
        /// <summary>
        /// 相册说明
        /// </summary>
        public ImageGroupDescription Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime { get; set; }
        
        /// <summary>
        /// 相册数据
        /// </summary>
        public int Total { get; set; }

        public Dictionary<string,string> Properties { get; set; }

        public string backgroundMusic { get; set; }
        
    }
}
