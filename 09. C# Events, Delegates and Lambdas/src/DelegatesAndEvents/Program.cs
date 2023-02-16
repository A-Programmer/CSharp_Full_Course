namespace DelegatesAndEvents;

public delegate int BizRuleDelegate(int x, int y);
public class Program
{
    static void Main(string[] args)
    {
        // WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
        // WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);
        // WorkPerformedHandler del3 = new WorkPerformedHandler(WorkPerformed3);
        // del1(5, WorkType.Golf);
        // del2(10, WorkType.GenerateReports);
        // del1 += del2 + del3;
        // int finalHours = del1(10, WorkType.Golf);
        // System.Console.WriteLine(finalHours);
        // DoWork(del1);
        // DoWork(del2);

        Worker worker = new Worker();
        worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(worker_WorkPerformed);
        worker.WorkCompleted += worker_WorkCompleted; // Compiler will infer the delegate
        worker.WorkCompleted += delegate(object sender, EventArgs e)
        {
            Console.WriteLine("Comleted..");
        };
        worker.WorkCompleted += 
            (object sender, EventArgs e)
                => Console.WriteLine("Completed...");
        worker.WorkCompleted += (s, e) => Console.WriteLine("Completed ....");
        
        worker.DoWork(8, WorkType.GenerateReports);


        BizRuleDelegate addDel = (x, y) => x + y;
        BizRuleDelegate multiplyDel = (x, y) => x * y;

        ProcessData data = new();
        data.Process(2, 3, addDel);
        data.Process(2, 3, multiplyDel);

        Action<int, int> myAddAction = (x, y) => System.Console.WriteLine(x + y);
        data.ProcessAction(2, 3, myAddAction);
        Action<int, int> myMultiplyAction = (x, y) => System.Console.WriteLine(x * y);
        data.ProcessAction(2, 3, myMultiplyAction);

        Func<int, int, int> myAddFunc = (x, y) => x + y;
        data.ProcessFunc(2, 3, myAddFunc);
        Func<int, int, int> myMultiplyFunc = (x, y) => x * y;
        data.ProcessFunc(2, 3, myMultiplyFunc);
    }

    static void worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
    {
        Console.WriteLine(e.Hours.ToString());
    }
    static void worker_WorkCompleted(object sender, EventArgs e)
    {
        Console.WriteLine("Work Completed!");
    }
    // static void DoWork(WorkPerformedHandler del)
    // {
    //     del(5, WorkType.GoToMeetings);
    // }
    // static int WorkPerformed1(int hours, WorkType workType)
    // {
    //     Console.WriteLine($"WorkPerformed1 called {hours}");
    //     return hours + 1;
    // }
    // static int WorkPerformed2(int hours, WorkType workType)
    // {
    //     Console.WriteLine($"WorkPerformed2 called {hours}");
    //     return hours + 2;
    // }
    // static int WorkPerformed3(int hours, WorkType workType)
    // {
    //     Console.WriteLine($"WorkPerformed3 called {hours}");
    //     return hours + 3;
    // }
}

public enum WorkType
{
    GoToMeetings,
    Golf,
    GenerateReports
}