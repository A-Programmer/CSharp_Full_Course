# Concurrent Collections  

(For review) Running tasks on threads:
```csharp
Task task1 = Task.Run(() => DoJob());
Task task2 = Task.Run(() => DoJob());
Task.WaitAll(task1, task2);
```

We need to use ConcurrentCollections for thread safety.  

lock is another way but most of the time it's better to use ConcorrentCollections.  
They use multiple techniques for thread safety.  

- ConcurrentDictionarry<TKey, TValue>
  - Dictionary, SortedDictionary, SortedList
- ConcurrentQueue<T>
  - Queue
- ConcurrentStack<T>
  - Stack
- ConcurrentBag<T>

Add and Remove methods in ConcurrentDictionary are hidden, why?  
In single thread thats okay to add item to dictionary and if there is an item with same key you will get error, but how about in ConcurrentDictionary that works with multiple threads!? how will you know about the existing same key!? Here you have TryAdd, TryGetValue, TryRemove and TryUpdate methods to make sure for unique keys that wont throw error (not good, right?), Also, there are 2 other methods called GetOrAdd and GetOrUpdate that will always succeed.  

**ConcurrentCollections do not protect you from race conditions between method calls.**  

**The key to using concurrent collections correctly**  
Do each operation in **ONE** concurrent collection method call.  

`Interlocked.Increement`  

Change mindset when you need to work with multi thread.  

Dont use Concurrent collections when you are working with single thread.  

If multiple threads might simultaneously be modifying the collection then clearly you do need a concurrent collection because ordinary collections will cause race conditions.  
On the other hand, if a collection is merely being read by multiple threads, then it looks like nothing is being modified so you might think it's a reasonable guess that data can not be corrupted even using the standard generic collections. And therefor you might deduce that there's no problem just using the standard collections here, hence no need to take the perform hit of using concurrent collections. In fact, the situation isn't quite so simple. There's a problem. In principle, even if it looks like you're only reading data from a type, you still need to consider the possibility that that type might be modifying fields under the hood. Here you can use Immutable Collections.  
They are readonly and thread safe.  

Avoid asking concurrent collections for aggregate state like:
- IsEmpty
- Count
- Clear()
- ToArray()
- Values
- Keys

