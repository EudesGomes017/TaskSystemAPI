using Domain.Models;
using Enums;
namespace Domain.Dto
{
    public class ModelTaskDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public StatusTask Status { get; set; }
        public int UserId { get; set; }


    }
}


