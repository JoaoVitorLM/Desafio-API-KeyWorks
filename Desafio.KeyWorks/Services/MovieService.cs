using Desafio.KeyWorks.Context;
using Desafio.KeyWorks.Models;
using Desafio.KeyWorks.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Desafio.KeyWorks.Services
{
    public class MovieService : BaseService
    {
        private StreamingService _streamingService;
        public MovieService(AppDbContext context, StreamingService streamingService) : base(context)
        {
            _streamingService = streamingService;
        }
        public List<Movie> Get()
        {
            var movies = context.Movies
                 .Include(m => m.Streamings)
                 .Include(m => m.Rates)
                 .ToList();

            return movies
                 .Select(m => new Movie(m))
                 .ToList();
        }

        public Movie GetById(int id)
        {
            Movie movie = context.Movies
                .Include(movie => movie.Rates)
                 .Include(movie => movie.Streamings)
                .FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                throw new Exception("Movie não encontrado");
            }

            return movie;
        }

        public List<GroupDto> GetByGroup(string category = "")
        {
            var movies = Get();

            List<GroupDto> groups = new();

            movies.ForEach(m =>
            {
                GroupDto group = groups.FirstOrDefault(gm => gm.Category == m.Category);
                if (group == null)
                {
                    GroupDto newGroup = new(m.Category);
                    newGroup.Movies.Add(m);
                    groups.Add(newGroup);
                }
                else
                {
                    group.Movies.Add(m);
                }
            });

            if (string.IsNullOrWhiteSpace(category))
                return groups
                    .Where(g => g.Category == category)
                    .ToList();

            return groups;
        }

        public MovieByYearDto GetByYear(int year)
        {
            var movies = context.Movies
                .Include(m => m.Streamings)
                .Include(m => m.Rates)
                .Where(m => m.Release.Year == year)
                .ToList();

            var moviesByYear = movies
                 .Select(m => new Movie(m))
                 .ToList();

            return new MovieByYearDto(moviesByYear);
        }

        public List<Movie> GetByRate(int rate)
        {
            var movies = context.Movies
               .Include(m => m.Streamings)
               .Include(m => m.Rates)
               .Where(m => m.AverageRate == rate)
               .ToList();

            return movies;
        }

        public AverageByGroupDto GetAverageByCategory(string category, int release)
        {
            var movies = GetByGroup(category);
            var result = movies
                .SelectMany(m => m.Movies
                    .Where(movie => movie.Release.Year == release)
                    .ToList())
                .ToList();

            return new AverageByGroupDto
            {
                Movies = result,
                Average = result.Select(m => m.AverageRate).Sum() / result.Count
            };
        }

        public Movie AddRate(AddMovieRateDto dto)
        {
            Movie movie = GetById(dto.MovieId);
            Rate newRate = new(dto, movie);
            movie.Rates.Add(newRate);
            context.SaveChanges();

            return new Movie(movie);
        }

        public Movie Create(CreateMovieDto dto)
        {
            List<Streaming> streamings = dto.StreamingsIds.Select(id => _streamingService.GetById(id)).ToList();
            Movie newMovie = new(dto, streamings);
            context.Movies.Add(newMovie);
            context.SaveChanges();
            return newMovie;
        }

        public Movie Update(UpdateMovieDto dto)
        {
            Movie movie = GetById(dto.Id);
            List<Streaming> streamings = dto.StreamingsId.Select(id => _streamingService.GetById(id)).ToList();
            movie.Title = dto.Title;
            movie.Category = dto.Category;
            movie.Streamings = streamings;
            movie.Release = dto.Release;
            context.SaveChanges();
            return movie;
        }

        public void Delete(int id)
        {
            Movie movie = GetById(id);
            context.Movies.Remove(movie);
            context.SaveChanges();
        }
    }
}
