using TCSA.V2026.Data.Models;

namespace TCSA.V2026.Data.Curriculum;

public class DiCourse
{
    public static Course GetDiCourse()
    {
        return new Course
        {
            Id = 6,
            Level = CourseLevel.Intermediate,
            Title = "Dependency Injection Fundamentals",
            Description = "Master the backbone of maintainable software design!",
            ImgUrl = "icons8-dependency-injection-64.png",
            Articles = new List<Article>
                {
                    new Article
                    {
                        Id = 500150,
                        CourseDisplayId = 1,
                        Title = "Introduction",
                        Slug = "intro-to-dependency-injection",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Welcome to the <b>Dependency Injection Fundamentals</b> Course! We are happy to have you join us on this comprehensive course made to teach you the Dependency Injection software design pattern."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Nowadays, the Dependency Injection design pattern is one of the most commonly used design patterns in .NET applications. It is a built-in part of .NET framework so every developer should understand how and why to use Dependency Injection."
                                    },
                                    new Paragraph
                                    {
                                        IsPicture = true,
                                        PictureUrl = "c6-ch1-dependency-injection-banner.png"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "What is dependency injection?",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Dependency injection is a <b>design pattern</b> - a technique for building software used to implement inversion of control between classes and their dependencies. It helps us write loosely-coupled code that is more modular and achieves increased maintainability and testability of our applications."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Dependency Injection in it's essence is all about <b>creating objects</b> other classes depend on. It helps us deal with dependencies - in this context a dependency is an object another object depends on. Instead of manually <b>new</b>-ing up objects inside classes, we delegate that responsibility to an external <b>container</b> which takes care of creating and disposing of objects. .NET provides us with a built-in container we can use for creation of our class instances."
                                    },
                                    new Paragraph
                                    {
                                        Body = "By using interfaces or base classes we abstract away the concrete implementation of classes. This removes direct dependencies between objects which results in loosely-coupled code. An approach like this allows for easy replacement of implementations without affecting existing classes."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Dependency Injection and SOLID principles",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Dependency Injection in .NET primarily addresses three <b>SOLID</b> design principles."
                                    },
                                    new Paragraph
                                    {
                                        Body = "<b>Single Responsibility Principle</b><ul style='padding-left: 1.5rem;'><li>DI helps ensure that a class has only one reason to change by delegating the responsibility of creating dependencies to an external container.</li><li>Without DI, a class might handle both its main functionality and the creation of its dependencies, violating SRP.</li></ul>"
                                    },
                                    new Paragraph
                                    {
                                        Body = "<b>Open/Closed Principle</b><ul style='padding-left: 1.5rem;'><li>With DI, classes depend on abstractions (interfaces or abstract classes) rather than concrete implementations, making it easy to extend functionality without modifying existing code.</li><li>You can introduce new implementations of an interface without altering the existing classes.</li></ul>"
                                    },
                                    new Paragraph
                                    {
                                        Body = "<b>Dependency Inversion Principle</b><ul style='padding-left: 1.5rem;'><li>DI is a direct implementation of this principle because it ensures that high-level modules depend on abstractions rather than concrete implementations.</li></ul>"
                                    },
                                    new Paragraph
                                    {
                                        Body = "<b>Liskov Substitution Principle</b><ul style='padding-left: 1.5rem;'><li>Although DI doesn't directly enforce this, it encourages using interfaces which can help maintain LSP.</li></ul>"
                                    },
                                    new Paragraph
                                    {
                                        Body = "<b>Interface Segregation Principle</b><ul style='padding-left: 1.5rem;'><li>DI doesn't enforce how interfaces are designed, but it benefits from well-segregated interfaces.</li></ul>"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Dependency Injection covers almost all aspects of SOLID principles without thinking too much about it - simply following the DI techniques gets the job done!"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "What you'll learn",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "✅ Injection methods<br>✅ Service lifetimes<br>✅  Inversion of Control design pattern<br>✅ Service resolution<br>✅ How to use Dependency Injection in console applications<br>➡️ And more!"
                                    }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500151,
                        CourseDisplayId = 2,
                        Title = "Tight Coupling",
                        Slug = "tight-coupling",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Tight coupling means that two objects are dependent on each other - if we want to make changes to an object we also have to change the class where this object is <b>being used</b>. This is not too big of an issue in smaller applications but becomes a big problem in large codebases where changes become difficult to handle."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Let's dive into code and see what this means with concrete examples."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "GrooveGrid console application",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Let's start by creating a small console application to showcase the problems with tight coupling and how we can refactor our code to use dependency injection. We will create an application where musicians can play songs on different instruments.<br>In an IDE of your choice create a new .NET 9 console application. We gave it a name <b>GrooveGrid</b> but you can name it anything you'd like."
                                    },
                                    new Paragraph
                                    {
                                        Body = "First we create an instrument for our musician:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public class Guitar\r\n{\r\n    public void Play(string song)\r\n    {\r\n        System.Console.WriteLine($\"Played {song} on the guitar.\");\r\n    }\r\n}"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Next we create a class that represents the musicians. To be able to play the songs, musicians need a <code class='inline-code'>Perform()</code> method. The musician should use their instrument, in this case a <code class='inline-code'>Guitar</code>, to play a song:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public class Musician\r\n{\r\n    private readonly Guitar _guitar = new();\r\n    public void Perform(string song)\r\n    {\r\n        _guitar.Play(song);\r\n    }\r\n}"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Now, in <code class='inline-code'>program.cs</code> we simply create a musician and play the song:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var musician = new Musician();\r\nmusician.Perform(\"Sultans of Swing\");"
                                    },
                                    new Paragraph
                                    {
                                        Body = "If we run the application this will print <i>Played Sultans of Swing on the guitar.</i>"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This is all fine, but what if we wanted our musician to play another instrument?"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Since the <code class='inline-code'>Guitar</code> object is created with a <b>new</b> keyword inside the <code class='inline-code'>Musician</code> class, we would have to <b>modify the implementation</b> of this class to make a change. If we wanted our musician to use <code class='inline-code'>Drums</code> we would have to change the <code class='inline-code'>Musician</code>'s code - literally delete the line where <code class='inline-code'>Guitar</code> is <b>new</b>-ed up and replace it with a <code class='inline-code'>Drums</code> class. In other words, our <code class='inline-code'>Musician</code> class is <b>tightly coupled</b> to a <code class='inline-code'>Guitar</code> class."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Using the <b>new</b> keyword for services and dependencies we want to work with is like <b>using lego bricks with super glue</b>. That doesn't mean there is no place for the <b>new</b> keyword - if you're just <b>new</b>-ing up an entity or creating a <code class='inline-code'>DateTime</code> object - that's completely fine."
                                    },
                                    new Paragraph
                                    {
                                        BackgroundColor="#1C236D",
                                        FontColor="#FFF",
                                        Body = "You can find the code for this project <a href='https://github.com/nwdorian/DependencyInjectionFundamentals/tree/main/ConsoleExamples/GrooveGridTight/GrooveGrid.Console' target='_blank'>on this link</a>."
                                    }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500152,
                        CourseDisplayId = 3,
                        Title = "Loose Coupling",
                        Slug = "loose-coupling",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Loose coupling means that two objects are <b>independent</b> of each other - if we make changes to one object it will not affect the code of another class. By achieving <b>loose coupling</b> in our codebase we can better manage <b>future changes</b> and easily extend our application with more <b>complex functionalities</b>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "In order to avoid tight coupling, we can provide a layer of abstraction by using <b>interfaces</b> to help <b>decouple</b> our classes. Interfaces serve as a contract, allowing classes to depend on an abstraction rather then concrete implementation."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Implementing dependency injection",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Let's start the refactoring process by creating an <b>interface</b> for instruments in our application."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public interface IInstrument\r\n{\r\n    void Play(string song);\r\n}"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Next, the <code class='inline-code'>Guitar</code> class can implement this interface:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public class Guitar : IInstrument\r\n{\r\n    public void Play(string song)\r\n    {\r\n        System.Console.WriteLine($\"Played {song} on the guitar.\");\r\n    }\r\n}"
                                    },
                                    new Paragraph
                                    {
                                        Body = "And we can alter the <code class='inline-code'>Musician</code> class:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public class Musician\r\n{\r\n    private readonly IInstrument _instrument;\r\n    public Musician(IInstrument instrument)\r\n    {\r\n        _instrument = instrument;\r\n    }\r\n    public void Perform(string song)\r\n    {\r\n        _instrument.Play(song);\r\n    }\r\n}"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Now we can provide our musician with different instruments. Rather then creating the <code class='inline-code'>Guitar</code> inside the <code class='inline-code'>Musician</code> class, we exposed it as a <b>constructor parameter</b> instead. We can then <b>inject</b> the <code class='inline-code'>Guitar</code> via the <code class='inline-code'>Musician</code>'s constructor to play it. This is an example of dependency injection (specifically, <i>constructor injection</i>)."
                                    },
                                    new Paragraph
                                    {
                                        Body = "This is how <code class='inline-code'>program.cs</code> looks like now:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var musician = new Musician(new Guitar());\r\nmusician.Perform(\"Sultans of Swing\");"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "What about a different instrument?",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Let's create another instrument a <code class='inline-code'>Musician</code> could use:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public class Drums : IInstrument\r\n{\r\n    public void Play(string song)\r\n    {\r\n        System.Console.WriteLine($\"Played {song} on the drums.\");\r\n    }\r\n}"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Now in <code class='inline-code'>program.cs</code> we can create a duo band:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var musician1 = new Musician(new Guitar());\r\nvar musician2 = new Musician(new Drums());\r\nmusician1.Perform(\"Sultans of Swing\");\r\nmusician2.Perform(\"Sultans of Swing\");"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This is what's printed on the console:<br><i>Played Sultans of Swing on the guitar.</i><br><i>Played Sultans of Swing on the drums.</i>"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Dependency Injection by hand",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "The refactored code we ended up with is called <i>dependency injection by hand</i> or <i>Poor Man's DI</i>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Every time we want to create a <code class='inline-code'>Musician</code> we have to provide it's constructor with some concrete implementation of the <code class='inline-code'>IInstrument</code> interface."
                                    },
                                    new Paragraph
                                    {
                                        Body = "It might seem we only moved the instantiation (the use of the <b>new</b> keyword) to another place and yes, that is totally true, but we still have to <b>new</b>-up the classes <i>somewhere</i>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "On the other hand we have also achieved our goal - we are able to <b>modify the functionality</b> of the <code class='inline-code'>Musician</code> class <b>without changing any code</b> inside it. We can create many different instruments which make our musician behave in different ways, with the important distinction that we don't have to modify <code class='inline-code'>Musician</code>'s code."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Composition root",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "So is it bad that we now have to use this weird syntax in <code class='inline-code'>program.cs</code>, chaining the <b>new</b> keywords inside the constructor during object instantiation?"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Not necessarily, while the syntax is a bit unusual, by moving all of the object creation code into <code class='inline-code'>program.cs</code> we have created a so called <b>Composition Root</b>. A central place where all our dependencies are wired up."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Having object instantiation in <code class='inline-code'>program.cs</code> is a common practice in all .NET applications that use Dependency Injection - from simple console apps to <b>WebApi</b> and <b>MVC</b> projects - <code class='inline-code'>program.cs</code> is the composition root of the application. In latest versions of .NET it is actually quite rare to not see it being done in <code class='inline-code'>program.cs</code> (note that before .NET 6 this was done in the <code class='inline-code'>startup.cs</code> class)."
                                    },
                                    new Paragraph
                                    {
                                        Body = "The caveat is that while <i>dependency injection by hand</i> works well in small projects, as the <b>application grows</b> it becomes cumbersome to <b>manually wire up</b> all the objects with the <b>new</b> keyword. Imagine adding just one more class, for example a <code class='inline-code'>Band</code> to our application and having to do:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var band = new Band(new Musician(new Guitar()));"
                                    },
                                    new Paragraph
                                    {
                                        Body = "And that's just a single extra class! In ASP.NET we delegate this responsibility of <b>new</b>-ing up classes to a central system for creating objects - the Dependency Injection Container. We will talk about it later in the course."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "SOLID in action",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "It's worth pointing out that even with pros and cons of <i>dependency injection by hand</i> we did satisfy the SOLID principles in our code."
                                    },
                                    new Paragraph
                                    {
                                        Body = "✅ <b>Single Responsibility Principle</b>: <code class='inline-code'>Musician</code> only performs the songs, but it doesn't have the responsibility of creating dependencies anymore.<br>✅ <b>Open/Closed Principle</b>: Add new instruments without modifying <code class='inline-code'>Musician</code>.<br>✅ <b>Dependency Inversion Principle</b>: <code class='inline-code'>Musician</code> depends on an abstraction (<code class='inline-code'>IInstrument</code>), not a specific instrument."
                                    },
                                    new Paragraph
                                    {
                                        BackgroundColor="#1C236D",
                                        FontColor="#FFF",
                                        Body = "You can find the code for this project <a href='https://github.com/nwdorian/DependencyInjectionFundamentals/tree/main/ConsoleExamples/GrooveGridLoose/GrooveGrid.Console' target='_blank'>on this link</a>."
                                    }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500153,
                        CourseDisplayId = 4,
                        Title = "Dependency Injection Techniques",
                        Slug = "dependency-injection-techniques",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "There are three techniques used for Dependency Injection implementation."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Constructor Injection",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "This is the <b>standard</b> and most common approach for injecting classes with dependencies. We have used constructor injection syntax in the previous code examples."
                                    },
                                    new Paragraph
                                    {
                                        Body = "This approach also satisfies the <a href='https://deviq.com/principles/explicit-dependencies-principle' target='_blank' style='color: #7DA2C8; text-decoration: underline;'>Explicit Dependencies Principle</a> which states that <b>methods and classes should explicitly require any collaborating objects they need in order to function correctly.</b> It makes types honest about dependencies, so that by only looking at types we can see what we are working with. This helps us avoid runtime surprises like missing a dependency we thought we didn't need."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Think about the constructor dependency list as a <b>cooking recipe</b>. By looking at the constructor we instantly see all the things our classes and services <b>need in order to function</b>."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public class CustomerService\r\n{\r\n	private readonly IEmployeeRepository _employeeRepository;\r\n	public EmployeeService(IEmployeeRepository employeeRepository)\r\n	{\r\n		_employeeRepository = employeeRepository;\r\n	}\r\n	// ...\r\n}"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Method Injection",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "This approach involves passing dependencies through public methods of the classes. It is a less commonly used syntax with an exception of Minimal style API projects where it's heavily utilized."
                                    },
                                    new Paragraph
                                    {
                                        Body = "The benefit of this approach is that we inject objects into specific methods that will use them instead of into the entire class. "
                                    },
                                    new Paragraph
                                    {
                                        Body = "Having lots of services injected through a constructor can make them bloated and if we only use some of these services in the endpoints, we end up wasting memory because they are all allocated when the constructor is called, even if they might not be needed for every endpoint. "
                                    },
                                    new Paragraph
                                    {
                                        Body = "Even though method injection might be a more memory efficient approach, you will most commonly see constructor injection in the majority of codebases."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public class EmployeeService\r\n{\r\n	// ...\r\n	public List<Employee> GetAllEmployees(IEmployeeRepository employeeRepository)\r\n	{\r\n		return employeeRepository.GetAll();\r\n	}\r\n	// ...\r\n}"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Property Injection",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "This approach involves exposing dependencies as public properties. It's rarely used in .NET applications as this syntax makes it less clear what dependencies a class requires."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public class EmployeeService\r\n{\r\n	public IEmployeeRepository EmployeeRepository { get; set; }\r\n	// ...\r\n}"
                                    }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500154,
                        CourseDisplayId = 5,
                        Title = "TeamPulse WebApi",
                        Slug = "teampulse-webapi",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "To demonstrate the use of dependency injection in ASP.NET we will create a <b>WebApi</b> for tracking employees of a company. To enforce previous lessons we start with manually <b>new</b>-ing up dependencies and will later convert to dependency injection syntax."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Name the project <b>TeamPulse</b> but you can also use a different name if you'd like."
                                    },
                                    new Paragraph
                                    {
                                        Body = "In an IDE of your choice create a new <b>WebApi</b> project with controllers and clean up the default <code class='inline-code'>WeatherForecast</code> examples and classes. This is what you should end up with."
                                    },
                                    new Paragraph
                                    {
                                        IsPicture = true,
                                        PictureUrl = "c6-ch5-team-pulse-api.png"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Model class",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Let's start by creating the <code class='inline-code'>Employee</code> model class to hold the data. Create a new folder <b>Models</b> and inside it create a new class <code class='inline-code'>Employee</code> with the following code:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public class Employee\r\n{\r\n    public int Id { get; set; }\r\n    public string Name { get; set; }\r\n    public string Email { get; set; }\r\n    public string Department { get; set; }\r\n}"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Data source",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Next, create a data source class. We are using an in-memory data for simplicity and ease of demonstration. This class holds some <b>hardcoded data</b> and represents a table in the database with employee information. It will be used by the <code class='inline-code'>EmployeeRepository</code> class which makes it a dependency class."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Create a new folder <b>DataSource</b> and inside it create a new class <code class='inline-code'>EmployeeData</code> with the following code:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public class EmployeeData\r\n{\r\n    public EmployeeData()\r\n    {\r\n        Employees = GetEmployees();\r\n    }\r\n\r\n    public List&ltEmployee&gt Employees { get; set; }\r\n\r\n    public List&ltEmployee&gt GetEmployees()\r\n    {\r\n        return new List&ltEmployee&gt\r\n        {\r\n            new Employee\r\n            {\r\n                Id = 1,\r\n                Name = \"John Smith\",\r\n                Email = \"jsmith@gmail.com\",\r\n                Department = \"Accounting\"\r\n            },\r\n            new Employee\r\n            {\r\n                Id = 2,\r\n                Name = \"Jane Taylor\",\r\n                Email = \"jtaylor@gmail.com\",\r\n                Department = \"Management\"\r\n            },\r\n            new Employee\r\n            {\r\n                Id = 3,\r\n                Name = \"Mark Wilson\",\r\n                Email = \"mwilson@gmail.com\",\r\n                Department = \"Development\"\r\n            }\r\n        };\r\n    }\r\n}"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Repository layer",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Repositories are classes commonly used for <b>data retrieval</b>. In a real world scenario this class would be responsible for interacting with the <b>database</b>. It will be used by the <code class='inline-code'>EmployeeService</code> class which also makes it a dependency class."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Create a new folder <b>Repositories</b> and inside it a new class <code class='inline-code'>EmployeeRepository</code> with the following code:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public class EmployeeRepository\r\n{\r\n    // By manually creating an instance of a dependency class means we have tight coupling\r\n    private readonly EmployeeData _dataSource = new();\r\n    // Get all employees from the database\r\n    public List&ltEmployee&gt GetAllEmployees()\r\n    {\r\n        return _dataSource.Employees;\r\n    }\r\n}"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Service layer",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Services are classes commonly used for <b>business logic</b>. In a real world scenario this class would be responsible for processing data before sending it to the controller or saving it to the database."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Create a new folder <b>Services</b> and inside it a new class <code class='inline-code'>EmployeeService</code> with the following code:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public class EmployeeService\r\n{\r\n    // By manually creating an instance of a dependency class means we have tight coupling\r\n    private readonly EmployeeRepository _employeeRepository = new();\r\n    public List<Employee> GetAllEmployees()\r\n    {\r\n        return _employeeRepository.GetAllEmployees();\r\n    }\r\n}"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Controllers layer",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "In the <b>Controllers</b> folder create a new class <code class='inline-code'>EmployeesController</code>. Make it inherit from <code class='inline-code'>ControllerBase</code> and decorate it with an <code class='inline-code'>[ApiController]</code> and a standard routing attribute. We only need one controller action - a <code class='inline-code'>GET</code> endpoint to retrieve the employee data."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "[Route(\"api/[controller]\")]\r\n[ApiController]\r\npublic class EmployeesController : ControllerBase\r\n{\r\n	// By manually creating an instance of a dependency class means we have tight coupling\r\n    private readonly EmployeeService _employeeService = new();\r\n\r\n    [HttpGet]\r\n    public IActionResult GetAll()\r\n    {\r\n        var employees = _employeeService.GetAllEmployees();\r\n        return Ok(employees);\r\n    }\r\n}"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Run the application",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Let's run the application and make sure it works. We didn't install Swagger or Scalar, so you can make a request trough Postman, go to <code class='inline-code'>localhost:port/api/employees</code> or use the <code class='inline-code'>TeamPulse.Api.http</code> file like this:"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Make sure to replace the <b>port</b> with the one your app is using."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "@TeamPulseApi_HostAddress = http://localhost:port\r\n\r\nGET {{TeamPulseApi_HostAddress}}/api/employees\r\nAccept: application/json\r\n"
                                    },
                                    new Paragraph
                                    {
                                        BackgroundColor="#1C236D",
                                        FontColor="#FFF",
                                        Body = "You can find the code for this project <a href='https://github.com/nwdorian/DependencyInjectionFundamentals/tree/main/WebApiExamples/TeamPulseNewUp/TeamPulse.Api' target='_blank'>on this link</a>."
                                    }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500155,
                        CourseDisplayId = 6,
                        Title = "Dependency Injection in ASP.NET Core",
                        Slug = "di-in-asp-net-core",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "You might be wondering - how does our Web API <b>even work</b> in the first place? We know that we've been manually creating our service and repository classes using the <b>new</b> keyword, but we <b>never</b> manually instantiated the controller. So what creates it?"
                                    },
                                    new Paragraph
                                    {
                                        Body = "The answer lies in <b>ASP.NET Core’s built-in DI container</b>. It’s responsible for creating controller instances when a <b>request</b> comes in. Controllers are automatically registered with the DI container when you call this method in <code class='inline-code'>program.cs</code>:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "builder.Services.AddControllers();"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This line tells ASP.NET Core to <b>discover and register all controller classes</b> in your project."
                                    },
                                    new Paragraph
                                    {
                                        Body = "When an HTTP request hits your API, the DI container springs into action: it locates the appropriate controller, creates an instance of it, and resolves any dependencies it might have - <b>but only if those dependencies are also registered</b>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "At this point in our app, only the controller is being resolved through the DI container - all the other classes (like services, repositories, or data access objects) are still being <b>manually instantiated</b> using the <b>new</b> keyword. Once we switch to constructor injection, we’ll need to register <b>all our classes and dependencies</b> with the DI container. We won’t be using the awkward <b>new</b>-up chaining syntax anymore, like we did in a console application."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Converting to Dependency Injection syntax",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "If you feel <b>confident</b> you can try and <b>convert</b> from manually <b>new</b>-ing up classes to dependency injection syntax on your own and come back after to check. Use <b>constructor injection</b> and remember to extract and <b>use interfaces</b>."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Data source",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Start by creating an <code class='inline-code'>IEmployeeData</code> interface inside the <b>DataSource</b> folder with the following code:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public interface IEmployeeData\r\n{\r\n    List&ltEmployee&gt Employees { get; set; }\r\n    List&ltEmployee&gt GetEmployees();\r\n}"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Next make the <code class='inline-code'>EmployeeData</code> inherit the previously created interface:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public class EmployeeData : IEmployeeData\r\n{\r\n// ..."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Repository layer",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Now we use the <code class='inline-code'>IEmployeeData</code> interface and implement constructor injection in the <code class='inline-code'>EmployeeRepository</code> class:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public class EmployeeRepository : IEmployeeRepository\r\n{\r\n    // By injecting the dependency object trough the constructor we achieve loose coupling\r\n    private readonly IEmployeeData _dataSource;\r\n\r\n    public EmployeeRepository(IEmployeeData dataSource)\r\n    {\r\n        _dataSource = dataSource;\r\n    }\r\n	// ...\r\n"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Create an <code class='inline-code'>IEmployeeRepository</code> interface inside the <b>Repositories</b> folder and make the <code class='inline-code'>EmployeeRepository</code> inherit the interface:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public interface IEmployeeRepository\r\n{\r\n    List&ltEmployee&gt GetAllEmployees();\r\n}"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Service layer",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "We do the same process again, use the <code class='inline-code'>IEmployeeRepository</code> interface and implement constructor injection in the <code class='inline-code'>EmployeeService</code> class:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public class EmployeeService : IEmployeeService\r\n{\r\n    // By injecting the dependency object trough the constructor we achieve loose coupling\r\n    private readonly IEmployeeRepository _employeeRepository;\r\n\r\n    public EmployeeService(IEmployeeRepository employeeRepository)\r\n    {\r\n        _employeeRepository = employeeRepository;\r\n    }\r\n    // ...\r\n"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Create an <code class='inline-code'>IEmployeeService</code> interface inside the <b>Services</b> folder and make the <code class='inline-code'>EmployeeService</code> inherit the interface:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public interface IEmployeeService\r\n{\r\n    List&ltEmployee&gt GetAllEmployees();\r\n}"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Controllers layer",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Repeating the process, we implement constructor injection with <code class='inline-code'>IEmployeeService</code> interface in the <code class='inline-code'>EmployeesController</code> class:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "[Route(\"api/[controller]\")]\r\n[ApiController]\r\npublic class EmployeesController : ControllerBase\r\n{\r\n    // By injecting the dependency object trough the constructor we achieve loose coupling\r\n    private readonly IEmployeeService _employeeService;\r\n\r\n    public EmployeesController(IEmployeeService employeeService)\r\n    {\r\n        _employeeService = employeeService;\r\n    }\r\n    // ...\r\n"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Running the application",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "We’ve finished implementing <b>constructor injection</b>, and if you run the application now, it will build and start successfully. However, as soon as you send an HTTP request, you’ll encounter a runtime exception:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "System.InvalidOperationException: Unable to resolve service for type 'TeamPulse.Api.Services.IEmployeeService'\r\nwhile attempting to activate 'TeamPulse.Api.Controllers.EmployeesController'."
                                    },
                                    new Paragraph
                                    {
                                        Body = "So, what’s going wrong, why does this happen?"
                                    },
                                    new Paragraph
                                    {
                                        Body = "The reason is simple: we <b>haven’t registered</b> our services with the <b>DI container</b>. Before introducing constructor injection, we manually instantiated classes using the <b>new</b> keyword. But in ASP.NET, we delegate the <b>responsibility of object creation</b> to the DI container. If a dependency hasn’t been registered, the container doesn’t know how to create it."
                                    },
                                    new Paragraph
                                    {
                                        Body = "The project builds without any syntax errors, so the compiler is happy. But the DI container only attempts to <b>resolve</b> dependencies at runtime - specifically when the controller is activated to handle an HTTP request. That’s when the error surfaces."
                                    },
                                    new Paragraph
                                    {
                                        Body = "This behavior is actually <b>beneficial</b>. The DI container follows a <b>deferred resolution</b> model: objects are only created when they're needed. However, this means we can accidentally run our app in a \"broken\" state if something hasn’t been registered properly. That’s why it’s important to <b>recognize and understand errors</b> like: <i>\"Unable to resolve service for type...\"</i>"
                                    },
                                    new Paragraph
                                    {
                                        Body = "It’s a common indicator of a missing DI registration."
                                    },
                                    new Paragraph
                                    {
                                        BackgroundColor="#1C236D",
                                        FontColor="#FFF",
                                        Body = "You can find the code for this project <a href='https://github.com/nwdorian/DependencyInjectionFundamentals/tree/main/WebApiExamples/TeamPulseDI/TeamPulse.Api' target='_blank'>on this link</a>."
                                    }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500156,
                        CourseDisplayId = 7,
                        Title = "Dependency Injection Container",
                        Slug = "dependency-injection-container",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Before we go further let's take a short moment to reiterate an important point. <b>Dependency injection is simply about instantiating classes.</b> When you try to understand the topics we are discussing, the best baseline to have is \"<i>How does this relate to creating objects?</i>\"."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Services in the context of Dependency Injection",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "In dependency injection terminology a <b>service</b> is nothing else then an <b>object</b>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "<b>Resolving services</b> means <b>creating objects</b> and their dependencies."
                                    },
                                    new Paragraph
                                    {
                                        Body = "It's important to remember these definitions because the term \"service\" is used interchangeably in different contexts of web development. Since we will use the term \"service\" a lot in the next chapters, remember this definition in relation to dependency injection. "
                                    },
                                    new Paragraph
                                    {
                                        Body = "We can also look at the official definition from <a href='https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection' target='_blank') style='color: #7DA2C8; text-decoration: underline;'>msdocs</a> - With dependency injection terminology, a service:<ul style='padding-left: 1.5rem;'><li>Is typically an object that provides a service to other objects.</li><li>Is not related to a web service, although the service may use a web service.</li></ul>"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "What is a dependency injection container?",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "A Dependency Injection container is the <b>central place</b> where our application's services are <b>registered and managed</b>. It creates instances of these services on demand, based on what our code requires."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Think of the DI container as a <b>black box</b> that holds many registered objects and knows how to provide the right objects when they’re needed. While it may seem like it \"contains\" all the objects, in reality, they are only created when required - such as when an HTTP request is made."
                                    },
                                    new Paragraph
                                    {
                                        Body = "We call it a black box because we don’t need to know how it works internally. We simply trust that it will resolve and provide the required dependencies as configured."
                                    },
                                    new Paragraph
                                    {
                                        Body = "You can imagine the container, filled with all our registered services, looking something like this:"
                                    },
                                    new Paragraph
                                    {
                                        IsPicture = true,
                                        PictureUrl = "c6-ch7-di-container.png"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Inversion of Control",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "By using constructor injection and a DI container, we’re also introducing a key software design principle - <b>Inversion of Control (IoC)</b>. IoC shifts the responsibility of object creation from our code to a central system - in this case, the DI container. Note that Dependency Injection is just one way to achieve IoC. Other patterns, such as the Service Locator, Builder, or Event driven patterns, also promote this principle."
                                    },
                                    new Paragraph
                                    {
                                        Body = "To complete the application, we still need to register all our services in <code class='inline-code'>program.cs</code> - the <b>composition root</b> of our application."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "IServiceProvider",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "ASP.NET framework provides us with a <b>built-in</b> DI container called <code class='inline-code'>IServiceProvider</code>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "We register our services to the <code class='inline-code'>IServiceProvider</code> so that it knows which objects to create when they are requested. It exposes a property representing a <b>collection of services</b> of type <code class='inline-code'>IServiceCollection</code>. We can add our own services to the <code class='inline-code'>IServiceCollection</code> and register them with the container."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Every dependency injection container needs to know service lifetimes in order to resolve them. We will learn about service lifetimes in the next chapter."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Registering custom services",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Let's complete the application by registering our services. "
                                    },
                                    new Paragraph
                                    {
                                        Body = "We can add custom services in <code class='inline-code'>program.cs</code> anywhere after creating the <code class='inline-code'>WebApplicationBuilder</code> and before calling the <code class='inline-code'>Build()</code> method on it."
                                    },
                                    new Paragraph
                                    {
                                        IsPicture = true,
                                        PictureUrl = "c6-ch7-builder-services.png"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Access the <code class='inline-code'>IServiceCollection</code> trough <code class='inline-code'>Services</code> property of the <code class='inline-code'>builder</code> variable"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Use the <code class='inline-code'>AddScoped&ltinterface, type&gt()</code> method for service registration. It's a <b>generic method</b> where you have to define the <b>interface and a class</b> that implements that interface. Then the DI container knows which concrete type to provide while resolving services."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var builder = WebApplication.CreateBuilder(args);\r\n\r\n// Add services to the container.\r\n\r\nbuilder.Services.AddScoped&ltIEmployeeService, EmployeeService&gt();\r\nbuilder.Services.AddScoped&ltIEmployeeRepository, EmployeeRepository&gt();\r\nbuilder.Services.AddScoped&ltIEmployeeData, EmployeeData&gt();\r\n\r\nbuilder.Services.AddControllers();\r\n//..."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Try sending a <code class='inline-code'>GET</code> request again - the application should now work correctly. That’s because we’ve <b>registered</b> the necessary classes with the <b>DI container</b>, telling it exactly how to resolve the dependencies our application needs. By registering these classes in the DI container, we enable ASP.NET to <b>automatically resolve</b> and supply the correct implementations whenever they're needed."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Service resolution process",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        IsPicture = true,
                                        PictureUrl = "c6-ch7-service-resolution.png"
                                    },
                                    new Paragraph
                                    {
                                        Body = "When an HTTP request <b>comes in</b>, ASP.NET routes it to the appropriate controller."
                                    },
                                    new Paragraph
                                    {
                                        Body = "The DI container is then responsible for creating an instance of the <code class='inline-code'>EmployeesController</code>. Since the controller has a dependency on <code class='inline-code'>IEmployeeService</code>, the DI container attempts to resolve that dependency by creating an instance of the registered concrete type - <code class='inline-code'>EmployeeService</code>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Similarly, <code class='inline-code'>EmployeeService</code> depends on <code class='inline-code'>IEmployeeRepository</code>, which the container resolves by creating an instance of <code class='inline-code'>EmployeeRepository</code>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "This <b>recursive</b> process of resolving dependencies continues until all required dependencies are satisfied. Then, the fully-constructed <code class='inline-code'>EmployeesController</code> is ready to handle the request."
                                    },
                                    new Paragraph
                                    {
                                        Body = "That's the <b>service resolution flow</b> of our current application."
                                    },
                                    new Paragraph
                                    {
                                        BackgroundColor="#1C236D",
                                        FontColor="#FFF",
                                        Body = "You can find the code for this project <a href='https://github.com/nwdorian/DependencyInjectionFundamentals/tree/main/WebApiExamples/TeamPulseDI/TeamPulse.Api' target='_blank'>on this link</a>."
                                    }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500157,
                        CourseDisplayId = 8,
                        Title = "Service Lifetimes",
                        Slug = "service-lifetimes",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Remember when we said that dependency injection is about instantiating classes? Well, that was only part of the story (and we kept it simple on purpose)."
                                    },
                                    new Paragraph
                                    {
                                        Body = "While dependency injection does handle <b>object creation</b>, it’s also equally responsible for <b>object disposal</b> - something we didn’t think about much when using the <b>new</b> keyword."
                                    },
                                    new Paragraph
                                    {
                                        Body = "When you manually <b>new</b>-up an object, <b>you</b> are responsible for managing its lifetime. In some cases, like working with database connections via ADO.NET or Dapper, we utilized <code class='inline-code'>using</code> declarations to ensure those connections were properly disposed. But that only works for objects that implement the <code class='inline-code'>IDisposable</code> interface. As for everything else? Those objects are eventually cleaned up by the .NET <b>Garbage Collector</b> - whenever it gets around to it."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Object disposal can be a real concern in long-running applications, and that’s another reason why dependency injection exists: it doesn’t just construct objects, it <b>tracks</b> them and <b>disposes</b> of them properly when they’re no longer needed."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "What is a lifetime of an application?",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "<b>Application lifetime</b> refers to the period during which your application is running."
                                    },
                                    new Paragraph
                                    {
                                        Body = "When developing locally, we often start the app, test a few endpoints, then shut it down and go back to coding. That cycle may last just a few minutes. But in <b>production</b>, applications can run for days, weeks, or even months without restarting."
                                    },
                                    new Paragraph
                                    {
                                        Body = "This shift in mindset, from short-lived dev sessions to long-lived production processes, is what makes <b>service lifetimes</b> and proper <b>object disposal</b> so important. If your application runs continuously, you need to ensure that the objects it creates don’t hang around longer than necessary, consuming memory or holding onto resources like database connections or file handles."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Service lifetimes",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "In ASP.NET, services can be registered with one of three lifetimes: <b>Singleton</b>, <b>Scoped</b>, or <b>Transient</b>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Just like <i>application lifetime</i> refers to how long the application is running, a <i>service lifetime</i> refers to how long a specific object remains in memory. ASP.NET gives us control over when our dependencies are created and disposed of - this is handled through service lifetimes."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Choosing the correct lifetime helps us manage memory efficiently and avoid unnecessary object creation or resource leaks."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Singleton",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "The DI container \"holds\" <b>only one</b> instance of the object for the entire <b>application lifetime</b>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Whoever wants to use this object will get the <b>same object reference</b>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Lifetime of the object is equal to the <b>lifetime of the application</b>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Used for caching, configuration or services that manage global state."
                                    },
                                    new Paragraph
                                    {
                                        IsPicture = true,
                                        PictureUrl = "c6-ch8-singleton.png"
                                    },
                                    new Paragraph
                                    {
                                        Body = "<b>Image</b>: Only the <b>Data class</b> has been registered as singleton. For each different request that comes in the same object is reused as there is only one object in the DI container."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Scoped",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "The DI container is \"holding\" many objects, but a <b>new instance</b> is created only per <b>each HTTP request</b>. Within the same request, the same object is reused wherever the dependency is injected."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Once the request is completed, the object is disposed of."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Lifetime of the object is equal to the <b>lifetime of the request</b>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "This is the <b>recommended lifetime</b> to use in ASP.NET, because it fits naturally with the request-response cycle of a web application."
                                    },
                                    new Paragraph
                                    {
                                        Body = "EF Core's <b>DbContext</b> is a scoped service by default."
                                    },
                                    new Paragraph
                                    {
                                        IsPicture = true,
                                        PictureUrl = "c6-ch8-scoped.png"
                                    },
                                    new Paragraph
                                    {
                                        Body = "<b>Image</b>: All classes are registered as scoped. If the controller requires three instances of a service class and two instances of a repository class it only gets one instance of each class per request and those same objects are reused during the lifetime of the request."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Transient",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "A <b>new instance</b> is created <b>every time</b> the object is requested."
                                    },
                                    new Paragraph
                                    {
                                        Body = "The DI container is \"holding\" many objects and gives a new one every time, it never reuses the same object reference - each injection results in a completely new object."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Lifetime of the object is equal to the lifetime of the <b>variable that represents the service object.</b>"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Used for lightweight services or when you explicitly need a fresh object every time."
                                    },
                                    new Paragraph
                                    {
                                        IsPicture = true,
                                        PictureUrl = "c6-ch8-transient.png"
                                    },
                                    new Paragraph
                                    {
                                        Body = "<b>Image</b>: If the controller needs three instances of a service class and two instances of a repository class it get's a new instance of each class every time it's requested - already created objects are never reused."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Additional clarification",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "You don't have to write this code yourself, it's only for demonstration purposes."
                                    },
                                    new Paragraph
                                    {
                                        Body = "If we duplicated the line where we fetch employees and have two calls to the <code class='inline-code'>EmployeeService</code> in the same request, like this:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "[Route(\"api/[controller]\")]\r\n[ApiController]\r\npublic class EmployeesController : ControllerBase\r\n{\r\n    private readonly IEmployeeService _employeeService;\r\n\r\n    public EmployeesController(IEmployeeService employeeService)\r\n    {\r\n        _employeeService = employeeService;\r\n    }\r\n\r\n    [HttpGet]\r\n    public IActionResult GetAll()\r\n    {\r\n        var employees1 = _employeeService.GetAllEmployees();\r\n        var employees2 = _employeeService.GetAllEmployees(); // Duplicated method call\r\n        return Ok(employees);\r\n    }\r\n}"
                                    },
                                    new Paragraph
                                    {
                                        Body = "We are calling the same field <code class='inline-code'>_employeeService</code> twice - this field was <b>injected once via constructor</b>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "The number of times we call methods on the field does not change how many instances of <code class='inline-code'>IEmployeeService</code> are created.<b><br>The number of times a service was injected is what matters.</b>"
                                    },
                                    new Paragraph
                                    {
                                        Body = "<b>Scoped</b>:<ul style='padding-left: 1.5rem;'><li>One instance of <code class='inline-code'>EmployeeService</code> is created <b>per request</b>.</li><li>Both calls to <code class='inline-code'>_employeeService.GetAllEmployees()</code> use the <b>same instance</b>.</li></ul><b>Transient</b>:<ul style='padding-left: 1.5rem;'><li>Controller  requested <code class='inline-code'>IEmployeeService</code> <b>only once</b>, via constructor injection.</li><li>So <b>only one instance</b> was created by the container for that request, even if you call its methods multiple times.</li><li>Just like in case of scoped, both method calls use the <b>same instance</b>.</li></ul>"
                                    },
                                    new Paragraph
                                    {
                                        Body = "You would get two instances only if you had <b>multiple injections</b> to the controller for the same transient service within the same request:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public class SomeClass\r\n{\r\n    public SomeClass(IEmployeeService employeeService1, IEmployeeService employeeService2)\r\n    {\r\n        // Two constructor parameters of the same transient type\r\n        // If IEmployeeService is transient → two different instances are injected\r\n    }\r\n}"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Injecting services with different lifetimes into one another",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "<b>Never inject Scoped and Transient services into a Singleton service.</b> This will effectively convert a transient or scoped service into the singleton."
                                    },
                                    new Paragraph
                                    {
                                        Body = "<b>Never inject Transient services into a Scoped service</b>. This converts the transient into the a scoped service."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Conclusion",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Each lifetime comes with trade-offs. Singleton services are memory-efficient but shared, Scoped services are request-safe and balanced, and Transient services offer maximum isolation but can increase memory usage if overused."
                                    }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500158,
                        CourseDisplayId = 9,
                        Title = "Dependency Injection in Console Applications",
                        Slug = "di-in-console-apps",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "We've already covered a lot of ground, to speed things up a bit let's reuse some code from previous lessons."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Create a new console application and give it a name <b>TeamPulseConsole</b>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Create the same Data, Repository and Service classes and interfaces from the WebApi project, feel free to copy the code over. This is what the starting point should look like:"
                                    },
                                    new Paragraph
                                    {
                                        IsPicture = true,
                                        PictureUrl = "c6-ch9-team-pulse-console.png"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Extending the application",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "We should be familiar with <code class='inline-code'>Spectre.Console</code> <a href='https://www.nuget.org/packages/spectre.console' target='_blank' style='color: #7DA2C8; text-decoration: underline;'>NuGet package</a>, let's add it to our application."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "dotnet add package Spectre.Console"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Create a folder <b>Helpers</b> and inside it add a <code class='inline-code'>TableVisualization</code> class."
                                    },
                                    new Paragraph
                                    {
                                        Body = "We can mark <code class='inline-code'>DisplayEmployeesTable</code> method as static as it doesn't access instance data:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public class TableVisualization\r\n{\r\n    public static void DisplayEmployeeTable(List&ltEmployee&gt employees)\r\n    {\r\n        var table = new Table();\r\n        table.Title = new TableTitle(\"Employees\");\r\n        table.AddColumns(\"Id\", \"Name\", \"Email\", \"Department\");\r\n\r\n        foreach (var employee in employees)\r\n        {\r\n            table.AddRow(employee.Id.ToString(), employee.Name, employee.Email, employee.Department);\r\n        }\r\n\r\n        AnsiConsole.Write(table);\r\n    }\r\n}"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Next, create a <b>Views</b> folder with <code class='inline-code'>IEmployeeView</code> interface and <code class='inline-code'>EmployeeView</code> class."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public interface IEmployeeView\r\n{\r\n    void DisplayAllEmployees();\r\n}"
                                    },
                                    new Paragraph
                                    {
                                        Body = "<code class='inline-code'>EmployeeView</code> class will display data based on some logic."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Make it inherit the <code class='inline-code'>IEmployeeView</code> interface and inject <code class='inline-code'>IEmployeeService</code> through the constructor:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public class EmployeeView : IEmployeeView\r\n{\r\n    private readonly IEmployeeService _employeeService;\r\n\r\n    public EmployeeView(IEmployeeService employeeService)\r\n    {\r\n        _employeeService = employeeService;\r\n    }\r\n\r\n    public void DisplayAllEmployees()\r\n    {\r\n        var employees = _employeeService.GetAllEmployees();\r\n\r\n        if (employees.Count == 0)\r\n        {\r\n            AnsiConsole.MarkupLine(\"[red]No employees found in the database![/]\");\r\n            AnsiConsole.WriteLine(\"Press any key to continue...\");\r\n            System.Console.ReadLine();\r\n            return;\r\n        }\r\n\r\n        TableVisualization.DisplayEmployeeTable(employees);\r\n        AnsiConsole.WriteLine(\"Press any key to continue...\");\r\n        System.Console.ReadLine();\r\n    }\r\n}"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Create a <b>Menus</b> folder with <code class='inline-code'>IMainMenu</code> interface and <code class='inline-code'>MainMenu</code> class."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public interface IMainMenu\r\n{\r\n    void Display();\r\n}"
                                    },
                                    new Paragraph
                                    {
                                        Body = "<code class='inline-code'>MainMenu</code> will display a simple menu and call the methods from <code class='inline-code'>EmployeeView</code>"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Make it inherit the <code class='inline-code'>IMainMenu</code> interface and inject <code class='inline-code'>IEmployeeView</code> through the constructor:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public class MainMenu : IMainMenu\r\n{\r\n    private readonly IEmployeeView _employeeView;\r\n\r\n    public MainMenu(IEmployeeView employeeView)\r\n    {\r\n        _employeeView = employeeView;\r\n    }\r\n\r\n    public void Display()\r\n    {\r\n        var exit = false;\r\n        while (!exit)\r\n        {\r\n            AnsiConsole.Clear();\r\n            var selection = AnsiConsole.Prompt(\r\n                new SelectionPrompt&ltstring&gt()\r\n                .Title(\"Select from the menu:\")\r\n                .AddChoices(\"Show All\", \"Exit\")\r\n            );\r\n\r\n            switch (selection)\r\n            {\r\n                case \"Show All\":\r\n                    _employeeView.DisplayAllEmployees();\r\n                    break;\r\n                case \"Exit\":\r\n                    exit = true;\r\n                    break;\r\n            }\r\n        }\r\n    }\r\n}"
                                    },
                                    new Paragraph
                                    {
                                        Body = "We are done with setting up code, up next we will look into different ways of implementing DI in console applications."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Implementing dependency injection in console applications",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "There are two ways to implement dependency injection in console applications:<ol style='padding-left: 1.5rem;'><li>Using <code class='inline-code'>Microsoft.Extensions.DependencyInjection</code> NuGet package directly</li><li>Using <code class='inline-code'>Host.CreateApplicationBuilder()</code> from <code class='inline-code'>Microsoft.Extensions.Hosting</code> NuGet package</li></ol>"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Microsoft.Extensions.DependencyInjection",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Install the <a href='https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection' target='_blank' style='color: #7DA2C8; text-decoration: underline;'>NuGet package</a>"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "dotnet add package Microsoft.Extensions.DependencyInjection"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This package allows us to instantiate our own service collection and then build the DI container with registered services. Let's have a look at <code class='inline-code'>program.cs</code>:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "// Instantiate a new service collection\r\nvar serviceCollection = new ServiceCollection();\r\n\r\n// Register services\r\nserviceCollection.AddTransient&ltIMainMenu, MainMenu&gt();\r\nserviceCollection.AddTransient&ltIEmployeeView, EmployeeView&gt();\r\nserviceCollection.AddTransient&ltIEmployeeService, EmployeeService&gt();\r\nserviceCollection.AddTransient&ltIEmployeeRepository, EmployeeRepository&gt();\r\nserviceCollection.AddTransient&ltIEmployeeData, EmployeeData&gt();\r\n\r\n// Build the service provider (our DI container) with the registered services\r\nvar serviceProvider = serviceCollection.BuildServiceProvider();\r\n\r\n// Retrieve the main menu instance from the container\r\nvar mainMenu = serviceProvider.GetRequiredService&ltIMainMenu&gt();\r\n\r\n// Start the application by displaying the main menu\r\nmainMenu.Display();"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Host.CreateApplicationBuilder()",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "<code class='inline-code'>Host.CreateApplicationBuilder()</code> is a simplified, modern approach introduced in <b>.NET 7</b> to set up a host for console applications. It's very similar to <code class='inline-code'>WebApplicationBuilder</code> we have in WebApi projects and offers direct access to:<ul style='padding-left: 1.5rem;'><li>Dependency injection</li><li>Configuration</li><li>Logging</li><li>Environment</li></ul>"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This is the recommended way to implement dependency injection in console applications."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Before proceeding, remove the <code class='inline-code'>Microsoft.Extensions.DependencyInjection</code> package from your project."
                                    },
                                    new Paragraph
                                    {
                                        Body = "To use <code class='inline-code'>Host.CreateApplicationBuilder()</code> you only need to install <code class='inline-code'>Microsoft.Extensions.Hosting</code> <a href='https://www.nuget.org/packages/microsoft.extensions.hosting' target='_blank' style='color: #7DA2C8; text-decoration: underline;'>NuGet package</a>."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "dotnet add package Microsoft.Extensions.Hosting"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This package <b>already includes</b>:<ul style='padding-left: 1.5rem;'><li><code class='inline-code'>Microsoft.Extensions.DependencyInjection</code></li><li><code class='inline-code'>Microsoft.Extensions.Configuration</code></li><li><code class='inline-code'>Microsoft.Extensions.Logging</code></li></ul>"
                                    },
                                    new Paragraph
                                    {
                                        Body = "You can find out more about <code class='inline-code'>.NET Generic Host</code> on the <a href='https://learn.microsoft.com/en-us/dotnet/core/extensions/generic-host?tabs=appbuilder' target='_blank' style='color: #7DA2C8; text-decoration: underline;'>link</a>"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Next, modify <code class='inline-code'>program.cs</code> with the following code:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "// Create a new HostBuilder with built-in configuration, logging, and DI setup\r\nvar builder = Host.CreateApplicationBuilder();\r\n\r\n// Register services\r\nbuilder.Services.AddTransient&ltIMainMenu, MainMenu&gt();\r\nbuilder.Services.AddTransient&ltIEmployeeView, EmployeeView&gt();\r\nbuilder.Services.AddTransient&ltIEmployeeService, EmployeeService&gt();\r\nbuilder.Services.AddTransient&ltIEmployeeRepository, EmployeeRepository&gt();\r\nbuilder.Services.AddTransient&ltIEmployeeData, EmployeeData&gt();\r\n\r\n// Build the host, which finalizes configuration and prepares the DI container\r\nusing var host = builder.Build();\r\n\r\n// Retrieve the main menu service from the DI container\r\nvar mainMenu = host.Services.GetRequiredService&ltIMainMenu&gt();\r\n\r\n// Start the application by displaying the main menu\r\nmainMenu.Display();"
                                    },
                                    new Paragraph
                                    {
                                        Body = "You can now see why it's said ASP.NET comes with built-in Dependency Injection functionality. After creating a new <b>WebApi</b> project, <code class='inline-code'>program.cs</code> already has the <code class='inline-code'>WebApplicationBuilder</code> created. Console applications are not a part of ASP.NET framework so we have to manually introduce DI support."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Service lifetimes in console applications",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "In ASP.NET, the scoped lifetime is tied to the <b>HTTP request</b>, but in <b>console applications</b>, there’s no built-in request pipeline, so scoped services don't work the same way. They will actually behave like singleton services."
                                    },
                                    new Paragraph
                                    {
                                        Body = "That's why <b>transient</b> is the recommended service lifetime in console applications."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Only use <b>singleton</b> when registering <code class='inline-code'>HttpClient</code>, configuration, logging or caching services."
                                    },
                                    new Paragraph
                                    {
                                        BackgroundColor="#1C236D",
                                        FontColor="#FFF",
                                        Body = "You can find the code for this project <a href='https://github.com/nwdorian/DependencyInjectionFundamentals/tree/main/ConsoleExamples/TeamPulseConsole/TeamPulse.Console' target='_blank'>on this link</a>."
                                    }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500159,
                        CourseDisplayId = 10,
                        Title = "Service Collection Extension Pattern",
                        Slug = "service-colletion-extension-pattern",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "As your application <b>grows in complexity</b>, you have to register more and more services in <code class='inline-code'>program.cs</code> which can make it bloated and unreadable."
                                    },
                                    new Paragraph
                                    {
                                        Body = "To avoid this we can move <b>service registration</b> to an extension class to provide a more <b>organized structure</b>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Create an <b>Extensions</b> folder with a static class <code class='inline-code'>ServiceCollectionExtensions</code>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Then create an extension method on the <code class='inline-code'>IServiceCollection</code> interface and move all service registrations from <code class='inline-code'>program.cs</code> to it:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public static class ServiceCollectionExtensions\r\n{\r\n    public static IServiceCollection AddCustomServices(this IServiceCollection services)\r\n    {\r\n        services.AddTransient&ltIMainMenu, MainMenu&gt();\r\n        services.AddTransient&ltIEmployeeView, EmployeeView&gt();\r\n        services.AddTransient&ltIEmployeeService, EmployeeService&gt();\r\n        services.AddTransient&ltIEmployeeRepository, EmployeeRepository&gt();\r\n        services.AddTransient&ltIEmployeeData, EmployeeData&gt();\r\n\r\n        return services;\r\n    }\r\n}"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Afterwards, in <code class='inline-code'>program.cs</code> simply call the method on the <code class='inline-code'>builder.Services</code> property:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var builder = Host.CreateApplicationBuilder();\r\n\r\nbuilder.Services.AddCustomServices(); // Extension method\r\n\r\nusing var host = builder.Build();\r\n// ..."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Microsoft prefixes methods that register services to the DI container with \"<b>Add</b>\" by convention so it's a good practice to follow."
                                    },
                                    new Paragraph
                                    {
                                        Body = "This pattern can be utilized with various service registrations making <code class='inline-code'>program.cs</code> clean and tidy and it allows us to organize services into <b>logical groups of related functionality</b>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Additional example with <code class='inline-code'>DbContext</code> registration:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public static class ServiceCollectionExtensions\r\n{\r\n	public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)\r\n	{\r\n	    services.AddDbContext<CustomDbContext>(options => options.UseSqlServer(connectionString));\r\n\r\n	    return services;\r\n	}\r\n}\r\n\r\n// program.cs\r\nvar connectionString = builder.Configuration.GetConnectionString(\"Default\");\r\nbuilder.Services.AddDatabase(connectionString);\r\n\r\n// or in one line\r\nbuilder.Services.AddDatabase(Configuration.GetConnectionString(\"Default\"));"
                                    },
                                    new Paragraph
                                    {
                                        BackgroundColor="#1C236D",
                                        FontColor="#FFF",
                                        Body = "You can find the code for this project <a href='https://github.com/nwdorian/DependencyInjectionFundamentals/tree/main/ConsoleExamples/TeamPulseConsole/TeamPulse.Console' target='_blank'>on this link</a>."
                                    }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500160,
                        CourseDisplayId = 11,
                        Title = "Frequently Asked Questions",
                        Slug = "faq",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Here you can find some frequently asked questions that were often discussed in The C# Academy <a href='https://discord.com/invite/aDMDET8ywB' target='_blank' style='color: #7DA2C8; text-decoration: underline;'>Discord Server</a>"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Do I have to use interfaces with dependency injection?",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Yes and no."
                                    },
                                    new Paragraph
                                    {
                                        Body = "You can absolutely inject <b>concrete classes</b> directly without using interfaces and your application will still function correctly. The generic service registration methods also allow to only specify the concrete class:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "builder.Services.AddScoped&ltEmployeeService&gt();"
                                    },
                                    new Paragraph
                                    {
                                        Body = "However, by doing so, you <b>miss out on key benefits</b> of using interfaces, such as:<ul style='padding-left: 1.5rem;'><li>Loose coupling between components</li><li>Easier testing (especially mocking)</li><li>Better adherence to <b>SOLID</b> principles like the <b>Dependency Inversion Principle</b></li></ul>"
                                    },
                                    new Paragraph
                                    {
                                        Body = "In short: <i>you’re not required</i> to use interfaces, but <b>you should</b> if you want clean, maintainable, and scalable code."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Which dependency injection framework to use ?",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "You have several options when it comes to dependency injection in .NET."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Microsoft’s built-in <b>dependency injection container</b> is just one of them, others include popular third-party frameworks like <b>Autofac</b>, <b>Ninject</b>, and <b>StructureMap</b>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "While all these frameworks ultimately solve the same problem, <b>Microsoft's built-in DI</b> is <b>most commonly used today</b>, especially since it has matured significantly over the years."
                                    },
                                    new Paragraph
                                    {
                                        Body = "<b>Autofac</b> was more widely adopted in earlier versions of .NET, and it's still a solid choice, particularly in legacy projects or companies that have standardized on it. One feature developers like about Autofac is it's <b>module system</b> for organizing registrations. That said, similar organization can be achieved with Microsoft's DI using <i>Service Collection Extension Pattern</i>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Stick with Microsoft’s built-in DI for <b>learning, personal projects, or new applications</b>, unless your team or company specifically uses something else like Autofac."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Do I have to think about the order of registering services?",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "In general - no. Though, you should be aware of the behavior when it comes to registering the same service multiple times."
                                    },
                                    new Paragraph
                                    {
                                        Body = "If you register the same service/interface multiple times, the last registration wins."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "services.AddSingleton&ltIDataService, SqlDataService&gt();\r\nservices.AddSingleton&ltIDataService, InMemoryDataService&gt(); // This one will be used\r\n"
                                    },
                                    new Paragraph
                                    {
                                        Body = "If each interface/class pair is unique, the order doesn't matter."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Rule of thumb: register services in any order unless you're overriding something - then the last one wins."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Why are we using private fields in constructor injection?",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "This is a simple answer - constructor parameters are only available inside the constructor scope. Assigning them to class fields makes them available in the entire class. "
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Should I use primary constructors?",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Your certainly can! Primary constructors (introduced in C# 12) simplify how we write constructors for certain types, especially record and class declarations, by allowing you to declare constructor parameters directly in the class header."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "// classic constructor injection syntax\r\npublic class StudentService\r\n{\r\n	private readonly IStudentRepository _studentRepository;\r\n\r\n	public StudentService(IStudentRepository studentRepository)\r\n	{\r\n		_studentRepository = studentRepository;\r\n	}\r\n	// ...\r\n}\r\n\r\n// primary constructors syntax\r\npublic class StudentService(IStudentRepository studentRepository)\r\n{\r\n	// ...\r\n}"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Have a closer look into primary constructors before deciding whether to use them or not. Here is a <a href='https://endjin.com/blog/2024/10/csharp-12-primary-constructors' target='_blank' style='color: #7DA2C8; text-decoration: underline;'>detailed article</a> which explains pros and cons."
                                    }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500161,
                        CourseDisplayId = 12,
                        Title = "Conclusion",
                        Slug = "conclusion",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Title = "🎉 Congratulations! You've Completed the Dependency Injection Course!",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "You should now be familiar with one of the most foundational concepts in modern .NET development - Dependency Injection design pattern. Understanding Dependency Injection means understanding how to write <b>modular</b>, <b>testable</b>, and <b>maintainable</b> applications, which is key whether you're building web apps, APIs, or desktop tools."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "What to do next ?",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Take a moment to reflect on what you've learned:<ul style='padding-left: 1.5rem;'><li>What parts of DI now make sense to you that were confusing before?</li><li>Are there parts you're still unsure about, like service lifetimes, containers, or constructor injection?</li><li>How has this changed the way you think about structuring your applications?</li></ul>"
                                    },
                                    new Paragraph
                                    {
                                        Body = "If you're following our <a href='https://thecsharpacademy.com/#' target='_blank' style='color: #7DA2C8; text-decoration: underline;'>learning roadmap</a> there are upcoming projects where DI plays a central role, starting from <a href='https://thecsharpacademy.com/project/17/shifts-logger' target='_blank' style='color: #7DA2C8; text-decoration: underline;'>Shifts Logger</a>. Have your own idea for a project? Perfect! Try applying DI in a WebApi or start small with a CRUD service console app. <b>The best way to reinforce this knowledge is to build with it.</a>"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This course is always here for you to revisit. Each time you go through it, you'll understand things more deeply, learn something new or see the same topic from a different perspective."
                                    }
                                },
                            },
                            new Block
                            {
                                Title = "Additional resources",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "<ul style='padding-left: 1.5rem;'><li>Official Microsoft <a href='https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection' target='_blank' style='color: #7DA2C8; text-decoration: underline;'>Documentation</a></li><li>Great <a href='https://www.coreprogramm.com/2020/02/difference-between-addsingleton-addScoped-addTransient.html' target='_blank' style='color: #7DA2C8; text-decoration: underline;'>article</a> to dig deeper into service lifetimes with a practical example</li><li>A video on how to <a href='https://www.youtube.com/watch?v=GZ7MYupyOlY' target='_blank' style='color: #7DA2C8; text-decoration: underline;'>build your own IoC container</a></li><li>Amazing quality of life tip that shows how to <a href='https://ardalis.com/configure-visual-studio-to-name-private-fields-with-underscore/' target='_blank' style='color: #7DA2C8; text-decoration: underline;'>configure Visual Studio 2022 to name private fields with underscore</a></li></ul>"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "🎊 Congratulations on Your Progress!",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "You've leveled up your architecture skills and taken a big step toward building professional-grade software. Keep building, keep experimenting, and most of all - <b>keep going</b>!"
                                    }
                                }
                            }
                        }
                    }
                }
        };
    }
}
