using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrossMarketApp.Api.Dtos.Categories
{
    public class CategoryToProductDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Note { get; set; }
    }
}
