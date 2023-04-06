using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.UnitTests.RepositoryTests
{
    public class TagRepositoryTests : BaseTest
    {
        public TagRepositoryTests() : base()
        {
        }

        [OneTimeTearDown]
        public void Clean()
        {
            _context.Database.EnsureDeleted();
        }

        /// <summary>
        /// test get all tag
        /// </summary>
        [Test]
        public void GetAll_WhenCalled_ReturnValue()
        {
            //Arrange

            //Act
            var result = tagRepository.GetAll();


            // Assert
            Assert.That(result.Count, Is.EqualTo(3));
        }
        /// <summary>
        /// test find
        /// </summary>
        [Test]
        public void Find_WhenCalledWithValidTagIdId_ReturnsTag()
        {
            //Arrange
            int tagId = 2;

            //Act
            var result = tagRepository.Find(tagId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.TagId, Is.EqualTo(tagId));
        }
        /// <summary>
        /// test find
        /// </summary>
        [Test]
        public void Find_WhenCalledWithInvalidTagIdId_ReturnsNull()
        {
            //Arrange
            int tagId = 9;

            //Act
            var result = tagRepository.Find(tagId);
            _context.SaveChanges();
            // Assert
            Assert.That(result, Is.Null);
        }
        /// <summary>
        /// test add tag
        /// </summary>
        [Test]
        public void AddTag_WhenCalled_AddsTag()
        {
            //Arrange
            Tag tagToAdd = new Tag
            {
                TagId = 4,
                Name = "Java Springboot",
                UrlSlug = "java-springboot",
                Description = "Jaba programming language",
                Count = 3
            };

            //Act
            tagRepository.Add(tagToAdd);
            _context.SaveChanges();

            var result = tagRepository.Find(tagToAdd.TagId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.TagId, Is.EqualTo(tagToAdd.TagId));
            Assert.That(result.Name, Is.EqualTo(tagToAdd.Name));
        }

        /// <summary>
        /// test update
        /// </summary>
        [Test]
        public void UpdateTag_WhenCalled_UpdateTag()
        {
            //Arrange

            // Act
            var tagToUpdate = tagRepository.Find(2);

            if (tagToUpdate == null)
            {
                Assert.Fail("Could not find category with CategoryId = 2");
            }

            tagToUpdate.Name = "Updated Category Name!!";

            tagRepository.Update(tagToUpdate);

            var result = tagRepository.GetAll();

            // Assert
            Assert.AreEqual(tagToUpdate.Name, "Updated Category Name!!");
        }
        /// <summary>
        /// test delete
        /// </summary>
        [Test]
        public void DeleteTag_WhenCalled_DeletesTag()
        {
            //Arrange
            int tagId = 1;
            Tag tagToDelete = tagRepository.Find(tagId);

            //Act
            tagRepository.Delete(tagToDelete);


            var result = tagRepository.Find(tagId);
            _context.SaveChanges();
            // Assert

            Assert.That(result, Is.Null);
        }
        /// <summary>
        /// test delete tag
        /// </summary>
        [Test]
        public void DeleteTag_WhenCalledWithTagId_DeletesTag()
        {
            //Arrange
            int TagId = 1;

            //Act
            tagRepository.Delete(TagId);


            var result = tagRepository.Find(TagId);
            _context.SaveChanges();
            // Assert
            Assert.That(result, Is.Null);
        }
        /// <summary>
        /// test get tag by urlslug
        /// </summary>
        [Test]
        public void GetTagsByUrlSlug_WhenTagExists_ReturnTags()
        {
            // Arrange
            string urlSlug = "responsive-design";

            // Act
            var result = tagRepository.GetTagByUrlSlug(urlSlug);

            // Assert
            Assert.That(result.Count, Is.EqualTo(1));
        }
    }
}
