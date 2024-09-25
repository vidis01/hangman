namespace Hangman
{
    public static class CheckUserInput
    {
        public static bool BasicChecks(string userInput)
        {
            {
                userInput = userInput.Trim();
                if (userInput == null)
                {
                    return false;
                }
                else
                    if (userInput == "")
                {
                    return false;
                }
                else
                    return true;
            }
        }

        public static bool CheckLetters(char userInput)
        {
            char LetterIinAscii = char.ToLower(userInput);
            if (LetterIinAscii > 96 && LetterIinAscii < 123)
            {
                return true;
            }
            return false;
        }
    }
}
