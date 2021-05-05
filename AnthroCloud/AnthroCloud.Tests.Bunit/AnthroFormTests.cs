using AnthroCloud.UI.Blazor.Components;
using AnthroCloud.UI.Blazor.Services;
using Blazored.Modal;
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
        public void AnthroForm_Results_Default()
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

            ctx.Services.AddBlazoredModal();

            var component = ctx.RenderComponent<AnthroForm>();

            // Act
            component.Find("button").Click();

            // Assert
            component.WaitForAssertion(() => Assert.Equal("11mo", component.Instance.FormModel.FormOutputs.Age.AgeString), TimeSpan.FromSeconds(5));
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

        [Fact]
        public void AnthroForm_Results_WeightChange()
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

            ctx.Services.AddBlazoredModal();

            var component = ctx.RenderComponent<AnthroForm>();

            component.Instance.FormModel.FormInputs.Weight = 9.1;

            // Act
            component.Find("button").Click();

            // Assert
            component.WaitForAssertion(() => Assert.Equal("11mo", component.Instance.FormModel.FormOutputs.Age.AgeString), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(16.9, component.Instance.FormModel.FormOutputs.Bmi), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(65.9, component.Instance.FormModel.FormOutputs.WflPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.41, component.Instance.FormModel.FormOutputs.WflZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(55.5, component.Instance.FormModel.FormOutputs.WfaPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.14, component.Instance.FormModel.FormOutputs.WfaZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(34.8, component.Instance.FormModel.FormOutputs.LfaPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(-0.39, component.Instance.FormModel.FormOutputs.LfaZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(68.6, component.Instance.FormModel.FormOutputs.BfaPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.48, component.Instance.FormModel.FormOutputs.BfaZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(53.1, component.Instance.FormModel.FormOutputs.HcaPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.08, component.Instance.FormModel.FormOutputs.HcaZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(74.3, component.Instance.FormModel.FormOutputs.MuacPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.65, component.Instance.FormModel.FormOutputs.MuacZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(49.9, component.Instance.FormModel.FormOutputs.TsfPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.00, component.Instance.FormModel.FormOutputs.TsfZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(65, component.Instance.FormModel.FormOutputs.SsfPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.38, component.Instance.FormModel.FormOutputs.SsfZscore), TimeSpan.FromSeconds(5));
        }

        [Fact]
        public void AnthroForm_Results_LengthChange()
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

            ctx.Services.AddBlazoredModal();

            var component = ctx.RenderComponent<AnthroForm>();

            component.Instance.FormModel.FormInputs.LengthHeight = 73.1;

            // Act
            component.Find("button").Click();

            // Assert
            component.WaitForAssertion(() => Assert.Equal("11mo", component.Instance.FormModel.FormOutputs.Age.AgeString), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(16.9, component.Instance.FormModel.FormOutputs.Bmi), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(60.5, component.Instance.FormModel.FormOutputs.WflPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.27, component.Instance.FormModel.FormOutputs.WflZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(51.9, component.Instance.FormModel.FormOutputs.WfaPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.05, component.Instance.FormModel.FormOutputs.WfaZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(36.3, component.Instance.FormModel.FormOutputs.LfaPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(-0.35, component.Instance.FormModel.FormOutputs.LfaZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(62.9, component.Instance.FormModel.FormOutputs.BfaPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.33, component.Instance.FormModel.FormOutputs.BfaZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(53.1, component.Instance.FormModel.FormOutputs.HcaPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.08, component.Instance.FormModel.FormOutputs.HcaZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(74.3, component.Instance.FormModel.FormOutputs.MuacPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.65, component.Instance.FormModel.FormOutputs.MuacZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(49.9, component.Instance.FormModel.FormOutputs.TsfPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.00, component.Instance.FormModel.FormOutputs.TsfZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(65, component.Instance.FormModel.FormOutputs.SsfPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.38, component.Instance.FormModel.FormOutputs.SsfZscore), TimeSpan.FromSeconds(5));
        }

        [Fact]
        public void AnthroForm_Results_HeadCircumferenceChange()
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

            ctx.Services.AddBlazoredModal();

            var component = ctx.RenderComponent<AnthroForm>();

            component.Instance.FormModel.FormInputs.HeadCircumference = 45.1;

            // Act
            component.Find("button").Click();

            // Assert
            component.WaitForAssertion(() => Assert.Equal("11mo", component.Instance.FormModel.FormOutputs.Age.AgeString), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(16.9, component.Instance.FormModel.FormOutputs.Bmi), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(61.4, component.Instance.FormModel.FormOutputs.WflPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.29, component.Instance.FormModel.FormOutputs.WflZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(51.9, component.Instance.FormModel.FormOutputs.WfaPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.05, component.Instance.FormModel.FormOutputs.WfaZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(34.8, component.Instance.FormModel.FormOutputs.LfaPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(-0.39, component.Instance.FormModel.FormOutputs.LfaZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(64.1, component.Instance.FormModel.FormOutputs.BfaPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.36, component.Instance.FormModel.FormOutputs.BfaZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(56.0, component.Instance.FormModel.FormOutputs.HcaPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.15, component.Instance.FormModel.FormOutputs.HcaZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(74.3, component.Instance.FormModel.FormOutputs.MuacPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.65, component.Instance.FormModel.FormOutputs.MuacZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(49.9, component.Instance.FormModel.FormOutputs.TsfPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.00, component.Instance.FormModel.FormOutputs.TsfZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(65, component.Instance.FormModel.FormOutputs.SsfPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.38, component.Instance.FormModel.FormOutputs.SsfZscore), TimeSpan.FromSeconds(5));
        }

        [Fact]
        public void AnthroForm_Results_MuacChange()
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

            ctx.Services.AddBlazoredModal();

            var component = ctx.RenderComponent<AnthroForm>();

            component.Instance.FormModel.FormInputs.MUAC = 15.1;

            // Act
            component.Find("button").Click();

            // Assert
            component.WaitForAssertion(() => Assert.Equal("11mo", component.Instance.FormModel.FormOutputs.Age.AgeString), TimeSpan.FromSeconds(5));
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
            component.WaitForAssertion(() => Assert.Equal(76.8, component.Instance.FormModel.FormOutputs.MuacPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.73, component.Instance.FormModel.FormOutputs.MuacZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(49.9, component.Instance.FormModel.FormOutputs.TsfPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.00, component.Instance.FormModel.FormOutputs.TsfZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(65, component.Instance.FormModel.FormOutputs.SsfPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.38, component.Instance.FormModel.FormOutputs.SsfZscore), TimeSpan.FromSeconds(5));
        }

        [Fact]
        public void AnthroForm_Results_TsfChange()
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

            ctx.Services.AddBlazoredModal();

            var component = ctx.RenderComponent<AnthroForm>();

            component.Instance.FormModel.FormInputs.TricepsSkinFold = 8.1;

            // Act
            component.Find("button").Click();

            // Assert
            component.WaitForAssertion(() => Assert.Equal("11mo", component.Instance.FormModel.FormOutputs.Age.AgeString), TimeSpan.FromSeconds(5));
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
            component.WaitForAssertion(() => Assert.Equal(52.3, component.Instance.FormModel.FormOutputs.TsfPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.06, component.Instance.FormModel.FormOutputs.TsfZscore), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(65, component.Instance.FormModel.FormOutputs.SsfPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.38, component.Instance.FormModel.FormOutputs.SsfZscore), TimeSpan.FromSeconds(5));
        }

        [Fact]
        public void AnthroForm_Results_SsfChange()
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

            ctx.Services.AddBlazoredModal();

            var component = ctx.RenderComponent<AnthroForm>();

            component.Instance.FormModel.FormInputs.SubscapularSkinFold = 7.1;

            // Act
            component.Find("button").Click();

            // Assert
            component.WaitForAssertion(() => Assert.Equal("11mo", component.Instance.FormModel.FormOutputs.Age.AgeString), TimeSpan.FromSeconds(5));
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
            component.WaitForAssertion(() => Assert.Equal(67.7, component.Instance.FormModel.FormOutputs.SsfPercentile), TimeSpan.FromSeconds(5));
            component.WaitForAssertion(() => Assert.Equal(0.46, component.Instance.FormModel.FormOutputs.SsfZscore), TimeSpan.FromSeconds(5));
        }
    }
}
