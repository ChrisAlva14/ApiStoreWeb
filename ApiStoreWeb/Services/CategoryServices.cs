using ApiStoreWeb.DTOs;
using System.Net.Http.Headers;

namespace ApiStoreWeb.Services
{
    public class CategoryServices
    {
        private readonly HttpClient _httpClient;
        private readonly AuthServices _authServices;

        public CategoryServices(HttpClient httpClient, AuthServices authServices)
        {
            _httpClient = httpClient;
            _authServices = authServices;
        }

        public async Task<List<CategoryResponse>> GetCategories()
        {
            try
            {
                var token = await _authServices.GetToken();

                if (string.IsNullOrEmpty(token))
                {
                    throw new InvalidCastException("EL TOKEN ES NULO O INVALIDO. INICIAR SESIÓN");
                }
                else
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var response = await _httpClient.GetFromJsonAsync<List<CategoryResponse>>("api/categories");

                    return response;
                }
            }
            catch (HttpRequestException ex)
            {

                throw new Exception("ERROR AL OBTENER LAS CATEGORÍAS, REVISAR CONEXIÓN A INTERNET");
            }
            catch(Exception ex)
            {
                throw new Exception("ERROR AL OBTENER CATEGORÍAS");
            }
        }
    }
}
