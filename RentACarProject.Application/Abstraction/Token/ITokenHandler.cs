using RentACarProject.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Abstraction.Token
{
    public interface ITokenHandler
    {
        Application.ViewModel.Token.Token CreateAccessToken(AppUser user,int minute = 5);
    }
}
