using AutoMapper;
using GrossMarketApp.Api.Dtos;
using GrossMarketApp.Api.Dtos.Products;
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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductAddDto productAddDto)
        {
            var product = _mapper.Map<Product>(productAddDto);

            var result = await _productService.AddAsync(product);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Created(string.Empty, productAddDto);
        }

        [HttpPost("save-all")]
        public async Task<IActionResult> CreateAll([FromBody] IEnumerable<ProductAddDto> productsAddDtos)
        {
            var products = _mapper.Map<IEnumerable<Product>>(productsAddDtos);

            var result = await _productService.AddRangeAsync(products);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Created(string.Empty, productsAddDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productService.GetByIdAsync(id);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(new ProductDto
            {
                Product = result.Data,
                Message = ApiResultMessages.ResultMessage(true),
                ResultStatus = result.ResultStatus
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAllAsync();

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(new ProductListDto
            {
                Products = result.Data,
                Message = ApiResultMessages.ResultMessage(true),
                ResultStatus = result.ResultStatus
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var product = _productService.GetByIdAsync(id).Result;

            var result = _productService.Delete(product.Data);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(ApiResultMessages.ResultMessage(true));
        }

        [HttpDelete("delete-all")]
        public IActionResult RemoveAll([FromBody] IEnumerable<ProductListDelete> products)
        {
            var productList = _mapper.Map<IEnumerable<Product>>(products);

            var result = _productService.DeleteRange(productList);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(ApiResultMessages.ResultMessage(true));
        }

        [HttpPut]
        public IActionResult Update([FromBody] ProductUpdateDto productUpdateDto)
        {
            var oldProduct = _productService.GetByIdAsync(productUpdateDto.Id).Result;

            var productUpdate = _mapper.Map<ProductUpdateDto, Product>(productUpdateDto, oldProduct.Data);


            var result = _productService.Update(productUpdate);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(new ProductDto
            {
                Product = result.Data,
                Message = ApiResultMessages.ResultMessage(true),
                ResultStatus = result.ResultStatus
            });
        }

        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetProductWithCategoryByIdAsync(int id)
        {
            if (id < 1)
                return BadRequest();

            var result = await _productService.GetProductWithCategoryByIdAsync(id);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(new ProductWithCategoryDto
            {
                Category = _mapper.Map<ProductWithCategoryDto>(result.Data).Category,
                ResultStatus = result.ResultStatus,
                Message = ApiResultMessages.ResultMessage(true)
            });
        }

        [HttpGet("{id}/supplier")]
        public async Task<IActionResult> GetProductWithSupplierByIdAsync(int id)
        {
            if (id < 1)
                return BadRequest();

            var result = await _productService.GetProductWithSupplierByIdAsync(id);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(new ProductWithSupplierDto
            {
                Supplier = _mapper.Map<ProductWithSupplierDto>(result.Data).Supplier,
                ResultStatus = result.ResultStatus,
                Message = ApiResultMessages.ResultMessage(true)
            });
        }

        [HttpGet("search/{productName}")]
        public async Task<IActionResult> SearchName(string productName)
        {
            if (string.IsNullOrEmpty(productName)) return BadRequest();

            var result = await _productService.SearchNameAsync(p => p.ProductName.Contains(productName));

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(new ProductListDto
            {
                Products = result.Data,
                ResultStatus = result.ResultStatus,
                Message = ApiResultMessages.ResultMessage(true)
            });
        }
    }
}
