namespace Biblioteca;

public class Livro
{
    //Marlon Rodrigues e Vitor Hugo Ribeiro Sá
    private string _titulo;
    private string _subtitulo;
    private string _escritor;
    private string _editora;
    private string _genero;
    private int _ano;

    public string Isbn { get; init; }

    public string Titulo
    {
        get => _titulo;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Título inválido");

            _titulo = value.Trim();
        }
    }

    public string Subtitulo
    {
        get => _subtitulo;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Subtítulo inválido");

            _subtitulo = value.Trim();
        }
    }

    public string Escritor
    {
        get => _escritor;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Escritor inválido");

            _escritor = value.Trim();
        }
    }

    public string Editora
    {
        get => _editora;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Editora inválida");

            _editora = value.Trim();
        }
    }

    public string Genero
    {
        get => _genero;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Gênero inválido");

            _genero = value.Trim();
        }
    }

    public int AnoPublicacao
    {
        get => _ano;
        set
        {
            int anoAtual = DateTime.Now.Year;

            if (value < 1970 || value > anoAtual)
                throw new ArgumentException("Ano inválido");

            _ano = value;
        }
    }

    public Livro(string isbn, string titulo, string subtitulo, string escritor, string editora, string genero, int ano)
    {
        if (string.IsNullOrWhiteSpace(isbn))
        { throw new ArgumentException("ISBN inválido"); }
        Isbn = isbn.Trim();
        Titulo = titulo;
        Subtitulo = subtitulo;
        Escritor = escritor;
        Editora = editora;
        Genero = genero;
        AnoPublicacao = ano;

    }

    public void Mostrar()
    {
        Console.WriteLine($"{Titulo} - {Escritor} ({AnoPublicacao})");
    }
}
