# DioBankC#
Aplicação desenvolvida no bootcamp da Digital Innovarion One em parceria com a Localiza.



### Recursos do sistema:

* Armazenamento das contas numa lista contendo o nome, tipo da conta (pessoa física ou jurídica), saldo e crédito;
* Transações de saque, deposito e transferência;
* Validação na entrada no tipo da conta e nos valores (implementação criada por mim).



### Requisitos do Sistema:

* .Net 5.0

### Funções:

* Menu inicial:

  ​	Este trecho de código é responsável pela impressão das opções iniciais da interação do usuário com o projeto.

  `

  ```
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
  ```
  `

* Listagem das contas:

  ​	Este recurso faz a impressão de todas as contas que estão presentes na variável do tipo <list> chamada de "listContas".

  `

  ```
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
  ```

`

​	

* Inserir uma nova conta:

  ​	Nesta parte de inserção de conta realizei a implementação da validação na entrada do tipo da conta e nos valores do saldo e crédito. Por se tratar de uma aplicação que roda direto do terminal utilizei o recurso de retorno de erro de operação inválida disponível na linguagem de programação.

  `

  ```
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
  ```
  `

* Transferir:

  ​	Nesta função o usuário informa das duas contas que irá participar da transação. Primeiro deverá fornecer a conta de origem, em seguida a de destino e por último o valor. O calculo e a validação se é possível executar a transação encontra-se dentro da classe do objeto Conta.

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

* Sacar:

  ​	Executa a transação de saque recebendo a conta e o valor a ser retirado. O calculo é executado dentro da classe do objeto Conta e a validação se é possível executar a tarefa.

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

* Depositar:

  ​	Realiza o acréscimo do valor na conta informada utilizando uma função existente na classe do objeto Conta.

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



### Classe Conta:

​	A classe, Conta.cs, recebe e trata os dados do arquivo Program.cs e executa conforme a chamada. Neste arquivo encontra-se a função que calcula o saque, deposito e transferência de valores entre contas, além da aplicação de um Enum que trata o tipo da conta informada.