using Elasticsearch.Net;
using Nest;
using PhotoAlbum.Core.Elastic;
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
        static void Test()
        {
            var nodes = new Uri[]
            {
                new Uri("http://10.204.124.222:9200"),
            };

            var pool = new StaticConnectionPool(nodes);
            
            var settings = new ConnectionSettings(pool).DefaultIndex("photo_album_image");
            var client = new ElasticClient(settings);
            var lowLevelClient = new ElasticLowLevelClient(settings);
            var data = new ImageModel
            {
                Description = " 说明 ",
                CreateTime = DateTime.Now,
                Filename = "filename.jpng",
                KeyWorld = new System.Collections.Generic.List<string> { "test" },
                Id = Guid.NewGuid().ToString(),
                Location = "shengzheng",
                Subject = "有望",
                Videos = "test.mp4"
            };

            var ndexResponse =lowLevelClient.Index<ImageModel>("索引", "PostData", PostData.Serializable(data));

            var searchResponse = lowLevelClient.Search<StringResponse>("people", PostData.Serializable(new
            {
                from = 0,
                size = 10,
                query = new
                {
                    match = new
                    {
                        firstName = new
                        {
                            query = "Martijn"
                        }
                    }
                }
            }));

            var successful = searchResponse.Success;
            var responseJson = searchResponse.Body;

            var response= client.IndexDocument(data);
            
            var t= response.Result;
            var searchReponse= client.Search<ImageModel>(s => s.From(0).Size(10).Query(q => q.
            Match(m => m.Field(f => f.Filename).Query("filename.jpng"))));
            var people= searchReponse.Documents;
        }
    }
}
