namespace uab.server.Entities
{
    public class Asignatura
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Total { get; set; }
        public Usuario Usuario { get; set; }
        public Materia Materia { get; set; }
    }
}
