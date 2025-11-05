namespace text_wars;

public interface IClasseDAO
{
    void Adicionar(Personagem c); // Create
    IList<Personagem> Classes(); // Read
    void Atualizar(Personagem c); // Update
    void Remover(Personagem c); // Delete
}
