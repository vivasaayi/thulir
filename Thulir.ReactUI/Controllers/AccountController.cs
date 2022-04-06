using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Thulir.Landsat.Models;
using Thulir.Landsat.Services;

namespace Thulir.ReactUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController: ControllerBase
    {
        private readonly AccountService _accountService = new AccountService();
        
        public AccountController()
        {
            
        }
        
        [HttpGet("details")]
        public async Task<AccountInfo> Details(string? userName)
        {
            if (String.IsNullOrEmpty(userName))
            {
                userName = "";
            }

            var catalog = await _accountService.GetAccountInfo(userName);
            return catalog;
        }
    }
}