// // Scenario 4: Financial Trading Platform
// // Problem: Build a type-safe trading system for different financial instruments.
// // csharp
// public interface IFinancialInstrument
// {
//     string Symbol { get; }
//     decimal CurrentPrice { get; }
//     InstrumentType Type { get; }
// }

// public enum InstrumentType { Stock, Bond, Option, Future }

// // 1. Generic portfolio
// public class Portfolio<T> where T : IFinancialInstrument
// {
//     private Dictionary<T, int> _holdings = new(); // Instrument -> Quantity
    
//     // TODO: Buy instrument
//     public void Buy(T instrument, int quantity, decimal price)
//     {
//         // Validate: quantity > 0, price > 0
//         // Add to holdings or update quantity
//     }
    
//     // TODO: Sell instrument
//     public decimal? Sell(T instrument, int quantity, decimal currentPrice)
//     {
//         // Validate: enough quantity
//         // Remove/update holdings
//         // Return proceeds (quantity * currentPrice)
//     }
    
//     // TODO: Calculate total value
//     public decimal CalculateTotalValue()
//     {
//         // Sum of (quantity * currentPrice) for all holdings
//     }
    
//     // TODO: Get top performing instrument
//     public (T instrument, decimal returnPercentage)? GetTopPerformer(
//         Dictionary<T, decimal> purchasePrices)
//     {
//         // Calculate return percentage for each
//         // Return highest performer
//     }
// }

// // 2. Specialized instruments
// public class Stock : IFinancialInstrument
// {
//     public string Symbol { get; set; }
//     public decimal CurrentPrice { get; set; }
//     public InstrumentType Type => InstrumentType.Stock;
//     public string CompanyName { get; set; }
//     public decimal DividendYield { get; set; }
// }

// public class Bond : IFinancialInstrument
// {
//     public string Symbol { get; set; }
//     public decimal CurrentPrice { get; set; }
//     public InstrumentType Type => InstrumentType.Bond;
//     public DateTime MaturityDate { get; set; }
//     public decimal CouponRate { get; set; }
// }

// // 3. Generic trading strategy
// public class TradingStrategy<T> where T : IFinancialInstrument
// {
//     // TODO: Execute strategy on portfolio
//     public void Execute(Portfolio<T> portfolio, 
//         Func<T, bool> buyCondition,
//         Func<T, bool> sellCondition)
//     {
//         // For each instrument in market data
//         // Apply buy/sell conditions
//         // Execute trades
//     }
    
//     // TODO: Calculate risk metrics
//     public Dictionary<string, decimal> CalculateRiskMetrics(IEnumerable<T> instruments)
//     {
//         // Return: Volatility, Beta, Sharpe Ratio
//     }
// }

// // 4. Price history with generics
// public class PriceHistory<T> where T : IFinancialInstrument
// {
//     private Dictionary<T, List<(DateTime, decimal)>> _history = new();
    
//     // TODO: Add price point
//     public void AddPrice(T instrument, DateTime timestamp, decimal price)
//     {
//         // Add to history
//     }
    
//     // TODO: Get moving average
//     public decimal? GetMovingAverage(T instrument, int days)
//     {
//         // Calculate simple moving average
//     }
    
//     // TODO: Detect trends
//     public Trend DetectTrend(T instrument, int period)
//     {
//         // Return: Upward, Downward, Sideways
//     }
// }

// public enum Trend { Upward, Downward, Sideways }

// class Program
// {
//     static void Main()
//     {
//         // ============================================
//         // 1️⃣ CREATE INSTRUMENTS
//         // ============================================

//         var stock1 = new Stock
//         {
//             Symbol = "AAPL",
//             CompanyName = "Apple Inc.",
//             CurrentPrice = 190.50m,
//             DividendYield = 0.5m
//         };

//         var stock2 = new Stock
//         {
//             Symbol = "GOOGL",
//             CompanyName = "Google",
//             CurrentPrice = 2800.75m,
//             DividendYield = 0.0m
//         };

