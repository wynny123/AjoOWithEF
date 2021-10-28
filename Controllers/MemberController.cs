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
    public class MemberController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public MemberController(IUnitOfWork unitOfWork , ILogger<MemberController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllMembers()
        {
            try
            {
                var members =  await _unitOfWork.Members.GetAll();
                var results = _mapper.Map<IList<MemberDTO>>(members);
                return Ok (results);

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the{ nameof(GetAllMembers)}");
                return StatusCode(500, "Internal Server Error, try again later");
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMember(int id)
        {
            try
            {
                var member = await _unitOfWork.Members.Get(q => q.Id == id, new List<string> { "Accounts","Loans" });
                var result = _mapper.Map<MemberDTO>(member);
                return Ok(result);

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the{ nameof(GetMember)}");
                return StatusCode(500, "Internal Server Error, try again later");
            }
        }

        //[HttpGet("{string: firstName}")]
        //public async Task<IActionResult> GetMember(string firstName)
        //{
        //    try
        //    {
        //        var member = await _unitOfWork.Members.Get(q => q.ToString == FirstName, new List<string> { "Accounts", "Loans" });
        //        var result = _mapper.Map<MemberDTO>(member);
        //        return Ok(result);

        //    }
        //    catch (Exception ex)
        //    {

        //        _logger.LogError(ex, $"Something went wrong in the{ nameof(GetMember)}");
        //        return StatusCode(500, "Internal Server Error, try again later");
        //    }
        //}
    }
}
