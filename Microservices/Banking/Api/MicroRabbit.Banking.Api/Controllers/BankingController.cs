using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroRabbit.Banking.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BankingController : ControllerBase
	{
		private readonly IAccountService _accountService;
		public BankingController(IAccountService accountService)
		{
			_accountService = accountService;
		}

		// GET api/banking
		[HttpGet]
		public ActionResult<IEnumerable<Account>> GetAccounts()
		{
			return Ok(_accountService.GetAccounts());
		}

		[HttpPost]
		public IActionResult PostAccount([FromBody] AccountTransfer accounTransfer)
		{
			_accountService.Transfer(accounTransfer);
			return Ok(accounTransfer);
		}
	}
}