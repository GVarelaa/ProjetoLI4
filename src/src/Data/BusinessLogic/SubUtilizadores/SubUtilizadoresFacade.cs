using System;
using src.Data.Data;
using src.Data.BusinessLogic.SubFeiras;

namespace src.Data.BusinessLogic.SubUsers;

    public class SubUtilizadoresFacade
    {
        private ClientesDAO clientesDAO;
        private VendedoresDAO vendedoresDAO;

        public SubUtilizadoresFacade()
        {
            clientesDAO = ClientesDAO.GetInstance();
            vendedoresDAO = VendedoresDAO.GetInstance();
        }


        public void RegistarCliente(String nome, String email, String password, int nifCliente)
        {
            if( clientesDAO.Get(nifCliente) == null )
            {
                Cliente cliente = new Cliente(nifCliente, nome, email, password);
                clientesDAO.Insert(cliente);
            }
            else
            {
                // atirar exceção
            }
        }

        public void RegistarVendedor(String nome, String email, String password, int nifVendedor)
        {
            if (vendedoresDAO.Get(nifVendedor) == null)
            {
                Vendedor vendedor = new Vendedor(nifVendedor, nome, email, password);
                vendedoresDAO.Insert(vendedor);
            }
            else
            {
                // atirar exceção
            }
        }

        public int Autenticar(int nif, String password)
        {
            Cliente cliente = clientesDAO.Get(nif);
            
            if(cliente != null)
            {
                if (cliente.passwordCliente.Equals(password))
                {
                    return 1;
                }
                else
                {
                    // exceção password errada
                }
            }

            Vendedor vendedor = vendedoresDAO.Get(nif);

            if(vendedor != null)
            {
                if (vendedor.passwordVendedor.Equals(password))
                {
                    return 2;
                }
                else
                {
                    // exceção password errada
                }
            }

            return 0;
            // exceção conta não criada
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
        
        public void AddCliente(Cliente cliente)
        {
           clientesDAO.Insert(cliente);
        }

        public void AddVendedor(Vendedor vendedor)
        {
            vendedoresDAO.Insert(vendedor);
        }

}


