using AutoMapper;
using CargoService.Application.DTOs.Bids;
using CargoService.Application.DTOs.Fleets;
using CargoService.Application.DTOs.Loads;
using CargoService.Application.DTOs.Trips;
using CargoService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoService.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile() { 
            CreateMap<Load, LoadAddDto>().ReverseMap();
            CreateMap<Load, LoadResponseDto>();
            CreateMap<Bid, BidAddDto>().ReverseMap();
            CreateMap<Bid, BidResponseDto>();
            CreateMap<Fleet, FleetAddDto>().ReverseMap();
            CreateMap<Fleet, FleetResponseDto>();
            CreateMap<Trip, TripAddDto>().ReverseMap();
            CreateMap<Trip, TripResponseDto>();
        }
    }
}
