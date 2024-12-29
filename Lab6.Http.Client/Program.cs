using Lab6.Http.Common;
using System.Threading.Tasks;

internal class Program
{
    private static object _locker = new object();

    public static async Task Main(string[] args)
    {
        var httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:5214/api/")
        };

        var taskApiClient = new TaskApiClient(httpClient);

        await ManageTasks(taskApiClient);
    }

    private static async Task ManageTasks(ITaskApi taskApi)
    {
        //PrintMenu();

        while (true)
        {
            string[] Array = new string[7]; // Создаём массив из 5 элементов

            // Заполняем массив данными о погоде
            Array[0] = "Active";
            Array[1] = "Pause";
            Array[2] = "Off";
            Console.Clear();
            var tasks = await taskApi.GetAllAsync();
            Console.Clear();
            Console.WriteLine($"|    Id |             UserName |        Activity |");
            foreach (var task in tasks)
            {
                Console.WriteLine($"| {task.Id,5} | {task.Name,20} | {task.Active,15} | ");
            }
            Thread.Sleep(5000);
            Random random = new Random();

            int UserId = random.Next(1, 6);
            int ActivityId = random.Next(0, 3);
            Console.WriteLine(UserId);
            Console.WriteLine(ActivityId);
            string UserIdId = UserId.ToString();
            var userIdString = UserIdId;
            int.TryParse(userIdString, out var userId);
            var task1 = await taskApi.GetAsync(userId);
            var Name = task1?.Name;
            var Active = task1?.Active;

            var newTask = new TaskItem(
                id: task1.Id,
                name: task1?.Name,
                active: Array[ActivityId]
            );
            var addResult = await taskApi.UpdateAsync(UserId, newTask);
        }
    }
}