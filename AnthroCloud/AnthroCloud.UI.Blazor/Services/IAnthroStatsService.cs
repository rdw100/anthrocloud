using AnthroCloud.Entities;
using System;
using System.Threading.Tasks;

namespace AnthroCloud.UI.Blazor.Services
{
    public interface IAnthroStatsService
    {
        Task<Tuple<double, double>> GetWFA(double weight, string ageInDays, Sexes sex);
        Task<Tuple<double, double>> GetMUAC(double muac, string ageInDays, Sexes sex);
        Task<Tuple<double, double>> GetBFA(double bmi, string ageInDays, Sexes sex);
        Task<Tuple<double, double>> GetHCA(double headCircumference, string ageInDays, Sexes sex);
        Task<Tuple<double, double>> GetHFA(double height, string ageInDays, Sexes sex);
        Task<Tuple<double, double>> GetLFA(double lenght, string ageInDays, Sexes sex);
        Task<Tuple<double, double>> GetSFA(double subScapularSkinfold, string ageInDays, Sexes sex);
        Task<Tuple<double, double>> GetTFA(double tricepsSkinfold, string ageInDays, Sexes sex);
        Task<Tuple<double, double>> GetWFH(double weight, double height, Sexes sex);
        Task<Tuple<double, double>> GetWFL(double weight, double length, Sexes sex);
        Task<Outputs> GetScores(Inputs inputs);
    }
}