//         var bond1 = new Bond
//         {
//             Symbol = "US10Y",
//             CurrentPrice = 102.30m,
//             CouponRate = 2.5m,
//             MaturityDate = DateTime.Now.AddYears(10)
//         };

//         // ============================================
//         // 2️⃣ CREATE PORTFOLIO
//         // ============================================

//         var stockPortfolio = new Portfolio<Stock>();
//         var bondPortfolio = new Portfolio<Bond>();

//         stockPortfolio.Buy(stock1, 10, 180m);
//         stockPortfolio.Buy(stock2, 5, 2500m);

//         bondPortfolio.Buy(bond1, 20, 98m);

//         Console.WriteLine("=== PORTFOLIO VALUE ===");

//         Console.WriteLine(
//             $"Stocks Value: {stockPortfolio.CalculateTotalValue()}");

//         Console.WriteLine(
//             $"Bonds Value: {bondPortfolio.CalculateTotalValue()}");

//         // ============================================
//         // 3️⃣ SELL TRANSACTION
//         // ============================================

//         var proceeds =
//             stockPortfolio.Sell(stock1, 2, stock1.CurrentPrice);

//         Console.WriteLine(
//             $"\nSold AAPL → Proceeds: {proceeds}");

//         // ============================================
//         // 4️⃣ TOP PERFORMER
//         // ============================================

//         var purchasePrices = new Dictionary<Stock, decimal>
//         {
//             { stock1, 180m },
//             { stock2, 2500m }
//         };

//         var top =
//             stockPortfolio.GetTopPerformer(purchasePrices);

//         if (top != null)
//         {
//             Console.WriteLine(
//                 $"\nTop Performer: {top.Value.instrument.Symbol}" +
//                 $" → Return: {top.Value.returnPercentage:F2}%");
//         }

//         // ============================================
//         // 5️⃣ TRADING STRATEGY
//         // ============================================

//         var strategy = new TradingStrategy<Stock>();

//         strategy.Execute(
//             stockPortfolio,

//             // BUY if price < 200
//             buyCondition: s => s.CurrentPrice < 200,

//             // SELL if price > 2700
//             sellCondition: s => s.CurrentPrice > 2700
//         );

//         Console.WriteLine(
//             "\nTrading strategy executed.");

//         // ============================================
//         // 6️⃣ PRICE HISTORY
//         // ============================================

//         var history = new PriceHistory<Stock>();

//         history.AddPrice(stock1,
//             DateTime.Now.AddDays(-3), 175m);

//         history.AddPrice(stock1,
//             DateTime.Now.AddDays(-2), 182m);

//         history.AddPrice(stock1,
//             DateTime.Now.AddDays(-1), 188m);

//         history.AddPrice(stock1,
//             DateTime.Now, 190.5m);

//         // Moving Average
//         var ma =
//             history.GetMovingAverage(stock1, 3);

//         Console.WriteLine(
//             $"\n3-Day Moving Avg: {ma}");

//         // Trend
//         var trend =
//             history.DetectTrend(stock1, 3);

//         Console.WriteLine(
//             $"Trend: {trend}");

//         // ============================================
//         // 7️⃣ RISK METRICS
//         // ============================================

//         var instruments = new List<Stock>
//         {
//             stock1,
//             stock2
//         };

//         var risk =
//             strategy.CalculateRiskMetrics(instruments);

//         Console.WriteLine("\n=== RISK METRICS ===");

//         foreach (var r in risk)
//         {
//             Console.WriteLine(
//                 $"{r.Key}: {r.Value}");
//         }

//         // ============================================
//         // END
//         // ============================================

//         Console.WriteLine(
//             "\n=== TRADING SIMULATION COMPLETE ===");
//     }
// }

// // 5. TEST SCENARIO: Trading simulation
// // a) Create portfolio with mixed instruments
// // b) Implement buy/sell logic
// // c) Create trading strategy with lambda conditions
// // d) Track price history
// // e) Demonstrate:
// //    - Portfolio rebalancing
// //    - Risk calculation
// //    - Trend detection
// //    - Performance comparison
