using AnthroCloud.UI.Blazor.Components;
using AnthroCloud.UI.Blazor.Pages;
using AnthroCloud.UI.Blazor.Services;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace AnthroCloud.Tests.Bunit
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Architecture", "DV2002:Unmapped types", Justification = "<Pending>")]

    public class AnthroComponentTests
    {
        private readonly string baseAddressPath;

        public AnthroComponentTests()
        {
            baseAddressPath = "https://localhost:5001/api/";
        }

        [Fact]
        public void AnthroComponent_CalculateBMI_Matches()
        {
            // Arrange
            using var ctx = new TestContext();

            ctx.Services.AddHttpClient<IAnthroService, AnthroService>(client =>
            {
                client.BaseAddress = new Uri(baseAddressPath);
            });

            ctx.Services.AddHttpClient<IAnthroStatsService, AnthroStatsService>(client =>
            {
                client.BaseAddress = new Uri(baseAddressPath);
            });

            var component = ctx.RenderComponent<Anthro>();

            // Act
            component.Find("button").Click();

            // Assert
            component.WaitForAssertion(() => component.Find("p").MarkupMatches("<p>The BMI for a weight of 9 kg and Length/height of 73 cm is 16.9.</p>"), TimeSpan.FromSeconds(5));
        }

        [Fact]
        public void CounterComponent_MultiClick_Matches()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Counter>();
            var paraElm = cut.Find("p");

            // Act
            cut.Find("button").Click();
            cut.Find("button").Click();
            cut.Find("button").Click();
            var paraElmText = paraElm.TextContent;

            // Assert
            paraElmText.MarkupMatches("Current count: 3");
        }
    }
}
