using System;
using System.Collections.Generic;

namespace Transferencia_bancaria
{
    class Program
    {
        static List<Account> ListAccounts = new List<Account>();
        static void Main()
        {
            ////Account MyAccount = new Account(AccountType.PessoaFisica, 2000, 600, "Frederick Ferreira Aquino");
            //Console.WriteLine(MyAccount.ToString());

            try
            {
                Console.WriteLine("DIO Bank a seu dispor!!!\n Informe a opção desejada");
                Console.WriteLine("1- Listar contas\n2- Inserir nova conta\n3- Transferir\n4- sacar\n5- Depositar\nC- Limpar Tela\nX- sair");

                string getUserOption = Console.ReadLine().ToUpper();

                if (getUserOption == "1" || getUserOption == "2" || getUserOption == "3" || getUserOption == "4" || getUserOption == "5" || getUserOption.ToUpper() == "C" || getUserOption.ToUpper() == "X")
                {

                    while (getUserOption.ToUpper() != "X")
                    {
                        switch (getUserOption)
                        {
                            case "1":
                                ListarContas();
                                break;

                            case "2":
                                InserirContas();
                                break;

                            case "3":
                                Transfer();
                                break;
                            case "4":
                                ToWithdraw();
                                break;

                            case "5":
                                Deposit();
                                break;

                            case "C":
                                Console.Clear();
                                break;
                        }
                    }
                }

                else
                {
                    Console.WriteLine("\nOpção invalida\n");
                    Main();
                }
            }
            catch
            {

            }
        }

        private static void Deposit()
        {
            Console.Write("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser Depositado: ");
            double valorDeposit = double.Parse(Console.ReadLine());

            ListAccounts[indiceConta].Deposit(valorDeposit);

            Main();
        }

        private static void Transfer()
        {
            Console.Write("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o numero da conta que deseja passar: ");
            int indiceConta2 = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser Transferido: ");
            double valorTransfer = double.Parse(Console.ReadLine());

            ListAccounts[indiceConta].ToWithdraw(valorTransfer);
            ListAccounts[indiceConta2].Deposit(valorTransfer);

            Main();
        }

        private static void ToWithdraw()
        {
            Console.Write("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            ListAccounts[indiceConta].ToWithdraw(valorSaque);

            Main();
        }

        private static void InserirContas()
        {
            Console.WriteLine("\nInserir nova conta");

            Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente:  ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Account NewAccount = new Account(accountType: (AccountType)entradaTipoConta, balance: entradaSaldo, credit: entradaCredito, name: entradaNome);

            ListAccounts.Add(NewAccount);


            if (ListAccounts.Count == 0)
            {
                Console.WriteLine("\nNenhuma conta inserida\n");
            }

            else
            {
                Console.WriteLine("\nConta inserida com sucesso\n");
            }

            Main();

        }

        private static void ListarContas()
        {
            
            Console.WriteLine("Listar contas");

            if (ListAccounts.Count == 0)
            {
                Console.WriteLine("\nNenhuma conta cadastrada\n");
            }
            else
            {
                for (int i = 0; i < ListAccounts.Count; i++)
                {
                    Account account = ListAccounts[i];
                    Console.Write($"\n#{i} - ");
                    Console.Write($"{account}\n");
                }
            }
            
            Main();
        }

        
    }
}
