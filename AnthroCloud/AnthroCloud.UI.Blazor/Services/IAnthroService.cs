using AnthroCloud.Business;
using AnthroCloud.Entities;
using System;
using System.Threading.Tasks;

namespace AnthroCloud.UI.Blazor.Services
{
    public interface IAnthroService
    {
        Task<double> GetBMI(double weight, double height);
        Task<Age> GetAge(string birth, string visit);
        Task<Tuple<double, double>> GetWFA(double weight, string ageInDays, Sexes sex);
    }
}
