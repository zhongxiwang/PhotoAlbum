using PhotoAlbum.Core.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.Core.Services
{
    public class Request
    {
        /// <summary>
        /// 参数id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 相册名称
        /// </summary>
        public PhotoAlbumModel Album { get; set; }

        /// <summary>
        /// 文件集合
        /// </summary>
        public List<string> Paths { get; set; }

        public List<ImageModel>  ImageList{ get; set; }

    }
}
