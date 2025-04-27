using Stackoverflow.Models;

namespace Stackoverflow.Services
{
    public class SearchService
    {
        private QuestionService _questionService;

        public SearchService(QuestionService questionService)
        {
            _questionService = questionService;
        }

        public List<Question> SearchByTag(string tagName) => _questionService.SearchQuestionsByTag(tagName);

        public List<Question> SearchByKeyword(string keyword) => _questionService.SearchByKeyword(keyword);
    }
}
