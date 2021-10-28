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
    public class LoanController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public LoanController(IUnitOfWork unitOfWork, ILogger<LoanController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllLoans()
        {
            try
            {
                var loans = await _unitOfWork.Loans.GetAll();
                var results = _mapper.Map<IList<LoanDTO>>(loans);
                return Ok(results);

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the{ nameof(GetAllLoans)}");
                return StatusCode(500, "Internal Server Error, try again later");
            }
        }
        [Authorize]
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLoan(int id)
        {
            try
            {
                var loan = await _unitOfWork.Loans.Get(q => q.Id == id, new List<string> { "Member" });
                var result = _mapper.Map<LoanDTO>(loan);
                return Ok(result);

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the{ nameof(GetLoan)}");
                return StatusCode(500, "Internal Server Error, try again later");
            }
        }
    }
}
