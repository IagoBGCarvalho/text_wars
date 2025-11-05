namespace text_wars;

public interface IPersonagemDAO
{
    void Adicionar(); // Create
    IList<Personagem> Personagens(); // Read
    void Atualizar(); // Update
    void Remover(); // Delete
}
