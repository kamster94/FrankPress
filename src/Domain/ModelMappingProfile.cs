using AutoMapper;

namespace FrankPress.Domain
{
    public class ModelMappingProfile : Profile
    {
        public ModelMappingProfile()
        {
            //Data Model -> Domain Model
            CreateMap<DataAccess.DataModels.Role, Domain.DomainModels.Role>();
            CreateMap<DataAccess.DataModels.IdentityProvider, Domain.DomainModels.IdentityProvider>();
            CreateMap<DataAccess.DataModels.User, Domain.DomainModels.User>();

            //Domain Model -> Data Model
            CreateMap<Domain.DomainModels.Role, DataAccess.DataModels.Role>();
            CreateMap<Domain.DomainModels.IdentityProvider, DataAccess.DataModels.IdentityProvider>();
        }
    }
}
