using TodoAppWebApi.Models;

namespace TodoAppWebApi.Controllers;

public partial class TodoAppController
{
    public TaskResponse performGetAllTasks()
    {
        var response = new TaskResponse();

        if (!IsAuthorized())
        {
            response.SetError("Unauthorized");
            return response;
        }

        lock (TasksLock)
        {
            response.Tasks = new List<TaskModel>(Tasks);
        }

        response.Success = true;
        return response;
    }
}
