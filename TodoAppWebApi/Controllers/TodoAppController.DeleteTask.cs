using TodoAppWebApi.Models;

namespace TodoAppWebApi.Controllers;

public partial class TodoAppController
{
    public BaseResponse performDeleteTask(DeleteRequest request)
    {
        var response = new BaseResponse();

        if (!IsAuthorized())
        {
            response.SetError("Unauthorized");
            return response;
        }

        if(request == null || request.Id <= 0)
        {
            response.SetError("Invalid task ID.");
            return response;
        }

        lock (TasksLock)
        {
            var taskIndex = Tasks.FindIndex(task => task.Id == request.Id);
            if (taskIndex < 0)
            {
                response.SetError($"Error on deleting Task with ID {request.Id}.");
                return response;
            }

            Tasks.RemoveAt(taskIndex);
        }

        response.Success = true;
        response.Message = "Task deleted successfully.";
        return response;
    }
}
