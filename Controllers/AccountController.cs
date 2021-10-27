using AjoOWithEF.IRepository;
using AjoOWithEF.Models;
using AutoMapper;
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

        [HttpGet("{id:int}")]
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
    }
}

