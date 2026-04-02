namespace PortalUniversitario
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Horario { get; set; }
        public string Professor { get; set; }

        public Disciplina(int id, string nome, string horario, string professor)
        {
            Id = id;
            Nome = nome;
            Horario = horario;
            Professor = professor;
        }
    }
}