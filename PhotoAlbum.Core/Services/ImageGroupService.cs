using Microsoft.Extensions.Options;
using PhotoAlbum.Core.Elastic;
using PhotoAlbum.Core.Model;
using PhotoAlbum.Core.Uilts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.Core.Services
{
    public class ImageGroupService
    {
        IElasticSearch search;
        PhotoAlbumGroupConfiguration opt;
        public ImageGroupService(IElasticSearch search,IOptionsMonitor<PhotoAlbumGroupConfiguration> opt)
        {
            this.search = search;
            this.opt = opt.CurrentValue;
        }
        public bool CreateGroup(string Name)
        {
            if (IsExsits(Name)) return false;
            var photoAlbum = new PhotoAlbumModel(Name,opt.CreateNewPath());
            
            return true;
        }
        public PhotoAlbumModel GetGroup(string Name)
        {
            return null; 
        }

        public IEnumerable<PhotoAlbumModel> GetPhotoAlbum()
        {
            return null;
        }

        public bool IsExsits(string name)
        {
            return true;
        }
        public bool ChangeGroup()
        {
            return true;
        }
        public bool Delete()
        {

            return true;
        }
    }
}
