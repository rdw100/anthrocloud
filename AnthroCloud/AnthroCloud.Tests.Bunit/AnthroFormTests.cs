using AnthroCloud.UI.Blazor.Components;
using AnthroCloud.UI.Blazor.Pages;
using AnthroCloud.UI.Blazor.Services;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace AnthroCloud.Tests.Bunit
{
    public class AnthroFormTests
    {
        private readonly string baseAddressPath;

        public AnthroFormTests()
        {
            baseAddressPath = "https://localhost:5001/api/";
        }

        [Fact]
        public void AnthroForm_Height_Matches()
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

            // Act
            var cut = ctx.RenderComponent<AnthroForm>();

            // Assert
            Assert.Equal(73, cut.Instance.FormModel.FormInputs.LengthHeight);
        }

        [Fact]
        public void AnthroForm_Results_Matches()
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

            var component = ctx.RenderComponent<AnthroForm>();

            // Act
            component.Find("button").Click();

            // Assert
            component.WaitForAssertion(() => Assert.Equal("11mo", component.Instance.FormModel.FormOutputs.AgeString), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(16.9, component.Instance.FormModel.FormOutputs.Bmi), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(61.4, component.Instance.FormModel.FormOutputs.WflPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.29, component.Instance.FormModel.FormOutputs.WflZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(51.9, component.Instance.FormModel.FormOutputs.WfaPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.05, component.Instance.FormModel.FormOutputs.WfaZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(34.8, component.Instance.FormModel.FormOutputs.LfaPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(-0.39, component.Instance.FormModel.FormOutputs.LfaZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(64.1, component.Instance.FormModel.FormOutputs.BfaPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.36, component.Instance.FormModel.FormOutputs.BfaZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(53.1, component.Instance.FormModel.FormOutputs.HcaPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.08, component.Instance.FormModel.FormOutputs.HcaZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(74.3, component.Instance.FormModel.FormOutputs.MuacPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.65, component.Instance.FormModel.FormOutputs.MuacZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(49.9, component.Instance.FormModel.FormOutputs.TsfPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.00, component.Instance.FormModel.FormOutputs.TsfZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(65, component.Instance.FormModel.FormOutputs.SsfPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.38, component.Instance.FormModel.FormOutputs.SsfZscore), TimeSpan.FromSeconds(5));
        }
    }
}
