using AnthroCloud.Entities;
using System;
using System.Threading.Tasks;

namespace AnthroCloud.UI.Blazor.Services
{
    public interface IAnthroStatsService
    {
        Task<Tuple<double, double>> GetWFA(double weight, string ageInDays, Sexes sex);
    }
}
