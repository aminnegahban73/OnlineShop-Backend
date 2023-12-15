using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrappers
{
    public abstract class RequestParametersBasic: PaginationParametersDto
    {
        private string _Search { get; set; }
        public TypeSort TypeSort { get; set; } = TypeSort.Asc;
        public int Sort { get; set; }

        public string Search { get => _Search; set => value?.ToLower(); }
    }

    public enum TypeSort
    {
        Asc = 1,
        Desc,
    }
}
