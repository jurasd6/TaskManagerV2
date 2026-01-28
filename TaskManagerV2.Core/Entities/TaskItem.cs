namespace TaskManagerV2.Core.Entities
{
    public class TaskItem
    {
        public int Id { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public bool IsDone { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? CompletedAt { get; private set; }

        protected TaskItem() { }

        public TaskItem(string title, string? description = null)
        {
            Title = title;
            Description = description;
            IsDone = false;
            CreatedAt = DateTime.Now;
            CompletedAt = null;
        }

        public void MarkDone()
        {
            IsDone = true;
            CompletedAt = DateTime.Now;
        }

        public void Reopen()
        {
            IsDone = false;
            CompletedAt = null;
        }

        public void UpdateDescription(string? description)
        {
            Description = description;
        }
    }
}
