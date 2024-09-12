using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Product.Dtos.Common
{
    public class FilterDto
    {
        private string? _keyword;

        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 100;
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
