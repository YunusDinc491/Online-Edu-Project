using AutoMapper;
using OnlineEdu.DTO.DTOS.MessageDTOS;
using OnlineEdu.DTO.DTOS.Subscriber_DTOS;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class SubscriberMapping : Profile
    {
        public SubscriberMapping()
        {
            CreateMap<CreateSubscriberDto, Subscriber>().ReverseMap();
            CreateMap<UpdateSubscriberDto , Subscriber>().ReverseMap();
        }
    }
}
