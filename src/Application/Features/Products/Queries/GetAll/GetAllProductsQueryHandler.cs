using Application.Contract;
using Application.Dtos.Products;
using Application.Features.Products.Queries.Get;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using static Application.Features.Products.Queries.GetAll.GetAllProductsSpec;

namespace Application.Features.Products.Queries.GetAll
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, PaginationResponse<ProductDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaginationResponse<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var spec = new GetAllProductsSpec(request);
            var count = await _unitOfWork.Repository<Product>().CountAsyncSpec(new ProductsCountSpec(request), cancellationToken);
            var result = await _unitOfWork.Repository<Product>().ListAsyncSpec(spec, cancellationToken);
            var model = _mapper.Map<IEnumerable<ProductDto>>(result);

            return new PaginationResponse<ProductDto>(request.PageIndex, request.PageSize, count, model);
        }
    }
}
