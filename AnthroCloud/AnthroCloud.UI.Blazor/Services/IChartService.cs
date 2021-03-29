using AnthroCloud.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnthroCloud.UI.Blazor.Services
{
    public interface IChartService
    {
        Task<List<WeightForLength>> GetAllWFL(byte id, double x, double y);
        Task<string> GetAllWFLJson(byte id, double x, double y);
    }
}
