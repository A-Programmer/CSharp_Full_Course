# Object Oriented Programming

## **Building Entity Classes**

* **Backing field**
* **Full Property**
  * I getter we return backing field
  * in the setter we set data into the backing field
  * By removing setter we will have readonly property
* **Auto Implemented Property**
  * In many cases we don't need full property.
  * If there is no need for logic within the getter or setter use an auto property, otherwise use full property with back fields

**Shortcuts to create properties:**

* prop : Generate auto implemented property
* propfull : Generate full property
* propg : Generates a property with public getter and private setter

**Most basic layers for each application:**

* User Interface
* Business Logic
* Data Access
* Common Library

**Access Modifiers:**

To access other classes and class members from other projects you need to set access modifiers base on your usage like protected, public or internal.

- Static members belong to the class instead of the class instances (objects)

## Building Entity Classes - Methods

* Method signiture: method name and parameters.
* The return type is not included in signiture
* The method signiture must be unique in the class
* We can have same method name with different parameters (count and type) this is **overloading**

**Constructor:**

A constructor is a special kind of method named with the class name that is executed each time an instance of the class is created. Constructors are normally defined at the top of the class, above the properties.

Shortcut for creating constructor: ctor

## Separation of Responsibilities

* Minimizes coupling
  * What: Dependence on other classes or external resources
  * How: Extract dependencies into their own classes
  * Why: Easier to test and maintain (because the dependencies are minimized and decoupled)
  * Example: For example we had Retrive and Save methods in each entity classes that are responsible for accessing and data storing and we moved them to repository classes
* Maximizes cohesion
  * What: Class members should relate to the class purpose
  * How: Extract unrelated members into their own classes
  * Why: Easier to understand, test and maintain
  * Example: We moved address to separated class
* Simplifies maintenance
* Imprves testability

Separation of concerns

YAGNI Principle : You aren't going to need it.

## Establishing relationships between classes

**Types of Repationships:**

* Collaboration ("uses a")
  * An object uses another object, like a CustomerRepository uses a Customer object to populate a retrive.
* Composition ("has a")
  * An object has another object, for example a Car has a motor, or an Order has a set of OrderItems and an Address
    * Aggregates: When an object composed of multiple objects that can exist outside of the relashinship:
      * An Order has a Customer, but a Customer can exist without the Order.
    * Composition: Those relationships where the related objects don't otherwise exist. => The object owns its related objects, and if the object is destroyed, the related objects are also destroyed.
      * And order has a set of OrderItems, the OrderItems have no context without an Order.
* Inheritance ("is a")
  * You know inheritance, Business Customer is a type of Customer, a Residential Customer is another Type of Customer.
  * Inheritance prvides a mechanism for defining classes that are a more specialized version of another class.

# Leveraging Reuse through Inheritance

* Involves extracting commonality
* Building reusable classes/components
* Defining Interfaces

#### **Secrets of Reuse:**

* Build the functionality once
* Test that functionality with unit tests.
* Reuse it.
* Update it in one place and retest it.

Any class that we create, it is inheriting from Object base class.

We can override inherited members of base classes (like ToString method).

### Polymorphism:

Is the concept that a single method, such as ToString method, can behave differently depending on the type of object that calls it. If the base class calls ToString, ToString displays the full class name. If an Order object calls ToString, it displays the order dat and the order id. If a customer object calls ToString, it displays Customer name and if the product object calls ToString, it displays the Product Name.

#### So a method can have different shapes.

When we decide to create a base class we have 2 choices: 1. Abstract class 2. Concrete Class

| Abstract Class                                                        | Concrete Class                            |
| --------------------------------------------------------------------- | ----------------------------------------- |
| Incomplete, with at least one<br />property or method not implemented | Normal class                              |
| Can not be instantiated (because it is incomplete)                    | Can be instantiated                       |
| intended for use as a base class                                      | Can be used as a base class or on its own |
| public abstract class                                                 | public class                              |

### Sealed class:

Is a class that can not be extended through inheritance. Sealing a class prevents extension and customization. If you build a class and want to ensure that no other classes extend or override its functionality, consider making it as sealed.

By default class members are sealed and can not be overriden.

**Expose members using:**

* Abstract
* Virtual

When do we use which?

| Abstract                                                                                                                                                     | Virtual                               |
| ------------------------------------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------- |
| Method signiture as place holder with no implementation<br />Use abstract if the base class defines the method, but has<br />no default code for the method. | Method with default implementation    |
| Only use in abstract classes                                                                                                                                 | Use in abstract or concrete classes   |
| Must be overriden by derived class                                                                                                                           | Optionally overriden by derived class |
| public abstract bool Validate();                                                                                                                             | public virtual bool Validate()        |

# Building Reusable Components

A static class is a class that can not be instantiated. That means there is no new keyword, because there is no instance we access the members of static classes using the class name.

**Extension Method:**

An extension method allows us to add methods to any existing type without the source code of the type, without inheritance, without recompiling, without any changes at all to the original type.
