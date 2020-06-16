using Elasticsearch.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.Core.Elastic
{
    public class ImageModel: IElasticsearchResponse
    {
        public string Filename { get; set; }
        public DateTime CreateTime { get; set; }
        public string Location { get; set; }
        public string Subject { get; set; }
        public string Videos { get; set; }
        public List<string> KeyWorld { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public IApiCallDetails ApiCall { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool TryGetServerErrorReason(out string reason)
        {
            throw new NotImplementedException();
        }
    }
}
