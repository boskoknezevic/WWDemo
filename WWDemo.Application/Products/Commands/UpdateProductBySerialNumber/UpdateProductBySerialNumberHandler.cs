using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWDemo.Application.DTOs;
using WWDemo.Application.Products.Commands.AddProduct;
using WWDemo.Data.Products;
using WWDemo.Models;

namespace WWDemo.Application.Products.Commands.UpdateProductBySerialNumber
{
    public class UpdateProductBySerialNumberHandler : IRequestHandler<UpdateProductCommand, ProductRepresentation>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductBySerialNumberHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductRepresentation> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetProductBySerialNumber(request.SerialNumber);

            result.Category = request.Category;
            result.Name = request.Name;
            result.Price = request.Price;

            var updatedResult = await _productRepository.UpdateProduct(result);
            return new ProductRepresentation { SerialNumber = result.SerialNumber };
        }
    }
}
