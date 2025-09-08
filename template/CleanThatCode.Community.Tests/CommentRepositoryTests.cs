using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CleanThatCode.Community.Repositories;
using CleanThatCode.Community.Tests.Mocks;

namespace CleanThatCode.Community.Tests
{
    [TestClass]
    public class CommentRepositoryTests
    {
        private CommentRepository _repository;

        [TestInitialize]
        public void Setup()
        {
            var mockContext = new CleanThatCodeDbContextMock();
            _repository = new CommentRepository(mockContext);
        }

        [TestMethod]
        public void GetAllCommentsByPostId_GivenWrongPostId_ShouldReturnNoComments()
        {
            // Act
            var result = _repository.GetAllCommentsByPostId(99); // invalid postId

            // Assert
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void GetAllCommentsByPostId_GivenValidPostId_ShouldReturnTwoComments()
        {
            // Act
            var result = _repository.GetAllCommentsByPostId(1); // valid from FakeData

            // Assert
            Assert.AreEqual(2, result.Count());
        }
    }
}
