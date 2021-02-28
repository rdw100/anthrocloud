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
        [Fact]
        public void AnthroForm_Results_Matches()
        {
            // Arrange
            using var ctx = new TestContext();

            String baseAddressPath = "https://localhost:5001/api/";

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
            component.WaitForAssertion(() => Assert.Equal("11mo", component.Instance.formModel.AgeString), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(16.9, component.Instance.formModel.BMI), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(61.4, component.Instance.formModel.WflPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.29, component.Instance.formModel.WflZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(51.9, component.Instance.formModel.WfaPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.05, component.Instance.formModel.WfaZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(34.8, component.Instance.formModel.LfaPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(-0.39, component.Instance.formModel.LfaZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(64.1, component.Instance.formModel.BfaPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.36, component.Instance.formModel.BfaZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(53.1, component.Instance.formModel.HcaPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.08, component.Instance.formModel.HcaZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(74.3, component.Instance.formModel.MuacPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.65, component.Instance.formModel.MuacZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(49.9, component.Instance.formModel.TsfPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.00, component.Instance.formModel.TsfZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(65, component.Instance.formModel.SsfPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.38, component.Instance.formModel.SsfZscore), TimeSpan.FromSeconds(5));
        }
    }
}
