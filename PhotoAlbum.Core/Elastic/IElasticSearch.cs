using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhotoAlbum.Core.Elastic
{
    public interface IElasticSearch
    {
        IElasticClient Client { get;  }
        public T CreateIndex<T>(string index,string id,T parm ) where T: class, IElasticsearchResponse, new();
        public Task<T> CreateIndexAsync<T>(string index, string id,T parm,CancellationToken token=default) where T : class, IElasticsearchResponse, new();
        public Task<IEnumerable<T>> CreateListIndex<T>(T[] parm) where T : class, IElasticsearchResponse, new();
        public Task<IEnumerable<T>> CreateListIndexAsync<T>(T[] parm,CancellationToken token=default) where T : class, IElasticsearchResponse, new();
        public T Search<T>(string index,string PostData) where T : class, IElasticsearchResponse, new();
        public Task<T> SearchAsync<T>(string index,string PostData,CancellationToken token=default) where T : class, IElasticsearchResponse, new();
    }
}
