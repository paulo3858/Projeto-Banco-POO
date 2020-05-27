using System;

namespace Novo_Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
               
                int sair = 0;
                ContaChequeEspecial conta = new ContaChequeEspecial("teste", 10, 0);
                ContaBancaria conta2 = new ContaBancaria("teste", 10);

                while (sair == 0)
                {
                    Console.WriteLine("============Opções==============");
                    Console.WriteLine("0 - Sair");
                    Console.WriteLine("1 - Criar uma nova conta:");
                    Console.WriteLine("2 - Criar uma nova Conta Especial:");

                    int opcao = int.Parse(Console.ReadLine());
                    int option = -1;
                    int saida = 1;
                    if (opcao == 0)
                    {
                        sair = 1;
                    } else if(opcao == 1)
                    {
                        while (saida == 1)
                        {
                            if (option == -1)
                            {
                                Console.Clear();
                                Console.WriteLine("======Abertura de nova conta=======");
                                Console.WriteLine("Digite o nome do novo correntista: ");
                                string nome = Console.ReadLine();
                                Console.WriteLine("Digite o valor do primeiro depósito: ");
                                decimal valor = decimal.Parse(Console.ReadLine());
                                conta2 = new ContaBancaria(nome, valor);
                                Console.WriteLine($" Numero da nova conta  é {conta2.Conta} do {conta2.Nome} saldo é de {conta2.Saldo}");
                            }
                            ImprimeOpcoes();
                            option = int.Parse(Console.ReadLine());
                            if(option == 0)
                            {
                                Console.Clear();
                                saida = 0;
                                sair = 1;
                            }
                            else if (option == 1)
                            {
                                Console.Clear();
                                saida = 0;
                            }
                            else if (option == 2)
                            {
                                Console.Clear();
                                Console.WriteLine("======Novo depósito=======");
                                Console.WriteLine("Digite o valor a ser depositado: ");
                                decimal valor = decimal.Parse(Console.ReadLine());
                                conta2.Deposito(valor, DateTime.Now, "Deposito        ");
                                Console.WriteLine("Deposito realizado com sucesso! ");
                            }
                            else if (option == 3)
                            {
                                Console.Clear();
                                Console.WriteLine("======Novo Saque=======");
                                Console.WriteLine("Digite o valor a ser Sacado: ");
                                decimal valor = decimal.Parse(Console.ReadLine());
                                conta2.Saque(valor, DateTime.Now, "Saque           ");
                                Console.WriteLine("Saque o realizado com sucesso! ");
                            }
                            else if (option == 4)
                            {
                                Console.Clear();
                                Console.WriteLine(conta2.Extrato());
                            }

                        }
                    } else if(opcao == 2)
                    {
                        while (saida == 1)
                        {
                            if (option == -1)
                            {
                                Console.Clear();
                                Console.WriteLine("======Abertura de nova conta=======");
                                Console.WriteLine("Digite o nome do novo correntista: ");
                                string nome = Console.ReadLine();
                                Console.WriteLine("Digite o valor do primeiro depósito: ");
                                decimal valor = decimal.Parse(Console.ReadLine());
                                Console.WriteLine("Digite o valor do cheque Especial: ");
                                decimal cheque = decimal.Parse(Console.ReadLine());
                                conta = new ContaChequeEspecial(nome, valor, cheque);
                                Console.WriteLine($" Numero da nova conta  é {conta.Conta} do {conta.Nome} saldo é de {conta.Saldo} Limite é de {conta.ChequeEspecial}");
                            }
                            ImprimeOpcoes();
                            option = int.Parse(Console.ReadLine());
                            if (option == 0)
                            {
                                Console.Clear();
                                saida = 0;
                                sair = 1;
                            }
                            else if (option == 1)
                            {
                                Console.Clear();
                                saida = 0;
                            }
                            else if (option == 2)
                            {
                                Console.Clear();
                                Console.WriteLine("======Novo depósito=======");
                                Console.WriteLine("Digite o valor a ser depositado: ");
                                decimal valor = decimal.Parse(Console.ReadLine());
                                conta.Deposito(valor, DateTime.Now, "Deposito        ");
                                Console.WriteLine("Deposito realizado com sucesso! ");
                            }
                            else if (option == 3)
                            {
                                Console.Clear();
                                Console.WriteLine("======Novo Saque=======");
                                Console.WriteLine("Digite o valor a ser Sacado: ");
                                decimal valor = decimal.Parse(Console.ReadLine());
                                conta.Saque(valor, DateTime.Now, "Saque           ");
                                Console.WriteLine("Saque o realizado com sucesso! ");
                            }
                            else if (option == 4)
                            {
                                Console.Clear();
                                Console.WriteLine(conta.Extrato());
                            }

                        }

                    }
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static public void ImprimeOpcoes()
        {
            Console.WriteLine("============Opções==============");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("1 - Criar uma nova conta:");
            Console.WriteLine("2 - Fazer um Deposito");
            Console.WriteLine("3 - Fazer um Saque:");
            Console.WriteLine("4 - Tirar um Extrato");
            Console.WriteLine("================================");
            Console.WriteLine("Escolha uma das opções: ");

        }
    }
}