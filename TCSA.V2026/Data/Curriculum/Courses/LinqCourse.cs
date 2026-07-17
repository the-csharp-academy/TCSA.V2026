using TCSA.V2026.Data.Models;
using static TCSA.V2026.Helpers.CourseContentHelper;

namespace TCSA.V2026.Data.Curriculum;

public class LinqCourse
{
    public static Course GetLinqCourse()
    {
        return new Course
        {
            Id = 8,
            Title = "LINQ Fundamentals",
            Description = "Learn how to query, filter, sort, group, and transform data with modern C#.",
            ImgUrl = "icons8-magnifying-glass-64.png",
            Articles = new List<Article>
            {
                new Article
                {
                        Id = 500249,
                        CourseDisplayId = 1,
                        Title = "About This Course",
                        Slug = "about-this-linq-course",
                        Description = "Understand who this course is for, how the lessons are structured, and how to get the most out of the exercises.",
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
                                        Body = "Welcome to <b>LINQ Fundamentals</b>. This course is designed to help you understand one of the most useful features in modern C#: <b>Language Integrated Query</b>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Before we start writing queries, we'll spend a few short lessons explaining what LINQ is, why Microsoft added it to C#, and what kinds of problems it helps us solve. The goal is not to memorize method names. The goal is to learn how to ask clear questions about data."
                                    },
                                    new Paragraph
                                    {
                                        Body = "After that brief introduction, we'll move into practical LINQ methods and apply them to a small course project. By the end, you'll have used LINQ to filter, project, sort, aggregate, inspect, and reshape collections of data."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Who This Course Is For",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "This course is for students who already know the fundamentals of C# and want to become more comfortable working with collections. You do not need to be advanced, but you should already understand variables, methods, classes, loops, conditionals, lists, and basic object-oriented programming."
                                    },
                                    new Paragraph
                                    {
                                        Body = "This course is <b>not</b> for absolute beginners. If you're still learning basic C# syntax, start with the <a href='/project/75/freecodecamp-certification' target='_blank'>FreeCodeCamp C# Certification</a> and the <a href='/project/53/math-game' target='_blank'>Math Game project</a> first. Those will give you the foundation you need to get more out of this course."
                                    },
                                    new Paragraph
                                    {
                                        Body = "LINQ becomes much easier when you already understand the problem it is trying to simplify: working with collections using loops, conditions, and temporary variables. If those ideas still feel shaky, spend more time with fundamentals before coming back here."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "How Each Chapter Is Structured",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Most chapters follow the same pattern:"
                                    },
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "<b>Explanation</b>: We introduce the LINQ method or concept and explain what problem it solves.",
                                            "<b>Application</b>: We apply the method in the course project so you can see it working with realistic data.",
                                            "<b>Exercises</b>: You practice the method yourself with small tasks designed to build fluency.")
                                    },
                                    new Paragraph
                                    {
                                        Body = "This structure is deliberate. Reading an explanation helps, but it is not enough. You need to see the method in context, then use it yourself until the syntax starts to feel natural."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "About The Exercises",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "The exercises are technically optional, but you should treat them as part of the course. LINQ is learned through repetition. Skipping the exercises may make the lessons feel faster, but it will also make the knowledge less durable."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Go through everything thoroughly. Type the code by hand, even when copying would be faster. The small friction of typing each word helps you remember the method names, lambda syntax, and query flow."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Avoid the temptation to use AI to solve the exercises for you. AI can be useful when you're stuck, but if it does the thinking and typing, you lose the practice this course is trying to give you. Use it to ask for explanations, hints, or comparisons after you've made a real attempt."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Practice Project",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "At the end of the course, you'll complete a practice project that brings the course together. It will ask you to use the LINQ methods you've learned to build better reports from the stock data in the course project."
                                    },
                                    new Paragraph
                                    {
                                        Body = "The final project is where the separate methods start becoming a practical skill. Take it seriously, build it step by step, and use it as proof that you can apply LINQ outside isolated examples."
                                    }
                                }
                            }
                        }
                },
                new Article
                {
                        Id = 500250,
                        CourseDisplayId = 2,
                        Title = "What Is LINQ?",
                        Slug = "what-is-linq",
                        Description = "Learn what LINQ is, why it was added to C#, and the kinds of problems it helps us solve.",
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
                                        Body = "Now that you know how the course is structured, we'll learn what LINQ is, why it became such an important part of modern C#, and the kinds of everyday data questions it helps us answer."
                                    },
                                    new Paragraph
                                    {
                                        Body = "<b>LINQ</b> stands for <b>Language Integrated Query</b>. It is a feature built into C# that allows us to query, filter, sort, group, and transform data using a consistent syntax."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Before LINQ was introduced, developers often needed to write loops to search through collections of data. That worked, but it could get repetitive and noisy very quickly. LINQ gives us a more expressive way to perform these operations, making our code easier to read, understand, and maintain."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Think of LINQ as a toolbox full of methods that help you ask questions about your data."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Questions LINQ Can Answer",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "Which students passed the exam?",
                                            "Which products cost more than $100?",
                                            "What is the average score?",
                                            "How many coding sessions happened this month?")
                                    },
                                    new Paragraph
                                    {
                                        Body = "These are all common tasks that LINQ helps us solve. Instead of manually tracking counters, temporary lists, and nested conditions, we can use clear query operations that describe what we want from the data."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "A Brief History of LINQ",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "LINQ was introduced by Microsoft in <b>2007</b> as part of <b>C# 3.0</b> and <b>.NET Framework 3.5</b>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Before LINQ, developers had to use different approaches depending on where their data was stored:"
                                    },
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "<b>SQL</b> for databases",
                                            "<b>XPath</b> for XML documents",
                                            "<b>Loops</b> for collections",
                                            "<b>Custom code</b> for other data sources")
                                    },
                                    new Paragraph
                                    {
                                        Body = "Microsoft wanted a single, consistent way to work with data regardless of its source. LINQ was the solution."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Today, LINQ is considered one of the most important features of modern C# and is used extensively in professional software development."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Why This Matters",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "You will use LINQ constantly when working with lists, arrays, files, databases, API responses, and many other sources of data. Once it clicks, it becomes one of those C# features you reach for without thinking."
                                    },
                                    new Paragraph
                                    {
                                        Body = "In the next lessons, we'll start using LINQ with simple collections so you can see the difference between writing manual loops and writing expressive LINQ queries."
                                    }
                                }
                            }
                        }
                },
                new Article
                {
                        Id = 500251,
                        CourseDisplayId = 3,
                        Title = "Why Did Microsoft Create LINQ?",
                        Slug = "why-did-microsoft-create-linq",
                        Description = "Understand the problems LINQ was designed to solve, from boilerplate code to inconsistent data querying.",
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
                                        Body = "Microsoft created <b>LINQ</b> to solve several common problems developers faced when working with data in C#. Before LINQ, even simple data operations often required extra loops, temporary collections, and different query approaches depending on where the data came from."
                                    },
                                    new Paragraph
                                    {
                                        Body = "LINQ was designed to make everyday data questions easier to express, easier to read, and more consistent across different kinds of data sources."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Problem #1: Too Much Boilerplate Code",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Suppose we want all numbers greater than <code class='inline-code'>5</code> from a collection. Without LINQ, we might write something like this:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "List<int> result = new();\r\n\r\nforeach (int number in numbers)\r\n{\r\n    if (number > 5)\r\n    {\r\n        result.Add(number);\r\n    }\r\n}"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This works, but there is a lot of code dedicated to a simple task. We create a result list, loop through every item, check a condition, and manually add matching values."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Nothing about that code is especially difficult, but it adds noise. LINQ helps us remove that noise so the intention is easier to see."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Problem #2: Readability",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "When reading code, we usually care about <b>what</b> the code does before we care about <b>how</b> it does it. Compare the previous example with this LINQ version:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var result = numbers.Where(n => n > 5);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Most developers can immediately understand the intention: <b>give me all numbers greater than 5</b>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "That is one of LINQ's biggest strengths. It lets code read closer to the question we are asking about the data."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Problem #3: Consistency",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Before LINQ, developers often switched between multiple querying technologies and styles. LINQ provides a consistent way to work with:"
                                    },
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "Lists",
                                            "Arrays",
                                            "Dictionaries",
                                            "Databases",
                                            "XML",
                                            "Many other data sources")
                                    },
                                    new Paragraph
                                    {
                                        Body = "Once you learn LINQ, the same concepts apply almost everywhere. The data source may change, but many of the querying ideas stay familiar."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Real-World Example",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Imagine you're building a <b>Coding Tracker</b> application. You have a collection of coding sessions:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "List<CodingSession> sessions;"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Questions you might ask include:"
                                    },
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "Which sessions lasted more than one hour?",
                                            "What was the longest session?",
                                            "How many sessions were recorded this month?",
                                            "What is the average session duration?")
                                    },
                                    new Paragraph
                                    {
                                        Body = "These are exactly the types of problems LINQ was designed to solve. As the course continues, we'll learn the LINQ methods that help answer these questions clearly and with much less boilerplate code."
                                    }
                                }
                            }
                        }
                },
                new Article
                {
                        Id = 500252,
                        CourseDisplayId = 4,
                        Title = "LINQ vs Loops",
                        Slug = "linq-vs-loops",
                        Description = "Compare a traditional loop with LINQ and learn when each approach makes sense.",
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
                                        Body = "Let's compare a traditional loop with LINQ. Both approaches are useful, and both can solve the same problem. The goal here is to understand how LINQ changes the way we express our intention."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Suppose we have a list of students:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "List<Student> students =\r\n[\r\n    new Student(\"John\", 85),\r\n    new Student(\"Sarah\", 92),\r\n    new Student(\"Tom\", 67)\r\n];"
                                    },
                                    new Paragraph
                                    {
                                        Body = "We want all students with a score above <code class='inline-code'>80</code>."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Using a Loop",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "List<Student> highScorers = new();\r\n\r\nforeach (Student student in students)\r\n{\r\n    if (student.Score > 80)\r\n    {\r\n        highScorers.Add(student);\r\n    }\r\n}"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This loop is clear enough, especially if you already know loops well. We create an empty list, inspect each student, check the score, and add the matching students to the result."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Using LINQ",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var highScorers = students.Where(s => s.Score > 80);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Both solutions produce the same result. The difference is that LINQ focuses on the intent: <b>find students with scores above 80</b>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "This often makes code shorter and easier to understand because the query reads closer to the question we are asking."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Does LINQ Replace Loops?",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "No. Loops are still extremely important. LINQ is simply another tool available to us."
                                    },
                                    new Paragraph
                                    {
                                        Body = "A good developer knows when to use each approach. As a general guideline:"
                                    },
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "Use loops when performing complex operations or modifying data.",
                                            "Use LINQ when querying, filtering, sorting, grouping, or transforming data.")
                                    },
                                    new Paragraph
                                    {
                                        Body = "Over time, you'll develop a feel for which approach is most appropriate. For now, remember that LINQ is not here to erase loops. It is here to make data queries easier to express."
                                    }
                                }
                            }
                        }
                },
                new Article
                {
                        Id = 500253,
                        CourseDisplayId = 5,
                        Title = "The Course Project",
                        Slug = "the-course-project",
                        Description = "Clone the LINQ study project and learn how the starter code is organized.",
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
                                        Body = "For the rest of this course, we'll use a small console application built specifically for practicing LINQ. The project gives us a realistic data set: stocks, trades, prices, quantities, dates, and buy/sell operations."
                                    },
                                    new Paragraph
                                    {
                                        Body = "You can find the repository here: <a href='https://github.com/TheCSharpAcademy/TCSA.Study.Linq' target='_blank' style='color: #a63a3a; text-decoration: underline;'><b>TheCSharpAcademy/TCSA.Study.Linq</b></a>."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Clone the Project",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Open a terminal in the folder where you keep your learning projects, then run:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "git clone https://github.com/TheCSharpAcademy/TCSA.Study.Linq.git"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Move into the repository:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "cd TCSA.Study.Linq"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Run the project:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "dotnet run --project TCSA.Study.Linq"
                                    },
                                    new Paragraph
                                    {
                                        Body = "When the app starts, you'll see a small menu that lets you print the stock watchlist or print all trades."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "What This App Does",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "The application is a simple market data viewer. It loads a fixed list of stocks, generates 500 fake trades, and prints the data in console tables using <code class='inline-code'>Spectre.Console</code>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "This gives us enough data to practice useful LINQ operations without needing a database, API, or complicated setup."
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
                                        Body = "<code class='inline-code'>Spectre.Console</code> is a popular library for building better-looking console applications in .NET. Instead of printing plain text line by line, it lets us create menus, tables, colors, prompts, panels, and other polished console UI elements."
                                    },
                                    new Paragraph
                                    {
                                        Body = "In this project, Spectre.Console is mainly used for presentation. It helps display the stock and trade data clearly, but it is not the main topic of the course. Our focus will be LINQ: querying, filtering, sorting, grouping, and transforming the data."
                                    },
                                    new Paragraph
                                    {
                                        Body = "You'll see a few Spectre.Console types while exploring the code:"
                                    },
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "<code class='inline-code'>AnsiConsole</code>: Writes styled output to the console and shows prompts.",
                                            "<code class='inline-code'>SelectionPrompt</code>: Creates the interactive menu shown when the app starts.",
                                            "<code class='inline-code'>Table</code>: Builds the formatted tables used to display stocks and trades.",
                                            "<code class='inline-code'>Markup</code>: Allows simple styling inside console text, such as colors or emphasis.")
                                    },
                                    new Paragraph
                                    {
                                        Body = "You do not need to master Spectre.Console to complete this course. Treat it as the display layer: it makes the app easier to use while LINQ does the data work behind the scenes."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Project Files",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "<code class='inline-code'>TCSA.Study.Linq.slnx</code>: The solution file. Open this in Visual Studio if you prefer working from the IDE.",
                                            "<code class='inline-code'>TCSA.Study.Linq.csproj</code>: The project file. It targets <code class='inline-code'>net10.0</code> and references <code class='inline-code'>Spectre.Console</code> for console UI tables and menus.",
                                            "<code class='inline-code'>Program.cs</code>: The entry point of the app. It loads stocks, flattens their nested trades into a separate trades list, shows the menu, and calls the table printer based on the selected option.",
                                            "<code class='inline-code'>Models/Stock.cs</code>: Represents a stock with a symbol, company name, sector, and nested list of trades.",
                                            "<code class='inline-code'>Models/Trade.cs</code>: Represents a trade with an id, symbol, date, price, quantity, and buy/sell type.",
                                            "<code class='inline-code'>Models/Enums/TradeType.cs</code>: Defines the two possible trade types: <code class='inline-code'>Buy</code> and <code class='inline-code'>Sell</code>.",
                                            "<code class='inline-code'>Seeders/StockSeeder.cs</code>: Creates the starting list of stocks, generates trades, and attaches each stock's matching trades.",
                                            "<code class='inline-code'>Seeders/TradeSeeder.cs</code>: Generates sample trades using the stock symbols. This is where most of our LINQ practice data comes from.",
                                            "<code class='inline-code'>Printing/TablePrinter.cs</code>: Contains helper methods that print stocks and trades as formatted console tables.")
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "How We'll Use It",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "In upcoming lessons, we'll write LINQ queries against the <code class='inline-code'>stocks</code> and <code class='inline-code'>trades</code> collections. For example, we'll filter trades, sort results, calculate totals, flatten nested data, and transform objects into new shapes."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Before moving on, clone the repository, run the app once, and take a few minutes to open each file. You don't need to understand every line yet. The goal is to become familiar with the project structure."
                                    }
                                }
                            }
                        }
                },
                new Article
                {
                        Id = 500254,
                        CourseDisplayId = 6,
                        Title = "Filtering Data With Where",
                        Slug = "filtering-data-with-where",
                        Description = "Learn how the LINQ Where method filters collections using conditions.",
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
                                        Body = "The <code class='inline-code'>Where</code> method is one of the most important LINQ methods you'll use. It allows us to filter a collection and keep only the items that match a condition."
                                    },
                                    new Paragraph
                                    {
                                        Body = "If LINQ helps us ask questions about data, <code class='inline-code'>Where</code> is the method we use when the question starts with <b>which items match this rule?</b>"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "What Where Does",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "<code class='inline-code'>Where</code> looks at each item in a collection and evaluates a condition. If the condition returns <code class='inline-code'>true</code>, the item is included in the result. If the condition returns <code class='inline-code'>false</code>, the item is skipped."
                                    },
                                    new Paragraph
                                    {
                                        Body = "For example, if we have a list of numbers and we only want numbers greater than 5, we can write:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var result = numbers.Where(number => number > 5);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This means: <b>go through the numbers collection and keep each number where the number is greater than 5</b>."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "The Predicate",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "The condition passed to <code class='inline-code'>Where</code> is called a <b>predicate</b>. A predicate is a function that receives one item and returns a boolean value: <code class='inline-code'>true</code> or <code class='inline-code'>false</code>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "In this example, the predicate is <code class='inline-code'>number => number > 5</code>:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var result = numbers.Where(number => number > 5);"
                                    },
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "<code class='inline-code'>number</code> represents the current item being checked.",
                                            "<code class='inline-code'>=></code> separates the input from the condition.",
                                            "<code class='inline-code'>number > 5</code> is the condition that must be true for the item to stay in the result.")
                                    },
                                    new Paragraph
                                    {
                                        Body = "You'll often hear this kind of expression called a <b>lambda expression</b>. We'll keep practicing lambdas throughout the course, but for now you can read them as small inline rules."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Where Returns a New Sequence",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "<code class='inline-code'>Where</code> does not change the original collection. Instead, it returns a new sequence containing the matching items."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "List<int> numbers = [1, 4, 6, 9];\r\n\r\nvar filteredNumbers = numbers.Where(number => number > 5);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "After this code runs, <code class='inline-code'>numbers</code> still contains <code class='inline-code'>1, 4, 6, 9</code>. The query result contains only <code class='inline-code'>6</code> and <code class='inline-code'>9</code>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "This is important because LINQ is usually used to query data, not mutate it. If you want a concrete list from the result, you can call <code class='inline-code'>ToList()</code>:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "List<int> filteredNumbers = numbers\r\n    .Where(number => number > 5)\r\n    .ToList();"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Filtering Objects",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "<code class='inline-code'>Where</code> becomes even more useful when we filter objects. Suppose we have students with names and scores:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "List<Student> students =\r\n[\r\n    new Student(\"John\", 85),\r\n    new Student(\"Sarah\", 92),\r\n    new Student(\"Tom\", 67)\r\n];"
                                    },
                                    new Paragraph
                                    {
                                        Body = "To get only students who scored above 80, we can filter by the <code class='inline-code'>Score</code> property:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var highScorers = students.Where(student => student.Score > 80);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "The result includes John and Sarah, because their scores match the condition. Tom is skipped because his score is below 80."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Combining Conditions",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "A <code class='inline-code'>Where</code> predicate can include more than one condition. We can use the same boolean operators we already know from regular C#:"
                                    },
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "<code class='inline-code'>&&</code>: both conditions must be true.",
                                            "<code class='inline-code'>||</code>: at least one condition must be true.",
                                            "<code class='inline-code'>!</code>: reverses a boolean condition.")
                                    },
                                    new Paragraph
                                    {
                                        Body = "For example, this query keeps students with a score above 80 whose name starts with <code class='inline-code'>S</code>:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var result = students.Where(student =>\r\n    student.Score > 80 && student.Name.StartsWith(\"S\"));"
                                    },
                                    new Paragraph
                                    {
                                        Body = "You can make predicates as specific as the problem requires, but try to keep them readable. When a condition gets too complex, it can be moved into a separate method with a clear name."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Using Where in the Course Project",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "In the LINQ study project, we'll use <code class='inline-code'>Where</code> with the <code class='inline-code'>stocks</code> and <code class='inline-code'>trades</code> collections. Open <code class='inline-code'>Program.cs</code> and look near the top of the file, right after these lines:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "List<Stock> stocks = StockSeeder.GetStocks();\r\nList<Trade> trades = stocks\r\n    .SelectMany(stock => stock.Trades)\r\n    .ToList();"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This is our sandbox space for now. Write your practice queries under those variables and before the menu code starts. That way, when you choose <b>Print all trades</b>, you can immediately see how your query changed the data being displayed."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "List<Stock> stocks = StockSeeder.GetStocks();\r\nList<Trade> trades = stocks\r\n    .SelectMany(stock => stock.Trades)\r\n    .ToList();\r\n\r\n// SANDBOX - Write your code here\r\n\r\ntrades = trades.Where(trade => trade.Symbol == \"AAPL\").ToList();\r\n\r\n//\r\n\r\nconst string stockOption = \"Print stocks\";\r\nconst string tradeOption = \"Print all trades\";\r\nconst string exitOption = \"Exit\";"
                                    },
                                    new Paragraph
                                    {
                                        Body = "In this example, we replace the original <code class='inline-code'>trades</code> list with a filtered list that only contains Apple trades. The call to <code class='inline-code'>ToList()</code> is important because <code class='inline-code'>trades</code> is a <code class='inline-code'>List&lt;Trade&gt;</code>, while <code class='inline-code'>Where</code> by itself returns a query sequence."
                                    },
                                    new Paragraph
                                    {
                                        Body = "The next examples use the <code class='inline-code'>TradeType</code> enum. If <code class='inline-code'>Program.cs</code> does not recognise <code class='inline-code'>TradeType</code>, add this using statement at the top of the file:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "using TCSA.Study.Linq.Models.Enums;"
                                    },
                                    new Paragraph
                                    {
                                        Body = "You can swap that line for different filters. For example, to keep only buy trades:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "trades = trades.Where(trade => trade.Type == TradeType.Buy).ToList();"
                                    },
                                    new Paragraph
                                    {
                                        Body = "To show only larger trades, filter by quantity:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "trades = trades.Where(trade => trade.Quantity >= 500).ToList();"
                                    },
                                    new Paragraph
                                    {
                                        Body = "You can also combine conditions. This query keeps only Apple buy trades with a quantity of at least 500:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "trades = trades\r\n    .Where(trade => trade.Symbol == \"AAPL\" &&\r\n                    trade.Type == TradeType.Buy &&\r\n                    trade.Quantity >= 500)\r\n    .ToList();"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Each query follows the same pattern: choose the collection, call <code class='inline-code'>Where</code>, provide a predicate that describes which items should remain, and call <code class='inline-code'>ToList()</code> when assigning the result back to a list."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Deferred Execution",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "One detail that surprises many beginners is that <code class='inline-code'>Where</code> uses <b>deferred execution</b>. This means the query is not actually evaluated at the moment you create it. It is evaluated when you loop over it, print it, call <code class='inline-code'>ToList()</code>, call <code class='inline-code'>Count()</code>, or otherwise ask for the results."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var query = numbers.Where(number => number > 5);\r\n\r\nforeach (int number in query)\r\n{\r\n    Console.WriteLine(number);\r\n}"
                                    },
                                    new Paragraph
                                    {
                                        Body = "In this example, the filtering happens when the <code class='inline-code'>foreach</code> loop reads from <code class='inline-code'>query</code>. This behavior is powerful because it allows LINQ to combine multiple operations efficiently, but it also means you should use <code class='inline-code'>ToList()</code> when you want to capture the results immediately."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Common Mistakes",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "Expecting <code class='inline-code'>Where</code> to modify the original collection.",
                                            "Forgetting to call <code class='inline-code'>ToList()</code> when a concrete list is needed.",
                                            "Writing predicates that are technically correct but hard to read.",
                                            "Using <code class='inline-code'>Where</code> when you only need a single item. Later, we'll learn methods like <code class='inline-code'>First</code>, <code class='inline-code'>FirstOrDefault</code>, and <code class='inline-code'>Single</code>.")
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
                                        Body = "Open the LINQ study project and practice writing <code class='inline-code'>Where</code> queries in the sandbox space in <code class='inline-code'>Program.cs</code>: after the <code class='inline-code'>stocks</code> and <code class='inline-code'>trades</code> collections are created, but before the menu constants. Run the app after each query and choose the relevant print option to inspect the result."
                                    },
                                    new Paragraph
                                    {
                                        Body = ExerciseList(
                                            "Filter the stocks collection to show only stocks in the <code class='inline-code'>Technology</code> sector.",
                                            "Filter the trades collection to show only trades with the symbol <code class='inline-code'>MSFT</code>.",
                                            "Filter the trades collection to show only <code class='inline-code'>Buy</code> trades.",
                                            "Filter the trades collection to show only trades where <code class='inline-code'>Quantity</code> is greater than or equal to <code class='inline-code'>500</code>.",
                                            "Filter the trades collection to show only trades where <code class='inline-code'>Price</code> is greater than <code class='inline-code'>200</code>.",
                                            "Filter the trades collection to show only <code class='inline-code'>Sell</code> trades for <code class='inline-code'>TSLA</code>.",
                                            "Filter the trades collection to show only trades from the last 30 days.",
                                            "Create a query that combines at least three conditions, such as symbol, trade type, and minimum quantity.")
                                    },
                                    new Paragraph
                                    {
                                        Body = "After completing the exercises, compare your solutions with the pattern from this lesson: collection, <code class='inline-code'>Where</code>, predicate. If that pattern is clear, you're ready to start chaining LINQ methods together."
                                    }
                                }
                            }
                        }
                },
                new Article
                {
                        Id = 500256,
                        CourseDisplayId = 7,
                        Title = "Transforming Data With Select",
                        Slug = "transforming-data-with-select",
                        Description = "Learn how to use Select to transform items from one shape into another.",
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
                                        Body = "The <code class='inline-code'>Select</code> method is used to transform data. While <code class='inline-code'>Where</code> decides which items stay in a sequence, <code class='inline-code'>Select</code> decides what each item becomes."
                                    },
                                    new Paragraph
                                    {
                                        Body = "This is one of the most important ideas in LINQ. We often start with objects that contain many properties, but the current task only needs one value or a smaller shape."
                                    },
                                    new Paragraph
                                    {
                                        Body = "In plain English, <code class='inline-code'>Select</code> means: <b>for each item, give me this piece of information</b>."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "What Select Does",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Suppose we have a collection of students. Each student has a name and a score:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var students = new[]\r\n{\r\n    new Student(\"John\", 85),\r\n    new Student(\"Sarah\", 92),\r\n    new Student(\"Tom\", 67)\r\n};"
                                    },
                                    new Paragraph
                                    {
                                        Body = "If we only want the names, we can use <code class='inline-code'>Select</code>:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var names = students.Select(student => student.Name);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This query does not return full student objects. It returns a sequence of names: <code class='inline-code'>John</code>, <code class='inline-code'>Sarah</code>, and <code class='inline-code'>Tom</code>."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "The Selector",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "The expression passed to <code class='inline-code'>Select</code> is often called a <b>selector</b>. A selector describes what value should be produced for each item."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var names = students.Select(student => student.Name);"
                                    },
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "<code class='inline-code'>student</code> represents the current item.",
                                            "<code class='inline-code'>=></code> separates the input from the output expression.",
                                            "<code class='inline-code'>student.Name</code> is the value we want from each student.")
                                    },
                                    new Paragraph
                                    {
                                        Body = "With <code class='inline-code'>Where</code>, the lambda must return <code class='inline-code'>true</code> or <code class='inline-code'>false</code>. With <code class='inline-code'>Select</code>, the lambda can return almost anything: a string, number, object, calculation, or new shape."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Selecting a Single Property",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "The most common beginner use of <code class='inline-code'>Select</code> is extracting one property from each object."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var scores = students.Select(student => student.Score);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Now <code class='inline-code'>scores</code> contains only the score values. This is useful when you want to print a property, check whether a value exists, calculate an average later, or pass a simpler sequence to another method."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Selecting a Calculated Value",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "<code class='inline-code'>Select</code> can also return a calculated value. The output does not have to be a property that already exists."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var curveScores = students.Select(student => student.Score + 5);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This produces a new sequence where every score has 5 points added. The original students are not changed. LINQ is creating projected values from the original data."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Selecting a New Shape",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Sometimes we want more than one value, but we still do not need the full original object. In that case, we can project each item into a new shape."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var studentSummaries = students.Select(student => new\r\n{\r\n    student.Name,\r\n    Passed = student.Score >= 70\r\n});"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This creates a sequence of anonymous objects. Each result has a <code class='inline-code'>Name</code> and a <code class='inline-code'>Passed</code> value. This is very common in real applications when preparing data for reports, tables, API responses, or UI screens."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Selecting Into a Custom Type",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Anonymous objects are useful for quick experiments, but sometimes the projected result deserves a real name. If the shape will be reused, printed in a table, returned from a method, or tested later, a custom type is usually clearer."
                                    },
                                    new Paragraph
                                    {
                                        Body = "For example, we could create a small custom type for student summaries:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public class StudentSummary\r\n{\r\n    public string Name { get; set; } = string.Empty;\r\n    public bool Passed { get; set; }\r\n}"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Then we can use <code class='inline-code'>Select</code> to create one <code class='inline-code'>StudentSummary</code> object for each student:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var studentSummaries = students\r\n    .Select(student => new StudentSummary\r\n    {\r\n        Name = student.Name,\r\n        Passed = student.Score >= 70\r\n    })\r\n    .ToList();"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This is still a projection. We start with <code class='inline-code'>Student</code> objects and create <code class='inline-code'>StudentSummary</code> objects. The original student collection is not changed."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Where and Select Together",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "<code class='inline-code'>Where</code> and <code class='inline-code'>Select</code> are often used together. First we filter the data, then we transform the matching items."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var highScorerNames = students\r\n    .Where(student => student.Score > 80)\r\n    .Select(student => student.Name);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Read this from top to bottom: start with students, keep only students with scores above 80, then select each student's name."
                                    },
                                    new Paragraph
                                    {
                                        Body = "This style of chaining is one of the reasons LINQ becomes so expressive. Each method does one clear job."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Using Select in the Course Project",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Open <code class='inline-code'>Program.cs</code> and use the same sandbox space: after <code class='inline-code'>stocks</code> and <code class='inline-code'>trades</code> are created, but before the menu constants."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var stocks = StockSeeder.GetStocks();\r\nvar trades = stocks\r\n    .SelectMany(stock => stock.Trades)\r\n    .ToList();\r\n\r\n// SANDBOX - Write your code here\r\n\r\nconst string stockOption = \"Print stocks\";\r\nconst string tradeOption = \"Print all trades\";\r\nconst string exitOption = \"Exit\";"
                                    },
                                    new Paragraph
                                    {
                                        Body = "To get only the stock symbols:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var symbols = stocks.Select(stock => stock.Symbol).ToList();"
                                    },
                                    new Paragraph
                                    {
                                        Body = "To get only the sectors:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var sectors = stocks.Select(stock => stock.Sector).ToList();"
                                    },
                                    new Paragraph
                                    {
                                        Body = "To calculate the total value of each trade, multiply price by quantity:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var tradeValues = trades\r\n    .Select(trade => trade.Price * trade.Quantity)\r\n    .ToList();"
                                    },
                                    new Paragraph
                                    {
                                        Body = "To create a simpler trade summary:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var tradeSummaries = trades\r\n    .Select(trade => new\r\n    {\r\n        trade.Symbol,\r\n        trade.Type,\r\n        Value = trade.Price * trade.Quantity\r\n    })\r\n    .ToList();"
                                    },
                                    new Paragraph
                                    {
                                        Body = "If that summary becomes part of the app, a custom type makes the code more professional and easier to reuse:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public class TradeSummary\r\n{\r\n    public string Symbol { get; set; } = string.Empty;\r\n    public TradeType Type { get; set; }\r\n    public int Quantity { get; set; }\r\n    public decimal Value { get; set; }\r\n}"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var tradeSummaries = trades\r\n    .Select(trade => new TradeSummary\r\n    {\r\n        Symbol = trade.Symbol,\r\n        Type = trade.Type,\r\n        Quantity = trade.Quantity,\r\n        Value = trade.Price * trade.Quantity\r\n    })\r\n    .ToList();"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This pattern is common in reporting code. The app may store rich domain objects, but the screen or report often needs a smaller purpose-built shape."
                                    },
                                    new Paragraph
                                    {
                                        Body = "These examples transform the original data into something easier to answer questions with. In the next lesson, this will make <code class='inline-code'>Contains</code> much easier to understand."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "💡 Tips",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "When practicing <code class='inline-code'>Select</code>, make sure you actually inspect the new collection you created. Otherwise, the query may compile, but you will not build a clear mental picture of what changed."
                                    },
                                    new Paragraph
                                    {
                                        Body = "You have two good options:"
                                    },
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "Put a breakpoint on the next executable line after the newly created collection, then hover over the variable or inspect it in the debugger.",
                                            "Print the results to the console so you can see each transformed value.")
                                    },
                                    new Paragraph
                                    {
                                        Body = "For example, after creating <code class='inline-code'>symbols</code>, place the breakpoint on the next executable line. In this project, that can be the <code class='inline-code'>while (true)</code> line where the menu starts:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var symbols = stocks.Select(stock => stock.Symbol).ToList();\r\n\r\nconst string stockOption = \"Print stocks\";\r\nconst string tradeOption = \"Print all trades\";\r\nconst string exitOption = \"Exit\";\r\n\r\nwhile (true) // Put a breakpoint here\r\n{\r\n    // Menu code starts here\r\n}"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Or you can print the values:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "foreach (var symbol in symbols)\r\n{\r\n    Console.WriteLine(symbol);\r\n}"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This habit is especially useful while learning LINQ. Each query should answer two questions: <b>what type of data did I start with?</b> and <b>what type of data did I create?</b>"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Common Mistakes",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "Using <code class='inline-code'>Select</code> when you meant to filter. If the number of items should shrink, you probably need <code class='inline-code'>Where</code>.",
                                            "Expecting <code class='inline-code'>Select</code> to change the original objects. It returns a projected sequence instead.",
                                            "Forgetting <code class='inline-code'>ToList()</code> when assigning the result to a list or when you want to evaluate the query immediately.",
                                            "Creating a projection with too many properties. If the new shape is becoming large or reused, a named class or DTO may be clearer.")
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
                                        Body = "Use the sandbox space in <code class='inline-code'>Program.cs</code> for these exercises. Type every query by hand instead of copying and pasting. It is slower at first, but the repeated typing helps your hands and eyes memorise the LINQ syntax."
                                    },
                                    new Paragraph
                                    {
                                        Body = ExerciseList(
                                            "Use <code class='inline-code'>Select</code> to create a list of stock symbols.",
                                            "Use <code class='inline-code'>Select</code> to create a list of company names.",
                                            "Use <code class='inline-code'>Select</code> to create a list of stock sectors.",
                                            "Use <code class='inline-code'>Select</code> to create a list of trade symbols.",
                                            "Use <code class='inline-code'>Select</code> to create a list of trade quantities.",
                                            "Use <code class='inline-code'>Select</code> to calculate the total value of each trade: price multiplied by quantity.",
                                            "Use <code class='inline-code'>Where</code> and <code class='inline-code'>Select</code> together to get the symbols of all buy trades.",
                                            "Use <code class='inline-code'>Where</code> and <code class='inline-code'>Select</code> together to get the values of all trades with quantity greater than or equal to <code class='inline-code'>500</code>.",
                                            "Create an anonymous trade summary projection with symbol, trade type, quantity, and total value.",
                                            "Create a <code class='inline-code'>TradeSummary</code> custom type, then use <code class='inline-code'>Select</code> to project trades into that type.")
                                    },
                                    new Paragraph
                                    {
                                        Body = "After each exercise, say what changed: did you filter items, transform items, or both? That habit will help you choose the right LINQ method faster."
                                    }
                                }
                            }
                        }
                },
                new Article
                {
                        Id = 500255,
                        CourseDisplayId = 8,
                        Title = "Asking Questions With Any, All, and Contains",
                        Slug = "asking-questions-with-any-all-and-contains",
                        Description = "Learn how to use Any, All, and Contains to answer yes-or-no questions about collections.",
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
                                        Body = "So far, we've used LINQ to filter data with <code class='inline-code'>Where</code> and transform data with <code class='inline-code'>Select</code>. But sometimes we do not need a new sequence at all. Sometimes we only need to answer a yes-or-no question."
                                    },
                                    new Paragraph
                                    {
                                        Body = "That is where <code class='inline-code'>Any()</code>, <code class='inline-code'>All()</code>, and <code class='inline-code'>Contains()</code> become useful. These methods return a <code class='inline-code'>bool</code>: either <code class='inline-code'>true</code> or <code class='inline-code'>false</code>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "You can think of them as question methods:"
                                    },
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "<code class='inline-code'>Any()</code>: Does at least one item exist?",
                                            "<code class='inline-code'>All()</code>: Do all items match this rule?",
                                            "<code class='inline-code'>Contains()</code>: Does this collection contain this exact value?")
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Using Any",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "<code class='inline-code'>Any()</code> answers the question: <b>is there at least one item?</b>"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Called without a predicate, it checks whether a collection has anything in it:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "List<int> numbers = [1, 2, 3];\r\n\r\nbool hasNumbers = numbers.Any();"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Since the list contains values, <code class='inline-code'>hasNumbers</code> will be <code class='inline-code'>true</code>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "More commonly, we pass a predicate to ask whether at least one item matches a condition:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "bool hasLargeNumber = numbers.Any(number => number > 100);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This means: <b>is there any number greater than 100?</b> Since none of the numbers match, the result is <code class='inline-code'>false</code>."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Any vs Where",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "A common beginner mistake is using <code class='inline-code'>Where</code> when the code only needs a yes-or-no answer."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var largeNumbers = numbers.Where(number => number > 100);\r\nbool hasLargeNumbers = largeNumbers.Any();"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This works, but it is more indirect than necessary. We can ask the question directly:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "bool hasLargeNumbers = numbers.Any(number => number > 100);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Use <code class='inline-code'>Where</code> when you need the matching items. Use <code class='inline-code'>Any</code> when you only need to know whether matching items exist."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Using All",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "<code class='inline-code'>All()</code> answers the question: <b>does every item match this condition?</b>"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "List<int> scores = [82, 91, 77, 88];\r\n\r\nbool everyonePassed = scores.All(score => score >= 70);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This returns <code class='inline-code'>true</code> because every score is greater than or equal to 70."
                                    },
                                    new Paragraph
                                    {
                                        Body = "If even one item fails the condition, <code class='inline-code'>All</code> returns <code class='inline-code'>false</code>:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "bool everyoneScoredAbove80 = scores.All(score => score > 80);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This returns <code class='inline-code'>false</code> because one score is 77."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "A Small All Gotcha",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "One detail worth knowing: <code class='inline-code'>All()</code> returns <code class='inline-code'>true</code> for an empty collection."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "List<int> emptyScores = [];\r\n\r\nbool result = emptyScores.All(score => score >= 70);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This may feel strange at first, but it means: <b>there are no items that break the rule</b>. In real applications, if the collection must not be empty, combine <code class='inline-code'>Any()</code> and <code class='inline-code'>All()</code>:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "bool everyonePassed = scores.Any() && scores.All(score => score >= 70);"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Using Contains",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "<code class='inline-code'>Contains()</code> answers the question: <b>does this collection contain this value?</b>"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var symbols = new[] { \"AAPL\", \"MSFT\", \"TSLA\" };\r\n\r\nbool hasApple = symbols.Contains(\"AAPL\");"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This returns <code class='inline-code'>true</code> because <code class='inline-code'>AAPL</code> is in the list."
                                    },
                                    new Paragraph
                                    {
                                        Body = "For simple values like strings, integers, and enums, <code class='inline-code'>Contains</code> is straightforward. With custom objects, it checks whether the collection contains an equal object. Because object equality has its own rules, beginners usually use <code class='inline-code'>Any</code> when checking properties on objects."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "bool hasAppleTrade = trades.Any(trade => trade.Symbol == \"AAPL\");"
                                    },
                                    new Paragraph
                                    {
                                        Body = "That reads clearly: <b>is there any trade whose symbol is AAPL?</b>"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Using Them in the Course Project",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Open <code class='inline-code'>Program.cs</code> in the LINQ study project and use the same sandbox space as before: after the <code class='inline-code'>stocks</code> and <code class='inline-code'>trades</code> collections are created, but before the menu constants."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "List<Stock> stocks = StockSeeder.GetStocks();\r\nList<Trade> trades = stocks\r\n    .SelectMany(stock => stock.Trades)\r\n    .ToList();\r\n\r\n// SANDBOX - Write your code here\r\n\r\nconst string stockOption = \"Print stocks\";\r\nconst string tradeOption = \"Print all trades\";\r\nconst string exitOption = \"Exit\";"
                                    },
                                    new Paragraph
                                    {
                                        Body = "To check whether the data contains any Apple trades, use <code class='inline-code'>Any</code>:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "bool hasAppleTrades = trades.Any(trade => trade.Symbol == \"AAPL\");\r\n\r\nConsole.WriteLine($\"Has Apple trades: {hasAppleTrades}\");"
                                    },
                                    new Paragraph
                                    {
                                        Body = "To check whether every trade has a positive quantity, use <code class='inline-code'>All</code>:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "bool allTradesHaveQuantity = trades.All(trade => trade.Quantity > 0);\r\n\r\nConsole.WriteLine($\"All trades have quantity: {allTradesHaveQuantity}\");"
                                    },
                                    new Paragraph
                                    {
                                        Body = "To check whether the stocks list includes a specific symbol, we can first create a list of symbols, then use <code class='inline-code'>Contains</code>:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var symbols = stocks\r\n    .Select(stock => stock.Symbol)\r\n    .ToList();\r\n\r\nbool hasMicrosoft = symbols.Contains(\"MSFT\");\r\n\r\nConsole.WriteLine($\"Has Microsoft: {hasMicrosoft}\");"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This is where the previous lesson on <code class='inline-code'>Select</code> becomes useful. We transform the stock objects into simple symbol values, then <code class='inline-code'>Contains</code> can check for one exact symbol."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Choosing the Right Method",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "Use <code class='inline-code'>Any()</code> when you want to know whether at least one matching item exists.",
                                            "Use <code class='inline-code'>All()</code> when you want to know whether every item satisfies a condition.",
                                            "Use <code class='inline-code'>Contains()</code> when you want to know whether a collection contains a specific value.",
                                            "Use <code class='inline-code'>Where()</code> when you need the matching items themselves, not just a yes-or-no answer.")
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
                                        Body = "Use the sandbox space in <code class='inline-code'>Program.cs</code> to answer each question. Store each answer in a <code class='inline-code'>bool</code> variable and print it with <code class='inline-code'>Console.WriteLine</code>. For better memorisation, type each query by hand instead of copying and pasting. The repetition helps the LINQ syntax become familiar."
                                    },
                                    new Paragraph
                                    {
                                        Body = ExerciseList(
                                            "Use <code class='inline-code'>Any</code> to check whether there are any trades for <code class='inline-code'>TSLA</code>.",
                                            "Use <code class='inline-code'>Any</code> to check whether there are any trades with a price greater than <code class='inline-code'>500</code>.",
                                            "Use <code class='inline-code'>Any</code> to check whether there are any <code class='inline-code'>Sell</code> trades.",
                                            "Use <code class='inline-code'>All</code> to check whether every trade has a quantity greater than <code class='inline-code'>0</code>.",
                                            "Use <code class='inline-code'>All</code> to check whether every stock has a non-empty symbol.",
                                            "Use <code class='inline-code'>All</code> to check whether every trade has a price greater than <code class='inline-code'>0</code>.",
                                            "Create a list of stock symbols and use <code class='inline-code'>Contains</code> to check whether <code class='inline-code'>AAPL</code> exists.",
                                            "Create a list of stock sectors and use <code class='inline-code'>Contains</code> to check whether <code class='inline-code'>Healthcare</code> exists.",
                                            "Write one question that uses <code class='inline-code'>Any</code>, one that uses <code class='inline-code'>All</code>, and one that uses <code class='inline-code'>Contains</code>, using your own conditions.")
                                    },
                                    new Paragraph
                                    {
                                        Body = "When you're done, read each line out loud as a question. If the method name matches the question naturally, you probably chose the right LINQ method."
                                    }
                                }
                            }
                        }
                },
                new Article
                {
                        Id = 500257,
                        CourseDisplayId = 9,
                        Title = "Working With Nested Collections",
                        Slug = "working-with-nested-collections",
                        Description = "Learn how to query collections that contain other collections, and how SelectMany flattens nested data.",
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
                                        Body = "So far, most of our examples have used simple collections: a list of stocks, a list of trades, a list of numbers, or a list of strings."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Real applications often contain <b>nested collections</b>. A nested collection is a collection inside another object or another collection."
                                    },
                                    new Paragraph
                                    {
                                        Body = "For example, one customer may have many orders, one course may have many lessons, one stock may have many trades, and one student may have many exam scores."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "What Is a Nested Collection?",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "A nested collection appears when each item in a collection contains its own collection."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public class Student\r\n{\r\n    public string Name { get; set; }\r\n    public List<int> Scores { get; set; }\r\n}"
                                    },
                                    new Paragraph
                                    {
                                        Body = "If we have a <code class='inline-code'>List&lt;Student&gt;</code>, then we do not only have a list of students. We also have multiple score lists, one inside each student."
                                    },
                                    new Paragraph
                                    {
                                        Body = "That means we may need to ask questions at two levels:"
                                    },
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "Questions about the outer collection, such as which students exist.",
                                            "Questions about the inner collections, such as which scores belong to each student.",
                                            "Questions across all inner collections, such as what scores exist across every student.")
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Selecting Inner Collections",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "If we use <code class='inline-code'>Select</code> on a nested collection, we usually get one inner collection per outer item."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var scoreLists = students.Select(student => student.Scores);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This does not give us one sequence of scores. It gives us a sequence of score lists. In other words, the shape is still nested."
                                    },
                                    new Paragraph
                                    {
                                        Body = "That can be useful when we want to keep each student's scores grouped with that student. But sometimes we want one flat sequence containing all scores."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Flattening With SelectMany",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "<code class='inline-code'>SelectMany</code> is used when each item has a collection and we want to flatten all the inner collections into one sequence."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var allScores = students.SelectMany(student => student.Scores);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This means: <b>for each student, get their scores, then combine all those score lists into one sequence</b>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "This is the key difference:"
                                    },
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "<code class='inline-code'>Select</code> keeps the nested shape.",
                                            "<code class='inline-code'>SelectMany</code> flattens the nested shape.")
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "A Simple Example",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var students = new[]\r\n{\r\n    new { Name = \"John\", Scores = new[] { 85, 90 } },\r\n    new { Name = \"Sarah\", Scores = new[] { 92, 88 } },\r\n    new { Name = \"Tom\", Scores = new[] { 67, 73 } }\r\n};"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Using <code class='inline-code'>Select</code> gives us a sequence of score arrays:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var nestedScores = students.Select(student => student.Scores);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Using <code class='inline-code'>SelectMany</code> gives us one flat sequence of scores:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var allScores = students.SelectMany(student => student.Scores);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "The flat result contains <code class='inline-code'>85, 90, 92, 88, 67, 73</code>."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Filtering Nested Data",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Once the inner values are flattened, we can keep chaining LINQ methods."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var passingScores = students\r\n    .SelectMany(student => student.Scores)\r\n    .Where(score => score >= 70)\r\n    .ToList();"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Read this from top to bottom: start with students, flatten all score lists into one score sequence, then keep only passing scores."
                                    },
                                    new Paragraph
                                    {
                                        Body = "This is a common LINQ pattern. We reshape the data first, then ask a question about the new shape."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Nested Trades in the Course Project",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "The study project already prepares nested trade data for us. When <code class='inline-code'>StockSeeder.GetStocks()</code> runs, it creates the stocks, asks <code class='inline-code'>TradeSeeder</code> for trades, and assigns each stock its matching trades."
                                    },
                                    new Paragraph
                                    {
                                        Body = "That means each <code class='inline-code'>Stock</code> has a <code class='inline-code'>Trades</code> collection that we can use for nested LINQ queries."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "List<Stock> stocks = StockSeeder.GetStocks();\r\n\r\nStock apple = stocks.First(stock => stock.Symbol == \"AAPL\");\r\nConsole.WriteLine($\"{apple.Symbol} has {apple.Trades.Count} trades\");"
                                    },
                                    new Paragraph
                                    {
                                        Body = "You do not need to manually attach trades in <code class='inline-code'>Program.cs</code>. The seeder has already done that work so this lesson can focus on querying nested collections."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Using Nested Collections in the Course Project",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "In the study project, <code class='inline-code'>stocks</code> is not just a simple list anymore. It is a list of stocks, and each stock contains its own list of trades."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Use the same sandbox space in <code class='inline-code'>Program.cs</code>: after the collections are created, but before the menu constants."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var stocks = StockSeeder.GetStocks();\r\nvar trades = stocks\r\n    .SelectMany(stock => stock.Trades)\r\n    .ToList();\r\n\r\n// SANDBOX - Write your code here\r\n\r\nconst string stockOption = \"Print stocks\";\r\nconst string tradeOption = \"Print all trades\";\r\nconst string exitOption = \"Exit\";"
                                    },
                                    new Paragraph
                                    {
                                        Body = "You can inspect one stock's nested trades directly:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var apple = stocks.First(stock => stock.Symbol == \"AAPL\");\r\n\r\nConsole.WriteLine($\"{apple.Symbol} has {apple.Trades.Count} trades\");"
                                    },
                                    new Paragraph
                                    {
                                        Body = "If we use <code class='inline-code'>Select</code>, we keep one trade list per stock:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var tradeLists = stocks.Select(stock => stock.Trades);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "If we use <code class='inline-code'>SelectMany</code>, we flatten all those trade lists into one trade sequence:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var allTradesFromStocks = stocks\r\n    .SelectMany(stock => stock.Trades)\r\n    .ToList();"
                                    },
                                    new Paragraph
                                    {
                                        Body = "At this point, <code class='inline-code'>allTradesFromStocks</code> is flat. It contains trades, not stocks. That means you can continue with methods like <code class='inline-code'>Where</code>, <code class='inline-code'>Select</code>, <code class='inline-code'>Any</code>, or <code class='inline-code'>All</code>."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Tips",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Nested collections are easier to understand when you inspect the shape of the data. After <code class='inline-code'>stocks</code> is created, put a breakpoint on the next executable line, such as <code class='inline-code'>while (true)</code>, and expand a stock in the debugger. You should see its nested <code class='inline-code'>Trades</code> list."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Look carefully at the difference between these two variables:"
                                    },
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "<code class='inline-code'>tradeLists</code>: a sequence where each item is a list of trades.",
                                            "<code class='inline-code'>allTradesFromStocks</code>: a single flattened list of trades.")
                                    },
                                    new Paragraph
                                    {
                                        Body = "You can also print counts to make the difference clearer:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "foreach (var stock in stocks)\r\n{\r\n    Console.WriteLine($\"{stock.Symbol}: {stock.Trades.Count} trades\");\r\n}"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Common Mistakes",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "Using <code class='inline-code'>Select</code> when you actually want one flat sequence.",
                                            "Using <code class='inline-code'>SelectMany</code> too early and losing the grouping you still needed.",
                                            "Forgetting that nested data has more than one level to reason about.",
                                            "Writing a large nested query without inspecting intermediate variables in the debugger.")
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
                                        Body = "Use the sandbox space in <code class='inline-code'>Program.cs</code>. Type each query by hand instead of copying and pasting so the syntax becomes familiar."
                                    },
                                    new Paragraph
                                    {
                                        Body = ExerciseList(
                                            "Put a breakpoint on the next executable line after <code class='inline-code'>stocks</code> is created and inspect one stock's nested <code class='inline-code'>Trades</code> list.",
                                            "Use <code class='inline-code'>Select</code> to create a sequence of trade lists from <code class='inline-code'>stocks</code>.",
                                            "Use <code class='inline-code'>SelectMany</code> to flatten all nested trade lists into one trade list.",
                                            "Use <code class='inline-code'>SelectMany</code> and <code class='inline-code'>Where</code> to get all nested trades with quantity greater than or equal to <code class='inline-code'>500</code>.",
                                            "Use <code class='inline-code'>Select</code> to create a new shape where each stock has its symbol and only its buy trades.",
                                            "Print each stock symbol with the number of matching trades.",
                                            "Print each stock symbol with the number of matching sell trades.",
                                            "Create a flattened list of trade values from the nested data, where value equals price multiplied by quantity.")
                                    },
                                    new Paragraph
                                    {
                                        Body = "After each exercise, ask yourself whether the result is still nested or flat. That question is the heart of this lesson."
                                    }
                                }
                            }
                        }
                },
                new Article
                {
                        Id = 500258,
                        CourseDisplayId = 10,
                        Title = "Sorting Data With OrderBy",
                        Slug = "sorting-data-with-orderby",
                        Description = "Learn how to sort LINQ query results with OrderBy and OrderByDescending.",
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
                                        Body = "After filtering and transforming data, another common task is sorting it. Sorting means arranging items in a specific order, such as alphabetically, from lowest to highest, or from newest to oldest."
                                    },
                                    new Paragraph
                                    {
                                        Body = "LINQ gives us two primary methods for basic sorting: <code class='inline-code'>OrderBy()</code> and <code class='inline-code'>OrderByDescending()</code>."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "OrderBy",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "<code class='inline-code'>OrderBy()</code> sorts a sequence in ascending order. For numbers, ascending means smallest to largest. For strings, it usually means alphabetical order."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var numbers = new[] { 8, 3, 10, 1 };\r\n\r\nvar orderedNumbers = numbers.OrderBy(number => number);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "The result is <code class='inline-code'>1, 3, 8, 10</code>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "When sorting objects, we choose which property should control the order:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var studentsByName = students.OrderBy(student => student.Name);"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "OrderByDescending",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "<code class='inline-code'>OrderByDescending()</code> sorts in the opposite direction. For numbers, that means largest to smallest. For dates, it often means newest to oldest."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var highestScoresFirst = students\r\n    .OrderByDescending(student => student.Score);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This is useful whenever the most important, newest, largest, or highest-value items should appear first."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Using OrderBy in the Course Project",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Use the sandbox space in <code class='inline-code'>Program.cs</code>. Write each query after <code class='inline-code'>stocks</code> and <code class='inline-code'>trades</code> are created, but before the menu constants."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var stocks = StockSeeder.GetStocks();\r\nvar trades = stocks\r\n    .SelectMany(stock => stock.Trades)\r\n    .ToList();\r\n\r\n// SANDBOX - Write your code here\r\n\r\nconst string stockOption = \"Print stocks\";\r\nconst string tradeOption = \"Print all trades\";\r\nconst string exitOption = \"Exit\";"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Sort stocks alphabetically by symbol:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var stocksBySymbol = stocks\r\n    .OrderBy(stock => stock.Symbol)\r\n    .ToList();"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Sort trades from lowest price to highest price:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var tradesByPrice = trades\r\n    .OrderBy(trade => trade.Price)\r\n    .ToList();"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Sort trades from newest to oldest:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var newestTrades = trades\r\n    .OrderByDescending(trade => trade.Date)\r\n    .ToList();"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Tips",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "After creating a sorted collection, either put a breakpoint on the next executable line or print the results. Sorting is visual, so it helps to actually inspect the order."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "foreach (var trade in newestTrades)\r\n{\r\n    Console.WriteLine($\"{trade.Date:d} - {trade.Symbol} - {trade.Price}\");\r\n}"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Common Mistakes",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "Expecting <code class='inline-code'>OrderBy</code> to change the original list. It returns a sorted sequence.",
                                            "Forgetting <code class='inline-code'>ToList()</code> when you want a concrete sorted list.",
                                            "Using <code class='inline-code'>OrderBy</code> twice when you mean to add a secondary sort. The next lesson covers <code class='inline-code'>ThenBy</code> for that.")
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
                                        Body = "Use the sandbox space in <code class='inline-code'>Program.cs</code>. Type every query by hand instead of copying and pasting."
                                    },
                                    new Paragraph
                                    {
                                        Body = ExerciseList(
                                            "Sort stocks alphabetically by <code class='inline-code'>Symbol</code>.",
                                            "Sort stocks alphabetically by <code class='inline-code'>CompanyName</code>.",
                                            "Sort trades by <code class='inline-code'>Price</code> from lowest to highest.",
                                            "Sort trades by <code class='inline-code'>Price</code> from highest to lowest.",
                                            "Sort trades by <code class='inline-code'>Date</code> from oldest to newest.",
                                            "Sort trades by <code class='inline-code'>Date</code> from newest to oldest.",
                                            "Flatten all nested stock trades with <code class='inline-code'>SelectMany</code>, then sort them by quantity descending.")
                                    }
                                }
                            }
                        }
                },
                new Article
                {
                        Id = 500259,
                        CourseDisplayId = 11,
                        Title = "Multi-Level Sorting With ThenBy",
                        Slug = "multi-level-sorting-with-thenby",
                        Description = "Learn how to apply secondary and tertiary sorting with ThenBy and ThenByDescending.",
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
                                        Body = "Sometimes one sort rule is not enough. We may want to sort people by last name, then by first name. Or sort trades by symbol, then by date, then by price."
                                    },
                                    new Paragraph
                                    {
                                        Body = "For multi-level sorting, LINQ gives us <code class='inline-code'>ThenBy()</code> and <code class='inline-code'>ThenByDescending()</code>."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Why ThenBy Exists",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "The first sort rule uses <code class='inline-code'>OrderBy</code> or <code class='inline-code'>OrderByDescending</code>. Extra sort rules use <code class='inline-code'>ThenBy</code> or <code class='inline-code'>ThenByDescending</code>."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var sortedPeople = people\r\n    .OrderBy(person => person.LastName)\r\n    .ThenBy(person => person.FirstName);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This means: sort by last name first. If two people have the same last name, sort those people by first name."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "ThenByDescending",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "<code class='inline-code'>ThenByDescending</code> applies a descending secondary sort."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var students = students\r\n    .OrderBy(student => student.ClassName)\r\n    .ThenByDescending(student => student.Score);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This sorts students by class first. Inside each class, the highest scores appear first."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Using ThenBy in the Course Project",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "In the study project, multi-level sorting is especially useful with trades. For example, we can sort by symbol first, then by date."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var tradesBySymbolThenDate = trades\r\n    .OrderBy(trade => trade.Symbol)\r\n    .ThenBy(trade => trade.Date)\r\n    .ToList();"
                                    },
                                    new Paragraph
                                    {
                                        Body = "We can also sort stocks by sector, then by company name:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var stocksBySectorThenCompany = stocks\r\n    .OrderBy(stock => stock.Sector)\r\n    .ThenBy(stock => stock.CompanyName)\r\n    .ToList();"
                                    },
                                    new Paragraph
                                    {
                                        Body = "And we can combine nested collections with sorting:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var nestedTradesSorted = stocks\r\n    .SelectMany(stock => stock.Trades)\r\n    .OrderBy(trade => trade.Symbol)\r\n    .ThenByDescending(trade => trade.Date)\r\n    .ToList();"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Common Mistakes",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "Starting a sort with <code class='inline-code'>ThenBy</code>. The first sort must be <code class='inline-code'>OrderBy</code> or <code class='inline-code'>OrderByDescending</code>.",
                                            "Using a second <code class='inline-code'>OrderBy</code> when you mean to add a secondary sort.",
                                            "Forgetting that each <code class='inline-code'>ThenBy</code> only applies when previous sort values are equal.")
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
                                        Body = "Use the sandbox space in <code class='inline-code'>Program.cs</code>. Type each query by hand and inspect the results with a breakpoint or by printing them."
                                    },
                                    new Paragraph
                                    {
                                        Body = ExerciseList(
                                            "Sort stocks by <code class='inline-code'>Sector</code>, then by <code class='inline-code'>Symbol</code>.",
                                            "Sort stocks by <code class='inline-code'>Sector</code>, then by <code class='inline-code'>CompanyName</code>.",
                                            "Sort trades by <code class='inline-code'>Symbol</code>, then by <code class='inline-code'>Date</code>.",
                                            "Sort trades by <code class='inline-code'>Type</code>, then by <code class='inline-code'>Price</code> descending.",
                                            "Sort trades by <code class='inline-code'>Symbol</code>, then by <code class='inline-code'>Quantity</code> descending.",
                                            "Flatten nested stock trades with <code class='inline-code'>SelectMany</code>, then sort by symbol and newest date first.",
                                            "Create one query with <code class='inline-code'>OrderBy</code>, <code class='inline-code'>ThenBy</code>, and <code class='inline-code'>ThenByDescending</code>.")
                                    }
                                }
                            }
                        }
                },
                new Article
                {
                    Id = 500260,
                    CourseDisplayId = 12,
                    Title = "Counting Items With Count",
                    Slug = "counting-items-with-count",
                    Blocks = new List<Block>
                        {
                            new Block
                            {
                                Title = "Section 5: Aggregation",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "So far, we have used LINQ to filter, transform, flatten, and sort data. Aggregation is different. Instead of returning a new collection, aggregation methods usually return one final answer."
                                    },
                                    new Paragraph
                                    {
                                        Body = "For example, aggregation can answer questions like:"
                                    },
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "How many trades are in the list?",
                                            "How many stocks belong to the Technology sector?",
                                            "How many trades were buys instead of sells?",
                                            "How many nested trades exist across every stock?")
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "What Count Does",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "<code class='inline-code'>Count()</code> returns the number of items in a collection."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "int totalStocks = stocks.Count();"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This query asks: how many stocks are in the <code class='inline-code'>stocks</code> collection?"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Unlike <code class='inline-code'>Where</code>, <code class='inline-code'>Select</code>, or <code class='inline-code'>OrderBy</code>, this does not return a list. It returns a single number."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Count With a Condition",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "<code class='inline-code'>Count</code> can also receive a condition. This lets us count only the items that match a rule."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "int technologyStocks = stocks.Count(stock => stock.Sector == \"Technology\");"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This means: count only the stocks whose sector is Technology."
                                    },
                                    new Paragraph
                                    {
                                        Body = "You could write the same idea with <code class='inline-code'>Where</code> followed by <code class='inline-code'>Count</code>:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "int technologyStocks = stocks\r\n    .Where(stock => stock.Sector == \"Technology\")\r\n    .Count();"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Both versions work, but <code class='inline-code'>Count(condition)</code> is shorter when counting is the only thing you need."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Using Count in the Course Project",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "In the study project, <code class='inline-code'>Count</code> is useful for quickly checking how much data you have after a query."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "int totalTrades = trades.Count();\r\n\r\nConsole.WriteLine($\"Total trades: {totalTrades}\");"
                                    },
                                    new Paragraph
                                    {
                                        Body = "You can also count trades for a specific stock symbol:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "int appleTrades = trades.Count(trade => trade.Symbol == \"AAPL\");\r\n\r\nConsole.WriteLine($\"Apple trades: {appleTrades}\");"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Because stocks already contain nested trades, you can count all trades across all stocks with <code class='inline-code'>SelectMany</code>:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "int nestedTradeCount = stocks\r\n    .SelectMany(stock => stock.Trades)\r\n    .Count();\r\n\r\nConsole.WriteLine($\"Nested trades: {nestedTradeCount}\");"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "LongCount",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "<code class='inline-code'>LongCount()</code> works like <code class='inline-code'>Count()</code>, but it returns a <code class='inline-code'>long</code> instead of an <code class='inline-code'>int</code>."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "long totalTrades = trades.LongCount();"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Most normal collections in beginner projects will use <code class='inline-code'>Count()</code>. <code class='inline-code'>LongCount()</code> is useful when a data source could contain more items than an <code class='inline-code'>int</code> can safely represent."
                                    },
                                    new Paragraph
                                    {
                                        Body = "You can also use a condition with <code class='inline-code'>LongCount</code>:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "long largeTrades = trades.LongCount(trade => trade.Quantity > 100);"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Tips",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "When practicing, print the count immediately or put a breakpoint on the next executable line after the count variable is created."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "int buyTrades = trades.Count(trade => trade.Type == TradeType.Buy);\r\n\r\nConsole.WriteLine($\"Buy trades: {buyTrades}\");"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Typing these examples by hand matters. Aggregation methods are short, but the habit of reading the condition clearly takes practice."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Common Mistakes",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "Expecting <code class='inline-code'>Count()</code> to return a collection. It returns a number.",
                                            "Using <code class='inline-code'>Where</code> before <code class='inline-code'>Count</code> when <code class='inline-code'>Count(condition)</code> would be simpler.",
                                            "Calling <code class='inline-code'>Count()</code> too early in a query chain, then trying to keep querying the result.",
                                            "Using <code class='inline-code'>LongCount()</code> everywhere when <code class='inline-code'>Count()</code> is clear and sufficient.")
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
                                        Body = "Use the sandbox space in <code class='inline-code'>Program.cs</code>. Type each query by hand for better memorisation, then print the result or inspect it with the debugger."
                                    },
                                    new Paragraph
                                    {
                                        Body = ExerciseList(
                                            "Count all stocks.",
                                            "Count all trades.",
                                            "Count all stocks in the Technology sector.",
                                            "Count all trades where the symbol is <code class='inline-code'>AAPL</code>.",
                                            "Count all trades where the quantity is greater than 100.",
                                            "Count all buy trades.",
                                            "Use <code class='inline-code'>SelectMany</code> to count all nested trades across all stocks.",
                                            "Rewrite one <code class='inline-code'>Where(...).Count()</code> query as a <code class='inline-code'>Count(...)</code> query.",
                                            "Create one <code class='inline-code'>LongCount()</code> query and print the result.")
                                    }
                                }
                            }
                        }
                },
                new Article
                {
                    Id = 500261,
                    CourseDisplayId = 13,
                    Title = "Calculating Totals and Averages",
                    Slug = "calculating-totals-and-averages",
                    Description = "Learn how to use Sum and Average to calculate meaningful values from collections.",
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
                                        Body = "In the previous lesson, we used <code class='inline-code'>Count()</code> to answer questions about how many items exist. Now we'll use two more aggregation methods: <code class='inline-code'>Sum()</code> and <code class='inline-code'>Average()</code>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "These methods help us calculate totals and typical values from our data. In real applications, they are often used in reports, dashboards, invoices, analytics screens, and summaries."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "What Sum Does",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "<code class='inline-code'>Sum()</code> adds values together and returns the total."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "int totalQuantity = trades.Sum(trade => trade.Quantity);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This means: go through every trade, take its quantity, and add all those quantities together."
                                    },
                                    new Paragraph
                                    {
                                        Body = "The value inside <code class='inline-code'>Sum</code> must be numeric. Common examples include <code class='inline-code'>int</code>, <code class='inline-code'>decimal</code>, and <code class='inline-code'>double</code>."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Calculating Trade Value",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Sometimes the value you want to add is not stored directly in one property. You can calculate it inside the lambda."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "decimal totalTradeValue = trades.Sum(trade => trade.Price * trade.Quantity);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This means: for each trade, multiply price by quantity, then add all those calculated values together."
                                    },
                                    new Paragraph
                                    {
                                        Body = "This is a good example of LINQ describing business logic clearly. We are not just adding a column. We are answering the question: what is the total value of all trades?"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "What Average Does",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "<code class='inline-code'>Average()</code> calculates the mean value."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "decimal averagePrice = trades.Average(trade => trade.Price);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This means: add all trade prices together, then divide by the number of trades."
                                    },
                                    new Paragraph
                                    {
                                        Body = "<code class='inline-code'>Average</code> is useful when you want a general sense of typical price, quantity, duration, score, or size."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Using Sum and Average in the Course Project",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "In the study project, these methods help us produce reporting-style answers from the stock and trade data."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "int totalQuantity = trades.Sum(trade => trade.Quantity);\r\n\r\nConsole.WriteLine($\"Total quantity traded: {totalQuantity}\");"
                                    },
                                    new Paragraph
                                    {
                                        Body = "We can calculate the total traded value across every trade:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "decimal totalTradeValue = trades.Sum(trade => trade.Price * trade.Quantity);\r\n\r\nConsole.WriteLine($\"Total trade value: {totalTradeValue:C}\");"
                                    },
                                    new Paragraph
                                    {
                                        Body = "We can also calculate the average trade price:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "decimal averageTradePrice = trades.Average(trade => trade.Price);\r\n\r\nConsole.WriteLine($\"Average trade price: {averageTradePrice:C}\");"
                                    },
                                    new Paragraph
                                    {
                                        Body = "And because stocks contain nested trades, we can combine <code class='inline-code'>SelectMany</code> with aggregation:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "decimal nestedTotalValue = stocks\r\n    .SelectMany(stock => stock.Trades)\r\n    .Sum(trade => trade.Price * trade.Quantity);\r\n\r\nConsole.WriteLine($\"Nested trade value: {nestedTotalValue:C}\");"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Filtering Before Aggregating",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "You can filter data before calculating a total or average. This lets you answer more specific questions."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "decimal appleTradeValue = trades\r\n    .Where(trade => trade.Symbol == \"AAPL\")\r\n    .Sum(trade => trade.Price * trade.Quantity);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This means: find only the Apple trades, then calculate the total value of those trades."
                                    },
                                    new Paragraph
                                    {
                                        Body = "For averages, be careful when a filtered collection might be empty. <code class='inline-code'>Average()</code> needs at least one item."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var microsoftTrades = trades\r\n    .Where(trade => trade.Symbol == \"MSFT\")\r\n    .ToList();\r\n\r\nif (microsoftTrades.Any())\r\n{\r\n    decimal averageMicrosoftPrice = microsoftTrades.Average(trade => trade.Price);\r\n    Console.WriteLine($\"Average Microsoft price: {averageMicrosoftPrice:C}\");\r\n}"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Tips",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "When practicing, print the result immediately or put a breakpoint on the next executable line after the aggregation variable is created."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "decimal averageQuantity = trades.Average(trade => trade.Quantity);\r\n\r\nConsole.WriteLine($\"Average quantity: {averageQuantity}\");"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Type the full query by hand. Pay special attention to the lambda inside <code class='inline-code'>Sum</code> or <code class='inline-code'>Average</code>, because that is where you define what value LINQ should calculate."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Common Mistakes",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "Trying to use <code class='inline-code'>Sum()</code> on a non-numeric value such as a name or symbol.",
                                            "Forgetting that <code class='inline-code'>Average()</code> can fail when there are no matching items.",
                                            "Calculating the wrong value by averaging prices when the question asks for total value.",
                                            "Calling <code class='inline-code'>ToList()</code> after <code class='inline-code'>Sum()</code> or <code class='inline-code'>Average()</code>. Aggregation returns one value, not a collection.",
                                            "Using <code class='inline-code'>Count()</code> when the question asks for a total quantity or total value.")
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
                                        Body = "Use the sandbox space in <code class='inline-code'>Program.cs</code>. Type each query by hand for better memorisation, then print the result or inspect it with the debugger."
                                    },
                                    new Paragraph
                                    {
                                        Body = ExerciseList(
                                            "Calculate the total quantity across all trades.",
                                            "Calculate the average quantity across all trades.",
                                            "Calculate the total value of all trades using price multiplied by quantity.",
                                            "Calculate the average trade price.",
                                            "Filter trades to <code class='inline-code'>AAPL</code>, then calculate the total value of those trades.",
                                            "Filter trades to buy trades, then calculate their total quantity.",
                                            "Use <code class='inline-code'>SelectMany</code> to calculate the total value of all nested trades across all stocks.",
                                            "Choose a stock symbol, filter to that symbol, check whether any trades exist, then calculate the average price.",
                                            "Create one query that uses <code class='inline-code'>Where</code>, <code class='inline-code'>SelectMany</code>, and <code class='inline-code'>Sum</code> together.")
                                    }
                                }
                            }
                        }
                },
                new Article
                {
                    Id = 500262,
                    CourseDisplayId = 14,
                    Title = "Finding Smallest and Largest Values",
                    Slug = "finding-smallest-and-largest-values",
                    Description = "Learn how to use Min and Max to find the lowest and highest values in a collection.",
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
                                        Body = "<code class='inline-code'>Min()</code> and <code class='inline-code'>Max()</code> are aggregation methods. They do not return a new collection. They return one answer: the smallest value or the largest value."
                                    },
                                    new Paragraph
                                    {
                                        Body = "These methods are useful when you want to answer questions like:"
                                    },
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "What is the lowest trade price?",
                                            "What is the highest trade price?",
                                            "What is the earliest trade date?",
                                            "What is the most recent trade date?",
                                            "What is the largest quantity traded?")
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Min",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "<code class='inline-code'>Min()</code> returns the smallest value from a sequence."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "decimal lowestPrice = trades.Min(trade => trade.Price);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This means: look at every trade price and return the lowest one."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "DateTime earliestTradeDate = trades.Min(trade => trade.Date);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Dates can be compared too. The minimum date is the earliest date."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Max",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "<code class='inline-code'>Max()</code> returns the largest value from a sequence."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "decimal highestPrice = trades.Max(trade => trade.Price);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This means: look at every trade price and return the highest one."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "DateTime mostRecentTradeDate = trades.Max(trade => trade.Date);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "The maximum date is the most recent date."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Using Min and Max in the Course Project",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "In the study project, <code class='inline-code'>Min</code> and <code class='inline-code'>Max</code> help us build reporting-style summaries."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "decimal lowestTradePrice = trades.Min(trade => trade.Price);\r\ndecimal highestTradePrice = trades.Max(trade => trade.Price);\r\n\r\nConsole.WriteLine($\"Lowest price: {lowestTradePrice:C}\");\r\nConsole.WriteLine($\"Highest price: {highestTradePrice:C}\");"
                                    },
                                    new Paragraph
                                    {
                                        Body = "We can also find the largest quantity:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "int largestQuantity = trades.Max(trade => trade.Quantity);\r\n\r\nConsole.WriteLine($\"Largest quantity: {largestQuantity}\");"
                                    },
                                    new Paragraph
                                    {
                                        Body = "And we can combine nested trades with <code class='inline-code'>SelectMany</code>:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "DateTime newestNestedTrade = stocks\r\n    .SelectMany(stock => stock.Trades)\r\n    .Max(trade => trade.Date);\r\n\r\nConsole.WriteLine($\"Newest nested trade: {newestNestedTrade:d}\");"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Filtering Before Min or Max",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "You can filter first when you only care about part of the data."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "decimal highestApplePrice = trades\r\n    .Where(trade => trade.Symbol == \"AAPL\")\r\n    .Max(trade => trade.Price);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Be careful: <code class='inline-code'>Min()</code> and <code class='inline-code'>Max()</code> need at least one item. If the filtered collection is empty, the query will fail."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var appleTrades = trades\r\n    .Where(trade => trade.Symbol == \"AAPL\")\r\n    .ToList();\r\n\r\nif (appleTrades.Any())\r\n{\r\n    decimal highestApplePrice = appleTrades.Max(trade => trade.Price);\r\n    Console.WriteLine($\"Highest Apple price: {highestApplePrice:C}\");\r\n}"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Common Mistakes",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "Expecting <code class='inline-code'>Min()</code> or <code class='inline-code'>Max()</code> to return the whole object. These examples return one selected value.",
                                            "Using <code class='inline-code'>Max(trade => trade.Price)</code> when the real question is which trade had the highest price.",
                                            "Calling <code class='inline-code'>Min()</code> or <code class='inline-code'>Max()</code> on an empty filtered collection.",
                                            "Forgetting that dates can be sorted and aggregated too.")
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
                                        Body = "Use the sandbox space in <code class='inline-code'>Program.cs</code>. Type each query by hand for better memorisation, then print the result or inspect it with the debugger."
                                    },
                                    new Paragraph
                                    {
                                        Body = ExerciseList(
                                            "Find the lowest trade price.",
                                            "Find the highest trade price.",
                                            "Find the smallest trade quantity.",
                                            "Find the largest trade quantity.",
                                            "Find the earliest trade date.",
                                            "Find the most recent trade date.",
                                            "Filter trades to <code class='inline-code'>AAPL</code>, check that any exist, then find the highest price.",
                                            "Use <code class='inline-code'>SelectMany</code> to find the newest nested trade date across all stocks.")
                                    }
                                }
                            }
                        }
                },
                new Article
                {
                    Id = 500263,
                    CourseDisplayId = 15,
                    Title = "Getting the First Matching Item",
                    Slug = "getting-the-first-matching-item",
                    Description = "Learn how to use First and FirstOrDefault to retrieve one item from a collection.",
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
                                        Body = "Sometimes you do not want a collection. You only want one item. <code class='inline-code'>First()</code> and <code class='inline-code'>FirstOrDefault()</code> help us retrieve the first item from a sequence."
                                    },
                                    new Paragraph
                                    {
                                        Body = "These methods are useful when order matters, or when you only need the first match after filtering or sorting."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "First",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "<code class='inline-code'>First()</code> returns the first item in a collection."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var firstStock = stocks.First();"
                                    },
                                    new Paragraph
                                    {
                                        Body = "You can also pass a condition:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var firstAppleTrade = trades.First(trade => trade.Symbol == \"AAPL\");"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This means: return the first trade where the symbol is Apple."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "FirstOrDefault",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "<code class='inline-code'>FirstOrDefault()</code> also returns the first matching item, but it returns a default value when nothing is found."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var teslaStock = stocks.FirstOrDefault(stock => stock.Symbol == \"TSLA\");\r\n\r\nif (teslaStock is not null)\r\n{\r\n    Console.WriteLine(teslaStock.CompanyName);\r\n}"
                                    },
                                    new Paragraph
                                    {
                                        Body = "For reference types such as classes, the default value is usually <code class='inline-code'>null</code>. That is why we check before using the result."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Using First in the Course Project",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "A common pattern is to sort first, then take the first item."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var newestTrade = trades\r\n    .OrderByDescending(trade => trade.Date)\r\n    .First();\r\n\r\nConsole.WriteLine($\"Newest trade: {newestTrade.Symbol} on {newestTrade.Date:d}\");"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This works because we put the newest trade first, then retrieved the first item."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var firstTechnologyStock = stocks\r\n    .OrderBy(stock => stock.CompanyName)\r\n    .FirstOrDefault(stock => stock.Sector == \"Technology\");\r\n\r\nif (firstTechnologyStock is not null)\r\n{\r\n    Console.WriteLine(firstTechnologyStock.CompanyName);\r\n}"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "First vs FirstOrDefault",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "Use <code class='inline-code'>First()</code> when the item must exist and it would be a bug if it does not.",
                                            "Use <code class='inline-code'>FirstOrDefault()</code> when the item might not exist.",
                                            "Always check the result of <code class='inline-code'>FirstOrDefault()</code> before using it if it could be null.")
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Common Mistakes",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "Using <code class='inline-code'>First()</code> when there might be no matching item.",
                                            "Forgetting that <code class='inline-code'>First()</code> depends on the current order of the collection.",
                                            "Using <code class='inline-code'>FirstOrDefault()</code> and then immediately accessing properties without a null check.",
                                            "Expecting <code class='inline-code'>First()</code> to prove that there is only one match. It only returns the first match.")
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
                                        Body = "Use the sandbox space in <code class='inline-code'>Program.cs</code>. Type each query by hand for better memorisation, then print the result or inspect it with the debugger."
                                    },
                                    new Paragraph
                                    {
                                        Body = ExerciseList(
                                            "Get the first stock.",
                                            "Get the first trade.",
                                            "Get the first trade where the symbol is <code class='inline-code'>AAPL</code>.",
                                            "Use <code class='inline-code'>FirstOrDefault</code> to look for a stock symbol that may not exist.",
                                            "Sort trades by newest date first, then get the first trade.",
                                            "Sort stocks by company name, then get the first stock.",
                                            "Use <code class='inline-code'>SelectMany</code> to get the first nested trade across all stocks.",
                                            "Write one example where <code class='inline-code'>FirstOrDefault</code> needs a null check.")
                                    }
                                }
                            }
                        }
                },
                new Article
                {
                    Id = 500264,
                    CourseDisplayId = 16,
                    Title = "Getting Exactly One Item",
                    Slug = "getting-exactly-one-item",
                    Description = "Learn how to use Single and SingleOrDefault when a query should return exactly one item.",
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
                                        Body = "<code class='inline-code'>Single()</code> and <code class='inline-code'>SingleOrDefault()</code> are stricter than <code class='inline-code'>First()</code>. They are used when your query should match exactly one item."
                                    },
                                    new Paragraph
                                    {
                                        Body = "This makes them useful for unique values, such as a stock symbol, an id, or any value that your program expects to identify one record."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Single",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "<code class='inline-code'>Single()</code> returns the only item that matches. If there are zero matches or more than one match, it fails."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var appleStock = stocks.Single(stock => stock.Symbol == \"AAPL\");"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This is appropriate if each stock symbol is expected to be unique in the stock list."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "SingleOrDefault",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "<code class='inline-code'>SingleOrDefault()</code> allows zero matches, but it still fails if there is more than one match."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var stock = stocks.SingleOrDefault(stock => stock.Symbol == \"AAPL\");\r\n\r\nif (stock is not null)\r\n{\r\n    Console.WriteLine(stock.CompanyName);\r\n}"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This means: return the matching stock if exactly one exists. Return null if no stock exists. Fail if more than one matching stock exists."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Single vs First",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "The difference between <code class='inline-code'>First</code> and <code class='inline-code'>Single</code> is about intent."
                                    },
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "<code class='inline-code'>First</code> means: give me the first match, and I do not care if more matches exist.",
                                            "<code class='inline-code'>Single</code> means: there should be exactly one match.",
                                            "<code class='inline-code'>SingleOrDefault</code> means: there should be zero or one match, but never many.")
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Using Single in the Course Project",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Stock symbols are a good example for <code class='inline-code'>Single</code> because each symbol should identify one stock."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var microsoft = stocks.Single(stock => stock.Symbol == \"MSFT\");\r\n\r\nConsole.WriteLine(microsoft.CompanyName);"
                                    },
                                    new Paragraph
                                    {
                                        Body = "If the user enters a symbol, <code class='inline-code'>SingleOrDefault</code> is usually safer because the symbol might not exist."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "string symbol = \"AAPL\";\r\n\r\nvar selectedStock = stocks.SingleOrDefault(stock => stock.Symbol == symbol);\r\n\r\nif (selectedStock is null)\r\n{\r\n    Console.WriteLine(\"Stock not found.\");\r\n}\r\nelse\r\n{\r\n    Console.WriteLine(selectedStock.CompanyName);\r\n}"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Common Mistakes",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "Using <code class='inline-code'>Single()</code> just because you only want one item. Use it when exactly one item should exist.",
                                            "Using <code class='inline-code'>Single()</code> on trades by symbol, where many trades can share the same symbol.",
                                            "Thinking <code class='inline-code'>SingleOrDefault()</code> is safe when multiple matches exist. It still fails if there is more than one match.",
                                            "Forgetting to check for null after <code class='inline-code'>SingleOrDefault()</code>.")
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
                                        Body = "Use the sandbox space in <code class='inline-code'>Program.cs</code>. Type each query by hand for better memorisation, then print the result or inspect it with the debugger."
                                    },
                                    new Paragraph
                                    {
                                        Body = ExerciseList(
                                            "Use <code class='inline-code'>Single</code> to get the stock with symbol <code class='inline-code'>AAPL</code>.",
                                            "Use <code class='inline-code'>Single</code> to get the stock with symbol <code class='inline-code'>MSFT</code>.",
                                            "Use <code class='inline-code'>SingleOrDefault</code> to search for a stock symbol that might not exist.",
                                            "Add a null check after <code class='inline-code'>SingleOrDefault</code>.",
                                            "Try using <code class='inline-code'>Single</code> on trades with symbol <code class='inline-code'>AAPL</code> and observe why it is the wrong method.",
                                            "Write a short comment explaining when you would choose <code class='inline-code'>First</code> instead of <code class='inline-code'>Single</code>.",
                                            "Write a short comment explaining when you would choose <code class='inline-code'>SingleOrDefault</code> instead of <code class='inline-code'>FirstOrDefault</code>.")
                                    }
                                }
                            }
                        }
                },
                new Article
                {
                    Id = 500265,
                    CourseDisplayId = 17,
                    Title = "Removing Duplicate Values With Distinct",
                    Slug = "removing-duplicate-values-with-distinct",
                    Description = "Learn how to use Distinct to return unique values from a collection.",
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
                                        Body = "<code class='inline-code'>Distinct()</code> removes duplicate values from a sequence. It is useful when you want a list of unique values instead of every repeated occurrence."
                                    },
                                    new Paragraph
                                    {
                                        Body = "For example, a trade list might contain many trades for the same symbol. <code class='inline-code'>Distinct</code> can help us find the unique symbols that appear in those trades."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Distinct With Simple Values",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "<code class='inline-code'>Distinct</code> works best when the sequence contains simple values such as strings, numbers, or dates."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var uniqueSymbols = trades\r\n    .Select(trade => trade.Symbol)\r\n    .Distinct()\r\n    .ToList();"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This means: select every trade symbol, remove duplicates, and store the unique symbols in a list."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Using Distinct in the Course Project",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "In the study project, <code class='inline-code'>Distinct</code> is useful for reports and filter menus."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var sectors = stocks\r\n    .Select(stock => stock.Sector)\r\n    .Distinct()\r\n    .OrderBy(sector => sector)\r\n    .ToList();\r\n\r\nforeach (var sector in sectors)\r\n{\r\n    Console.WriteLine(sector);\r\n}"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This creates a unique, sorted list of sectors."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var tradedSymbols = stocks\r\n    .SelectMany(stock => stock.Trades)\r\n    .Select(trade => trade.Symbol)\r\n    .Distinct()\r\n    .OrderBy(symbol => symbol)\r\n    .ToList();"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This flattens nested trades, selects their symbols, removes duplicates, and sorts the result."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Distinct With Objects",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Be careful when using <code class='inline-code'>Distinct()</code> directly on objects. Two different object instances may look the same to a person but still be treated as different by C#."
                                    },
                                    new Paragraph
                                    {
                                        Body = "For beginner LINQ work, a clear pattern is to select the property you care about first, then call <code class='inline-code'>Distinct()</code>."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var uniqueCompanyNames = stocks\r\n    .Select(stock => stock.CompanyName)\r\n    .Distinct()\r\n    .ToList();"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This avoids ambiguity because the query is working with strings instead of whole stock objects."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Combining Distinct With Other LINQ Methods",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "<code class='inline-code'>Distinct</code> is often used after <code class='inline-code'>Select</code> and before <code class='inline-code'>OrderBy</code>."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var symbolsWithLargeTrades = trades\r\n    .Where(trade => trade.Quantity > 100)\r\n    .Select(trade => trade.Symbol)\r\n    .Distinct()\r\n    .OrderBy(symbol => symbol)\r\n    .ToList();"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This means: find large trades, select their symbols, remove duplicate symbols, then sort the symbols alphabetically."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Common Mistakes",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "Calling <code class='inline-code'>Distinct()</code> on whole objects when you really need unique property values.",
                                            "Forgetting to use <code class='inline-code'>Select</code> before <code class='inline-code'>Distinct</code>.",
                                            "Expecting <code class='inline-code'>Distinct</code> to sort results. Use <code class='inline-code'>OrderBy</code> if order matters.",
                                            "Using <code class='inline-code'>Distinct</code> when you actually need counts per group. That is a grouping problem, not just a uniqueness problem.")
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
                                        Body = "Use the sandbox space in <code class='inline-code'>Program.cs</code>. Type each query by hand for better memorisation, then print the result or inspect it with the debugger."
                                    },
                                    new Paragraph
                                    {
                                        Body = ExerciseList(
                                            "Create a unique list of stock sectors.",
                                            "Create a unique list of stock symbols.",
                                            "Create a unique list of trade symbols.",
                                            "Create a unique list of trade types.",
                                            "Create a unique list of symbols that have trades with quantity greater than 100.",
                                            "Use <code class='inline-code'>SelectMany</code> to create a unique list of nested trade symbols.",
                                            "Sort one distinct result alphabetically.",
                                            "Print every value from one distinct result using a <code class='inline-code'>foreach</code> loop.")
                                    }
                                }
                            }
                        }
                },
                new Article
                {
                    Id = 500266,
                    CourseDisplayId = 18,
                    Title = "Course Project: Stock Insights Reporter",
                    Slug = "course-project-stock-insights-reporter",
                    Description = "Build a reporting feature that uses every LINQ method covered in the beginner course.",
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
                                        Body = "You have reached the end of the beginner LINQ course. The final project is to extend the study application with a reporting feature called <b>Stock Insights Reporter</b>."
                                    },
                                    new Paragraph
                                    {
                                        Body = "This project should feel like a real application feature. Instead of writing isolated LINQ queries in the sandbox, you will build menu options that ask the user for filters, produce useful stock and trade reports, and display the results clearly."
                                    },
                                    new Paragraph
                                    {
                                        Body = "The goal is simple: prove that you can use LINQ to answer practical questions about data."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Project Goal",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Add a new menu option to the application:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "Print stock report"
                                    },
                                    new Paragraph
                                    {
                                        Body = "When the user selects this option, show a report menu where they can choose which report to run. Each report should use LINQ to query, transform, sort, aggregate, or inspect the existing stock and trade data."
                                    },
                                    new Paragraph
                                    {
                                        Body = "Use <b>Spectre.Console</b> prompts and tables where appropriate. The final result should be readable, intentional, and easy to test manually."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Methods You Must Use",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Your completed project must include at least one meaningful use of every LINQ method covered in this course:"
                                    },
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "<code class='inline-code'>Where()</code>",
                                            "<code class='inline-code'>Select()</code>",
                                            "<code class='inline-code'>SelectMany()</code>",
                                            "<code class='inline-code'>Any()</code>",
                                            "<code class='inline-code'>All()</code>",
                                            "<code class='inline-code'>Contains()</code>",
                                            "<code class='inline-code'>OrderBy()</code>",
                                            "<code class='inline-code'>OrderByDescending()</code>",
                                            "<code class='inline-code'>ThenBy()</code>",
                                            "<code class='inline-code'>ThenByDescending()</code>",
                                            "<code class='inline-code'>Count()</code>",
                                            "<code class='inline-code'>LongCount()</code>",
                                            "<code class='inline-code'>Sum()</code>",
                                            "<code class='inline-code'>Average()</code>",
                                            "<code class='inline-code'>Min()</code>",
                                            "<code class='inline-code'>Max()</code>",
                                            "<code class='inline-code'>First()</code>",
                                            "<code class='inline-code'>FirstOrDefault()</code>",
                                            "<code class='inline-code'>Single()</code>",
                                            "<code class='inline-code'>SingleOrDefault()</code>",
                                            "<code class='inline-code'>Distinct()</code>")
                                    },
                                    new Paragraph
                                    {
                                        Body = "Do not use a method just to tick a box. Each method should help answer a real question in the reporting feature."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Required Reports",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Create a report menu with these report options:"
                                    },
                                    new Paragraph
                                    {
                                        Body = ExerciseList(
                                            "<b>Portfolio Summary</b>: show total stocks, total trades, total quantity traded, total trade value, average trade price, lowest trade price, highest trade price, earliest trade date, and most recent trade date.",
                                            "<b>Stocks By Sector</b>: ask the user to choose a sector, then show stocks from that sector ordered by company name.",
                                            "<b>Trades By Symbol</b>: ask the user for a stock symbol, validate it, then show matching trades ordered by newest date first.",
                                            "<b>High-Volume Trades</b>: ask for a minimum quantity, then show trades at or above that quantity ordered by symbol and quantity descending.",
                                            "<b>Stock Activity Report</b>: show one row per stock with symbol, company name, sector, trade count, total quantity, total value, highest trade price, and latest trade date.",
                                            "<b>Unique Values Report</b>: show unique sectors, unique stock symbols, unique trade symbols, and unique trade types.",
                                            "<b>Data Quality Report</b>: show whether all stocks have trades, whether any trade exceeds a chosen value, and whether the stock list contains a symbol entered by the user.")
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Required Custom Types",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Create at least one custom type for a report row. Do not print only raw stock and trade objects."
                                    },
                                    new Paragraph
                                    {
                                        Body = "For example, you can create this type:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "public class StockActivityReportRow\r\n{\r\n    public string Symbol { get; set; } = string.Empty;\r\n    public string CompanyName { get; set; } = string.Empty;\r\n    public string Sector { get; set; } = string.Empty;\r\n    public int TradeCount { get; set; }\r\n    public int TotalQuantity { get; set; }\r\n    public decimal TotalValue { get; set; }\r\n    public decimal HighestTradePrice { get; set; }\r\n    public DateTime LatestTradeDate { get; set; }\r\n}"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Then use <code class='inline-code'>Select</code> to project stocks into this custom type:"
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "var reportRows = stocks\r\n    .Select(stock => new StockActivityReportRow\r\n    {\r\n        Symbol = stock.Symbol,\r\n        CompanyName = stock.CompanyName,\r\n        Sector = stock.Sector,\r\n        TradeCount = stock.Trades.Count(),\r\n        TotalQuantity = stock.Trades.Sum(trade => trade.Quantity),\r\n        TotalValue = stock.Trades.Sum(trade => trade.Price * trade.Quantity),\r\n        HighestTradePrice = stock.Trades.Max(trade => trade.Price),\r\n        LatestTradeDate = stock.Trades.Max(trade => trade.Date)\r\n    })\r\n    .OrderBy(row => row.Sector)\r\n    .ThenBy(row => row.Symbol)\r\n    .ToList();"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "User Input Requirements",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "The user should not only choose static reports. At least three reports must ask the user for a parameter before running."
                                    },
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "Ask for a stock symbol, such as <code class='inline-code'>AAPL</code> or <code class='inline-code'>MSFT</code>.",
                                            "Ask for a sector selected from the distinct sectors in the stock list.",
                                            "Ask for a minimum trade quantity.",
                                            "Ask for a minimum trade value.",
                                            "Ask whether results should be sorted ascending or descending.")
                                    },
                                    new Paragraph
                                    {
                                        Body = "Validate user input where it matters. For example, use <code class='inline-code'>Contains</code>, <code class='inline-code'>Any</code>, <code class='inline-code'>FirstOrDefault</code>, or <code class='inline-code'>SingleOrDefault</code> before trying to print data that may not exist."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Specific Method Requirements",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Use these requirements as a checklist while building the project:"
                                    },
                                    new Paragraph
                                    {
                                        Body = ExerciseList(
                                            "Use <code class='inline-code'>Where</code> to filter trades by symbol, quantity, type, or value.",
                                            "Use <code class='inline-code'>Select</code> to create report rows or smaller display models.",
                                            "Use <code class='inline-code'>SelectMany</code> to flatten nested stock trades.",
                                            "Use <code class='inline-code'>Any</code> to check whether matching trades exist before printing a report.",
                                            "Use <code class='inline-code'>All</code> to verify that every stock has at least one trade.",
                                            "Use <code class='inline-code'>Contains</code> to validate a symbol or sector against a known list.",
                                            "Use <code class='inline-code'>OrderBy</code> and <code class='inline-code'>ThenBy</code> for multi-level stock sorting.",
                                            "Use <code class='inline-code'>OrderByDescending</code> and <code class='inline-code'>ThenByDescending</code> for newest or largest-first trade reports.",
                                            "Use <code class='inline-code'>Count</code> to count stocks, trades, or matching records.",
                                            "Use <code class='inline-code'>LongCount</code> in at least one report to show that you understand its purpose.",
                                            "Use <code class='inline-code'>Sum</code> to calculate total quantity or total trade value.",
                                            "Use <code class='inline-code'>Average</code> to calculate average price or average quantity.",
                                            "Use <code class='inline-code'>Min</code> and <code class='inline-code'>Max</code> to find lowest, highest, earliest, or latest values.",
                                            "Use <code class='inline-code'>First</code> after sorting to retrieve the top item from a known non-empty list.",
                                            "Use <code class='inline-code'>FirstOrDefault</code> when the result might not exist.",
                                            "Use <code class='inline-code'>Single</code> when querying a stock by a symbol that must uniquely exist.",
                                            "Use <code class='inline-code'>SingleOrDefault</code> when querying a user-entered symbol that might not exist.",
                                            "Use <code class='inline-code'>Distinct</code> to build unique lists for report filters.")
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Output Requirements",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Your reports should be easy to read. Use clear report titles, meaningful column names, and formatted values."
                                    },
                                    new Paragraph
                                    {
                                        Body = RedDotList(
                                            "Currency values should be formatted as currency where possible.",
                                            "Dates should be formatted consistently.",
                                            "Empty reports should show a helpful message instead of a blank table.",
                                            "Tables should include only the columns needed for the selected report.",
                                            "After each report, let the user return to the report menu or main menu.")
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Suggested Structure",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Keep the code organised. A final project becomes much easier to reason about when each report has its own method."
                                    },
                                    new Paragraph
                                    {
                                        IsCode = true,
                                        Body = "static void PrintPortfolioSummary(List<Stock> stocks, List<Trade> trades)\r\n{\r\n    // Summary queries go here\r\n}\r\n\r\nstatic void PrintTradesBySymbol(List<Trade> trades, string symbol)\r\n{\r\n    // Symbol report queries go here\r\n}\r\n\r\nstatic void PrintStockActivityReport(List<Stock> stocks)\r\n{\r\n    // Projection into report rows goes here\r\n}"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This is still a LINQ project, not an architecture project. Keep the structure simple, but avoid putting every query into one giant block of code."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Advanced Challenges",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "These challenges are optional. Try them after the required reports work correctly."
                                    },
                                    new Paragraph
                                    {
                                        Body = ExerciseList(
                                            "Add a report that lets the user choose the sort field and sort direction at runtime.",
                                            "Add a date range filter for trades.",
                                            "Add a minimum and maximum trade value filter.",
                                            "Add a top-results option, such as showing only the top 5 highest-value trades.",
                                            "Create separate report row classes for at least three reports.",
                                            "Move report-printing logic into a dedicated report service class.",
                                            "Add guard clauses so reports do not crash if a filtered collection is empty.",
                                            "Add a small test data scenario where a report intentionally returns no results, then handle it cleanly.",
                                            "Use Spectre.Console markup or table styling to make important values stand out.",
                                            "Create a final summary screen that lists which reports were run during the current session.")
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Completion Checklist",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "Before considering the project complete, check each item below:"
                                    },
                                    new Paragraph
                                    {
                                        Body = ExerciseList(
                                            "The application has a working <code class='inline-code'>Print stock report</code> menu option.",
                                            "The report menu contains all required reports.",
                                            "At least three reports ask the user for input.",
                                            "Every LINQ method listed in this lesson is used meaningfully.",
                                            "At least one report uses a custom report row type.",
                                            "At least one report uses nested trades through <code class='inline-code'>SelectMany</code>.",
                                            "Reports print clean output instead of raw debugging information.",
                                            "Empty or invalid user input is handled gracefully.",
                                            "The code is split into clear methods.",
                                            "You manually tested every report option.")
                                    },
                                    new Paragraph
                                    {
                                        Body = "When this project is finished, you have done more than memorise LINQ method names. You have used LINQ to build a real reporting feature, which is exactly how these skills appear in professional C# applications."
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
                                        Body = "In your submission notes, mention that this is the final project for the beginner LINQ course and briefly describe which reports you added. This helps the reviewer understand what to look for when checking your work."
                                    }
                                }
                            }
                        }
                }
            }
        };
    }
}

