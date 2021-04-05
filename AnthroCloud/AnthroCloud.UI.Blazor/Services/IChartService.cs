using AnthroCloud.Entities;
using AnthroCloud.Entities.Charts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnthroCloud.UI.Blazor.Services
{
    public interface IChartService
    {
        Task<string> GetAllBfaJson(byte id, byte x, double y, GraphTypes z);
        Task<string> GetAllHcfaJson(byte id, byte x, double y, GraphTypes z);
        Task<string> GetAllMuacJson(byte id, byte x, double y, GraphTypes z);
        Task<string> GetAllLhfaJson(byte id, byte x, double y, GraphTypes z);
        Task<string> GetAllSsfaJson(byte id, byte x, double y, GraphTypes z);
        Task<string> GetAllTsfaJson(byte id, byte x, double y, GraphTypes z);
        Task<string> GetAllWfaJson(byte id, byte x, double y, GraphTypes z);
        Task<string> GetAllWfhJson(byte id, double x, double y, GraphTypes z);
        Task<string> GetAllWflJson(byte id, double x, double y, GraphTypes z);
    }
}
