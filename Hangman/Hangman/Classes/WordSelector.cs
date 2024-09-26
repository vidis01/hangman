using Hangman.Enums;
using Hangman.Interfaces;

namespace Hangman.Classes
{
    public class WordSelector : IWordSelector
    {
        private Random _random;
        private Dictionary<TopicEnum, string[]> _words;
        
        public WordSelector(Random random)
        {
            _random = random;

            _words = new Dictionary<TopicEnum, string[]>
            {
                { TopicEnum.COUNTRIES, new string[] { "Latvia", "Estonia", "Denmark", "China", "Ireland", "Thailand", "Zimbabwe", "France", "Uganda", "Poland", "Sweden" } },
                { TopicEnum.CITIES, new string[] { "Vilnius", "Kaunas", "Venice", "Kedainiai", "Paris", "Mumbai", "Philadelphia", "Dallas", "Kolkata", "Pasvalys", "Madrid" } },
                { TopicEnum.SEAS, new string[] { "Java", "Solomon", "White", "Sargasso", "Baltic", "Celebes", "labrador", "Norwegian", "Weddell", "Caribbean", "Greenland" } }            
            };            
        }

        public string SelectWord(TopicEnum? topic)
        {
            if (topic == null) return "";

            return _words[(TopicEnum)topic][_random.Next(_words[(TopicEnum)topic].Length)].ToUpper();           
        }
    }
}
