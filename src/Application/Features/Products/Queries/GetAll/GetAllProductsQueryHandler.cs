using Application.Contract;
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
            return await _unitOfWork.Repository<Product>().GetAllAsync(cancellationToken);
        }
    }
}
