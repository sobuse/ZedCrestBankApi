using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZedCrestBankApi.Models;

namespace ZedCrestBankApi.Queries
{
    public class GetAllWalletQuery : IRequest<List<GetWalletAccountModel>>
    {
    }
}
