using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProduto _produto;

        public ProdutosController(IProduto produto)
        {
            _produto = produto;
        }

        [HttpGet("/api/List")]
        [Produces("application/json")]
        public async Task<Object> List()
        {
            return await _produto.Lista();
        }


        [HttpPost("/api/Add")]
        [Produces("application/json")]
        public async Task<Object> Add(ProdutoRepository produto)
        {
            try
            {
                await _produto.Add(produto);
               
            }
            catch(Exception ex) 
            {
                return BadRequest(new { error = "Erro ao adicionar o produto. Tente novamente.", details = ex.Message });
            }

            //return Ok(new { message = "Produto adicionado com sucesso." });
            return Task.FromResult("Produto adicionado com sucesso.");
        }

        [HttpGet("/api/GetEntityById")]
        [Produces("application/json")]
        public async Task<object> GetEntityById(int id)
        {
            return await _produto.GetEntityById(id);
        }

        [HttpDelete("/api/Delete")]
        [Produces("application/json")]
        public async Task<object> Delete(int id)
        {
            try
            {
                var produto = await _produto.GetEntityById(id);

                await _produto.Delete(produto);

            }
            catch (Exception ex)
            {
                return false;
            }

            return true;

        }

    }
}
