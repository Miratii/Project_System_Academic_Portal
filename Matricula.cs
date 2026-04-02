
    

namespace PortalUniversitario
{
    public class Matricula
    {
        public string RA { get; set; }
        public int DisciplinaId { get; set; }
        public DateTime DataMatricula { get; set; }

        public Matricula(string ra, int disciplinaId, DateTime data)
        {
            RA = ra;
            DisciplinaId = disciplinaId;
            DataMatricula = data;
        }
    }
}