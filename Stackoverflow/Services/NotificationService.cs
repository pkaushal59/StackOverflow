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

        internal void Notify(Vote vote, string votedFor)
        {
            string q = vote.QuestionId == 0 ? "Answer" : "Question";
    
            foreach (var subscriber in subscribers)
            {
                Console.WriteLine($"{q} is voted ");
                Console.WriteLine($"{subscriber} is notified");
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
    }
}
