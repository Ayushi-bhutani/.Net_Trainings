
namespace delivery {
    public interface IRestaurantService
{
    /// <summary>
    ///  Accepts an order from a customer.
    /// </summary>
    /// <param name="order"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<RestaurantAcceptance> AcceptOrderAsync(
        CustomerOrder order, 
        CancellationToken ct);
    

    /// <summary>
    /// Provides preparation progress of an order.
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<PreparationProgress> GetPreparationProgressAsync(
        string orderId, 
        CancellationToken ct);
    

    /// <summary>
    /// Cancels an order for a given reason.
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="reason"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<bool> CancelOrderAsync(
        string orderId, 
        string reason, 
        CancellationToken ct);
    

    /// <summary>
    /// Streams real-time kitchen updates for an order.
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    IAsyncEnumerable<KitchenUpdate> StreamKitchenUpdates(
        string orderId, 
        CancellationToken ct);
}
}