using Microsoft.Extensions.Options;
using PhotoAlbum.Core.Elastic;
using PhotoAlbum.Core.Uilts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PhotoAlbum.Core.Services
{
    public class ImageService
    {
        IElasticSearch search;
        PhotoAlbumGroupConfiguration opt;
        ImageGroupService service;
        FileExtensionConfiguration exts;
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
        public void Import(string path,string Name)
        {
            var name= Path.GetDirectoryName(path);
            //var group= service.CreateGroup(Name,path);
            Dictionary<string, ImageModel> list = new Dictionary<string, ImageModel>();//改为双缓存队列
            foreach(var key in  Directory.GetFiles(path, "*", SearchOption.AllDirectories))
            {
                var ext= Path.GetExtension(key);
                var filename = Path.GetFileName(key);
                if (exts.ImageExts.Contains(ext))
                {
                    //list.Add(filename, new ImageModel(name, key,group));
                }
                else if(exts.BgMusicExts.Contains(ext))
                {
                    //背景音乐是group的，
                }else if (exts.VideosExts.Contains(ext))
                {

                }
            }            
        }
        
        public void Add()
        {

        }

        private string[] GetFiles(string path,string exten)
        {
            return Directory.GetFiles(path, "*."+exten, SearchOption.AllDirectories);
        }
    }
}
