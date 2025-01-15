using Application.Core;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Persistence;

namespace Application.Photos
{
    public class Add
    {
        public class Command : IRequest<Result<Photo>>
        {
            public required Guid AnimeId { get; set; }
            public required IFormFile File { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Photo>>
        {
            private readonly DataContext _context;
            private readonly IPhotoAccessor _photoAccessor;

            public Handler(DataContext context, IPhotoAccessor photoAccessor)
            {
                _context = context;
                _photoAccessor = photoAccessor;
            }

            public async Task<Result<Photo>> Handle(Command request, CancellationToken cancellationToken)
            {
                var anime = await _context.Animes.FindAsync(request.AnimeId);

                if (anime == null)
                {
                    return Result<Photo>.Failure($"Anime with id: {request.AnimeId} was not found.");
                }

                var photoUploadResult = await _photoAccessor.AddPhoto(request.File);

                var photo = new Photo
                {
                    Url = photoUploadResult.Url,
                    Id = photoUploadResult.PublicId
                };

                if (!anime.Photos.Any(x => x.IsMain)) photo.IsMain = true;

                anime.Photos.Add(photo);

                await _context.SaveChangesAsync();

                return Result<Photo>.Success(photo);
            }
        }
    }
}