using AutoMapper;
using Loans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanApplications.Profiles
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
            CreateMap<LoanApplication, LoanApplicationRequest>();
            CreateMap<LoanApplicationRequest, LoanApplication>();
        }
    }
}
