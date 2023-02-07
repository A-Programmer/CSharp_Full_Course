# C# Interfaces

## Introduction

Before interfaces, lets see what and abstract is?

Data ****abstraction** is the process of hiding certain details and showing only essential information to the user.
Abstraction can be achieved with either** ****abstract classes** or** **interfaces** (which you will learn more about in the next chapter).

The `abstract` keyword is used for classes and methods:

* **Abstract class:** is a restricted class that cannot be used to create objects (to access it, it must be inherited from another class).
* **Abstract method:** can only be used in an abstract class, and it does not have a body. The body is provided by the derived class (inherited from).

An abstract class can have both abstract and regular methods.

```csharp
abstract class Animal 
{
  public abstract void animalSound();
  public void sleep() 
  {
    Console.WriteLine("Zzz");
  }
}
```

#### Interfaces:

In the human world, a contract between the two or more humans binds them to act as per the contract. In the same way, an interface includes the declarations of related functionalities. The entities that implement the interface must provide the implementation of declared functionalities.

In C#, an interface can be defined using the** **`interface` keyword. An interface can contain declarations of methods, properties, indexers, and events. However, it cannot contain instance fields.

### Why interfaces?

* We want code that is asy to **Maintain**
* We want code that is easy to **Extend**
* We want code that is easy to **Test**

Interfaces describe a group of related functions that can belong to any class or struct.

It is considered good practice to start with the letter "I" at the beginning of an interface, as it makes it easier for yourself and others to remember that it is an interface and not a class.

By default, members of an interface are **`abstract` and** `public`.

**Note:** Interfaces can contain properties and methods, but not fields.


## Modifiers in Interfaces

C# 8.0 allows private, protected, internal, public, virtual, abstract, sealed, static, extern, and partial modifiers in an interface.

* The default access level for all interface members is `public`.
* An interface member whose declaration includes a body is a **`virtual` member unless the** **`sealed` or** `private` modifier is used.
* A **`private` or** `sealed` function member of an interface must have implementation body.
* Interfaces may declare static members which can be accessed by interface name.

**Points to Remember :**

1. Interface can contain declarations of method, properties, indexers, and events.
2. Interface cannot include private, protected, or internal members. All the members are public by default.
3. Interface cannot contain fields, and auto-implemented properties.
4. A class or a struct can implement one or more interfaces implicitly or explicitly. Use public modifier when implementing interface implicitly, whereas don't use it in case of explicit implementation.
5. Implement interface explicitly using `InterfaceName.MemberName`.
6. An interface can inherit one or more interfaces.

**What is Explicit Interface Implementation and when is it used?**

Explicitly telling the compiler that a particular member belongs to that particular interface is called Explicit interface implementation. 
If a class implements from more than one interface that has methods with the same signature then the call to such a method will implement the same method and not the interface-specific methods. This will defeat the whole purpose of using different Interfaces. That is when Explicit implementation comes into the picture. Using explicit implementation you can tell the compiler which interface’s method you are Overloading and can provide different functionalities for methods of different interfaces. The same is the case for any other type of member like a property, event.

```csharp
class ClassName : InterfaceName
{
    returnType InterfaceName.method()
    { 
          // Your Code 
    }
}
```  
## Where we use interfaces  
* Dependency Injection  
* Design Patterns  
  * Repository  
  * Factory method  
  * Decorator  
* Mocking  

