﻿using Application.Contract;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductTypes.Queries.GetAll
{
    public class GetAllProductTypesQueryHandler : IRequestHandler<GetAllProductTypesQuery, IEnumerable<ProductType>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllProductTypesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductType>> Handle(GetAllProductTypesQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Repository<ProductType>().GetAllAsync(cancellationToken);
        }
    }
}
