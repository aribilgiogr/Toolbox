using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbox.Test.Fakes;

namespace Toolbox.Test.Generics
{
    public class RepositoryTests
    {
        private readonly FakeDBContext context;
        private readonly FakeRepository repository;

        public RepositoryTests()
        {
            var options = new DbContextOptionsBuilder<FakeDBContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            context = new FakeDBContext(options);
            repository = new FakeRepository(context);
        }

        [Fact]
        public async Task CreateAsync_ShouldAddEntity()
        {
            // Arrange
            var entity = new FakeEntity { Id = 1, Name = "Test Entity 1", Age = 30 };

            // Act
            await repository.CreateAsync(entity);

            // Assert
            var result = await repository.FindByIdAsync(1);
            Assert.NotNull(result);
            Assert.Equal("Test Entity 1", result.Name);
        }

        [Fact]
        public async Task DeleteAsync_SoftDelete_ShouldMarkAsDeleted()
        {
            // Arrange
            var entity = new FakeEntity { Id = 2, Name = "Test Entity 2", Age = 30 };
            await repository.CreateAsync(entity);

            // Act
            await repository.DeleteAsync(entity, soft_delete: true);

            // Assert
            var result = await repository.FindByIdAsync(2);
            Assert.NotNull(result);
            Assert.True(result.Deleted);
        }

        [Fact]
        public async Task DeleteAsync_HardDelete_ShouldRemoveFromDb()
        {
            // Arrange
            var entity = new FakeEntity { Id = 3, Name = "Test Entity 3", Age = 30 };
            await repository.CreateAsync(entity);

            // Act
            await repository.DeleteAsync(entity, soft_delete: false);

            // Assert
            var result = await repository.FindByIdAsync(3);
            Assert.Null(result);
        }
    }
}
