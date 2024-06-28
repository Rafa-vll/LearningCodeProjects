using Cadastro_Usuario.Entities;

namespace Cadastro_Usuario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GerenciadorUsuarios gerenciador = new GerenciadorUsuarios();

            while (true)
            {
                MostrarMenu();
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        gerenciador.CadastrarUsuario();
                        break;
                    case "2":
                        Console.WriteLine("Digite o código do usuário para editar:");
                        if (int.TryParse(Console.ReadLine(), out int codigoEditar))
                        {
                            gerenciador.EditarUsuario(codigoEditar);
                        }
                        else
                        {
                            Console.WriteLine("Código inválido. Digite um número válido.");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Digite o código do usuário para excluir:");
                        if (int.TryParse(Console.ReadLine(), out int codigoExcluir))
                        {
                            gerenciador.ExcluirUsuario(codigoExcluir);
                        }
                        else
                        {
                            Console.WriteLine("Código inválido. Digite um número válido.");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Digite o nome para pesquisa:");
                        string nomePesquisa = Console.ReadLine().Trim();
                        gerenciador.PesquisarPorNome(nomePesquisa);
                        break;
                    case "5":
                        gerenciador.ListarUsuarios();
                        break;
                    case "6":
                        Console.WriteLine("Digite o código do usuário para pesquisa:");
                        if (int.TryParse(Console.ReadLine(), out int codigoPesquisar))
                        {
                            gerenciador.PesquisarPorCodigo(codigoPesquisar);
                        }
                        else
                        {
                            Console.WriteLine("Código inválido. Digite um número válido.");
                        }
                        break;
                    case "7":
                        Console.WriteLine("Programa encerrado.");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1 - Cadastrar usuário");
            Console.WriteLine("2 - Editar usuário");
            Console.WriteLine("3 - Excluir usuário");
            Console.WriteLine("4 - Pesquisar usuário por nome");
            Console.WriteLine("5 - Listar todos os usuários");
            Console.WriteLine("6 - Pesquisar usuário por código");
            Console.WriteLine("7 - Sair");
            Console.Write("Opção: ");
        }
    }
}