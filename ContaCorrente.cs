using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinança
{
    public class ContaCorrente : ContaBancaria
    {
        public ContaCorrente(string nome, int saldoInicial) : base(nome, saldoInicial)
        {
        }
        public override void CalcularRendimentos()
        {
            int anuidade = 10;
            Saldo = Saldo - anuidade;
            HistoricoExtrato.Add($"[DESCONTO] | +R${anuidade}");
            Console.WriteLine($"Um desconto de anuidade no valor de R${anuidade} foi realizado na sua conta.");
        }
    }
}
