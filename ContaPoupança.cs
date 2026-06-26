using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ProjetoFinança
{
    public class ContaPoupança : ContaBancaria
    {
        public ContaPoupança(string nome, int saldoInicial) : base(nome, saldoInicial)
        {
        }
        public override void CalcularRendimentos()
        {
            float rendimento = 2f / 100f * Saldo;
            Saldo = Saldo + rendimento;
            HistoricoExtrato.Add($"[RENDEU] | +R${rendimento}");
            Console.WriteLine($"Sua conta gerou um rendimento no valor de R${rendimento}. Acesse o histórico de transação para visualizar.");
        }
    }
}
