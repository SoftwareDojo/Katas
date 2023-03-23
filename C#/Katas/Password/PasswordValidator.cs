namespace Katas.Password
{
    public static class PasswordValidator
    {
        public static bool Validate(string password)
        {
            if (!LengthIsGreaterThan8(password)) return false;

            return GetComplexity(password).IsReached();
        }

        private static bool LengthIsGreaterThan8(string password)
        {
            return password.Length > 8;
        }

        private static PasswordComplexity GetComplexity(string password)
        {
            var complexity = new PasswordComplexity();
            foreach (char c in password)
            {
                complexity.CheckChar(c);
            }

            return complexity;
        }
    }
}
