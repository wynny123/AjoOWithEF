using AjoOWithEF.Data;
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

        [HttpGet("{id:int}", Name = "GetMember")]
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

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateMember([FromBody] CreateMemberDTO memberDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Post attempt in the {nameof(CreateMember)}");
                return BadRequest(ModelState);
            }
            try
            {
                var member = _mapper.Map<Member>(memberDTO);
                await _unitOfWork.Members.Insert(member);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetMember", new { id = member.Id }, member);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(CreateMember)}");
                return StatusCode(500, "Internal Server Error, Please try again later");
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateMember(int id,[FromBody] UpdateMemberDTO memberDTO)
        {
            if(!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid Update attempt in the {nameof(UpdateMember)}");
                return BadRequest(ModelState);
            }
            try
            {
                var member = await _unitOfWork.Members.Get(q => q.Id == id);
                if(member == null)
                {
                    _logger.LogError($"Invalid Update attempt in the {nameof(UpdateMember)}");
                    return BadRequest("Submitted data is invalid");
                }
                _mapper.Map(memberDTO, member);
                _unitOfWork.Members.Update(member);
                await _unitOfWork.Save();
                return NoContent();

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(UpdateMember)}");
                return StatusCode(500, "Internal Server Error, Please try again later");
            } 

        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteMember(int id)
        {
            if  (id < 1)
            {
                _logger.LogError($"Invalid Delete attempt in the {nameof(DeleteMember)}");
                return BadRequest();
            }
            try
            {
                var member = await _unitOfWork.Members.Get(q => q.Id == id);
                if (member == null)
                {
                    _logger.LogError($"Invalid Delete attempt in the {nameof(DeleteMember)}");
                    return BadRequest("Submitted data is invalid");
                }
               
               await _unitOfWork.Members.Delete(id);
                await _unitOfWork.Save();
                return NoContent();

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(DeleteMember)}");
                return StatusCode(500, "Internal Server Error, Please try again later");
            }

        }

    }





}
