using src.Data.BusinessLogic.SubFeiras;

namespace src.Data.BusinessLogic.SubCompras;

public interface ISubCompras
{
    public void AddCompra(int nifCliente, string nomeFaturacao, string morada, string telemovel);

    public Task<IEnumerable<(Produto, float, int)>> GetCarrinho(int nifCliente);

    public void AdicionarAoCarrinho(int nifCliente, int idProduto, float valorVenda);
}