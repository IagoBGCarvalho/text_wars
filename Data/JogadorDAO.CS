
namespace text_wars
{
    class JogadorDAO : IDisposable, IJogadorDAO
    {
        private Contexto contexto;
        public JogadorDAO()
        {
            this.contexto = new Contexto();
        }
        public void Adicionar(Jogador j)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Jogador j)
        {
            throw new NotImplementedException();
        }

        public IList<Jogador> Jogadores()
        {
            throw new NotImplementedException();
        }

        public void Remover(Jogador j)
        {
            throw new NotImplementedException();
        }
        
        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}