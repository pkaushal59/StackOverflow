// See https://aka.ms/new-console-template for more information
using Stackoverflow.Controller;
using Stackoverflow.Services;
using System;
using System.Runtime.CompilerServices;

Console.WriteLine("Welcome to Stackoverflow");
NotificationService notificationService = new();
AnswerService answerService = new(notificationService);
CommentService commentService = new();
SearchService searchService = new();
TagService tagService = new();
QuestionService questionService = new(tagService, notificationService);
VoteService voteService = new(notificationService);

StackoverflowController stc = new(answerService, commentService, searchService,
    questionService, voteService, tagService, notificationService);
bool flag = true;

while (flag)
{
    SelectChoice();
    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            Console.WriteLine("Provide question");
            string ques = Console.ReadLine();
            Console.WriteLine("Provide tag");
            string tag = Console.ReadLine();
            stc.PostQuestion(ques, 1, tag);
            break;
        case 2:
            Console.WriteLine("Press 1 for up vote and 0 for downVote");
            int vote = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Provide questionId");
            int questionId = Convert.ToInt32(Console.ReadLine());
            stc.UpdateVotesToQuestion(vote == 1 ? 1 : 0, vote == 0 ? 1 : 0, questionId);
            break;
        case 10:
            Console.WriteLine("Provide questionId");
            questionId = Convert.ToInt32(Console.ReadLine());
            stc.GetVotesonQuestion(questionId);
            break;
        case 11:
            flag = false;
            break;

    }
}

void SelectChoice()
{
    Console.WriteLine("Select Choice:");
    Console.WriteLine("1: Postquestion");
    Console.WriteLine("2: Update Votes To Question");
    Console.WriteLine("3: Update Votes To Answer");
    Console.WriteLine("4: AcceptAnswer");
    Console.WriteLine("5: PostAnswer");
    Console.WriteLine("6: AddComment");
    Console.WriteLine("7: DeleteComment");
    Console.WriteLine("8: Search Questions By Tag");
    Console.WriteLine("9: Get Tags By UserId");
    Console.WriteLine("10: Get Votes on Question");
    Console.WriteLine("11: Exit");
}

