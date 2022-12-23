using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

public class ServiceProfileTRansaction : Profile
{
 public ServiceProfileTRansaction()
 {
 CreateMap<AddTransaction, Transaction>()

 .ForMember(x=>x.AcountId,t=>t.MapFrom(x=>x.AccountId));

 CreateMap<Transaction,GetTransaction>();


CreateMap<AddTopUpBalanceDto, GetTopUpBalanceDto>().ReverseMap();

 CreateMap<Transaction,GetTopUpBalanceDto>().ReverseMap();

CreateMap<Transaction, AddTopUpBalanceDto>().ReverseMap();

 }
}