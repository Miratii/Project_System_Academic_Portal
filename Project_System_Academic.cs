
namespace PortalUniversitario
{
    class Program
    {
        static List<Disciplina> disciplinasDisponiveis = new List<Disciplina>();
        static List<Matricula> minhasMatriculas = new List<Matricula>();

        static void Main(string[] args)
        {
            CarregarDadosIniciais();


            Console.WriteLine("=== LOGIN NO PORTAL ===");
            Console.Write("Por favor, digite seu nome completo: ");
            string nome = Console.ReadLine();

            Console.Write("Digite seu RA (ex: 2026001): ");
            string ra = Console.ReadLine();

            Console.Write("Digite seu curso: ");
            string curso = Console.ReadLine();

            Aluno alunoAtual = new Aluno(nome, ra, curso);


            Console.WriteLine($"Bem-vindo ao Portal Universitário, {alunoAtual.Nome}!\n");

            while (true)
            {
                Console.WriteLine("=== MENU PRINCIPAL ===");
                Console.WriteLine("1. Ver/Calcular minha média de notas");
                Console.WriteLine("2. Matricular em uma disciplina");
                Console.WriteLine("3. Visualizar meu horário de aulas");
                Console.WriteLine("4. Consultar boletim completo");
                Console.WriteLine("5. Cadastrar/Atualizar meus dados pessoais");
                Console.WriteLine("6. Ver lista de professores e contatos");
                Console.WriteLine("7. Solicitar declaração de matrícula ou histórico");
                Console.WriteLine("8. Sair");
                Console.Write("\nEscolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out int opcao))
                {
                    switch (opcao)
                    {
                        case 1: CalcularMedia(alunoAtual); break;
                        case 2: MatricularDisciplina(alunoAtual); break;
                        case 3: VisualizarHorario(alunoAtual); break;
                        case 4: ConsultarBoletim(alunoAtual); break;
                        case 5: AtualizarDadosPessoais(alunoAtual); break;
                        case 6: VerProfessores(); break;
                        case 7: SolicitarDeclaracao(alunoAtual); break;
                        case 8:
                            Console.WriteLine("Saindo do portal... Até mais!");
                            return;
                        default:
                            Console.WriteLine("Opção inválida! Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Digite apenas números!");
                }

                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void CarregarDadosIniciais()
        {
            disciplinasDisponiveis.Add(new Disciplina(1, "Algoritmos e Lógica de Programação", "Seg 08:00-10:00", "Prof. Carlos"));
            disciplinasDisponiveis.Add(new Disciplina(2, "Banco de Dados", "Ter 14:00-16:00", "Prof. Ana"));
            disciplinasDisponiveis.Add(new Disciplina(3, "Desenvolvimento Web", "Qua 10:00-12:00", "Prof. Marcos"));
            disciplinasDisponiveis.Add(new Disciplina(4, "Engenharia de Software", "Qui 08:00-10:00", "Prof. Beatriz"));
        }

        static void CalcularMedia(Aluno aluno)
        {
            Console.WriteLine("\n=== CÁLCULO DE MÉDIA ===");
            Console.WriteLine("Média simulada das disciplinas matriculadas: 7.8");
            Console.WriteLine("Status: Aprovado");
        }

        static void MatricularDisciplina(Aluno aluno)
        {
            Console.WriteLine("\n=== MATRÍCULA EM DISCIPLINA ===");
            Console.WriteLine("Disciplinas disponíveis:");
            foreach (var disc in disciplinasDisponiveis)
            {
                Console.WriteLine($"{disc.Id} - {disc.Nome} ({disc.Horario}) - {disc.Professor}");
            }

            Console.Write("Digite o ID da disciplina: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var disciplina = disciplinasDisponiveis.FirstOrDefault(d => d.Id == id);
                if (disciplina != null)
                {
                    if (!minhasMatriculas.Any(m => m.DisciplinaId == id))
                    {
                        minhasMatriculas.Add(new Matricula(aluno.RA, id, DateTime.Now));
                        Console.WriteLine($"✅ Matriculado com sucesso em: {disciplina.Nome}");
                    }
                    else
                    {
                        Console.WriteLine("Você já está matriculado nessa disciplina!");
                    }
                }
                else
                {
                    Console.WriteLine("Disciplina não encontrada!");
                }
            }
        }

        static void VisualizarHorario(Aluno aluno)
        {
            Console.WriteLine("\n=== MEU HORÁRIO DE AULAS ===");
            if (minhasMatriculas.Count == 0)
            {
                Console.WriteLine("Você ainda não está matriculado em nenhuma disciplina.");
                return;
            }

            Console.WriteLine("Disciplina\t\tHorário\t\tProfessor");
            Console.WriteLine("--------------------------------------------------");
            foreach (var mat in minhasMatriculas)
            {
                var disc = disciplinasDisponiveis.FirstOrDefault(d => d.Id == mat.DisciplinaId);
                if (disc != null)
                    Console.WriteLine($"{disc.Nome,-25} {disc.Horario}\t{disc.Professor}");
            }
        }

        static void ConsultarBoletim(Aluno aluno)
        {
            Console.WriteLine("\n=== BOLETIM COMPLETO ===");
            Console.WriteLine("Disciplina\t\tNota\tStatus");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Algoritmos\t\t8.5\tAprovado");
            Console.WriteLine("Banco de Dados\t\t7.2\tAprovado");
            Console.WriteLine("Média geral: 7.85");
        }

        static void AtualizarDadosPessoais(Aluno aluno)
        {
            Console.WriteLine("\n=== ATUALIZAR DADOS PESSOAIS ===");
            Console.Write($"Nome atual: {aluno.Nome} → Novo nome (ou Enter para manter): ");
            string novoNome = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(novoNome)) aluno.Nome = novoNome;
            Console.WriteLine("Dados atualizados com sucesso!");
        }

        static void VerProfessores()
        {
            Console.WriteLine("\n=== LISTA DE PROFESSORES ===");
            Console.WriteLine("Professor\t\tDisciplina\t\tE-mail");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Prof. Carlos\t\tAlgoritmos\t\tcarlos@uva.edu.br");
            Console.WriteLine("Prof. Ana\t\tBanco de Dados\t\tana@uva.edu.br");
            Console.WriteLine("Prof. Marcos\t\tDesenvolvimento Web\tmarcos@uva.edu.br");
        }

        static void SolicitarDeclaracao(Aluno aluno)
        {
            Console.WriteLine("\n=== DECLARAÇÃO DE MATRÍCULA ===");
            Console.WriteLine($"Aluno: {aluno.Nome}");
            Console.WriteLine($"RA: {aluno.RA}");
            Console.WriteLine($"Curso: {aluno.Curso}");
            Console.WriteLine($"Data: {DateTime.Now:dd/MM/yyyy}");
            Console.WriteLine("Declaração gerada com sucesso! (simulada)");
        }
    }
}