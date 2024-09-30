namespace ApiStoreWeb.DTOs
{
    public class OrderDetailResponse
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }
    }
}
