
public class ControllerAluguel
{
    private List<Aluguel> alugueis;
    private int incrementalId;

    public ControllerAluguel()
    {
        alugueis = new List<Aluguel>();
        incrementalId = 1;
    }

    public Aluguel criar(Aluguel aluguel)
    {
        aluguel.setId(incrementalId);
        incrementalId++;
        alugueis.Add(aluguel);
        return aluguel;
    }

    public List<Aluguel> getAluguel()
    {
        return alugueis;
    }

    public Aluguel getAluguelById(int id)
    {
        return alugueis.FirstOrDefault(aluguel => aluguel.getId() == id);
    }

    public Aluguel atualizar(Aluguel aluguel)
    {
        var index = alugueis.FindIndex(a => a.getId() == aluguel.getId());

        if (index >= 0)
        {
            alugueis[index] = aluguel;
        }

        return aluguel;
    }

    public Aluguel deletar(int id)
    {
        var index = alugueis.FindIndex(a => a.getId() == id);
        var aluguel = alugueis.FirstOrDefault(a => a.getId() == id);

        if (index >= 0)
        {
            alugueis.RemoveAt(index);
            return aluguel;
        }

        return null;
    }
}
