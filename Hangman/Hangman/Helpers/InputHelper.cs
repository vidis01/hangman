using Hangman.Enums;

namespace Hangman.Helpers
{
    public static class InputHelper
    {
        public static bool TryParseTopicSelection(string? input, out TopicEnum? topicEnum)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Empty input!");
                topicEnum = null;
                return false;
            }            

            if (!int.TryParse(input, out int value))
            {
                Console.WriteLine("Not a number!");
                topicEnum = null;
                return false;
            }

            if(!(Enum.TryParse<TopicEnum>($"{value}", out var result) && Enum.IsDefined(result)))
            {
                Console.WriteLine("Wrong value!");
                topicEnum = null;
                return false;
            }
            topicEnum = result;

            return true;
        }
    }
}
