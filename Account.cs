using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    class Account
    {
        private AccountType AccountType { get; set; }
        private double Balance { get; set; }
        private double Credit { get; set; }
        private string Name { get; set; }

        public Account()
        {
            
        }

        public Account(AccountType accountType, double balance, double credit, string name)
        {
            this.AccountType = accountType;
            this.Balance = balance;
            this.Credit = credit;
            this.Name = name;
        }

        public bool ToWithdraw(double CashOutValue)
        {
            if(this.Balance - CashOutValue < (this.Credit * -1))
            {
                Console.WriteLine("Saldo insuficiente!!");
                return false;
            }

            this.Balance -= CashOutValue;

            Console.WriteLine($"\nSaldo atual da conta de {this.Name} é {this.Balance}\n");

            return true;
        }

        public void Deposit(double DepositValue)
        {
            this.Balance += DepositValue;

            Console.WriteLine($"Saldo atual da conta de {this.Name} é {this.Balance}");
        }

        public void transfer(double TransferValue, Account DestinationAccount)
        {
            if (this.ToWithdraw(TransferValue))//Reusando a função ToWithdraw para ver se tem saldo para a transferência  
            {
                DestinationAccount.Deposit(TransferValue);//Reusando a função Deposit para depositar em uma conta
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += $"TipoConta: {this.AccountType} | Nome: {this.Name} | Saldo: {this.Balance}R$ | Crédito: {this.Credit}R$ ";
            return retorno;
        }

    }
}
