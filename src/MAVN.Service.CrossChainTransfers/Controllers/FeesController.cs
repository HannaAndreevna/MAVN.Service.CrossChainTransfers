using System.Net;
using System.Threading.Tasks;
using MAVN.Service.CrossChainTransfers.Client;
using MAVN.Service.CrossChainTransfers.Client.Models.Enums;
using MAVN.Service.CrossChainTransfers.Client.Models.Requests;
using MAVN.Service.CrossChainTransfers.Client.Models.Responses;
using MAVN.Service.CrossChainTransfers.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace MAVN.Service.CrossChainTransfers.Controllers
{
    [ApiController]
    [Route("api/fees")]
    public class FeesController : ControllerBase, IFeesApi
    {
        private readonly IFeesService _feesService;

        public FeesController(IFeesService feesService)
        {
            _feesService = feesService;
        }

        /// <summary>
        /// Get transfers to public fee
        /// </summary>
        /// <returns></returns>
        [HttpGet("transfer-to-public")]
        [ProducesResponseType(typeof(TransferToPublicFeeResponse), (int)HttpStatusCode.OK)]
        public async Task<TransferToPublicFeeResponse> GetTransferToPublicFeeAsync()
        {
            var fee = await _feesService.GetTransfersToPublicFeeAsync();

            return new TransferToPublicFeeResponse { Fee = fee };
        }

        /// <summary>
        /// Set transfers to public fee
        /// </summary>
        /// <param name="request"></param>
        [HttpPost("transfer-to-public")]
        [ProducesResponseType(typeof(SetTransferToPublicFeeResponse), (int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<SetTransferToPublicFeeResponse> SetTransferToPublicFeeAsync(SetTransferToPublicFeeRequest request)
        {
            var result = await _feesService.SetTransfersToPublicFeeAsync(request.Fee);

            return new SetTransferToPublicFeeResponse { Error = (FeesErrorCodes)result };
        }
    }
}
