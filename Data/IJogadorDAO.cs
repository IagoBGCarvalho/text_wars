namespace text_wars;

public interface IJogadorDAO
{
    void Adicionar(Jogador j); // Create
    IList<Jogador> Jogadores(); // Read
    void Atualizar(Jogador j); // Update
    void Remover(Jogador j); // Delete
}
