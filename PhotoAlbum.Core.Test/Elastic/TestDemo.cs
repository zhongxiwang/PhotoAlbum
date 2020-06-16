using Elasticsearch.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.Core.Test.Elastic
{
    public class TestDemo: IElasticsearchResponse
    {
        public string Name { get; set; }
        public string book { get; set; }
        public int Age { get; set; }
        public IApiCallDetails ApiCall { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool TryGetServerErrorReason(out string reason)
        {
            throw new NotImplementedException();
        }
    }
}
