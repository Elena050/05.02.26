public class TransactionLogger
{
    public void LogTransaction(decimal amount, string from, string to)
    {
        var message = $"Транзакция в {DateTime.Now:HH:mm:ss}\n" +
                      $"Сумма: {amount:C}\n" +
                      $"Отправитель: \"{from}\"\n" +
                      $"Получатель: \"{to}\"\n" +
                      $"Статус: УСПЕШНО";
        WriteToLog(message);
    }
}
