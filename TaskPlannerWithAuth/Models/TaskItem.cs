using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPlanner.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsCompleted { get; set; }
        public int UserId { get; set; }
        public int SharedWithUserId { get; set; } // 0 если не shared
    }

    public enum SortType
    {
        ByCreationDate,
        ByDueDate
    }
}