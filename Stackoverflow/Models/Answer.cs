namespace Stackoverflow.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string Desc { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public bool IsAccepted { get; set; }
    }
}
