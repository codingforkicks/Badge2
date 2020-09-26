using SGBank.Models;
using SGBank.Models.Responses;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL.WithdrawRules
{
    public class PremiumAccountWithdrawRule : IWithdraw
    {
        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

            if(account.Type != AccountType.Premium)
            {
                response.Success = false;
                response.Message = "Error: a non premium account hit the Free Basic Withdraw Rule.  Contact IT";
                return response;
            }

            if(amount >= 0)
            {
                response.Success = false;
                response.Message = "Withdrawal amount must be negative!";
                return response;
            }

            if (account.Balance + amount < -1000)
            {
                response.Success = false;
                response.Message = "This account will overdraft more than your $1000 limit!";
                return response;
            }

            response.OldBalance = account.Balance;
            account.Balance += amount;
            response.Account = account;
            response.Amount = amount;
            response.Success = true;

            if (response.Account.Balance < -500)
            {
                response.Account.Balance -= 10;
            }

            return response;
        }
    }
}
