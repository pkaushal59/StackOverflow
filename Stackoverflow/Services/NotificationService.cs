using Stackoverflow.Models;

namespace Stackoverflow.Services
{
    public class NotificationService
    {
        List<string> subscribers;

        public NotificationService()
        {
            subscribers = [];
        }

        public void Notify(NotificationType notificationType, string content)
        {
            foreach (var subscriber in subscribers)
            {
                Console.WriteLine($"Notifying {subscriber} about {notificationType}: {content}");
            }
        }

        public void AddSubscriber(string email)
        {
            subscribers.Add(email);
        }

        public void RemoveSubscriber(string email)
        {
            subscribers.Remove(email);
        }
        public void NotifyForAnswerAccepted(int answerId, int questionId)
        {
            string message = $"Answer {answerId} for Question {questionId} has been accepted.";
            Notify(NotificationType.AnswerAccepted, message);
        }
    }
    public enum NotificationType
    {
        QuestionVoted,
        AnswerAccepted,
        AnswerPosted,
    }
}
