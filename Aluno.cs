namespace PortalUniversitario
{
    public class Aluno
    {
        public string Nome { get; set; }
        public string RA { get; set; }
        public string Curso { get; set; }

        public Aluno(string nome, string ra, string curso)
        {
            Nome = nome;
            RA = ra;
            Curso = curso;
        }
    }
}