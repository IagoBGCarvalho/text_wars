# Text Wars

## 📖 Descrição

Projeto pessoal criado para aplicar e praticar os conhecimentos adquiridos no meu período de treinamento como Estagiário em Desenvolvimento de Sistemas da PGJM, envolvendo tecnologias como: `C#`, `POO`, `SQLite`, `Entity`, e outras. 

Se trata de um jogo de turno retrô que roda no terminal. O Jogador se cadastra com um **Login** e **Senha** e pode criar **personagens** baseados em **classes pré-definidas** que possuem diferentes valores para **vida**, **força** e **agilidade**. Depois que dois jogadores se autenticam e criam um personagem, uma batalha de turno é iniciada. 

## Classes

O jogador pode escolher 2 classes para criar um personagem, sendo elas:

* `Guerreiro`: *100* de vida, *35* de força e *30* de agilidade
* `Mago`: *80* de vida, *20* de força e *50* de agilidade

Futuramente, mais classes serão implementadas e cada classe terá mecânicas próprias.

## 🎮 Batalha de turno

Após dois jogadores se autenticarem e selecionarem seus personagens, uma batalha de turno começará. Por enquanto, cada jogador possui 3 ações, sendo elas:

1.  **Atacar**: Diminui a vida do defensor pela força do atacante.
2.  **Defendertacar**: Na próxima vez que tormar dano, o personagem em modo de defesa recebe apenas metade do dano.
3.  **Passar**: Apenas passa a ação para o outro jogador.

Futuramente, mais ações serão implementadas.

## 🏦 Persistência de dados 

Por enquanto, os dados relacionados aos jogadores e personagens apenas é mantido durante a execução do programa, mas o banco de dados `SQLite` já está sendo implementado utilizando `Entity Framework Core`.

## 🚀 Como Jogar

Por enquanto, apenas existe uma forma de jogar o Text Wars, que é executando o código-fonte, mas futuramente será possível instalar executando os instaladores para Linux e Windows.

### Executando o código fonte

Esta é a maneira utilizada, principalmente, para ter acesso ao código do projeto.

1.  Acesse a página do [**GitHub do projeto**](https://github.com/IagoBGCarvalho/text_wars).
2.  Clique em **Code** e copie a URL caso queira clonar usando `Git`, ou faça o download do `ZIP`.
3.  **Para executar:**
      1. Descompacte o arquivo zipado do projeto
      2. Acesse o diretório descompactado pelo terminal
      3. Utilizando a CLI do dotnet, rode o projeto utilizando o comando `dotnet run` 

#### Pré-requisitos

  * [.NET](https://dotnet.microsoft.com/pt-br/download)
  * [Git](https://git-scm.com/downloads/)

Caso os pré-requisitos forem instalados mas o jogo não rodar, talvez seja necessário instalar manualmente as dependências do projeto. Seguem os comandos necessários para instalar as dependências:

```bash
dotnet add package Microsoft.EntityFrameworkCore -v 8.0.2 
```

```bash
dotnet add package Microsoft.EntityFrameworkCore.Sqlite -v 8.0.2 
```

```bash
dotnet add package Microsoft.EntityFrameworkCore.Tools -v 8.0.2 
```

Desenvolvido por Iago Batista Gomes de Carvalho como um projeto de código aberto.