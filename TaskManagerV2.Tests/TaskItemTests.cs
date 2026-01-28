using TaskManagerV2.Core.Entities;
using Xunit;

namespace TaskManagerV2.Tests
{
    public class TaskItemTests
    {
        [Fact]
        public void NewTask_IsNotDone_ByDefault()
        {
            // Arrange
            var task = new TaskItem("Test task");

            // Assert
            Assert.False(task.IsDone);
            Assert.Null(task.CompletedAt);
        }

        [Fact]
        public void MarkDone_SetsIsDoneAndCompletedAt()
        {
            // Arrange
            var task = new TaskItem("Test task");

            // Act
            task.MarkDone();

            // Assert
            Assert.True(task.IsDone);
            Assert.NotNull(task.CompletedAt);
        }

        [Fact]
        public void Reopen_Task_ClearsCompletedAt()
        {
            // Arrange
            var task = new TaskItem("Test task");
            task.MarkDone();

            // Act
            task.Reopen();

            // Assert
            Assert.False(task.IsDone);
            Assert.Null(task.CompletedAt);
        }
    }
}
