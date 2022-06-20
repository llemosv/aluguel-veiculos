
public class Program
{
    //instanciar controllers para realizar operacoes
    private static ControllerCategoria controllerCategoria = new ControllerCategoria();
    private static ControllerCliente controllerCliente = new ControllerCliente();
    private static ControllerVeiculo controllerVeiculo = new ControllerVeiculo();
    private static ControllerAluguel controllerAluguel = new ControllerAluguel();

    public static void Main(String[] args)
    {
        //instanciar view para mostrar opcoes
        ViewConsole view = new ViewConsole();

        while (true)
        {
            view.printMenuPrincipal();
            int option = getInt();
            switch (option)
            {
                case 1:
                    // CADASTRAR
                    view.printMenuCadastrar();
                    menuCadastro();
                    break;
                case 2:
                    // PESQUISAR
                    view.printMenuPesquisar();
                    menuPesquisa();
                    break;
                case 3:
                    // APAGAR
                    view.printMenuApagar();
                    menuApagar();
                    break;
            }
        }
    }

    private static void menuCadastro()
    {
        int option = getInt();
        switch (option)
        {
            case 1:  //CADASTRO DE CATEGORIA
                cadastrarCategoria();
                break;

            case 2: //CADASTRO DE CLIENTE
                cadastrarCliente();
                break;

            case 3: //CADASTRO DE VEICUO
                cadastrarVeiculo();
                break;

            case 4: //CADASTRO DE ALUGUEL
                cadastrarAluguel();
                break;

        }
    }

    private static void menuPesquisa()
    {
        int option = getInt();
        switch (option)
        {
            case 1:  //PESQUISAR CATEGORIA
                pesquisarCategoria();
                break;

            case 2: //PESQUISAR CLIENTE
                pesquisarCliente();
                break;

            case 3: //PESQUISAR VEICUO
                pesquisarVeiculo();
                break;

            case 4: //PESQUISAR ALUGUEL
                pesquisarAluguel();
                break;
        }
    }

