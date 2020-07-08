using Microsoft.Extensions.Options;
using PhotoAlbum.Core.Elastic;
using PhotoAlbum.Core.Uilts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.Core.Services
{
    public class ImageService
    {
        IElasticSearch search;
        PhotoAlbumGroupConfiguration opt;
        public ImageService(IElasticSearch search, IOptionsMonitor<PhotoAlbumGroupConfiguration> opt)
        {
            this.search = search;
            this.opt = opt.CurrentValue;
        }
        public void ImageChange(string id)
        {

        }
        public void Delete()
        {

        }
        /// <summary>
        /// 导入
        /// </summary>
        public void Import()
        {

        }
        public void Add()
        {

        }
    }
}
