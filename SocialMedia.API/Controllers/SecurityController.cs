﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.API.Responses;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System.Threading.Tasks;

namespace SocialMedia.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IMapper _mapper;

        public SecurityController(ISecurityService securityService, IMapper mapper)
        {
            _securityService = securityService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(SecurityDto securityDto)
        {
            var security = _mapper.Map<Security>(securityDto);
            await _securityService.RegisterUser(security);

            securityDto = _mapper.Map<SecurityDto>(security);
            var response = new ApiResponse<SecurityDto>(securityDto);

            return Ok(response);
        }

    }
}
