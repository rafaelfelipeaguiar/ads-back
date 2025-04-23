namespace ApiLocadora
{
    public class Filme
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nome { get; set; }
        
        public string Genero { get; set; }
    }
}
