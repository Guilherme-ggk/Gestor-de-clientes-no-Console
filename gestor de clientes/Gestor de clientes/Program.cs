using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace Gestor_de_clientes
{
    internal class Program
    {
        [System.Serializable]
        struct Cliente
        {
            public string nome;
            public string email;
            public string cpf;
        }

        static List<Cliente> clientes = new List<Cliente>();

        enum Menu {listagem = 1, adicionar, remover, sair};

        static void Main(string[] args)
        {
                Carregar();

            bool escolheuSair = false;
            while(!escolheuSair)
            {
                Console.WriteLine("<<  Gestor de Clientes  >>");
            Console.WriteLine("1-listagem\n2-adicionar\n3-remover\n4-sair");
            int intop = int.Parse(Console.ReadLine());
            Menu opcao = (Menu) intop;

            switch (opcao)
            {
                    case Menu.listagem:
                        Listagem();
                    break;
                    case Menu.adicionar:
                        Adicionar();
                    break;
                    case Menu.remover:
                        Remover();
                    break;
                    case Menu.sair:
                        escolheuSair = true;
                    break;
                
            }
                Console.Clear();
            }
        }
        static void Adicionar()
        {
                Cliente cliente = new Cliente();

                Console.WriteLine("Adicionando Clientes");

                Console.WriteLine("Nome:");
                cliente.nome = Console.ReadLine();

                Console.WriteLine("Email:");
                cliente.email = Console.ReadLine();

                Console.WriteLine("CPF:");
                cliente.cpf = Console.ReadLine();

                clientes.Add(cliente);
                Salvar();

                Console.WriteLine("Cliente adicionado com sucesso!");
                Console.WriteLine("aperte enter para voltar ao menu.");
        }
        static void Listagem()
        {
            Console.WriteLine("Listagem de Clientes");
            int id = 0;
            if(clientes.Count > 0)
            {
                

                foreach (var cliente in clientes)
                {
                    
                    Console.WriteLine($"Nome: {id}");
                    Console.WriteLine($"Nome: {cliente.nome}");
                    Console.WriteLine($"Email: {cliente.email}");
                    Console.WriteLine($"CPF: {cliente.cpf}");
                    id++;
                }
            }
            else
            {
                Console.WriteLine("Nenhum cliente cadastrado!");
                Console.WriteLine("aperte enter para voltar ao menu.");
            }
            Console.ReadLine();
        }
        static void Remover()
        {
            Listagem();
            Console.WriteLine("Escolha um cliente para remover (id):");
            int id = int.Parse(Console.ReadLine());
            if(id >= 0 && id < clientes.Count)
            {
                clientes.RemoveAt(id);
                Salvar();
            }
        }
        static void Salvar()
        {
            FileStream fileStream = new FileStream("clientes.dados", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(fileStream, clientes);
            
            fileStream.Close();
        }
        static void Carregar()
        {
            FileStream fileStream = new FileStream("clientes.dados", FileMode.OpenOrCreate);
            try
            {
                BinaryFormatter encoder = new BinaryFormatter();

                clientes = (List<Cliente>)encoder.Deserialize(fileStream);
                if(clientes == null)
                {
                    clientes = new List<Cliente>();
                }
                
            }
            catch (Exception)
            {
                clientes = new List<Cliente>();
            }
            fileStream.Close();
        }
    }
}
