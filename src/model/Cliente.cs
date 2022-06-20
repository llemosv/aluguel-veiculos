public class Cliente {
    private int id;
    private string nome;
    private string cpf;
    private string telefone;
    private DateTime nascimento;
    private string endereco;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public string getNome() {
        return nome;
    }

    public void setNome(string nome) {
        this.nome = nome;
    }

    public string getCpf() {
        return cpf;
    }

    public void setCpf(string cpf) {
        this.cpf = cpf;
    }

    public string getTelefone() {
        return telefone;
    }

    public void setTelefone(string telefone) {
        this.telefone = telefone;
    }

    public DateTime getNascimento() {
        return nascimento;
    }

    public void setNascimento(DateTime nascimento) {
        this.nascimento = nascimento;
    }

    public string getEndereco() {
        return endereco;
    }

    public void setEndereco(string endereco) {
        this.endereco = endereco;
    }
}
