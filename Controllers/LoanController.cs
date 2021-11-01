using AjoOWithEF.Data;
using AjoOWithEF.IRepository;
using AjoOWithEF.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            
            
                var loan = await _unitOfWork.Loans.Get(q => q.Id == id, include: q => q.Include(X => X.Member));
                var result = _mapper.Map<LoanDTO>(loan);
                return Ok(result);

           
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateLoan([FromBody] CreateLoanDTO loanDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Post attempt in the {nameof(CreateLoan)}");
                return BadRequest(ModelState);
            }
            
                var loan = _mapper.Map<Loan>(loanDTO);
                await _unitOfWork.Loans.Insert(loan);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetLoan", new { id = loan.Id }, loan);
           
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateLoan(int id, [FromBody] UpdateLoanDTO loanDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid Update attempt in the {nameof(UpdateLoan)}");
                return BadRequest(ModelState);
            }
            
                var loan = await _unitOfWork.Loans.Get(q => q.Id == id);
                if (loan == null)
                {
                    _logger.LogError($"Invalid Update attempt in the {nameof(UpdateLoan)}");
                    return BadRequest("Submitted data is invalid");
                }
                _mapper.Map(loanDTO, loan);
                _unitOfWork.Loans.Update(loan);
                await _unitOfWork.Save();
                return NoContent();

           


        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteLoan(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid Delete attempt in the {nameof(DeleteLoan)}");
                return BadRequest();
            }
            
            
                var loan = await _unitOfWork.Loans.Get(q => q.Id == id);
                if (loan == null)
                {
                    _logger.LogError($"Invalid Delete attempt in the {nameof(DeleteLoan)}");
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.Loans.Delete(id);
                await _unitOfWork.Save();
                return NoContent();

            

        }
    }
}
