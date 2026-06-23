/*using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoFinança
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Bem-vindo ao Gerenciador de Gastos!\nDigite o valor do seu salário:R$ ");
            float salario = Convert.ToSingle(Console.ReadLine());

            List<float> despesas= new List<float>();
            //float[] oi = new float[despesas.Count];

            bool continuar = true;

            while (continuar == true)
            {
                while (true)
                {
                    Console.Write("Adicione uma despesa: R$");

                    if (float.TryParse(Console.ReadLine(), out float valor))
                    {
                        despesas.Add(valor);
                        Console.WriteLine($"R${valor} adicionado com sucesso em Despesas.\n");
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Valor inválido! Digite apenas números.\n");
                    }
                }
                
                Console.WriteLine("Quer continuar adicionando despesas?(S/N)");
                
                bool confirma = true;

                while (confirma)
                {
                    string resposta = Console.ReadLine().ToUpper();
                    if (resposta == "N")
                    {
                        continuar = false;
                        Console.WriteLine("");
                        break;
                    }

                    else if (resposta == "S")
                    {
                        Console.WriteLine("");
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Digite apenas S ou N");
                    }
                }

                Console.WriteLine("");
                
            }

            string valoresDespesas = string.Join(", R$ ", despesas);

            Console.WriteLine($"Estas despesas foram adicionadas à lista: R$ {valoresDespesas}."));

            var despesatotal = despesas.Sum();
            Console.WriteLine($"O valor total de suas despesas é de R${despesatotal}.");
            var saldoAtual = salario - despesas.Sum();

            float limiteAlerta = salario * 0.10f;

            if (despesatotal > limiteAlerta)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Orçamento apertado!");
                Console.ResetColor();
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Orçamento seguro!");
                Console.ResetColor();
            }
        }
    }
}*/