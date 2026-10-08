using TodoAppWebApi.Models;

namespace TodoAppWebApi.Controllers;

public partial class TodoAppController
{
    public BaseResponse performAddTask(TaskModel taskModel)
    {
        var response = new BaseResponse();

        if (!IsAuthorized())
        {
            response.SetError("Unauthorized");
            return response;
        }

        if(taskModel == null)
        {
            response.SetError("Task model cannot be null.");
            return response;
        }

        lock (TasksLock)
        {
            taskModel.Id = ++_nextTaskId;
            Tasks.Add(taskModel);
        }

        response.Success = true;
        response.Message = "Task added successfully.";
        return response;
    }
}