    private static void menuApagar()
    {
        int option = getInt();
        switch (option)
        {
            case 1:  //APAGAR CATEGORIA
                apagarCategoria();
                break;
            case 2: //APAGAR CLIENTE
                apagarCliente();
                break;
            case 3: //APAGAR VEICUO
                apagarVeiculo();
                break;
            case 4: //BAIXA ALUGUEL
                baixaAluguel();
                break;
        }
    }
    //concluido
    private static void cadastrarCategoria()
    {
        Categoria categoria = new Categoria();

        System.Console.WriteLine("DIGITE O NOME DA CATEGORIA: ");
        string nomeCategoria = Console.ReadLine();
        while (nomeCategoria.Length == 0)
        {
            System.Console.WriteLine("INSIRA UM NOME VALIDO!");
            nomeCategoria = Console.ReadLine();
        }
        categoria.setNome(nomeCategoria);

        if (controllerCategoria.criar(categoria) != null)
        {
            System.Console.WriteLine("Cadastrado: ID: " + categoria.getId() + " | NOME: " + categoria.getNome());
        }
    }
    //concluido
    private static void cadastrarCliente()
    {
        Cliente cliente = new Cliente();
        System.Console.WriteLine("DIGITE NOME: ");
        string nomeCliente = Console.ReadLine();
        while (nomeCliente.Length == 0)
        {
            System.Console.WriteLine("INSIRA UM NOME VALIDO!");
            nomeCliente = Console.ReadLine();
        }
        cliente.setNome(nomeCliente);

        System.Console.WriteLine("DIGITE CPF (APENAS NUMEROS): ");
        string cpfCliente = Console.ReadLine();
        while (cpfCliente.Length != 11)
        {
            System.Console.WriteLine("INSIRA UM CPF VALIDO!");
            cpfCliente = Console.ReadLine();
        }
        var getClientes = controllerCliente.GetClientes().Exists(x => x.getCpf() == cpfCliente);

        if (getClientes)
        {
            System.Console.WriteLine("CPF JA CADASTRADO");
        }
        else
        {
            cliente.setCpf(cpfCliente);

            System.Console.WriteLine("DIGITE TELEFONE COM DDD (EX: 34992203993): ");
            string telefoneCliente = Console.ReadLine();
            while (telefoneCliente.Length != 11)
            {
                System.Console.WriteLine("INSIRA UM TELEFONE VALIDO!");
                telefoneCliente = Console.ReadLine();
            }
            cliente.setTelefone(telefoneCliente);

            System.Console.WriteLine("DIGITE A DATA DE NASCIMENTO (EX: 27/03/2002): ");
            string nascimentoCliente = Console.ReadLine();
            while (nascimentoCliente.Length != 10)
            {
                System.Console.WriteLine("INSIRA UMA DATA VALIDA!");
                nascimentoCliente = Console.ReadLine();
            }
            DateTime nascimentoConvertido = new DateTime(int.Parse(nascimentoCliente.Split('/')[2]), int.Parse(nascimentoCliente.Split('/')[1]), int.Parse(nascimentoCliente.Split('/')[0]));
            cliente.setNascimento(nascimentoConvertido);

            System.Console.WriteLine("DIGITE O ENDEREÇO: ");
            string enderecoCliente = Console.ReadLine();
            cliente.setEndereco(enderecoCliente);

            if (controllerCliente.criar(cliente) != null)
            {
                System.Console.WriteLine("Cadastrado: ID: " + cliente.getId() + " | NOME: " + cliente.getNome()
                    + " | CPF: " + cliente.getCpf() + " | TELEFONE: " + cliente.getTelefone() + " | NASCIMENTO: "
                    + cliente.getNascimento().ToString("dd/MM/yyyy") + " | ENDEREÇO: " + cliente.getEndereco());
            }
        }
    }
    //concluido
    private static void cadastrarVeiculo()
    {
        Veiculo veiculo = new Veiculo();

        if (controllerCategoria.getCategoria().Count() == 0)
        {
            System.Console.WriteLine("NAO POSSUIMOS CATEGORIAS CADASTRADAS!");
        }
        else
        {

            System.Console.WriteLine("DIGITE ID DA CATEGORIA: ");
            System.Console.WriteLine("CATEGORIAS");
            foreach (var c in controllerCategoria.getCategoria())
            {
                System.Console.WriteLine(c.getId() + " | " + c.getNome());
            }

            int idCategorias = getInt();
            Categoria categoria = controllerCategoria.getCategoriaById(idCategorias);

            if (categoria == null) System.Console.WriteLine("CATEGORIA NAO ENCONTRADA!");
            else
            {
                veiculo.setCategoria(categoria);

                System.Console.WriteLine("DIGITE MARCA: ");
                string marcaVeiculo = Console.ReadLine();
                while (marcaVeiculo.Length < 2)
                {
                    System.Console.WriteLine("INSIRA UMA MARCA VALIDA!");
                    marcaVeiculo = Console.ReadLine();
                }
                veiculo.setMarca(marcaVeiculo);

                System.Console.WriteLine("DIGITE MODELO: ");
                string modeloVeiculo = Console.ReadLine();
                while (modeloVeiculo.Length < 2)
                {
                    System.Console.WriteLine("INSIRA UM MODELO VALIDO!");
                    modeloVeiculo = Console.ReadLine();
                }
                veiculo.setModelo(modeloVeiculo);

                System.Console.WriteLine("DIGITE A PLACA DO VEICULO (EX: CIZ9988): ");
                string placaVeiculo = Console.ReadLine();
                while (placaVeiculo.Length != 7)
                {
                    System.Console.WriteLine("INSIRA UMA PLACA VALIDA!");
                    placaVeiculo = Console.ReadLine();
                }

                var getVeiculos = controllerVeiculo.GetVeiculos().Exists(x => x.getPlaca() == placaVeiculo);

                if (getVeiculos)
                {
                    System.Console.WriteLine("VEICULO JA CADASTRADO");
                }
                else
                {
                    veiculo.setPlaca(placaVeiculo);

                    System.Console.WriteLine("DIGITE A COR DO VEICULO: ");
                    string corVeiculo = Console.ReadLine();
                    while (corVeiculo.Length < 1)
                    {
                        System.Console.WriteLine("INSIRA UMA COR VALIDA!");
                        corVeiculo = Console.ReadLine();
                    }
                    veiculo.setCor(corVeiculo);

                    System.Console.WriteLine("DIGITE O VALOR DA DIARIA DO VEICULO (EX: 50): ");
                    double valorVeiculo = getDouble();
                    veiculo.setValor(valorVeiculo);

                    if (controllerVeiculo.criar(veiculo) != null)
                    {
                        System.Console.WriteLine("Cadastrado: ID: " + veiculo.getId() + " | MARCA: " + veiculo.getMarca()
                            + " | MODELO: " + veiculo.getModelo() + " | CATEGORIA: " + veiculo.getNomeCategoria() + " | PLACA: "
                            + veiculo.getPlaca() + " | COR: " + veiculo.getCor() + " | VALOR DIARIA: R$ " + veiculo.getValor().ToString());
                    }
                }
            }

        }

    }
    //concluido
    private static void cadastrarAluguel()
    {
        Aluguel aluguel = new Aluguel();
        if (controllerCliente.GetClientes().Count() == 0)
        {
            System.Console.WriteLine("NAO POSSUIMOS CLIENTES CADASTRADOS!");
        }
        else
        {
            System.Console.WriteLine("DIGITE ID DO CLIENTE: ");
            System.Console.WriteLine("CLIENTES");
            foreach (var c in controllerCliente.GetClientes())
            {
                System.Console.WriteLine(c.getId() + " | " + c.getNome());
            }

            int idCliente = getInt();

            Cliente cliente = controllerCliente.GetClientesById(idCliente);

            aluguel.setCliente(cliente);


            if (controllerVeiculo.GetVeiculos().Count() == 0)
            {
                System.Console.WriteLine("NAO POSSUIMOS VEICULOS CADASTRADOS!");
            }
            else
            {
                System.Console.WriteLine("DIGITE ID DO VEICULO: ");
                System.Console.WriteLine("VEICULOS");
                foreach (var v in controllerVeiculo.GetVeiculos())
                {
                    System.Console.WriteLine(v.getId() + " | " + v.getModelo());
                }

                int idVeiculo = getInt();
                Veiculo veiculo = controllerVeiculo.GetVeiculosById(idVeiculo);
                aluguel.setVeiculo(veiculo);

                System.Console.WriteLine("INFORME A QUANTIDADE DE DIAS DO ALUGUEL: ");
                int qtdDiasAluguel = getInt();
                DateTime dataMomento = DateTime.Now;
                DateTime devolucaoPrevista = dataMomento.AddDays(qtdDiasAluguel);
                aluguel.setDevolucaoPrevista(devolucaoPrevista);

                System.Console.WriteLine("INFORME O ID DO TIPO DE PAGAMENTO: ");
                int i = 1;
                foreach (var elemento in Enum.GetValues(typeof(Pagamento)))
                {
                    System.Console.WriteLine($"{i}- {elemento}");
                    i++;
                }
                int idPagamento = getInt();
                Pagamento pg = (Pagamento)idPagamento - 1;
                aluguel.setPagamento(pg);

                //CALCULANDO VALOR ALUGUEL
                double valorAluguel = veiculo.getValor() * qtdDiasAluguel;
                aluguel.setValorAluguel(valorAluguel);
                // DATA DE HOJE COMO RETIRADA
                aluguel.setRetirada(dataMomento);
                aluguel.setEntrega(false); //SETA ALUGUEL COMO DEVOLUCAO PENDENTE

                string entrega = aluguel.getEntrega() == false ? "PENDENTE" : "DEVOLVIDO";

                if (controllerAluguel.criar(aluguel) != null)
                {
                    var clienteName = aluguel.getCliente();
                    System.Console.WriteLine("Cadastrado: ID: " + aluguel.getId() + " | NOME CLIENTE: " + cliente.getNome() + " | VEICULO: " + aluguel.getVeiculo().getModelo()
                        + " | DATA ALUGUEL: " + aluguel.getRetirada().ToString("dd/MM/yyyy") + " | DEVOLUCAO PREVISTA: " + aluguel.getDevolucaoPrevista().ToString("dd/MM/yyyy")
                        + " | VALOR ALUGUEL: R$" + aluguel.getValorAluguel() + " | PAGAMENTO: " + aluguel.getPagamento() + " | STATUS DEVOLUCAO: " + entrega);
                }
            }

        }


    }
    //concluido
    private static void pesquisarCategoria()
    {
        if (controllerCategoria.getCategoria().Count() == 0)
        {
            System.Console.WriteLine("NAO POSSUIMOS CATEGORIAS CADASTRADAS!");
        }
        else
        {
            System.Console.WriteLine("DIGITE ID DA CATEGORIA OU 0 PARA TODOS: ");
            int input = getInt();
            if (input == 0)
            {
                foreach (var c in controllerCategoria.getCategoria())
                {
                    System.Console.WriteLine("ID: " + c.getId() + " | NOME: " + c.getNome());
                }
            }
            else
            {
                Categoria c = controllerCategoria.getCategoriaById(input);
                if (c != null)
                {
                    System.Console.WriteLine("ID: " + c.getId() + " | NOME: " + c.getNome());
                }
                else
                {
                    System.Console.WriteLine("CATEGORIA INEXISTENTE");
                }
            }
        }
    }
    //concluido
    private static void pesquisarCliente()
    {
        if (controllerCliente.GetClientes().Count() == 0)
        {
            System.Console.WriteLine("NAO POSSUIMOS CLIENTES CADASTRADOS!");
        }
        else
        {
            System.Console.WriteLine("DIGITE ID DO CLIENTE OU 0 PARA TODOS: ");
            int input = getInt();
            if (input == 0)
            {
                foreach (var c in controllerCliente.GetClientes())
                {
                    System.Console.WriteLine("Cadastrado: ID: " + c.getId() + " | NOME: " + c.getNome() + " | CPF: " + c.getCpf() + " | TELEFONE: " + c.getTelefone() + " | NASCIMENTO: " + c.getNascimento().ToString("dd/MM/yyyy") + " | ENDEREÇO: " + c.getEndereco());
                }
            }
            else
            {
                Cliente c = controllerCliente.GetClientesById(input);
                if (c != null)
                {
                    System.Console.WriteLine("Cadastrado: ID: " + c.getId() + " | NOME: " + c.getNome() + " | CPF: " + c.getCpf() + " | TELEFONE: " + c.getTelefone() + " | NASCIMENTO: " + c.getNascimento().ToString("dd/MM/yyyy") + " | ENDEREÇO: " + c.getEndereco());
                }
                else
                {
                    System.Console.WriteLine("CLIENTE INEXISTENTE");
                }
            }
        }

    }
    //concluido
    private static void pesquisarVeiculo()
    {
        if (controllerVeiculo.GetVeiculos().Count() == 0)
        {
            System.Console.WriteLine("NAO POSSUIMOS VEICULOS CADASTRADOS!");
        }
        else
        {
            System.Console.WriteLine("DIGITE ID DO VEICULO OU 0 PARA TODOS: ");
            int input = getInt();
            if (input == 0)
            {
                foreach (var v in controllerVeiculo.GetVeiculos())
                {
                    System.Console.WriteLine("ID: " + v.getId() + " | MARCA: " + v.getMarca() + " | MODELO: "
                    + v.getModelo() + " | CATEGORIA: " + v.getNomeCategoria() + " | PLACA: " + v.getPlaca() + " | COR: "
                    + v.getCor() + " | VALOR DIARIA: R$ " + v.getValor().ToString());
                }
            }
            else
            {
                Veiculo v = controllerVeiculo.GetVeiculosById(input);
                if (v != null)
                {
                    System.Console.WriteLine("ID: " + v.getId() + " | MARCA: " + v.getMarca() + " | MODELO: "
                    + v.getModelo() + " | CATEGORIA: " + v.getNomeCategoria() + " | PLACA: " + v.getPlaca() + " | COR: "
                    + v.getCor() + " | VALOR DIARIA: R$ " + v.getValor().ToString());
                }
                else
                {
                    System.Console.WriteLine("VEICULO INEXISTENTE");
                }
            }
        }

    }
    //concluido
    private static void pesquisarAluguel()
    {
        if (controllerAluguel.getAluguel().Count() == 0)
        {
            System.Console.WriteLine("NAO POSSUIMOS ALUGUEIS CADASTRADOS!");
        }
        else
        {
            System.Console.WriteLine("DIGITE ID DO ALUGUEL OU 0 PARA TODOS: ");
            int input = getInt();
            if (input == 0)
            {
                foreach (var a in controllerAluguel.getAluguel())
                {
                    string entrega = a.getEntrega() == false ? "PENDENTE" : "DEVOLVIDO";
                    System.Console.WriteLine("Cadastrado: ID: " + a.getId() + " | NOME CLIENTE: " + a.getCliente().getNome() + " | VEICULO: " + a.getVeiculo().getModelo()
                        + " | DATA ALUGUEL: " + a.getRetirada().ToString("dd/MM/yyyy") + " | DEVOLUCAO PREVISTA: " + a.getDevolucaoPrevista().ToString("dd/MM/yyyy")
                        + " | VALOR ALUGUEL: R$" + a.getValorAluguel() + " | PAGAMENTO: " + a.getPagamento() + " | STATUS DEVOLUCAO: " + entrega);
                }
            }
            else
            {
                Aluguel a = controllerAluguel.getAluguelById(input);
                if (a != null)
                {
                    string entrega = a.getEntrega() == false ? "PENDENTE" : "DEVOLVIDO";
                    System.Console.WriteLine("Cadastrado: ID: " + a.getId() + " | NOME CLIENTE: " + a.getCliente().getNome() + " | VEICULO: " + a.getVeiculo().getModelo()
                        + " | DATA ALUGUEL: " + a.getRetirada().ToString("dd/MM/yyyy") + " | DEVOLUCAO PREVISTA: " + a.getDevolucaoPrevista().ToString("dd/MM/yyyy")
                        + " | VALOR ALUGUEL: R$" + a.getValorAluguel() + " | PAGAMENTO: " + a.getPagamento() + " | STATUS DEVOLUCAO: " + entrega);
                }
                else
                {
                    System.Console.WriteLine("ALUGUEL INEXISTENTE");
                }
            }
        }
    }
    //concluido
    private static void apagarCategoria()
    {
        if (controllerCategoria.getCategoria().Count() == 0)
        {
            System.Console.WriteLine("NAO POSSUIMOS CATEGORIAS CADASTRADAS!");
        }
        else
        {
            System.Console.WriteLine("DIGITE ID DA CATEGORIA PARA APAGAR: ");
            int input = getInt();
            Categoria c = controllerCategoria.deletar(input);
            if (c != null)
            {
                System.Console.WriteLine("CATEGORIA APAGADA: " + c.getNome());
            }
            else
            {
                System.Console.WriteLine("CATEGORIA INEXISTENTE");
            }
        }

    }
    //concluido
    private static void apagarCliente()
    {
        if (controllerCliente.GetClientes().Count() == 0)
        {
            System.Console.WriteLine("NAO POSSUIMOS CLIENTES CADASTRADOS!");
        }
        else
        {
            System.Console.WriteLine("DIGITE ID DO CLIENTE PARA APAGAR: ");
            int input = getInt();
            Cliente c = controllerCliente.deletar(input);
            if (c != null)
            {
                System.Console.WriteLine("CLIENTE APAGADO: " + c.getNome());
            }
            else
            {
                System.Console.WriteLine("CLIENTE INEXISTENTE");
            }
        }
    }
    //concluido
    private static void apagarVeiculo()
    {
        if (controllerVeiculo.GetVeiculos().Count() == 0)
        {
            System.Console.WriteLine("NAO POSSUIMOS VEICULOS CADASTRADOS!");
        }
        else
        {
            System.Console.WriteLine("DIGITE ID DO VEICULO PARA APAGAR: ");
            int input = getInt();
            Veiculo v = controllerVeiculo.deletar(input);
            if (v != null)
            {
                System.Console.WriteLine("VEICULO APAGADO: " + v.getModelo());
            }
            else
            {
                System.Console.WriteLine("VEICULO INEXISTENTE");
            }
        }

    }
    //concluido
    private static void baixaAluguel()
    {
        if (controllerAluguel.getAluguel().Count() == 0)
        {
            System.Console.WriteLine("NAO POSSUIMOS ALUGUEIS CADASTRADOS!");
        }
        else
        {
            System.Console.WriteLine("DIGITE ID DO ALUGUEL PARA DAR BAIXA: ");
            System.Console.WriteLine("ALUGUEIS");
            foreach (var aluguel in controllerAluguel.getAluguel())
            {
                string entrega = aluguel.getEntrega() == false ? "PENDENTE" : "DEVOLVIDO";
                System.Console.WriteLine("Cadastrado: ID: " + aluguel.getId() + " | NOME CLIENTE: " + aluguel.getCliente().getNome()
                    + " | DATA ALUGUEL: " + aluguel.getRetirada().ToString("dd/MM/yyyy") + " | DEVOLUCAO PREVISTA: " + aluguel.getDevolucaoPrevista().ToString("dd/MM/yyyy")
                    + " | VALOR ALUGUEL: R$" + aluguel.getValorAluguel() + " | PAGAMENTO: " + aluguel.getPagamento() + " | STATUS DEVOLUCAO: " + entrega);
            }
            int input = getInt();
            Aluguel a = controllerAluguel.getAluguelById(input);
            if (a.getEntrega())
            {
                System.Console.WriteLine("ALUGUEL JA ENTREGUE!");
            }
            else if (a != null)
            {
                a.setDevolucao(DateTime.Now);
                a.setEntrega(true);
                string entrega = a.getEntrega() == false ? "PENDENTE" : "DEVOLVIDO";
                System.Console.WriteLine("ALUGUEL ENTREGUE: ID: " + a.getId() + " | NOME CLIENTE: " + a.getCliente().getNome()
                        + " | DATA ALUGUEL: " + a.getRetirada().ToString("dd/MM/yyyy") + " | DEVOLUCAO PREVISTA: " + a.getDevolucaoPrevista().ToString("dd/MM/yyyy")
                        + " | VALOR ALUGUEL: R$" + a.getValorAluguel() + " | PAGAMENTO: " + a.getPagamento() + " | STATUS DEVOLUCAO: " + entrega);
            }
            else
            {
                System.Console.WriteLine("ALUGUEL INEXISTENTE");
            }
        }

    }

    public static int getInt()
    {
        try
        {
            return Convert.ToInt32(Console.ReadLine());
        }
        catch (System.Exception)
        {
            System.Console.WriteLine("DIGITE UMA OPÇÃO VÁLIDA!");
            return getInt();
        }
    }

    public static double getDouble()
    {
        try
        {
            return Convert.ToDouble(Console.ReadLine());
        }
        catch (System.Exception)
        {
            System.Console.WriteLine("DIGITE UM VALOR VÁLIDO!");
            return getDouble();
        }
    }
}
