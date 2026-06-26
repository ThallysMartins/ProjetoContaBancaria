using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinança
{
    public abstract class ContaBancaria
    {
        public string Titular { get; private set; }
        public float Saldo { get; protected set; }
        public List<string> HistoricoExtrato { get; set; } = new List<string>();


        public ContaBancaria(string Nome, float saldoInicial)
        {
            Titular = Nome;
            Saldo = saldoInicial;
        }

        public void ExibirStatus()
        {
            Console.WriteLine($"Titular: {Titular} | Saldo: {Saldo}");
        }

        public void ExibirHistorico()
        {
            Console.Clear();
            Console.WriteLine("=== Extrato Bancário ===");

            if (HistoricoExtrato.Count() == 0)
            {
                Console.WriteLine("Nenhuma tansação foi realizada nesta conta até o momento.");
            }

            else
            {
                foreach (string tansacao in HistoricoExtrato)
                {
                    string[] partes = tansacao.Split('|');

                    Console.Write(partes[0]);

                    if (partes[0].Contains("DEPOSITO") || partes[0].Contains("RENDEU"))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    else if ((partes[0].Contains("SAQUE") || partes[0].Contains("DESCONTO")))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.Write(partes[1]);
                    Console.ResetColor();
                    Console.WriteLine();
                }
            }

            Console.WriteLine("\n=====================");
            Console.WriteLine("Pressione ENTER para voltar ao menu principal.");
            Console.ReadLine();
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
                        HistoricoExtrato.Add($"[DEPOSITO] | +R${deposito}");
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
                        HistoricoExtrato.Add($"[SAQUE] | -R${saque}");
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

        public abstract void CalcularRendimentos();
    }
}
