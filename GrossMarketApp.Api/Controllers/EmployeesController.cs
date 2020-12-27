using AutoMapper;
using GrossMarketApp.Api.Dtos;
using GrossMarketApp.Api.Dtos.Employees;
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
    public class EmployeesController : ControllerBase
    {
        private readonly IService<Employee> _service;
        private readonly IMapper _mapper;

        public EmployeesController(IService<Employee> service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeesAddDto employeesAddDto)
        {
            var employee = _mapper.Map<Employee>(employeesAddDto);

            var result = await _service.AddAsync(employee);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Created(string.Empty, employeesAddDto);
        }


        [HttpPost("save-all")]
        public async Task<IActionResult> CreateAll([FromBody] IEnumerable<EmployeesAddDto> employeesAddDtos)
        {
            var employees = _mapper.Map<IEnumerable<Employee>>(employeesAddDtos);

            var result = await _service.AddRangeAsync(employees);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Created(string.Empty, employeesAddDtos);
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

            return Ok(new EmployeeDto
            {
                Employee = result.Data,
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

            return Ok(new EmployeeListDto
            {
                Employees = result.Data,
                Message = ApiResultMessages.ResultMessage(true),
                ResultStatus = result.ResultStatus
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var employee = _service.GetByIdAsync(id).Result;

            var result = _service.Delete(employee.Data);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(ApiResultMessages.ResultMessage(true));
        }

        [HttpDelete("delete-all")]
        public IActionResult RemoveAll([FromBody] IEnumerable<EmployeeListDelete> employeeListDeletes)
        {
            var employeeList = _mapper.Map<IEnumerable<Employee>>(employeeListDeletes);

            var result = _service.DeleteRange(employeeList);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(ApiResultMessages.ResultMessage(true));
        }

        [HttpPut]
        public IActionResult Update([FromBody] EmployeeUpdateDto employeeUpdateDto)
        {
            var oldEmployee = _service.GetByIdAsync(employeeUpdateDto.Id).Result;

            var employeeUpdate = _mapper.Map<EmployeeUpdateDto, Employee>(employeeUpdateDto, oldEmployee.Data);

            var result = _service.Update(employeeUpdate);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(new EmployeeDto
            {
                Employee = result.Data,
                Message = ApiResultMessages.ResultMessage(true),
                ResultStatus = result.ResultStatus
            });
        }

        [HttpGet("search/{employeeName}")]
        public async Task<IActionResult> SearchName(string employeeName)
        {
            if (string.IsNullOrEmpty(employeeName)) return BadRequest();

            var result = await _service.SearchNameAsync(e => e.EmployeeName.Contains(employeeName));

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(new EmployeeListDto
            {
                Employees = result.Data,
                ResultStatus = result.ResultStatus,
                Message = ApiResultMessages.ResultMessage(true)
            });
        }
    }
}
