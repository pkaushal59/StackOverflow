
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

        public void UpdateVotesForQuestions(int up, int down, int questionId)
        {
            var findVote = votes.Find(x => x.Id == questionId);
            if (findVote != null)
            {
                findVote.Up += up;
                findVote.Down += down;
            }
            else
            {
                findVote = new QuestionVotes
                {
                    QuestionId = questionId,
                    Up = up,
                    Down = down,
                };
                votes.Add(findVote);
            }
            _notificationService.Notify(NotificationType.QuestionVoted, $"yes votes{findVote.Up}, No votes: {findVote.Down} for questionid: {findVote.QuestionId}");
        }

        public void UpdateVotesForAnswers(int up, int down, int answerId)
        {
            var findVote = votes.Find(x => x.Id == answerId);
            if (findVote != null)
            {
                findVote.Up += up;
                findVote.Down += down;
            }
            else
            {
                findVote = new AnswerVote
                {
                    Up = up,
                    Down = down,
                    AnswerVoteId = answerId
                };
                votes.Add(findVote);
            }
            _notificationService.Notify(NotificationType.QuestionVoted, $"yes votes{findVote.Up}, No votes: {findVote.Down} for questionid: {findVote.Id}");
        }


        internal IVote GetVotesonQuestion(int questionId)
        {
            return votes.Find(x => x.Id == questionId);
        }
    }
}
