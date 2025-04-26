namespace Stackoverflow.Models
{
    public class Vote
    {
        public int Yes { get; set; }
        public int No { get; set; }
        public int QuestionId{ get; set; }
        public int AnswerId { get; set; }
    }
}
