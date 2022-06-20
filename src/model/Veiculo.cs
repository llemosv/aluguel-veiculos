public class Veiculo : Categoria {
    private int id;
    private string marca;
    private string modelo;
    private string placa;
    private string cor;
    private double valor;
    private Categoria categoria;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public string getMarca() {
        return marca;
    }

    public void setMarca(string marca) {
        this.marca = marca;
    }

    public string getModelo() {
        return modelo;
    }

    public void setModelo(string modelo) {
        this.modelo = modelo;
    }

    public string getPlaca() {
        return placa;
    }

    public void setPlaca(string placa) {
        this.placa = placa;
    }

    public string getCor() {
        return cor;
    }

    public void setCor(string cor) {
        this.cor = cor;
    }

    public double getValor() {
        return valor;
    }

    public void setValor(double valor) {
        this.valor = valor;
    }

    public Categoria getCategoria() {
        return categoria;
    }
    public string getNomeCategoria() {
        return categoria.getNome();
    }

    public void setCategoria(Categoria categoria) {
        this.categoria = categoria;
    }
}
