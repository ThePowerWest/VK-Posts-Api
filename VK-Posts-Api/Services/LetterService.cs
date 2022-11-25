using System.Text.RegularExpressions;
using VK_Posts_Api.Models;
using VK_Posts_Api.Services.Interfaces;

namespace VK_Posts_Api.Services
{
    /// <summary>
    /// Сервис для подсчета букв
    /// </summary>
    public class LetterService : ILetterService
    {
        /// <summary>
        /// Посчитать буквы в постах
        /// </summary>
        /// <param name="posts"></param>
        /// <returns></returns>
        public List<Letter> CountUp(List<Post> posts)
        {
            var counts = new List<Letter>();
            string inputString = "";
            string sortedString = "";
            string outputString = "";

            foreach (var post in posts)
            {
                inputString += post.Text;
            }

            MatchCollection onlyWordsMatches = new Regex("\\p{L}").Matches(inputString);
            foreach (Match match in onlyWordsMatches)
            {
                sortedString += match.Value;
            }

            if (sortedString.Length > 1)
            {
                foreach (var letter in sortedString.ToLower().OrderBy(l => l))
                {
                    outputString += letter;
                }

                MatchCollection repeatedLetters = new Regex("(.)\\1*").Matches(outputString);

                foreach (Match match in repeatedLetters)
                {
                    if (match.Value.Length > 1)
                    {
                        counts.Add(new Letter
                        {
                            LetterName = match.Groups[1].Value,
                            Count = match.Value.Length
                        });
                    }
                }
                return counts;
            }
            else
                return null;
        }
    }
}