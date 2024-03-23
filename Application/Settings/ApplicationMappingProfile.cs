﻿using Application.Dtos.User;
using AutoMapper;
using Domain.Entities;

namespace Application.Settings;

public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        CreateMap<RegisterDto, User>();
        CreateMap<AuthenticationRequest, User>();
    }
}
