using System.IdentityModel.Tokens.Jwt;
using IdentityServer4.Extensions;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using ToDoAPI.Services;
using Models;
using Models.ToDoList;
using MongoDB.Bson;
using ToDoAPI.Errors;

namespace ToDoAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;
    using Client.Models.Errors;
    using Client.Models.ToDoList;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Models.Converters.ToDoList;
    using ToDoAPI.Configuration;

    [Authorize]
    [Route("v1/todo")]
    public sealed class ToDoController : Controller
    {
        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> SearchUserToDoListAsync(string userId)
        {
            var UserIdfromTokken = HttpContext.User.FindFirst(p => p.Type == "sub").Value;
            
            if (UserIdfromTokken == null || userId != UserIdfromTokken)
            {
                var error = ServiceErrorResponses.AuthIsNotConfirmed("Unauthorized request");
            }

            var todoServ = new ToDoService(UserIdfromTokken);

            var todoIdGet = todoServ.Get();

            if (todoIdGet.IsNullOrEmpty())
            {
                var error = ServiceErrorResponses.ToDoNotFound("this user");
                return this.NotFound(error);
            }

            return this.Ok(todoIdGet);
        }

        [HttpGet]
        [Route("{userId}/{todoId}")]
        public async Task<IActionResult> GetToDoAsync(string userId, string todoId)
        {
            var UserIdfromTokken = HttpContext.User.FindFirst(p => p.Type == "sub").Value;

            if (UserIdfromTokken == null || userId != UserIdfromTokken)
            {
                var error = ServiceErrorResponses.AuthIsNotConfirmed("Unauthorized request");
            }

            var todoServ = new ToDoService(UserIdfromTokken);

            if (!int.TryParse(todoId, out var ToDoIdCheck))
            {
                var error = ServiceErrorResponses.ToDoNotFound(todoId);
                return this.NotFound(error);
            }

            var todoIdGet = todoServ.Get(ToDoIdCheck);

            if (todoIdGet == null)
            {
                var error = ServiceErrorResponses.ToDoNotFound(todoId);
                return this.NotFound(error);
            }

            return this.Ok(todoIdGet);
        }

        [HttpPost]
        [Route("{userId}")]
        public async Task<IActionResult> CreateToDoAsync([FromRoute] string userId, [FromBody]ToDoBuildInfo todoNewInfo)
        {
            var UserIdfromTokken = HttpContext.User.FindFirst(p => p.Type == "sub").Value;

            if (UserIdfromTokken == null || userId != UserIdfromTokken)
            {
                var error = ServiceErrorResponses.AuthIsNotConfirmed("Unauthorized request");
            }

            var todoServ = new ToDoService(UserIdfromTokken);

            var creationInfo = ToDoBuildInfoConverter.Convert(userId, todoNewInfo);

            if (todoNewInfo == null)
            {
                throw new ArgumentNullException(nameof(todoNewInfo));
            }

            var id = todoServ.Get().Count + 1;
            var timeAtJustMoment = DateTime.UtcNow;

            var todoNew = new Models.ToDoList.ToDo
            {
                Id = id,
                UserId = userId,
                IsDone = false,
                Text = creationInfo.Text,
                CreatedAt = timeAtJustMoment,
                LastUpdatedAt = timeAtJustMoment
            };

            var clientToDoInfo = ToDoInfoConverter.Convert(todoNew);
            todoServ.Create(todoNew);

            return this.Ok($"Created at route: v1/todo/{userId}/{id}");
        }

        [HttpPut]
        [Route("{userId}/{todoId}")]
        public async Task<IActionResult> PutToDoAsync([FromRoute] string userId, string todoId, [FromBody]ToDoUpdateInfo updInfo)
        {
            var UserIdfromTokken = HttpContext.User.FindFirst(p => p.Type == "sub").Value;

            if (UserIdfromTokken == null || userId != UserIdfromTokken)
            {
                var error = ServiceErrorResponses.AuthIsNotConfirmed("Unauthorized request");
            }

            var todoServ = new ToDoService(UserIdfromTokken);

            if (!int.TryParse(todoId, out var ToDoIdCheck))
            {
                var error = ServiceErrorResponses.ToDoNotFound(todoId);
                return this.NotFound(error);
            }

            var todoIdPut = todoServ.Get(ToDoIdCheck);

            if (todoIdPut == null)
            {
                var error = ServiceErrorResponses.ToDoNotFound(todoId);
                return this.NotFound(error);
            }

            todoIdPut.Text = updInfo.Text;

            if (updInfo.IsDone == null)
            {
                todoIdPut.IsDone = false;
            }

            todoIdPut.LastUpdatedAt = DateTime.UtcNow;

            todoServ.Update(ToDoIdCheck, todoIdPut);

            var clientToDo = ToDoConverter.Convert(todoIdPut);
            return this.Ok(clientToDo);
        }

        [HttpPatch]
        [Route("{userId}/{todoId}")]
        public async Task<IActionResult> PatchToDoAsync([FromRoute] string userId, string todoId, [FromBody]ToDoUpdateInfo updInfo)
        {
            var UserIdfromTokken = HttpContext.User.FindFirst(p => p.Type == "sub").Value;

            if (UserIdfromTokken == null || userId != UserIdfromTokken)
            {
                var error = ServiceErrorResponses.AuthIsNotConfirmed("Unauthorized request");
            }

            var todoServ = new ToDoService(UserIdfromTokken);

            if (!int.TryParse(todoId, out var ToDoIdCheck))
            {
                var error = ServiceErrorResponses.ToDoNotFound(todoId);
                return this.NotFound(error);
            }

            var todoIdPatch = todoServ.Get(ToDoIdCheck);

            if (todoIdPatch == null)
            {
                var error = ServiceErrorResponses.ToDoNotFound(todoId);
                return this.NotFound(error);
            }

            var updated = false;

            if (updInfo.Text != null)
            {
                todoIdPatch.Text = updInfo.Text;
                updated = true;
            }

            if (updInfo.IsDone != null)
            {
                todoIdPatch.IsDone = updInfo.IsDone.Value;
                updated = true;
            }

            if (!updated)
            {
                var error = ServiceErrorResponses.BodyIsMissingOrUncorrect(updInfo.ToString());
                return this.BadRequest(error);
            }

            todoIdPatch.LastUpdatedAt = DateTime.UtcNow;

            todoServ.Update(ToDoIdCheck, todoIdPatch);

            var clientToDo = ToDoConverter.Convert(todoIdPatch);
            return this.Ok(clientToDo);
        }


        [HttpDelete]
        [Route("{userId}/{todoId}")]
        public async Task<IActionResult> DeleteToDoAsync(string userId, string todoId)
        {
            var UserIdfromTokken = HttpContext.User.FindFirst(p => p.Type == "sub").Value;

            if (UserIdfromTokken == null || userId != UserIdfromTokken)
            {
                var error = ServiceErrorResponses.AuthIsNotConfirmed("Unauthorized request");
            }

            var todoServ = new ToDoService(UserIdfromTokken);

            if (!int.TryParse(todoId, out var ToDoIdCheck))
            {
                var error = ServiceErrorResponses.ToDoNotFound(todoId);
                return this.NotFound(error);
            }

            var todoIdPatch = todoServ.Get(ToDoIdCheck);

            if (todoIdPatch == null)
            {
                var error = ServiceErrorResponses.ToDoNotFound(todoId);
                return this.NotFound(error);
            }

            todoServ.Remove(todoIdPatch);
            return this.NoContent();
        }
    }
}
