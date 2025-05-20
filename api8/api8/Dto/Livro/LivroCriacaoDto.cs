using api8.Dto.Vinculo;
using api8.Models;

namespace api8.Dto.Livro
{
    public class LivroCriacaoDto
    {
        public string Titulo { get; set; }
        public AutorVinculoDto Autor { get; set; }
    }
}
