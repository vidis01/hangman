using Hangman.Enums;
using Hangman.Interfaces;

namespace Hangman.Classes
{
    public class WordSelector : IWordSelector
    {
        public string SelectWord(TopicEnum? topic)
        {
            Random rand = new();

            switch (topic)
            {
                case TopicEnum.COUNTRIES:
                {
                    string[] countries = { "Latvia", "Estonia", "Denmark", "China", "Ireland", "Thailand", "Zimbabwe", "France", "Uganda", "Poland", "Sweden" };
                    return countries[rand.Next(countries.Length)].ToUpper();
                }
                case TopicEnum.CITIES:
                {
                    string[] cities = { "Vilnius", "Kaunas", "Venice", "Kedainiai", "Paris", "Mumbai", "Philadelphia", "Dallas", "Kolkata", "Pasvalys", "Madrid" };
                    return cities[rand.Next(cities.Length)].ToUpper();
                }
                case TopicEnum.SEAS:
                {
                    string[] seas = { "Java", "Solomon", "White", "Sargasso", "Baltic", "Celebes", "labrador", "Norwegian", "Weddell", "Caribbean", "Greenland" };
                    return seas[rand.Next(seas.Length)].ToUpper();
                }
                default:
                    return "";
            }
        }
    }
}
