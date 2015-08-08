using MetaNotes.Business.Services;
using MetaNotes.Core.Entities;
using MetaNotes.Internationalization.UI.Notes;
using MetaNotes.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MetaNotes.UI.Services
{
    public class NotesIndexModelBuilder
    {
        private readonly INotesService _notesService;
        private readonly IUserService _userService;

        public NotesIndexModelBuilder(INotesService notesService, IUserService userService)
        {
            _notesService = notesService;
            _userService = userService;
        }

        public async Task<NotesIndexModel> Build(Guid userId, NotesFilterModel arguments)
        {
            IQueryable<Note> notes;
            bool? isPublic = null;
            Guid? userIdFilter = null;
            var model = new NotesIndexModel { FilterModel = arguments };

            var user = await _userService.GetUser(userId);
            if (user == null)
                throw new NullReferenceException("user not found");

            model.IsAdmin = user.IsAdmin;
            userIdFilter = user.IsAdmin ? userIdFilter : userId;

            if (arguments.Type.HasValue)
                isPublic = arguments.Type == NotesTypeFilter.OnlyPublic ? true : false;

            notes = _notesService
                   .GetFilteredNotes(userIdFilter, isPublic, arguments.KeyPhrase);

            model.Data = notes.Select(x => new NoteTableModel
            {
                Id = x.Id,
                CreatingDate = x.CreatingDate,
                IsPublic = x.IsPublic,
                Title = x.Title,
                UserId = x.OwnerId
            });

            if (model.IsAdmin)
            {
                model.NotesTypeItems = GetList();
            }

            return model;
        }

        private IEnumerable<SelectListItem> GetList()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Selected = true, 
                    Text = NotesIndexUIResources.AllNotes, 
                    Value = NotesTypeFilter.All.ToString() 
                },
                new SelectListItem
                {
                    Text = NotesIndexUIResources.OnlyMyNotes, 
                    Value = NotesTypeFilter.OnlyMy.ToString()
                },
                new SelectListItem
                {
                    Text = NotesIndexUIResources.OnlyPublicNotes, 
                    Value = NotesTypeFilter.OnlyPublic.ToString()
                }
            };
        }
    }
}
