using AutoMapper;
using GrossMarketApp.Api.Dtos;
using GrossMarketApp.Api.Dtos.MemberCustomers;
using GrossMarketApp.Api.Messages;
using GrossMarketApp.Core.Abstract.Services;
using GrossMarketApp.Core.Concrete.Entities;
using GrossMarketApp.Core.Concrete.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrossMarketApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberCustomersController : ControllerBase
    {
        private readonly IService<MemberCustomer> _service;
        private readonly IMapper _mapper;

        public MemberCustomersController(IService<MemberCustomer> service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MemberCustomersAddDto memberCustomersAddDto)
        {
            var memberCustomer = _mapper.Map<MemberCustomer>(memberCustomersAddDto);

            var result = await _service.AddAsync(memberCustomer);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Created(string.Empty, memberCustomersAddDto);
        }


        [HttpPost("save-all")]
        public async Task<IActionResult> CreateAll([FromBody] IEnumerable<MemberCustomersAddDto> memberCustomersAddDto)
        {
            var memberCustomers = _mapper.Map<IEnumerable<MemberCustomer>>(memberCustomersAddDto);

            var result = await _service.AddRangeAsync(memberCustomers);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Created(string.Empty, memberCustomersAddDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(new MemberCustomerDto
            {
                MemberCustomer = result.Data,
                Message = ApiResultMessages.ResultMessage(true),
                ResultStatus = result.ResultStatus
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(new MemberCustomerListDto
            {
                MemberCustomers = result.Data,
                Message = ApiResultMessages.ResultMessage(true),
                ResultStatus = result.ResultStatus
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var memberCustomer = _service.GetByIdAsync(id).Result;

            var result = _service.Delete(memberCustomer.Data);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(ApiResultMessages.ResultMessage(true));
        }

        [HttpDelete("delete-all")]
        public IActionResult RemoveAll([FromBody] IEnumerable<MemberCustomerListDelete> memberCustomers)
        {
            var memberCustomerList = _mapper.Map<IEnumerable<MemberCustomer>>(memberCustomers);

            var result = _service.DeleteRange(memberCustomerList);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(ApiResultMessages.ResultMessage(true));
        }

        [HttpPut]
        public IActionResult Update([FromBody] MemberCustomerUpdateDto memberCustomerUpdateDto)
        {
            var oldMemberCustomer = _service.GetByIdAsync(memberCustomerUpdateDto.Id).Result;

            var memberCustomerUpdate = _mapper.Map<MemberCustomerUpdateDto, MemberCustomer>(memberCustomerUpdateDto, oldMemberCustomer.Data);

            var result = _service.Update(memberCustomerUpdate);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(new MemberCustomerDto
            {
                MemberCustomer = result.Data,
                Message = ApiResultMessages.ResultMessage(true),
                ResultStatus = result.ResultStatus
            });
        }

        [HttpGet("search/{memberCustomerName}")]
        public async Task<IActionResult> SearchName(string memberCustomerName)
        {
            if (string.IsNullOrEmpty(memberCustomerName)) return BadRequest();

            var result = await _service.SearchNameAsync(m => m.MemberCustomerName.Contains(memberCustomerName));

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(new MemberCustomerListDto
            {
                MemberCustomers = result.Data,
                ResultStatus = result.ResultStatus,
                Message = ApiResultMessages.ResultMessage(true)
            });
        }
    }
}
