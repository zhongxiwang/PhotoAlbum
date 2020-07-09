using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PhotoAlbum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageHandlerController : ControllerBase
    {
        /// <summary>
        /// 上传图片
        /// </summary>
        [HttpPost("ImportImage")]
        public void ImportImage(string Groupid)
        {
            if (string.IsNullOrEmpty(Groupid)) return ;
            var res= HttpContext.Request.Form.Files.Count();
            string path = Path.GetTempPath();

            ///图片需要缩小并压缩，方便展示
            ///
            try
            {

            }catch(Exception e)
            {

            }
            finally
            {

            }

        }

        /// <summary>
        /// 扫描文件夹路径来添加
        /// </summary>
        [HttpPost]
        public void ImportDir(string dirPath)
        {
            ///图片需要缩小并压缩，方便展示
        }


        /// <summary>
        /// 编辑图片
        /// </summary>
        /// <param name="id"></param>
        [HttpPost("Edit")]
        public void EditImage(string id)
        {
            ///编制照片说明，包括背景音乐，或者相对应的视频
        }
        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="id"></param>
        [HttpPost]
        public void Delete(string id)
        {
            //写入回收文件夹，达到一定区间后压缩原始图片，创建还原点
        }
    }
}