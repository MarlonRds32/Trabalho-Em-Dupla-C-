namespace Biblioteca;

public class Livro
{

    //Marlon Rodrigues e Vitor Hugo Ribeiro Sá
    public string Titulo;

    public string Autor;

    public Livro(string titulo, string autor)
    {
        if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(autor))
            throw new ArgumentException("Título ou autor inválido!");

        Titulo = titulo;
        Autor = autor;
    }

    public void Mostrar()
    {
        Console.WriteLine($"{Titulo} - {Autor}");
    }
 
}

