using ApiStoreWeb.DTOs;
using System.Net.Http.Headers;

namespace ApiStoreWeb.Services
{
    public class OrderServices
    {
        private readonly HttpClient _httpClient;
        private readonly AuthServices _authServices;

        public OrderServices(HttpClient httpClient, AuthServices authServices)
        {
            _httpClient = httpClient;
            _authServices = authServices;
        }

        public async Task<List<OrderResponse>> GetOrders()
        {
            try
            {
                var token = await _authServices.GetToken();

                if (string.IsNullOrEmpty(token))
                {
                    throw new InvalidOperationException("El token es nulo o invalido. Iniciar sesión");
                }

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.GetFromJsonAsync<List<OrderResponse>>("api/orders");

                return response;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error al obtener productos. Revisar conexión a internet.");
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error inesperado al obtener el detalle de ordenes.");
            }
        }
    }
}
