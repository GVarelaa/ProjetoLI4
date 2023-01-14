using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using src.Data.BusinessLogic;

namespace src.Data.Data;

public class ComprasDAO
{
    private static ComprasDAO compras = null;

    private ComprasDAO() { }

    public static ComprasDAO getInstance()
    {
        if(compras == null)
        {
            compras = new ComprasDAO();
        }

        return compras;
    }

    public Compra Get(int id)
    {
        const string connectionString = DAOConfig.URL;

        Compra c;
        using (var connection = new SqlConnection(connectionString))
        {
            compra = connection.Get<Compra>(id);
        }

        return compra;
    }

    public Compra Insert(Compra compra)
    {
        const string connectionString = DAOConfig.URL;

        using (var connection = new SqlConnection(connectionString))
        {
            compra = connection.Insert<Compra>(compra);
        }

        return compra;
    }

    public IEnumerable<Compra> GetAll()
    {
        const string connectionString = DAOConfig.URL;

        IEnumerable<Compra> compras;
        using (var connection = new SqlConnection(connectionString))
        {
            compras = connection.GetAll<Compra>();
        }
        return compras;
    }


}