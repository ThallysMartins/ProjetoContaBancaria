using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Metadata;
using System.Text;

namespace ProjetoFinança
{
    public class ContaBancaria
    {
        public string Titular { get; private set; }
        public float Saldo { get; protected set; }

        public ContaBancaria(string Nome, float saldoInicial)
        {
            Titular = Nome;
            Saldo = saldoInicial;
        }

        public void ExibirStatus()
        {
            Console.WriteLine($"Titular: {Titular} | Saldo: {Saldo}");
        }

        public void Depositar()
        {
            while (true)
            {
                Console.WriteLine("===  Deposite aqui seu dinheiro  ===");
                Console.WriteLine("Digite o valor para deposito ou aperte \"V\" para voltar.");

                string entrada = Console.ReadLine();
            
                if (entrada.ToUpper() == "V")
                {   
                    break;
                }

                if (float.TryParse(entrada, out float deposito))
                {
                    if (deposito > 0)
                    {
                        Saldo = Saldo + deposito;
                        Console.WriteLine($"Um deposito no valor de R${deposito} foi realizado. Seu novo saldo é de R${Saldo}.");
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Digite um valor maior que zero.");
                    }
                }
                
                else
                {
                    Console.WriteLine("Por favor, digite um número válido.");
                }
            }
        }

        public void Sacar()
        {
            while (true)
            {
                Console.WriteLine("=== Saque aqui seu dinheiro ===");
                Console.WriteLine("Digite o valor do saque ou digite \"V\" para sair.");

                string entrada = Console.ReadLine();

                if (entrada.ToUpper() == "V")
                {
                    break;
                }

                if (float.TryParse(entrada, out float saque))
                {
                    if (saque > 0 && Saldo > saque)
                    {
                        Saldo = Saldo - saque;
                        Console.WriteLine($"Um saque no valor de R${saque} foi realizado. Seu novo saldo é de R${Saldo}.");
                        break;
                    }

                    else if (Saldo < saque)
                    {
                        Console.WriteLine("Você não tem saldo suficiente para sacar este valor.");
                    }

                    else if (saque <= 0)
                    {
                        Console.WriteLine("Valor de saque inválido! Digite uma valor maior que zero.");
                    }
                
                }
                
                else
                {
                    Console.WriteLine("Por favor, digite um número válido.");
                }

            }
        }

        static void Main(string[] args)
        {
            ContaBancaria contaComum = new ContaBancaria("Thallys Comum", 1000);
            ContaPoupança contaPoupança = new ContaPoupança("Thallys Poupança", 500);

            //minhaConta.Escolher();
            //minhaPoupança.Escolher();

            ContaBancaria contaAtiva = contaComum;

            while (true)
            {
                Console.WriteLine($"\n === Conta Ativa: {contaAtiva.Titular}. ===");
                Console.WriteLine("=== Escolha uma opção ===");

                Console.WriteLine("1 - Exibir Saldo");


                Console.WriteLine("2 - Depositar");

                Console.WriteLine("3 - Sacar");

                if (contaAtiva == contaPoupança)
                {
                    Console.WriteLine("4 - Render Juros");
                }

                string textoAlternar = (contaAtiva == contaComum) ? "poupança" : "comum";
                Console.WriteLine($"5 - Alternar conta para {textoAlternar}");
                Console.WriteLine("0 - Sair do App");


                string escolha = Console.ReadLine();
                if (escolha == "1") contaAtiva.ExibirStatus();

                else if (escolha == "2") contaAtiva.Depositar();

                else if (escolha == "3") contaAtiva.Sacar();

                else if (escolha == "4" && contaAtiva is ContaPoupança poupança)
                {
                    poupança.Render();
                }

                else if (escolha == "5")
                {
                    // A MÁGICA DA ALTERNÂNCIA:
                    if (contaAtiva == contaComum)
                    {
                        contaAtiva = contaPoupança;
                        Console.WriteLine("\n[Sistema] Você mudou para a Conta Poupança!");
                    }
                    else
                    {
                        contaAtiva = contaComum;
                        Console.WriteLine("\n[Sistema] Você mudou para a Conta Comum!");
                    }
                }

                else if (escolha == "0") break;

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Escolha uma opção válida.");
                    Console.ResetColor();
                }
                
                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}

