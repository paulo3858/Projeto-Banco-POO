using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Novo_Banco
{
    class ContaChequeEspecial : ContaBancaria
    {
        public decimal ChequeEspecial {get; set;}

        public ContaChequeEspecial(string nome, decimal valorInicial, decimal valorCheque) 
        {
            this.Nome = nome;

            this.Conta = NumeroSequencia.ToString();

            NumeroSequencia++;

            this.ChequeEspecial = valorCheque;

            Deposito(valorInicial, DateTime.Now, "Deposito Inicial");
        }

        public override void Saque(decimal valor, DateTime data, string obs)
        {
            if (valor > 0 && valor <= (this.Saldo + this.ChequeEspecial))
            {
                var saque = new Transacao(-valor, data, obs);
                todasTransacoes.Add(saque);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(valor), "O valor do saque nao pode ser 0 e não pode ser maior que o Cheque Especial");
            }
        }

        public override string Extrato()
        {
            var extrato = new System.Text.StringBuilder();
            decimal total = 0;
            extrato.AppendLine("Data\t\tHora\tValor\ttotal\tObs\t\t\tLimite");
            foreach (var item in todasTransacoes)
            {
                total += item.Valor;
                extrato.AppendLine($"{item.Data.ToShortDateString()}\t{item.Data.ToShortTimeString()}\t{item.Valor}\t{total}\t{item.Obs}\t{this.ChequeEspecial}");
            }
            return extrato.ToString();

        }

    }
}
