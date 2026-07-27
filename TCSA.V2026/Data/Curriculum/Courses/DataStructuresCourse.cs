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
                                    Body = "Big O notation, complexity analysis, linked lists, trees, heaps, graphs, and advanced algorithms belong in a future <b>Data Structures and Algorithms</b> course. You do not need that knowledge to begin this course."
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
                                },
                                new Paragraph
                                {
                                    Body = "This course also uses small LINQ expressions to select, filter, sort, and transform collection data. Those expressions support the Store Management System, but LINQ itself is not taught here. If methods such as <code class='inline-code'>Select</code>, <code class='inline-code'>Where</code>, <code class='inline-code'>OrderBy</code>, or <code class='inline-code'>ToDictionary</code> are unfamiliar, complete the <a href='/course/8/article/1/500249/false' target='_blank'>LINQ Fundamentals course</a> first."
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
                                    Body = "using Spectre.Console;\r\n\r\nnamespace TCSA.Study.DataStructures;\r\n\r\npublic sealed class StoreApp\r\n{\r\n    public void Run()\r\n    {\r\n        bool isRunning = true;\r\n\r\n        while (isRunning)\r\n        {\r\n            AnsiConsole.Clear();\r\n            DisplayTitle();\r\n\r\n            string choice = AnsiConsole.Prompt(\r\n                new SelectionPrompt&lt;string&gt;()\r\n                    .Title(\"What would you like to do?\")\r\n                    .PageSize(5)\r\n                    .AddChoices(\r\n                        \"View Departments\",\r\n                        \"Exit\"));\r\n\r\n            switch (choice)\r\n            {\r\n                case \"View Departments\":\r\n                    ShowDepartmentsPlaceholder();\r\n                    break;\r\n                case \"Exit\":\r\n                    isRunning = false;\r\n                    break;\r\n            }\r\n        }\r\n    }\r\n\r\n    private static void DisplayTitle()\r\n    {\r\n        AnsiConsole.Write(\r\n            new FigletText(\"Store Management\")\r\n                .Centered()\r\n                .Color(Color.Green));\r\n    }\r\n\r\n    private static void ShowDepartmentsPlaceholder()\r\n    {\r\n        AnsiConsole.Clear();\r\n        AnsiConsole.MarkupLine(\"[yellow]Departments haven't been implemented yet.[/]\");\r\n        AnsiConsole.MarkupLine(\"[grey]Press any key to return to the menu...[/]\");\r\n        Console.ReadKey(intercept: true);\r\n    }\r\n}"
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
                                    Body = "for (int index = 0; index &lt; departments.Length; index++)\r\n{\r\n    Console.WriteLine($\"{index + 1}. {departments[index]}\");\r\n}"
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
                                    Body = "private static void ShowDepartments()\r\n{\r\n    AnsiConsole.Clear();\r\n\r\n    var table = new Table()\r\n        .Title(\"[green]Store Departments[/]\")\r\n        .AddColumn(\"Number\")\r\n        .AddColumn(\"Department\");\r\n\r\n    for (int index = 0; index &lt; Departments.Length; index++)\r\n    {\r\n        table.AddRow(\r\n            (index + 1).ToString(),\r\n            Markup.Escape(Departments[index]));\r\n    }\r\n\r\n    AnsiConsole.Write(table);\r\n    AnsiConsole.MarkupLine(\"[grey]Press any key to return to the menu...[/]\");\r\n    Console.ReadKey(intercept: true);\r\n}"
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
                                        "Print the first department with index <code class='inline-code'>0</code> and the last department with <code class='inline-code'>^1</code> instead of calculating the final index with <code class='inline-code'>Length - 1</code>.",
                                        "Temporarily change one department through its index and confirm that the array length stays the same.",
                                        "Use <code class='inline-code'>Array.IndexOf</code> to find the position of <code class='inline-code'>Home</code>. Display a friendly one-based department number.",
                                        "Create an independent copy of the department array with <code class='inline-code'>Array.Copy</code>. Sort the copy and confirm that the original display order has not changed.",
                                        "Replace the application's <code class='inline-code'>for</code> loop with <code class='inline-code'>foreach</code>. What information do you lose, and what extra variable would you need to keep the numbered column?",
                                        "Add one more department to the collection expression. Confirm that <code class='inline-code'>Length</code> and the table update without changing the loop.")
                                },
                                new Paragraph
                                {
                                    Body = "Complete the exercises inside the Store Management System by adding a temporary practice method or menu option. Run the app, verify the behavior, and then delete any exercise-only code before continuing the course project. When you are ready, press the <b>View Source Code</b> button below to see example answers."
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
                                    Body = "int homeIndex = Array.IndexOf(Departments, \"Home\");\r\n\r\nif (homeIndex &gt;= 0)\r\n{\r\n    Console.WriteLine($\"Home is department number {homeIndex + 1}.\");\r\n}\r\nelse\r\n{\r\n    Console.WriteLine(\"Home was not found.\");\r\n}"
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
                                    Body = "var products = new List&lt;string&gt;();"
                                },
                                new Paragraph
                                {
                                    Body = "When values are already known, initialise the list with a collection expression:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "List&lt;string&gt; products =\r\n[\r\n    \"Wireless Mouse\",\r\n    \"Coffee Beans\",\r\n    \"Running Shoes\"\r\n];"
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
                                    Body = "var products = new List&lt;string&gt;();\r\n\r\nproducts.Add(\"Wireless Mouse\");\r\nproducts.Add(\"Coffee Beans\");\r\n\r\nConsole.WriteLine(products.Count);    // 2\r\nConsole.WriteLine(products.Capacity); // At least 2"
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
                                    Body = "var products = new List&lt;string&gt;();\r\n\r\nproducts.Add(\"Wireless Mouse\");\r\nproducts.AddRange([\"Coffee Beans\", \"Running Shoes\"]);\r\nproducts.Insert(1, \"Desk Lamp\");\r\n\r\n// Wireless Mouse, Desk Lamp, Coffee Beans, Running Shoes"
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
                                    Body = "List&lt;string&gt; products = [\"Mouse\", \"Coffee\", \"Shoes\"];\r\n\r\nConsole.WriteLine(products[0]);  // Mouse\r\nConsole.WriteLine(products[^1]); // Shoes\r\n\r\nproducts[0] = \"Wireless Mouse\";"
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
                                    Body = "List&lt;string&gt; products = [\"Mouse\", \"Coffee\", \"Shoes\"];\r\n\r\nbool hasCoffee = products.Contains(\"Coffee\");\r\nint shoesIndex = products.IndexOf(\"Shoes\");\r\nbool hasLongName = products.Exists(name =&gt; name.Length &gt; 5);\r\nstring? firstWithS = products.Find(name =&gt; name.StartsWith('S'));"
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
                                    Body = "List&lt;string&gt; products = [\"Mouse\", \"Coffee\", \"Shoes\", \"Coffee\"];\r\n\r\nbool removed = products.Remove(\"Coffee\"); // Removes the first match\r\nproducts.RemoveAt(0);                        // Removes by index\r\nint removedCount = products.RemoveAll(name =&gt; name == \"Coffee\");\r\nproducts.Clear();                            // Removes everything"
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
                    Title = "Applying List<T>",
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
                                    Body = "private static readonly List&lt;Product&gt; Products =\r\n[\r\n    new Product\r\n    {\r\n        Name = \"Wireless Mouse\",\r\n        Sku = \"ELE-001\",\r\n        Price = 29.99m,\r\n        Department = \"Electronics\",\r\n        StockQuantity = 12\r\n    },\r\n    new Product\r\n    {\r\n        Name = \"Coffee Beans\",\r\n        Sku = \"GRO-004\",\r\n        Price = 14.50m,\r\n        Department = \"Groceries\",\r\n        StockQuantity = 20\r\n    }\r\n];"
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
                                    Body = "private static void ShowProductMenu()\r\n{\r\n    bool returnToMainMenu = false;\r\n\r\n    while (!returnToMainMenu)\r\n    {\r\n        AnsiConsole.Clear();\r\n\r\n        string choice = AnsiConsole.Prompt(\r\n            new SelectionPrompt&lt;string&gt;()\r\n                .Title(\"[green]Product Management[/]\")\r\n                .AddChoices(\r\n                    \"View All Products\",\r\n                    \"Add Product\",\r\n                    \"Update Product\",\r\n                    \"Return to Main Menu\"));\r\n\r\n        switch (choice)\r\n        {\r\n            case \"View All Products\":\r\n                ShowProducts();\r\n                break;\r\n            case \"Add Product\":\r\n                AddProduct();\r\n                break;\r\n            case \"Update Product\":\r\n                UpdateProduct();\r\n                break;\r\n            case \"Return to Main Menu\":\r\n                returnToMainMenu = true;\r\n                break;\r\n        }\r\n    }\r\n}"
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
                                    Body = "private static void AddProduct()\r\n{\r\n    AnsiConsole.Clear();\r\n\r\n    string sku = AnsiConsole.Prompt(\r\n        new TextPrompt&lt;string&gt;(\"SKU:\")\r\n            .Validate(value =&gt; !string.IsNullOrWhiteSpace(value)\r\n                ? ValidationResult.Success()\r\n                : ValidationResult.Error(\"[red]SKU is required.[/]\")))\r\n        .Trim()\r\n        .ToUpperInvariant();\r\n\r\n    if (Products.Exists(product =&gt; product.Sku == sku))\r\n    {\r\n        AnsiConsole.MarkupLine($\"[red]A product with SKU {Markup.Escape(sku)} already exists.[/]\");\r\n        Pause();\r\n        return;\r\n    }\r\n\r\n    string name = AnsiConsole.Prompt(\r\n        new TextPrompt&lt;string&gt;(\"Name:\")\r\n            .Validate(value =&gt; !string.IsNullOrWhiteSpace(value)\r\n                ? ValidationResult.Success()\r\n                : ValidationResult.Error(\"[red]Name is required.[/]\")))\r\n        .Trim();\r\n    string department = AnsiConsole.Prompt(\r\n        new SelectionPrompt&lt;string&gt;()\r\n            .Title(\"Department:\")\r\n            .AddChoices(Departments));\r\n    decimal price = AnsiConsole.Prompt(\r\n        new TextPrompt&lt;decimal&gt;(\"Price:\")\r\n            .Validate(value =&gt; value &gt;= 0\r\n                ? ValidationResult.Success()\r\n                : ValidationResult.Error(\"[red]Price cannot be negative.[/]\")));\r\n    int stockQuantity = AnsiConsole.Prompt(\r\n        new TextPrompt&lt;int&gt;(\"Stock quantity:\")\r\n            .Validate(value =&gt; value &gt;= 0\r\n                ? ValidationResult.Success()\r\n                : ValidationResult.Error(\"[red]Stock cannot be negative.[/]\")));\r\n\r\n    Products.Add(new Product\r\n    {\r\n        Name = name,\r\n        Sku = sku,\r\n        Price = price,\r\n        Department = department,\r\n        StockQuantity = stockQuantity\r\n    });\r\n\r\n    AnsiConsole.MarkupLine(\"[green]Product added successfully.[/]\");\r\n    Pause();\r\n}"
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
                                    Body = "private static void UpdateProduct()\r\n{\r\n    AnsiConsole.Clear();\r\n\r\n    if (Products.Count == 0)\r\n    {\r\n        AnsiConsole.MarkupLine(\"[yellow]There are no products to update.[/]\");\r\n        Pause();\r\n        return;\r\n    }\r\n\r\n    string selectedSku = AnsiConsole.Prompt(\r\n        new SelectionPrompt&lt;string&gt;()\r\n            .Title(\"Choose a product:\")\r\n            .AddChoices(Products.Select(product =&gt; product.Sku)));\r\n\r\n    Product product = Products.Find(product =&gt; product.Sku == selectedSku)!;\r\n\r\n    product.Name = AnsiConsole.Prompt(\r\n        new TextPrompt&lt;string&gt;(\"Name:\")\r\n            .DefaultValue(product.Name)\r\n            .Validate(value =&gt; !string.IsNullOrWhiteSpace(value)\r\n                ? ValidationResult.Success()\r\n                : ValidationResult.Error(\"[red]Name is required.[/]\")))\r\n        .Trim();\r\n    product.Department = AnsiConsole.Prompt(\r\n        new SelectionPrompt&lt;string&gt;()\r\n            .Title(\"Department:\")\r\n            .AddChoices(Departments));\r\n    product.Price = AnsiConsole.Prompt(\r\n        new TextPrompt&lt;decimal&gt;(\"Price:\")\r\n            .DefaultValue(product.Price)\r\n            .Validate(value =&gt; value &gt;= 0\r\n                ? ValidationResult.Success()\r\n                : ValidationResult.Error(\"[red]Price cannot be negative.[/]\")));\r\n    product.StockQuantity = AnsiConsole.Prompt(\r\n        new TextPrompt&lt;int&gt;(\"Stock quantity:\")\r\n            .DefaultValue(product.StockQuantity)\r\n            .Validate(value =&gt; value &gt;= 0\r\n                ? ValidationResult.Success()\r\n                : ValidationResult.Error(\"[red]Stock cannot be negative.[/]\")));\r\n\r\n    AnsiConsole.MarkupLine(\"[green]Product updated successfully.[/]\");\r\n    Pause();\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "The prompt is created from the current list of SKUs. Because the user must select one of those values, <code class='inline-code'>Find</code> should return a Product. The null-forgiving operator communicates that guarantee to the compiler. The text and numeric prompts also preserve the existing values as defaults while rejecting empty names and negative numbers."
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
                                        "Create a temporary copy of the store's <code class='inline-code'>Products</code> list, add a practice Product, and print its <code class='inline-code'>Count</code> before and after the addition.",
                                        "Insert another practice Product at index <code class='inline-code'>1</code>, then print every Product name with its index.",
                                        "Remove one practice Product by value and another by index. Print the boolean returned by <code class='inline-code'>Remove</code>.",
                                        "Use <code class='inline-code'>Exists</code> to check whether the product list contains an item with zero stock.",
                                        "Use <code class='inline-code'>Find</code> to retrieve the first Electronics product and handle the case where none exists.",
                                        "Create a separate list containing the product names, sort it, and print the names without changing the Product list.",
                                        "Add a <code class='inline-code'>View Low Stock Products</code> option that displays Products whose StockQuantity is five or less.",
                                        "Add a <code class='inline-code'>View Products By Department</code> option that asks for a department and displays only matching products.")
                                },
                                new Paragraph
                                {
                                    Body = "Complete the exercises inside the Store Management System by adding a temporary practice method or menu option. Run the app, verify the behavior, and then delete any exercise-only code before continuing the course project. When you are ready, press the <b>View Source Code</b> button below to see example answers."
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
                                    Body = "// Use a copy so these exercises do not change the course project data.\r\nList&lt;Product&gt; practiceProducts = new(Products);\r\n\r\n// 1. Add a practice Product and compare Count\r\nint countBefore = practiceProducts.Count;\r\nvar practiceMouse = new Product\r\n{\r\n    Sku = \"PRACTICE-001\",\r\n    Name = \"Practice Mouse\",\r\n    Department = \"Electronics\",\r\n    Price = 19.99m,\r\n    StockQuantity = 4\r\n};\r\npracticeProducts.Add(practiceMouse);\r\nConsole.WriteLine($\"{countBefore} -&gt; {practiceProducts.Count}\");\r\n\r\n// 2. Insert a Product and print indexes\r\nvar practiceLamp = new Product\r\n{\r\n    Sku = \"PRACTICE-002\",\r\n    Name = \"Practice Lamp\",\r\n    Department = \"Home\",\r\n    Price = 24.50m,\r\n    StockQuantity = 2\r\n};\r\npracticeProducts.Insert(1, practiceLamp);\r\nfor (int index = 0; index &lt; practiceProducts.Count; index++)\r\n{\r\n    Console.WriteLine($\"{index}: {practiceProducts[index].Name}\");\r\n}\r\n\r\n// 3. Remove by value and by index\r\nbool removed = practiceProducts.Remove(practiceMouse);\r\nConsole.WriteLine(removed);\r\npracticeProducts.RemoveAt(1);\r\n\r\n// 4. Check for zero stock\r\nbool hasOutOfStockProduct = Products\r\n    .Exists(product =&gt; product.StockQuantity == 0);\r\n\r\n// 5. Find an Electronics product\r\nProduct? electronicsProduct = Products\r\n    .Find(product =&gt; product.Department == \"Electronics\");\r\n\r\nif (electronicsProduct is null)\r\n{\r\n    Console.WriteLine(\"No Electronics product was found.\");\r\n}\r\nelse\r\n{\r\n    Console.WriteLine(electronicsProduct.Name);\r\n}\r\n\r\n// 6. Sort a separate list of names\r\nList&lt;string&gt; productNames = Products\r\n    .Select(product =&gt; product.Name)\r\n    .ToList();\r\nproductNames.Sort();\r\n\r\nforeach (string productName in productNames)\r\n{\r\n    Console.WriteLine(productName);\r\n}"
                                },
                                new Paragraph { Body = "<b>7. View low-stock Products</b>" },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static void ShowLowStockProducts()\r\n{\r\n    List&lt;Product&gt; lowStockProducts = Products\r\n        .Where(product =&gt; product.StockQuantity &lt;= 5)\r\n        .ToList();\r\n\r\n    if (lowStockProducts.Count == 0)\r\n    {\r\n        AnsiConsole.MarkupLine(\"[green]Every Product has more than five items in stock.[/]\");\r\n        Pause();\r\n        return;\r\n    }\r\n\r\n    foreach (Product product in lowStockProducts)\r\n    {\r\n        AnsiConsole.MarkupLine(\r\n            $\"{Markup.Escape(product.Name)}: {product.StockQuantity}\");\r\n    }\r\n\r\n    Pause();\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "Add <code class='inline-code'>View Low Stock Products</code> to the product menu and call <code class='inline-code'>ShowLowStockProducts</code> from its switch case."
                                },
                                new Paragraph { Body = "<b>8. View products by department</b>" },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static void ShowProductsByDepartment()\r\n{\r\n    string department = AnsiConsole.Prompt(\r\n        new SelectionPrompt&lt;string&gt;()\r\n            .Title(\"Choose a department:\")\r\n            .AddChoices(Departments));\r\n\r\n    List&lt;Product&gt; matchingProducts = Products\r\n        .Where(product =&gt; product.Department == department)\r\n        .ToList();\r\n\r\n    foreach (Product product in matchingProducts)\r\n    {\r\n        AnsiConsole.MarkupLine(Markup.Escape(product.Name));\r\n    }\r\n\r\n    Pause();\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "Add <code class='inline-code'>View Products By Department</code> to the product menu and call <code class='inline-code'>ShowProductsByDepartment</code> from its switch case."
                                }
                            }
                        }
                    }
                },
                new Article
                {
                    Id = 500307,
                    CourseDisplayId = 8,
                    Title = "Dictionary<TKey, TValue>",
                    Slug = "dictionary-tkey-tvalue",
                    Description = "Learn key-value collections and add direct SKU lookup to the Store Management System.",
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
                                    Body = "Our product list is excellent for displaying products in order, but finding one product by SKU requires searching through the list. A SKU is not merely a position; it is a meaningful, unique identifier. That makes this feature a natural fit for <code class='inline-code'>Dictionary&lt;TKey, TValue&gt;</code>."
                                },
                                new Paragraph
                                {
                                    Body = "In this chapter, you will learn how dictionaries model key-value relationships and then build the store's <b>Find Product by SKU</b> feature."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "What Is a Dictionary?",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "A dictionary stores pairs. Each pair contains a <b>key</b> and a <b>value</b>. The key identifies the value, much like a word identifies its definition in a printed dictionary."
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "Dictionary&lt;string, decimal&gt; prices = new();\r\n\r\nprices.Add(\"ELE-001\", 29.99m);\r\nprices.Add(\"GRO-004\", 14.50m);\r\n\r\nConsole.WriteLine(prices[\"ELE-001\"]); // 29.99"
                                },
                                new Paragraph
                                {
                                    Body = "Here, <code class='inline-code'>string</code> is the key type and <code class='inline-code'>decimal</code> is the value type. A store dictionary can instead map a string SKU to an entire Product object: <code class='inline-code'>Dictionary&lt;string, Product&gt;</code>."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Keys Must Be Unique",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "A dictionary cannot contain the same key twice. Two products may share a price or department because values do not need to be unique, but each SKU key must identify only one product."
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "var productsBySku = new Dictionary&lt;string, string&gt;\r\n{\r\n    [\"ELE-001\"] = \"Wireless Mouse\",\r\n    [\"GRO-004\"] = \"Coffee Beans\"\r\n};\r\n\r\n// Throws ArgumentException because ELE-001 already exists.\r\nproductsBySku.Add(\"ELE-001\", \"Keyboard\");"
                                },
                                new Paragraph
                                {
                                    Body = "The indexer uses square brackets. During initialization it adds the pairs. On an existing dictionary, assigning through the indexer adds a missing key or replaces the value of an existing key. Use that behavior deliberately; it can overwrite data."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Adding Pairs Safely",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "var stockBySku = new Dictionary&lt;string, int&gt;();\r\n\r\nstockBySku.Add(\"ELE-001\", 12);\r\n\r\nbool added = stockBySku.TryAdd(\"GRO-004\", 20);\r\nbool duplicateAdded = stockBySku.TryAdd(\"ELE-001\", 99);\r\n\r\nConsole.WriteLine(added);          // True\r\nConsole.WriteLine(duplicateAdded); // False"
                                },
                                new Paragraph
                                {
                                    Body = "<code class='inline-code'>Add</code> throws when the key already exists. <code class='inline-code'>TryAdd</code> returns false instead. Both are useful: choose whether a duplicate represents an exceptional programming mistake or an expected condition that the application should handle."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Reading Values Safely",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "if (stockBySku.TryGetValue(\"ELE-001\", out int stock))\r\n{\r\n    Console.WriteLine($\"Stock: {stock}\");\r\n}\r\nelse\r\n{\r\n    Console.WriteLine(\"Product not found.\");\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "Reading <code class='inline-code'>stockBySku[\"MISSING\"]</code> throws <code class='inline-code'>KeyNotFoundException</code>. <code class='inline-code'>TryGetValue</code> is usually the best choice when a key comes from user input because a missing value is a normal possibility. It checks for the key and retrieves its value in one operation."
                                },
                                new Paragraph
                                {
                                    Body = "<code class='inline-code'>ContainsKey</code> answers only whether a key exists. Avoid checking with <code class='inline-code'>ContainsKey</code> and then reading with the indexer when <code class='inline-code'>TryGetValue</code> can do both jobs clearly."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Updating and Removing Pairs",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "stockBySku[\"ELE-001\"] = 15;\r\n\r\nbool removed = stockBySku.Remove(\"GRO-004\");\r\nConsole.WriteLine(removed);\r\n\r\nstockBySku.Clear();"
                                },
                                new Paragraph
                                {
                                    Body = "Assigning through the indexer changes the value associated with a key. <code class='inline-code'>Remove</code> returns whether a pair was removed, and <code class='inline-code'>Clear</code> removes every pair. Removing a dictionary entry does not destroy an object that may also be referenced elsewhere."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Iterating Through a Dictionary",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "foreach (KeyValuePair&lt;string, int&gt; pair in stockBySku)\r\n{\r\n    Console.WriteLine($\"{pair.Key}: {pair.Value}\");\r\n}\r\n\r\nforeach (string sku in stockBySku.Keys)\r\n{\r\n    Console.WriteLine(sku);\r\n}\r\n\r\nforeach (int quantity in stockBySku.Values)\r\n{\r\n    Console.WriteLine(quantity);\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "Enumerating the dictionary produces <code class='inline-code'>KeyValuePair&lt;TKey, TValue&gt;</code> values. The <code class='inline-code'>Keys</code> and <code class='inline-code'>Values</code> properties provide views of only one side of the pairs. Do not depend on dictionary order to communicate business meaning; use a list when ordered presentation is the requirement."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "String Keys and Comparers",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "var productsBySku = new Dictionary&lt;string, Product&gt;(\r\n    StringComparer.OrdinalIgnoreCase);"
                                },
                                new Paragraph
                                {
                                    Body = "By default, string keys are case-sensitive, so <code class='inline-code'>ELE-001</code> and <code class='inline-code'>ele-001</code> are different keys. SKU input should not fail because of letter casing, so the store uses <code class='inline-code'>StringComparer.OrdinalIgnoreCase</code>. The comparer belongs to the dictionary and applies consistently to additions and lookups."
                                },
                                new Paragraph
                                {
                                    Body = "A <b>string comparer</b> is the rule the dictionary uses to decide whether two string keys are equal. <code class='inline-code'>Ordinal</code> compares their character values rather than applying the language rules of a particular culture. <code class='inline-code'>IgnoreCase</code> makes uppercase and lowercase versions compare as equal. This culture-independent behavior is appropriate for identifiers such as SKUs, file extensions, protocol values, and internal codes."
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "ProductsBySku.ContainsKey(\"ELE-001\"); // True\r\nProductsBySku.ContainsKey(\"ele-001\"); // Also true"
                                }
                            }
                        },
                        new Block
                        {
                            Title = "List or Dictionary?",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = RedDotList(
                                        "Use <code class='inline-code'>List&lt;T&gt;</code> when values form an ordered sequence and you work with positions or the whole collection.",
                                        "Use <code class='inline-code'>Dictionary&lt;TKey, TValue&gt;</code> when a unique key is the natural way to locate a value.",
                                        "A dictionary is not a replacement for every list. The store keeps its Product list for ordered display.",
                                        "The store adds a dictionary as an index for direct SKU lookup.")
                                },
                                new Paragraph
                                {
                                    Body = "Using both collections means the application must keep them synchronized. Later applications might choose one authoritative collection or hide synchronization inside a dedicated service. Here, maintaining both explicitly makes their different purposes visible."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Explain Lists vs Dictionaries Like I Am 10",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    BackgroundColor = "#1C236D",
                                    FontColor = "#FFF",
                                    Body = "Imagine your products are written in a notebook. A <b>List</b> is like writing every product on a numbered line: Mouse is first, Coffee is second, and Shoes is third. It is easy to read the notebook from top to bottom or ask for the item on a particular line. But if you ask, ‘Where is product ELE-001?’, you may need to read the lines until you find it.<br><br>A <b>Dictionary</b> is like a set of labelled drawers. Each drawer has a unique SKU written on the front. When you need ELE-001, you go to the drawer labelled ELE-001 and find its Product inside. You do not ask for drawer number zero or one; you ask using the meaningful label.<br><br>The store uses <b>both</b>: the List is the notebook used to display all products in order, and the Dictionary is the labelled-drawer system used to find one product by SKU."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Application: Create the SKU Index",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "In <code class='inline-code'>StoreApp.cs</code>, add this field immediately after <code class='inline-code'>Products</code>. Field order matters because the initializer reads the product list:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static readonly Dictionary&lt;string, Product&gt; ProductsBySku =\r\n    Products.ToDictionary(\r\n        product =&gt; product.Sku,\r\n        StringComparer.OrdinalIgnoreCase);"
                                },
                                new Paragraph
                                {
                                    Body = "<code class='inline-code'>ToDictionary</code> creates one pair for each Product. The lambda chooses the SKU as the key, while the Product itself becomes the value. Duplicate starting SKUs would cause initialization to fail, which exposes invalid seed data immediately."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Keep New Products Synchronized",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "In <code class='inline-code'>AddProduct</code>, replace the list-based duplicate check with the dictionary check:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "if (ProductsBySku.ContainsKey(sku))\r\n{\r\n    AnsiConsole.MarkupLine(\r\n        $\"[red]A product with SKU {Markup.Escape(sku)} already exists.[/]\");\r\n    Pause();\r\n    return;\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "Then create the Product in a variable and add the same object to both collections:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "var product = new Product\r\n{\r\n    Name = name,\r\n    Sku = sku,\r\n    Price = price,\r\n    Department = department,\r\n    StockQuantity = stockQuantity\r\n};\r\n\r\nProducts.Add(product);\r\nProductsBySku.Add(product.Sku, product);"
                                },
                                new Paragraph
                                {
                                    Body = "Both collections reference the same Product object. Updating its Name, Price, Department, or StockQuantity through either collection is visible through the other. The SKU is init-only, so the dictionary key cannot silently become inconsistent with the Product."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Do We Need to Change UpdateProduct?",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "You do <b>not</b> need to add the Product to the dictionary again when changing its Name, Department, Price, or StockQuantity. The list and dictionary do not hold separate copies. They both hold a reference to the same Product object:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "Product fromList = Products.Find(product =&gt; product.Sku == selectedSku)!;\r\nProduct fromDictionary = ProductsBySku[selectedSku];\r\n\r\nConsole.WriteLine(ReferenceEquals(fromList, fromDictionary)); // True\r\n\r\nfromList.Price = 39.99m;\r\nConsole.WriteLine(fromDictionary.Price); // 39.99"
                                },
                                new Paragraph
                                {
                                    Body = "Your existing <code class='inline-code'>UpdateProduct</code> method can therefore remain unchanged. You could optionally replace its <code class='inline-code'>Products.Find(...)</code> call with <code class='inline-code'>ProductsBySku[selectedSku]</code>, but that is an alternative lookup, not a synchronization requirement."
                                },
                                new Paragraph
                                {
                                    Body = "The situation would be different if SKU could change. A dictionary does not automatically move an entry when a property inside its value changes. You would need to remove the old key and add the new key. This course made <code class='inline-code'>Sku</code> init-only specifically so that inconsistency cannot happen."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Add Find Product to the Main Menu",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Add <code class='inline-code'>Find Product by SKU</code> after <code class='inline-code'>Manage Products</code> in the main menu, then add its switch case:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = ".AddChoices(\r\n    \"View Departments\",\r\n    \"Manage Products\",\r\n    \"Find Product by SKU\",\r\n    \"Exit\"));"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "case \"Find Product by SKU\":\r\n    FindProductBySku();\r\n    break;"
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Find and Display the Product",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static void FindProductBySku()\r\n{\r\n    AnsiConsole.Clear();\r\n\r\n    string sku = AnsiConsole.Ask&lt;string&gt;(\"Enter product SKU:\").Trim();\r\n\r\n    if (!ProductsBySku.TryGetValue(sku, out Product? product))\r\n    {\r\n        AnsiConsole.MarkupLine(\r\n            $\"[yellow]No product was found with SKU {Markup.Escape(sku)}.[/]\");\r\n        Pause();\r\n        return;\r\n    }\r\n\r\n    var table = new Table()\r\n        .Title(\"[green]Product Details[/]\")\r\n        .AddColumn(\"Field\")\r\n        .AddColumn(\"Value\")\r\n        .AddRow(\"Name\", Markup.Escape(product.Name))\r\n        .AddRow(\"SKU\", Markup.Escape(product.Sku))\r\n        .AddRow(\"Department\", Markup.Escape(product.Department))\r\n        .AddRow(\"Price\", product.Price.ToString(\"C\"))\r\n        .AddRow(\"Stock\", product.StockQuantity.ToString());\r\n\r\n    AnsiConsole.Write(table);\r\n    Pause();\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "Spectre.Console handles input and display only. The important dictionary operation is <code class='inline-code'>TryGetValue</code>: it converts a user-provided SKU into either the matching Product or a clear not-found path."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Inspect the Dictionary in the Debugger",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "A debugger lets you pause the program and inspect its data while it is running. This is one of the best ways to turn the dictionary from an abstract idea into something you can see."
                                },
                                new Paragraph
                                {
                                    Body = "Place a breakpoint inside <code class='inline-code'>FindProductBySku</code>, either on its opening brace or on the <code class='inline-code'>TryGetValue</code> line. Start the application in debug mode, choose <b>Find Product by SKU</b>, and enter a SKU. Visual Studio will pause before the lookup finishes."
                                },
                                new Paragraph
                                {
                                    IsPicture = true,
                                    PictureUrl = "c8-ch8-inspect-dictionary.png"
                                },
                                new Paragraph
                                {
                                    Body = "While execution is paused, hover over <code class='inline-code'>ProductsBySku</code> or find it in the Locals window. Expand the dictionary, then expand one entry. Notice the two parts of the pair: <b>Key</b> contains the SKU such as <code class='inline-code'>ELE-001</code>, and <b>Value</b> contains the corresponding Product object. Expand Value again to inspect its Name, Department, Price, and StockQuantity."
                                },
                                new Paragraph
                                {
                                    Body = "Repeat the lookup using different casing, such as <code class='inline-code'>ele-001</code>. The dictionary still returns the entry whose stored key is <code class='inline-code'>ELE-001</code> because it was created with <code class='inline-code'>StringComparer.OrdinalIgnoreCase</code>. Inspecting this behavior at a breakpoint helps connect the code you wrote with the key-value structure held in memory."
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
                                        "Create a temporary SKU dictionary from the store's Products, then retrieve and display one Product with its SKU.",
                                        "Use <code class='inline-code'>TryAdd</code> to attempt adding the same practice Product SKU twice and print both results.",
                                        "Ask for a Product SKU and use <code class='inline-code'>TryGetValue</code> to display either its name or a not-found message.",
                                        "Replace a practice Product through the dictionary indexer, remove its SKU, and print the dictionary's <code class='inline-code'>Count</code>.",
                                        "Print every SKU and product name from <code class='inline-code'>ProductsBySku</code>.",
                                        "Prove that lowercase SKU input finds an uppercase key when using <code class='inline-code'>StringComparer.OrdinalIgnoreCase</code>.",
                                        "Add a method that asks for a SKU and changes the matching product's stock quantity.",
                                        "Explain what could go wrong if a product were added to <code class='inline-code'>Products</code> but not to <code class='inline-code'>ProductsBySku</code>.")
                                },
                                new Paragraph
                                {
                                    Body = "Complete the exercises inside the Store Management System by adding a temporary practice method or menu option. Run the app, verify the behavior, and then delete any exercise-only code before continuing the course project. When you are ready, press the <b>View Source Code</b> button below to compare your work with example answers."
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
                                        "A dictionary associates each unique key with one value.",
                                        "Use <code class='inline-code'>TryAdd</code> when duplicate keys are an expected possibility.",
                                        "Use <code class='inline-code'>TryGetValue</code> when a requested key may be absent.",
                                        "A string comparer can define case-insensitive key behavior consistently.",
                                        "The store retains its Product list for display and uses a dictionary as its SKU index.")
                                },
                                new Paragraph
                                {
                                    Body = "The next chapter introduces <code class='inline-code'>HashSet&lt;T&gt;</code> and uses it to guarantee that every product's tags remain unique."
                                }
                            }
                        },
                        new Block
                        {
                            IsCourseCodePage = true,
                            Title = "Dictionary Exercise Answers",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph { Body = "These are example answers. Your variable names and messages may differ." },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "// Use a separate dictionary for temporary practice entries.\r\nvar practiceProductsBySku = new Dictionary&lt;string, Product&gt;(\r\n    ProductsBySku,\r\n    StringComparer.OrdinalIgnoreCase);\r\n\r\n// 1. Retrieve a store Product by SKU\r\nProduct selectedProduct = practiceProductsBySku[\"ELE-001\"];\r\nConsole.WriteLine(selectedProduct.Name);\r\n\r\n// 2. TryAdd the same practice SKU twice\r\nvar practiceProduct = new Product\r\n{\r\n    Sku = \"PRACTICE-001\",\r\n    Name = \"Practice Keyboard\",\r\n    Department = \"Electronics\",\r\n    Price = 35m,\r\n    StockQuantity = 3\r\n};\r\nbool firstAdd = practiceProductsBySku.TryAdd(practiceProduct.Sku, practiceProduct);\r\nbool secondAdd = practiceProductsBySku.TryAdd(practiceProduct.Sku, practiceProduct);\r\nConsole.WriteLine($\"{firstAdd}, {secondAdd}\");\r\n\r\n// 3. Safe Product lookup\r\nstring sku = AnsiConsole.Ask&lt;string&gt;(\"Enter product SKU:\").Trim();\r\nif (practiceProductsBySku.TryGetValue(sku, out Product? product))\r\n{\r\n    Console.WriteLine(product.Name);\r\n}\r\nelse\r\n{\r\n    Console.WriteLine(\"Product not found.\");\r\n}\r\n\r\n// 4. Replace, remove, and Count\r\npracticeProductsBySku[\"PRACTICE-001\"] = new Product\r\n{\r\n    Sku = \"PRACTICE-001\",\r\n    Name = \"Updated Practice Keyboard\",\r\n    Department = \"Electronics\",\r\n    Price = 39m,\r\n    StockQuantity = 5\r\n};\r\npracticeProductsBySku.Remove(\"PRACTICE-001\");\r\nConsole.WriteLine(practiceProductsBySku.Count);"
                                },
                                new Paragraph { Body = "<b>5. Print the SKU index</b>" },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "foreach (KeyValuePair&lt;string, Product&gt; pair in ProductsBySku)\r\n{\r\n    Console.WriteLine($\"{pair.Key}: {pair.Value.Name}\");\r\n}"
                                },
                                new Paragraph { Body = "<b>6. Verify case-insensitive lookup</b>" },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "bool found = ProductsBySku.TryGetValue(\"ele-001\", out Product? product);\r\nConsole.WriteLine(found);\r\nConsole.WriteLine(product?.Name);"
                                },
                                new Paragraph { Body = "<b>7. Update stock by SKU</b>" },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static void UpdateStockBySku()\r\n{\r\n    string sku = AnsiConsole.Ask&lt;string&gt;(\"Enter product SKU:\").Trim();\r\n\r\n    if (!ProductsBySku.TryGetValue(sku, out Product? product))\r\n    {\r\n        AnsiConsole.MarkupLine(\"[yellow]Product not found.[/]\");\r\n        Pause();\r\n        return;\r\n    }\r\n\r\n    product.StockQuantity = AnsiConsole.Prompt(\r\n        new TextPrompt&lt;int&gt;(\"New stock quantity:\")\r\n            .Validate(quantity =&gt; quantity &gt;= 0\r\n                ? ValidationResult.Success()\r\n                : ValidationResult.Error(\"[red]Stock cannot be negative.[/]\")));\r\n\r\n    Pause();\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "<b>8.</b> If only the list is updated, the product appears in product listings but cannot be found by SKU. The two collections disagree about the application's state. Centralizing additions in one method helps prevent that synchronization bug."
                                }
                            }
                        }
                    }
                },
                new Article
                {
                    Id = 500308,
                    CourseDisplayId = 9,
                    Title = "HashSet<T>",
                    Slug = "hashset-t",
                    Description = "Learn how sets enforce uniqueness and add unique product tags to the Store Management System.",
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
                                    Body = "Products can have descriptive tags such as <code class='inline-code'>wireless</code>, <code class='inline-code'>computer</code>, and <code class='inline-code'>accessory</code>. A product should never contain the same tag twice, even if a user types it with different capitalization. This requirement introduces <code class='inline-code'>HashSet&lt;T&gt;</code>."
                                },
                                new Paragraph
                                {
                                    Body = "In this chapter, you will learn how sets model unique values and then build the store's <b>Manage Product Tags</b> feature."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "What Is a HashSet?",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "A <code class='inline-code'>HashSet&lt;T&gt;</code> is a collection of unique values. It answers a simple question clearly: <b>is this value a member of the set?</b> Unlike a dictionary, it stores values by themselves rather than key-value pairs."
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "var tags = new HashSet&lt;string&gt;();\r\n\r\ntags.Add(\"wireless\");\r\ntags.Add(\"computer\");\r\ntags.Add(\"accessory\");\r\n\r\nConsole.WriteLine(tags.Count); // 3"
                                },
                                new Paragraph
                                {
                                    Body = "A set has no indexer, so <code class='inline-code'>tags[0]</code> does not compile. A tag's membership matters; its numbered position does not."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Duplicates Are Rejected",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "var tags = new HashSet&lt;string&gt;();\r\n\r\nbool firstAdd = tags.Add(\"wireless\");\r\nbool secondAdd = tags.Add(\"wireless\");\r\n\r\nConsole.WriteLine(firstAdd);  // True\r\nConsole.WriteLine(secondAdd); // False\r\nConsole.WriteLine(tags.Count); // 1"
                                },
                                new Paragraph
                                {
                                    Body = "<code class='inline-code'>Add</code> returns true when the value was added and false when an equal value already existed. It does not throw for a duplicate. That return value lets the store show a useful message without first performing a separate membership check."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Contains, Remove, and Clear",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "bool hasWireless = tags.Contains(\"wireless\");\r\nbool removed = tags.Remove(\"wireless\");\r\n\r\nConsole.WriteLine(hasWireless); // True\r\nConsole.WriteLine(removed);     // True\r\n\r\ntags.Clear();"
                                },
                                new Paragraph
                                {
                                    Body = "<code class='inline-code'>Contains</code> tests membership. <code class='inline-code'>Remove</code> returns whether an item was present and removed. <code class='inline-code'>Clear</code> empties the set. These operations express the language of a set directly."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Case-Insensitive Tags",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "var tags = new HashSet&lt;string&gt;(StringComparer.OrdinalIgnoreCase);\r\n\r\ntags.Add(\"wireless\");\r\nbool addedAgain = tags.Add(\"WIRELESS\");\r\n\r\nConsole.WriteLine(addedAgain); // False"
                                },
                                new Paragraph
                                {
                                    Body = "Just like the SKU dictionary, a string HashSet accepts a comparer. <code class='inline-code'>StringComparer.OrdinalIgnoreCase</code> makes <code class='inline-code'>wireless</code>, <code class='inline-code'>Wireless</code>, and <code class='inline-code'>WIRELESS</code> equal for membership purposes. The set keeps the spelling of the first value that was successfully added."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Iterating and Ordering",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "foreach (string tag in tags)\r\n{\r\n    Console.WriteLine(tag);\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "A HashSet can be enumerated, but its order should not represent business meaning. If the UI needs alphabetical tags, create an ordered view when displaying them, for example <code class='inline-code'>tags.OrderBy(tag =&gt; tag)</code>. The set remains responsible for uniqueness; the query handles presentation order."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Set Operations",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "HashSet also supports operations from mathematical sets. You do not need advanced mathematics to use them; each method answers a practical collection question."
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "var mouseTags = new HashSet&lt;string&gt;([\"wireless\", \"computer\", \"accessory\"]);\r\nvar keyboardTags = new HashSet&lt;string&gt;([\"wireless\", \"computer\", \"peripheral\"]);\r\n\r\nvar allTags = new HashSet&lt;string&gt;(mouseTags);\r\nallTags.UnionWith(keyboardTags);\r\n// wireless, computer, accessory, peripheral\r\n\r\nvar sharedTags = new HashSet&lt;string&gt;(mouseTags);\r\nsharedTags.IntersectWith(keyboardTags);\r\n// wireless, computer\r\n\r\nvar mouseOnlyTags = new HashSet&lt;string&gt;(mouseTags);\r\nmouseOnlyTags.ExceptWith(keyboardTags);\r\n// accessory"
                                },
                                new Paragraph
                                {
                                    Body = RedDotList(
                                        "<code class='inline-code'>UnionWith</code> keeps every value that appears in either set.",
                                        "<code class='inline-code'>IntersectWith</code> keeps only values shared by both sets.",
                                        "<code class='inline-code'>ExceptWith</code> removes values found in the other set.",
                                        "<code class='inline-code'>SymmetricExceptWith</code> keeps values found in only one of the sets.")
                                },
                                new Paragraph
                                {
                                    Body = "These methods modify the set on which they are called. The examples create copies first so the original product tags remain unchanged."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Set Relationship Checks",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "var requiredTags = new HashSet&lt;string&gt;([\"computer\", \"wireless\"]);\r\n\r\nbool hasEveryRequiredTag = mouseTags.IsSupersetOf(requiredTags);\r\nbool requirementsFitMouse = requiredTags.IsSubsetOf(mouseTags);\r\nbool sharesAnyTag = mouseTags.Overlaps(keyboardTags);\r\nbool exactlyEqual = mouseTags.SetEquals(keyboardTags);"
                                },
                                new Paragraph
                                {
                                    Body = "A <b>subset</b> contains no values outside the other set. A <b>superset</b> contains every value from the other set. <code class='inline-code'>Overlaps</code> asks whether at least one value is shared, while <code class='inline-code'>SetEquals</code> asks whether both sets contain exactly the same values regardless of enumeration order."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "List, Dictionary, or HashSet?",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = RedDotList(
                                        "Use <code class='inline-code'>List&lt;T&gt;</code> for an ordered, growable sequence that may contain duplicates.",
                                        "Use <code class='inline-code'>Dictionary&lt;TKey, TValue&gt;</code> when a unique key identifies a corresponding value.",
                                        "Use <code class='inline-code'>HashSet&lt;T&gt;</code> when each value must appear at most once and membership is the main concern.",
                                        "Choose based on the meaning and operations required by the feature, not merely because one type is familiar.")
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Explain HashSet Like I Am 10",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    BackgroundColor = "#1C236D",
                                    FontColor = "#FFF",
                                    Body = "Imagine you are collecting permission stamps for a school trip. You need one Lunch stamp, one Bus stamp, and one Museum stamp. If someone tries to give you another Lunch stamp, it does not help; you already have that permission.<br><br>A <b>List</b> is like a notebook that would happily let you write Lunch several times. A <b>Dictionary</b> is like labelled drawers where each label points to some information. A <b>HashSet</b> is like your stamp card: a stamp is either present or absent, and duplicates do not count twice.<br><br>Product tags work the same way. A mouse can be tagged wireless, computer, and accessory, but adding wireless again should not create a second wireless tag."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Application: Add Tags to Product",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Open <code class='inline-code'>Product.cs</code> and add a HashSet property. The collection is created once for each Product and cannot be replaced from outside the class:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "public HashSet&lt;string&gt; Tags { get; } =\r\n    new(StringComparer.OrdinalIgnoreCase);"
                                },
                                new Paragraph
                                {
                                    Body = "The getter exposes the set so the application can call <code class='inline-code'>Add</code> and <code class='inline-code'>Remove</code>. Omitting a setter prevents code from replacing it with a differently configured set."
                                },
                                new Paragraph
                                {
                                    Body = "Optionally seed tags inside the existing Product object initializers. Because <code class='inline-code'>Tags</code> is a get-only collection, this nested collection initializer adds values to the HashSet rather than replacing it:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "new Product\r\n{\r\n    Name = \"Wireless Mouse\",\r\n    Sku = \"ELE-001\",\r\n    Price = 29.99m,\r\n    Department = \"Electronics\",\r\n    StockQuantity = 12,\r\n    Tags = { \"wireless\", \"computer\", \"accessory\" }\r\n}"
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Add Product Tags to the Main Menu",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Add <code class='inline-code'>Manage Product Tags</code> after <code class='inline-code'>Find Product by SKU</code>, then connect its switch case:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = ".AddChoices(\r\n    \"View Departments\",\r\n    \"Manage Products\",\r\n    \"Find Product by SKU\",\r\n    \"Manage Product Tags\",\r\n    \"Exit\"));"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "case \"Manage Product Tags\":\r\n    ManageProductTags();\r\n    break;"
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Select a Product and Manage Its Tags",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static void ManageProductTags()\r\n{\r\n    AnsiConsole.Clear();\r\n\r\n    if (Products.Count == 0)\r\n    {\r\n        AnsiConsole.MarkupLine(\"[yellow]There are no products.[/]\");\r\n        Pause();\r\n        return;\r\n    }\r\n\r\n    string sku = AnsiConsole.Prompt(\r\n        new SelectionPrompt&lt;string&gt;()\r\n            .Title(\"Choose a product:\")\r\n            .AddChoices(Products.Select(product =&gt; product.Sku)));\r\n\r\n    Product product = ProductsBySku[sku];\r\n    bool returnToMainMenu = false;\r\n\r\n    while (!returnToMainMenu)\r\n    {\r\n        AnsiConsole.Clear();\r\n        ShowProductTags(product);\r\n\r\n        string choice = AnsiConsole.Prompt(\r\n            new SelectionPrompt&lt;string&gt;()\r\n                .Title($\"Manage tags for [green]{Markup.Escape(product.Name)}[/]\")\r\n                .AddChoices(\"Add Tag\", \"Remove Tag\", \"Return\"));\r\n\r\n        switch (choice)\r\n        {\r\n            case \"Add Tag\":\r\n                AddProductTag(product);\r\n                break;\r\n            case \"Remove Tag\":\r\n                RemoveProductTag(product);\r\n                break;\r\n            case \"Return\":\r\n                returnToMainMenu = true;\r\n                break;\r\n        }\r\n    }\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "The product is found through the SKU dictionary. Its Tags property then gives the tag menu direct access to that Product's own HashSet."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Display, Add, and Remove Tags",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static void ShowProductTags(Product product)\r\n{\r\n    AnsiConsole.MarkupLine(\r\n        $\"[green]Product Tags - {Markup.Escape(product.Name)}[/]\");\r\n\r\n    if (product.Tags.Count == 0)\r\n    {\r\n        AnsiConsole.MarkupLine(\"[grey]No tags assigned.[/]\");\r\n        return;\r\n    }\r\n\r\n    foreach (string tag in product.Tags.OrderBy(tag =&gt; tag))\r\n    {\r\n        AnsiConsole.MarkupLine($\"- {Markup.Escape(tag)}\");\r\n    }\r\n}\r\n\r\nprivate static void AddProductTag(Product product)\r\n{\r\n    string tag = AnsiConsole.Ask&lt;string&gt;(\"Tag to add:\").Trim();\r\n\r\n    if (string.IsNullOrWhiteSpace(tag))\r\n    {\r\n        AnsiConsole.MarkupLine(\"[red]A tag cannot be empty.[/]\");\r\n    }\r\n    else if (product.Tags.Add(tag))\r\n    {\r\n        AnsiConsole.MarkupLine(\"[green]Tag added.[/]\");\r\n    }\r\n    else\r\n    {\r\n        AnsiConsole.MarkupLine(\r\n            $\"[yellow]The tag {Markup.Escape(tag)} is already assigned.[/]\");\r\n    }\r\n\r\n    Pause();\r\n}\r\n\r\nprivate static void RemoveProductTag(Product product)\r\n{\r\n    if (product.Tags.Count == 0)\r\n    {\r\n        AnsiConsole.MarkupLine(\"[yellow]This product has no tags.[/]\");\r\n        Pause();\r\n        return;\r\n    }\r\n\r\n    string tag = AnsiConsole.Prompt(\r\n        new SelectionPrompt&lt;string&gt;()\r\n            .Title(\"Choose a tag to remove:\")\r\n            .AddChoices(product.Tags.OrderBy(tag =&gt; tag)));\r\n\r\n    product.Tags.Remove(tag);\r\n    AnsiConsole.MarkupLine(\"[green]Tag removed.[/]\");\r\n    Pause();\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "The boolean returned by <code class='inline-code'>Add</code> determines which message is shown. The removal prompt is built from existing tags, so its selected value is guaranteed to be a member of the set."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Inspect the HashSet in the Debugger",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Place a breakpoint inside <code class='inline-code'>AddProductTag</code>, after the application attempts to add the tag. Start the application in debug mode, open <b>Manage Product Tags</b>, choose a Product, and add a tag. Visual Studio will pause while the Product and its HashSet are still available for inspection."
                                },
                                new Paragraph
                                {
                                    IsPicture = true,
                                    PictureUrl = "c8-ch9-inspect-hashset.png"
                                },
                                new Paragraph
                                {
                                    Body = "Hover over <code class='inline-code'>product</code> or find it in the Locals window. Expand the Product, then expand <code class='inline-code'>Tags</code>. Notice that Count represents the number of unique tags and that each entry contains a tag value rather than a key-value pair. This is different from the Dictionary you inspected in the previous chapter."
                                },
                                new Paragraph
                                {
                                    Body = "Continue execution, then try adding the same tag again using different capitalization. Inspect <code class='inline-code'>product.Tags</code> once more. Because the HashSet uses <code class='inline-code'>StringComparer.OrdinalIgnoreCase</code>, <code class='inline-code'>hardware</code> and <code class='inline-code'>HARDWARE</code> are considered equal. The second <code class='inline-code'>Add</code> returns false and Count does not increase."
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
                                        "Create a temporary HashSet containing five tags for a store Product and print its Count.",
                                        "Add the same Product tag twice and print the boolean returned by each <code class='inline-code'>Add</code> call.",
                                        "Create a case-insensitive tag set and prove that <code class='inline-code'>wireless</code> and <code class='inline-code'>WIRELESS</code> count as one value.",
                                        "Remove one Product tag, attempt to remove a missing tag, and print both results.",
                                        "Create two sets of product tags and display their union, intersection, and difference without changing the originals.",
                                        "Use <code class='inline-code'>Overlaps</code> to determine whether two products share any tags.",
                                        "Add a <code class='inline-code'>Clear Tags</code> option to the product-tag menu and ask for confirmation before clearing.",
                                        "Build a unique set of every tag used by every Product in the store and display it alphabetically.")
                                },
                                new Paragraph
                                {
                                    Body = "Complete the exercises inside the Store Management System by adding a temporary practice method or menu option. Run the app, verify the behavior, and then delete any exercise-only code before continuing the course project. When you are ready, press the <b>View Source Code</b> button below to compare your work with example answers."
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
                                        "A <code class='inline-code'>HashSet&lt;T&gt;</code> stores unique values and models membership.",
                                        "<code class='inline-code'>Add</code> returns false instead of inserting a duplicate.",
                                        "A comparer defines equality consistently for string values.",
                                        "Set operations combine, compare, and subtract groups of unique values.",
                                        "Each Product now owns a case-insensitive HashSet of tags.")
                                },
                                new Paragraph
                                {
                                    Body = "The next chapter introduces <code class='inline-code'>Stack&lt;T&gt;</code> and uses its last-in, first-out behavior to undo product removals."
                                }
                            }
                        },
                        new Block
                        {
                            IsCourseCodePage = true,
                            Title = "HashSet Exercise Answers",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph { Body = "These are example answers. Your variable names and output may differ." },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "// Keep this set local so it does not change a real Product.\r\nvar practiceTags = new HashSet&lt;string&gt;(StringComparer.OrdinalIgnoreCase)\r\n{\r\n    \"wireless\", \"computer\", \"accessory\", \"office\", \"sale\"\r\n};\r\nConsole.WriteLine(practiceTags.Count);\r\n\r\n// 2. Inspect duplicate Add results\r\nbool firstAdd = practiceTags.Add(\"portable\");\r\nbool secondAdd = practiceTags.Add(\"portable\");\r\nConsole.WriteLine($\"{firstAdd}, {secondAdd}\");\r\n\r\n// 3. Case-insensitive Product tags\r\nvar caseInsensitiveTags = new HashSet&lt;string&gt;(StringComparer.OrdinalIgnoreCase);\r\ncaseInsensitiveTags.Add(\"wireless\");\r\ncaseInsensitiveTags.Add(\"WIRELESS\");\r\nConsole.WriteLine(caseInsensitiveTags.Count); // 1\r\n\r\n// 4. Remove existing and missing tags\r\nbool removedOffice = practiceTags.Remove(\"office\");\r\nbool removedMissing = practiceTags.Remove(\"clearance\");\r\nConsole.WriteLine($\"{removedOffice}, {removedMissing}\");"
                                },
                                new Paragraph { Body = "<b>5 and 6. Set operations and overlap</b>" },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "var firstTags = new HashSet&lt;string&gt;([\"wireless\", \"computer\", \"accessory\"]);\r\nvar secondTags = new HashSet&lt;string&gt;([\"wireless\", \"computer\", \"peripheral\"]);\r\n\r\nvar union = new HashSet&lt;string&gt;(firstTags);\r\nunion.UnionWith(secondTags);\r\n\r\nvar intersection = new HashSet&lt;string&gt;(firstTags);\r\nintersection.IntersectWith(secondTags);\r\n\r\nvar difference = new HashSet&lt;string&gt;(firstTags);\r\ndifference.ExceptWith(secondTags);\r\n\r\nbool sharesTags = firstTags.Overlaps(secondTags);\r\nConsole.WriteLine(sharesTags);"
                                },
                                new Paragraph { Body = "<b>7. Clear tags with confirmation</b>" },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static void ClearProductTags(Product product)\r\n{\r\n    if (product.Tags.Count == 0)\r\n    {\r\n        AnsiConsole.MarkupLine(\"[yellow]This product has no tags.[/]\");\r\n        Pause();\r\n        return;\r\n    }\r\n\r\n    if (AnsiConsole.Confirm(\"Remove every tag?\"))\r\n    {\r\n        product.Tags.Clear();\r\n        AnsiConsole.MarkupLine(\"[green]Tags cleared.[/]\");\r\n    }\r\n\r\n    Pause();\r\n}"
                                },
                                new Paragraph { Body = "<b>8. Collect every unique store tag</b>" },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "var storeTags = new HashSet&lt;string&gt;(StringComparer.OrdinalIgnoreCase);\r\n\r\nforeach (Product product in Products)\r\n{\r\n    storeTags.UnionWith(product.Tags);\r\n}\r\n\r\nforeach (string tag in storeTags.OrderBy(tag =&gt; tag))\r\n{\r\n    Console.WriteLine(tag);\r\n}"
                                }
                            }
                        }
                    }
                },
                new Article
                {
                    Id = 500309,
                    CourseDisplayId = 10,
                    Title = "Stack<T>",
                    Slug = "stack-t",
                    Description = "Learn last-in, first-out processing and add product removal with undo support to the Store Management System.",
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
                                    Body = "The store can add and update products, but it cannot remove one safely. A removal feature becomes much friendlier when users can undo a mistake. Undo naturally introduces <code class='inline-code'>Stack&lt;T&gt;</code>."
                                },
                                new Paragraph
                                {
                                    Body = "In this chapter, removed products will be placed on a stack. The most recently removed Product will be the first one restored."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "What Is a Stack?",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "A stack is a collection that follows <b>Last In, First Out</b>, commonly shortened to <b>LIFO</b>. Values enter and leave from the same end, called the top."
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "var removedSkus = new Stack&lt;string&gt;();\r\n\r\nremovedSkus.Push(\"ELE-001\");\r\nremovedSkus.Push(\"GRO-004\");\r\n\r\nConsole.WriteLine(removedSkus.Pop()); // GRO-004\r\nConsole.WriteLine(removedSkus.Pop()); // ELE-001"
                                },
                                new Paragraph
                                {
                                    Body = "ELE-001 entered first, but GRO-004 entered last and therefore left first. A stack does not let the user choose an arbitrary item to remove from the middle; its behavior is deliberately restricted."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Push: Place a Value on Top",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "var removedProducts = new Stack&lt;Product&gt;();\r\n\r\nremovedProducts.Push(mouse);\r\nremovedProducts.Push(coffee);\r\n\r\nConsole.WriteLine(removedProducts.Count); // 2"
                                },
                                new Paragraph
                                {
                                    Body = "<code class='inline-code'>Push</code> adds a value to the top. After these calls, Coffee is on top of Mouse. <code class='inline-code'>Count</code> reports how many removed products are available to restore."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Pop: Remove the Top Value",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "Product productToRestore = removedProducts.Pop();\r\nConsole.WriteLine(productToRestore.Name); // Coffee"
                                },
                                new Paragraph
                                {
                                    Body = "<code class='inline-code'>Pop</code> returns and removes the top value. Calling it on an empty stack throws <code class='inline-code'>InvalidOperationException</code>, so applications must handle the empty case."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Peek: Inspect Without Removing",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "Product nextProduct = removedProducts.Peek();\r\n\r\nConsole.WriteLine(nextProduct.Name);\r\nConsole.WriteLine(removedProducts.Count); // Count is unchanged"
                                },
                                new Paragraph
                                {
                                    Body = "<code class='inline-code'>Peek</code> returns the top value without removing it. It is useful when the store needs to validate or preview the next Product before deciding whether restoration can continue. Like Pop, Peek throws when the stack is empty."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "TryPop and TryPeek",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "if (removedProducts.TryPeek(out Product? nextProduct))\r\n{\r\n    Console.WriteLine($\"Next to restore: {nextProduct.Name}\");\r\n}\r\n\r\nif (removedProducts.TryPop(out Product? restoredProduct))\r\n{\r\n    Console.WriteLine($\"Restoring: {restoredProduct.Name}\");\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "The Try methods return false when the stack is empty instead of throwing. Use <code class='inline-code'>TryPeek</code> when validation must happen before removal. Use <code class='inline-code'>TryPop</code> when taking the value immediately is safe."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Enumerating a Stack",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "foreach (Product product in removedProducts)\r\n{\r\n    Console.WriteLine(product.Name);\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "Enumeration visits the stack from top to bottom, so the most recently removed Product appears first. A <code class='inline-code'>foreach</code> loop does not pop values; Count remains unchanged."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "When Should You Use a Stack?",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = RedDotList(
                                        "Use a stack when the most recent item must be processed first.",
                                        "Stacks are natural for undo histories, nested operations, backtracking, and temporary work that must be reversed.",
                                        "Do not use a stack when users need indexed access or arbitrary removal.",
                                        "Do not use a stack when the oldest item must be processed first; that behavior belongs to a queue.")
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Explain Stack Like I Am 10",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    BackgroundColor = "#1C236D",
                                    FontColor = "#FFF",
                                    Body = "Imagine stacking cafeteria trays. You put one tray down, then another tray on top, then another. When someone needs a tray, they take the one from the top. Taking the bottom tray first would mean lifting every tray above it.<br><br>A Stack in C# works the same way. <b>Push</b> puts something on top, <b>Peek</b> looks at the top without taking it, and <b>Pop</b> takes the top item away.<br><br>When products are removed from the store, each one becomes the new top tray. Undo restores the last product removed because it is sitting on top of the stack."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Application: Create the Removal History",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Add this field below <code class='inline-code'>ProductsBySku</code> in <code class='inline-code'>StoreApp.cs</code>:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static readonly Stack&lt;Product&gt; RemovedProducts = new();"
                                },
                                new Paragraph
                                {
                                    Body = "The stack stores the actual Product objects that were removed. Their SKU, tags, price, department, and stock remain together, so undo can restore the complete object."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Add Remove and Undo to the Main Menu",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Add the two new choices after <code class='inline-code'>Manage Product Tags</code>:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = ".AddChoices(\r\n    \"View Departments\",\r\n    \"Manage Products\",\r\n    \"Find Product by SKU\",\r\n    \"Manage Product Tags\",\r\n    \"Remove Product\",\r\n    \"Undo Last Removal\",\r\n    \"Exit\"));"
                                },
                                new Paragraph
                                {
                                    Body = "Then connect both switch cases:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "case \"Remove Product\":\r\n    RemoveProduct();\r\n    break;\r\ncase \"Undo Last Removal\":\r\n    UndoLastRemoval();\r\n    break;"
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Remove a Product Safely",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static void RemoveProduct()\r\n{\r\n    AnsiConsole.Clear();\r\n\r\n    if (Products.Count == 0)\r\n    {\r\n        AnsiConsole.MarkupLine(\"[yellow]There are no products to remove.[/]\");\r\n        Pause();\r\n        return;\r\n    }\r\n\r\n    string sku = AnsiConsole.Prompt(\r\n        new SelectionPrompt&lt;string&gt;()\r\n            .Title(\"Choose a product to remove:\")\r\n            .AddChoices(Products.Select(product =&gt; product.Sku)));\r\n\r\n    Product product = ProductsBySku[sku];\r\n\r\n    bool confirmed = AnsiConsole.Confirm(\r\n        $\"Remove {Markup.Escape(product.Name)}?\");\r\n\r\n    if (!confirmed)\r\n    {\r\n        AnsiConsole.MarkupLine(\"[grey]Removal cancelled.[/]\");\r\n        Pause();\r\n        return;\r\n    }\r\n\r\n    Products.Remove(product);\r\n    ProductsBySku.Remove(product.Sku);\r\n    RemovedProducts.Push(product);\r\n\r\n    AnsiConsole.MarkupLine(\r\n        $\"[green]{Markup.Escape(product.Name)} was removed.[/]\");\r\n    AnsiConsole.MarkupLine(\"[grey]You can restore it using Undo Last Removal.[/]\");\r\n    Pause();\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "The Product is removed from both active collections before it is pushed onto the history. The list and dictionary therefore stay synchronized, while the stack becomes the one place holding removed products."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Undo the Last Removal",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static void UndoLastRemoval()\r\n{\r\n    AnsiConsole.Clear();\r\n\r\n    if (!RemovedProducts.TryPeek(out Product? product))\r\n    {\r\n        AnsiConsole.MarkupLine(\"[yellow]There are no removed products to restore.[/]\");\r\n        Pause();\r\n        return;\r\n    }\r\n\r\n    if (ProductsBySku.ContainsKey(product.Sku))\r\n    {\r\n        AnsiConsole.MarkupLine(\r\n            $\"[red]SKU {Markup.Escape(product.Sku)} is already active.[/]\");\r\n        Pause();\r\n        return;\r\n    }\r\n\r\n    RemovedProducts.Pop();\r\n    Products.Add(product);\r\n    ProductsBySku.Add(product.Sku, product);\r\n\r\n    AnsiConsole.MarkupLine(\r\n        $\"[green]{Markup.Escape(product.Name)} was restored.[/]\");\r\n    Pause();\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "The method peeks before popping so it can validate the SKU while the Product remains safely on the stack. Only after validation succeeds does it pop and restore the same object to both active collections. Its Tags HashSet is restored automatically because it belongs to that Product."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Why Undo Restores Only the Latest Product",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Suppose the user removes Wireless Mouse, then Coffee Beans. Coffee Beans is now on top of the stack, so the first undo restores Coffee Beans. A second undo restores Wireless Mouse."
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "RemovedProducts.Push(wirelessMouse);\r\nRemovedProducts.Push(coffeeBeans);\r\n\r\nProduct firstUndo = RemovedProducts.Pop();  // Coffee Beans\r\nProduct secondUndo = RemovedProducts.Pop(); // Wireless Mouse"
                                },
                                new Paragraph
                                {
                                    Body = "That reverse order is not an inconvenience; it is the rule that makes a stack suitable for undo. Each undo reverses the most recent outstanding action."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Inspect the Stack in the Debugger",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Place a breakpoint immediately after <code class='inline-code'>RemovedProducts.Push(product)</code> in <code class='inline-code'>RemoveProduct</code>. Start the application in debug mode, remove a Product, and let Visual Studio pause after the Product has been pushed onto the stack."
                                },
                                new Paragraph
                                {
                                    IsPicture = true,
                                    PictureUrl = "c8-ch10-inspect-stack.png"
                                },
                                new Paragraph
                                {
                                    Body = "Hover over <code class='inline-code'>RemovedProducts</code> or find it in the Locals window. Expand the stack and inspect its Count and Product values. The item displayed first is the top of the stack: it is the next Product that <code class='inline-code'>Peek</code> will inspect or <code class='inline-code'>Pop</code> will remove."
                                },
                                new Paragraph
                                {
                                    Body = "Continue execution and remove a different Product. When the breakpoint is reached again, expand the stack once more. The second Product removed should now appear on top of the earlier removal. Use <b>Undo Last Removal</b> and verify that this newest Product is restored first. This inspection makes the stack's last-in, first-out behavior visible in memory."
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
                                        "Remove two different store products, inspect <code class='inline-code'>RemovedProducts.Count</code>, and verify that one undo restores the second product removed.",
                                        "Add a message to the main menu showing how many product removals can currently be undone.",
                                        "Use <code class='inline-code'>TryPeek</code> to display the Name and SKU of the next Product that Undo Last Removal will restore without changing Count.",
                                        "Add a <code class='inline-code'>View Removal History</code> option that lists removed products from newest to oldest without popping them.",
                                        "Add a <code class='inline-code'>Clear Removal History</code> option with confirmation, leaving currently active products unchanged.",
                                        "Limit the undo history to five Products by discarding the oldest history entry when a sixth Product is removed.",
                                        "Verify that removing and restoring a Product also preserves every value in its Tags HashSet.",
                                        "Create a helper method that performs all three removal updates together so <code class='inline-code'>Products</code>, <code class='inline-code'>ProductsBySku</code>, and <code class='inline-code'>RemovedProducts</code> cannot be updated in different places.")
                                },
                                new Paragraph
                                {
                                    Body = "Complete the exercises inside the Store Management System by adding a temporary practice method or menu option. Run the app, verify the behavior, and then delete any exercise-only code before continuing the course project. When you are ready, press the <b>View Source Code</b> button below to compare your implementation with the examples."
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
                                        "A <code class='inline-code'>Stack&lt;T&gt;</code> processes the last value added before earlier values.",
                                        "<code class='inline-code'>Push</code> adds to the top, <code class='inline-code'>Peek</code> reads the top, and <code class='inline-code'>Pop</code> removes it.",
                                        "The Try methods handle an empty stack without throwing.",
                                        "Removed Products retain all their data while stored in the undo history.",
                                        "Undo restores the most recently removed Product to both active collections.")
                                },
                                new Paragraph
                                {
                                    Body = "The next chapter introduces <code class='inline-code'>Queue&lt;T&gt;</code> and uses first-in, first-out processing for pending store orders."
                                }
                            }
                        },
                        new Block
                        {
                            IsCourseCodePage = true,
                            Title = "Stack Exercise Answers",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph { Body = "These example answers all extend the Store Management System. Your method names and messages may differ." },
                                new Paragraph { Body = "<b>1. Verify LIFO removal and undo</b>" },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "RemoveProduct(); // Select the first Product\r\nRemoveProduct(); // Select a different Product\r\n\r\nConsole.WriteLine(RemovedProducts.Count); // 2\r\nProduct nextToRestore = RemovedProducts.Peek();\r\nUndoLastRemoval();\r\n\r\n// The restored Product is nextToRestore, the second Product removed."
                                },
                                new Paragraph { Body = "<b>2 and 3. Show undo count and preview</b>" },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "AnsiConsole.MarkupLine(\r\n    $\"[grey]Available undos: {RemovedProducts.Count}[/]\");\r\n\r\nif (RemovedProducts.TryPeek(out Product? nextProduct))\r\n{\r\n    AnsiConsole.MarkupLine(\r\n        $\"Next restore: {Markup.Escape(nextProduct.Name)} ({Markup.Escape(nextProduct.Sku)})\");\r\n}"
                                },
                                new Paragraph { Body = "<b>4. View removal history</b>" },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static void ShowRemovalHistory()\r\n{\r\n    AnsiConsole.Clear();\r\n\r\n    if (RemovedProducts.Count == 0)\r\n    {\r\n        AnsiConsole.MarkupLine(\"[yellow]Removal history is empty.[/]\");\r\n    }\r\n    else\r\n    {\r\n        foreach (Product product in RemovedProducts)\r\n        {\r\n            AnsiConsole.MarkupLine(\r\n                $\"{Markup.Escape(product.Sku)} - {Markup.Escape(product.Name)}\");\r\n        }\r\n    }\r\n\r\n    Pause();\r\n}"
                                },
                                new Paragraph { Body = "<b>5. Clear removal history</b>" },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static void ClearRemovalHistory()\r\n{\r\n    if (AnsiConsole.Confirm(\"Clear the undo history?\"))\r\n    {\r\n        RemovedProducts.Clear();\r\n        AnsiConsole.MarkupLine(\"[green]Undo history cleared.[/]\");\r\n    }\r\n\r\n    Pause();\r\n}"
                                },
                                new Paragraph { Body = "<b>6. Keep only five undo entries</b>" },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private const int RemovalHistoryLimit = 5;\r\n\r\nprivate static void PushRemoval(Product product)\r\n{\r\n    RemovedProducts.Push(product);\r\n\r\n    if (RemovedProducts.Count &lt;= RemovalHistoryLimit)\r\n    {\r\n        return;\r\n    }\r\n\r\n    Product[] newestToOldest = RemovedProducts.ToArray();\r\n    RemovedProducts.Clear();\r\n\r\n    for (int index = RemovalHistoryLimit - 1; index &gt;= 0; index--)\r\n    {\r\n        RemovedProducts.Push(newestToOldest[index]);\r\n    }\r\n}"
                                },
                                new Paragraph { Body = "<b>7. Verify that tags survive restoration</b>" },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "Product product = ProductsBySku[\"ELE-001\"];\r\nvar originalTags = new HashSet&lt;string&gt;(product.Tags);\r\n\r\nRemoveActiveProduct(product);\r\nUndoLastRemoval();\r\n\r\nbool tagsPreserved = ProductsBySku[\"ELE-001\"].Tags.SetEquals(originalTags);\r\nConsole.WriteLine(tagsPreserved);"
                                },
                                new Paragraph { Body = "<b>8. Centralize removal updates</b>" },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static void RemoveActiveProduct(Product product)\r\n{\r\n    bool removedFromList = Products.Remove(product);\r\n    bool removedFromDictionary = ProductsBySku.Remove(product.Sku);\r\n\r\n    if (!removedFromList || !removedFromDictionary)\r\n    {\r\n        throw new InvalidOperationException(\r\n            \"The active product collections were out of sync.\");\r\n    }\r\n\r\n    RemovedProducts.Push(product);\r\n}"
                                }
                            }
                        }
                    }
                },
                new Article
                {
                    Id = 500310,
                    CourseDisplayId = 11,
                    Title = "Queue<T>",
                    Slug = "queue-t",
                    Description = "Learn first-in, first-out processing and build the Store Management System's pending-order queue.",
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
                                    Body = "The store now needs to accept customer orders and process them fairly. The first order created should be the first order processed. This rule introduces <code class='inline-code'>Queue&lt;T&gt;</code>."
                                },
                                new Paragraph
                                {
                                    Body = "In this chapter, you will learn first-in, first-out behavior and build a complete pending-order menu around <code class='inline-code'>Queue&lt;Order&gt;</code>."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "What Is a Queue?",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "A queue is a collection that follows <b>First In, First Out</b>, commonly shortened to <b>FIFO</b>. New values join at the back, while processing happens at the front."
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "var pendingOrderIds = new Queue&lt;string&gt;();\r\n\r\npendingOrderIds.Enqueue(\"ORD-101\");\r\npendingOrderIds.Enqueue(\"ORD-102\");\r\npendingOrderIds.Enqueue(\"ORD-103\");\r\n\r\nConsole.WriteLine(pendingOrderIds.Dequeue()); // ORD-101\r\nConsole.WriteLine(pendingOrderIds.Dequeue()); // ORD-102"
                                },
                                new Paragraph
                                {
                                    Body = "ORD-101 entered first and therefore left first. Unlike a stack, the newest item does not jump ahead of older work."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Enqueue: Join the Back",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "var pendingOrders = new Queue&lt;Order&gt;();\r\n\r\npendingOrders.Enqueue(firstOrder);\r\npendingOrders.Enqueue(secondOrder);\r\n\r\nConsole.WriteLine(pendingOrders.Count); // 2"
                                },
                                new Paragraph
                                {
                                    Body = "<code class='inline-code'>Enqueue</code> places a value at the back. The first Order remains at the front while later Orders line up behind it."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Dequeue: Process the Front",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "Order nextOrder = pendingOrders.Dequeue();\r\nConsole.WriteLine(nextOrder.Id);"
                                },
                                new Paragraph
                                {
                                    Body = "<code class='inline-code'>Dequeue</code> returns and removes the value at the front. Calling it on an empty queue throws <code class='inline-code'>InvalidOperationException</code>, so the empty case must be handled."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Peek: Inspect the Next Order",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "Order nextOrder = pendingOrders.Peek();\r\n\r\nConsole.WriteLine(nextOrder.Id);\r\nConsole.WriteLine(pendingOrders.Count); // Count is unchanged"
                                },
                                new Paragraph
                                {
                                    Body = "<code class='inline-code'>Peek</code> returns the front value without removing it. The store can preview or validate the next Order before processing it. Peek also throws when the queue is empty."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "TryDequeue and TryPeek",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "if (pendingOrders.TryPeek(out Order? nextOrder))\r\n{\r\n    Console.WriteLine($\"Next order: {nextOrder.Id}\");\r\n}\r\n\r\nif (pendingOrders.TryDequeue(out Order? processedOrder))\r\n{\r\n    Console.WriteLine($\"Processing: {processedOrder.Id}\");\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "The Try methods return false when the queue is empty. Use <code class='inline-code'>TryPeek</code> when the Order must remain pending during validation, and <code class='inline-code'>TryDequeue</code> when it is safe to take the next Order immediately."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Enumerating a Queue",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "int position = 1;\r\n\r\nforeach (Order order in pendingOrders)\r\n{\r\n    Console.WriteLine($\"{position}: {order.Id}\");\r\n    position++;\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "Enumeration visits the queue from front to back, which is exactly the pending processing order. A <code class='inline-code'>foreach</code> loop does not dequeue anything, so it is safe for a View Pending Orders screen."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Queue or Stack?",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = RedDotList(
                                        "A <code class='inline-code'>Queue&lt;T&gt;</code> processes the oldest waiting value first: FIFO.",
                                        "A <code class='inline-code'>Stack&lt;T&gt;</code> processes the newest value first: LIFO.",
                                        "Pending Orders use a queue because customers should be served in arrival order.",
                                        "Removed Products use a stack because undo should reverse the most recent removal.")
                                },
                                new Paragraph
                                {
                                    Body = "The two collections expose similarly restricted access, but they solve opposite ordering problems. Choosing correctly depends on which end of the history the application must process next."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Explain Queue Like I Am 10",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    BackgroundColor = "#1C236D",
                                    FontColor = "#FFF",
                                    Body = "Imagine lining up for lunch at school. The first student who joins the line is served first. New students join at the back; they do not step in front of everyone already waiting.<br><br>A Queue in C# works the same way. <b>Enqueue</b> joins the back of the line, <b>Peek</b> looks at who is next without serving them, and <b>Dequeue</b> serves and removes the person at the front.<br><br>Store orders use a Queue because ORD-101 should be processed before ORD-102 when ORD-101 arrived first."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "When Should You Use a Queue?",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = RedDotList(
                                        "Use a queue when work must be handled in arrival order.",
                                        "Queues are natural for orders, print jobs, support requests, messages, and background tasks.",
                                        "Do not use a queue when users need indexed or arbitrary access.",
                                        "Do not use a queue when the newest action must be reversed first; use a stack for that behavior.")
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Application: Create the Order Model",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Create <code class='inline-code'>Order.cs</code> in the Models folder:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "namespace TCSA.Study.DataStructures.Models;\r\n\r\npublic sealed class Order\r\n{\r\n    public required string Id { get; init; }\r\n    public required string CustomerName { get; init; }\r\n    public int ItemCount { get; init; }\r\n    public DateTime CreatedAt { get; init; }\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "The Order is immutable after creation in this version. Its ID, customer, item count, and creation time describe the work waiting in the queue."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Create the Pending Order Queue",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Add the queue and the next order number below <code class='inline-code'>RemovedProducts</code>:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static readonly Queue&lt;Order&gt; PendingOrders = new();\r\nprivate static int _nextOrderNumber = 101;"
                                },
                                new Paragraph
                                {
                                    Body = "The queue preserves arrival order. The counter creates readable IDs beginning with ORD-101 for this in-memory application."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Add Order Management to the Main Menu",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Add <code class='inline-code'>Manage Orders</code> after <code class='inline-code'>Undo Last Removal</code>, then connect its switch case:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = ".AddChoices(\r\n    \"View Departments\",\r\n    \"Manage Products\",\r\n    \"Find Product by SKU\",\r\n    \"Manage Product Tags\",\r\n    \"Remove Product\",\r\n    \"Undo Last Removal\",\r\n    \"Manage Orders\",\r\n    \"Exit\"));"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "case \"Manage Orders\":\r\n    ShowOrderMenu();\r\n    break;"
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Build the Order Menu",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static void ShowOrderMenu()\r\n{\r\n    bool returnToMainMenu = false;\r\n\r\n    while (!returnToMainMenu)\r\n    {\r\n        AnsiConsole.Clear();\r\n\r\n        string choice = AnsiConsole.Prompt(\r\n            new SelectionPrompt&lt;string&gt;()\r\n                .Title(\"[green]Order Management[/]\")\r\n                .AddChoices(\r\n                    \"View Pending Orders\",\r\n                    \"Create Order\",\r\n                    \"Process Next Order\",\r\n                    \"Return to Main Menu\"));\r\n\r\n        switch (choice)\r\n        {\r\n            case \"View Pending Orders\":\r\n                ShowPendingOrders();\r\n                break;\r\n            case \"Create Order\":\r\n                CreateOrder();\r\n                break;\r\n            case \"Process Next Order\":\r\n                ProcessNextOrder();\r\n                break;\r\n            case \"Return to Main Menu\":\r\n                returnToMainMenu = true;\r\n                break;\r\n        }\r\n    }\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "The menu lets users see the queue, add work to its back, and process work from its front. It deliberately offers no option to choose an arbitrary pending Order."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Create and Enqueue an Order",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static void CreateOrder()\r\n{\r\n    AnsiConsole.Clear();\r\n\r\n    string customerName = AnsiConsole.Prompt(\r\n        new TextPrompt&lt;string&gt;(\"Customer name:\")\r\n            .Validate(value =&gt; !string.IsNullOrWhiteSpace(value)\r\n                ? ValidationResult.Success()\r\n                : ValidationResult.Error(\"[red]Customer name is required.[/]\")))\r\n        .Trim();\r\n    int itemCount = AnsiConsole.Prompt(\r\n        new TextPrompt&lt;int&gt;(\"Number of items:\")\r\n            .Validate(count =&gt; count &gt; 0\r\n                ? ValidationResult.Success()\r\n                : ValidationResult.Error(\"[red]An order needs at least one item.[/]\")));\r\n\r\n    var order = new Order\r\n    {\r\n        Id = $\"ORD-{_nextOrderNumber++}\",\r\n        CustomerName = customerName,\r\n        ItemCount = itemCount,\r\n        CreatedAt = DateTime.Now\r\n    };\r\n\r\n    PendingOrders.Enqueue(order);\r\n\r\n    AnsiConsole.MarkupLine(\r\n        $\"[green]{Markup.Escape(order.Id)} joined the order queue.[/]\");\r\n    Pause();\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "The prompts reject an empty customer name and a non-positive item count before an Order can be created. The Order ID is assigned immediately before the valid object enters the queue, and <code class='inline-code'>Enqueue</code> places it behind every Order already waiting."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Display Pending Orders in Queue Order",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static void ShowPendingOrders()\r\n{\r\n    AnsiConsole.Clear();\r\n\r\n    if (PendingOrders.Count == 0)\r\n    {\r\n        AnsiConsole.MarkupLine(\"[yellow]There are no pending orders.[/]\");\r\n        Pause();\r\n        return;\r\n    }\r\n\r\n    var table = new Table()\r\n        .Title(\"[green]Pending Orders[/]\")\r\n        .AddColumn(\"Position\")\r\n        .AddColumn(\"Order ID\")\r\n        .AddColumn(\"Customer\")\r\n        .AddColumn(\"Items\")\r\n        .AddColumn(\"Created\");\r\n\r\n    int position = 1;\r\n\r\n    foreach (Order order in PendingOrders)\r\n    {\r\n        table.AddRow(\r\n            position.ToString(),\r\n            Markup.Escape(order.Id),\r\n            Markup.Escape(order.CustomerName),\r\n            order.ItemCount.ToString(),\r\n            order.CreatedAt.ToString(\"g\"));\r\n        position++;\r\n    }\r\n\r\n    AnsiConsole.Write(table);\r\n    Pause();\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "The first table row is the front of the queue and therefore the next Order to process. Enumeration preserves the queue and its Count."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Process the Next Order",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static void ProcessNextOrder()\r\n{\r\n    AnsiConsole.Clear();\r\n\r\n    if (!PendingOrders.TryPeek(out Order? nextOrder))\r\n    {\r\n        AnsiConsole.MarkupLine(\"[yellow]There are no pending orders to process.[/]\");\r\n        Pause();\r\n        return;\r\n    }\r\n\r\n    AnsiConsole.MarkupLine(\"[green]Next Order[/]\");\r\n    AnsiConsole.MarkupLine($\"Order: {Markup.Escape(nextOrder.Id)}\");\r\n    AnsiConsole.MarkupLine($\"Customer: {Markup.Escape(nextOrder.CustomerName)}\");\r\n    AnsiConsole.MarkupLine($\"Items: {nextOrder.ItemCount}\");\r\n\r\n    if (!AnsiConsole.Confirm(\"Process this order?\"))\r\n    {\r\n        AnsiConsole.MarkupLine(\"[grey]The order remains pending.[/]\");\r\n        Pause();\r\n        return;\r\n    }\r\n\r\n    Order processedOrder = PendingOrders.Dequeue();\r\n\r\n    AnsiConsole.MarkupLine(\r\n        $\"[green]{Markup.Escape(processedOrder.Id)} processed successfully.[/]\");\r\n    Pause();\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "The method peeks first so cancellation leaves the Order untouched. Only confirmation leads to <code class='inline-code'>Dequeue</code>. Users cannot skip the oldest Order and process a later one."
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
                                        "Create three store Orders and verify that processing once removes the first Order created, not the last.",
                                        "Display the number of pending Orders beside the Order Management menu title.",
                                        "Use <code class='inline-code'>TryPeek</code> to show the next Order ID and customer without changing the queue's Count.",
                                        "Add a confirmation message showing how many Orders will remain after the next Order is processed.",
                                        "Add a <code class='inline-code'>Process All Orders</code> option that dequeues every pending Order in FIFO order and reports each processed ID.",
                                        "Reject a new Order when CustomerName is empty or whitespace while leaving the queue unchanged.",
                                        "Add an urgent-order warning when an Order contains ten or more items, but keep that Order in its original queue position.",
                                        "Create a helper that returns a snapshot array of pending Orders for reporting without exposing or modifying the Queue itself.")
                                },
                                new Paragraph
                                {
                                    Body = "Complete the exercises inside the Store Management System by adding a temporary practice method or menu option. Run the app, verify the behavior, and then delete any exercise-only code before continuing the course project. When you are ready, press the <b>View Source Code</b> button below to compare your implementation with the examples."
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
                                        "A <code class='inline-code'>Queue&lt;T&gt;</code> processes values in arrival order.",
                                        "<code class='inline-code'>Enqueue</code> joins the back, <code class='inline-code'>Peek</code> reads the front, and <code class='inline-code'>Dequeue</code> removes the front.",
                                        "The Try methods handle an empty Queue without throwing.",
                                        "Enumerating a Queue reveals processing order without changing it.",
                                        "The store's oldest pending Order is always processed first.")
                                },
                                new Paragraph
                                {
                                    Body = "The next chapter brings the course together by comparing arrays, lists, dictionaries, sets, stacks, and queues so you can choose a structure from the needs of a problem."
                                }
                            }
                        },
                        new Block
                        {
                            IsCourseCodePage = true,
                            Title = "Queue Exercise Answers",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph { Body = "These example answers all extend the Store Management System. Your method names and messages may differ." },
                                new Paragraph { Body = "<b>1. Verify FIFO processing</b>" },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "PendingOrders.Enqueue(new Order\r\n{\r\n    Id = \"ORD-101\", CustomerName = \"Maria\", ItemCount = 3, CreatedAt = DateTime.Now\r\n});\r\nPendingOrders.Enqueue(new Order\r\n{\r\n    Id = \"ORD-102\", CustomerName = \"John\", ItemCount = 1, CreatedAt = DateTime.Now\r\n});\r\nPendingOrders.Enqueue(new Order\r\n{\r\n    Id = \"ORD-103\", CustomerName = \"Aisha\", ItemCount = 5, CreatedAt = DateTime.Now\r\n});\r\n\r\nOrder processed = PendingOrders.Dequeue();\r\nConsole.WriteLine(processed.Id); // ORD-101"
                                },
                                new Paragraph { Body = "<b>2 and 3. Show Count and preview the next Order</b>" },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "AnsiConsole.MarkupLine($\"[grey]Pending: {PendingOrders.Count}[/]\");\r\n\r\nif (PendingOrders.TryPeek(out Order? nextOrder))\r\n{\r\n    AnsiConsole.MarkupLine(\r\n        $\"Next: {Markup.Escape(nextOrder.Id)} - {Markup.Escape(nextOrder.CustomerName)}\");\r\n}"
                                },
                                new Paragraph { Body = "<b>4. Report the remaining count before processing</b>" },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "int remainingAfterProcessing = PendingOrders.Count - 1;\r\nbool confirmed = AnsiConsole.Confirm(\r\n    $\"Process this order? {remainingAfterProcessing} will remain.\");"
                                },
                                new Paragraph { Body = "<b>5. Process every pending Order</b>" },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static void ProcessAllOrders()\r\n{\r\n    if (PendingOrders.Count == 0)\r\n    {\r\n        AnsiConsole.MarkupLine(\"[yellow]There are no pending orders.[/]\");\r\n        Pause();\r\n        return;\r\n    }\r\n\r\n    while (PendingOrders.TryDequeue(out Order? order))\r\n    {\r\n        AnsiConsole.MarkupLine(\r\n            $\"Processed {Markup.Escape(order.Id)}\");\r\n    }\r\n\r\n    Pause();\r\n}"
                                },
                                new Paragraph { Body = "<b>6. Validate CustomerName before enqueueing</b>" },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "string customerName = AnsiConsole.Prompt(\r\n    new TextPrompt&lt;string&gt;(\"Customer name:\")\r\n        .Validate(name =&gt; !string.IsNullOrWhiteSpace(name)\r\n            ? ValidationResult.Success()\r\n            : ValidationResult.Error(\"[red]Customer name is required.[/]\")));"
                                },
                                new Paragraph { Body = "<b>7. Warn about large Orders without changing position</b>" },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "foreach (Order order in PendingOrders)\r\n{\r\n    string warning = order.ItemCount &gt;= 10 ? \" [yellow]Large order[/]\" : string.Empty;\r\n    AnsiConsole.MarkupLine(\r\n        $\"{Markup.Escape(order.Id)}{warning}\");\r\n}"
                                },
                                new Paragraph { Body = "<b>8. Return a reporting snapshot</b>" },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static Order[] GetPendingOrderSnapshot()\r\n{\r\n    return PendingOrders.ToArray();\r\n}\r\n\r\nOrder[] snapshot = GetPendingOrderSnapshot();\r\n// Changing the array does not enqueue or dequeue Orders."
                                }
                            }
                        }
                    }
                },
                new Article
                {
                    Id = 500311,
                    CourseDisplayId = 12,
                    Title = "Choosing the Right Data Structure",
                    Slug = "choosing-right-data-structure",
                    Description = "Compare the collections from this course and choose them from the practical needs of a feature.",
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
                                    Body = "Knowing how to call collection methods is only part of the skill. The more important question is: <b>which collection represents this problem clearly?</b>"
                                },
                                new Paragraph
                                {
                                    Body = "This chapter brings together arrays, lists, dictionaries, HashSets, stacks, and queues. We will make choices using practical requirements rather than formal complexity analysis, then build the Store Summary that combines information from the whole application."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Start With the Problem, Not the Type",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Do not begin with ‘I want to use a Dictionary.’ Begin with ‘I need to find one Product by its unique SKU.’ The requirement leads to the collection, not the other way around."
                                },
                                new Paragraph
                                {
                                    Body = RedDotList(
                                        "What does one element represent?",
                                        "Can the number of elements change?",
                                        "Does order matter?",
                                        "Are duplicate values allowed?",
                                        "Is there a unique key that identifies each value?",
                                        "Must the newest or oldest value be processed next?",
                                        "Which operations does this feature perform most often?")
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Array: A Fixed Group With Positions",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Choose an array when the size is fixed or naturally known and indexed positions express the data well. The store's departments are established when the application starts and do not need Add or Remove operations."
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static readonly string[] Departments =\r\n[\r\n    \"Electronics\",\r\n    \"Groceries\",\r\n    \"Clothing\",\r\n    \"Home\",\r\n    \"Sports\"\r\n];"
                                },
                                new Paragraph
                                {
                                    Body = "If administrators needed to create and delete departments while the application was running, the fixed-size requirement would disappear and a different collection would become more appropriate."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "List<T>: An Ordered Collection That Changes",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Choose a List when values form an ordered sequence, duplicates may be acceptable, and the collection needs to grow or shrink. The store displays all active Products and allows users to add, update, and remove them."
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static readonly List&lt;Product&gt; Products = [];"
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Dictionary<TKey, TValue>: Lookup by a Unique Key",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Choose a Dictionary when a meaningful, unique key identifies a value. The user knows a SKU and expects it to locate one Product directly."
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static readonly Dictionary&lt;string, Product&gt; ProductsBySku =\r\n    Products.ToDictionary(\r\n        product =&gt; product.Sku,\r\n        StringComparer.OrdinalIgnoreCase);"
                                },
                                new Paragraph
                                {
                                    Body = "The dictionary complements the Product list rather than replacing its ordered display role. When two collections describe the same active Products, the application must keep them synchronized."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "HashSet<T>: Unique Membership",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Choose a HashSet when each value may appear at most once and the important question is whether a value belongs to the group. Product tags are unique, have no meaningful index, and benefit from case-insensitive membership."
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "public HashSet&lt;string&gt; Tags { get; } =\r\n    new(StringComparer.OrdinalIgnoreCase);"
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Stack<T>: Reverse the Latest Action",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Choose a Stack when the newest value must be processed first. Undo reverses the most recent outstanding removal, so removed Products follow last-in, first-out behavior."
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static readonly Stack&lt;Product&gt; RemovedProducts = new();"
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Queue<T>: Process in Arrival Order",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Choose a Queue when the oldest waiting value must be processed first. Pending Orders should be handled fairly in the order they arrived, so they follow first-in, first-out behavior."
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static readonly Queue&lt;Order&gt; PendingOrders = new();"
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Explain the Choices Like I Am 10",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    BackgroundColor = "#1C236D",
                                    FontColor = "#FFF",
                                    Body = "Imagine organizing a classroom.<br><br>An <b>Array</b> is a row of five assigned seats that never changes size. A <b>List</b> is the attendance sheet where students can be added or removed. A <b>Dictionary</b> is the teacher's folder that finds a student using their unique student number. A <b>HashSet</b> is the permission checklist where each permission appears only once. A <b>Stack</b> is a pile of returned books where the last book placed on top is picked up first. A <b>Queue</b> is the lunch line where the first student waiting is served first.<br><br>None is the best organizer for everything. Each one is useful because it follows a rule that matches a particular job."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "A Practical Decision Guide",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = RedDotList(
                                        "Fixed number of values with positions? Consider an array.",
                                        "Ordered collection that grows and shrinks? Consider a List.",
                                        "One value retrieved by a unique key? Consider a Dictionary.",
                                        "Unique values where membership matters? Consider a HashSet.",
                                        "Newest value must be processed first? Consider a Stack.",
                                        "Oldest waiting value must be processed first? Consider a Queue.")
                                },
                                new Paragraph
                                {
                                    Body = "These questions are starting points, not laws. Real applications may use more than one collection, create dedicated classes around them, or change designs as requirements evolve. The goal is to explain the choice from the behavior the feature needs."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "One Feature Can Use Several Structures",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "The active Product feature uses a List for ordered display and a Dictionary for SKU lookup. Each Product contains a HashSet for tags. Removing a Product moves the same object onto a Stack. These structures cooperate without becoming interchangeable."
                                },
                                new Paragraph
                                {
                                    Body = "When several collections represent overlapping state, centralize operations that update them. A method such as <code class='inline-code'>AddActiveProduct</code> or <code class='inline-code'>RemoveActiveProduct</code> reduces the chance that one collection is changed while another is forgotten."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Application: Add Store Summary to the Menu",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Add <code class='inline-code'>View Store Summary</code> after <code class='inline-code'>Manage Orders</code> in the main menu, then connect its switch case:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = ".AddChoices(\r\n    \"View Departments\",\r\n    \"Manage Products\",\r\n    \"Find Product by SKU\",\r\n    \"Manage Product Tags\",\r\n    \"Remove Product\",\r\n    \"Undo Last Removal\",\r\n    \"Manage Orders\",\r\n    \"View Store Summary\",\r\n    \"Exit\"));"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "case \"View Store Summary\":\r\n    ShowStoreSummary();\r\n    break;"
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Collect Every Unique Store Tag",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "The summary needs the number of unique tags used across all active Products. Build that result with a temporary HashSet:"
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static HashSet&lt;string&gt; GetUniqueStoreTags()\r\n{\r\n    var storeTags = new HashSet&lt;string&gt;(StringComparer.OrdinalIgnoreCase);\r\n\r\n    foreach (Product product in Products)\r\n    {\r\n        storeTags.UnionWith(product.Tags);\r\n    }\r\n\r\n    return storeTags;\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "The method combines each Product's tags without modifying those original sets. The returned HashSet contains every tag at most once."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Build the Store Summary",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static void ShowStoreSummary()\r\n{\r\n    AnsiConsole.Clear();\r\n\r\n    HashSet&lt;string&gt; storeTags = GetUniqueStoreTags();\r\n\r\n    var totals = new Table()\r\n        .Title(\"[green]Store Summary[/]\")\r\n        .AddColumn(\"Measure\")\r\n        .AddColumn(\"Total\")\r\n        .AddRow(\"Departments\", Departments.Length.ToString())\r\n        .AddRow(\"Active Products\", Products.Count.ToString())\r\n        .AddRow(\"Unique Store Tags\", storeTags.Count.ToString())\r\n        .AddRow(\"Removed Products\", RemovedProducts.Count.ToString())\r\n        .AddRow(\"Pending Orders\", PendingOrders.Count.ToString());\r\n\r\n    AnsiConsole.Write(totals);\r\n    AnsiConsole.WriteLine();\r\n\r\n    var productsByDepartment = new Table()\r\n        .Title(\"[green]Products by Department[/]\")\r\n        .AddColumn(\"Department\")\r\n        .AddColumn(\"Products\");\r\n\r\n    foreach (string department in Departments)\r\n    {\r\n        int productCount = Products.Count(\r\n            product =&gt; product.Department == department);\r\n\r\n        productsByDepartment.AddRow(\r\n            Markup.Escape(department),\r\n            productCount.ToString());\r\n    }\r\n\r\n    AnsiConsole.Write(productsByDepartment);\r\n    Pause();\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "The summary does not introduce another long-lived collection. It asks each existing structure for the information it owns and creates temporary reporting values where needed. Spectre.Console formats the result, but the collection choices determine where each number comes from."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Check the Design Against the Requirements",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = RedDotList(
                                        "Departments remain fixed and ordered in an array.",
                                        "Active Products can grow, shrink, and display in a List.",
                                        "A Product can be located by its unique SKU in a Dictionary.",
                                        "Each Product's tag membership remains unique in a HashSet.",
                                        "The newest removed Product is restored first from a Stack.",
                                        "The oldest pending Order is processed first from a Queue.")
                                },
                                new Paragraph
                                {
                                    Body = "This is the explanation your final README should provide. Naming the collection is not enough; connect it to the feature's requirement."
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
                                        "For every existing store field, write one sentence explaining why its collection matches its feature.",
                                        "Move active-product additions into an <code class='inline-code'>AddActiveProduct</code> helper that updates both Products and ProductsBySku.",
                                        "Move active-product restoration into a <code class='inline-code'>RestoreProduct</code> helper that validates and updates both active collections.",
                                        "Add an alphabetical list of every unique store tag to the Store Summary without modifying any Product's Tags.",
                                        "Add the ID and customer of the next pending Order to the summary without removing it from the Queue.",
                                        "Add the Name and SKU of the next removable-history Product to the summary without popping the Stack.",
                                        "Add a summary warning when Products.Count and ProductsBySku.Count disagree.",
                                        "Choose a collection for completed Order history, add it to the application, and explain why its behavior fits better than the alternatives.")
                                },
                                new Paragraph
                                {
                                    Body = "Complete the exercises inside the Store Management System by adding a temporary practice method or menu option. Run the app, verify the behavior, and then delete any exercise-only code before continuing the course project. When you are ready, press the <b>View Source Code</b> button below to compare your decisions with example solutions."
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
                                        "Choose a collection from the feature's required behavior.",
                                        "Order, uniqueness, key-based lookup, fixed size, and processing direction are practical decision points.",
                                        "One feature may use several structures for distinct responsibilities.",
                                        "Overlapping collections must be updated together.",
                                        "The Store Summary demonstrates how all six structures contribute to one coherent application.")
                                },
                                new Paragraph
                                {
                                    Body = "The final two chapters turn the Store Management System into your completed course project, then offer additional project ideas for more practice."
                                }
                            }
                        },
                        new Block
                        {
                            IsCourseCodePage = true,
                            Title = "Choosing Structures Exercise Answers",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = RedDotList(
                                        "Departments: array, because the first version uses a fixed ordered group.",
                                        "Products: List, because active Products are displayed in sequence and can be added or removed.",
                                        "ProductsBySku: Dictionary, because each unique SKU identifies one Product.",
                                        "Tags: HashSet, because duplicate tag membership is not allowed.",
                                        "RemovedProducts: Stack, because undo restores the latest removal first.",
                                        "PendingOrders: Queue, because the earliest waiting Order is processed first.")
                                },
                                new Paragraph { Body = "<b>2 and 3. Centralize active Product updates</b>" },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "private static void AddActiveProduct(Product product)\r\n{\r\n    if (!ProductsBySku.TryAdd(product.Sku, product))\r\n    {\r\n        throw new InvalidOperationException(\"The SKU is already active.\");\r\n    }\r\n\r\n    Products.Add(product);\r\n}\r\n\r\nprivate static bool RestoreProduct(Product product)\r\n{\r\n    if (ProductsBySku.ContainsKey(product.Sku))\r\n    {\r\n        return false;\r\n    }\r\n\r\n    Products.Add(product);\r\n    ProductsBySku.Add(product.Sku, product);\r\n    return true;\r\n}"
                                },
                                new Paragraph { Body = "<b>4, 5, and 6. Add detail to the summary</b>" },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "foreach (string tag in GetUniqueStoreTags().OrderBy(tag =&gt; tag))\r\n{\r\n    AnsiConsole.MarkupLine(Markup.Escape(tag));\r\n}\r\n\r\nif (PendingOrders.TryPeek(out Order? nextOrder))\r\n{\r\n    AnsiConsole.MarkupLine(\r\n        $\"Next order: {Markup.Escape(nextOrder.Id)} - {Markup.Escape(nextOrder.CustomerName)}\");\r\n}\r\n\r\nif (RemovedProducts.TryPeek(out Product? nextRestore))\r\n{\r\n    AnsiConsole.MarkupLine(\r\n        $\"Next restore: {Markup.Escape(nextRestore.Sku)} - {Markup.Escape(nextRestore.Name)}\");\r\n}"
                                },
                                new Paragraph { Body = "<b>7. Detect synchronization problems</b>" },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "if (Products.Count != ProductsBySku.Count)\r\n{\r\n    AnsiConsole.MarkupLine(\r\n        \"[red]Warning: active Product collections are out of sync.[/]\");\r\n}"
                                },
                                new Paragraph
                                {
                                    Body = "<b>8.</b> A <code class='inline-code'>List&lt;Order&gt;</code> is a reasonable completed-order history because completed Orders need to be retained and displayed in completion order, but they are no longer waiting for FIFO processing. A Dictionary could be added later if completed Orders also require direct lookup by ID."
                                }
                            }
                        }
                    }
                },
                new Article
                {
                    Id = 500312,
                    CourseDisplayId = 13,
                    Title = "Final Project",
                    Slug = "final-project",
                    Description = "Complete, review, explain, and submit the Store Management System.",
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
                                    Body = "You have built the Store Management System one structure at a time. The final project is to turn those chapter additions into a complete, coherent application that you can explain without relying on the course instructions."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Final Store Management Requirements",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = ExerciseList(
                                        "Display the store's fixed Departments.",
                                        "View, add, and update active Products.",
                                        "Find one Product using a unique SKU.",
                                        "Add and remove unique, case-insensitive Product tags.",
                                        "Remove a Product while keeping active collections synchronized.",
                                        "Undo the most recent outstanding Product removal.",
                                        "Create, view, and process pending Orders in arrival order.",
                                        "Display a Store Summary that combines information from all features.",
                                        "Handle empty collections, missing keys, duplicates, invalid values, and cancelled confirmations without crashing.")
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Application Quality Checklist",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = RedDotList(
                                        "Menus return to the correct parent menu and Exit closes the application.",
                                        "Product additions, removals, and restorations update every relevant collection.",
                                        "User-provided text is trimmed and escaped before Spectre.Console markup display.",
                                        "Prices, stock quantities, and item counts reject invalid negative or zero values where appropriate.",
                                        "Empty stacks and queues are handled with Try methods or explicit Count checks.",
                                        "Collection fields and helper methods have names that explain their roles.",
                                        "Spectre.Console remains presentation code; collection decisions remain visible in the application logic.")
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Write the README Explanation",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Add a section named <b>Data Structure Decisions</b> to the project README. For each structure, explain the application requirement that caused you to choose it."
                                },
                                new Paragraph
                                {
                                    IsCode = true,
                                    Body = "## Data Structure Decisions\r\n\r\n### Product lookup\r\nI used a Dictionary&lt;string, Product&gt; because each unique SKU identifies one Product.\r\nThe application can request the Product using the SKU rather than searching by list position.\r\n\r\n### Pending orders\r\nI used a Queue&lt;Order&gt; because Orders must be processed in the same order they arrive."
                                },
                                new Paragraph
                                {
                                    Body = "Do not write only ‘I used a Dictionary because dictionaries are good.’ Name the requirement: unique key lookup, uniqueness, fixed size, newest-first undo, or oldest-first processing."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Submitting Your Project",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "This course project is not an official standalone project in the roadmap. If you want to submit it for review, use the Freestyle Project submission page here: <a href='https://thecsharpacademy.com/project/100001/free-style' target='_blank'>Submit a Freestyle Project</a>."
                                },
                                new Paragraph
                                {
                                    Body = "Before submitting, publish the repository, include your screenshots and Data Structure Decisions section in the README, and verify that another person can follow the setup instructions from a clean clone."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Final Store Challenges",
                            CssClass = ExerciseBlockClass,
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = ExerciseList(
                                        "Refactor active Product changes so synchronization logic is never duplicated across menu methods.",
                                        "Add completed Order history and explain which collection you selected.",
                                        "Add Product search by tag while preserving tag uniqueness.",
                                        "Add low-stock reporting grouped by Department.",
                                        "Limit the removal history and explain what should happen to older undo entries.",
                                        "Add sample data that demonstrates every feature immediately after startup.",
                                        "Test every empty-state message by processing all Orders, removing all Products, and consuming the undo history.",
                                        "Ask another person to use the application without guidance and improve any confusing menu or message.")
                                }
                            }
                        },
                    }
                },
                new Article
                {
                    Id = 500313,
                    CourseDisplayId = 14,
                    Title = "More Practice",
                    Slug = "more-data-structures-practice",
                    Description = "Choose another console project and practise selecting collections without following a chapter recipe.",
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
                                    Body = "Completing the Store Management System once gives you a guided example. Building a similar application in a different domain helps you prove that you can make the collection decisions yourself."
                                },
                                new Paragraph
                                {
                                    Body = "Choose one or more of the project briefs below. They describe required behavior without prescribing every data structure, so you must decide what fits and explain why."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "How to Approach Another Practice Project",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = RedDotList(
                                        "Write the user-visible features before choosing collections.",
                                        "Identify what one element represents in each feature.",
                                        "Ask the practical decision questions from the previous chapter.",
                                        "Choose the smallest set of collections that represents the behavior clearly.",
                                        "Build one working feature at a time.",
                                        "Explain every choice in the README and note any trade-offs or synchronization requirements.")
                                }
                            }
                        },
                        new Block
                        {
                            Title = "More Final Projects for Practice",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Choose one project that interests you. The briefs intentionally describe behavior without prescribing every collection. Make the decisions yourself, then justify them in the README."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Practice Idea 1: Library Service Desk",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = ExerciseList(
                                        "Maintain a fixed set of library sections.",
                                        "Add, update, remove, and display Books.",
                                        "Find a Book using its unique ISBN.",
                                        "Assign unique genres or keywords to each Book.",
                                        "Undo the latest Book removal.",
                                        "Process reservation requests in arrival order.",
                                        "Produce a summary and explain every collection choice.")
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Practice Idea 2: Help Desk Ticket Manager",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = ExerciseList(
                                        "Maintain a fixed list of support categories.",
                                        "Create and display support Tickets.",
                                        "Find a Ticket using its unique ID.",
                                        "Assign unique labels such as billing, urgent, and login.",
                                        "Undo the latest Ticket deletion.",
                                        "Process normal Tickets in arrival order.",
                                        "Report open, deleted, and waiting Ticket totals.")
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Practice Idea 3: Restaurant Order Desk",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = ExerciseList(
                                        "Maintain fixed dining areas or menu categories.",
                                        "Manage available MenuItems.",
                                        "Find a MenuItem using its unique code.",
                                        "Store unique dietary labels for each MenuItem.",
                                        "Undo the most recent MenuItem removal.",
                                        "Process kitchen Orders in the sequence they were submitted.",
                                        "Display a restaurant summary and explain the structures used.")
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Practice Idea 4: Event Registration System",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = ExerciseList(
                                        "Maintain fixed ticket types or event tracks.",
                                        "Register, update, remove, and display Attendees.",
                                        "Find one Attendee using a unique registration code.",
                                        "Assign unique session selections or interests.",
                                        "Undo the latest registration cancellation.",
                                        "Process a check-in waiting line in arrival order.",
                                        "Summarize registrations by ticket type.")
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Practice Idea 5: Warehouse Dispatch Console",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = ExerciseList(
                                        "Maintain fixed warehouse zones.",
                                        "Manage inventory Items and stock quantities.",
                                        "Find an Item using its unique stock code.",
                                        "Assign unique handling labels such as fragile or refrigerated.",
                                        "Undo the latest Item removal.",
                                        "Process dispatch requests in arrival order.",
                                        "Report inventory, removed Items, and pending dispatches.")
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Make the Practice Project Your Own",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "You may also invent a project around a hobby or real problem. Keep the first version in memory, console-based, and small enough to finish. A completed application with six well-explained decisions teaches more than an enormous unfinished design."
                                },
                                new Paragraph
                                {
                                    Body = "Change names, presentation, and optional features freely, but preserve the central challenge: choose structures because their behavior matches the problem."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Submit a Practice Project",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    BackgroundColor = "#1C236D",
                                    FontColor = "#FFF",
                                    Body = "Each project in this chapter can be submitted through the Academy as a <b>Freestyle Project</b>. Create a public repository with a clear README and screenshots, then use the <a href='https://thecsharpacademy.com/project/100001/free-style' target='_blank'>Freestyle Project submission page</a> when you are ready for review."
                                },
                                new Paragraph
                                {
                                    Body = "You can submit more than one practice project. Give each project its own repository and explain its data-structure decisions in its README."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Submission Checklist",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = RedDotList(
                                        "The project builds and runs without warnings introduced by your code.",
                                        "Every required menu option works from a clean application start.",
                                        "Invalid and empty states are handled without crashing.",
                                        "The README explains collection choices from requirements.",
                                        "The repository contains no secrets, generated build folders, or unrelated files.",
                                        "Screenshots show the main menu and several completed features.",
                                        "You can explain the difference between every structure used without reading the course text.")
                                }
                            }
                        },
                        new Block
                        {
                            Title = "What You Can Do Now",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = RedDotList(
                                        "Represent a fixed group with an array.",
                                        "Manage an ordered collection that grows and shrinks with a List.",
                                        "Retrieve values through meaningful unique keys with a Dictionary.",
                                        "Guarantee unique membership with a HashSet.",
                                        "Reverse the latest outstanding action with a Stack.",
                                        "Process waiting work in arrival order with a Queue.",
                                        "Explain a collection choice from the behavior a feature requires.")
                                },
                                new Paragraph
                                {
                                    Body = "That final skill matters most. Collection syntax can always be looked up; recognizing the shape of a problem is what allows you to design a clear solution."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Where to Go From Here",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    Body = "Complete at least one additional project without following a chapter recipe. Start with features, choose collections from their requirements, and document your reasoning. If the first design feels awkward, revise it; changing a collection after learning more about the problem is part of software development."
                                },
                                new Paragraph
                                {
                                    Body = "A future <b>Data Structures and Algorithms</b> course can take you deeper into implementing structures, analysing their behavior, comparing algorithms, and optimizing solutions. You now have the practical foundation that advanced study will build upon."
                                }
                            }
                        },
                        new Block
                        {
                            Title = "Course Complete",
                            Paragraphs = new List<Paragraph>
                            {
                                new Paragraph
                                {
                                    BackgroundColor = "#1C236D",
                                    FontColor = "#FFF",
                                    Body = "<b>Congratulations - you completed Beginner Data Structures in C#.</b><br><br>You began with an empty console application and developed a coherent Store Management System using six collection types. More importantly, every structure entered the application for a reason.<br><br>Build another project, submit it as a Freestyle Project, and keep practising until choosing a collection feels like describing the problem rather than remembering a rule."
                                }
                            }
                        }
                    }
                }
            }
        };
    }
}
