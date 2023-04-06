using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repository.ImplementRepo;
using FA.JustBlog.Core.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FA.JustBlog.UnitTests.RepositoryTests
{
    [TestFixture]
    public class CategoryRepositoryTests : BaseTest
    {
        public CategoryRepositoryTests() : base()
        {
        }

        [OneTimeTearDown]
        public void Clean()
        {
            _context.Database.EnsureDeleted();
        }

        /// <summary>
        /// get all
        /// </summary>
        [Test]
        public void GetAll_WhenCalled_ReturnValue()
        {
            //Arrange

            //Act
            var result = categoryRepository.GetAll();


            // Assert
            Assert.That(result.Count, Is.EqualTo(3));
        }
        /// <summary>
        /// find with categoryid
        /// </summary>
        [Test]
        public void Find_WhenCalledWithValidCategoryId_ReturnsCategory()
        {
            //Arrange
            int categoryId = 2;

            //Act
            var result = categoryRepository.Find(categoryId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.CategoryId, Is.EqualTo(categoryId));
        }
        /// <summary>
        /// find
        /// </summary>
        [Test]
        public void Find_WhenCalledWithInvalidCategoryId_ReturnsNull()
        {
            //Arrange
            int categoryId = 8;

            //Act
            var result = categoryRepository.Find(categoryId);
            _context.SaveChanges();
            // Assert
            Assert.That(result, Is.Null);
        }
        /// <summary>
        /// test add
        /// </summary>
        [Test]
        public void AddCategory_WhenCalled_AddsCategory()
        {
            //Arrange
            Category categoryToAdd = new Category
            {
                CategoryId = 4,
                Name = "Toi la chien si",
                UrlSlug = "toi-la-chien-si",
                Desciption = "Learn more about our.",
            };

            //Act
            categoryRepository.Add(categoryToAdd);
            _context.SaveChanges();

            var result = categoryRepository.Find(categoryToAdd.CategoryId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.CategoryId, Is.EqualTo(categoryToAdd.CategoryId));
            Assert.That(result.Name, Is.EqualTo(categoryToAdd.Name));
        }
        /// <summary>
        /// test update
        /// </summary>
        [Test]
        public void UpdateCategory_WhenCalled_UpdatesCategory()
        {
            //Arrange

            // Act
            var categoryToUpdate = categoryRepository.Find(2);

            if (categoryToUpdate == null)
            {
                Assert.Fail("Could not find category with CategoryId = 2");
            }

            categoryToUpdate.Name = "Updated Category Name!!";

            categoryRepository.Update(categoryToUpdate);

            var result = categoryRepository.GetAll();

            // Assert
            Assert.AreEqual(categoryToUpdate.Name, "Updated Category Name!!");
        }
        /// <summary>
        /// test delete
        /// </summary>
        [Test]
        public void DeleteCategory_WhenCalled_DeletesCategory()
        {
            //Arrange
            int categoryId = 1;
            Category categoryToDelete = categoryRepository.Find(categoryId);

            //Act
            categoryRepository.Delete(categoryToDelete);


            var result = categoryRepository.Find(categoryId);
            _context.SaveChanges();
            // Assert

            Assert.That(result, Is.Null);
        }
        /// <summary>
        /// test delete
        /// </summary>
        [Test]
        public void DeleteCategory_WhenCalledWithCategoryId_DeletesCategory()
        {
            //Arrange
            int categoryId = 1;

            //Act
            categoryRepository.Delete(categoryId);


            var result = categoryRepository.Find(categoryId);
            _context.SaveChanges();
            // Assert
            Assert.That(result, Is.Null);
        }
    }
}
