using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Repository
{
    public class ServicosAssociadoRepository : Repository<ServicosAssociado>, IServicosAssociadoRepository
    {
        private readonly Contexto _context;

        public ServicosAssociadoRepository(Contexto context) : base(context)
        {
            _context = context;
        }
        public int PostCadastroServicosAssociado()
        {
            ServicosAssociado ServicosAssociado = _context.ServicosAssociados.AsNoTracking().FirstOrDefault();
            return ServicosAssociado.Id;
        }
    }
}
