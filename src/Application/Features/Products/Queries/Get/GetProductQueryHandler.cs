using Application.Contract;
using Application.Features.Products.Queries.GetAll;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Queries.Get
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var spec = new GetProductSpec(request.Id);
            return await _unitOfWork.Repository<Product>().GetEntityWithSpec(spec, cancellationToken);

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
