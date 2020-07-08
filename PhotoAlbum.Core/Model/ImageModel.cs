using PhotoAlbum.Core.Uilts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;

namespace PhotoAlbum.Core.Model
{

    public class ImageModel
    {
        public string Name { get;  }
        public string filename { get;  set; }
        /// <summary>
        /// 地址，人物，简单说明
        /// </summary>
        public Dictionary<string,string> Properties { get; set; }
        public string Md5 { get; private set; }
        public long Size { get; }
        public long Width { get; }
        public long Height { get;  }
        public DateTime CreateTime { get;  }
        public DateTime LastAccess { get; set; }
        /// <summary>
        /// 场景视频
        /// </summary>
        public string Video { get; set; }

        public string MiniImagePath { get; }

        public PhotoAlbumModel Album { get;  }

        public Image Image { get;  }


        private bool _isExists = true;

        public ImageModel(string name, string filename,PhotoAlbumModel album)
        {
            Name = name;
            this.filename = filename;
            this.Album = album;
            var fi = new FileInfo(this.filename);
            if (!(_isExists = fi.Exists)) return;
            this.Size = fi.Length;
            this.Md5=Uilt.GetMd5(File.ReadAllBytes(filename));
            Image = Image.FromFile(filename);
            this.Width = Image.Width;
            this.Height = Image.Height;
            this.CreateTime = fi.CreationTime;
            this.LastAccess = fi.LastAccessTime;
        }
        public ImageModel(string name,Stream stream, PhotoAlbumModel album)
        {
            Name = name;
            this.filename = album.Path.TrimEnd('/')+"/"+name;
            this.Album = album;
            var buffer= Uilt.GetBytes(stream);
            File.WriteAllBytes(filename, buffer);
            Md5= Uilt.GetMd5(buffer);
            this.Size = buffer.Length;
            Image = Image.FromStream(stream);
            this.Width = Image.Width;
            this.Height = Image.Height;
            this.CreateTime = DateTime.Now;
            this.LastAccess = DateTime.Now;
        }
        
        /// <summary>
        /// 压缩图片
        /// </summary>
        /// <param name="sFile"></param>
        /// <param name="outPath"></param>
        /// <param name="flag"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        private bool GetMiniImage(string sFile, string outPath, int flag,long width)
        {
            System.Drawing.Image iSource = System.Drawing.Image.FromFile(sFile); 
            ImageFormat tFormat = iSource.RawFormat;
            //以下代码为保存图片时，设置压缩质量  
            EncoderParameters ep = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = flag;//设置压缩的比例1-100  
            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            ep.Param[0] = eParam;
            try
            {
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICIinfo = null;
                for (int x = 0; x < arrayICI.Length; x++)
                {
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICIinfo = arrayICI[x];
                        break;
                    }
                }
                if (jpegICIinfo != null)
                {
                    iSource.Save(outPath, jpegICIinfo, ep);//dFile是压缩后的新路径  
                }
                else
                {
                    iSource.Save(outPath, tFormat);
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                iSource.Dispose();
                iSource.Dispose();
            }
        }
        /// <summary>
        /// 缩小图片
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static Image TBScaleBitmap(Image bitmap, int w, int h, string mode)
        {
            Bitmap map = new Bitmap(w, h);
            System.Drawing.Graphics gra = System.Drawing.Graphics.FromImage(map);
            gra.Clear(System.Drawing.Color.Transparent);//清空画布并以透明背景色填充
            gra.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; //使绘图质量最高，即消除锯齿
            gra.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            gra.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            gra.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            gra.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            int towidth = w;
            int toheight = h;

            int x = 0;
            int y = 0;
            int ow = bitmap.Width;
            int oh = bitmap.Height;



            switch (mode)
            {
                case "HW":  //指定高宽缩放（可能变形）                
                    break;
                case "W":   //指定宽，高按比例                    
                    toheight = bitmap.Height * w / bitmap.Width;
                    break;
                case "H":   //指定高，宽按比例
                    towidth = bitmap.Width * h / bitmap.Height;
                    break;
                case "Cut": //指定高宽裁减（不变形）                
                    if ((double)bitmap.Width / (double)bitmap.Height > (double)towidth / (double)toheight)
                    {
                        oh = bitmap.Height;
                        ow = bitmap.Height * towidth / toheight;
                        y = 0;
                        x = (bitmap.Width - ow) / 2;
                    }
                    else
                    {
                        ow = bitmap.Width;
                        oh = bitmap.Width * h / towidth;
                        x = 0;
                        y = (bitmap.Height - oh) / 2;
                    }
                    break;
                case "MaxHW"://最大宽高比例缩放，比如原100*50->50*30，则结果是50*25
                    var rmaxhw_d1w = bitmap.Width * 1.0 / w;
                    var rmaxhw_d2h = bitmap.Height * 1.0 / h;
                    if (rmaxhw_d1w > rmaxhw_d2h)
                    {
                        if (rmaxhw_d1w <= 1)
                        {
                            towidth = bitmap.Width; h = bitmap.Height;
                            goto case "HW";
                        }
                        towidth = w;
                        goto case "W";
                    }
                    if (rmaxhw_d2h <= 1)
                    {
                        towidth = bitmap.Width; h = bitmap.Height;
                        goto case "HW";
                    }
                    toheight = h;
                    goto case "H";
                default:
                    break;
            }

            gra.DrawImage(bitmap, new System.Drawing.Rectangle(0, 0, towidth, toheight), new System.Drawing.Rectangle(x, y, ow, oh), System.Drawing.GraphicsUnit.Pixel);

            gra.Flush();
            gra.Dispose();
            bitmap.Dispose();
            return map;
        }
    }
}
