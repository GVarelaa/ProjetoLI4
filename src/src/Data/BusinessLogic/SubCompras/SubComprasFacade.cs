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
        IEnumerable<Tuple<Produto, float>> produtos = this.Compras.GetProdutosCarrinho(nifCliente);

        float valorTotal = 0;
        foreach (Tuple<Produto, float> t in produtos)
        {
            valorTotal += t.Item2;
        }

        Compra compra = this.Compras.Insert(new Compra(nomeFaturacao, morada, telemovel, valorTotal, DateTime.Now, nifCliente));

        int idCompra = compra.idCompra;
        
        foreach (Tuple<Produto, float> t in produtos)
        {
            //this.Compras.InsertProdutoCompra(idCompra, t.Item1.idProduto, nifCliente, t.Item2);
            this.Compras.InsertProdutoCompra(idCompra, t.Item1.idProduto, nifCliente, t.Item2);
            this.Compras.DeleteProdutoCarinho(nifCliente, t.Item1.idProduto);
        }
    }

    public Task<IEnumerable<Tuple<Produto, float>>> GetCarrinho(int nifCliente)
    {
        return Task.FromResult(this.Compras.GetProdutosCarrinho(nifCliente));
    }
}