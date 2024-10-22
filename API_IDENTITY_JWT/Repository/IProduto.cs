using WebApi.Entities;

namespace WebApi.Repository
{
    public interface IProduto
    {
        Task<List<ProdutoRepository>> Lista();
        Task<ProdutoRepository> GetEntityById(int id);
        Task Add(ProdutoRepository produto);
        Task Update(ProdutoRepository produto);
        Task Delete(ProdutoRepository produto);
        
    }
}
