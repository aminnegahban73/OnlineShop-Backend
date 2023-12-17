using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrappers
{
    public abstract class PaginationParametersDto
    {
        private const int _MaxPageSize = 50;
        private int _PageIndex = 1;
        private int _PageSize = 10;

        public int PageSize
        {
            get => _PageSize;
            set => _PageSize = value > _MaxPageSize ? _MaxPageSize : value;
        }
        public int PageIndex
        {
            get => _PageIndex;
            set => _PageIndex = value <= 0 ? 1 : value;
        }
    }
}
