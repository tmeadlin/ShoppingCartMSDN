using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Core.Models.Config;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace AzureDocumentDb
{
    public class AzureDocDatabase : IAzureDocDatabase
    {
        private readonly IAzureDocClient _docClient;
        private readonly DocumentDbConfig _documentDbConfig;
        private Database _documentDatabase;
        static readonly SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

        public AzureDocDatabase(IAzureDocClient docClient, DocumentDbConfig documentDbConfig)
        {
            _docClient = docClient;
            _documentDbConfig = documentDbConfig;
        }

        #region IAzureDocDatabase Methods

        public DocumentClient Client => _docClient.Client;
        public async Task<string> SelfLink() => (await GetDocumentDatabase()).SelfLink;
        public async Task<string> AltLink() => (await GetDocumentDatabase()).AltLink;

        #endregion

        #region Private Methods

        private async Task<Database> GetDocumentDatabase()
        {
            if (_documentDatabase != null) return _documentDatabase;

            await semaphoreSlim.WaitAsync();

            try
            {
                _documentDatabase = _docClient.Client.CreateDatabaseQuery().Where(db => db.Id == _documentDbConfig.Name).AsEnumerable().FirstOrDefault();

                // If the database does not exist, create a new database
                if (_documentDatabase == null)
                    _documentDatabase = await _docClient.Client.CreateDatabaseAsync(new Database { Id = _documentDbConfig.Name });
            }
            finally
            {
                semaphoreSlim.Release();
            }

            return _documentDatabase;
        }

        #endregion
    }
}
