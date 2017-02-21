using DemoAppPortable.BusinessLayer.Contracts;

namespace DemoAppPortable.BusinessLayer.Entities
{
    public class TaskEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Detail { get; set; }
        public bool Done { get; set; }
    }
}
