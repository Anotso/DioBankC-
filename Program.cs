using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {

		static List<Conta> listContas = new List<Conta>();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarContas();
						break;
					case "2":
						InserirConta();
						break;
					case "3":
						Transferir();
						break;
					case "4":
						Sacar();
						break;
					case "5":
						Depositar();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.WriteLine("Pressione Enter duas vezes para sair.");
			Console.ReadLine();
		}

		private static void Depositar()
		{
			Console.Write("Digite o número da conta: ");
			int indiceConta;
			if (!Int32.TryParse(Console.ReadLine(), out indiceConta))
			{
				throw new InvalidOperationException("Formato da conta inválida");
			}

			Console.Write("Digite o valor a ser depositado: ");
			double valorDeposito;
			if (!Double.TryParse(Console.ReadLine(), out valorDeposito))
			{
				throw new InvalidOperationException("Saldo informado no formato inválido");
			}

			listContas[indiceConta].Depositar(valorDeposito);
		}

		private static void Sacar()
		{
			Console.Write("Digite o número da conta: ");
			int indiceConta;
			if (!Int32.TryParse(Console.ReadLine(), out indiceConta))
			{
				throw new InvalidOperationException("Formato da conta inválida");
			}

			Console.Write("Digite o valor a ser sacado: ");
			double valorSaque;
			if (!Double.TryParse(Console.ReadLine(), out valorSaque))
			{
				throw new InvalidOperationException("Saldo informado no formato inválido");
			}

			listContas[indiceConta].Sacar(valorSaque);
		}

		private static void Transferir()
		{
			Console.Write("Digite o número da conta de origem: ");
			int indiceContaOrigem;
			if (!Int32.TryParse(Console.ReadLine(), out indiceContaOrigem))
			{
				throw new InvalidOperationException("Formato da conta inválida");
			}

			Console.Write("Digite o número da conta de destino: ");
			int indiceContaDestino;
			if (!Int32.TryParse(Console.ReadLine(), out indiceContaDestino))
			{
				throw new InvalidOperationException("Formato da conta inválida");
			}

			Console.Write("Digite o valor a ser transferido: ");
			double valorTransferencia;
			if (!Double.TryParse(Console.ReadLine(), out valorTransferencia))
			{
				throw new InvalidOperationException("Valor informado no formato inválido");
			}

			listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
		}

		private static void InserirConta()
		{
			Console.WriteLine("Inserir nova conta");

			Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
			int entradaTipoConta;
			if(!Int32.TryParse(Console.ReadLine(), out entradaTipoConta))
            {
				throw new InvalidOperationException("Tipo de conta inválida");
			}

			Console.Write("Digite o Nome do Cliente: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite o saldo inicial: ");
			double entradaSaldo;
			if(!Double.TryParse(Console.ReadLine(), out entradaSaldo)) {
				throw new InvalidOperationException("Saldo informado no formato inválido");
            }

			Console.Write("Digite o crédito: ");
			double entradaCredito;
			if (!Double.TryParse(Console.ReadLine(), out entradaCredito))
			{
				throw new InvalidOperationException("Crédito informado no formato inválido");
			}

			Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
										saldo: entradaSaldo,
										credito: entradaCredito,
										nome: entradaNome);

			listContas.Add(novaConta);
		}

		private static void ListarContas()
		{
			Console.WriteLine("Listar contas");

			if (listContas.Count == 0)
			{
				Console.WriteLine("Nenhuma conta cadastrada.");
				return;
			}

			for (int i = 0; i < listContas.Count; i++)
			{
				Conta conta = listContas[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(conta);
			}
		}

		private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
