using System.Collections.Generic;
using CleanThatCode.Community.Models.Entities;
using CleanThatCode.Community.Repositories.Data;

namespace CleanThatCode.Community.Tests.Mocks
{
    public class CleanThatCodeDbContextMock : ICleanThatCodeDbContext
    {
        // implement interface exactly
        public IEnumerable<Comment> Comments { get; private set; }
        public IEnumerable<Post> Posts { get; private set; }

        public CleanThatCodeDbContextMock()
        {
            // use FakeData.cs to populate
            Comments = FakeData.Comments;
            Posts = FakeData.Posts;
        }
    }
}
