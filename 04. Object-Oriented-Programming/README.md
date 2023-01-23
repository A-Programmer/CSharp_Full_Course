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
