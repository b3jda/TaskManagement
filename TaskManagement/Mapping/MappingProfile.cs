using System;
using AutoMapper;
using TaskManagement.DTOs;

namespace TaskManagement.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<TaskDTO, Models.Task>();
            CreateMap<Models.Task, TaskDTO>();
        }
    }
}

