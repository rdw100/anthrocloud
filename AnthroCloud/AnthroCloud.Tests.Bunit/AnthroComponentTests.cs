using AnthroCloud.UI.Blazor.Components;
using AnthroCloud.UI.Blazor.Pages;
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
            var cut = ctx.RenderComponent<Anthro>();

            // Assert
            Assert.Equal(73, cut.Instance.Height);
        }

        //[Fact]
        //public void AnthroComponent_CalculateBMI_Matches()
        //{
        //    // Arrange
        //    using var ctx = new TestContext();

        //    ctx.Services.AddHttpClient<IAnthroService, AnthroService>(client =>
        //    {
        //        client.BaseAddress = new Uri("https://localhost:5001/api/");
        //    });

        //    // Act
        //    var component = ctx.RenderComponent<AnthroCloud.UI.Blazor.Components.Anthro>();
        //    component.Find("button").Click();

        //    // Assert
        //    Assert.Equal(16.9, component.Instance.BMI);
        //}

        //[Fact]
        //public void AnthroComponent_CalculateBMI_Matches()
        //{
        //    // Arrange
        //    using var ctx = new TestContext();
        //    ctx.Services.AddHttpClient<IAnthroService, AnthroService>(client =>
        //    {
        //        client.BaseAddress = new Uri("https://localhost:5001/api/");
        //    });
        //    var cut = ctx.RenderComponent<Anthro>();
        //    var paraElm = cut.Find("p");

        //    // Act
        //    cut.Find("button").Click();
        //    var paraElmText = paraElm.TextContent;

        //    // Assert
        //    //paraElmText.MarkupMatches("Current count: 1");
        //    paraElmText.MarkupMatches("The BMI for a weight of 9 kg and Length/height of 73 cm is 1 16.9.");            
        //}

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
