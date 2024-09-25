using Hangman.Enums;

namespace Hangman.Interfaces
{
    public interface IWordSelector
    {
        string SelectWord(TopicEnum? topic);
    }
}
