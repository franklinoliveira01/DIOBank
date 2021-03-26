
using DIO.Bank.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Bank.Classes
{
     public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private String Nome { get; set; }
        private Double Saldo { get; set; }
        private Double Credito { get; set; }

        public Conta(TipoConta tipoConta, string nome, double saldo, double credito)
        {
            this.TipoConta = tipoConta;
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;

        }

        public bool Sacar(double valorSaque)
        {
            //Validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");

            return true;

        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");
        }

        public void Transferir(double valorTranferencia, Conta contadestino)
        {
            if (this.Sacar(valorTranferencia))
            {
                contadestino.Depositar(valorTranferencia);
            }

        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + "|";
            retorno += "Nome " + this.Nome + "|";
            retorno += "Saldo " + this.Saldo + "|";
            retorno += "Crédito " + this.Credito + "|";
            return retorno;
        }



    }
}
