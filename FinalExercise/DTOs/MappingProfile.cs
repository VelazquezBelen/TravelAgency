using AutoMapper;
using FinalExercise.Domain.Models;

namespace FinalExercise.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TravelPackage, TravelPackageDTO>();
            CreateMap<TravelPackageDTO, TravelPackage>();

            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();

            CreateMap<TravelPackage, TravelPackageGetByIdDTO>();
            CreateMap<TravelPackageGetByIdDTO, TravelPackage>();

            CreateMap<Product, ProductGetByIdDTO>();
            CreateMap<ProductGetByIdDTO, Product>();

            CreateMap<Product, ProductPostDTO>();
            CreateMap<ProductPostDTO, Product>();

            CreateMap<Client, ClientPostDTO>();
            CreateMap<ClientPostDTO, Client>();

            CreateMap<TravelPackage, TravelPackagePostDTO>();
            CreateMap<TravelPackagePostDTO, TravelPackage>();

            CreateMap<Commission, CommissionDTO>();
            CreateMap<CommissionDTO, Commission>();

            CreateMap<CosmosClientModelPostPutDTO, CosmosClientModel>();
            CreateMap<CosmosClientModel, CosmosClientModelPostPutDTO>();

            CreateMap<CosmosClientModelDTO, CosmosClientModel>();
            CreateMap<CosmosClientModel, CosmosClientModelDTO>();
        }
    }
}
