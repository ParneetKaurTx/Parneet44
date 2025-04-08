class TaskCategory
{
    string name;
    string deadline;
    int priority;
    string category;

    public string Name { get { return name; } set { name = value; } }
    public string Deadline { get { return deadline; } set { deadline = value; } }
    public int Priority { get { return priority; } set { priority = value; } }
    public string Category { get { return category; } set { category = value; } }

    public TaskCategory(string deadline, int priority, string category, string name)
    {
        this.name = name;
        this.deadline = deadline;
        this.priority = priority;
        this.category = category;
    }

    public TaskCategory() { }


}
