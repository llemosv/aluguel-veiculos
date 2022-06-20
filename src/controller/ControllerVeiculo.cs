public class ControllerVeiculo {
    private List<Veiculo> veiculos;
    private int incrementalId;

    public ControllerVeiculo() {
        veiculos = new List<Veiculo> ();
        incrementalId = 1;
    }

    public Veiculo criar(Veiculo veiculo) {
        veiculo.setId(incrementalId);
        incrementalId++;
        veiculos.Add(veiculo);
        return veiculo;
    }

    public List<Veiculo> GetVeiculos() {
        return veiculos;
    }

    public Veiculo GetVeiculosById(int id) {
        return veiculos.FirstOrDefault(veiculo => veiculo.getId() == id);
    }

    public Veiculo atualizar(Veiculo veiculo) {
        var index = veiculos.FindIndex(v => v.getId() == veiculo.getId());
        if (index >= 0)
        {
            veiculos[index] = veiculo;
        }

        return veiculo;
    }

    public Veiculo deletar(int id) {
        var index = veiculos.FindIndex(v => v.getId() == id);
        var veiculo = veiculos.FirstOrDefault(v => v.getId() == id);

         if (index >= 0)
        {
            veiculos.RemoveAt(index);
            return veiculo;
        }

        return null;
    }
}
