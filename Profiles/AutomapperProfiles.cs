using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZedCrestBankApi.Models;

namespace ZedCrestBankApi.Profiles
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<RegisterNewWalletAccountModel, WalletAccount>() ;
            CreateMap<UpdateWalletAccountModel, WalletAccount>();
            CreateMap<WalletAccount, GetWalletAccountModel>();
        }
    }
}
