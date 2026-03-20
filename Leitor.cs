namespace Biblioteca;
public class Leitor
{

    //Marlon Rodrigues e Vitor Hugo Ribeiro Sá
    public string Nome;

    public string CPF;

    public List<Livro> Livros;

    public Leitor(string nome, string cpf)
    {
        Nome = nome;
        CPF = cpf;
        Livros = new List<Livro>();
    }
}