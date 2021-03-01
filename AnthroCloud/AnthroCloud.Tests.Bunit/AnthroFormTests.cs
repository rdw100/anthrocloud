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
            component.WaitForAssertion(() => Assert.Equal("11mo", component.Instance.formModel.FormInputs.AgeString), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(16.9, component.Instance.formModel.FormInputs.BMI), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(61.4, component.Instance.formModel.FormOutputs.WflPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.29, component.Instance.formModel.FormOutputs.WflZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(51.9, component.Instance.formModel.FormOutputs.WfaPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.05, component.Instance.formModel.FormOutputs.WfaZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(34.8, component.Instance.formModel.FormOutputs.LfaPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(-0.39, component.Instance.formModel.FormOutputs.LfaZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(64.1, component.Instance.formModel.FormOutputs.BfaPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.36, component.Instance.formModel.FormOutputs.BfaZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(53.1, component.Instance.formModel.FormOutputs.HcaPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.08, component.Instance.formModel.FormOutputs.HcaZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(74.3, component.Instance.formModel.FormOutputs.MuacPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.65, component.Instance.formModel.FormOutputs.MuacZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(49.9, component.Instance.formModel.FormOutputs.TsfPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.00, component.Instance.formModel.FormOutputs.TsfZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(65, component.Instance.formModel.FormOutputs.SsfPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.38, component.Instance.formModel.FormOutputs.SsfZscore), TimeSpan.FromSeconds(5));
        }
    }
}
