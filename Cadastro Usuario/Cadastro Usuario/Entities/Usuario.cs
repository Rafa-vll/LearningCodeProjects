using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_Usuario.Entities
{
    public class Usuario
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
    }

    public class GerenciadorUsuarios
    {
        private List<Usuario> usuarios;

        public GerenciadorUsuarios()
        {
            usuarios = new List<Usuario>();
        }

        public void CadastrarUsuario()
        {
            Console.WriteLine("Digite o nome do usuário:");
            string nome = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome inválido. O nome não pode estar em branco.");
                return;
            }

            int codigo = usuarios.Count + 1;
            usuarios.Add(new Usuario { Codigo = codigo, Nome = nome });

            Console.WriteLine("Usuário cadastrado com sucesso.");
        }

        public void EditarUsuario(int codigo)
        {
            Usuario usuarioParaEditar = usuarios.FirstOrDefault(u => u.Codigo == codigo);

            if (usuarioParaEditar == null)
            {
                Console.WriteLine("Usuário não encontrado.");
                return;
            }

            Console.WriteLine($"Nome atual: {usuarioParaEditar.Nome}");
            Console.WriteLine("Digite o novo nome (ou deixe em branco para manter):");
            string novoNome = Console.ReadLine().Trim();

            if (!string.IsNullOrWhiteSpace(novoNome))
            {
                usuarioParaEditar.Nome = novoNome;
                Console.WriteLine("Usuário editado com sucesso.");
            }
            else
            {
                Console.WriteLine("Edição cancelada. O nome não pode estar em branco.");
            }
        }

        public void ExcluirUsuario(int codigo)
        {
            Usuario usuarioParaExcluir = usuarios.FirstOrDefault(u => u.Codigo == codigo);

            if (usuarioParaExcluir == null)
            {
                Console.WriteLine("Usuário não encontrado.");
                return;
            }

            Console.WriteLine($"Tem certeza que deseja excluir o usuário '{usuarioParaExcluir.Nome}'? (S/N)");
            string confirmacao = Console.ReadLine().Trim().ToUpper();

            if (confirmacao == "S")
            {
                usuarios.Remove(usuarioParaExcluir);
                Console.WriteLine("Usuário excluído com sucesso.");
            }
            else
            {
                Console.WriteLine("Exclusão cancelada.");
            }
        }

        public void PesquisarPorCodigo(int codigo)
        {
            Usuario usuarioEncontrado = usuarios.FirstOrDefault(u => u.Codigo == codigo);

            if (usuarioEncontrado != null)
            {
                Console.WriteLine($"Código: {usuarioEncontrado.Codigo}, Nome: {usuarioEncontrado.Nome}");
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.");
            }
        }

        public void PesquisarPorNome(string nome)
        {
            List<Usuario> usuariosEncontrados = usuarios.Where(u => u.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase)).ToList();

            if (usuariosEncontrados.Any())
            {
                foreach (var usuario in usuariosEncontrados)
                {
                    Console.WriteLine($"Código: {usuario.Codigo}, Nome: {usuario.Nome}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum usuário encontrado com esse nome.");
            }
        }

        public void ListarUsuarios()
        {
            if (usuarios.Any())
            {
                foreach (var usuario in usuarios)
                {
                    Console.WriteLine($"Código: {usuario.Codigo}, Nome: {usuario.Nome}");
                }
            }
            else
            {
                Console.WriteLine("Não há usuários cadastrados.");
            }
        }
    }
}