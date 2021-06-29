using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        List<TaskItem> taskItems = new List<TaskItem>{
                new TaskItem(){
                    title = "title 1",
                    IsCompleted = false
                },
                new TaskItem(){
                    title = "title 2",
                    IsCompleted = true
                },
                new TaskItem(){
                    title = "title 3",
                    IsCompleted = false
                },
                new TaskItem(){
                    title = "title 4",
                    IsCompleted = true
                },
            };

        [HttpGet]
        public IEnumerable<TaskItem> GetList()
        {
            return taskItems;
        }

        [HttpPost]
        public List<TaskItem> CreateItem(TaskItem task)
        {
            task.Id = Guid.NewGuid();
            taskItems.Add(task);
            return taskItems;
        }

        [HttpGet("GetItem")]
        public TaskItem GetItem(string title)
        {
            return taskItems.Find(x => x.title == title);
        }

        [HttpPut("UpdateItem")]
        public List<TaskItem> UpdateItem(string title)
        {
            var item = taskItems.Find(x => x.title == title);
            item.IsCompleted = true;
            return taskItems;
        }

        [HttpDelete("Delete")]
        public List<TaskItem> DeleteItem(string title)
        {
            TaskItem item = taskItems.Find(x => x.title == title);
            taskItems.Remove(item);
            return taskItems;
        }

        [HttpPost("BulkAdd")]
        public List<TaskItem> AddBulkItems(TaskItem task)
        {
            for (int i = 1; i <= 5; i++)
            {
                if (i % 2 == 0)
                {
                    taskItems.Add(new TaskItem()
                    {
                        Id = Guid.NewGuid(),
                        title = "title " + (i + 4),
                        IsCompleted = true,

                    });
                }else{
                    taskItems.Add(new TaskItem()
                    {
                        Id = Guid.NewGuid(),
                        title = "title " + (i + 4),
                        IsCompleted = false,
                    });
                }
            }
            return taskItems;
        }

        [HttpDelete("BulkDel")]
        public List<TaskItem> DelBulkItems (int num)
        {
            for (int i = 1; i <= num; i++)
            {
                TaskItem item = taskItems.Find(x => x.title == $"title {i}" );
                taskItems.Remove(item);
            }
            return taskItems;
        }
    }
}