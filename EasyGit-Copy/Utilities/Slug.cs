using System.Text;
using System.Text.RegularExpressions;

namespace EasyGit_Copy.Utilities
{
    public class Slug
    {
        public static string GenerateSlug(string text)
        {
            var turkishCharacters = new System.Collections.Generic.Dictionary<char, char>
        {
            { 'ç', 'c' },
            { 'ı', 'i' },
            { 'ğ', 'g' },
            { 'ö', 'o' },
            { 'ş', 's' },
            { 'ü', 'u' }
        };


            var normalizedText = new StringBuilder();

            foreach (char c in text.ToLower())
            {
                if (turkishCharacters.ContainsKey(c))
                {
                    normalizedText.Append(turkishCharacters[c]);
                }
                else
                {
                    normalizedText.Append(c);
                }
            }

            var slug = Regex.Replace(normalizedText.ToString(), @"\s+", "-")
                .ToLowerInvariant()
                .Replace("-", "")
                .Trim();

            return slug;
        }
    }
}
