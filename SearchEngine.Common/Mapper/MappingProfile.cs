using System.Security.Cryptography;
using SearchEngine.Model.DatabaseModels;
using SearchEngine.Common.DTOs;
using System.Text;
using AutoMapper;

namespace SearchEngine.BusinessLogic.Mapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			var hmac = new HMACSHA256();
			CreateMap<Browser, BrowserDto>().ReverseMap();
			CreateMap<Browser, RegisterDto>().ReverseMap()
				.ForMember("Login", opt => opt.MapFrom(ud => ud.Login.ToLower()))
				.ForMember("PasswordHash", opt => opt.MapFrom(ud => hmac.ComputeHash(Encoding.UTF8.GetBytes(ud.Password))))
				.ForMember("PasswordSalt", opt => opt.MapFrom(ud => hmac.Key));
		}
	}
}
