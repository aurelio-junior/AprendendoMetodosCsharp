using System;
using System.Globalization;
using System.Linq;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Primeiro Sistema de Escola - Estudo de funções";
            string[] Nomes = new string[10];
            double[] mediaAlunos = new double[10];
            int totalDeAlunos = 0;

            MostrarMenu(Nomes, mediaAlunos, ref totalDeAlunos);

        }

        public static void MostrarMenu(string[] nomesAlunos, double[] mediaAlunos, ref int totalDeAlunos)
        {
            int Opcao;

            do
            {
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("1 - Cadastrar Aluno");
                Console.WriteLine("2 - Mostrar todos os alunos");
                Console.WriteLine("3 - Mostrar média geral dos alunos");
                Console.WriteLine("4 - Procurar aluno pelo nome");
                Console.WriteLine("5 - Sair");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.Write("Sua opção: ");
                while (!int.TryParse(Console.ReadLine(), out Opcao) || Opcao < 0 || Opcao > 5)
                {
                    Console.WriteLine("Opção inválida! Digite novamente: ");
                }
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");

                switch (Opcao)
                {
                    case 1:
                        AnimacaoCarregamento();
                        CadastrarAluno(nomesAlunos, ref totalDeAlunos);
                        break;

                    case 2:
                        AnimacaoCarregamento();
                        MostrarAlunos(nomesAlunos);
                        break;

                    case 3:
                        AnimacaoCarregamento();
                        MediaGeral(nomesAlunos, mediaAlunos);
                        break;
                    case 4:
                        ProcurarAluno(nomesAlunos);
                        break;
                }
            } while (Opcao!=5);

        }

        public static void CadastrarAluno(string[] Nomes, ref int totalDeAlunos)
        {
            int quantidade;

            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.Write("Quantos alunos irá cadastrar nesta turma: ");
            while (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade <= 0)
            {
                Console.Write("Digite um número válido! Tente novamente: ");
            }
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            for (int i = 0; i < quantidade && totalDeAlunos < Nomes.Length; i++)
            {
                Console.Write($"Nome do {i + 1}º aluno: ");
                Nomes[totalDeAlunos] = Console.ReadLine();
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            }

            AnimacaoCarregamento();
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("Alunos cadastrados");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("Pressione Enter para prosseguir!");
            Console.ReadLine();
            Console.Clear();
        }

        public static void MostrarAlunos(string[] nomesAlunos)
        {
            AnimacaoCarregamento();
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.Write($"Alunos registrados nesta turma: {string.Join(", ", nomesAlunos.Where(n => !string.IsNullOrEmpty(n)))}\n");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("Pressione Enter para prosseguir!");
            Console.ReadLine();
            Console.Clear();
        }

        public static void MediaGeral(string[] nomesAlunos, double[] MediaAlunos)
        {
            double Media = 0;
            int quantidade = 0;

            for (int i = 0; i < nomesAlunos.Length; i++)
            {
                if (string.IsNullOrEmpty(nomesAlunos[i]))
                {
                    continue;
                }
                Console.Write($"Nota do aluno {nomesAlunos[i]}: ");
                while (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out MediaAlunos[i]))
                {
                    Console.Write("Nota inválida! Digite novamente: ");
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                }
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Media += MediaAlunos[i];
                quantidade++;
            }

            Media /= quantidade;

            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            AnimacaoCarregamento();
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine($"Média geral da turma é de: {Media.ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("Pressione Enter para prosseguir!");
            Console.ReadLine();
            Console.Clear();
        }

        public static void ProcurarAluno(string[] nomesAlunos)
        {
            string Nome;
            bool Encontrado = false;

            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.Write("Qual nome deseja procurar: ");
            Nome = Console.ReadLine();
            AnimacaoCarregamento();

            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");

            for (int i = 0; i < nomesAlunos.Length; i++)
            {
                if (Nome.ToLower() ==  nomesAlunos[i].ToLower())
                {
                    Console.WriteLine($"Aluno {Nome} encontrado nesta turma!");
                    Encontrado = true;
                    break;
                }
            }
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");

            if (!Encontrado)
            {
                Console.WriteLine($"Aluno {Nome} não permanece nesta turma!");
            }
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("Pressione Enter para prosseguir!");
            Console.ReadLine();
            Console.Clear();
        }

        public static void AnimacaoCarregamento()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Carregando");
            for (int i = 0; i < 4; i++)
            {
                Console.Write(".");
                Thread.Sleep(500);
            }
            Console.WriteLine("\n=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-\n");
            Console.ForegroundColor= ConsoleColor.White;
            Console.Clear();
        }
    }
}