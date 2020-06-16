using PhotoAlbum.Core.Elastic;
using PhotoAlbum.Core.Test.Elastic;
using System;
using Xunit;

namespace PhotoAlbum.Core.Test
{
    public class ElasticTest:BaseTest
    {
        const string index = "PhotAlbumTest";
        [Fact]
        public TestDemo Write()
        {
            var res= this.Es.CreateIndex(index, Guid.NewGuid().ToString(), new TestDemo
            {
                Age = 18,
                book = "book",
                Name = "name"
            });
            return res;
        }
        [Fact]
        public void Test1()
        {
            
        }
    }
}
