using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using CleanThatCode.Community.Models.Entities;
using CleanThatCode.Community.Repositories.Data;
using CleanThatCode.Community.Repositories.Implementations;

namespace CleanThatCode.Community.Tests
{
    [TestClass]
    public class PostRepositoryTests
    {
        private PostRepository _repository;
        private Mock<ICleanThatCodeDbContext> _mockContext;
        private List<Post> _fakePosts; // <-- class-level field

        [TestInitialize]
        public void Setup()
        {
            // Generate fake posts using Bogus
            _fakePosts = new Faker<Post>()
                .RuleFor(p => p.Id, f => f.IndexFaker + 1)
                .RuleFor(p => p.Title, f => f.Lorem.Sentence())
                .RuleFor(p => p.Author, f => f.Person.FullName)
                .RuleFor(p => p.Message, f => f.Lorem.Paragraph())
                .RuleFor(p => p.Created, f => f.Date.Recent())
                .RuleFor(p => p.NumberOfLikes, f => f.Random.Int(0, 100))
                .Generate(5); // generate 5 fake posts

            // Mock the DbContext
            _mockContext = new Mock<ICleanThatCodeDbContext>();
            _mockContext.Setup(c => c.Posts).Returns(_fakePosts);

            // Pass mocked context into PostRepository
            _repository = new PostRepository(_mockContext.Object);
        }

        [TestMethod]
        public void GetAllPosts_ShouldReturnAllPosts()
        {
            var result = _repository.GetAllPosts("", ""); // pass empty filters
            Assert.AreEqual(_fakePosts.Count, result.Count());
        }

        [TestMethod]
        public void GetAllPosts_ShouldFilterByTitle()
        {
            var firstTitle = _fakePosts[0].Title;
            var result = _repository.GetAllPosts(firstTitle, "");
            Assert.IsTrue(result.All(p => p.Title.Contains(firstTitle)));
        }

        [TestMethod]
        public void GetAllPosts_ShouldFilterByAuthor()
        {
            var firstAuthor = _fakePosts[0].Author;
            var result = _repository.GetAllPosts("", firstAuthor);
            Assert.IsTrue(result.All(p => p.Author.Contains(firstAuthor)));
        }
    }
}
