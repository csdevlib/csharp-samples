using Newtonsoft.Json;

namespace OrderManagement.Contracts.Output
{
    public class PlaceOrderResponse
    {
        bool IsSuccess { get; }
        string ErrorReason { get; }
        decimal? OrderId { get; }

        [JsonConstructor]
        private PlaceOrderResponse(bool isSuccess, string errorReason, decimal? orderId)
        {
            IsSuccess = isSuccess;
            ErrorReason = errorReason;
            OrderId = orderId;
        }

        public static PlaceOrderResponse Create(bool isSuccess, string errorReason, decimal? orderId)
        {
            return new PlaceOrderResponse(isSuccess, errorReason, orderId);
        }
    }
}
