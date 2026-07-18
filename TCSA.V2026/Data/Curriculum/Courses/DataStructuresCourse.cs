using TCSA.V2026.Data.Models;
using static TCSA.V2026.Helpers.CourseContentHelper;

namespace TCSA.V2026.Data.Curriculum;

public class DataStructuresCourse
{
    public static Course GetDataStructuresCourse()
    {
        return new Course
        {
            Id = 9,
            Title = "Beginner Data Structures in C#",
            Description = "Learn to use common .NET data structures and choose the right collection for practical C# problems.",
            ImgUrl = "icons8-memory-512.png",
            Articles = new List<Article>
            {
                new Article
                {
                    Id = 500300,
                    CourseDisplayId = 1,
                    Title = "About This Course",
                    Slug = "about-this-data-structures-course",
                    Description = "Understand what this course covers, how it is organised, and how to get the most from it.",
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
                                    Body = "Welcome to <b>Beginner Data Structures in C#</b>. This course will teach you how programs organise data so it can be stored, accessed, updated, and processed effectively."
                                },
                                new Paragraph
                                {
                                    Body = "A data structure is more than a container. The structure we choose affects how clearly we can model a problem and how efficiently our program can perform common operations. Throughout the course, we will connect each structure to the problems it is designed to solve."
                                },
                                new Paragraph
                                {
                                    Body = "We will begin with the ideas behind data structures before moving into the implementations provided by .NET. The goal is not to memorise method names. It is to understand how common structures behave, recognise their practical trade-offs, and choose an appropriate tool for a problem."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "What You Will Learn",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = RedDotList(
                                        "What data structures are and why programmers use them.",
                                        "How common data structures organise and access their values.",
                                        "How operations such as searching, inserting, and removing differ between structures.",
                                        "How to reason about the strengths, limitations, and practical uses of each structure.",
                                        "How to use arrays, lists, dictionaries, sets, stacks, and queues in C#.")
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Course Scope",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "This is a practical beginner course about <b>using, understanding, and choosing</b> common data structures. We will not study formal complexity analysis or implement the internal algorithms behind the collections."
                                },
                                new Paragraph
                                {
                                    Body = "Big O notation, linked lists, trees, heaps, graphs, and advanced algorithms belong in a future <b>Data Structures and Algorithms</b> course. You do not need that knowledge to begin this course."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "How To Use This Course",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Read each chapter in order and type the examples yourself. When an exercise asks you to predict what will happen, make your prediction before running the code. That small pause is an important part of learning."
                                },
                                new Paragraph
                                {
                                    Body = "Do not rush to collect definitions. Draw the structures, trace their operations by hand, and explain the trade-offs in your own words. A data structure becomes useful when you understand its behaviour, not merely its name."
                                },
                                new Paragraph
                                {
                                    Body = "If you use AI while studying, use it for explanations, hints, and feedback after making a genuine attempt. Letting it complete the exercises for you removes the reasoning practice this course is designed to build."
                                }
                            }
                        }
                    }
                },
                new Article
                {
                    Id = 500301,
                    CourseDisplayId = 2,
                    Title = "A Brief History of Data Structures",
                    Slug = "a-brief-history-of-data-structures",
                    Description = "Explore how data structures developed alongside computers, programming languages, and increasingly complex software.",
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
                                    Body = "Data structures have developed alongside computing itself. As early computers began processing larger and more varied collections of information, programmers needed reliable ways to organise values in memory and perform operations on them."
                                },
                                new Paragraph
                                {
                                    Body = "Some structures model information in a simple sequence. Others represent priorities, relationships, hierarchies, or fast lookups. Many of the structures used in modern software were studied and refined during the early decades of computer science, then incorporated into programming languages and their standard libraries."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "From Machine Memory To Abstraction",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Early programmers worked close to the machine and had to manage memory locations directly. Arrays provided a way to treat adjacent memory locations as one indexed collection, making repeated data easier to manage."
                                },
                                new Paragraph
                                {
                                    Body = "As programming languages became more expressive, structures such as linked lists, stacks, queues, trees, graphs, and hash tables gave programmers reusable models for common problems. These abstractions let developers focus on the behaviour they need without handling every memory detail themselves."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Why These Ideas Still Matter",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Modern languages such as C# provide ready-made collection types, but the underlying decisions have not disappeared. A <code class='inline-code'>List&lt;T&gt;</code>, <code class='inline-code'>Queue&lt;T&gt;</code>, <code class='inline-code'>Stack&lt;T&gt;</code>, or <code class='inline-code'>Dictionary&lt;TKey, TValue&gt;</code> behaves differently because each is built around a different structure and purpose."
                                },
                                new Paragraph
                                {
                                    Body = "Understanding that history helps explain why these types exist and why no single collection is best for every task. The central question remains the same: <b>how should this data be organised for the work the program needs to do?</b>"
                                }
                            }
                        }
                    }
                },
                new Article
                {
                    Id = 500302,
                    CourseDisplayId = 3,
                    Title = "Who This Course Is For",
                    Slug = "who-this-data-structures-course-is-for",
                    Description = "Check the recommended knowledge, learning goals, and expectations for this course.",
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
                                    Body = "This course is for C# students who are comfortable with the fundamentals and want to learn how to organise data in their applications. It is especially useful if you can write small working programs but are not always sure which collection to choose for a particular problem."
                                },
                                new Paragraph
                                {
                                    Body = "You do not need a computer science degree or previous algorithms experience. We will introduce new terminology carefully and connect it to code, diagrams, and familiar programming problems."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Recommended Knowledge",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Before starting, you should understand:"
                                },
                                new Paragraph
                                {
                                    Body = RedDotList(
                                        "Variables, conditions, loops, and methods.",
                                        "Classes, objects, and basic object-oriented programming.",
                                        "How to create and run a C# console application.",
                                        "Basic debugging and how to read compiler errors.")
                                },
                                new Paragraph
                                {
                                    Body = "If these topics are still unfamiliar, read the <a href='/article/8/foundations' target='_blank'>C# Foundations article</a> and complete the <a href='/project/53/math-game' target='_blank'>Math Game</a> and <a href='/project/11/calculator' target='_blank'>Calculator</a> projects first. You will get much more from this course when the language syntax is not competing for your attention."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "The Mindset You Need",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Data structures require patience and active reasoning. Expect to trace examples, draw boxes and arrows, compare alternatives, and revisit an idea more than once. Confusion during that process is normal; working through it is how the mental model develops."
                                },
                                new Paragraph
                                {
                                    Body = "You should finish the course able to explain not only <b>how</b> a structure works, but also <b>when</b> you would choose it and <b>what trade-offs</b> come with that choice."
                                }
                            }
                        }
                    }
                },
                new Article
                {
                    Id = 500303,
                    CourseDisplayId = 4,
                    Title = "Set Up the Store Application",
                    Slug = "set-up-the-data-structures-store-application",
                    Description = "Turn the starter project into a small Spectre.Console application shell that will grow throughout the course.",
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
                                    Body = "Throughout this course, we will build a <b>Store Management System</b>. Each new data structure will solve a real problem in the store, so the application will grow one feature at a time."
                                },
                                new Paragraph
                                {
                                    Body = "The starter repository already contains a .NET 10 console application and the Spectre.Console package. At the moment it only prints <code class='inline-code'>Hello, World!!</code>. In this lesson, we will replace that line with the smallest useful application shell."
                                },
                                new Paragraph
                                {
                                    Body = "Clone or download the <a href='https://github.com/TheCSharpAcademy/TCSA.Study.DataStructures' target='_blank'>TCSA.Study.DataStructures repository</a>, open the solution, and run it once before making any changes. This confirms that your environment is ready."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Why Start With a Shell?",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "We want to understand the application we are building without implementing the features that the data structures are meant to teach. The initial version therefore needs only a main menu, an exit option, and a placeholder for the first store feature."
                                },
                                new Paragraph
                                {
                                    Body = "We will begin with only <b>View Departments</b> and <b>Exit</b>. The next chapter will ask how a store should represent a small group of departments that does not change. That question will give us a natural reason to introduce arrays."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "A Quick Note About Spectre.Console",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "<code class='inline-code'>Spectre.Console</code> is a popular library for building better-looking console applications in .NET. It gives us interactive menus, colours, tables, prompts, and other useful display components without requiring us to build a graphical user interface."
                                },
                                new Paragraph
                                {
                                    Body = "In this project, Spectre.Console is used only for <b>presentation</b>. It will make the Store Management System easier to navigate and its information easier to read, but it is not the subject of this course. Our focus is understanding data structures and choosing the right one for each feature."
                                },
                                new Paragraph
                                {
                                    Body = "You will encounter types such as <code class='inline-code'>AnsiConsole</code>, <code class='inline-code'>SelectionPrompt</code>, <code class='inline-code'>FigletText</code>, and later <code class='inline-code'>Table</code>. You do not need to study or memorise these classes. Follow the provided display code and concentrate on the collections that store and organise the application's data."
                                },
                                new Paragraph
                                {
                                    Body = "Think of Spectre.Console as the display layer: it controls what the user sees, while arrays, lists, dictionaries, sets, stacks, and queues do the data work behind the scenes."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Create StoreApp.cs",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "In the <code class='inline-code'>TCSA.Study.DataStructures</code> project, create a file named <code class='inline-code'>StoreApp.cs</code>. Add the following code:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "using Spectre.Console;\r\n\r\nnamespace TCSA.Study.DataStructures;\r\n\r\npublic sealed class StoreApp\r\n{\r\n    public void Run()\r\n    {\r\n        bool isRunning = true;\r\n\r\n        while (isRunning)\r\n        {\r\n            AnsiConsole.Clear();\r\n            DisplayTitle();\r\n\r\n            string choice = AnsiConsole.Prompt(\r\n                new SelectionPrompt<string>()\r\n                    .Title(\"What would you like to do?\")\r\n                    .PageSize(5)\r\n                    .AddChoices(\r\n                        \"View Departments\",\r\n                        \"Exit\"));\r\n\r\n            switch (choice)\r\n            {\r\n                case \"View Departments\":\r\n                    ShowDepartmentsPlaceholder();\r\n                    break;\r\n                case \"Exit\":\r\n                    isRunning = false;\r\n                    break;\r\n            }\r\n        }\r\n    }\r\n\r\n    private static void DisplayTitle()\r\n    {\r\n        AnsiConsole.Write(\r\n            new FigletText(\"Store Management\")\r\n                .Centered()\r\n                .Color(Color.Green));\r\n    }\r\n\r\n    private static void ShowDepartmentsPlaceholder()\r\n    {\r\n        AnsiConsole.Clear();\r\n        AnsiConsole.MarkupLine(\"[yellow]Departments haven't been implemented yet.[/]\");\r\n        AnsiConsole.MarkupLine(\"[grey]Press any key to return to the menu...[/]\");\r\n        Console.ReadKey(intercept: true);\r\n    }\r\n}"
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Update Program.cs",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Replace the existing contents of <code class='inline-code'>Program.cs</code> with this entry point:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "using TCSA.Study.DataStructures;\r\n\r\nvar app = new StoreApp();\r\napp.Run();"
                                },
                                new Paragraph
                                {
                                    Body = "The entry point now has one responsibility: create the application and run it. The menu loop and presentation logic live in <code class='inline-code'>StoreApp</code>, where we can add features as the course progresses."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Run the Initial Application",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Run the application and check the following behaviour:"
                                },
                                new Paragraph
                                {
                                    Body = ExerciseList(
                                        "The store title and main menu are displayed.",
                                        "The arrow keys move between the menu choices.",
                                        "Selecting <b>View Departments</b> displays the placeholder message.",
                                        "Pressing a key after the placeholder returns to the menu.",
                                        "Selecting <b>Exit</b> closes the application.")
                                },
                                new Paragraph
                                {
                                    Body = "Do not add the other store features yet. In this course, every new menu option should appear when the data structure that supports it is introduced. This keeps the reason for each structure visible in the application."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "What Comes Next",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Our store needs a fixed set of departments: Electronics, Groceries, Clothing, Home, and Sports. In the next chapter, we will represent those departments with our first data structure: an <b>array</b>."
                                }
                            }
                        }
                    }
                },
                new Article
                {
                    Id = 500304,
                    CourseDisplayId = 5,
                    Title = "Arrays",
                    Slug = "data-structures-arrays",
                    Description = "Learn how arrays store a fixed number of values, then use one to represent the store's departments.",
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
                                    Body = "Our Store Management System needs a set of departments: Electronics, Groceries, Clothing, Home, and Sports. These departments will remain fixed in the first version of the application."
                                },
                                new Paragraph
                                {
                                    Body = "We need one variable that can hold several related values in a defined order. We also know how many values there will be before the application starts. This is a natural problem for our first data structure: an <b>array</b>."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "What Is an Array?",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "An array is a collection that stores a <b>fixed number of values of the same type</b>. Each value occupies a numbered position called an <b>index</b>. We use that index to read or replace a particular value."
                                },
                                new Paragraph
                                {
                                    Body = "Arrays are among the most fundamental data structures in programming. Many more flexible collections are built on top of array-like storage internally, which makes arrays a useful starting point for understanding how collections organise values."
                                },
                                new Paragraph
                                {
                                    Body = RedDotList(
                                        "An array has one element type, such as <code class='inline-code'>string</code>, <code class='inline-code'>int</code>, or <code class='inline-code'>Product</code>.",
                                        "Its length is decided when the array is created.",
                                        "Its elements are stored in a defined order.",
                                        "Each element can be accessed using its numeric index.",
                                        "The values can change, but the number of positions cannot change.")
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Creating Arrays",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "There are several ways to create an array in C#. The clearest option when we already know the values is a <b>collection expression</b>:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "string[] departments =\r\n[\r\n    \"Electronics\",\r\n    \"Groceries\",\r\n    \"Clothing\",\r\n    \"Home\",\r\n    \"Sports\"\r\n];"
                                },
                                new Paragraph
                                {
                                    Body = "The square brackets after <code class='inline-code'>string</code> tell C# that this variable refers to an array of strings. Every element must be compatible with the declared element type."
                                },
                                new Paragraph
                                {
                                    Body = "You can also create an array by specifying its length before assigning its values:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "string[] departments = new string[5];\r\n\r\ndepartments[0] = \"Electronics\";\r\ndepartments[1] = \"Groceries\";\r\ndepartments[2] = \"Clothing\";\r\ndepartments[3] = \"Home\";\r\ndepartments[4] = \"Sports\";"
                                },
                                new Paragraph
                                {
                                    Body = "When C# creates an array with <code class='inline-code'>new string[5]</code>, it immediately creates five positions. Until we assign strings to them, those positions contain the default value for <code class='inline-code'>string</code>, which is <code class='inline-code'>null</code>. Numeric arrays begin with zeroes, and <code class='inline-code'>bool</code> arrays begin with <code class='inline-code'>false</code>."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Indexes Start at Zero",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "C# arrays are <b>zero-indexed</b>. The first element is at index <code class='inline-code'>0</code>, the second is at index <code class='inline-code'>1</code>, and the final element is at index <code class='inline-code'>Length - 1</code>."
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "string[] departments = [\"Electronics\", \"Groceries\", \"Clothing\"];\r\n\r\nConsole.WriteLine(departments[0]); // Electronics\r\nConsole.WriteLine(departments[1]); // Groceries\r\nConsole.WriteLine(departments[2]); // Clothing"
                                },
                                new Paragraph
                                {
                                    Body = "An array with three elements has valid indexes from <code class='inline-code'>0</code> to <code class='inline-code'>2</code>. Trying to access index <code class='inline-code'>3</code> causes an <code class='inline-code'>IndexOutOfRangeException</code> at runtime."
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "Console.WriteLine(departments[3]); // Throws IndexOutOfRangeException"
                                },
                                new Paragraph
                                {
                                    Body = "You can also use the index-from-end operator. <code class='inline-code'>departments[^1]</code> means the last element, while <code class='inline-code'>departments[^2]</code> means the second-to-last element. Unlike a normal index, <code class='inline-code'>^1</code> refers to the final element; <code class='inline-code'>^0</code> refers to the position after the end and cannot be used to read an element."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Length and Iteration",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "The <code class='inline-code'>Length</code> property tells us how many elements an array contains:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "string[] departments = [\"Electronics\", \"Groceries\", \"Clothing\"];\r\n\r\nConsole.WriteLine(departments.Length); // 3"
                                },
                                new Paragraph
                                {
                                    Body = "Use <code class='inline-code'>foreach</code> when you want to process every element and do not need its index:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "foreach (string department in departments)\r\n{\r\n    Console.WriteLine(department);\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "Use <code class='inline-code'>for</code> when the index is part of the work. The condition uses <code class='inline-code'>&lt;</code>, not <code class='inline-code'>&lt;=</code>, because <code class='inline-code'>Length</code> is one greater than the final valid index."
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "for (int index = 0; index < departments.Length; index++)\r\n{\r\n    Console.WriteLine($\"{index + 1}. {departments[index]}\");\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "Here, <code class='inline-code'>index</code> is zero-based because it accesses the array. We print <code class='inline-code'>index + 1</code> because numbered lists shown to users normally begin at one."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Arrays Are Fixed-Size, Not Read-Only",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Fixed-size does not mean that an array's elements are permanent. We can replace a value at an existing index:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "string[] departments = [\"Electronics\", \"Food\", \"Clothing\"];\r\n\r\ndepartments[1] = \"Groceries\";\r\n\r\nConsole.WriteLine(departments[1]); // Groceries"
                                },
                                new Paragraph
                                {
                                    Body = "What we cannot do is add a sixth position to a five-element array or remove one of its positions. To represent a different number of elements, we must create another array with a different length and copy the values we want to keep."
                                },
                                new Paragraph
                                {
                                    Body = "That limitation is useful when the number of values is genuinely fixed. It becomes inconvenient when values need to be added and removed regularly. Later, <code class='inline-code'>List&lt;T&gt;</code> will solve that problem."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Arrays Are Reference Types",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "An array is a reference type, even when it contains value types such as <code class='inline-code'>int</code>. Assigning an array variable to another variable does not duplicate its elements. Both variables refer to the same array."
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "int[] original = [10, 20, 30];\r\nint[] sameArray = original;\r\n\r\nsameArray[0] = 99;\r\n\r\nConsole.WriteLine(original[0]); // 99"
                                },
                                new Paragraph
                                {
                                    Body = "Changing the array through <code class='inline-code'>sameArray</code> is visible through <code class='inline-code'>original</code> because there is only one array. When you need an independent copy, create a new array and copy the elements:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "int[] original = [10, 20, 30];\r\nint[] copy = new int[original.Length];\r\n\r\nArray.Copy(original, copy, original.Length);\r\ncopy[0] = 99;\r\n\r\nConsole.WriteLine(original[0]); // 10\r\nConsole.WriteLine(copy[0]);     // 99"
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Useful Array Operations",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "The <code class='inline-code'>Array</code> class provides static methods for common operations:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "string[] departments = [\"Sports\", \"Electronics\", \"Home\"];\r\n\r\nint homeIndex = Array.IndexOf(departments, \"Home\");\r\nConsole.WriteLine(homeIndex); // 2\r\n\r\nArray.Sort(departments);\r\n// Electronics, Home, Sports\r\n\r\nArray.Reverse(departments);\r\n// Sports, Home, Electronics"
                                },
                                new Paragraph
                                {
                                    Body = "<code class='inline-code'>Array.IndexOf</code> returns the matching element's index or <code class='inline-code'>-1</code> when no match exists. <code class='inline-code'>Array.Sort</code> and <code class='inline-code'>Array.Reverse</code> modify the original array rather than producing a separate result."
                                },
                                new Paragraph
                                {
                                    Body = "Always ask whether changing the original order is acceptable before sorting or reversing an array. If the order has meaning, make a copy first."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Multidimensional and Jagged Arrays",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Most arrays in everyday application code are one-dimensional, but C# also supports rectangular multidimensional arrays. A two-dimensional array uses two indexes, often visualised as rows and columns:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "string[,] shelfLocations =\r\n{\r\n    { \"A1\", \"A2\", \"A3\" },\r\n    { \"B1\", \"B2\", \"B3\" }\r\n};\r\n\r\nConsole.WriteLine(shelfLocations[0, 1]); // A2\r\nConsole.WriteLine(shelfLocations[1, 2]); // B3"
                                },
                                new Paragraph
                                {
                                    Body = "A <b>jagged array</b> is an array whose elements are themselves arrays. Each inner array can have a different length:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "string[][] productsByAisle =\r\n[\r\n    [\"Coffee\", \"Tea\"],\r\n    [\"Bread\", \"Rice\", \"Pasta\"],\r\n    [\"Soap\"]\r\n];\r\n\r\nConsole.WriteLine(productsByAisle[1][2]); // Pasta"
                                },
                                new Paragraph
                                {
                                    Body = "You should recognise both forms, but our department feature needs only a simple one-dimensional array. Choose additional dimensions only when the data genuinely has a grid or nested shape."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "When Should You Use an Array?",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "An array is a good choice when:"
                                },
                                new Paragraph
                                {
                                    Body = RedDotList(
                                        "You know the number of elements when the array is created.",
                                        "That number will not change while the array is being used.",
                                        "The values share one element type.",
                                        "Their order matters or you need to access them by position.",
                                        "A simple, direct collection is preferable to a growable one.")
                                },
                                new Paragraph
                                {
                                    Body = "An array is usually not the best choice when the collection needs frequent additions or removals, when each value needs a meaningful lookup key, or when duplicate values must be prevented automatically. The later chapters will introduce collections designed for those needs."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Application: Store the Departments",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "The store's five departments are known in advance and remain fixed. We want to preserve their display order and visit every department when building the table. An array fits all of these requirements."
                                },
                                new Paragraph
                                {
                                    Body = "Open <code class='inline-code'>StoreApp.cs</code>. At the beginning of the <code class='inline-code'>StoreApp</code> class, add this field:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static readonly string[] Departments =\r\n[\r\n    \"Electronics\",\r\n    \"Groceries\",\r\n    \"Clothing\",\r\n    \"Home\",\r\n    \"Sports\"\r\n];"
                                },
                                new Paragraph
                                {
                                    Body = "The field is <code class='inline-code'>static</code> because the same departments belong to the application rather than to an individual object. It is <code class='inline-code'>readonly</code> so the field cannot later be assigned a different array. Remember that <code class='inline-code'>readonly</code> protects the field reference; it does not make the array's individual elements immutable."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Display the Department Array",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Replace <code class='inline-code'>ShowDepartmentsPlaceholder</code> with a method named <code class='inline-code'>ShowDepartments</code>:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static void ShowDepartments()\r\n{\r\n    AnsiConsole.Clear();\r\n\r\n    var table = new Table()\r\n        .Title(\"[green]Store Departments[/]\")\r\n        .AddColumn(\"Number\")\r\n        .AddColumn(\"Department\");\r\n\r\n    for (int index = 0; index < Departments.Length; index++)\r\n    {\r\n        table.AddRow(\r\n            (index + 1).ToString(),\r\n            Markup.Escape(Departments[index]));\r\n    }\r\n\r\n    AnsiConsole.Write(table);\r\n    AnsiConsole.MarkupLine(\"[grey]Press any key to return to the menu...[/]\");\r\n    Console.ReadKey(intercept: true);\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "This loop connects the theory to the feature. <code class='inline-code'>Departments.Length</code> controls how many rows we create, <code class='inline-code'>Departments[index]</code> retrieves each department, and <code class='inline-code'>index + 1</code> gives the user a friendly number beginning at one."
                                },
                                new Paragraph
                                {
                                    Body = "<code class='inline-code'>Markup.Escape</code> belongs to Spectre.Console. It prevents special markup characters inside a department name from being treated as formatting. It is display code, not part of the array behaviour you need to learn."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Connect the Menu Option",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Update the <code class='inline-code'>View Departments</code> case in the menu switch so it calls the completed method:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "case \"View Departments\":\r\n    ShowDepartments();\r\n    break;"
                                },
                                new Paragraph
                                {
                                    Body = "Run the application and select <b>View Departments</b>. You should now see all five departments in their original array order. The placeholder has become the first working store feature."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Exercises",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Complete these exercises before moving on:"
                                },
                                new Paragraph
                                {
                                    Body = ExerciseList(
                                        "Print the first department and the last department without writing their numeric indexes directly. Use <code class='inline-code'>0</code> for the first and <code class='inline-code'>^1</code> for the last.",
                                        "Temporarily change one department through its index and confirm that the array length stays the same.",
                                        "Use <code class='inline-code'>Array.IndexOf</code> to find the position of <code class='inline-code'>Home</code>. Display a friendly one-based department number.",
                                        "Create an independent copy of the department array with <code class='inline-code'>Array.Copy</code>. Sort the copy and confirm that the original display order has not changed.",
                                        "Replace the application's <code class='inline-code'>for</code> loop with <code class='inline-code'>foreach</code>. What information do you lose, and what extra variable would you need to keep the numbered column?",
                                        "Add one more department to the collection expression. Confirm that <code class='inline-code'>Length</code> and the table update without changing the loop.")
                                },
                                new Paragraph
                                {
                                    Body = "Try each exercise yourself before checking the solutions. When you are ready, press the <b>View Source Code</b> button below to see the exercise answers."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Chapter Summary",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = RedDotList(
                                        "Arrays store a fixed number of values of one element type.",
                                        "Indexes begin at zero, and the last valid index is <code class='inline-code'>Length - 1</code>.",
                                        "Array elements can be replaced even though the array's length cannot change.",
                                        "Use <code class='inline-code'>foreach</code> for simple iteration and <code class='inline-code'>for</code> when the index matters.",
                                        "Array variables are references; assigning one to another does not copy the elements.",
                                        "The store departments are a good array because their number and order are fixed.")
                                },
                                new Paragraph
                                {
                                    Body = "The next store feature will manage products. Unlike departments, products must be added, updated, and removed while the application runs. That changing collection will motivate our next data structure: <code class='inline-code'>List&lt;T&gt;</code>."
                                }
                            }
                        },
                        new Block
                        {
                            IsCourseCodePage = true,
                            Title = "Array Exercise Answers",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "These are example solutions, not the only valid answers. Compare them with your work and make sure you understand why each one behaves as it does."
                                },
                                new Paragraph
                                {
                                    Body = "<b>1. Print the first and last departments</b>"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "Console.WriteLine(Departments[0]);\r\nConsole.WriteLine(Departments[^1]);"
                                },
                                new Paragraph
                                {
                                    Body = "Index <code class='inline-code'>0</code> retrieves the first element. The from-end index <code class='inline-code'>^1</code> retrieves the last element regardless of the array's length."
                                },
                                new Paragraph
                                {
                                    Body = "<b>2. Replace an element without changing the length</b>"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "string originalDepartment = Departments[1];\r\n\r\nDepartments[1] = \"Food\";\r\n\r\nConsole.WriteLine(Departments[1]);     // Food\r\nConsole.WriteLine(Departments.Length); // 5\r\n\r\nDepartments[1] = originalDepartment;"
                                },
                                new Paragraph
                                {
                                    Body = "Replacing an element changes the value stored at an existing position. It does not add or remove a position, so <code class='inline-code'>Length</code> remains five. The final line restores the application data for the remaining exercises."
                                },
                                new Paragraph
                                {
                                    Body = "<b>3. Find Home and display a one-based number</b>"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "int homeIndex = Array.IndexOf(Departments, \"Home\");\r\n\r\nif (homeIndex >= 0)\r\n{\r\n    Console.WriteLine($\"Home is department number {homeIndex + 1}.\");\r\n}\r\nelse\r\n{\r\n    Console.WriteLine(\"Home was not found.\");\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "<code class='inline-code'>Array.IndexOf</code> returns <code class='inline-code'>-1</code> when it cannot find a match, so we check the result before using it. The array index is zero-based; adding one produces a user-friendly department number."
                                },
                                new Paragraph
                                {
                                    Body = "<b>4. Copy and sort without changing the original</b>"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "string[] sortedDepartments = new string[Departments.Length];\r\nArray.Copy(Departments, sortedDepartments, Departments.Length);\r\n\r\nArray.Sort(sortedDepartments);\r\n\r\nConsole.WriteLine(\"Sorted copy:\");\r\nforeach (string department in sortedDepartments)\r\n{\r\n    Console.WriteLine(department);\r\n}\r\n\r\nConsole.WriteLine($\"Original first item: {Departments[0]}\");"
                                },
                                new Paragraph
                                {
                                    Body = "<code class='inline-code'>Array.Sort</code> changes the array it receives. Because we pass an independent copy, the application keeps the original department order. Assigning <code class='inline-code'>string[] sortedDepartments = Departments</code> would not work because both variables would refer to the same array."
                                },
                                new Paragraph
                                {
                                    Body = "<b>5. Use foreach while keeping display numbers</b>"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "int displayNumber = 1;\r\n\r\nforeach (string department in Departments)\r\n{\r\n    table.AddRow(\r\n        displayNumber.ToString(),\r\n        Markup.Escape(department));\r\n\r\n    displayNumber++;\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "A <code class='inline-code'>foreach</code> loop gives us each value but not its array index. We introduce <code class='inline-code'>displayNumber</code> and increment it manually. The original <code class='inline-code'>for</code> loop is slightly more natural here because the table needs a number for every row."
                                },
                                new Paragraph
                                {
                                    Body = "<b>6. Add another department</b>"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static readonly string[] Departments =\r\n[\r\n    \"Electronics\",\r\n    \"Groceries\",\r\n    \"Clothing\",\r\n    \"Home\",\r\n    \"Sports\",\r\n    \"Garden\"\r\n];"
                                },
                                new Paragraph
                                {
                                    Body = "The array is now created with six positions, so <code class='inline-code'>Departments.Length</code> returns six. The display loop already depends on <code class='inline-code'>Length</code>, which means it automatically includes the new element without any other changes."
                                }
                            }
                        }
                    }
                },
                new Article
                {
                    Id = 500305,
                    CourseDisplayId = 6,
                    Title = "List<T> Fundamentals",
                    Slug = "data-structures-list-t",
                    Description = "Learn how List<T> manages ordered collections that can grow and shrink.",
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
                                    Body = "Our store departments work well in an array because their number is fixed. Products are different. While the application runs, users need to add products, update them, and eventually remove them."
                                },
                                new Paragraph
                                {
                                    Body = "We could create a larger array and manually copy elements whenever the collection changes, but that would add repetitive bookkeeping to a common task. .NET provides a collection designed for this situation: <code class='inline-code'>List&lt;T&gt;</code>."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "What Is List<T>?",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "<code class='inline-code'>List&lt;T&gt;</code> is an ordered, generic collection whose size can change. The <code class='inline-code'>T</code> is a type parameter. When we create a <code class='inline-code'>List&lt;string&gt;</code>, every element is a string. A <code class='inline-code'>List&lt;Product&gt;</code> stores Product objects."
                                },
                                new Paragraph
                                {
                                    Body = RedDotList(
                                        "A list keeps its elements in a defined order.",
                                        "It uses zero-based indexes like an array.",
                                        "Elements can be added, inserted, replaced, and removed.",
                                        "Its <code class='inline-code'>Count</code> changes as elements are added or removed.",
                                        "Its generic element type gives compile-time type safety.")
                                },
                                new Paragraph
                                {
                                    Body = "Internally, <code class='inline-code'>List&lt;T&gt;</code> uses an array-like storage area. When that storage becomes full, the list creates a larger area and moves its elements. The collection handles this process for us, which gives us convenient growth while preserving indexed access."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Creating Lists",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Create an empty list when the values will arrive later:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "var products = new List<string>();"
                                },
                                new Paragraph
                                {
                                    Body = "When values are already known, initialise the list with a collection expression:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "List<string> products =\r\n[\r\n    \"Wireless Mouse\",\r\n    \"Coffee Beans\",\r\n    \"Running Shoes\"\r\n];"
                                },
                                new Paragraph
                                {
                                    Body = "The explicit type on the left tells the compiler to create a list from the collection expression. Using <code class='inline-code'>var products = [ ... ]</code> does not provide enough information for the compiler to determine the collection type."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Count and Capacity",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "A list has two related measurements. <code class='inline-code'>Count</code> is the number of elements currently in the list. <code class='inline-code'>Capacity</code> is the number of elements its internal storage can currently hold before it needs to grow."
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "var products = new List<string>();\r\n\r\nproducts.Add(\"Wireless Mouse\");\r\nproducts.Add(\"Coffee Beans\");\r\n\r\nConsole.WriteLine(products.Count);    // 2\r\nConsole.WriteLine(products.Capacity); // At least 2"
                                },
                                new Paragraph
                                {
                                    Body = "Most application code should make decisions using <code class='inline-code'>Count</code>. Capacity is an implementation detail that can occasionally help when you already know a collection will become large, but you should not treat it as the number of meaningful elements."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Adding and Inserting Elements",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "<code class='inline-code'>Add</code> places one element at the end. <code class='inline-code'>AddRange</code> appends several elements. <code class='inline-code'>Insert</code> places an element at a particular index and shifts later elements to make space."
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "var products = new List<string>();\r\n\r\nproducts.Add(\"Wireless Mouse\");\r\nproducts.AddRange([\"Coffee Beans\", \"Running Shoes\"]);\r\nproducts.Insert(1, \"Desk Lamp\");\r\n\r\n// Wireless Mouse, Desk Lamp, Coffee Beans, Running Shoes"
                                },
                                new Paragraph
                                {
                                    Body = "Use <code class='inline-code'>Insert</code> only when a specific position matters. If order is not important, adding at the end communicates the intention more clearly. An invalid insertion index throws <code class='inline-code'>ArgumentOutOfRangeException</code>."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Reading and Updating Elements",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Lists use the same index syntax as arrays. Valid indexes run from zero to <code class='inline-code'>Count - 1</code>:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "List<string> products = [\"Mouse\", \"Coffee\", \"Shoes\"];\r\n\r\nConsole.WriteLine(products[0]);  // Mouse\r\nConsole.WriteLine(products[^1]); // Shoes\r\n\r\nproducts[0] = \"Wireless Mouse\";"
                                },
                                new Paragraph
                                {
                                    Body = "The index changes an existing position; it does not add a new one. Writing <code class='inline-code'>products[3] = \"Lamp\"</code> when the count is three throws an exception. Use <code class='inline-code'>Add</code> to create a new element."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Finding Elements",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Lists provide methods for common searches. <code class='inline-code'>Contains</code> checks for a value, <code class='inline-code'>IndexOf</code> returns its position, <code class='inline-code'>Exists</code> checks whether any element matches a condition, and <code class='inline-code'>Find</code> returns the first match."
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "List<string> products = [\"Mouse\", \"Coffee\", \"Shoes\"];\r\n\r\nbool hasCoffee = products.Contains(\"Coffee\");\r\nint shoesIndex = products.IndexOf(\"Shoes\");\r\nbool hasLongName = products.Exists(name => name.Length > 5);\r\nstring? firstWithS = products.Find(name => name.StartsWith('S'));"
                                },
                                new Paragraph
                                {
                                    Body = "A predicate such as <code class='inline-code'>name => name.Length > 5</code> is a function that returns true or false for each candidate. <code class='inline-code'>Find</code> returns the element type's default value when there is no match, so reference-type results should be checked for <code class='inline-code'>null</code>."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Removing Elements",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Lists support several forms of removal:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "List<string> products = [\"Mouse\", \"Coffee\", \"Shoes\", \"Coffee\"];\r\n\r\nbool removed = products.Remove(\"Coffee\"); // Removes the first match\r\nproducts.RemoveAt(0);                        // Removes by index\r\nint removedCount = products.RemoveAll(name => name == \"Coffee\");\r\nproducts.Clear();                            // Removes everything"
                                },
                                new Paragraph
                                {
                                    Body = "<code class='inline-code'>Remove</code> returns false when it cannot find the value. <code class='inline-code'>RemoveAt</code> throws when the index is invalid. <code class='inline-code'>RemoveAll</code> returns the number of matching elements removed."
                                },
                                new Paragraph
                                {
                                    Body = "We will not add product removal to the store yet. A later chapter will combine removal with <code class='inline-code'>Stack&lt;T&gt;</code> so the user can undo the most recent removal."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Iteration and Sorting",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Use <code class='inline-code'>foreach</code> when you need each element and <code class='inline-code'>for</code> when the index matters. Do not add or remove elements inside a <code class='inline-code'>foreach</code> loop; changing the collection while it is being enumerated causes an exception."
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "foreach (string product in products)\r\n{\r\n    Console.WriteLine(product);\r\n}\r\n\r\nproducts.Sort();\r\nproducts.Reverse();"
                                },
                                new Paragraph
                                {
                                    Body = "<code class='inline-code'>Sort</code> and <code class='inline-code'>Reverse</code> mutate the original list. Custom objects need a comparison rule. For example, <code class='inline-code'>products.Sort((left, right) => left.Name.CompareTo(right.Name))</code> sorts Product objects by name."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Array or List?",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = RedDotList(
                                        "Choose an <b>array</b> when the number of elements is fixed and indexed storage is the clearest representation.",
                                        "Choose <code class='inline-code'>List&lt;T&gt;</code> when elements need to be added or removed while the collection is in use.",
                                        "Both collections are ordered, zero-indexed, generic, iterable, and allow duplicate values.",
                                        "Neither structure automatically provides meaningful key-based lookup or uniqueness rules. Later chapters introduce collections for those requirements.")
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Chapter Summary",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = RedDotList(
                                        "<code class='inline-code'>List&lt;T&gt;</code> is an ordered, zero-indexed collection that can grow and shrink.",
                                        "<code class='inline-code'>Count</code> is the number of meaningful elements; Capacity describes internal storage.",
                                        "Use <code class='inline-code'>Add</code>, <code class='inline-code'>Insert</code>, and the removal methods to change the collection.",
                                        "Use indexes, iteration, <code class='inline-code'>Exists</code>, and <code class='inline-code'>Find</code> to work with its elements.",
                                        "Choose a list when the number of elements will change while the collection is in use.")
                                },
                                new Paragraph
                                {
                                    Body = "Now that you understand the collection itself, the next chapter will apply <code class='inline-code'>List&lt;T&gt;</code> to the Store Management System's changing product collection."
                                }
                            }
                        },
                    }
                },
                new Article
                {
                    Id = 500306,
                    CourseDisplayId = 7,
                    Title = "Applying List<T>: Product Management",
                    Slug = "apply-list-t-product-management",
                    Description = "Create the Product model and use List<Product> to view, add, and update store products.",
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
                                    Body = "In the previous chapter, you learned how <code class='inline-code'>List&lt;T&gt;</code> represents an ordered collection that can grow and shrink. Now we will apply that knowledge to the Store Management System."
                                },
                                new Paragraph
                                {
                                    Body = "Products are a good fit for a list because users need to add and update them while the application is running. By the end of this chapter, the store will have a complete product-management menu built around <code class='inline-code'>List&lt;Product&gt;</code>."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Application: Create the Product Model",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Create a <code class='inline-code'>Models</code> folder in the project, then create <code class='inline-code'>Product.cs</code>:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "namespace TCSA.Study.DataStructures.Models;\r\n\r\npublic sealed class Product\r\n{\r\n    public required string Name { get; set; }\r\n    public required string Sku { get; init; }\r\n    public decimal Price { get; set; }\r\n    public required string Department { get; set; }\r\n    public int StockQuantity { get; set; }\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "A product's SKU identifies it, so this version makes <code class='inline-code'>Sku</code> init-only. The other values may change when a user updates a product. The <code class='inline-code'>required</code> modifier makes callers provide the essential string values when creating an object."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Create the Product List",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Add the model namespace at the top of <code class='inline-code'>StoreApp.cs</code>:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "using TCSA.Study.DataStructures.Models;"
                                },
                                new Paragraph
                                {
                                    Body = "Then add a list field below the department array:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static readonly List<Product> Products =\r\n[\r\n    new Product\r\n    {\r\n        Name = \"Wireless Mouse\",\r\n        Sku = \"ELE-001\",\r\n        Price = 29.99m,\r\n        Department = \"Electronics\",\r\n        StockQuantity = 12\r\n    },\r\n    new Product\r\n    {\r\n        Name = \"Coffee Beans\",\r\n        Sku = \"GRO-004\",\r\n        Price = 14.50m,\r\n        Department = \"Groceries\",\r\n        StockQuantity = 20\r\n    }\r\n];"
                                },
                                new Paragraph
                                {
                                    Body = "The field is readonly, which prevents assigning a different list to <code class='inline-code'>Products</code>. The list itself remains mutable, so the application can still call <code class='inline-code'>Add</code> and update its Product objects."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Add Product Management to the Main Menu",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Add <code class='inline-code'>Manage Products</code> between the existing menu choices:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = ".AddChoices(\r\n    \"View Departments\",\r\n    \"Manage Products\",\r\n    \"Exit\"));"
                                },
                                new Paragraph
                                {
                                    Body = "Add the corresponding switch case:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "case \"Manage Products\":\r\n    ShowProductMenu();\r\n    break;"
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Build the Product Menu",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static void ShowProductMenu()\r\n{\r\n    bool returnToMainMenu = false;\r\n\r\n    while (!returnToMainMenu)\r\n    {\r\n        AnsiConsole.Clear();\r\n\r\n        string choice = AnsiConsole.Prompt(\r\n            new SelectionPrompt<string>()\r\n                .Title(\"[green]Product Management[/]\")\r\n                .AddChoices(\r\n                    \"View All Products\",\r\n                    \"Add Product\",\r\n                    \"Update Product\",\r\n                    \"Return to Main Menu\"));\r\n\r\n        switch (choice)\r\n        {\r\n            case \"View All Products\":\r\n                ShowProducts();\r\n                break;\r\n            case \"Add Product\":\r\n                AddProduct();\r\n                break;\r\n            case \"Update Product\":\r\n                UpdateProduct();\r\n                break;\r\n            case \"Return to Main Menu\":\r\n                returnToMainMenu = true;\r\n                break;\r\n        }\r\n    }\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "The nested menu has its own loop. Returning changes its boolean flag, exits the loop, and gives control back to the main menu."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Display Every Product",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static void ShowProducts()\r\n{\r\n    AnsiConsole.Clear();\r\n\r\n    var table = new Table()\r\n        .Title(\"[green]Products[/]\")\r\n        .AddColumn(\"SKU\")\r\n        .AddColumn(\"Name\")\r\n        .AddColumn(\"Department\")\r\n        .AddColumn(\"Price\")\r\n        .AddColumn(\"Stock\");\r\n\r\n    foreach (Product product in Products)\r\n    {\r\n        table.AddRow(\r\n            Markup.Escape(product.Sku),\r\n            Markup.Escape(product.Name),\r\n            Markup.Escape(product.Department),\r\n            product.Price.ToString(\"C\"),\r\n            product.StockQuantity.ToString());\r\n    }\r\n\r\n    AnsiConsole.Write(table);\r\n    Pause();\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "The <code class='inline-code'>foreach</code> loop visits every Product in the list. It does not need an index because each table row is built entirely from the current object."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Add a Product",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static void AddProduct()\r\n{\r\n    AnsiConsole.Clear();\r\n\r\n    string sku = AnsiConsole.Ask<string>(\"SKU:\").Trim().ToUpperInvariant();\r\n\r\n    if (Products.Exists(product => product.Sku == sku))\r\n    {\r\n        AnsiConsole.MarkupLine($\"[red]A product with SKU {Markup.Escape(sku)} already exists.[/]\");\r\n        Pause();\r\n        return;\r\n    }\r\n\r\n    string name = AnsiConsole.Ask<string>(\"Name:\").Trim();\r\n    string department = AnsiConsole.Prompt(\r\n        new SelectionPrompt<string>()\r\n            .Title(\"Department:\")\r\n            .AddChoices(Departments));\r\n    decimal price = AnsiConsole.Ask<decimal>(\"Price:\");\r\n    int stockQuantity = AnsiConsole.Ask<int>(\"Stock quantity:\");\r\n\r\n    Products.Add(new Product\r\n    {\r\n        Name = name,\r\n        Sku = sku,\r\n        Price = price,\r\n        Department = department,\r\n        StockQuantity = stockQuantity\r\n    });\r\n\r\n    AnsiConsole.MarkupLine(\"[green]Product added successfully.[/]\");\r\n    Pause();\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "<code class='inline-code'>Exists</code> prevents duplicate SKUs for now, and <code class='inline-code'>Add</code> grows the product list. In the Dictionary chapter, we will model SKU lookup more directly."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Update a Product",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static void UpdateProduct()\r\n{\r\n    AnsiConsole.Clear();\r\n\r\n    if (Products.Count == 0)\r\n    {\r\n        AnsiConsole.MarkupLine(\"[yellow]There are no products to update.[/]\");\r\n        Pause();\r\n        return;\r\n    }\r\n\r\n    string selectedSku = AnsiConsole.Prompt(\r\n        new SelectionPrompt<string>()\r\n            .Title(\"Choose a product:\")\r\n            .AddChoices(Products.Select(product => product.Sku)));\r\n\r\n    Product product = Products.Find(product => product.Sku == selectedSku)!;\r\n\r\n    product.Name = AnsiConsole.Ask(\"Name:\", product.Name);\r\n    product.Department = AnsiConsole.Prompt(\r\n        new SelectionPrompt<string>()\r\n            .Title(\"Department:\")\r\n            .AddChoices(Departments));\r\n    product.Price = AnsiConsole.Ask(\"Price:\", product.Price);\r\n    product.StockQuantity = AnsiConsole.Ask(\"Stock quantity:\", product.StockQuantity);\r\n\r\n    AnsiConsole.MarkupLine(\"[green]Product updated successfully.[/]\");\r\n    Pause();\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "The prompt is created from the current list of SKUs. Because the user must select one of those values, <code class='inline-code'>Find</code> should return a Product. The null-forgiving operator communicates that guarantee to the compiler. In code where the value comes from unrestricted input, use a null check instead."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Add a Shared Pause Method",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "The product methods all pause before returning. Add this helper and update <code class='inline-code'>ShowDepartments</code> to call it as well:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static void Pause()\r\n{\r\n    AnsiConsole.MarkupLine(\"[grey]Press any key to return...[/]\");\r\n    Console.ReadKey(intercept: true);\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "This helper is presentation code. It removes repetition but is not part of <code class='inline-code'>List&lt;T&gt;</code>."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Exercises",
                            CssClass = ExerciseBlockClass,
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = ExerciseList(
                                        "Create an empty <code class='inline-code'>List&lt;int&gt;</code>, add five numbers, and print its <code class='inline-code'>Count</code> after every addition.",
                                        "Insert a number at index <code class='inline-code'>1</code>, then print every element with its index.",
                                        "Remove one number by value and another by index. Print the boolean returned by <code class='inline-code'>Remove</code>.",
                                        "Use <code class='inline-code'>Exists</code> to check whether the product list contains an item with zero stock.",
                                        "Use <code class='inline-code'>Find</code> to retrieve the first Electronics product and handle the case where none exists.",
                                        "Create a separate list containing the product names, sort it, and print the names without changing the Product list.",
                                        "Add validation so product price and stock quantity cannot be negative.",
                                        "Add a <code class='inline-code'>View Products By Department</code> option that asks for a department and displays only matching products.")
                                },
                                new Paragraph
                                {
                                    Body = "Try every exercise before checking the solutions. When you are ready, press the <b>View Source Code</b> button below to see example answers."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Application Summary",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = RedDotList(
                                        "The store now represents each product with a dedicated <code class='inline-code'>Product</code> model.",
                                        "A <code class='inline-code'>List&lt;Product&gt;</code> holds the changing product collection.",
                                        "The product menu can display, add, and update Product objects.",
                                        "<code class='inline-code'>Exists</code> currently prevents duplicate SKUs, while <code class='inline-code'>Find</code> retrieves the selected product.",
                                        "Shared display helpers keep repeated Spectre.Console code out of the collection logic.")
                                },
                                new Paragraph
                                {
                                    Body = "The list can find a Product by SKU, but it must inspect products until it finds a match. The next chapter introduces <code class='inline-code'>Dictionary&lt;TKey, TValue&gt;</code>, which models meaningful key-based lookup directly."
                                }
                            }
                        },
                        new Block
                        {
                            IsCourseCodePage = true,
                            Title = "Product Management Exercise Answers",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph { Body = "These are example answers. Your structure and variable names may differ." },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "// 1. Add numbers and print Count\r\nvar numbers = new List<int>();\r\nforeach (int number in new[] { 10, 20, 30, 40, 50 })\r\n{\r\n    numbers.Add(number);\r\n    Console.WriteLine(numbers.Count);\r\n}\r\n\r\n// 2. Insert and print indexes\r\nnumbers.Insert(1, 15);\r\nfor (int index = 0; index < numbers.Count; index++)\r\n{\r\n    Console.WriteLine($\"{index}: {numbers[index]}\");\r\n}\r\n\r\n// 3. Remove by value and index\r\nbool removed = numbers.Remove(30);\r\nConsole.WriteLine(removed);\r\nnumbers.RemoveAt(0);\r\n\r\n// 4. Check for zero stock\r\nbool hasOutOfStockProduct = Products\r\n    .Exists(product => product.StockQuantity == 0);\r\n\r\n// 5. Find an Electronics product\r\nProduct? electronicsProduct = Products\r\n    .Find(product => product.Department == \"Electronics\");\r\n\r\nif (electronicsProduct is null)\r\n{\r\n    Console.WriteLine(\"No Electronics product was found.\");\r\n}\r\nelse\r\n{\r\n    Console.WriteLine(electronicsProduct.Name);\r\n}\r\n\r\n// 6. Sort a separate list of names\r\nList<string> productNames = Products\r\n    .Select(product => product.Name)\r\n    .ToList();\r\nproductNames.Sort();\r\n\r\nforeach (string productName in productNames)\r\n{\r\n    Console.WriteLine(productName);\r\n}"
                                },
                                new Paragraph { Body = "<b>7. Validate non-negative values</b>" },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "decimal price = AnsiConsole.Prompt(\r\n    new TextPrompt<decimal>(\"Price:\")\r\n        .Validate(value => value >= 0\r\n            ? ValidationResult.Success()\r\n            : ValidationResult.Error(\"[red]Price cannot be negative.[/]\")));\r\n\r\nint stockQuantity = AnsiConsole.Prompt(\r\n    new TextPrompt<int>(\"Stock quantity:\")\r\n        .Validate(value => value >= 0\r\n            ? ValidationResult.Success()\r\n            : ValidationResult.Error(\"[red]Stock cannot be negative.[/]\")));"
                                },
                                new Paragraph { Body = "<b>8. View products by department</b>" },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static void ShowProductsByDepartment()\r\n{\r\n    string department = AnsiConsole.Prompt(\r\n        new SelectionPrompt<string>()\r\n            .Title(\"Choose a department:\")\r\n            .AddChoices(Departments));\r\n\r\n    List<Product> matchingProducts = Products\r\n        .Where(product => product.Department == department)\r\n        .ToList();\r\n\r\n    foreach (Product product in matchingProducts)\r\n    {\r\n        AnsiConsole.MarkupLine(Markup.Escape(product.Name));\r\n    }\r\n\r\n    Pause();\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "Add <code class='inline-code'>View Products By Department</code> to the product menu and call <code class='inline-code'>ShowProductsByDepartment</code> from its switch case."
                                }
                            }
                        }
                    }
                }
            }
        };
    }
}
