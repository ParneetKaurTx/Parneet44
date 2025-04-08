using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
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
        List<Operation_TaskManager> list = new Operation_TaskManager();

        public List<Operation_TaskManager> AddTask(int id, string name, string prior, string deadlinetask)
        {
            var tasks = Items.Find(x => x.ID == id);
            if (!tasks)
            {
                find1.Add(new TaskManagerList(id, name, prior, deadlinetask));
                retrun tasks;


            }
            else
            {
                return null;


            }




        }
    }
}