using Application.Contract;
using Application.Dtos.Products;
using Application.Features.Products.Queries.Get;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Queries.GetAll
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var spec = new GetAllProductsSpec(request);
            var result =  await _unitOfWork.Repository<Product>().ListAsyncSpec(spec, cancellationToken);
            
            return _mapper.Map<IEnumerable<ProductDto>>(result);
        }
    }
}
