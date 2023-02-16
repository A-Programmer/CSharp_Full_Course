# Events, Delegates, Lambda
**Events are notifications**

**Delegate is a pipeline between an event and event handler**  
It is a function poiner.  
A pipeline allows our event and the EventArgs to get over to the event handler.  
There is a special class called MulticastDelegate in .NET, this is a class that actually tracks every one that is listening.  

**Event <=====> Delegate <=====> Event Handler**

**Event Handler**
Is responsible for receiving and processing data from delegate.  
Normally receives two parameters:
- Sender
- EventArgs

EventArgs is responsible for encapsulating event data.  

**Delegates**
Custom delegates are defined using the delegate keyword.
```csharp
public delegate void WorkPerformedHandler(int hours, WorkType workType);
```
Behind the scenes when the compiler sees the delegate keyword, it actually generates a class that inherits from some other .NET framework delegate classes.  

A delegate is a blueprint for the method that data is going to get dumped into, the handler will call it.  

An event handler signature and delegate signature must be similar:  
```csharp
public void Manager_WorkPerdormed(int workHouts, WorkType wType)
{
    // body
}
```

**Delegate Base Classes:**
- Delegate (Has 2 properties)
  - Method (The method that the delegate should dump the data to)
  - Target (If you have to have an object instance where that method lives, then the target would be actual object that has that method)

Every delegate that we create, after compilation will inherit from **MulticastDelegate** class.  
**MulticastDelegate** is really a way to hold multiple delegates, I might have one message I want to send out, but I might want to send it across multiple pipelines. So, instead of just having the one, a MulticastDelegate, imagine it had multiple pipelines that dump in different methods.

At the end, the custom delegate inherits from MulticastDelegate. Actually, we can not inherit from delegate class or MulticastDelegate, by using delegate keyword the inheritance will be implement when we compile the code.  

**Events** can be defined in a class using the event keyword.
```csharp
public event WorkPerformedHandler WorkPerformed;
```

**Events can be defined using add/remove accessors**
```csharo
private WorkPerformedHandler _WorkPerformedHandler;
public event WorkPerformedHandler WorkPerformed
{
  [MethodImpl(MethodImplOptions.Synchronized)]
  add
  {
    _WorkPerformedHandler = (WordkPerformedHandler)Delegate.Combine(_WorkPerformed, value);
  }
  [MethodImpl(MethodImplOptions.Synchronized)]
  remove
  {
    _WorkPerformedHandler = (WordkPerformedHandler)Delegate.Remove(_WorkPerformed, value);
  }
}
// 'add' here is what += does when we used in last example:
// del1 += del2;
```
Why would we use this add/remove accessors?  
There may be occasions where you have some logic on then listener can actually attach and when then can't, or when they get removed or those types of thins. If you need to get a lot more detailed and have more control over adding into the invocation list, then you can use add and the remove accessors. But it's not something that I personally use really ever, but you may come across this in samples, and it's something if you need a little more advanced control over adding and removing into that invocation list, then this is what you can do.  

**Events are raised by calling the event like a method**
```csharp
if (WorkPerformed != null)
{
  WorkPerformed(8, WorkType.GenerateReports);
}
```

It is important to have null check to check if there is anything in invocation list.because if the delegate behind the scenes is null and there's nothing there, then if you try to raise it, you can get an exception error.  

Another option is to access the event's delegate and invoke it directly:  
```csharp
WorkPerformedHandler del = WorkPerformed as WorkPerformedHandler;
if (del != null)
{
  del(8, WorkType.GenerateReports);
}
```

**The EventAtgs class is used in the signature of many delegates and event handlers**
When custom data needs to be passed, the EbentArgs class can be extended.  
```csharp
public void button_Clicked(object sender, EventArgs e)
{
  // Handle button click
}
```
**Custom EventArgs sample**
```csharp
public class WorkPerformedEventArgs : System.EventArgs
{
  public int Hours { get; set; }
  public WorkType WorkType { get; set; }
}
```

.NET includes a generic EventHandler<T> class that can be used instead of custom delegate:
```csharp
// public delegate void WorkPerformedHandler(object sender, WorkPerformedEventArgs e);
public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
```

Use `+=` to attach and event to and event handler and `-=` to detach an event.  

```csharp
Worker worker = new();
worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(worker_WorkPerformed);

void worker_WorkPerformed(object sender, WorkPerformEvendArgs e)
{
  Console.WriteLine(e.Hours.ToString());
}
```

The .NET framework provides several defferent delegates that provide flexible options:  
- **Action<T>** : Accepts a single (or more) parameter and returns no value. (Action<T> is a sprcial type of Func<T, TResult> that does not return any result)
- **Func<T, TResult>** : Accepts a single paramenter (or more) and returns a value of type TResult.


