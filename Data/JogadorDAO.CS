
namespace text_wars
{
    class JogadorDAO : IJogadorDAO
    {
        private Contexto contexto;
        public JogadorDAO(Contexto contextoExterno)
        {
            this.contexto = contextoExterno;
        }

        public void Adicionar(Jogador j)
        {
            contexto.Jogador.Add(j);
            contexto.SaveChanges();
        }

        public void Atualizar(Jogador j)
        {
            contexto.Jogador.Update(j);
            contexto.SaveChanges();
        }

        public IList<Jogador> Jogadores()
        {
            var jogadores = contexto.Jogador.ToList();
            return jogadores;
        }

        public void Remover(Jogador j)
        {
            contexto.Jogador.Remove(j);
            contexto.SaveChanges();
        }

        public Jogador? BuscarPorLogin(string login)
        {
            return contexto.Jogador.FirstOrDefault(j => j.Login == login);
        }
    }
}