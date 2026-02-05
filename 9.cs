public class OrderProcessor
{
    public void ProcessOrder(Order order)
    {
        var checks = new List<Func<bool, string>>
        {
            () => order.Items?.Any() == false ? "Order has no items" : null,
            () => string.IsNullOrEmpty(order.Customer?.Email) ? "Customer email missing" : null,
            () => order.TotalAmount <= 0 ? "Invalid amount" : null
        };

        foreach (var check in checks)
        {
            var error = check();
            if (error != null)
            {
                HandleError(error, order.Id);
                return;
            }
        }

    }

    private void HandleError(string message, int orderId)
    {
        SendNotification(message);
        UpdateStatus(orderId, "Failed");
        LogError($"Order {orderId}: {message}");
    }
}
