using MediatR;
using WWDemo.Application.DTOs;

namespace WWDemo.Application.Products.Commands.AddProduct
{
    public class UpdateProductCommand : IRequest<ProductRepresentation>
    {
        public string? SerialNumber { get; set; }
        public string? Name { get; set; }
        public string? Price { get; set; }
        public string? Category { get; set; }
    }
}
