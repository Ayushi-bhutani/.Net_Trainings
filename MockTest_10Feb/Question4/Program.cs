using System;
using System.Collections.Generic;
using System.Linq;

// ============================================
// 1. INTERFACES & ENUMS
// ============================================

public interface IFinancialInstrument
{
    string Symbol { get; }
    decimal CurrentPrice { get; }
    InstrumentType Type { get; }
}

public enum InstrumentType
{
    Stock,
    Bond,
    Option,
    Future
}

// ============================================
// 2. GENERIC PORTFOLIO
// ============================================

public class Portfolio<T> where T : IFinancialInstrument
{
    private Dictionary<T, int> _holdings = new();

    // BUY
    public void Buy(T instrument, int quantity, decimal price)
    {
        if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity));

        if (price <= 0)
            throw new ArgumentOutOfRangeException(nameof(price));

        if (_holdings.ContainsKey(instrument))
            _holdings[instrument] += quantity;
        else
            _holdings[instrument] = quantity;
    }

    // SELL
    public decimal? Sell(T instrument, int quantity, decimal currentPrice)
    {
        if (quantity <= 0)
            throw new ArgumentException("Invalid quantity");

        if (!_holdings.ContainsKey(instrument))
            throw new InvalidOperationException("Instrument not found");

        if (_holdings[instrument] < quantity)
            throw new InvalidOperationException("Not enough quantity");

        _holdings[instrument] -= quantity;

        if (_holdings[instrument] == 0)
            _holdings.Remove(instrument);

        return quantity * currentPrice;
    }

    // TOTAL VALUE
    public decimal CalculateTotalValue()
    {
        decimal total = 0;

        foreach (var h in _holdings)
        {
            total += h.Key.CurrentPrice * h.Value;
        }

        return total;
    }

    // TOP PERFORMER
    public (T instrument, decimal returnPercentage)?
        GetTopPerformer(Dictionary<T, decimal> purchasePrices)
    {
        if (_holdings.Count == 0)
            return null;

        var result = _holdings
            .Where(h => purchasePrices.ContainsKey(h.Key))
            .Select(h =>
            {
                var purchase = purchasePrices[h.Key];
                var current = h.Key.CurrentPrice;

                var returnPct =
                    ((current - purchase) / purchase) * 100;

                return (h.Key, returnPct);
            })
            .OrderByDescending(x => x.returnPct)
            .FirstOrDefault();

        return result;
    }

    // Helper → expose holdings for strategy
    public IEnumerable<T> GetInstruments()
        => _holdings.Keys;
}

// ============================================
// 3. INSTRUMENT TYPES
// ============================================

public class Stock : IFinancialInstrument
{
    public string Symbol { get; set; }
    public decimal CurrentPrice { get; set; }
    public InstrumentType Type => InstrumentType.Stock;
    public string CompanyName { get; set; }
    public decimal DividendYield { get; set; }
}

public class Bond : IFinancialInstrument
{
    public string Symbol { get; set; }
    public decimal CurrentPrice { get; set; }
    public InstrumentType Type => InstrumentType.Bond;
    public DateTime MaturityDate { get; set; }
    public decimal CouponRate { get; set; }
}

// ============================================
// 4. TRADING STRATEGY
// ============================================

public class TradingStrategy<T>
    where T : IFinancialInstrument
{
    public void Execute(
        Portfolio<T> portfolio,
        Func<T, bool> buyCondition,
        Func<T, bool> sellCondition)
    {
        foreach (var instrument in portfolio.GetInstruments())
        {
            if (buyCondition(instrument))
            {
                portfolio.Buy(
                    instrument,
                    1,
                    instrument.CurrentPrice);
            }
            else if (sellCondition(instrument))
            {
                portfolio.Sell(
                    instrument,
                    1,
                    instrument.CurrentPrice);
            }
        }
    }

    // RISK METRICS (Simulated)
    public Dictionary<string, decimal>
        CalculateRiskMetrics(IEnumerable<T> instruments)
    {
        var random = new Random();

        var returns = instruments
            .Select(i =>
                (decimal)(random.NextDouble() * 0.2 - 0.1))
            .ToList();

        if (!returns.Any())
            return new Dictionary<string, decimal>();

        var avg = returns.Average();

        var variance =
            returns.Average(r => (r - avg) * (r - avg));

        var volatility =
            (decimal)Math.Sqrt((double)variance);

        var beta = volatility * 1.2m;

        var sharpe =
            volatility == 0 ? 0 : (avg - 0.02m) / volatility;

        return new Dictionary<string, decimal>
        {
            { "Volatility", volatility },
            { "Beta", beta },
            { "Sharpe Ratio", sharpe }
        };
    }
}

