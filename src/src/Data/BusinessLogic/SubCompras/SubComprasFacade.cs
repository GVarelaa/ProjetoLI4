using src.Data.Data;
using src.Data.BusinessLogic.SubFeiras;
namespace src.Data.BusinessLogic.SubCompras;

public class SubComprasFacade
{
    private ComprasDAO Compras;
    private ProdutosDAO produtos;
    
    public SubComprasFacade()
    {
        this.Compras = ComprasDAO.getInstance();
    } 


    public void AddCompra(int nifCliente, string nomeFaturacao, string morada, string telemovel)
    {
        IEnumerable<Tuple<Produto, float>> produtos = this.produtos.GetProdutosCarrinho(nifCliente);

        float valorTotal = 0;
        foreach (Tuple<Produto, float> t in produtos)
        {
            valorTotal += t.Item2;
        }

        Compra compra = this.Compras.Insert(new Compra(nomeFaturacao, morada, telemovel, valorTotal, DateTime.Now, nifCliente));

        int id = compra.idCompra;

        // faco amanha
    }


}