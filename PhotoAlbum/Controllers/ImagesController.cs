using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoAlbum.ViewModel;

namespace PhotoAlbum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        /// <summary>
        /// 搜索具有关键字的图片
        /// </summary>
        /// <param name="Param"></param>
        [HttpPost(nameof(ImagesController.Search))]
        public void Search(QueryParam Param ) 
        {
            
        }
        /// <summary>
        /// 搜索图片列表
        /// </summary>
        [HttpGet]
        [HttpPost(nameof(ImagesController.ImageGroupList))]
        public void ImageGroupList(ImageGroupQueryParam Parm)
        {

        }
        /// <summary>
        /// 获取图片列表
        /// </summary>
        /// <param name="Groupid"></param>
        [HttpGet]
        [HttpGet(nameof(ImagesController.ImageList))]
        public void ImageList(string Groupid)
        {

        }
        /// <summary>
        /// 图片说明
        /// </summary>
        /// <param name="imageId"></param>
        [HttpGet]
        [HttpGet(nameof(ImagesController.ImageDescript))]
        public void ImageDescript(string imageId)
        {


        }
        /// <summary>
        /// 图片组的说明
        /// </summary>
        /// <param name="Groupid"></param>
        [HttpGet(nameof(ImagesController.ImageGroupDescript))]
        public void ImageGroupDescript(string Groupid)
        {

        }

    }
}