
using Stackoverflow.Models;

namespace Stackoverflow.Services
{
    public class QuestionService
    {
        List<Question> questions;
        private TagService _tagService;
        private NotificationService _notificationService;

        public QuestionService(TagService tagService, NotificationService notificationService)
        {
            questions = [];
            _tagService = tagService;
            _notificationService = notificationService;
        }

        public void AddQuestion(string desc, int userId, int tagId)
        {
            var newQuestion = new Question()
            {
                QuestionId = questions.Count+1,
                UserId = userId,
                Desc = desc,
                TagId = tagId
            };
            questions.Add(newQuestion);
            _notificationService.AddSubscriber("mudit@gmail.com");
        }

        internal Question GetQuestion(int questionId)
        {
            return questions[questionId-1];
        }

        internal List<Question> SearchQuestionsByTag(string tag)
        {
            var tags = _tagService.GetTags(tag).Select(x=>x.TagId);

            var result = questions.FindAll(x => tags.Contains(x.TagId));
            return result;
        }
    }
}
