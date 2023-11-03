namespace PhotoGallery_BackEnd.Mapper
{
    public class AutoMapperProfilecs : Profile
    {
        public AutoMapperProfilecs()
        {
            /*            CreateMap<TaskModel, ViewTaskDTO>()
                            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                            .ForMember(dest => dest.taskid, opt => opt.MapFrom(src => src.taskid))
                            .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.status));

                        CreateMap<RP_LD_WorkToListByResource, WorkToListByResource_DTO>();
                        CreateMap<RP_LD_LateOrders, LateOrders_DTO>();
                        CreateMap<RP_LD_MaterialUsage, MaterialUsage_DTO>();
                        CreateMap<RP_LD_ApPlan, ApPlan_DTO>();
                        CreateMap<TaskModel, ViewTaskDTO>();
                        CreateMap<TaskReviewData, TaskReviewDataDTO>();
                        CreateMap<TaskSchedule, ViewTaskScheduleDTO>();
            */
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.username, opt => opt.MapFrom(src => src.username))
                .ForMember(dest => dest.userAccessLevelid, opt => opt.MapFrom(src => src.userAccessLevelid))
                .ForMember(dest => dest.roles, opt => opt.MapFrom(src => src.userAccessLevels.accessLevelName));
        }
    }
}
