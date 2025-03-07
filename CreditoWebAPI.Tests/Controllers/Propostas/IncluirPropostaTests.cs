﻿using CreditoWebAPI.Inputs.Propostas;
using CreditoWebAPI.Tests.Base;
using FluentAssertions;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Xunit;

namespace CreditoWebAPI.Tests.Controllers.Propostas
{
    public class IncluirPropostaTests : IntegrationTest
    {
        public IncluirPropostaTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {

        }

        [Fact]
        public async Task IncluirPropostaRetorna200OkQuandoDadosSaoValidos()
        {
            // Arrange
            string username = "admin";
            string password = "password";
            string encodedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encodedCredentials);
            string guidString = "123e4567-e89b-12d3-a456-426614174000";

            IncluirPropostaInput inculuirPropostaInput = new IncluirPropostaInput
            {
                CpfProponente = "12662366605",
                IdAgente = Guid.Parse(guidString),
                IdLoja = Guid.Parse(guidString),
                ValorSolicitado = 1000,
                QuantidadeParcelas = 10,
                ValorParcela = 100,
                Data = DateTimeOffset.Now
            };

            StringContent content = new StringContent(JsonSerializer.Serialize(inculuirPropostaInput), Encoding.UTF8, "application/json");
            HttpStatusCode expectedStatusCode = HttpStatusCode.Accepted;

            // Act
            HttpResponseMessage response = await Client.PostAsync("/api/proposta/Incluir", content);

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
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encodedCredentials);

            IncluirPropostaInput inculuirPropostaInput = new IncluirPropostaInput
            {
                CpfProponente = "1234567890", // CpfProponente invalido
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
            HttpResponseMessage response = await Client.PostAsync("/api/proposta/Incluir", content);
            string responseContent = await response.Content.ReadAsStringAsync();

            // Assert
            response.StatusCode.Should().Be(expectedStatusCode);
            responseContent.Should().BeEquivalentTo("{\"statusCode\":400,\"message\":\"One or more errors occured.\",\"errors\":{\"cpfProponente\":\"CPF invalido.\",\"valorSolicitado\":\"Valor invalido. Esperava valor monetario acima de 0\",\"quantidadeParcelas\":\"A quantidade de parcelas deve ser maior que zero.\",\"valorParcela\":\"Valor invalido. Esperava valor monetario acima de 0\"}}");
        }

        [Fact]
        public async Task IncluirPropostaRetorna401UnauthorizedQuandoNaoPossuiHeaderDeAuth()
        {
            // Arrange
            string guidString = "123e4567-e89b-12d3-a456-426614174000";
            IncluirPropostaInput inculuirPropostaInput = new IncluirPropostaInput
            {
                CpfProponente = "12662366605",
                IdAgente = Guid.Parse(guidString),
                IdLoja = Guid.Parse(guidString),
                ValorSolicitado = 1000,
                QuantidadeParcelas = 10,
                ValorParcela = 100,
                Data = DateTimeOffset.Now
            };
            StringContent content = new StringContent(JsonSerializer.Serialize(inculuirPropostaInput), Encoding.UTF8, "application/json");
            HttpStatusCode expectedStatusCode = HttpStatusCode.Unauthorized;

            // Act
            HttpResponseMessage response = await Client.PostAsync("/api/proposta/Incluir", content);

            // Assert
            response.StatusCode.Should().Be(expectedStatusCode);
        }
    }
}
