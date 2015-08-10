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
        private readonly INoteService _notesService;
        private readonly IUserService _userService;

        public NotesIndexModelBuilder(INoteService notesService, IUserService userService)
        {
            _notesService = notesService;
            _userService = userService;
        }

        public async Task<NotesIndexModel> Build(Guid userId, NotesFilterModel arguments)
        {
            if (arguments == null)
                throw new ArgumentNullException();

            var user = await _userService.GetUser(userId);
            if (user == null)
                throw new ModelBuilderException("user not found");

            IQueryable<Note> notes;
            Guid? userIdFilter = null;
            var model = new NotesIndexModel 
            { 
                Filter = arguments,
                IsAdmin = user.IsAdmin
            };

            userIdFilter = user.IsAdmin ? userIdFilter : userId;          

            notes = _notesService
                   .GetFilteredNotes(userIdFilter, arguments.IsPublic, arguments.KeyPhrase);

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
                model.PublicDropDownList = GetList();
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
                    Value = null
                },
                new SelectListItem
                {
                    Text = NotesIndexUIResources.OnlyPublic, 
                    Value = true.ToString()
                },
                new SelectListItem
                {
                    Text = NotesIndexUIResources.OnlyNotPublic, 
                    Value = false.ToString()
                }
            };
        }
    }
}
