using FinalExercise.Domain.Models;
using Microsoft.Azure.Cosmos;

namespace FinalExercise.Services
{
    public class CosmosDbClientService : CosmosDbService<CosmosClientModel>
    {
        public CosmosDbClientService(CosmosClient dbClient,
            string databaseName,
            string containerName) : base(dbClient, databaseName, containerName)
        {            
        }
    }
}
