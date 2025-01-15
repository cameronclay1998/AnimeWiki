using Application.Core;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Photos
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public required Guid AnimeId { get; set; }
            public required string PhotoId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IPhotoAccessor _photoAccessor;

            public Handler(DataContext context, IPhotoAccessor photoAccessor)
            {
                _context = context;
                _photoAccessor = photoAccessor;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var anime = await _context.Animes
                    .Include(x => x.Photos)
                    .SingleOrDefaultAsync(x => x.Id == request.AnimeId);

                if (anime == null)
                {
                    return Result<Unit>.Failure($"Anime with Id: {request.AnimeId} was not found.");
                }

                var photo = anime.Photos.SingleOrDefault(x => x.Id == request.PhotoId);

                if (photo == null)
                {
                    return Result<Unit>.Failure($"Anime with Id: {request.AnimeId} does" 
                        + $" not contain the photo with Id: {request.PhotoId}.");
                }

                if (photo.IsMain) 
                {
                    return Result<Unit>.Failure("You cannot delete "
                    + "the anime's main photo. You must change it instead.");
                }

                await _photoAccessor.DeletePhoto(photo.Id);

                anime.Photos.Remove(photo);

                await _context.SaveChangesAsync();

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}