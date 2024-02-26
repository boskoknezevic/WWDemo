using AutoMapper;
using MediatR;
using WWDemo.Application.DTOs;
using WWDemo.Application.Products.Queries.GetAllProducts;
using WWDemo.Data.Products;

namespace WWDemo.Application.Products.Queries.GetProductBySerialNumber
{
    public class GetProductsBySerialNumberHandler : IRequestHandler<GetProductBySerialNumberQuery, ProductRepresentation>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductsBySerialNumberHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductRepresentation> Handle(GetProductBySerialNumberQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductBySerialNumber(request.SerialNumber);

            var result = _mapper.Map<Models.Product, DTOs.ProductRepresentation>(products!);

            return result;
        }
    }
}
