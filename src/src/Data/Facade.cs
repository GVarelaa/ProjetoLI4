namespace src.Data;

    public class Facade
    {
        public Task<List<String>> getFeiras()
        {
            List<String> feiras = new List<String>();
            feiras.Add("Feira1");
            feiras.Add("Feira2");
        return Task.FromResult(feiras);
        }

        public Task<String> getDetalhesFeira()
        {
            String feira = "Feira1\n A melhor feira do mundo\n";
        return Task.FromResult(feira);
        }

        public Task<List<String>> getCatalogo()
        {
            List<String> produtos = new List<string>();
        produtos.Add("Produto1");
        produtos.Add("Produto2");
        produtos.Add("Produto3");
        return Task.FromResult(produtos);
        }
    }

