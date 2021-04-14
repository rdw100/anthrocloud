using AnthroCloud.Entities;
using System.Threading.Tasks;

namespace AnthroCloud.UI.Blazor.Services
{
    public interface IAnthroService
    {
        Task<double> GetBMI(double weight, double height);
        Task<Age> GetAge(string birth, string visit);
        Task<Outputs> GetScores(Inputs inputs);
        Task<Outputs> GetMeasuredScores(Inputs inputs);
        Task<Outputs> GetHcaScores(Inputs inputs);
        Task<Outputs> GetMuacScores(Inputs inputs);
        Task<Outputs> GetTsfScores(Inputs inputs);
        Task<Outputs> GetSsfScores(Inputs inputs);
        Task<System.Tuple<double, double>> GetWFA(double weight, string ageInDays, Sexes sex);
        Task<System.Tuple<double, double>> GetMUAC(double muac, string ageInDays, Sexes sex);
        Task<System.Tuple<double, double>> GetBFA(double bmi, string ageInDays, Sexes sex);
        Task<System.Tuple<double, double>> GetHCA(double headCircumference, string ageInDays, Sexes sex);
        Task<System.Tuple<double, double>> GetHFA(double height, string ageInDays, Sexes sex);
        Task<System.Tuple<double, double>> GetLFA(double length, string ageInDays, Sexes sex);
        Task<System.Tuple<double, double>> GetSFA(double subScapularSkinfold, string ageInDays, Sexes sex);
        Task<System.Tuple<double, double>> GetTFA(double tricepsSkinfold, string ageInDays, Sexes sex);
        Task<System.Tuple<double, double>> GetWFH(double weight, double height, Sexes sex);
        Task<System.Tuple<double, double>> GetWFL(double weight, double length, Sexes sex);
    }
}
