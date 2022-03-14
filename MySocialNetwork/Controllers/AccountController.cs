using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySocialNetwork.Models;
using MySocialNetwork.Repository;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

namespace MySocialNetwork.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _repository;
        private readonly IMapper _mapper;
        public AccountController(IAccountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// list accounts
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<ActionResult> Details(int count)
        {
            var details = await _repository.ReadAccountsAsync(count, new CancellationToken());
            return Ok(details);
        }

        /// <summary>
        /// register new
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Register(AccountRegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var account = _mapper.Map<AccountRegisterModel, Account>(model);
            await _repository.RegisterAsync(account, new CancellationToken());
            return Ok();
        }

        /// <summary>
        /// subscibe customers
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Subscribe(SubscribeRegisterModel model)
        {
            var subscribeModel = _mapper.Map<SubscribeRegisterModel, SubscribeModel>(model);
            await _repository.SibscribeAsync(subscribeModel, new CancellationToken());
            return Ok();
        }       
    }
}
