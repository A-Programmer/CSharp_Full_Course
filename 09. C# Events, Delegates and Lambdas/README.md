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
