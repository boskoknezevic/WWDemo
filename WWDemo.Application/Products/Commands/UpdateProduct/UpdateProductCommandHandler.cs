using AutoMapper;
using MediatR;
using WWDemo.Application.DTOs;
using WWDemo.Data.Products;
using WWDemo.Models;

namespace WWDemo.Application.Products.Commands.AddProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductRepresentation>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
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
