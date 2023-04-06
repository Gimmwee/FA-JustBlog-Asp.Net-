using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repository.ImplementRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.UnitTests.RepositoryTests
{
    [TestFixture]
    public class PostRepositoryTests : BaseTest
    {
        public PostRepositoryTests() : base()
        {

        }

        [OneTimeTearDown]
        public void Clean()
        {
            _context.Database.EnsureDeleted();
        }
        /// <summary>
        /// test get all
        /// </summary>
        [Test]
        public void GetAll_WhenCalled_ReturnValue()
        {
            //Arrange

            //Act
            var result = postRepository.GetAll();

            // Assert
            Assert.That(result.Count, Is.EqualTo(3));
        }
        /// <summary>
        /// test find post by id
        /// </summary>
        [Test]
        public void Find_WhenCalledWithValidPostId_ReturnsPost()
        {
            //Arrange
            int postId = 2;

            //Act
            var result = postRepository.Find(postId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.PostId, Is.EqualTo(postId));
        }
        /// <summary>
        /// test get publishedpost
        /// </summary>
        [Test]
        public void GetPublisedPosts_WhenCalled_ReturnsOnlyPublishedPosts()
        {
            // Act
            var result = postRepository.GetPublisedPosts();

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
        }
        /// <summary>
        /// test find post
        /// </summary>
        [Test]
        public void FindPost_WhenCalledWithValidYearMonthAndUrlSlug_ReturnsPost()
        {
            //Arrange
            int year = 2023;
            int month = 3;
            string urlSlug = "how-to-build-a-responsive-website";


            //Act
            var result = postRepository.FindPost(year, month, urlSlug);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.PostedOn.Value.Year, Is.EqualTo(year));
            Assert.That(result.PostedOn.Value.Month, Is.EqualTo(month));
            Assert.That(result.UrlSlug, Is.EqualTo(urlSlug));
        }
        /// <summary>
        /// test add post
        /// </summary>
        [Test]
        public void AddPost_WhenCalled_AddsPost()
        {
            //Arrange
            Post postToAdd = new Post
            {
                PostId = 4,
                Title = "Introduction to Java Programming",
                ShortDescription = "Learn the basics of C#.",
                PostContent = "Modernweb applicationsoperators and control structures.",
                UrlSlug = "introduction-to-java-programming",
                Published = true,
                PostedOn = DateTime.Now,
                Modified = DateTime.Now,
                CategoryId = 1,
            };

            //Act
            postRepository.Add(postToAdd);


            var result = postRepository.Find(postToAdd.PostId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.PostId, Is.EqualTo(postToAdd.PostId));
            Assert.That(result.Title, Is.EqualTo(postToAdd.Title));
        }
        /// <summary>
        /// test update
        /// </summary>
        [Test]
        public void UpdatePost_WhenCalled_UpdatesPost()
        {
            //Arrange

            // Act
            var postToUpdate = postRepository.Find(2);

            if (postToUpdate == null)
            {
                Assert.Fail("Could not find title with PostId = 2");
            }

            postToUpdate.Title = "Updated Post Title!!";

            postRepository.Update(postToUpdate);

            var result = postRepository.GetAll();

            // Assert
            Assert.AreEqual(postToUpdate.Title, "Updated Post Title!!");
        }
        /// <summary>
        /// test delete
        /// </summary>
        [Test]
        public void DeletePost_WhenCalled_DeletesPost()
        {
            //Arrange
            int postId = 3;
            Post postToDelete = postRepository.Find(postId);

            //Act
            postRepository.Delete(postToDelete);

            var result = postRepository.Find(postId);

            // Assert
            Assert.That(result, Is.Null);
        }
        /// <summary>
        /// test deletepost
        /// </summary>
        [Test]
        public void DeletePost_WhenCalledWithPostId_DeletesPost()
        {
            //Arrange
            int postId = 3;

            //Act
            postRepository.Delete(postId);


            var result = postRepository.Find(postId);

            // Assert
            Assert.That(result, Is.Null);
        }
        /// <summary>
        /// get unpublishedpost
        /// </summary>

        [Test]
        public void GetUnpublisedPosts_WhenCalled_ReturnsOnlyUnpublishedPosts()
        {
            // Act
            var result = postRepository.GetUnpublisedPosts();

            // Assert
            Assert.That(result.Count, Is.EqualTo(1));
        }
        /// <summary>
        /// get latest post
        /// </summary>
        [Test]
        public void GetLatestPosts_WhenCalled_ReturnValue()
        {
            int size = 3;
            var result = postRepository.GetLatestPost(size);
            Assert.AreEqual(size, result.Count());
        }
        /// <summary>
        /// get post by month
        /// </summary>
        [Test]
        public void GetPostsByMonth_WhenMonthExists_ReturnPosts()
        {
            // Arrange
            var monthYear = new DateTime(2023, 3, 1);

            // Act
            var result = postRepository.GetPostsByMonth(monthYear);

            // Assert
            Assert.That(result.Count, Is.EqualTo(3));
        }
        /// <summary>
        /// count post for category
        /// </summary>
        [Test]
        public void CountPostsForCategory_WhenCategoryExists_ReturnCount()
        {
            // Arrange
            var categoryName = "About Us";

            // Act
            var result = postRepository.CountPostsForCategory(categoryName);

            // Assert
            Assert.That(result, Is.EqualTo(1));
        }
        /// <summary>
        /// test get post by category
        /// </summary>
        [Test]
        public void GetPostsByCategory_WhenCategoryExists_ReturnPosts()
        {
            // Arrange
            var categoryName = "About Us";

            // Act
            var result = postRepository.GetPostsByCategory(categoryName);

            // Assert
            Assert.That(result.Count, Is.EqualTo(1));
        }

    }
}

