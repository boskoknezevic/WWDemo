using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWDemo.Application.DTOs;
using WWDemo.Application.Products.Queries.GetProductBySerialNumber;
using WWDemo.Data.Products;

namespace WWDemo.Application.Products.Queries.DeleteProductBySerialNumber
{
    public class DeleteProductBySerialNumberHandler : IRequestHandler<DeleteProductBySerialNumberQuery, Unit>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductBySerialNumberHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(DeleteProductBySerialNumberQuery request, CancellationToken cancellationToken)
        {
            await _productRepository.DeleteProductBySerialNumber(request.SerialNumber);
            return Unit.Value;
        }
    }
}
