using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WS.Order.Dtos.Common
{
    public class FilterDto
    {
        private string? _keyword;
        [FromQuery(Name = "pageIndex")]

        public int PageIndex { get; set; } = 1;
        [FromQuery(Name = "pageSize")]
        public int PageSize { get; set; } = 100;
        [FromQuery(Name = "keyword")]
        public string? Keyword
        {
            get => _keyword;
            set => _keyword = value?.Trim();
        }

        public int SkipCount()
        {
            return (PageIndex - 1) * PageSize;
        }
    }
}
