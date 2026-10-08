using TodoAppWebApi.Models;

namespace TodoAppWebApi.Models;

public class TaskResponse: BaseResponse
{
    public List<TaskModel> Tasks { get; set; } = new List<TaskModel>();
}
