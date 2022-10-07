using Banking.Core.Entities;
using Banking.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public AccountsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpPost]
        [Route("user")]
        public async Task<ActionResult> Post(User user)
        {
            await this.context.Users.AddAsync(user);
            await this.context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        [Route("account")]
        public async Task<ActionResult> PostAccount(Account account)
        {
            await this.context.Accounts.AddAsync(account);
            await this.context.SaveChangesAsync();
            return Ok();
        }
    }
}
