using System.Threading.Tasks;
using MAVN.Numerics;
using MAVN.Service.CrossChainTransfers.Domain.Enums;

namespace MAVN.Service.CrossChainTransfers.Domain.Services
{
    public interface ICrossChainTransfersService
    {
        Task<TransferToExternalErrorCodes> TransferToExternalAsync(string customerId, Money18 amount);
    }
}
