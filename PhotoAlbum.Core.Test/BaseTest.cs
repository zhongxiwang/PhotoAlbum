using Elasticsearch.Net;
using Nest;
using PhotoAlbum.Core.Elastic;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.Core.Test
{
    public class BaseTest
    {
        public IElasticSearch Es { get; private set; }
        public BaseTest()
        {
            var nodes = new Uri[]
            {
                new Uri("http://localhost:9200")
            };

            var pool = new StaticConnectionPool(nodes);
            var settings = new ConnectionSettings(pool);

            this.Es = new ElasticSearch(settings);
        }

    }
}
