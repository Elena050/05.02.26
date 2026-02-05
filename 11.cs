public class SimpleValidator
{
    public bool Validate(UserInput input)
    {
        return input != null &&
               input.Data?.Length > 0 &&
               (input.Type == "A" || input.Type == "B") &&
               input.Value.HasValue &&
               input.Value >= 0 && input.Value <= 100 &&
               !string.IsNullOrEmpty(input.Name) &&
               input.Name.Length >= 3 && input.Name.Length <= 50;
    }
}
