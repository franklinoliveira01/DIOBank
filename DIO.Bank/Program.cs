using DIO.Bank.Classes;
using DIO.Bank.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {

            string opcaoUsuario = ObterOpcaoUsuario();
            GerenciarOpcaoUsuario(opcaoUsuario);

        }

        private static void SacarDaConta()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);

        }

        private static void DepositarNaConta()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valordeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valordeposito);
        }

        private static void TransferirParaConta()
        {
            Console.Write("Digite o número da conta de origem : ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino : ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser Transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);
        }

        private static void InserirConta()
        {
            Console.WriteLine("====Inserir nova conta====");
            Console.Write("Digite 1 para Conta Física ou 2 para juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            var novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                      saldo: entradaSaldo,
                                      credito: entradaCredito,
                                      nome: entradaNome);
            listaContas.Add(novaConta);

        }

        public static void ListarContas()
        {
            Console.WriteLine("====Listar Contas====");

            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
            }

            int indice = 0;
            foreach (var conta in listaContas)
            {
                Console.WriteLine($"#{indice} - {conta}");
                indice++;
            }
        }


        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X - Sair");

            Console.WriteLine();
            string opcaousuario = Console.ReadLine();
            Console.WriteLine();
            return opcaousuario;

        }


        private static void GerenciarOpcaoUsuario(string opcao)
        {
            while (opcao.ToUpper() != "X")
            {
                switch (opcao)
                {
                    case "1":

                        ListarContas();

                        break;

                    case "2":
                        InserirConta();
                        break;

                    case "3":
                        TransferirParaConta();

                        break;

                    case "4":
                        SacarDaConta();

                        break;

                    case "5":

                        DepositarNaConta();

                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                        break;
                }

                opcao = ObterOpcaoUsuario();

            }
            Console.WriteLine("Obrigado por utilizar nossos serviços");


        }
    }
}
