using CreditoWebAPI.Inputs.Propostas;
using CreditoWebAPI.Tests.Base;
using FluentAssertions;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace CreditoWebAPI.Tests.Controllers.Propostas
{
    public class IncluirPropostaTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public IncluirPropostaTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task IncluirPropostaRetorna200OkQuandoDadosSaoValidos()
        {
            // Arrange
            string username = "admin";
            string password = "password";
            string encodedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encodedCredentials);

            IncluirPropostaInput inculuirPropostaInput = new IncluirPropostaInput
            {
                CpfProponente = "12662366605",
                IdAgente = Guid.NewGuid(),
                IdLoja = Guid.NewGuid(),
                ValorSolicitado = 1000,
                QuantidadeParcelas = 10,
                ValorParcela = 100,
                Data = DateTimeOffset.Now
            };

            StringContent content = new StringContent(JsonSerializer.Serialize(inculuirPropostaInput), Encoding.UTF8, "application/json");
            HttpStatusCode expectedStatusCode = HttpStatusCode.Accepted;

            // Act
            HttpResponseMessage response = await _client.PostAsync("/api/proposta/incluir", content);

            // Assert
            response.StatusCode.Should().Be(expectedStatusCode);
        }

        [Fact]
        public async Task IncluirPropostaRetorna400BadRequestQuandoDadosSaoInvalidos()
        {
            // Arrange
            string username = "admin";
            string password = "password";
            string encodedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encodedCredentials);

            IncluirPropostaInput inculuirPropostaInput = new IncluirPropostaInput
            {
                CpfProponente = "12345678901", // CpfProponente invalido
                IdAgente = Guid.NewGuid(),
                IdLoja = Guid.NewGuid(),
                ValorSolicitado = 0,
                QuantidadeParcelas = 0,
                ValorParcela = 0,
                Data = DateTimeOffset.Now
            };

            StringContent content = new StringContent(JsonSerializer.Serialize(inculuirPropostaInput), Encoding.UTF8, "application/json");
            HttpStatusCode expectedStatusCode = HttpStatusCode.BadRequest;

            // Act
            HttpResponseMessage response = await _client.PostAsync("/api/proposta/incluir", content);
            string responseContent = await response.Content.ReadAsStringAsync();

            // Assert
            response.StatusCode.Should().Be(expectedStatusCode);
            responseContent.Should().BeEquivalentTo("{\"errors\":{\"ValorSolicitado\":[\"Valor invalido.\"],\"QuantidadeParcelas\":[\"A quantidade de parcelas deve ser maior que zero.\"],\"ValorParcela\":[\"Valor invalido.\"]}}");
        }

        [Fact]
        public async Task IncluirPropostaRetorna401UnauthorizedQuandoNaoPossuiHeaderDeAuth()
        {
            // Arrange
            IncluirPropostaInput inculuirPropostaInput = new IncluirPropostaInput
            {
                CpfProponente = "12662366605",
                IdAgente = Guid.NewGuid(),
                IdLoja = Guid.NewGuid(),
                ValorSolicitado = 1000,
                QuantidadeParcelas = 10,
                ValorParcela = 100,
                Data = DateTimeOffset.Now
            };
            StringContent content = new StringContent(JsonSerializer.Serialize(inculuirPropostaInput), Encoding.UTF8, "application/json");
            HttpStatusCode expectedStatusCode = HttpStatusCode.Unauthorized;

            // Act
            HttpResponseMessage response = await _client.PostAsync("/api/proposta/incluir", content);

            // Assert
            response.StatusCode.Should().Be(expectedStatusCode);
        }
    }
}
