# C# Extension Methods

- Extend types
  - Classes & Structs
  - Interfaces
- Extend generics
  - Classes - List<T>
  - Interfaces - IEnumerable<T>
- Enabling technology
  - Adding to a third-party codebase
  - Adding to a class hirerarchy
    - Without inheritence or composition
- Straightforward to use
  - But powerful
  
1. Class should be static
2. Method should be static
3. Make sure put `this` keyword befor the first method argument

**Writing extension methods**
- Can libe in any assembly
- With any namespace
- And any class name - typically
  - {Type}Extensions
  - {Feature}Extensions

**Declating extension methods**
- Type to extend in `this` argument
- Static method in static class

**Using extension methods**
- Reference extension method assembly
- Import extension method namespace
- Call the method on an instance

You can use any namespace, usually, we use our namespaces but sometimes we can declare extension methods in the same namespace as the type theu are extending, such as System, so to use them we just need to reference the assembly where the extension methods are defined and we don't need to worry about the namespace.  

**Tip**
Extending Interfaces:  
Adding an extension method to an interface, let's us to add functionality to a class hierarchy without having to modify the hierarchy. The extension method syntax is exactly the same as when we are extending a class or a struct. We need a static method in a static class and the first parameter needs to be an instance of the interface we're extending, specified with the `this` keyword. When we extend an interface, all implementations of the interface are automatically extended, which means we can use extended methods in all implemented classes without any changes to any of those classes.  

By using extension methods defined in the namespace of the interface, our new functionality is available any time we're working with an object that implements the interface and we don't have to create wrapper objects or call static methods on helper classes and remember a second set of classes. We only need to work with the actual implementations.  

