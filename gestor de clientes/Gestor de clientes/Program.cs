using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Binary;

namespace Gestor_de_clientes
{
    internal class Program
    {
        
        struct Cliente
        {
            public string nome;
            public string email;
            public string cpf;
        }

        enum Menu {listagem = 1, adicionar, remover, sair};

        static void Main(string[] args)
        {
            Console.WriteLine("<<  Gestor de Clientes  >>");
            Console.WriteLine("1-listagem\n2-adicionar\n3-remover\n4-sair");
            int intop = int.Parse(Console.ReadLine());
            Menu opcao = (Menu) opcao;

            switch (opcao)
            {
                case Menu.
                
            }

        }
    }
}
