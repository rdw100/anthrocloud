using AnthroCloud.Entities;
using System.Threading.Tasks;

namespace AnthroCloud.UI.Blazor.Services
{
    public interface IAnthroService
    {
        Task<AgeView> GetAge(string birth, string visit);
        Task<double> GetBMI(double weight, double height);
        Task<Outputs> GetScores(Inputs inputs);        
        Task<Outputs> GetHcaScores(Inputs inputs);
        Task<Outputs> GetMuacScores(Inputs inputs);
        Task<Outputs> GetTsfScores(Inputs inputs);
        Task<Outputs> GetSsfScores(Inputs inputs);
    }
}