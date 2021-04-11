using AnthroCloud.Entities.Charts;
using System.Threading.Tasks;

namespace AnthroCloud.UI.Blazor.Services
{
    public interface IChartService
    {
        Task<string> GetBfa(byte id, byte x, double y, GraphTypes z);
        Task<string> GetHcfa(byte id, byte x, double y, GraphTypes z);
        Task<string> GetMuac(byte id, byte x, double y, GraphTypes z);
        Task<string> GetLhfa(byte id, byte x, double y, GraphTypes z);
        Task<string> GetSsfa(byte id, byte x, double y, GraphTypes z);
        Task<string> GetTsfa(byte id, byte x, double y, GraphTypes z);
        Task<string> GetWfa(byte id, byte x, double y, GraphTypes z);
        Task<string> GetWfh(byte id, double x, double y, GraphTypes z);
        Task<string> GetWfl(byte id, double x, double y, GraphTypes z);
    }
}
