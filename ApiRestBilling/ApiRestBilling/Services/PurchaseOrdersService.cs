using ApiRestBilling.Data;
using ApiRestBilling.Models;
using Microsoft.AspNetCore.Http.Features;

namespace ApiRestBilling.Services
{
    public class PurchaseOrdersService : IPurchaseOrdersService
    {
        private ApplicationDbContext _context;

        public PurchaseOrdersService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductById(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) 
            {
                throw new Exception($"El producto con ID {productId} no fue encontrado.");
            }

            return product;
        }
        public async Task<decimal> checkUnitPrice(OrderItem detalle) 
        {
            var product = await GetProductById(detalle.ProductId);
            detalle.UnitPrice = product.UnitPrice;

            return (decimal)detalle.UnitPrice;
        }

        public async Task<decimal> CalculateSubtotalOrderItem(OrderItem item)
        {
            decimal UnitPrice = await checkUnitPrice(item);
            item.Subtotal = UnitPrice * item.Quantity;

            return (decimal) item.Subtotal;
        }

        public decimal CalculateTotalOrderItem(List<OrderItem> items) 
        {
            decimal total = 0;
            foreach (var item in items)
            {
                total += (decimal)item.Subtotal;
            }

        //decimal total = (decimal) items.Sum(item => item.Subtotal);
            return total;
        }

        public Task<decimal> ChechUnitPrice(OrderItem detalle)
        {
            throw new NotImplementedException();
        }

        public decimal CalcularTotalOrderItems(List<OrderItem> item)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> CheckUnitPrice(OrderItem detalle)
        {
            throw new NotImplementedException();
        }
    }
}
