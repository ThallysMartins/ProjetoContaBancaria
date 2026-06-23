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
        public void Render()
        {
            float rendimento = 2f / 100f * Saldo;
            Saldo = Saldo + rendimento;
        }
    }
}
