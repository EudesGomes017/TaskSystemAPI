using Enums;
using System.Text.Json.Serialization;
namespace Domain.Models
{
    public class ModelTask
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? Description { get; set; }
        public StatusTask Status { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual ModelUser User { get; set; }

    }
}

