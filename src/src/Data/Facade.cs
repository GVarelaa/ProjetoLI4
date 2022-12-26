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
            List<string> produtos = new List<string>();
        produtos.Add("Produto1");
        produtos.Add("Produto2");
        produtos.Add("Produto3");
        produtos.Add("Produto4");
        produtos.Add("Produto5");
        produtos.Add("Produto6");
        produtos.Add("Produto7");
        produtos.Add("Produto8");
        produtos.Add("Produto9");
        produtos.Add("Produto10");
        produtos.Add("Produto11");
        produtos.Add("Produto12");
        return Task.FromResult(produtos);
        }

        public Task<string> getProduto()
        {
        string produto = "Produto1 Descrição tal";
        return Task.FromResult(produto);
        }
    }

