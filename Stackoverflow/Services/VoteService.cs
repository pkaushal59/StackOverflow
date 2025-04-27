
using Stackoverflow.Models;

namespace Stackoverflow.Services
{
    public class VoteService
    {
        List<IVote> votes;
        private NotificationService _notificationService;

        public VoteService(NotificationService notificationService)
        {
            votes = [];
            _notificationService = notificationService;
        }

        internal IVote GetVotesonQuestion(int questionId)
        {
            return votes.FirstOrDefault(x => x.Id == questionId);
        }

        internal void UpdateVotes<T>(int up, int down, int id) where T : IVote, new()
        {
            var findVote = votes.FirstOrDefault(x => x.Id == id);

            if (findVote != null)
            {
                findVote.Up += up;
                findVote.Down += down;
            }
            else
            {
                findVote = new T
                {
                    Up = up,
                    Down = down
                };
                // Dynamically set the ID (using reflection or conditional logic)
                if (findVote is QuestionVote questionVote)
                    questionVote.QuestionId = id;

                if (findVote is AnswerVote answerVote)
                    answerVote.AnswerVoteId = id;

                votes.Add(findVote);
            }

            _notificationService.Notify(NotificationType.QuestionVoted, $"Yes votes: {findVote.Up}, No votes: {findVote.Down} for Id: {findVote.Id}");
        }
    }
}
