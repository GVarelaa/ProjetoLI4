using System;
using src.Data.Data;

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

        

    }
}

