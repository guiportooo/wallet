using Microsoft.AspNetCore.Mvc;

namespace Wallet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalletController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok();
    }
}
