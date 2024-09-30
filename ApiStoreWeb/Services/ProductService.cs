using ApiStoreWeb.DTOs;
using System.Net.Http.Headers;
namespace ApiStoreWeb.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthServices _authServices;

        public ProductService(HttpClient httpClient, AuthServices authServices)
        {
            _httpClient = httpClient;
            _authServices = authServices;
        }
        public async Task<List<ProductResponse>> GetProducts()
        {
            try
            {
                var token = await _authServices.GetToken();
                if (string.IsNullOrEmpty(token))
                {
                    throw new InvalidOperationException("El token es nulo o invalido.Iniciar sesion");
                }
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                var response = await _httpClient.GetFromJsonAsync<List<ProductResponse>>("api/products");

                return response;
            }

            catch (HttpRequestException ex)
            {

                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error inesperado al obtener productos");
            }

        }
    }
}
