namespace Stackoverflow.Models
{
    public class IVote
    {
        public int Id { get; set; }
        public int Up { get; set; }
        public int Down { get; set; }
        public int UserId { get; set; }
    }

    public class QuestionVote : IVote
    {
        public int QuestionId { get; set; }
        public int ID => QuestionId;

    }

    public class AnswerVote : IVote
    {
        public int AnswerVoteId { get; set; }
        public int ID => AnswerVoteId;

    }
}
