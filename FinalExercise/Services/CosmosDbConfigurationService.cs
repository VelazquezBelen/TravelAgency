using FinalExercise.Domain.Models;
using Microsoft.Azure.Cosmos;

namespace FinalExercise.Services
{
    public class CosmosDbConfigurationService : CosmosDbService<Configuration>
    {
        public CosmosDbConfigurationService(CosmosClient dbClient,
            string databaseName,
            string containerName) : base(dbClient, databaseName, containerName)
        {
        }
    }
}
