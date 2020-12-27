using AutoMapper;
using GrossMarketApp.Api.Dtos;
using GrossMarketApp.Api.Dtos.Suppliers;
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
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public SuppliersController(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService ?? throw new ArgumentNullException(nameof(supplierService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SupplierAddDto supplierAddDto)
        {
            var supplier = _mapper.Map<Supplier>(supplierAddDto);

            var result = await _supplierService.AddAsync(supplier);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Created(string.Empty, supplierAddDto);
        }

        [HttpPost("save-all")]
        public async Task<IActionResult> CreateAll([FromBody] IEnumerable<SupplierAddDto> supplierAddDto)
        {
            var suppliers = _mapper.Map<IEnumerable<Supplier>>(supplierAddDto);

            var result = await _supplierService.AddRangeAsync(suppliers);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Created(string.Empty, supplierAddDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _supplierService.GetByIdAsync(id);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(new SupplierDto
            {
                Supplier = result.Data,
                Message = ApiResultMessages.ResultMessage(true),
                ResultStatus = result.ResultStatus
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _supplierService.GetAllAsync();

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(new SupplierListDto
            {
                Suppliers = result.Data,
                Message = ApiResultMessages.ResultMessage(true),
                ResultStatus = result.ResultStatus
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var supplier = _supplierService.GetByIdAsync(id).Result;

            var result = _supplierService.Delete(supplier.Data);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(ApiResultMessages.ResultMessage(true));
        }

        [HttpDelete("delete-all")]
        public IActionResult RemoveAll([FromBody] IEnumerable<SupplierListDelete> suppliers)
        {
            var supplierList = _mapper.Map<IEnumerable<Supplier>>(suppliers);

            var result = _supplierService.DeleteRange(supplierList);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(ApiResultMessages.ResultMessage(true));
        }

        [HttpPut]
        public IActionResult Update([FromBody] SupplierUpdateDto supplierUpdateDto)
        {
            var oldSupplier = _supplierService.GetByIdAsync(supplierUpdateDto.Id).Result;

            var supplierUpdate = _mapper.Map<SupplierUpdateDto, Supplier>(supplierUpdateDto, oldSupplier.Data);


            var result = _supplierService.Update(supplierUpdate);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(new SupplierDto
            {
                Supplier = result.Data,
                Message = ApiResultMessages.ResultMessage(true),
                ResultStatus = result.ResultStatus
            });
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetSupplierWithProductsByIdAsync(int id)
        {
            if (id < 1)
                return BadRequest();

            var result = await _supplierService.GetSupplierWithProductsByIdAsync(id);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(new SupplierWithProductsDto
            {
                Products = _mapper.Map<SupplierWithProductsDto>(result.Data).Products,
                ResultStatus = result.ResultStatus,
                Message = ApiResultMessages.ResultMessage(true)
            });
        }

        [HttpGet("search/{supplierName}")]
        public async Task<IActionResult> SearchName(string supplierName)
        {
            if (string.IsNullOrEmpty(supplierName)) return BadRequest();

            var result = await _supplierService.SearchNameAsync(s => s.SupplierName.Contains(supplierName));

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(new SupplierListDto
            {
                Suppliers = result.Data,
                ResultStatus = result.ResultStatus,
                Message = ApiResultMessages.ResultMessage(true)
            });
        }
    }
}
