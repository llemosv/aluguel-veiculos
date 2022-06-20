public class Aluguel
{
    private int id;
    private Cliente cliente;
    private Veiculo veiculo;
    private DateTime retirada;
    private DateTime devolucaoPrevista;
    private DateTime devolucao;
    private double valorAluguel;
    private bool aluguelEntregue;
    private Pagamento tpPagamento;

    public int getId()
    {
        return id;
    }

    public void setId(int id)
    {
        this.id = id;
    }

    public Cliente getCliente()
    {
        return cliente;
    }

    public void setCliente(Cliente cliente)
    {
        this.cliente = cliente;
    }

    public Veiculo getVeiculo()
    {
        return veiculo;
    }

    public void setVeiculo(Veiculo veiculo)
    {
        this.veiculo = veiculo;
    }

    public DateTime getRetirada()
    {
        return retirada;
    }

    public void setRetirada(DateTime retirada)
    {
        this.retirada = retirada;
    }

    public DateTime getDevolucao()
    {
        return devolucao;
    }

    public void setDevolucao(DateTime devolucao)
    {
        this.devolucao = devolucao;
    }

    public DateTime getDevolucaoPrevista()
    {
        return devolucaoPrevista;
    }

    public void setDevolucaoPrevista(DateTime devolucaoPrevista)
    {
        this.devolucaoPrevista = devolucaoPrevista;
    }

    public void setPagamento(Pagamento pagamento)
    {
        this.tpPagamento = pagamento;
    }

    public Pagamento getPagamento()
    {
        return tpPagamento;
    }

    public bool getEntrega()
    {
        return aluguelEntregue;
    }

    public void setEntrega(bool entrega)
    {
        this.aluguelEntregue = entrega;
    }

    public double getValorAluguel()
    {
        return valorAluguel;
    }

    public void setValorAluguel(double valor)
    {
        this.valorAluguel = valor;
    }
}
