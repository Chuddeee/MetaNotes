﻿using MetaNotes.Core.Entities;
using MetaNotes.Core.Services;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MetaNotes.Infrastructure.Data.EF
{
    internal class NoteService : BaseService, INoteService
    {
        public NoteService(IUnitOfWork uow) : base(uow) { }

        public IQueryable<Note> GetFilteredNotes(Guid? userId, bool? isPublic, string keyPhrase)
        {
            var repository = UnitOfWork.GetRepository<Note>();
            return repository.Select()
                .NotDeleted()
                .FilterByOwnerId(userId)
                .FilterByIsPublic(isPublic)
                .FilterByKeyPhrase(keyPhrase)
                .OrderByDescending(x => x.CreatingDate);
        }

        public Task<Note> GetNote(int id)
        {
            var repository = UnitOfWork.GetRepository<Note>();
            return repository.Select(x => x.Id == id)
                .NotDeleted().FirstOrDefaultAsync();
        }
    }
}
