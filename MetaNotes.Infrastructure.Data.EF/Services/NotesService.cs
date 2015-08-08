using MetaNotes.Business.Services;
using MetaNotes.Core.Entities;
using MetaNotes.Core.Services;
using System;
using System.Linq;

namespace MetaNotes.Infrastructure.Data.EF
{
    public class NotesService : BaseService, INotesService
    {
        public NotesService(IUnitOfWork uow) : base(uow) { }

        public IQueryable<Note> GetFilteredNotes(Guid? userId, bool? isPublic, string keyPhrase)
        {
            var repository = UnitOfWork.GetRepository<Note>();
            return repository.Select()
                .NotDeleted()
                .FilterByOwnerId(userId)
                .FilterByIsPublic(isPublic)
                .FilterByKeyPhrase(keyPhrase)
                .OrderByDescending(x=>x.CreatingDate);                
        }
    }
}
