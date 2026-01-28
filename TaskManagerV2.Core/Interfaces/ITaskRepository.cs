using TaskManagerV2.Core.Entities;

namespace TaskManagerV2.Core.Interfaces
{
    public interface ITaskRepository
    {
        IEnumerable<TaskItem> GetAll();
        TaskItem? GetById(int id);
        void Add(TaskItem task);
        void Update(TaskItem task);
        void Delete(int id);
        void Save();
    }
}
