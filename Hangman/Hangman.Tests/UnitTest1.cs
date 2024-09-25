using Hangman.Enums;
using Hangman.Helpers;

namespace Hangman.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            InputHelper.TryParseTopicSelection("1", out var topicEnum);
        }
    }
}