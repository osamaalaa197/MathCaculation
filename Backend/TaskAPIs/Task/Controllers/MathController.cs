using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Task.Context;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {
        private readonly IRepo _repo;
        private readonly string key;
        private readonly string iv;



        public MathController(IRepo repo)
        {
            _repo = repo;
            key = "0123456789abcdef";
            iv = "0123456789abcdef";
        }
        [HttpPost]
        [Route("Calculate")]
        public IActionResult Calculate(string data)
        {
            var encryptedInput= _repo.EncryptAES(data, key, iv);
            string decryptedInput = _repo.DecryptAES(encryptedInput, key, iv);
            if (int.TryParse(decryptedInput, out int operand))
            {
                int result = 1 << operand;
                return Ok(new { Operand = operand, Result = result });
            }
            else
            {
                return BadRequest("Invalid input.");
            }
        }


    }
}
