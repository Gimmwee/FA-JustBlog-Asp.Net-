using FA.JustBlog.Core.Common;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repository.UnitOfWork;
using FA.JustBlog.UI.Manager;
using System.Diagnostics;
using System;
using System.Xml.Linq;

namespace FA.JustBlog.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Menu();
            //var m = new PostManager();
            //Console.WriteLine("----------------AllPost-----------------");
            //m.DisplayAllPost();

            //Console.WriteLine("----Findpost-----");
            //m.FindPost();

            //Console.WriteLine("---------------Category--------------");
            //DisplayAllCategory();

            //Console.WriteLine("-------------------------Tag--------------------------");
            //DisplayAllTag();

            //Console.WriteLine("--------------------------------------Comment--------------------------------------------------");
            //DisplayAllComment();




        }
        /// <summary>
        /// /display all category
        /// </summary>
        public static void DisplayAllCategory()
        {
            using (var uow = new UnitOfWork())
            {
                var categorys = uow.CategoryRepository.GetAll();

                categorys.ToList().ForEach(b => Console.WriteLine($"{b.CategoryId}|" +
                    $"{b.Name}\t|" +
                    $"{b.UrlSlug}\t|" +
                    $"{b.Desciption}\t|"
                   ));
            }
        }
        /// <summary>
        /// display all comment
        /// </summary>
        public static void DisplayAllComment()
        {
            using (var uow = new UnitOfWork())
            {
                var comments = uow.CommentRepository.GetAll();

                comments.ToList().ForEach(b => Console.WriteLine($"{b.CommentId}|" +
                    $"{b.Name}\t|" +
                    $"{b.Email}\t|" +
                    $"{b.PostId}\t|" +
                    $"{b.CommentHeader}\t|" +
                    $"{b.CommentText}\t|" +
                    $"{b.CommentTime}\t|"
                  ));
            }
        }
        /// <summary>
        /// display all tag
        /// </summary>
        public static void DisplayAllTag()
        {
            using (var uow = new UnitOfWork())
            {
                var tags = uow.TagRepository.GetAll();

                tags.ToList().ForEach(b => Console.WriteLine($"{b.TagId}|" +
                    $"{b.Name}\t|" +
                    $"{b.UrlSlug}\t|" +
                    $"{b.Description}\t|" +
                    $"{b.Count}\t|"
                   ));
            }
        }
        public static void Menu()
        {

            do
            {
                var m = new PostManager();
                Console.WriteLine("6. Convert to UrlSlug");
                Console.WriteLine("1. AddComment");
                Console.WriteLine("2. GetAllComment");
                Console.WriteLine("3. GetAllTag");
                Console.WriteLine("4. GetAllCategory");
                Console.WriteLine("5. FindPost");
                Console.WriteLine("0. Exit");
                int choice;
                do
                {
                    Console.Write("--Enter Choice:");
                } while (!int.TryParse(Console.ReadLine(), out choice));
                switch (choice)
                {
                    case 1:
                        AddComment();
                        break;
                    case 2:
                        DisplayAllComment();
                        break;
                    case 3:
                        DisplayAllTag();
                        break;
                    case 4:
                        DisplayAllCategory();
                        break;
                    case 5:
                        m.FindPost();
                        break;
                    case 6:
                        Console.WriteLine("Input here:");
                        Console.WriteLine(SeoUrlHepler.ToUrlSlug(Console.ReadLine()));
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Wrong choice!");
                        break;
                }
            } while (true);
        }
        /// <summary>
        /// add comment
        /// </summary>
        public static void AddComment()
        {
            using (var uow = new UnitOfWork())
            {
                int postId;
                do
                {
                    Console.Write("Enter PostId: ");
                } while (!int.TryParse(Console.ReadLine(), out postId));
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Email: ");
                string email = Console.ReadLine();
                Console.Write("Enter CommentHeader: ");
                string commentHeader = Console.ReadLine();
                Console.Write("Enter CommentText: ");
                string commentText = Console.ReadLine();
                var newComment = new Comment
                {
                    PostId = postId,
                    Name = name,
                    Email = email,
                    CommentHeader = commentHeader,
                    CommentText = commentHeader,
                };

                uow.CommentRepository.Add(newComment);

                // Commit changes to database
                uow.SaveChange();
                Console.WriteLine("Create Comment successfully.");
            }
        }
    }
}