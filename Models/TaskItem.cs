using System;
namespace WebAPI.Models{
    public class TaskItem{
        public Guid Id {get; set;}
        public string title {get; set;}
        public bool IsCompleted {get; set;}
    }
}