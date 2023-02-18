# Getting started Asynchronous Programming in .NET

We can declare a method by `async` keyword, this is the first step but it's not enough.  
We should do our jobs asynchronously in the method body.  
In asynchronous tasks, new thread will create and the task will run on that thread, by using `await` keyword we are telling that, hey, please get back the result to this thread. If we don't use `await` when the method throws an exception, we will not notify!  
One example for times that we wouldn't use `await` :  
Imagine, we are creating a registration form and we want to send a welcome email to the user after saving the user data on the database, so, we are sure that the data is saved but sending email will take a long time (like 2 minutes), does the user need to wait for email sending process!? Of course that's not a good idea to wait for the result, the user has been registered and we can show the success page to the user and on the background we can send the welcome email, in this case we dont use `await` keyword.  
Almost in 99 percent we dont use `async void` methods, if there is nothing to return by method, we use `async Task`.  
Exceptions occuring in an `async void` method can not be cought.  

Using `async` and `await` in ASP.NET means the web server can handle other requests.  

**Best Practices**
1. Never use `async void` unless it's an event handler or delegate.
2. Never block an asynchronous operation by calling `Result` or `Wait()`.
3. Always use `async` and `await` together.
4. Always return a `Task` from an asynchronous method.
5. Always `await` an asynchronous method to validate the operation.
6. Use `async` and `await` all the way up the chain.

Simplest way to conver a sync code to async code is using `Task.Run(() => { // codes } )`  
A big difference between using `await` and `ContinueWith` is the fact that `ContinueWith` is not back on the original context.  

Validate tasks even when not using `async` and `await` by chaining on a continuation.  


**Simple Await:** starts all tasks and then awaits them one-by-one. It will collect all results in the correct order. In case of an exception it will return before all tasks are completed, and it will report only the exception of the first failed task (first in order, not chronologically).
Not recommended unless this behavior is exactly what you want (most probably it isn't).  

**WhenAll:** starts all tasks and then awaits all of them to complete. It will collect all results in the correct order. In case of an exception it will return after all tasks have been completed, and it will report only the exception of the first failed task (first in order, not chronologically).
Not recommended unless this behavior is exactly what you want (most probably it isn't either).  

**WhenAny:** starts all tasks and then awaits all of them to complete. It will collect all results in order of completion, so the original order will not be preserved. In case of an exception it will return immediately, and it will report the exception of the first failed task (this time first chronologically, not in order). The while loop introduces an overhead that is absent from the other two approaches, which will be quite significant if the number of tasks is larger than 10,000, and it will grow exponentially as the number of tasks becomes larger.
Not recommended unless this behavior is exactly what you want (I bet by now you should not be a fan of this either).  

**All of these approaches:** will bombard the remote server with a huge number of concurrent requests, making it hard for that machine to respond quickly, and in the worst case triggering a defensive anti-DOS-attack mechanism.  

**A better solution** to this problem is to use the specialized API Parallel.ForEachAsync, available from .NET 6 and later. This method parallelizes multiple asynchronous operations, enforces a maximum degree of parallelism which by default is Environment.ProcessorCount, and also supports cancellation and fast completion in case of exceptions.  

Sometimes, for example in testing an API call, we don't want to call API and get data from it, in this situation we can mock the data, like creating an interface that has one method called GetData which is async method and returns a `Task<ICollection<Item>>`, so, implementation of this interface is very simple, it has just a method called GetData and returns a list of Items, but we dont do anything asyncronously, what should we do in this case? Yes, we can use Task.`FromResult(result.Where(x => x.Name == "name"))`.  

`ConfigureAwait` should be used when you don't care about the original context.  

ASP.NET Core does not need to use `ConfigureAwait` in Controllers.  
ConfigureAwait only has effects on code running in the context of a SynchronizationContext which ASP.NET Core doesn't have (ASP.NET "Legacy" does).  

General purpose code should still use it because it might be running with a SynchronizationContext.

If you are developing a Library, always use `ConfigureAwait`.  

**Remember** that continuations are executed on a different thread.  

**Working with Task**
- Task is a reference to an asynchronous operation
- Work passed to `Task.Run()` is scheduled to execute on a different thread
- Task swallow exceptions
- Continuations are executed on a different thread

Wrapping synchronous code in `Task.Run()` can be dangerous!  
Make sure there is no blocking code.  

