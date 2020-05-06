﻿using System;
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

        public IActionResult GetMessagesWithUsers(string toUser,string fromUser)
        {
            var data = _chatService.GetMessagesWithUsers(toUser, fromUser);
            return Ok(data);
        }

        public IActionResult GetGroupMessages(string groupName)
        {
            var data = _chatService.GetGroupsMessage(groupName);
            return Ok(data);
        }

        [HttpPost("saveUser")]
        public IActionResult SaveUser(string userName)
        {
            _userService.SaveUser(userName);
            return Ok(userName + " save in database");
        }
    }
}