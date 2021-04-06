using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Controllers
{
    public class CommentsController : Controller
    {
        private ICommentsService _commentsService;
        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(CommentCreateModel commentCreateModel)
        {
            var userId = int.Parse(User.FindFirst("Id").Value);

            var response = _commentsService.Add(commentCreateModel.Comment, commentCreateModel.MovieId, userId);
            if (response.IsSuccessful)
            {
                return RedirectToAction("Details", "Movies", new { id = commentCreateModel.MovieId });
            }
            else
            {
                return RedirectToAction("ActionNonSuccessful", "Info", new { Message = response.Message });
            }

            
        }
    }
}
