﻿using Microsoft.AspNetCore.Authorization;
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
        public IActionResult Add([FromBody]CommentCreateModel commentCreateModel)
        {
            var userId = int.Parse(User.FindFirst("Id").Value);

            var response = _commentsService.Add(commentCreateModel.Comment, commentCreateModel.MovieId, userId);
            if (response.IsSuccessful)
            {
                //return RedirectToAction("Details", "Movies", new { id = commentCreateModel.MovieId });
                return Ok(response);
            }
            else
            {
                return RedirectToAction("ActionNonSuccessful", "Info", new { Message = response.Message });
            }

        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var comment = _commentsService.GetById(id);

            if (comment == null)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }

            if ((comment.UserId != int.Parse(User.FindFirst("Id").Value))  && (User.FindFirst("IsAdmin").Value == "False"))
            {
                return RedirectToAction("AccessDenied", "Auth");
            }

            _commentsService.Delete(comment);

            return RedirectToAction("Details", "Movies", new { id = comment.MovieId });
        }
    }
}
