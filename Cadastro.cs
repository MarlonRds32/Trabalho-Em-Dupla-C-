using System.Linq;

namespace Biblioteca;

public class Cadastro
{
    //Marlon Rodrigues e Vitor Hugo Ribeiro Sá
    private List<Leitor> listaLeitores = new List<Leitor>();
    public void CadastrarLeitor(string nome, string cpf, int idade, string email = "", string telefone = "")
    {
        if (listaLeitores.Any(l => l.CPF == cpf))
        {
            Console.WriteLine("CPF já cadastrado!");
            return;
        }
        try
        {
            Leitor novo = new Leitor(nome, cpf, idade, email, telefone);
            listaLeitores.Add(novo);
            Console.WriteLine("Leitor cadastrado!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public Leitor BuscarCPF(string cpf)
    {
        return listaLeitores.FirstOrDefault(l => l.CPF == cpf);
    }

    public void ListarLeitores()
    {
        if (listaLeitores.Count == 0)
        {
            Console.WriteLine("Nenhum leitor cadastrado!");
            return;
        }
        foreach (var l in listaLeitores)
        {
            Console.WriteLine($"{l.Nome} | CPF: {l.CPF} | Idade: {l.Idade} | Livros: {l.Livros.Count} | Email: {l.Email} | Telefone: {l.Telefone}");
        }
    }

    public void EditarLeitor(string cpf)
    {
        Leitor leitorencontrado = BuscarCPF(cpf);

        if (leitorencontrado != null)
        {
            Console.Write($"Novo nome para {leitorencontrado.Nome}: ");
            string novoNome = Console.ReadLine();

            try
            {
                leitorencontrado.Nome = novoNome;
                Console.WriteLine("Nome alterado com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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

    public void AdicionarLivro(string cpf, Livro livro)
    {
        var leitor = BuscarCPF(cpf);

        if (leitor != null)
        {
            leitor.AdicionarLivro(livro);
            Console.WriteLine("Livro adicionado!");
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
            var livro = leitor.Livros.FirstOrDefault(l => l.Titulo == titulo);

            if (livro != null)
            {
                leitor.RemoverLivro(livro);
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
            var livro = leitor.Livros.FirstOrDefault(l => l.Titulo == titulo);

            if (livro != null)
            {
                try
                {
                    Console.Write("Novo título: ");
                    string novoTitulo = Console.ReadLine();

                    Console.Write("Novo autor: ");
                    string novoAutor = Console.ReadLine();

                    Console.Write("Nova editora: ");
                    string novaEditora = Console.ReadLine();

                    Console.Write("Novo gênero: ");
                    string novoGenero = Console.ReadLine();

                    livro.Titulo = novoTitulo;
                    livro.Escritor = novoAutor;
                    livro.Editora = novaEditora;
                    livro.Genero = novoGenero;

                    Console.WriteLine("Livro atualizado!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
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
            var livro = origem.Livros.FirstOrDefault(l => l.Titulo == titulo);

            if (livro != null)
            {
                origem.RemoverLivro(livro);
                destino.AdicionarLivro(livro);

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