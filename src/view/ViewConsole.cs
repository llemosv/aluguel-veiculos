
public class ViewConsole
{
    public void printMenuPrincipal()
    {
        System.Console.WriteLine();
        System.Console.WriteLine("ESCOLHA UMA OPÇÃO:");
        System.Console.WriteLine("1: CADASTRAR");
        System.Console.WriteLine("2: PESQUISAR");
        System.Console.WriteLine("3: APAGAR / DAR BAIXA ALUGUEL");
    }

    public void printMenuCadastrar()
    {
        System.Console.WriteLine();
        System.Console.WriteLine("O QUE DESEJA CADASTRAR?");
        System.Console.WriteLine("1: CATEGORIA");
        System.Console.WriteLine("2: CLIENTE");
        System.Console.WriteLine("3: VEICULO");
        System.Console.WriteLine("4: ALUGUEL");
    }

    public void printMenuPesquisar()
    {
        System.Console.WriteLine();
        System.Console.WriteLine("O QUE DESEJA PESQUISAR?");
        System.Console.WriteLine("1: CATEGORIA");
        System.Console.WriteLine("2: CLIENTE");
        System.Console.WriteLine("3: VEICULO");
        System.Console.WriteLine("4: ALUGUEL");
    }

    public void printMenuApagar()
    {
        System.Console.WriteLine();
        System.Console.WriteLine("O QUE DESEJA APAGAR / DAR BAIXA?");
        System.Console.WriteLine("1: CATEGORIA");
        System.Console.WriteLine("2: CLIENTE");
        System.Console.WriteLine("3: VEICULO");
        System.Console.WriteLine("4: ALUGUEL");
    }

}
