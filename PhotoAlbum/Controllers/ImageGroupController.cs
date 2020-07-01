using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PhotoAlbum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageGroupController : ControllerBase
    {
        /// <summary>
        /// 创建图片组
        /// </summary>
        [HttpPost("CreateGroup")]
        public void CreateGroup()
        {
            
        }
        [HttpPost("EditGroup")]
        public void EditGroup()
        {

        }
        /// <summary>
        /// 访问限制
        /// </summary>
        [HttpPost("Accesss")]
        public void Accesss()
        {

        }
        /// <summary>
        ///  图片数据 
        /// </summary>
        [HttpDelete]
        public void Delete(string id)
        {
            //写入回收站，创建还原点，写入删除记录
        }
    }
}