using Application.Contract;
using Application.Contract.Specification;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductBrands.Queries.GetAll
{
    public class GetAllProductBrandsQueryHandler : IRequestHandler<GetAllProductBrandsQuery, IEnumerable<ProductBrand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllProductBrandsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductBrand>> Handle(GetAllProductBrandsQuery request, CancellationToken cancellationToken)
        {
            var spec = new GetAllProductBrandsSpec();
            return await _unitOfWork.Repository<ProductBrand>().ListAsyncSpec(spec, cancellationToken);
            //return await _unitOfWork.Repository<ProductBrand>().GetAllAsync(cancellationToken);
        }
    }
}
