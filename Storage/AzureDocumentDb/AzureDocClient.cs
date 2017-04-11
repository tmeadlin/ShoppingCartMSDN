using System;
using Core.Models.Config;
using Microsoft.Azure.Documents.Client;

namespace AzureDocumentDb
{
    public class AzureDocClient : IAzureDocClient
    {
        private DocumentClient _client;
        private readonly DocumentDbConfig _documentDbConfig;
        private readonly Object _thisLock = new Object();

        public AzureDocClient(DocumentDbConfig documentDbConfig)
        {
            _documentDbConfig = documentDbConfig;
        }

        public DocumentClient Client => _client ?? GetClient();

        #region Private Methods

        private DocumentClient GetClient()
        {
            lock (_thisLock)
            {
                _client = new DocumentClient(new Uri(_documentDbConfig.Endpoint), _documentDbConfig.Key);
                return _client;
            }            
        }

        #endregion
    }
}
