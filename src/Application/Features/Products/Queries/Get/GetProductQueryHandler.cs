using Application.Contract;
using Application.Dtos.Products;
using Application.Features.Products.Queries.GetAll;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Products.Queries.Get
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var spec = new GetProductSpec(request.Id);
            var result = await _unitOfWork.Repository<Product>().GetEntityWithSpec(spec, cancellationToken);
            if (result is null) throw new NotFoundEntityException();

            return _mapper.Map<ProductDto>(result);
        }
    }
}
