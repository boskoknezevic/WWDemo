using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWDemo.Application.DTOs;

namespace WWDemo.Application.Products.Queries.DeleteProductBySerialNumber
{
    public class DeleteProductBySerialNumberQuery : IRequest<Unit>
    {
        public string? SerialNumber { get; set; }

        public DeleteProductBySerialNumberQuery(string? serialNumber)
        {
            SerialNumber = serialNumber;
        }
    }
}
