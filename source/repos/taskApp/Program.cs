namespace taskApp
{

    public class Operation_TaskManager
    {
        public int ID;
        public string NameTask;
        public string Priority;
        public string Deadline;

        public Operation_TaskManager(int id, string nametask, string priority, string deadline)
        {
            ID = id;
            NameTask = nametask;
            Priority = priority;
            Deadline = deadline;
        }






    }



    public class TaskManagerList
    {
        List<Operation_TaskManager> list = new List<Operation_TaskManager>();

        public List<Operation_TaskManager> AddTask(int id, string name, string prior, string deadlinetask)
        {
            var tasks = list.Find(x => x.ID == id);
            if (tasks==null)
            {
                list.Add(new Operation_TaskManager(id, name, prior, deadlinetask));
                return list;


            }
            else
            {
                return null;


            }




        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press '1.' if you want to add any task");
            Console.WriteLine("Press '2.' if you want to update any task");
        }
    }
}
