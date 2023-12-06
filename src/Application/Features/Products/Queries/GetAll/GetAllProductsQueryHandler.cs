using Application.Contract;
using Application.Features.Products.Queries.Get;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Queries.GetAll
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var spec = new GetAllProductsSpec();
            return await _unitOfWork.Repository<Product>().ListAsyncSpec(spec, cancellationToken);
            
            //return await _unitOfWork.Repository<Product>().GetAllAsync(cancellationToken);

        }
    }
}
