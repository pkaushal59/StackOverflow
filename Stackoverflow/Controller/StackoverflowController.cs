using Stackoverflow.Models;
using Stackoverflow.Services;

namespace Stackoverflow.Controller
{
    public class StackoverflowController
    {
        private AnswerService _answerService;
        private CommentService _commentService;
        private SearchService _searchService;
        private QuestionService _questionService;
        private VoteService _voteService;
        private TagService _tagService;
        private NotificationService _notificationService;

        public StackoverflowController(
            AnswerService answerService,
            CommentService commentService,
            SearchService searchService,
            QuestionService questionService,
            VoteService voteService,
            TagService tagService,
            NotificationService notificationService)
        {
            _answerService = answerService;
            _commentService = commentService;
            _searchService = searchService;
            _questionService = questionService;
            _voteService = voteService;
            _tagService = tagService;
            _notificationService = notificationService;
        }

        //Post
        public void PostQuestion(string desc, int userId, string tag)
        {
            var tagId = _tagService.AddTag(tag, userId);
            _questionService.AddQuestion(desc, userId, tagId);
        }

        //Post
        public void UpdateVotesToQuestion(int up, int down, int questionId)
        {
            _voteService.UpdateVotesForQuestions(up, down, questionId);
        }

        //Post
        public void UpdateVotesToAnswer(int up, int down, int answerId)
        {
            _voteService.UpdateVotesForAnswers(up, down,answerId);
        }

        //Post
        public void GetVotesonQuestion(int questionId)
        {
           var vote=  _voteService.GetVotesonQuestion(questionId);
            var question = _questionService.GetQuestion(questionId);
            Console.WriteLine($"question: {question.Desc} has Up votes: {vote.Up} and DownVotes: {vote.Down}");
        }

        public void AcceptAnswer(int answerId)
        {
            _answerService.AcceptAnswer(answerId);
        }

        public void PostAnswer(string answer, int questionId, int userId)
        {
            _answerService.PostAnswer(answer, questionId, userId);
            _notificationService.Notify(NotificationType.AnswerPosted, "Answer");
        }

        public void AddComment(int answerId, int userId, string comment)
        {
            _commentService.AddComment(answerId, userId, comment);
        }

        public void DeleteComment(int comentId)
        {
            _commentService.DeleteComment(comentId);
        }

        public void SearchQuestionsByTag(string tag)
        {
            var questions = _searchService.SearchByTag(tag);
            Console.WriteLine(string.Join(", ", questions));
        }

        public void GetTagsByUserId(int userId)
        {
           var tags= _tagService.GetTagsByUserId(userId);
            Console.WriteLine(string.Join(", ", tags));
        }
    }
}
