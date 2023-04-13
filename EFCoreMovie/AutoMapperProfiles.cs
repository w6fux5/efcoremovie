﻿using AutoMapper;
using EFCoreMovie.Dtos;
using EFCoreMovie.Entities;

namespace EFCoreMovie;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<ActorEntity, ActorDTO>();

        CreateMap<CinemaEntity, CinemaDTO>()
            .ForMember(dto => dto.Latitude, entity => entity.MapFrom(p => p.Location.Y))
            .ForMember(dto => dto.Longitude, entity => entity.MapFrom(p => p.Location.X));


        CreateMap<GenreEntity, GenreDTO>();

        CreateMap<MovieEntity, MovieDTO>()
            .ForMember(dto => dto.Genres, entity =>
                entity.MapFrom(p =>
                    p.Genres
                        .OrderByDescending(g => g.Name)))

            .ForMember(dto => dto.Cinemas, entity =>
                entity.MapFrom(p =>
                    p.CinemaHalls
                        .OrderByDescending(ch => ch.Cinema.Name)
                        .Select(ch => ch.Cinema)))

            .ForMember(dto => dto.Actors, entity =>
                entity.MapFrom(p =>
                    p.MoviesActors
                        .Select(ma => ma.Actor)));
    }
}
