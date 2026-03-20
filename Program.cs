using System.Runtime.Intrinsics.Arm;
namespace Biblioteca;
internal class Program
{

    //Marlon Rodrigues e Vitor Hugo Ribeiro Sá
    private static void Main(string[] args)
    {
        Cadastro sistema = new Cadastro();
        bool painel = true;
        while (painel)
        {
            Console.Clear();
            Console.WriteLine("--- SISTEMA DE BIBLIOTECA  ----");
            Console.WriteLine("1. Cadastrar Novo Leitor");
            Console.WriteLine("2. Listar Todos os Leitores");
            Console.WriteLine("3. Buscar Leitor por CPF");
            Console.WriteLine("4. Editar Leitor");
            Console.WriteLine("5. Excluir Leitor");
            Console.WriteLine("6. Adicionar Livro");
            Console.WriteLine("7. Remover Livro");
            Console.WriteLine("8. Editar Livro");
            Console.WriteLine("9. Doar Livro");
            Console.WriteLine("10. Listar Livros");
            Console.WriteLine("0. Sair");
            Console.Write("\nEscolha uma opção: ");

            string opcoes = Console.ReadLine();

            switch (opcoes)
            {
                case "1":
                    Console.Write("Digite o Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Digite o CPF (apenas números): ");
                    string cpf = Console.ReadLine();
                    sistema.CadastrarLeitor(nome, cpf);
                    Console.Write("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "2":
                    Console.WriteLine("--Lista de Leitores--");
                    sistema.ListarLeitores();
                    Console.Write("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "3":
                    Console.Write("Digite o CPF do Leitor: ");
                    string BuscarCPF = Console.ReadLine();
                    var leitorEncontrado = sistema.BuscarCPF(BuscarCPF);

                    if (leitorEncontrado != null)
                    { Console.WriteLine($"Encontrado: {leitorEncontrado.Nome} (CPF: {leitorEncontrado.CPF})"); }
                    else
                    { Console.WriteLine("Leitor não localizado."); }
                    Console.Write("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "4":
                    Console.Write("Digite o CPF do Leitor a ser editado: ");
                    string cpfEditar = Console.ReadLine();
                    sistema.EditarLeitor(cpfEditar);
                    Console.Write("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "5":
                    Console.Write("Digite o CPF do Leitor a ser excluido: ");
                    string cpfExcluir = Console.ReadLine();
                    sistema.DeletarLeitor(cpfExcluir);
                    Console.Write("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "0":
                    painel = false;
                    Console.Write("Encerrando o sistema...");
                    break;

                case "6":
                    Console.Write("CPF: ");
                    string cpfLivro = Console.ReadLine();

                    Console.Write("Título: ");
                    string titulo = Console.ReadLine();

                    Console.Write("Autor: ");
                    string autor = Console.ReadLine();

                    sistema.AdicionarLivro(cpfLivro, titulo, autor);
                    Console.ReadKey();
                    break;

                case "7":
                    Console.Write("CPF do leitor: ");
                    string cpfRemover = Console.ReadLine();

                    Console.Write("Título do livro: ");
                    string tituloRemover = Console.ReadLine();

                    sistema.RemoverLivro(cpfRemover, tituloRemover);

                    Console.Write("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "8":
                    Console.Write("CPF do leitor: ");
                    string cpfEditarLivro = Console.ReadLine();

                    Console.Write("Título do livro: ");
                    string tituloEditar = Console.ReadLine();

                    sistema.EditarLivro(cpfEditarLivro, tituloEditar);

                    Console.Write("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "9":
                    Console.Write("CPF do leitor origem: ");
                    string cpfOrigem = Console.ReadLine();

                    Console.Write("CPF do leitor destino: ");
                    string cpfDestino = Console.ReadLine();

                    Console.Write("Título do livro: ");
                    string tituloDoar = Console.ReadLine();

                    sistema.DoarLivro(cpfOrigem, cpfDestino, tituloDoar);

                    Console.Write("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "10":
                    Console.Write("CPF do leitor: ");
                    string cpfListar = Console.ReadLine();

                    sistema.ListarLivrosDoLeitor(cpfListar);

                    Console.Write("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}