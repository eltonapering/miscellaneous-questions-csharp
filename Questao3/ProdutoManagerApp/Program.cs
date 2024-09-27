using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProdutoManagerApp.Entities;
using ProdutoManagerApp.Enums;
using ProdutoManagerApp.Services;

class Program
{
    static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder()
                       .ConfigureServices((context, services) =>
                       {
                           // Registro da injeção de dependência
                           services.AddSingleton<IProdutoService, ProdutoService>();
                       })
                       .Build();

        // Resolvendo o serviço de produtos
        var produtoService = host.Services.GetRequiredService<IProdutoService>();

        // Inserindo alguns produtos de exemplo
        produtoService.InserirProduto(new Produto { Descricao = "Produto A", ValorVenda = 200, ValorCompra = 100, Tipo = TipoProduto.Final, DataCriacao = new DateTime(2024, 4, 10) });
        produtoService.InserirProduto(new Produto { Descricao = "Produto B", ValorVenda = 300, ValorCompra = 150, Tipo = TipoProduto.Consumo, DataCriacao = new DateTime(2024, 5, 15) });
        produtoService.InserirProduto(new Produto { Descricao = "Produto C", ValorVenda = 150, ValorCompra = 120, Tipo = TipoProduto.MateriaPrima, DataCriacao = new DateTime(2024, 3, 30) }); // Fora do segundo trimestre
        produtoService.InserirProduto(new Produto { Descricao = "Produto D", ValorVenda = 400, ValorCompra = 200, Tipo = TipoProduto.Intermediario, DataCriacao = new DateTime(2024, 6, 5) });
        produtoService.InserirProduto(new Produto { Descricao = "Produto E", ValorVenda = 250, ValorCompra = 180, Tipo = TipoProduto.Final, DataCriacao = new DateTime(2024, 4, 20) });

        // Filtrar produtos criados no segundo trimestre de 2024
        var produtosSegundoTrimestre = produtoService.FiltrarProdutosSegundoTrimestre();
        Console.WriteLine("Produtos criados no segundo trimestre de 2024:");
        foreach (var produto in produtosSegundoTrimestre)
        {
            Console.WriteLine($"{produto.Descricao} - Criado em: {produto.DataCriacao:dd/MM/yyyy}");
        }

        // Ordenar produtos por Tipo
        var produtosOrdenadosPorTipo = produtoService.OrdenarPorTipo();
        Console.WriteLine("\nProdutos ordenados por Tipo:");
        foreach (var produto in produtosOrdenadosPorTipo)
        {
            Console.WriteLine($"{produto.Descricao} - Tipo: {produto.Tipo}");
        }

        // Exibir os 3 produtos com maior margem de lucro
        var produtosComMaiorMargem = produtoService.Top3ProdutosPorMargemDeLucro();
        Console.WriteLine("\nTop 3 produtos com maior margem de lucro:");
        foreach (var produto in produtosComMaiorMargem)
        {
            double margemLucro = produto.ValorVenda - produto.ValorCompra;
            Console.WriteLine($"{produto.Descricao} - Margem de Lucro: {margemLucro:C}");
        }
    }
}