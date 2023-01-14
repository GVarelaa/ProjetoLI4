using System;
using src.Data.Data;
using src.Data.BusinessLogic.SubFeiras;
using src.Data.BusinessLogic.Excecoes;

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
                throw new AlreadyRegisteredException("Conta já registada");
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
                throw new AlreadyRegisteredException("Conta já registada");
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
                    throw new WrongPasswordException("Password inválida!");
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
                    throw new WrongPasswordException("Password inválida!");
                }
            }

            throw new NonExistentAccountException("Conta inexistente!");
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


