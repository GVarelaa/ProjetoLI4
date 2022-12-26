using System;
namespace src.Data.BusinessLogic;

public class Market
{
    private int marketId { get; set; }
    private String theme { get; set; }
    private String description { get; set; }
    private String local { get; set; }

    public Market(int marketId, string theme, string description, string local)
    {
        this.marketId = marketId;
        this.theme = theme;
        this.description = description;
        this.local = local;
        this.sellers = new Dictionary<int, Seller>();
    }

    public override bool Equals(object? obj)
    {
        return obj is Market market &&
               marketId == market.marketId &&
               theme == market.theme &&
               description == market.description &&
               local == market.local;
    }
}


