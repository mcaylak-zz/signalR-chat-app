using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract.Chat;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/chat")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private IChatService _chatService;
        private IUserService _userService;

        public ChatController(IChatService chatService, IUserService userService)
        {
            _chatService = chatService;
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var data = _userService.GetUsers();

            data.ForEach(x =>
            {
                x.Groups.ForEach(y =>
                {
                    y.User = null;
                    y.Group.Users = null;
                });
            });

            return Ok(data);
        }


        [HttpGet("GetUserMessages")]
        public IActionResult GetMessagesWithUsers(string toUser, string fromUser)
        {
            var data = _chatService.GetPrivateChatMessages(toUser, fromUser);
            return Ok(data);
        }

        [HttpGet("GetGroupMessages")]
        public IActionResult GetGroupMessages(string groupName)
        {
            var data = _chatService.GetGroupMessages(groupName);
            return Ok(data);
        }

        [HttpGet("GetUserGroups")]
        public IActionResult GetUserGroups(string username)
        {
            var data = _chatService.GetUserGroups(username);
            return Ok(data);
        }

        [HttpGet("saveUser")]
        public IActionResult SaveUser(string userName)
        {
            var user = _userService.findUser(userName) ?? _userService.SaveUser(userName);

            user.Groups?.ForEach(x =>
            {
                x.User = null;
                x.Group.Users = null;
            });

            return Ok(user);
        }

        [HttpGet("GetAllGroups")]
        public IActionResult GetAllGroups()
        {
            var data = _chatService.GetAllGroups();
            return Ok(data);
        }

        public class ResponseModel
        {
            public string Value { get; set; }
            public bool State { get; set; }
        }
    }
}