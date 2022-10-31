using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZedCrestBankApi.Services;

namespace ZedCrestBankApi.Controllers
{
    public class TransactionController : ControllerBase
    {
        private IWalletService _walletService;
        IMapper _mapper;
        private readonly IMediator _mediator;

        public TransactionController(IWalletService walletService, IMapper mapper, IMediator mediator)
        {
            _walletService = walletService;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("createNewTrasaction")]
        public IActionResult CreateNewTransaction([FromBody] TransactionRequestDto  transactionRequestDto)
        {
            return Ok();
        }
    }
}
