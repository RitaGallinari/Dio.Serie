using System;
using System.Diagnostics;

namespace Dio.Series
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
          string opcaoUsuario = ObterOpcaoUsuario();

          while (opcaoUsuario.ToUpper() != "x")
          {
              switch (opcaoUsuario)
              {
                case "1":
                    ListarSeries();
                    break;
                case "2":
                    InserirSerie();
                    break;
                case "3":
                    AtualizarSerie();
                    break;
                case "4":
                    ExcluirSerie();
                    break;
                case "5":
                    VisualizarSerie();
                    break;
                case "c":
                    Console.Clear();
                    break;   
                  default:
                    throw new ArgumentOutOfRangeException();
              }
              opcaoUsuario = ObterOpcaoUsuario();

          }
             Console.WriteLine("Obrigado por usar nossos serviços");
             Console.ReadLine();
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries:");

            var lista = repositorio.Lista();

            if (lista.Count ==0)
            {
                Console.WriteLine("Nehuma Lista Cadastrada");
                return;   
            }
            foreach (var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1}", serie.retornaId(),serie.retornaTitulo());
            }
        }


        private static string ObterOpcaoUsuario()

        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor !!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar séries:");
            Console.WriteLine("2 - Inserir nova série:");
            Console.WriteLine("3 - Atualizar série:");
            Console.WriteLine("4 - Excluir série: ");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("c - Limpar Tela ");
            Console.WriteLine("x - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }

        private static void InserirSerie()
        {
           Console.WriteLine("Inserir nova série");

           foreach (int i in Enum.GetValues(typeof(Genero)))
           {
                Console.WriteLine("{0}.{1}", i, Enum.GetName(typeof(Genero), i));
           }
            Console.WriteLine("Digite o Gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da Série: ");
            string entradaTitulo = Console.ReadLine();
            
            Console.WriteLine("Digite o Ano da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Series novaSerie = new Series(id: repositorio.ProximoId(),
                                          genero: (Genero)entradaGenero,
                                          titulo: entradaTitulo,
                                          ano: entradaAno,
                                          descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
            }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }

        private static void AtualizarSerie()
        {
            Console.Write( "Digite o Id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            foreach (int i in  Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}.{1}", i , Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o gênero entre as opçoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Série:");
            string entradaTitulo = Console.ReadLine();
            
            Console.WriteLine("Digite o Ano da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Series atualizaSerie = new Series(id: indiceSerie,
                                         genero: (Genero)entradaGenero,
                                         titulo: entradaTitulo,
                                         ano: entradaAno,
                                         descricao: entradaDescricao);
            
            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void ExcluirSerie()
        {
            
            Console.Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorID(indiceSerie);
            Console.WriteLine(serie);
        }
    }
}
