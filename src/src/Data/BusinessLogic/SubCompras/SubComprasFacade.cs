using src.Data.Data;

namespace src.Data.BusinessLogic.SubCompras;

public class SubComprasFacade
{
    private ComprasDAO Compras;
    
    public SubComprasFacade()
    {
        this.Compras = ComprasDAO.getInstance();
    }


    public void AddCompra(Inumerable<int> produtos, int nifCliente)
    {
        this.Compras.Insert(compra);
    }


}