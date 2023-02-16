namespace DelegatesAndEvents;

// public delegate int WorkPerformedHandler(int hours, WorkType workType); // Not standard
// public delegate int WorkPerformedHandler(object sender, WorkPerformedEventArgs e);

public class Worker
{
    // public event WorkPerformedHandler WorkPerformed;
    public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
    public event EventHandler WorkCompleted;
    public virtual void DoWork(int hours, WorkType workType)
    {
        for (int i = 0; i < hours; i++)
        {
            Thread.Sleep(1000);
            OnWorkPerformed(i + 1, workType);
        }
        OnWorkCompleted();
    }

    protected virtual void OnWorkPerformed(int hours, WorkType workType)
    {
        EventHandler<WorkPerformedEventArgs> del =
            WorkPerformed as EventHandler<WorkPerformedEventArgs>;
        if (del != null) //Listeners are attached
        {
            del(this, new WorkPerformedEventArgs(hours, workType));
        }
    }

    protected virtual void OnWorkCompleted()
    {
        EventHandler del = WorkCompleted as EventHandler;
        if (del != null)
        {
            del(this, EventArgs.Empty);
        }

    }
}