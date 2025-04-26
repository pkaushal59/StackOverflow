
using Stackoverflow.Models;

namespace Stackoverflow.Services
{
    public class VoteService
    {
        List<Vote> votes;
        private NotificationService _notificationService;

        public VoteService(NotificationService notificationService)
        {
            votes = [];
            _notificationService = notificationService;
        }

        public void UpdateVotes(int up, int down, int questionId = 0, int answerId = 0)
        {
            var findVote = votes.Find(x => x.QuestionId == questionId
            && x.QuestionId != 0
            && x.AnswerId != 0
            || x.AnswerId == answerId);
            if (findVote != null)
            {
                findVote.Yes += up;
                findVote.No += down;
            }
            else
            {
                findVote = new Vote
                {
                    QuestionId = questionId,
                    Yes = up,
                    No = down,
                    AnswerId = answerId
                };
                votes.Add(findVote);
            }
            _notificationService.Notify(NotificationType.QuestionVoted, $"yes votes{findVote.Yes}, No votes: {findVote.No} for questionid: {findVote.QuestionId}");
        }


        internal Vote GetVotesonQuestion(int questionId)
        {
            return votes.Find(x => x.QuestionId == questionId);
        }
    }
}
