using System;
namespace src.Data.BusinessLogic.SubUsers;

public interface ISubUtilizadores
{
    public Task<IEnumerable<Cliente>> GetClientes();

    public Task<IEnumerable<Vendedor>> GetVendedores();

    public Task<Cliente> GetCliente(int nifCliente);

    public Task<Vendedor> GetVendedor(int nifVendedor);

    public Task<int> GetAvaliacao(int nifCliente, int idProduto);
    {

    }
}

