using src.Data.Data;
using src.Data.BusinessLogic.SubFeiras;
namespace src.Data.BusinessLogic.SubCompras;

public class SubComprasFacade
{
    private ComprasDAO Compras;
    
    public SubComprasFacade()
    {
        this.Compras = ComprasDAO.getInstance();
    } 


    public void AddCompra(int nifCliente, string nomeFaturacao, string morada, string telemovel)
    {
        IEnumerable<(Produto, float, int)> produtos = this.Compras.GetProdutosCarrinho(nifCliente);

        float valorTotal = 0;
        foreach ((Produto, float, int) t in produtos)
        {
            valorTotal += t.Item2;
        }

        Compra compra = this.Compras.Insert(new Compra(nomeFaturacao, morada, telemovel, valorTotal, DateTime.Now, nifCliente));

        int idCompra = compra.idCompra;
        
        foreach ((Produto, float, int) t in produtos)
        {
            this.Compras.InsertProdutoCompra(idCompra, t.Item1.idProduto, t.Item2);
            this.Compras.DeleteProdutoCarrinho(nifCliente, t.Item1.idProduto);
        }
    }

    public Task<IEnumerable<(Produto, float, int)>> GetCarrinho(int nifCliente)
    {
        foreach((Produto, float, int) t in this.Compras.GetProdutosCarrinho(nifCliente))
        {
            Console.WriteLine(t.Item1.descricao);
        }

        return Task.FromResult(this.Compras.GetProdutosCarrinho(nifCliente));
    }

    public void AdicionarAoCarrinho(int nifCliente, int idProduto, float valorVenda, int quantidade)
    {
        this.Compras.InsertProdutoCarrinho(nifCliente, idProduto, valorVenda, quantidade);
    }
}