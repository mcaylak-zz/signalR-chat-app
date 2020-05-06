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


        [HttpGet("GetUserMessages")]
        public IActionResult GetMessagesWithUsers(string toUser,string fromUser)
        {
            var data = _chatService.GetMessagesWithUsers(toUser, fromUser);
            return Ok(data);
        }

        [HttpGet("GetGroupMessages")]
        public IActionResult GetGroupMessages(string groupName)
        {
            var data = _chatService.GetGroupMessages(groupName);
            return Ok(data);
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
            {
            var data = _chatService.GetAllUsers();
            return Ok(data);
        }

        [HttpGet("saveUser")]
        public IActionResult SaveUser(string userName)
        {
            _userService.SaveUser(userName);
            var data = new ResponseModel
            {
                State = true,
                Value = userName
            };

            return Ok(data);
        }

        public class ResponseModel
        {
            public string Value { get; set; }
            public bool State  { get; set; }
        }
    }
}