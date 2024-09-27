using ProdutoManagerApp.Entities;

namespace ProdutoManagerApp.Services;

public class ProdutoService : IProdutoService
{
    private readonly List<Produto> _produtos;

    public ProdutoService()
    {
        _produtos = new List<Produto>();
    }

    public void InserirProduto(Produto produto)
    {
        if (produto.ValorVenda > produto.ValorCompra &&
            produto.DataCriacao >= new DateTime(2024, 1, 1) &&
            produto.Descricao.Length >= 5 &&
            produto.ValorCompra > 0 && produto.ValorVenda > 0)
        {
            _produtos.Add(produto);
        }
    }

    public IEnumerable<Produto> FiltrarProdutosSegundoTrimestre()
    {
        return _produtos.Where(p => p.DataCriacao >= new DateTime(2024, 4, 1) && p.DataCriacao <= new DateTime(2024, 6, 30)).ToList();
    }

    public IEnumerable<Produto> OrdenarPorTipo()
    {
        return _produtos.OrderBy(p => p.Tipo).ToList();
    }

    public IEnumerable<Produto> Top3ProdutosPorMargemDeLucro()
    {
        return _produtos.OrderByDescending(p => p.ValorVenda - p.ValorCompra).Take(3).ToList();
    }
}
