
using Stackoverflow.Models;

namespace Stackoverflow.Services
{
    public class CommentService
    {
        List<Comment> comments;

        public CommentService()
        {
            comments = [];
        }
        public void AddComment(int answerId, int userId, string comment)
        {
            var newComment = new Comment
            {
                AnswerId = answerId,
                UserId = userId,
                Desc = comment,
                CommentId = comments.Count + 1
            };

            comments.Add(newComment);
        }

        internal void DeleteComment(int comentId)
        {
            var comment = comments.FirstOrDefault(x=> x.CommentId == comentId);
        }
    }
}
