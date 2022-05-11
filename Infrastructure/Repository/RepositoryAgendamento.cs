using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RepositoryAgendamento : RepositoryGenerics<Agendamento>, IServAgendamento
    {
        private readonly Contexto _Context;
        public RepositoryAgendamento(Contexto context)
        {
            _Context = context;
            SetContext(context);
        }

        public override async Task Add(Agendamento entity)
        {
            await _Context.Agendamento.AddAsync(entity);
            await _Context.SaveChangesAsync();
        }

        public override async Task<Agendamento> Get(long Id)
        {
            return await _Context.Agendamento
                .Include(a => a.Endereco)
                .Include(a => a.Associado)
                .Include(a => a.Conveniado)
                .Include(a => a.TipoAtendimento)
                .Where(p => p.Id == Id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public override async Task<List<Agendamento>> List(Expression<Func<Agendamento, bool>> expression)
        {
            return await _Context.Agendamento
                .Include(a => a.Endereco)
                .Include(a => a.Associado)
                .Include(a => a.Conveniado)
                .Include(a => a.TipoAtendimento)
                .Where(expression)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> ConveniadoLivre(long id, DateTime dataAtendimento)
        {
            var agendamento = await _Context.Agendamento
                .Where(p => p.ConveniadoId == id && p.DataAtendimento == dataAtendimento)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            

            return agendamento == null || agendamento.Id == 0;
        }

        public async Task<bool> AssociadoAtivo(long id)
        {
            var associado = await _Context.Associado
                .Where(a => a.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return associado != null && associado.Ativo == "S";
        }
    }
}
