namespace Stackoverflow.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Desc { get; set; }
        public int UserId { get; set; }
        public int TagId { get; set; }
    }
}
