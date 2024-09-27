using ProdutoManagerApp.Entities;

namespace ProdutoManagerApp.Services;

public interface IProdutoService
{
    void InserirProduto(Produto produto);
    IEnumerable<Produto> FiltrarProdutosSegundoTrimestre();
    IEnumerable<Produto> OrdenarPorTipo();
    IEnumerable<Produto> Top3ProdutosPorMargemDeLucro();
}