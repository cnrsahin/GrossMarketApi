using AutoMapper;
using GrossMarketApp.Api.Dtos;
using GrossMarketApp.Api.Dtos.Categories;
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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryAddDto categoryAddDto)
        {
            var category = _mapper.Map<Category>(categoryAddDto);

            var result = await _categoryService.AddAsync(category);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Created(string.Empty, categoryAddDto);
        }

        [HttpPost("save-all")]
        public async Task<IActionResult> CreateAll([FromBody] IEnumerable<CategoryAddDto> categoryAddDtos)
        {
            var categories = _mapper.Map<IEnumerable<Category>>(categoryAddDtos);

            var result = await _categoryService.AddRangeAsync(categories);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Created(string.Empty, categoryAddDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _categoryService.GetByIdAsync(id);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(new CategoryDto
            {
                Category = result.Data,
                Message = ApiResultMessages.ResultMessage(true),
                ResultStatus = result.ResultStatus
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetAllAsync();

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(new CategoryListDto
            {
                Categories = result.Data,
                Message = ApiResultMessages.ResultMessage(true),
                ResultStatus = result.ResultStatus
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var category = _categoryService.GetByIdAsync(id).Result;

            var result = _categoryService.Delete(category.Data);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(ApiResultMessages.ResultMessage(true));
        }

        [HttpDelete("delete-all")]
        public IActionResult RemoveAll([FromBody] IEnumerable<CategoryListDelete> categories)
        {
            var categoryList = _mapper.Map<IEnumerable<Category>>(categories);

            var result = _categoryService.DeleteRange(categoryList);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(ApiResultMessages.ResultMessage(true));
        }

        [HttpPut]
        public IActionResult Update([FromBody] CategoryUpdateDto categoryUpdateDto)
        {
            var oldCategory = _categoryService.GetByIdAsync(categoryUpdateDto.Id).Result;

            var categoryUpdate = _mapper.Map<CategoryUpdateDto, Category>(categoryUpdateDto, oldCategory.Data);


            var result = _categoryService.Update(categoryUpdate);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(new CategoryDto
            {
                Category = result.Data,
                Message = ApiResultMessages.ResultMessage(true),
                ResultStatus = result.ResultStatus
            });
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetCategoryWithProductsByIdAsync(int id)
        {
            if (id < 1)
                return BadRequest();

            var result = await _categoryService.GetCategoryWithProductsByIdAsync(id);

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(new CategoryWithProductsDto
            {
                Products = _mapper.Map<CategoryWithProductsDto>(result.Data).Products,
                ResultStatus = result.ResultStatus,
                Message = ApiResultMessages.ResultMessage(true)
            });
        }

        [HttpGet("search/{categoryName}")]
        public async Task<IActionResult> SearchName(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName)) return BadRequest();

            var result = await _categoryService.SearchNameAsync(c => c.CategoryName.Contains(categoryName));

            if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(new ErrorDto
                {
                    Message = ApiResultMessages.ResultMessage(false),
                    ResultStatus = result.ResultStatus
                });

            return Ok(new CategoryListDto
            {
                Categories = result.Data,
                ResultStatus = result.ResultStatus,
                Message = ApiResultMessages.ResultMessage(true)
            });
        }
    }
}
