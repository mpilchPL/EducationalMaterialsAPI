using AutoMapper;
using EducationalMaterialsAPI.Data.DTOs.AuthorDtos;
using EducationalMaterialsAPI.Data.DTOs.EduMaterialDtos;
using EducationalMaterialsAPI.Data.DTOs.EduMaterialTypeDtos;
using EducationalMaterialsAPI.Data.DTOs.ReviewDtos;
using EducationalMaterialsAPI.Data.DTOs.UserDtos;
using EducationalMaterialsAPI.Model.Entities;
using EducationalMaterialsAPI.Model.User;

namespace EducationalMaterialsAPI.Data.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region EduMaterial maps
            CreateMap<EduMaterial, EduMaterialReadDto>();
            CreateMap<EduMaterialCreateDto, EduMaterial>();
            CreateMap<EduMaterialUpdateDto, EduMaterial>();
            CreateMap<EduMaterial, EduMaterialUpdateDto>();
            #endregion

            #region EduMaterialTypes maps
            CreateMap<EduMaterialType, EduMaterialTypeReadDto>();
            CreateMap<EduMaterialTypeCreateDto, EduMaterialType>();
            CreateMap<EduMaterialTypeUpdateDto, EduMaterialType>();
            CreateMap<EduMaterialType, EduMaterialTypeUpdateDto>();
            #endregion

            #region Authors maps
            CreateMap<Author, AuthorReadDto>();
            CreateMap<AuthorCreateDto, Author>();
            CreateMap<AuthorUpdateDto, Author>();
            CreateMap<Author, AuthorUpdateDto>();
            #endregion

            #region Reviews maps
            CreateMap<Review, ReviewReadDto>();
            CreateMap<ReviewCreateDto, Review>();
            CreateMap<ReviewUpdateDto, Review>();
            CreateMap<Review, ReviewUpdateDto>();
            #endregion

            #region Users maps
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
            #endregion
        }
    }
}
