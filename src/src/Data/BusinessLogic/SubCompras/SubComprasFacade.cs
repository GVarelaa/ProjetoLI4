using src.Data.Data;

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

        float valorTotal;
        foreach (Tuple t in produtos)
        {
            valorTotal += t.Item2;
        }

        Compra compra = this.Compras.Insert(new Compra(nomeFaturacao, morada, telemovel, valorTotal, DateTime.Now, nifCliente));

        int id = compra.idCompra;

        // faco amanha
    }


}