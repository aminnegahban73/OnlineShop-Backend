using Application.Contract;
using Application.Dtos.Products;
using Application.Features.Products.Queries.GetAll;
using AutoMapper;
using Domain.Entities;
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
            return _mapper.Map<ProductDto>(result);

            //var product = await _unitOfWork.Repository<Product>().GetByIdAsync(request.Id, cancellationToken);
            ////TODO Handle Exception
            //if (product is null)
            //{
            //    throw new Exception("An Error occurred.");
            //}

            //return product;
        }
    }
}
