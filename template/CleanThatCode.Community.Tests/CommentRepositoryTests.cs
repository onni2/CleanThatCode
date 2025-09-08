using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CleanThatCode.Community.Repositories.Implementations;
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
            var result = _repository.GetAllCommentsByPostId(99); // invalid id
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void GetAllCommentsByPostId_GivenValidPostId_ShouldReturnTwoComments()
        {
            var validPostId = 1; // check FakeData for a valid post with 2 comments
            var result = _repository.GetAllCommentsByPostId(validPostId);
            Assert.AreEqual(2, result.Count());
        }
    }
}
