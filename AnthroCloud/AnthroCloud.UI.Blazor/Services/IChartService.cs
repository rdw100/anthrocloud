using AnthroCloud.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnthroCloud.UI.Blazor.Services
{
    public interface IChartService
    {
        Task<List<WeightForLength>> GetAllWFL(byte id, decimal x, decimal y);
    }
}
