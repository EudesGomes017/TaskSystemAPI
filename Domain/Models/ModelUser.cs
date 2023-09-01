namespace Domain.Models
{
    public class ModelUser
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int TaskId { get; set; }
        public virtual ICollection<ModelTask?> ModelTasks { get; set; }

    }
}

