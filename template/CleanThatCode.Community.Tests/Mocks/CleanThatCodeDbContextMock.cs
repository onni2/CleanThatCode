using System.Linq;
using CleanThatCode.Community.Models.Entities;
using CleanThatCode.Community.Repositories;

namespace CleanThatCode.Community.Tests.Mocks
{
    public class CleanThatCodeDbContextMock : ICleanThatCodeDbContext
    {
        public IQueryable<Post> Posts { get; }
        public IQueryable<Comment> Comments { get; }

        public CleanThatCodeDbContextMock()
        {
            Posts = FakeData.Posts.AsQueryable();
            Comments = FakeData.Comments.AsQueryable();
        }
    }
}
