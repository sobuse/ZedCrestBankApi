using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZedCrestBankApi.Models;
using ZedCrestBankApi.Queries;
using ZedCrestBankApi.Services;

namespace ZedCrestBankApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalletAccountController : ControllerBase
    {
        private IWalletService _walletService;
        IMapper _mapper;
        private readonly IMediator _mediator;

        public WalletAccountController(IWalletService walletService, IMapper mapper, IMediator mediator)
        {
            _walletService = walletService;
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpPost]
        [Route("register")]
        public IActionResult RegisterNewWallet ( [FromBody] RegisterNewWalletAccountModel newWallet )
        {
            if (!ModelState.IsValid) return BadRequest(newWallet);

            var wallet = _mapper.Map<WalletAccount>(newWallet);
            return Ok(_walletService.Create(wallet, newWallet.Pin, newWallet.ConfirmPin)) ; 
        }

        [HttpGet]
        [Route("getAllAccount")]
        public async Task<IActionResult> GetAllAccount()
        {
            var query = new GetAllWalletQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
            //var wallets = _walletService.GetAllAccounts();
            //var cleanedAccounts = _mapper.Map<IList<GetWalletAccountModel>>(wallets);
            //return Ok(cleanedAccounts);
        }

        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            if (!ModelState.IsValid) return BadRequest(model);

            //mapping
            return Ok(_walletService.Authenticate(model.WalletAccountNumber, model.Pin));
        }
    }
}
