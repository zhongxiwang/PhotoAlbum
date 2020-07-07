using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.Core.Model
{
    public enum DescriptionType { Normal,Page,Json }
    public class ImageGroupDescription
    {
         public DescriptionType Type { get; set; }
        public string Body { get; set; }
    }
}
