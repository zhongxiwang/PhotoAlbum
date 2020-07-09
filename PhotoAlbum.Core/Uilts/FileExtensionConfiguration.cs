using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.Core.Uilts
{
    public class FileExtensionConfiguration
    {
        public HashSet<string> ImageExts { get; set; }
        public HashSet<string> BgMusicExts { get; set; }
        public HashSet<string> VideosExts { get; set; }

    }
}
