public class ControllerCliente {
    private List<Cliente> clientes;
    private int incrementalId;

    public ControllerCliente() {
        clientes = new List<Cliente> ();
        incrementalId = 1;
    }

    public Cliente criar(Cliente cliente) {
        cliente.setId(incrementalId);
        incrementalId ++;
        clientes.Add(cliente);
        return cliente;
    }

    public List<Cliente> GetClientes() {
        return clientes;
    }

    public Cliente GetClientesById(int id) {
        return clientes.FirstOrDefault(cliente => cliente.getId() == id);
    }

    public Cliente atualizar(Cliente cliente) {
        var index = clientes.FindIndex(c => c.getId() == cliente.getId());
        if (index >= 0)
        {
            clientes[index] = cliente;
        }

        return cliente;
    }

    public Cliente deletar(int id) {
        var index = clientes.FindIndex(c => c.getId() == id);
        var cliente = clientes.FirstOrDefault(c => c.getId() == id);

         if (index >= 0)
        {
            clientes.RemoveAt(index);
            return cliente;
        }

        return null;
    }

}