// ============================================
// 5. PRICE HISTORY
// ============================================

public class PriceHistory<T>
    where T : IFinancialInstrument
{
    private Dictionary<T,
        List<(DateTime, decimal)>> _history = new();

    public void AddPrice(
        T instrument,
        DateTime timestamp,
        decimal price)
    {
        if (!_history.ContainsKey(instrument))
            _history[instrument] =
                new List<(DateTime, decimal)>();

        _history[instrument].Add((timestamp, price));
    }

    public decimal? GetMovingAverage(
        T instrument,
        int days)
    {
        if (!_history.ContainsKey(instrument))
            return null;

        var prices = _history[instrument]
            .OrderByDescending(p => p.Item1)
            .Take(days)
            .Select(p => p.Item2)
            .ToList();

        if (!prices.Any())
            return null;

        return prices.Average();
    }

    public Trend DetectTrend(T instrument, int period)
    {
        if (!_history.ContainsKey(instrument))
            return Trend.Sideways;

        var data = _history[instrument]
            .OrderByDescending(p => p.Item1)
            .Take(period)
            .OrderBy(p => p.Item1)
            .ToList();

        if (data.Count < 2)
            return Trend.Sideways;

        var first = data.First().Item2;
        var last = data.Last().Item2;

        var pct = ((last - first) / first) * 100;

        if (pct > 2) return Trend.Upward;
        if (pct < -2) return Trend.Downward;

        return Trend.Sideways;
    }
}

public enum Trend
{
    Upward,
    Downward,
    Sideways
}

// ============================================
// 6. MAIN — TEST SCENARIO
// ============================================

class Program
{
    static void Main()
    {
        // Instruments
        var stock1 = new Stock
        {
            Symbol = "AAPL",
            CompanyName = "Apple",
            CurrentPrice = 190.5m
        };

        var stock2 = new Stock
        {
            Symbol = "GOOGL",
            CompanyName = "Google",
            CurrentPrice = 2800m
        };

        var bond1 = new Bond
        {
            Symbol = "US10Y",
            CurrentPrice = 102.3m,
            CouponRate = 2.5m,
            MaturityDate = DateTime.Now.AddYears(10)
        };

        // Portfolio
        var stockPortfolio = new Portfolio<Stock>();
        var bondPortfolio = new Portfolio<Bond>();

        stockPortfolio.Buy(stock1, 10, 180);
        stockPortfolio.Buy(stock2, 5, 2500);
        bondPortfolio.Buy(bond1, 20, 98);

        Console.WriteLine("Stock Value: " +
            stockPortfolio.CalculateTotalValue());

        Console.WriteLine("Bond Value: " +
            bondPortfolio.CalculateTotalValue());

        // Sell
        var proceeds =
            stockPortfolio.Sell(
                stock1, 2, stock1.CurrentPrice);

        Console.WriteLine($"Sold AAPL → {proceeds}");

        // Top performer
        var purchasePrices = new Dictionary<Stock, decimal>
        {
            { stock1, 180 },
            { stock2, 2500 }
        };

        var top =
            stockPortfolio.GetTopPerformer(
                purchasePrices);

        Console.WriteLine(
            $"Top Performer: {top?.instrument.Symbol}");

        // Strategy
        var strategy = new TradingStrategy<Stock>();

        strategy.Execute(
            stockPortfolio,
            s => s.CurrentPrice < 200,
            s => s.CurrentPrice > 2700);

        Console.WriteLine("Strategy Executed");

        // Price history
        var history = new PriceHistory<Stock>();

        history.AddPrice(stock1,
            DateTime.Now.AddDays(-3), 175);

        history.AddPrice(stock1,
            DateTime.Now.AddDays(-2), 182);

        history.AddPrice(stock1,
            DateTime.Now.AddDays(-1), 188);

        history.AddPrice(stock1,
            DateTime.Now, 190);

        Console.WriteLine(
            "Moving Avg: " +
            history.GetMovingAverage(stock1, 3));

        Console.WriteLine(
            "Trend: " +
            history.DetectTrend(stock1, 3));

        // Risk
        var risk =
            strategy.CalculateRiskMetrics(
                new List<Stock> { stock1, stock2 });

        Console.WriteLine("\nRisk Metrics:");

        foreach (var r in risk)
            Console.WriteLine($"{r.Key}: {r.Value}");
    }
}
