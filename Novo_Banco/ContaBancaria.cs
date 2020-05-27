using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Novo_Banco
{
    class ContaBancaria
    {
        public string Conta { get; set; }
        public string Nome { get; set; }
        public decimal Saldo { get
            {
                decimal saldo = 0;
                foreach (var item in todasTransacoes)
                {
                    saldo += item.Valor;
                }
                return saldo;
            }
        }

        protected static int NumeroSequencia = 86600;


        protected List<Transacao> todasTransacoes = new List<Transacao>();

        public ContaBancaria(string nome, decimal valorInicial)
        {
            this.Nome = nome;

            this.Conta = NumeroSequencia.ToString();

            NumeroSequencia++;

            Deposito(valorInicial, DateTime.Now, "Deposito Inicial");
        }
        public ContaBancaria() { }

        public void Deposito(decimal valor, DateTime data, string obs)
        {
            if(valor > 0)
            {
                var deposito = new Transacao(valor, data, obs);
                todasTransacoes.Add(deposito);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(valor), "O deposito deve ser positivo");
            }
        }

        public virtual void Saque(decimal valor, DateTime data, string obs) 
        {
            if (valor > 0 && valor <= this.Saldo)
            {
                var saque = new Transacao(-valor, data, obs);
                todasTransacoes.Add(saque);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(valor), "O valor do saque nao pode ser 0 e não pode ser maior que o saldo");
            }
        }
        
        public virtual string Extrato()
        {
            var extrato = new System.Text.StringBuilder();
            decimal total = 0;
            extrato.AppendLine("Data\t\tValor\ttotal\tObs");
            foreach(var item in todasTransacoes)
            {
                total += item.Valor;
                extrato.AppendLine($"{item.Data.ToShortDateString()}\t{item.Valor}\t{total}\t{item.Obs}");
            }
            return extrato.ToString();

        }

    }
}
