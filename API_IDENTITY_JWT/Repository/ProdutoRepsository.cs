
using Microsoft.EntityFrameworkCore;
using WebApi.Config;
using WebApi.Entities;

namespace WebApi.Repository
{
    public class ProdutoRepository : IProduto
    {
        private DbContextOptions<ContextBase> ? _optionsBuilder;

        public ProdutoRepository()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<ProdutoRepository> GetEntityById(int Id)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.Set<ProdutoRepository>().FindAsync(Id);

            }
        }
        public async Task Add(ProdutoRepository produto)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                await data.Set<ProdutoRepository>().AddAsync(produto);
                await data.SaveChangesAsync();
            }
        }

        public async Task Update(ProdutoRepository produto)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                data.Set<ProdutoRepository>().Update(produto);
                await data.SaveChangesAsync();
            }
        }


        public async Task<List<ProdutoRepository>> Lista()
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.Set<ProdutoRepository>().ToListAsync();

            }
        }
        public async Task Delete(ProdutoRepository produto)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                data.Set<ProdutoRepository>().Remove(produto);
                await data.SaveChangesAsync();
            }
        }

       
        
    }
}
