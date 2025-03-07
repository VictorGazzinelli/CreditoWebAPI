using CreditoWebAPI.Inputs.Propostas;
using CreditoWebAPI.Tests.Base;
using FluentAssertions;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Xunit;

namespace CreditoWebAPI.Tests.Controllers.Propostas
{
    public class SimularPropostaTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public SimularPropostaTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task SimularPropostaRetorna200OkQuandoDadosSaoValidos()
        {
            // Arrange
            string username = "admin";
            string password = "password";
            string encodedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encodedCredentials);

            SimularPropostaInput inculuirPropostaInput = new SimularPropostaInput
            {
                CpfProponente = "12662366605",
                ValorSolicitado = 1000,
                QuantidadeParcelas = 10,
            };

            StringContent content = new StringContent(JsonSerializer.Serialize(inculuirPropostaInput), Encoding.UTF8, "application/json");
            HttpStatusCode expectedStatusCode = HttpStatusCode.Accepted;

            // Act
            HttpResponseMessage response = await _client.PostAsync("/api/proposta/Simular", content);

            // Assert
            response.StatusCode.Should().Be(expectedStatusCode);
        }

        [Fact]
        public async Task SimularPropostaRetorna400BadRequestQuandoDadosSaoInvalidos()
        {
            // Arrange
            string username = "admin";
            string password = "password";
            string encodedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encodedCredentials);

            SimularPropostaInput inculuirPropostaInput = new SimularPropostaInput
            {
                CpfProponente = "1234567890", // CpfProponente invalido
                ValorSolicitado = 0,
                QuantidadeParcelas = 0,
            };

            StringContent content = new StringContent(JsonSerializer.Serialize(inculuirPropostaInput), Encoding.UTF8, "application/json");
            HttpStatusCode expectedStatusCode = HttpStatusCode.BadRequest;

            // Act
            HttpResponseMessage response = await _client.PostAsync("/api/proposta/Simular", content);
            string responseContent = await response.Content.ReadAsStringAsync();

            // Assert
            response.StatusCode.Should().Be(expectedStatusCode);
            responseContent.Should().BeEquivalentTo("{\"statusCode\":400,\"message\":\"One or more errors occured.\",\"errors\":{\"cpfProponente\":\"CPF invalido.\",\"valorSolicitado\":\"Valor invalido. Esperava valor monetario acima de 0\",\"quantidadeParcelas\":\"A quantidade de parcelas deve ser maior que zero.\"}}");
        }

        [Fact]
        public async Task SimularPropostaRetorna401UnauthorizedQuandoNaoPossuiHeaderDeAuth()
        {
            // Arrange
            SimularPropostaInput inculuirPropostaInput = new SimularPropostaInput
            {
                CpfProponente = "12662366605",
                ValorSolicitado = 1000,
                QuantidadeParcelas = 10
            };
            StringContent content = new StringContent(JsonSerializer.Serialize(inculuirPropostaInput), Encoding.UTF8, "application/json");
            HttpStatusCode expectedStatusCode = HttpStatusCode.Unauthorized;

            // Act
            HttpResponseMessage response = await _client.PostAsync("/api/proposta/Simular", content);

            // Assert
            response.StatusCode.Should().Be(expectedStatusCode);
        }
    }
}
