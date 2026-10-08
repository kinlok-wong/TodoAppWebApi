using Microsoft.AspNetCore.Mvc;
using TodoAppWebApi.Models;

namespace TodoAppWebApi.Controllers
{
    [ApiController]
    [Route("TodoApp")]
    public partial class TodoAppController : ControllerBase
    {
        private const string ApiKey = "dbc06188-f82b-4dc4-9c62-71c410d07fb4";
        private static readonly List<TaskModel> Tasks = new();
        private static readonly object TasksLock = new();
        private static int _nextTaskId;

        [HttpGet]
        [Route("GetAllTasks")]
        public TaskResponse GetAllTasks()
        {
            return performGetAllTasks();
        }

        [HttpPost]
        [Route("AddTask")]
        public BaseResponse AddTask([FromBody] TaskModel taskModel)
        {
           return performAddTask(taskModel);
        }

        [HttpPost]
        [Route("DeleteTask")]
        public BaseResponse DeleteTask([FromBody] DeleteRequest request)
        {
            return performDeleteTask(request);
        }

        private bool IsAuthorized()
        {
            string? authorizationHeader = HttpContext.Request.Headers["x-api-key"].ToString();

            if (string.IsNullOrEmpty(authorizationHeader)) return false;

            var headerKey = authorizationHeader.Trim();  

            return headerKey == ApiKey;
        }
    }
}
