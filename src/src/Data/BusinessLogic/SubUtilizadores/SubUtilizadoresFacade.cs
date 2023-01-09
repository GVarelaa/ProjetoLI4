using System;
using src.Data.Data;
using src.Data.BusinessLogic.SubFeiras;

namespace src.Data.BusinessLogic.SubUsers
{
    public class SubUtilizadoresFacade
    {
        private ClientesDAO clientesDAO;
        private VendedoresDAO vendedoresDAO;

        public SubUtilizadoresFacade()
        {
            clientesDAO = ClientesDAO.GetInstance();
            vendedoresDAO = VendedoresDAO.GetInstance();
        }

        public Task<IEnumerable<Cliente>> GetClientes()
        {
            return Task.FromResult(clientesDAO.GetAll());
        }

        public Task<IEnumerable<Vendedor>> GetVendedores()
        {
            return Task.FromResult(vendedoresDAO.GetAll());
        }

        public Task<Cliente> GetCliente(int nifCliente)
        {
            return Task.FromResult(clientesDAO.Get(nifCliente));
        }

        public Task<Vendedor> GetVendedor(int nifVendedor)
        {
            return Task.FromResult(vendedoresDAO.Get(nifVendedor));
        }

        public Task<int> GetAvaliacao(int nifCliente, int idProduto)
        {
            return Task.FromResult(clientesDAO.GetAvaliacao(nifCliente,idProduto));
        }
        
    }
}

