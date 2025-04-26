using Stackoverflow.Models;

namespace Stackoverflow.Services
{
    public class KeywordService
    {
        readonly List<Keyword> keywords;

        public KeywordService()
        {
            keywords = [];
        }

        public int AddKeyword(string keyword, int userId)
        {
            var newKeyword = new Keyword()
            {
                KeywordId = keywords.Count + 1,
                Desc =  keyword,
                UserId = userId
            };
            keywords.Add(newKeyword);
            return newKeyword.KeywordId;
        }
    }
}
