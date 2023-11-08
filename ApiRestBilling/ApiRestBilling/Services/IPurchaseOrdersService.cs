using ApiRestBilling.Models;

namespace ApiRestBilling.Services
{
    public interface IPurchaseOrdersService
    {
        Task<decimal> ChechUnitPrice(OrderItem detalle);
        Task<decimal> CalculateSubtotalOrderItem(OrderItem item);
        decimal CalcularTotalOrderItems(List<OrderItem> item);
        Task<decimal> CheckUnitPrice(OrderItem detalle);
    }
}
