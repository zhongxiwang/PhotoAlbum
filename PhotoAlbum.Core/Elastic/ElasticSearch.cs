using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhotoAlbum.Core.Elastic
{
    public class ElasticSearch : IElasticSearch
    {
        private readonly IElasticLowLevelClient LowClient;
        
        public ElasticSearch(IConnectionSettingsValues settings)
        {
            this._client = new ElasticClient(settings);
            LowClient = new ElasticLowLevelClient(settings);
        }
        IElasticClient _client = null;
        IElasticClient IElasticSearch.Client { get { return _client; }  }

        T IElasticSearch.CreateIndex<T>(string index, string id, T parm)
        {
            return this.LowClient.Index<T>(index, id, PostData.Serializable(parm));
        }

        Task<T> IElasticSearch.CreateIndexAsync<T>(string index, string id, T parm, CancellationToken token)
        {
            return this.LowClient.IndexAsync<T>(index, id, PostData.Serializable(parm),ctx:token);
        }

        Task<IEnumerable<T>> IElasticSearch.CreateListIndex<T>(T[] parm)
        {
             var res= this.LowClient.Bulk<T>(PostData.MultiJson(parm)) ;
            return null;
        }

        Task<IEnumerable<T>> IElasticSearch.CreateListIndexAsync<T>(T[] parm, CancellationToken token)
        {
             var res= this.LowClient.BulkAsync<T>(PostData.MultiJson(parm),ctx:token) ;
            return null;
        }

        T IElasticSearch.Search<T>(string index, string PostData)
        {
            return this.LowClient.Search<T>(index, PostData);
        }

        Task<T> IElasticSearch.SearchAsync<T>(string index, string PostData, CancellationToken token)
        {
            return this.LowClient.SearchAsync<T>(index, PostData,ctx:token);
        }
    }
}
