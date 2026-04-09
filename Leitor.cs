namespace Biblioteca;

public class Leitor
{

    //Marlon Rodrigues e Vitor Hugo Ribeiro Sá
    private string _nome;
    private string _cpf;
    private int _idade;

    private string _email;
    private string _telefone;

    private List<Livro> _livros = new List<Livro>();
    public IReadOnlyList<Livro> Livros => _livros;

    public string Nome
    {
        get => _nome;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Nome Inválido");
            }
            _nome = value.Trim();
        }
    }

    public string CPF
    {
        get => _cpf;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("CPF Inválido");
            }
            _cpf = value.Trim();

            var cpfFormatado = value.Trim();
            if (cpfFormatado.Length != 11 || !cpfFormatado.All(char.IsDigit))
            {
                throw new ArgumentException("CPF deve conter exatamente 11 dígitos numéricos");
            }
        }
    }

    public int Idade
    {
        get => _idade;
        set
        {
            if (value < 0)
                throw new ArgumentException("Idade não pode ser negativa");

            _idade = value;
        }
    }
    public string Email
    {
        get => _email;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Email inválido");

            _email = value.Trim();

            string emailFormatado = value.Trim();
            if (!emailFormatado.Contains("@"))
                throw new ArgumentException("Email deve conter '@'");

            _email = emailFormatado;

        }

    }

    public string Telefone
    {
        get => _telefone;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Telefone inválido");

            _telefone = value.Trim();

            string telefoneFormatado = value.Trim();

            if (telefoneFormatado.Length < 11)
                throw new ArgumentException("Telefone deve ter pelo menos 11 dígitos");

            _telefone = telefoneFormatado;
        }
    }

    public Leitor(string nome, string cpf, int idade, string email = "", string telefone = "")
    {
        Nome = nome;
        CPF = cpf;
        Idade = idade;
        Email = email;
        Telefone = telefone;
    }

    public void AdicionarLivro(Livro livro)
    {
        _livros.Add(livro);
    }

    public void RemoverLivro(Livro livro)
    {
        _livros.Remove(livro);
    }

}

