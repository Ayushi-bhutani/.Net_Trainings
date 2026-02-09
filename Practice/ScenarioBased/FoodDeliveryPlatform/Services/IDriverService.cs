
namespace delivery {
    public interface IDriverService
{
    /// <summary>
    /// Finds available drivers near pickup and dropoff locations.
    /// </summary>
    /// <param name="pickup"></param>
    /// <param name="dropoff"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<List<AvailableDriver>> FindAvailableDriversAsync(
        Location pickup, 
        Location dropoff, 
        CancellationToken ct);
    

    /// <summary>
    /// Assigns a driver to an order.
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="driverId"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<DriverAssignment> AssignDriverAsync(
        string orderId, 
        string driverId, 
        CancellationToken ct);
    
    /// <summary>
    /// Tracks current location of a driver.
    /// </summary>
    /// <param name="driverId"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<DriverLocation> TrackDriverAsync(
        string driverId, 
        CancellationToken ct);
}}
