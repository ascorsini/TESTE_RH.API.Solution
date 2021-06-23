using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TESTE_RH.API.Contexto;
using TESTE_RH.API.Models;

namespace TESTE_RH.API.Controllers
{
    [Route("v1/pessoas")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        [Route("ObterTodos")]
        [HttpPost]
        public async Task<ActionResult<List<Pessoa>>> ObterTodos([FromServices] DataContext context)
        {
            var pessoas = await context.PessoaDbSet.ToListAsync();
            return pessoas;
        }

        [Route("{id:int}")]
        [HttpGet]
        public async Task<ActionResult<Pessoa>> GetById([FromServices] DataContext context, int id)
        {
            var pessoa = await context.PessoaDbSet.FirstOrDefaultAsync(x => x.PessoaID == id);
            return pessoa;
        }

        [Route("GetByCpf/{cpf}")]
        [HttpGet]
        public async Task<ActionResult<Pessoa>> GetByCpf([FromServices] DataContext context, string cpf)
        {
            var pessoa = await context.PessoaDbSet.FirstOrDefaultAsync(x => x.CPF == cpf);
            return pessoa;
        }

        [Route("")]
        [HttpPost]
        public async Task<ActionResult<Pessoa>> Post([FromServices] DataContext context, Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                context.PessoaDbSet.Add(pessoa);
                await context.SaveChangesAsync();
                return pessoa;
            }
            else
                return BadRequest(ModelState);
        }

        [Route("")]
        [HttpPut]
        public async Task<ActionResult<Pessoa>> Update([FromServices] DataContext context, Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                context.PessoaDbSet.Update(pessoa);
                await context.SaveChangesAsync();
                return pessoa;
            }
            else
                return BadRequest(ModelState);
        }

        [Route("{id:int}")]
        [HttpDelete]
        public async Task<ActionResult<Pessoa>> Delete([FromServices] DataContext context, int id)
        {
            var pessoa = await context.PessoaDbSet.FirstOrDefaultAsync(x => x.PessoaID == id);
            context.PessoaDbSet.Remove(pessoa);
            await context.SaveChangesAsync();
            return pessoa;
        }
    }
}
