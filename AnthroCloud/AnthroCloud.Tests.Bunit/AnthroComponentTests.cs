using AnthroCloud.UI.Blazor.Services;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace AnthroCloud.Tests.Bunit
{
    public class AnthroComponentTests
    {
        [Fact]
        public void AnthroComponent_Height_Matches()
        {
            // Arrange
            using var ctx = new TestContext();

            ctx.Services.AddHttpClient<IAnthroService, AnthroService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
            });

            // Act
            var cut = ctx.RenderComponent<AnthroCloud.UI.Blazor.Components.Anthro>();

            // Assert
            Assert.Equal(73, cut.Instance.Height);
        }
    }
}
