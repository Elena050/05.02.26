public class UserValidator
{
    public ValidationResult ValidateUser(User user)
    {
        var result = new ValidationResult();

        if (string.IsNullOrEmpty(user.Email) || !IsValidEmail(user.Email))
            result.AddError("Invalid email");
        return result;
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email && email.Length > 5 && email.Length < 255;
        }
        catch
        {
            return false;
        }
    }
}
