using Elasticsearch.Net;
using System;

namespace PhotoAlbum.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var nodes = new Uri[]
            {
                new Uri("http://myserver1:9200"),
                new Uri("http://myserver2:9200"),
                new Uri("http://myserver3:9200")
            };

            var pool = new StaticConnectionPool(nodes);
            //var settings = new ConnectionSettings(pool);
            //var client = new ElasticClient(settings);
            Console.WriteLine("Hello World!");
        }
    }
}
