using Stackoverflow.Models;

namespace Stackoverflow.Services
{
    public class AnswerService
    {
        List<Answer> answers;
        private NotificationService _notificationService;


        public AnswerService(NotificationService notificationService)
        {
            answers = [];
            _notificationService = notificationService;

        }
        public void AcceptAnswer(int answerId)
        {
            var answer = answers[answerId];
            answer.IsAccepted = true;
        }

        public void PostAnswer(string answer, int questionId, int userId)
        {
            var newAnswer = new Answer
            {
                AnswerId = answers.Count + 1,
                Desc = answer,
                QuestionId = questionId,
                UserId = userId
            };
            answers.Add(newAnswer);
            _notificationService.AddSubscriber("pk@gmail.com");
        }
    }
}
