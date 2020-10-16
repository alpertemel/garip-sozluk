using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data.Domain;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace GaripSozluk.Business.Interfaces
{
  public interface IUserService
    {
        bool Register(RegisterVM model);

        //Todo: buradaki user nesnemizi mümkünse hiçbir zaman ui tarafına dönmeyelim. çünkü hashlenmiş dahi olsa password dönebilir, gözden kaçabilir. 
        User GetUser(ClaimsPrincipal user);

        bool Login(LoginVM model);
    }
}
