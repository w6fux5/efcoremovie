using AutoMapper;
using EFCoreMovie.Dtos.Actor;
using EFCoreMovie.Dtos.Cinema;
using EFCoreMovie.Dtos.CinemaHall;
using EFCoreMovie.Dtos.CinemaOffer;
using EFCoreMovie.Dtos.Genre;
using EFCoreMovie.Dtos.Movie;
using EFCoreMovie.Entities;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace EFCoreMovie;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {

        var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

        CreateMap<ActorEntity, ActorDTO>();


        CreateMap<CreateCinemaDTO, CinemaEntity>().ForMember(entity => entity.Location,
            dto => dto.MapFrom(prop => geometryFactory.CreatePoint(new Coordinate(prop.Longitude, prop.Lattitude))));

        CreateMap<CinemaEntity, CinemaDTO>()
            .ForMember(dto => dto.Latitude, entity => entity.MapFrom(p => p.Location.Y))
            .ForMember(dto => dto.Longitude, entity => entity.MapFrom(p => p.Location.X));


        CreateMap<CreateCinemaOfferDTO, CinemaOfferEntity>();

        CreateMap<CreateCinemaHallDTO, CinemaHallEntity>();


        CreateMap<GenreEntity, GenreDTO>();
        CreateMap<CreateGenresDTO, GenreEntity>();



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
                    p.MovieActors
                        .Select(ma => ma.Actor)));



        CreateMap<CreateMovieDTO, MovieEntity>()
            .ForMember(entity => entity.Genres, dto => dto.MapFrom(prop => prop.GenresIds.Select(id => new GenreEntity { Id = id })))
            .ForMember(entity => entity.CinemaHalls, dto => dto.MapFrom(prop => prop.CinemaHallsIds.Select(id => new CinemaHallEntity { Id = id })))
            ;

        CreateMap<CreateMovieActorDTO, MovieActorEntity>();


        CreateMap<CreateActorDTO, ActorEntity>();




    }
}
