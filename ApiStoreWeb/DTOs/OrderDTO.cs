namespace ApiStoreWeb.DTOs
{
    public class OrderResponse
    {
        public int Id { get; set; }

        public DateOnly FechaPedido { get; set; }

        public string EstadoPedido { get; set; } = null!;

        public int UserId { get; set; }

    }
}
