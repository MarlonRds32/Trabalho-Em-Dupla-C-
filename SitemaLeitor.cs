namespace Biblioteca;

public class Cadastro
{

    //Marlon Rodrigues e Vitor Hugo Ribeiro Sá
    private List<Leitor> listaLeitores = new List<Leitor>();

    public void CadastrarLeitor(string nome, string cpf)
    {
        bool jaexiste = listaLeitores.Any(l => l.CPF == cpf);

        if (jaexiste)
        {
            Console.WriteLine("Leito já existente nesse CPF!");
        }
        else
        {
            Leitor novoLeitor = new Leitor(nome, cpf);
            listaLeitores.Add(novoLeitor);
            Console.WriteLine("Leitor cadastrado com sucesso!");
        }
    }
    public Leitor BuscarCPF(string cpf)
    {
        var leitor = listaLeitores.Find(l => l.CPF == cpf);

        return leitor;
    }
    public void ListarLeitores()
    {
        if (listaLeitores.Count == 0)
        {
            Console.WriteLine("Nenhum leitor cadastrado!");
        }
        foreach (var leitor in listaLeitores)
        {
            Console.WriteLine($"Nome: {leitor.Nome} | CPF: {leitor.CPF} | Livros: {leitor.Livros.Count}");
        }
    }

    public void EditarLeitor(string cpf)
    {
        Leitor leitorencontrado = BuscarCPF(cpf);

        if (leitorencontrado != null)
        {
            Console.Write($"Novo nome para {leitorencontrado.Nome}: ");
            string novoNome = Console.ReadLine();

            leitorencontrado.Nome = novoNome;
            Console.WriteLine("Nome alterado com sucesso");
        }
        else
        {
            Console.WriteLine("Não foi possivel alterar o nome. Leitor não encontrado");
        }
    }

    public void DeletarLeitor(string cpf)
    {
        Leitor leitorapagar = BuscarCPF(cpf);

        if (leitorapagar != null)
        {
            listaLeitores.Remove(leitorapagar);
            Console.WriteLine($"Leitor {leitorapagar.Nome} deletado");
        }
        else
        {
            Console.WriteLine($"CPF não encontrado! Verefique se esse leitor realmente existe!");
        }
    }

    public void AdicionarLivro(string cpf, string titulo, string autor)
    {
        Leitor leitor = BuscarCPF(cpf);

        if (leitor != null)
        {
            Livro novoLivro = new Livro(titulo, autor);
            leitor.Livros.Add(novoLivro);
            Console.WriteLine("Livro adicionado com sucesso!");
        }
        else
        {
            Console.WriteLine("Leitor não encontrado!");
        }
    }

    public void RemoverLivro(string cpf, string titulo)
    {
        Leitor leitor = BuscarCPF(cpf);

        if (leitor != null)
        {
            var livro = leitor.Livros.Find(l => l.Titulo == titulo);

            if (livro != null)
            {
                leitor.Livros.Remove(livro);
                Console.WriteLine("Livro removido!");
            }
            else
            {
                Console.WriteLine("Livro não encontrado!");
            }
        }
        else
        {
            Console.WriteLine("Leitor não encontrado!");
        }
    }

    public void EditarLivro(string cpf, string titulo)
    {
        Leitor leitor = BuscarCPF(cpf);

        if (leitor != null)
        {
            var livro = leitor.Livros.Find(l => l.Titulo == titulo);

            if (livro != null)
            {
                Console.Write("Novo título: ");
                string novoTitulo = Console.ReadLine();

                Console.Write("Novo autor: ");
                string novoAutor = Console.ReadLine();

                livro.Titulo = novoTitulo;
                livro.Autor = novoAutor;

                Console.WriteLine("Livro atualizado!");
            }
            else
            {
                Console.WriteLine("Livro não encontrado!");
            }
        }
        else
        {
            Console.WriteLine("Leitor não encontrado!");
        }
    }

    public void DoarLivro(string cpfOrigem, string cpfDestino, string titulo)
    {
        Leitor origem = BuscarCPF(cpfOrigem);
        Leitor destino = BuscarCPF(cpfDestino);

        if (origem != null && destino != null)
        {
            var livro = origem.Livros.Find(l => l.Titulo == titulo);

            if (livro != null)
            {
                origem.Livros.Remove(livro);
                destino.Livros.Add(livro);
                Console.WriteLine("Livro transferido!");
            }
            else
            {
                Console.WriteLine("Livro não encontrado no leitor origem!");
            }
        }
        else
        {
            Console.WriteLine("Leitor não encontrado!");
        }
    }

    public void ListarLivrosDoLeitor(string cpf)
    {
        Leitor leitor = BuscarCPF(cpf);

        if (leitor != null)
        {
            if (leitor.Livros.Count == 0)
            {
                Console.WriteLine("Esse leitor não possui livros.");
            }
            else
            {
                foreach (var livro in leitor.Livros)
                {
                    livro.Mostrar();
                }
            }
        }
        else
        {
            Console.WriteLine("Leitor não encontrado!");
        }
    }

}