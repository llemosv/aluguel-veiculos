public class ControllerCategoria {
    private List<Categoria> categorias;
    private int incrementalId;

    public ControllerCategoria() {
        categorias = new List<Categoria>();
        incrementalId = 1;
    }

    public Categoria criar(Categoria categoria) {
        categoria.setId(incrementalId);
        incrementalId++;
        categorias.Add(categoria);
        return categoria;
    }

    public Categoria getCategoriaById(int id) {
        return categorias.FirstOrDefault(categoria => categoria.getId() == id);
    }

    public List<Categoria> getCategoria () {
        return categorias;
    }

    public Categoria atualizar(Categoria categoria) {
        var index = categorias.FindIndex(c => c.getId() == categoria.getId());
        if (index >= 0)
        {
            categorias[index] = categoria;
        }

        return categoria;
    }

    public Categoria deletar(int id) {
        var index = categorias.FindIndex(c => c.getId() == id);
        var categoria = categorias.FirstOrDefault(c => c.getId() == id);

         if (index >= 0)
        {
            categorias.RemoveAt(index);
            return categoria;
        }

        return null;
    }
}
