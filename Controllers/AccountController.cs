﻿using AjoOWithEF.Data;
using AjoOWithEF.IRepository;
using AjoOWithEF.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjoOWithEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public AccountController(IUnitOfWork unitOfWork, ILogger<AccountController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAccounts()
        {
            try
            {
                var accounts = await _unitOfWork.Accounts.GetAll();
                var results = _mapper.Map<IList<AccountDTO>>(accounts);
                return Ok(results);

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the{ nameof(GetAllAccounts)}");
                return StatusCode(500, "Internal Server Error, try again later");
            }
        }
        [Authorize]
        [HttpGet("{id:int}", Name = "GetAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAccount(int id)
        {
            try
            {
                var account = await _unitOfWork.Accounts.Get(q => q.Id == id, new List<string> { "Member" });
                var result = _mapper.Map<AccountDTO>(account);
                return Ok(result);

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the{ nameof(GetAccount)}");
                return StatusCode(500, "Internal Server Error, try again later");
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountDTO accountDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Post attempt in the {nameof(CreateAccount)}");
                return BadRequest(ModelState);
            }
            try
            {
                var account = _mapper.Map<Account>(accountDTO);
                await _unitOfWork.Accounts.Insert(account);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetAccount", new { id = account.Id }, account);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(CreateAccount)}");
                return StatusCode(500, "Internal Server Error, Please try again later");
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAccount(int id, [FromBody] UpdateAccountDTO accountDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid Update attempt in the {nameof(UpdateAccount)}");
                return BadRequest(ModelState);
            }
            try
            {
                var account = await _unitOfWork.Accounts.Get(q => q.Id == id);
                if (account == null)
                {
                    _logger.LogError($"Invalid Update attempt in the {nameof(UpdateAccount)}");
                    return BadRequest("Submitted data is invalid");
                }
                _mapper.Map(accountDTO, account);
                _unitOfWork.Accounts.Update(account);
                await _unitOfWork.Save();
                return NoContent();

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(UpdateAccount)}");
                return StatusCode(500, "Internal Server Error, Please try again later");
            }

        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid Delete attempt in the {nameof(DeleteAccount)}");
                return BadRequest();
            }
            try
            {
                var account = await _unitOfWork.Accounts.Get(q => q.Id == id);
                if (account == null)
                {
                    _logger.LogError($"Invalid Delete attempt in the {nameof(DeleteAccount)}");
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.Accounts.Delete(id);
                await _unitOfWork.Save();
                return NoContent();

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(DeleteAccount)}");
                return StatusCode(500, "Internal Server Error, Please try again later");
            }

        }
    }
}

