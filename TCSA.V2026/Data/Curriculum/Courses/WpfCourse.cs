using TCSA.V2026.Data.Models;

namespace TCSA.V2026.Data.Curriculum;

public class WpfCourse
{
    public static Course GetWpfCourse()
    {
        return new Course
        {
            Id = 5,
            Title = "Introduction to WPF",
            Description = "Build stunning desktop apps with XAML and C# in WPF!",
            ImgUrl = "icons8-application-64.png",
            Articles = new List<Article>
                {
                    new Article
                    {
                        Id = 500100,
                        CourseDisplayId = 1,
                        Title = "Introduction",
                        Slug = "intro-to-wpf-intro",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Title = "What is WPF?",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                        Body = "Windows Presentation Foundation, or WPF, is a powerful framework for building modern desktop applications on Windows. First introduced by Microsoft as part of the .NET Framework, WPF leverages the combination of <b>XAML</b> (a declarative markup language) and C# to create visually rich and interactive user interfaces. WPF is designed to provide flexibility in UI design, offering capabilities such as data binding, advanced graphics, animations, and styling."
                                    },
                                    new Paragraph {
                                       Body = "At its core, WPF is built on a <b>vector-based rendering engine</b>, which allows for scalable, resolution-independent visuals. This means that the interface looks sharp and performs consistently across different screen resolutions. With support for both 2D and 3D graphics, developers can create applications that are not just functional but also visually stunning."
                                    },
                                    new Paragraph {
                                        BackgroundColor="#c9436e",
                                        FontColor="#FFF",
                                        Body = "Unfortunately WPF can only be developed on Windows. It was architected as part of the .NET Framework and deeply integrated into Windows-only APIs, especially DirectX, for rendering graphics; Win32 and Windows Messages, a native message loop and windowing system and Milcore: A low-level rendering engine that’s deeply tied to Windows internals and was never intended to run cross-platform. If you're not on Windows, don't worry, we'll soon release a similar intro course on Avalonia UI, a fully XAML based cross-platform technology." },
                                    new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c5-ch1-wpf-logo.png"}
                                }
                            },
                            new Block
                            {
                                Title = "Why Learn WPF?",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                       Body = "WPF remains a key technology for developers building robust and feature-rich desktop applications. Its comprehensive tools and components enable developers to focus on crafting user experiences rather than worrying about the complexities of UI management."
                                    },
                                    new Paragraph
                                    {
                                       Body = "WPF is also highly extensible, supporting both enterprise-grade applications and smaller personal projects. Despite the rise of web and mobile technologies, WPF is still widely used in industries like finance, healthcare, and engineering, where desktop applications are preferred for their reliability, performance, and offline capabilities."
                                    },
                                    new Paragraph
                                    {
                                       Body = "While WPF may not enjoy the hype of newer technologies, it remains a reliable and powerful framework with a dedicated community and a solid place in enterprise development. Its longevity is a testament to its design and capability, making it an excellent choice for developers focused on building sophisticated desktop applications."
                                    },
                                }
                            },
                            new Block
                            {
                                Title = "Key Features of WPF",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "WPF provides developers with a set of tools that simplify application development. Some of the most notable features include:<br> ➡️ <b>Data Binding</b>: Connect UI components directly to data sources, ensuring real-time updates and synchronization.<br>➡️ <b>Styles and Templates</b>: Customize and theme your application to maintain a consistent look and feel.<br>➡️ <b>Animations and Graphics</b>:Build dynamic and visually appealing applications with support for animations and rich media.<br>➡️ <b>Layouts</b> Arrange UI components dynamically, ensuring the application looks great on any window size or resolution.\r\n" }
                                }
                            },
                            new Block
                            {
                                Title = "A Bit of History",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "Microsoft has provided numerous frameworks and technologies over the years for building desktop applications on Windows. <br> 🔹Early on, developers used <b>Win32 API</b>, a low-level C-based interface offering direct control over Windows components. <br> 🔹Then came <b>MFC</b> (Microsoft Foundation Classes), a C++ wrapper around Win32 that simplified UI programming while still requiring manual memory management and COM interactions. <br> 🔹 Later, Microsoft introduced <b>Windows Forms</b> (WinForms) with .NET, which brought a higher-level, event-driven programming model and RAD (rapid application development) tools in Visual Studio, making it easier for developers to build GUI applications with drag-and-drop interfaces. <br> 🔹Then came <b>UWP</b> (Universal Windows Platform), which aimed to unify development across PCs, tablets, Xbox, and other Windows 10+ devices, but suffered from limited adoption and ecosystem constraints. <br> 🔹More recently, Microsoft introduced <b>WinUI</b>, part of the Windows App SDK, which evolves UWP into a modern, flexible framework that works well with both Win32 and .NET apps." },
                                    new Paragraph {
                                       Body = "With so many options, why pick WPF? In our opinion, WPF is the most mature and reliable of the above. Even considering the downside of being limited to building Windows Apps, a production app demands a <b>battle-tested</b> framework and that can be said of WPF. It's also important to note that learning WPF means learning XAML, which is used by a few of frameworks above. Even if you decide to switch later, the <b>knowledge from WPF will transfer</b> to the chosen framework." }
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                        BackgroundColor="#1C236D",
                                        FontColor="#FFF",
                                        Body = "Did you know that WPF was originally codenamed \"Avalon\" during its development at Microsoft? Before it was formally introduced with .NET Framework 3.0 in 2006, Avalon was envisioned as the next big leap in desktop UI—bringing together declarative XAML, advanced graphics with DirectX, and a fully vector-based rendering engine. Kind of like a secret identity before it put on the WPF cape. \U0001f9b8‍♂️" }
                                }
                            },
                        }
                    },
                    new Article
                    {
                        Id = 500101,
                        CourseDisplayId = 2,
                        Title = "About the Course",
                        Slug = "intro-to-wpf-about",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Title = "What to Expect?",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                        Body = "This course is designed as a <b>hands-on introduction</b> to Windows Presentation Foundation (WPF). Instead of overwhelming you with abstract concepts or exhaustive theory, we’ll focus on building a <b>practical and engaging project</b> from start to finish. By the end of the course, you’ll have a simple,  fully functional desktop application that showcases the power and versatility of WPF."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "What Will We Build?",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "The project we’ll create is a <b>Recipes Manager</b> — an application that allows users to manage, edit, and save their favorite recipes. Through this project, you’ll explore WPF’s key features, including dynamic layouts, user interaction through controls, and data persistence using <b>SQLite with Entity Framework</b>."
                                    },
                                    new Paragraph
                                    {
                                        IsPicture = true,
                                        PictureUrl = "c5-ch15-wpf-styling.png"
                                    },
                                    new Paragraph {
                                       Body = "This course takes a practical approach, <b>skipping the advanced Model-View-ViewModel (MVVM)</b> design pattern, which is commonly used in WPF applications. Instead, we’ll stick to a straightforward code-behind pattern to make it easier for you to understand the core mechanics of WPF. While MVVM is a powerful tool for building scalable and maintainable applications, it can be complex for beginners. For now, our goal is to <b>focus on the basics</b> and build a strong foundation."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Pre-requisites",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "It’s important to note that this course is <b>not for absolute beginners</b>. To get the most out of the lessons, you should already have a working knowledge of:<br>✅<b>C#</b>: Understanding classes, methods, events, and basic object-oriented programming is essential.<br>✅<b>SQL</b>: You should be familiar with basic SQL concepts, such as creating tables and performing CRUD (Create, Read, Update, Delete) operations.<br> ✅<b>Entity Framework </b>: A basic understanding of how Entity Framework works, including setting up a database context and performing queries, will be helpful."
                                    },
                                }
                            },
                            new Block
                            {
                                Title = ".NET Desktop Development Workload",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "When installing Visual Studio, you had different workload options to choose from. If you haven't installed .NET Desktop Development Workload <b>you won't see WPF as a project option</b> when creating a new project. If that is the case, download <a href='https://visualstudio.microsoft.com/downloads/ target='_blank'>Visual Studio Installer</a> and install it:"
                                    },
                                    new Paragraph
                                    {
                                        IsPicture = true,
                                        PictureUrl = "c5-ch2-wpf-workflow.png"
                                    },
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                        BackgroundColor="#1C236D",
                                        FontColor="#FFF",
                                        Body = "Bill Gates had to be convinced Yep, the big guy himself. The WPF team needed to pitch the vision of a unified UI framework that could handle documents, media, and interactivity. Gates eventually gave the green light, and WPF became part of .NET Framework 3.0 in 2006." }
                                }
                            },
                        }
                    },
                    new Article
                    {
                        Id = 500102,
                        CourseDisplayId = 3,
                        Title = "Project Creation",
                        Slug = "intro-to-wpf-project-creation",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                        Body = "In this chapter, we’ll walk through the process of creating your very first WPF project and running it. We won’t dive into any coding yet; instead, we’ll <b>focus on getting the project set up correctly</b> in Visual Studio, ensuring that everything is ready to go before we start building our application."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Selecting WPF",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "Launch Visual Studio on your machine. Once Visual Studio is open, click on the <b>Create a new project</b> button. This will bring up the project template wizard. When searching for WPF you'll see a few options: WPF with Visual Basic (VB), WPF App (.NET Framework) and WPF Applicaton with C#. Select Select <b>WPF Application</b> (not .NET Framework). "
                                    },
                                    new Paragraph
                                    {
                                        IsPicture = true,
                                        PictureUrl = "c5-ch3-wpf-project-type.png"
                                    },
                                }
                            },
                            new Block
                            {
                                Title = "Configuring Your Project",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "After selecting the WPF App template, you'll be prompted to name your project. To keep things simple in case you want to use our code, we suggest we name it <b>TCSA.Recipes</b> For the location, choose a directory where you want to save your project. For the solution Name: Visual Studio will automatically set the solution name to match your project name, but you can change it if needed. Click on <b>Next</b>. Then choose .NET's version. We'll choose <b>.NET 9</b>, the latest at the moment this tutorial is being written. Once you’ve configured your project, click on <b>Create</b>.\r\n" },
                                    new Paragraph
                                    {
                                        IsPicture = true,
                                        PictureUrl = "c5-ch3-wpf-configure.png"
                                    },
                                    new Paragraph {
                                        Body = "Visual Studio will now generate a default WPF project for you. It will include several files and folders, but the most important for us right now is the <b>MainWindow.xaml</b> file, which contains the UI layout of the application, and the <b>MainWindow.xaml.cs</b> file, where we will write the logic to control how the application behaves."
                                    },
                                    new Paragraph
                                    {
                                        IsPicture = true,
                                        PictureUrl = "c5-ch3-wpf-files.png"
                                    },
                                }
                            },
                            new Block
                            {
                                Title = "Running Your Project",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "To run the application, <b>click the green button</b> alongside the project's name in Visual Studio, or <b>press F5</b>. This will start the app and launch the </b>MainWindow.xaml</b> by default. You should see a blank window appear with the default WPF UI layout. It won’t have any functionality yet, but the project is now set up and running."
                                    },
                                    new Paragraph
                                    {
                                        IsPicture = true,
                                        PictureUrl = "c5-ch3-start-button.png"
                                    },
                                    new Paragraph
                                    {
                                        IsPicture = true,
                                        PictureUrl = "c5-ch3-blank-app.png"
                                    },
                                    new Paragraph {
                                       Body = "After verifying that the application runs successfully, close the window. We’re now ready to start customizing the project to suit our needs."
                                    },
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500103,
                        CourseDisplayId = 4,
                        Title = "Exploring the Template",
                        Slug = "intro-to-wpf-exploring",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Title = "MainWindow.xaml",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                        Body = "<b>MainWindow.xaml</b> is the primary file where the user interface (UI) of your WPF application is defined. It uses <b>XAML</b> (Extensible Application Markup Language), a declarative markup language, to describe the structure and layout of the UI elements such as buttons, text boxes, labels, and grids. In this file, you can arrange controls, set properties like size and color, and apply styles. This file <b>serves as the blueprint</b> for the window users will interact with in the application."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "App.xaml",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "App.xaml is responsible for defining application-wide resources, styles, and global settings that can be shared across all windows and controls in the application. It typically includes things like color schemes, fonts, and custom resources that can be accessed anywhere in the app. This file also <b>specifies which window should open</b> when the application starts, typically the <b>MainWindow</b>. It serves as the <b>entry point</b> for application-level settings and resources."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "App.xaml.cs",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "The <b>App.xaml.cs</b> file contains the application logic, handling startup and shutdown events. This file includes the code that runs when the application is launched, such as initializing application-level resources and defining which window should appear first. In our case, it launches <b>MainWindow.xaml</b> when the application starts, and clean up resources when the application closes. It serves as the entry point for <b>the app's life cycle</b>."
                                    },
                                }
                            },
                            new Block
                            {
                                Title = "So what's XAML?",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "XAML (Extensible Application Markup Language) is a markup language used to <b>define the structure and appearance</b> of user interfaces in WPF applications. It’s a declarative language, meaning you describe the elements of your UI in a <b>hierarchical, readable format</b> rather than writing procedural code to create and manipulate each UI element manually. XAML is tightly integrated with C# in WPF, with C# handling the logic and XAML defining the layout. In a WPF project, XAML files describe elements such as buttons, grids, text boxes, and other controls, along with their properties like size, color, and alignment."
                                    },
                                    new Paragraph {
                                       Body = "XAML is designed to be both human-readable and machine-readable, making it easy for designers and developers to collaborate on a project. Designers can focus on laying out the interface in XAML, while developers work on the functionality in C#. One of the main advantages of XAML is that <b>it allows for a clear separation of concerns</b> between the UI and logic, making it easier to maintain and scale applications. It also allows for powerful features like <b>data binding</b>, where UI elements are linked directly to data sources, ensuring the interface automatically updates when the underlying data changes"
                                    },
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500104,
                        CourseDisplayId = 5,
                        Title = "Visual Studio Components",
                        Slug = "intro-to-wpf-vs-components",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Title = "Running the App",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                        Body = "With the application running you can also see the following Visual Studio tools:"
                                    },
                                }
                            },
                            new Block
                            {
                                Title = "Live Visual Tree",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                        Body = "A debugging tool that allows you to see the entire <b>hierarchy of elements</b> currently in the visual tree of your application while it's running. It dynamically updates as you interact with your application, showing you a tree-like structure of all the UI elements, such as buttons, grids, and text blocks. This tool helps you visualize how the elements are nested and allows you to <b>inspect their properties in real-time</b>, making it easier to understand the layout and troubleshoot issues related to element visibility or arrangement."
                                    },
                                    new Paragraph
                                    {
                                        IsPicture = true,
                                        PictureUrl = "c5-ch5-wpf-live-visual-tree.png"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "XAML Live Preview",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "Another debugging feature that enables you to <b>preview your XAML UI code live</b> as you make changes. With this tool, you can see the updated interface without needing to manually recompile or restart the application. It provides a real-time preview of your XAML layout, which is especially helpful for adjusting design elements like colors, alignment, or control sizes. This preview can also reflect changes made to the XAML code in the editor, allowing you to immediately see how the interface will look in the app, streamlining the development process."
                                    },
                                    new Paragraph
                                    {
                                        IsPicture = true,
                                        PictureUrl = "c5-ch5-wpf-xaml-live-preview.png"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "XAML Binding Failures",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "A diagnostic tool that helps you <b>track issues related to data binding</b>. In WPF, data binding is a key feature that connects the UI to the underlying data, but if there are errors or mismatches in the bindings, the UI may not update as expected. The XAML Binding Failures tool shows you any <b>failed bindings in real time</b>, displaying the details of the error, such as the source of the data, the target property, and the error message. This makes it easier to identify and fix binding issues, ensuring that the UI reflects the data properly."
                                    },
                                    new Paragraph
                                    {
                                        IsPicture = true,
                                        PictureUrl = "c5-ch5-wpf-binding-failures.png"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Live Property Explorer",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "A tool that allows you to inspect and modify the properties of the UI elements in your running app. By selecting an element in the Live Visual Tree or XAML, you can view its current properties such as size, color, margin, and font. You can  tweak these properties interactively, providing <b>immediate feedback on how changes affect the UI</b>. This tool is invaluable for debugging and adjusting styles, as it enables you to see exactly how different properties impact the appearance and behavior of the UI without having to go back to the XAML code."
                                    },
                                    new Paragraph
                                    {
                                        IsPicture = true,
                                        PictureUrl = "c5-ch5-wpf-property-explorer.png"
                                    }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500105,
                        CourseDisplayId = 6,
                        Title = "Main Window",
                        Slug = "intro-to-wpf-main-window",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                        Body = "Open <b>MainWindow.xaml</b>, In the Window tag, most of the attributes are either necessary for the functionality of the WPF window or are part of good development practices, but some of them can be safely removed depending on your project needs. Here's a breakdown of what can be removed or modified without affecting the basic functionality of your application:"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "What You Can Safely Remove",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "🔴 <b>xmlns:d=\"http://schemas.microsoft.com/expression/blend/2008\"</b> : This namespace is used for design-time data and features in tools like Expression Blend. If you're not using Expression Blend or any design-time data features, you can safely remove this. It’s not needed for runtime functionality, and removing it won't affect the application."
                                    },
                                    new Paragraph {
                                       Body = "🔴 <b>xmlns:mc=\"http://schemas.openxmlformats.org/markup-compatibility/2006\" </b> : The `mc` namespace is related to markup compatibility and is typically used for handling different versions of XAML and ignoring certain design-time attributes. For most simple WPF applications, this namespace isn’t strictly necessary unless you need to handle backward compatibility or complex scenarios. It can be removed safely."
                                    },
                                    new Paragraph {
                                       Body = "🔴 <b>mc:Ignorable=\"d\"</b> : This attribute works in conjunction with the `d` namespace and tells the XAML parser to ignore any design-time data. If you're not using design-time tools or data, this attribute can also be removed."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "What We Should Keep",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "🔵 <b> x:Class=\"TCSA.WPF.Recipes.MainWindow\"</b> : This is essential because it links the XAML to the C# code-behind class. You cannot remove this, as it tells the application which class is associated with this XAML file."
                                    },
                                    new Paragraph {
                                       Body = "🔵 <b>xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"</b>: This is the default namespace for WPF elements and controls. It's necessary for all WPF controls to work, so this cannot be removed."
                                    },
                                    new Paragraph {
                                       Body = "🔵 <b>xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\"</b> : This is the XAML namespace used for defining XAML-specific features, such as <b>x:Name</b>, <b>x:Class</b>, and others. It’s required and cannot be removed."
                                    },
                                    new Paragraph {
                                       Body = "🔵 <b>xmlns:local=\"clr-namespace:TCSA.WPF.Recipes\"</b> : This is used to reference classes within your own project (like custom controls, resources, or user controls). If you’re not using any custom controls or project-specific resources, you can remove it, but it’s often useful for adding references to your project's C# classes. If you plan to use custom elements, keep it."
                                    },
                                    new Paragraph {
                                       Body = "🔵 <b>Title=\"MainWindow\"</b> :  Used to set the window's title. You can change it to something else, but it's often useful to provide a meaningful title for your window."
                                    },
                                    new Paragraph {
                                       Body = "🔵 <b>Height=\"450\" Width=\"800\"</b> : These define the initial size of the window. While you can remove them, the window will default to a small size, and you might not want that. Adjusting the size is generally useful to fit your UI design."
                                    }
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "We end up with the cleaned up version:"
                                    },
                                    new Paragraph {
                                        IsCode = true,
                                       Body = "&lt;Window x:Class=&quot;TCSA.WPF.Recipes.MainWindow&quot;<br>\r\n&nbsp;&nbsp;xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;<br>\r\n&nbsp;&nbsp;xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;<br>\r\n&nbsp;&nbsp;Title=&quot;MainWindow&quot; Height=&quot;450&quot; Width=&quot;800&quot;&gt;<br>\r\n&lt;/Window&gt;\r\n"
                                    }
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "You can find the code for the current state of this project <a href='https://github.com/TheCSharpAcademy/TCSA.Study.Recipes/tree/1.Main-Window-Cleanup' target='_blank'>in this link</a>." }
                                }
                            }

                        }
                    },
                    new Article
                    {
                        Id = 500106,
                        CourseDisplayId = 7,
                        Title = "Adding Some Text",
                        Slug = "intro-to-wpf-adding-some-text",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "In <b>MainWindow.xaml</b>, add the following code into the Grid tag:"
                                    },
                                    new Paragraph {
                                        IsCode = true,
                                       Body = "&lt;Grid&gt;\r\n    &lt;TextBlock \r\n        Text=&quot;Welcome to the Interactive Recipe Manager!&quot; \r\n        HorizontalAlignment=&quot;Center&quot; \r\n        VerticalAlignment=&quot;Center&quot; \r\n        FontSize=&quot;20&quot; \r\n        FontWeight=&quot;Bold&quot; /&gt;\r\n&lt;/Grid&gt;\r\n"
                                    },
                                    new Paragraph {
                                       Body = "You should see the change straight away in the UI:"
                                    },
                                    new Paragraph
                                    {
                                        IsPicture = true,
                                        PictureUrl = "c5-ch7-wpf-adding-text.png"
                                    },
                                }
                            },
                            new Block
                            {
                                Title = "The Grid Element",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                        Body = "The <b>Grid</b> element is a <b>container control</b> that is used to arrange its child elements in a flexible grid of rows and columns. In this example, the Grid doesn't have any rows or columns defined, so it will automatically stretch to take up the available space within its parent container (in this case, the <b>Window</b>)."
                                    },
                                     new Paragraph {
                                        Body = "The Grid is one of the most commonly used layout containers in WPF, as it provides a flexible way to align and arrange elements. It allows you to <b>define a structure with rows and columns</b> to place your UI elements exactly where you want them. In this case, it serves as the container for the <b>TextBlock</b>, but it's empty apart from that."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "The TextBlock",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "The <b>TextBlock</b> element is used to display a block of text in your UI. It is a lightweight control specifically designed for text output, offering a high level of performance. Unlike a <b>Label</b>, which can be used for both text and other types of content, a TextBlock is optimized purely for displaying text, making it a good choice when you just need to show a string."
                                    },
                                    new Paragraph {
                                       Body = "Here are the important attributes we use in this TextBlock: "
                                    },
                                    new Paragraph {
                                       Body = "🔹<b>Text=\"Welcome to the Interactive Recipe Manager!\"</b> : This is the text that will be displayed. You can customize the content to whatever you want to display to the user."
                                    },
                                    new Paragraph {
                                       Body = "🔹 <b>HorizontalAlignment and VerticalAlignment</b> : These properties control the alignment of the TextBlock within its container (the Grid). Setting them to Center means the text will appear in the middle of the window horizontally and vertically."
                                    },
                                    new Paragraph {
                                       Body = "🔹 <b>FontSize and FontWeight</b> work similarly to CSS properties, the first setting the size of the characters and the second their boldness."
                                    }
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "You can find the code for the current state of this project <a href='https://github.com/TheCSharpAcademy/TCSA.Study.Recipes/tree/2.Adding-Text' target='_blank'>in this link</a>." }
                                }
                            }

                        }
                    },
                    new Article
                    {
                        Id = 500107,
                        CourseDisplayId = 8,
                        Title = "Using Grids",
                        Slug = "intro-to-wpf-using-grids",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "Still in <b>MainWindow.xaml<b>, add the following code into the Grid tag:"
                                    },
                                    new Paragraph {
                                        IsCode = true,
                                       Body = "&lt;Grid&gt;\r\n    &lt;Grid.ColumnDefinitions&gt;\r\n        &lt;ColumnDefinition Width=&quot;2*&quot; /&gt;\r\n        &lt;ColumnDefinition Width=&quot;3*&quot; /&gt;\r\n    &lt;/Grid.ColumnDefinitions&gt;\r\n\r\n    &lt;StackPanel Grid.Column=&quot;0&quot; Margin=&quot;10&quot;&gt;\r\n        &lt;TextBlock Text=&quot;Recipes&quot; \r\n                   FontSize=&quot;16&quot; FontWeight=&quot;Bold&quot; \r\n                   Margin=&quot;0 0 0 10&quot; /&gt;\r\n    &lt;/StackPanel&gt;\r\n\r\n    &lt;StackPanel Grid.Column=&quot;1&quot; Margin=&quot;10&quot;&gt;\r\n        &lt;TextBlock Text=&quot;Recipe Details&quot; \r\n                   FontSize=&quot;16&quot; FontWeight=&quot;Bold&quot; \r\n                   Margin=&quot;0 0 0 10&quot; /&gt;\r\n        &lt;TextBlock Name=&quot;RecipeDetails&quot; \r\n                   Text=&quot;Select a recipe to view details&quot; \r\n                   TextWrapping=&quot;Wrap&quot; /&gt;\r\n    &lt;/StackPanel&gt;\r\n&lt;/Grid&gt;\r\n"
                                    },
                                    new Paragraph {
                                       Body = "The modified UI should look like this:"
                                    },
                                    new Paragraph
                                    {
                                        IsPicture = true,
                                        PictureUrl = "c5-ch8-wpf-grid-modified-ui.png"
                                    },
                                }
                            },
                            new Block
                            {
                                Title = "Column Definitions",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                        Body = "The code above defines the grid's columns. In this case, two columns. The first (ColumnDefinition) has a <b>width of 2*</b>, meaning it will take up two parts of available space. The second column has a <b>width of 3*</b>, meaning it will take up three parts of available space. The `*` is a star sizing, where the space is divided proportionally based on the weight of the numbers. So, </b>the second column will take up more space than the first</b>."
                                    },
                                     new Paragraph {
                                        Body = "The <b>StackPanel element</b> is placed in each grid column (<b>Grid.Column=\"0\"</b>). Note that the index of the column is zero-based. Inside each StackPanel we have TextBlocks."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Why Use Stack Panel?",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "A StackPanel in WPF is a layout container that <b>arranges its child elements in a single line</b>, either vertically (default) or horizontally, depending on its <b>Orientation</b> property."
                                    },
                                    new Paragraph {
                                       Body = "It’s great for simple layouts where you want elements to flow naturally in one direction. It automatically sizes itself to fit its children. You can nest it inside other containers like Grid or DockPanel for more complex layouts. If you ever want the elements to stack horizontally, just add: <b>Orientation=\"Horizontal\"</b>"
                                    }
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "You can find the code for the current state of this project <a href='https://github.com/TheCSharpAcademy/TCSA.Study.Recipes/tree/3.Using-Grids' target='_blank'>in this link</a>." }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500108,
                        CourseDisplayId = 9,
                        Title = "List of Recipes",
                        Slug = "intro-to-wpf-list-of-recipes",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "Let's create a <b>model class</b> for our recipes. If you don't know what model classes are, this course might be slightly too advanced for you. We recommend you do the first three or four projects in our roadmap, or check out our <a href='http://course/1/article/1/500025/false' target='_blank'>Object-oriented Programming Crash-Course</b>. In a new file, create a Recipe class:"
                                    },
                                    new Paragraph {
                                       IsCode = true,
                                       Body = "public class Recipe\r\n{\r\n    public string Name { get; set; } = string.Empty;\r\n}"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "The Code-Behind",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                        Body = "Now let's modify the <b>MainWindow.xaml.cs</b> file."
                                    },
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "public MainWindow()\r\n    {\r\n        InitializeComponent();\r\n\r\n        Recipes = new ObservableCollection<Recipe>\r\n        {\r\n            new Recipe { Name = \"Spaghetti Bolognese\" },\r\n            new Recipe { Name = \"Chicken Curry\" },\r\n            new Recipe { Name = \"Beef Stroganoff\" }\r\n        };\r\n\r\n        RecipeList.ItemsSource = Recipes;\r\n    }"
                                    },
                                    new Paragraph
                                    {
                                        Body = "The code above defines an <b>ObservableCollection</b> of Recipes. That's a special type of collection in .NET that notifies the UI when its contents change. It implements the <b>INotifyCollectionChanged</b> interface, which means:"
                                    },
                                    new Paragraph
                                    {
                                        Body = "✅ When you add, remove, or move items, the UI updates automatically."
                                    },
                                    new Paragraph
                                    {
                                        Body = "✅ It’s perfect for data binding in WPF, especially when you want real-time updates without manually refreshing the view."
                                    },
                                    new Paragraph
                                    {
                                        Body = "In this case we're initializing our Recipes collection with hard-coded values for their names."
                                    },
                                    new Paragraph
                                    {
                                        Body = "In line 12, <b>RecipeList.ItemsSource = Recipes</b>: This binds the <b>ListView named RecipeList</b> to the Recipes collection. WPF then iterates over each item in Recipes, applies the defined view or template (like GridViewColumn) and Automatically updates the UI when the collection changes."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "The UI",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "Now let's go back to <b>MainWindow.xaml</b>. Replace the <b>first StackPanel</b> with this:"
                                    },
                                    new Paragraph {
                                        IsCode = true,
                                       Body = "&lt;StackPanel Grid.Column=&quot;0&quot; Margin=&quot;10&quot;&gt;\r\n    &lt;TextBlock Text=&quot;Recipes&quot; \r\n               FontSize=&quot;16&quot; \r\n               FontWeight=&quot;Bold&quot; \r\n               Margin=&quot;0 0 0 10&quot; /&gt;\r\n    &lt;ListView Name=&quot;RecipeList&quot;&gt;\r\n        &lt;ListView.View&gt;\r\n            &lt;GridView&gt;\r\n                &lt;GridViewColumn Header=&quot;Recipe Name&quot; \r\n                                DisplayMemberBinding=&quot;{Binding Name}&quot; /&gt;\r\n            &lt;/GridView&gt;\r\n        &lt;/ListView.View&gt;\r\n    &lt;/ListView&gt;\r\n&lt;/StackPanel&gt;\r\n}"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "The List",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                        Body = "🔵 <b>ListView</b> is the main control that displays a list of items. It’s capable of showing complex layouts and multiple columns. Here we're defining the control and names it RecipeList, so it can be referenced in your code-behind."
                                    },
                                    new Paragraph {
                                        Body = "🔵 <b><ListView.View></b>: This section specifies how the items inside the ListView should be visually structured. We're overriding the default view to use a GridView. It specifies how the items inside the ListView should be visually structured. We're overriding the default view to use a <b>GridView</b>. This element is one of the layout modes for ListView, allowing data to be displayed in columns—essentially a table. The default view would simply show a list, without the possibility of adding headers or columns."
                                     },
                                    new Paragraph {
                                        Body = "🔵 <b>GridViewColumn Header</b>: Defines a single column in your grid. The Header text (\"Recipe Name\") is what the user sees at the top of the column."
                                    },
                                    new Paragraph {
                                        Body = "🔵 <b>DisplayMemberBinding=\"{Binding Name}\"</b>. This binds the contents of each row under the \"Recipe Name\" column to the Name property of the bound data object. Since our ListView.ItemsSource is bound to a collection of objects like Recipe { string Name }, <b>this column will automatically display each Recipe.Name</b>."
                                    },
                                    new Paragraph {
                                        Body = "With these modifications we now will see this as a result:"
                                    },
                                    new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c5-ch9-wpf-list-of-recipes.png"
                                    }
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "You can find the code for the current state of this project <a href='https://github.com/TheCSharpAcademy/TCSA.Study.Recipes/tree/4.Recipes-List' target='_blank'>in this link</a>." }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500109,
                        CourseDisplayId = 10,
                        Title = "Selecting a Recipe",
                        Slug = "intro-to-wpf-selecting-recipe",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "Let's enhance our Recipe model by adding a couple of properties:"
                                    },
                                    new Paragraph {
                                        IsCode = true,
                                       Body = "public class Recipe\r\n{\r\n    public int Id { get; set; }\r\n    public string Name { get; set; }\r\n    public string Details { get; set; }\r\n}\r\n"
                                    },
                                    new Paragraph {
                                       Body = "In the <b>MainWindow.xaml.cs</b>, assign values to the new properties when seeding recipies: "
                                    },
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "Recipes = new ObservableCollection<Recipe>\r\n{\r\n    new Recipe { Id = 1, Name = \"Spaghetti Bolognese\", Details = \"Classic Italian pasta dish with a rich meat sauce.\" },\r\n    new Recipe { Id = 2, Name = \"Chicken Curry\", Details = \"Spicy Indian-inspired curry made with tender chicken and aromatic spices.\" },\r\n    new Recipe { Id = 3, Name = \"Beef Stroganoff\", Details = \"Creamy Russian-style beef dish served with mushrooms and egg noodles.\" }\r\n};\r\n"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Event Handler",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "Still in <b>MainWindow.xaml.cs</b>, add the following method, below the constructor:"
                                    },
                                    new Paragraph {
                                        IsCode = true,
                                       Body = "private void RecipeList_SelectionChanged(object sender, SelectionChangedEventArgs e)\r\n    {\r\n        if (RecipeList.SelectedItem is Recipe selectedRecipe)\r\n        {\r\n            RecipeDetails.Text = selectedRecipe.Details;\r\n        }\r\n        else\r\n        {\r\n            RecipeDetails.Text = \"Select a recipe to view details.\";\r\n        }\r\n    }}"
                                    },
                                    new Paragraph
                                    {
                                        Body = "This method will be responsible for <b>handling clicks on individual list items</b> in the front-end. The first parameter is <b>object sender</b>, which represents the control that will be transmitting this event to the back end. In our case it will be the <b>RecipeList ListView</b>. It will be <b>automatically triggered</b> when the selected item in RecipeList changes. <b>SelectionChangedEventArgs e</b> gives you data about what changed — specifically the items that were added or removed from selection."
                                    },
                                    new Paragraph
                                    {
                                        Body = "The code block inside the method controls the text in the Recipe Details block. If any item was selected we will assign the details of a recipe to the text. If not we will display a default text. We can control the text in the front end because we have assigned a name to the TextBlock in the front-end: <TextBlock Name=\"RecipeDetails\">"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "The UI",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "In MainWindow.xaml, <b>add the SelectionChanged property to the ListView</b>, pointing to the handler we created in the back-end:"
                                    },
                                    new Paragraph {
                                        IsCode = true,
                                       Body = "&lt;StackPanel Grid.Column=&quot;0&quot; Margin=&quot;10&quot;&gt;\r\n    &lt;TextBlock Text=&quot;Recipes&quot; \r\n               FontSize=&quot;16&quot; \r\n               FontWeight=&quot;Bold&quot; \r\n               Margin=&quot;0 0 0 10&quot; /&gt;\r\n    &lt;ListView Name=&quot;RecipeList&quot;\r\n              SelectionChanged=&quot;RecipeList_SelectionChanged&quot;&gt; &lt;!-- ADD THIS LINE --&gt;\r\n        &lt;ListView.View&gt;\r\n            &lt;GridView&gt;\r\n                &lt;GridViewColumn Header=&quot;Recipe Name&quot; \r\n                                DisplayMemberBinding=&quot;{Binding Name}&quot; /&gt;\r\n            &lt;/GridView&gt;\r\n        &lt;/ListView.View&gt;\r\n    &lt;/ListView&gt;\r\n&lt;/StackPanel&gt;\r\n}"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Test The Changes",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                        Body = "Run the app and click on a recipe. You should see it's details changing automatically on the right side:"
                                    },
                                    new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c5-ch10-wpf-selecting-recipe.png"
                                    }
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "You can find the code for the current state of this project <a href='https://github.com/TheCSharpAcademy/TCSA.Study.Recipes/blob/5.Recipe-Details/TCSA.Recipes/MainWindow.xaml' target='_blank'>in this link</a>." }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500110,
                        CourseDisplayId = 11,
                        Title = "Adding a Recipe",
                        Slug = "intro-to-wpf-adding-recipe",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "In this chapter we will <b>collect the input</b> from the user to add a new recipe. For that we'll need a <b>modal</b>. Right click on the project file and choose <b>Add > Window (WPF)</b>. Name the new window <b>AddRecipeDialog.xaml</b> and add the following content to the front-end: "
                                    },
                                    new Paragraph {
                                        IsCode = true,
                                       Body = "&lt;Window x:Class=&quot;TCSA.Recipes.AddRecipeDialog&quot;\r\n        xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;\r\n        xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;\r\n        xmlns:local=&quot;clr-namespace:TCSA.Recipes&quot;\r\n        Title=&quot;AddRecipeDialog&quot; \r\n        Height=&quot;450&quot; \r\n        Width=&quot;800&quot;&gt;\r\n    &lt;Grid&gt;\r\n        &lt;StackPanel Margin=&quot;10&quot;&gt;\r\n            &lt;TextBlock Text=&quot;Recipe Name:&quot; /&gt;\r\n            &lt;TextBox x:Name=&quot;NameInput&quot; Margin=&quot;0 5 0 10&quot; /&gt;\r\n\r\n            &lt;TextBlock Text=&quot;Details:&quot; /&gt;\r\n            &lt;TextBox x:Name=&quot;DetailsInput&quot; Height=&quot;80&quot; AcceptsReturn=&quot;True&quot; TextWrapping=&quot;Wrap&quot; Margin=&quot;0 5 0 10&quot; /&gt;\r\n\r\n            &lt;StackPanel Orientation=&quot;Horizontal&quot; HorizontalAlignment=&quot;Right&quot;&gt;\r\n                &lt;Button Content=&quot;OK&quot; Width=&quot;80&quot; Margin=&quot;5&quot; Click=&quot;Ok_Click&quot; /&gt;\r\n                &lt;Button Content=&quot;Cancel&quot; Width=&quot;80&quot; Margin=&quot;5&quot; Click=&quot;Cancel_Click&quot; /&gt;\r\n            &lt;/StackPanel&gt;\r\n        &lt;/StackPanel&gt;\r\n    &lt;/Grid&gt;\r\n&lt;/Window&gt;\r\n"
                                    },
                                    new Paragraph {
                                       Body = "You should already be familiar with Window, Grid, StackPanel and TextBlock. In the code above, we're introducing <b>TextBox</b>, which is the control for text fields and Buttons. We can also see a property in the second TextBox: <b>AcceptsReturn=\"True\"</b>. This means the control will accept line breaks when the user presses Enter. This works well when you want a TextBox to behave more like a simple text editor, not a single-line input."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Dialog's Properties",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "In <b>AddRecipeDialog.xaml.cs</b>, add the following code:"
                                    },
                                    new Paragraph {
                                        IsCode = true,
                                       Body = "public partial class AddRecipeDialog : Window\r\n{\r\n    public string RecipeName => NameInput.Text;\r\n    public string Details => DetailsInput.Text;\r\n\r\n    public AddRecipeDialog()\r\n    {\r\n        InitializeComponent();\r\n    }\r\n\r\n    private void Ok_Click(object sender, RoutedEventArgs e)\r\n    {\r\n        DialogResult = true;\r\n    }\r\n\r\n    private void Cancel_Click(object sender, RoutedEventArgs e)\r\n    {\r\n        DialogResult = false;\r\n    }\r\n}\r\n"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Here we're creating two properties that are assigned to the text property of the NameInput and DetailsInput controls. These properties will be used when the AddRecipeDialog object is insantiated in the MainWindow back-end."
                                    },
                                    new Paragraph
                                    {
                                        Body = "We also have two methods that handle the Ok and Cancel Buttons. They control the <b>DialogResult boolean</b>, which a property part of the <b>Window class</b>. We will use this boolean in the MainWindow back-end."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Using the Modal",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "In MainWindow.xaml.cs, add the method that will handle this modal:"
                                    },
                                    new Paragraph {
                                        IsCode = true,
                                       Body = "private void AddRecipe_Click(object sender, RoutedEventArgs e)\r\n    {\r\n        var dialog = new AddRecipeDialog\r\n        {\r\n            Owner = this\r\n        };\r\n\r\n        if (dialog.ShowDialog() == true)\r\n        {\r\n            var newRecipe = new Recipe\r\n            {\r\n                Name = dialog.RecipeName,\r\n                Details = dialog.Details \r\n            };\r\n\r\n            Recipes.Add(newRecipe);\r\n        }\r\n    }"
                                    },
                                    new Paragraph
                                    {
                                        Body = "In this method we're creating <b>an instance of AddRecipeDialog</b>, which shows the modal. We're defining the Owner of this dialog as the MainWindow, with the <b>keyword this</b>, helping with focus and centering."
                                    },
                                    new Paragraph
                                    {
                                        Body = "If the user clicks on ok, the result of <b>dialog.ShowDialog() equals true</b>. ShowDialog() returns the DialogResult boolean we set in the dialog's code-behind. If that is the case we will create a new Recipe object with the values from the input taken from the dialog's properties and add it to the Recipes collection."
                                    },
                                }
                            },
                            new Block
                            {
                                Title = "The UI",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "The last step is to add a button that will show the dialog. In MainWindow.xaml, add: "
                                    },
                                    new Paragraph {
                                        IsCode = true,
                                       Body = "&lt;StackPanel Grid.Column=&quot;0&quot; Margin=&quot;10&quot;&gt;\r\n    &lt;TextBlock Text=&quot;Recipes&quot; \r\n               FontSize=&quot;16&quot; \r\n               FontWeight=&quot;Bold&quot; \r\n               Margin=&quot;0 0 0 10&quot; /&gt;\r\n    &lt;ListView Name=&quot;RecipeList&quot; \r\n              SelectionChanged=&quot;RecipeList_SelectionChanged&quot;&gt; &lt;!-- ADD THIS LINE --&gt;\r\n        &lt;ListView.View&gt;\r\n            &lt;GridView&gt;\r\n                &lt;GridViewColumn Header=&quot;Recipe Name&quot; \r\n                                DisplayMemberBinding=&quot;{Binding Name}&quot; /&gt;\r\n            &lt;/GridView&gt;\r\n        &lt;/ListView.View&gt;\r\n    &lt;/ListView&gt;\r\n\r\n         &lt;Button Content=&quot;Add Recipe&quot; \r\n             Grid.Column=&quot;0&quot; \r\n             Margin=&quot;10 0 10 10&quot; \r\n             HorizontalAlignment=&quot;Right&quot; \r\n           Click=&quot;AddRecipe_Click&quot; /&gt;\r\n    &lt;/StackPanel&gt;\r\n"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Test The Changes",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                        Body = "Run the app, add a recipe and try to visualize its details:"
                                    },
                                    new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c5-ch11-wpf-add-recipe.png"
                                    },
                                     new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c5-ch11-wpf-view-recipe.png"
                                    }
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "You can find the code for the current state of this project <a href='https://github.com/TheCSharpAcademy/TCSA.Study.Recipes/tree/6.Add-Recipe-Dialog' target='_blank'>in this link</a>." }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500111,
                        CourseDisplayId = 12,
                        Title = "Editing a Recipe",
                        Slug = "intro-to-wpf-editing-recipe",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {

                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "To edit a recipe we will need a button in the StackPanel where recipe details live. In <b>MainWindow.xaml</b>, modify the <b>second StackPanel</b>: "
                                    },
                                    new Paragraph {
                                        IsCode = true,
                                       Body = "&lt;StackPanel Grid.Column=&quot;1&quot; Margin=&quot;10&quot;&gt;\r\n        &lt;TextBlock Text=&quot;Recipe Details&quot; \r\n                FontSize=&quot;16&quot; FontWeight=&quot;Bold&quot; \r\n                Margin=&quot;0 0 0 10&quot; /&gt;\r\n        &lt;TextBlock Name=&quot;RecipeDetails&quot; \r\n                Text=&quot;Select a recipe to view details&quot; \r\n                TextWrapping=&quot;Wrap&quot; /&gt;\r\n     &lt;Button x:Name=&quot;EditButton&quot; \r\n             Content=&quot;Edit Recipe&quot;\r\n             Margin=&quot;10 10 0 0&quot;\r\n             HorizontalAlignment=&quot;Right&quot;\r\n             Visibility=&quot;Collapsed&quot;\r\n             Click=&quot;EditRecipe_Click&quot; /&gt;\r\n&lt;/StackPanel&gt;\r\n"
                                    },
                                    new Paragraph {
                                       Body = "Notice that this button has a <b>Visibility property set as Collapsed</b>, which means it doesn't show by default. In <b>MainWindow.xaml.cs</b> modify RecipeList_SelectionChanged so it sets EditButton to visible only when a recipe is selected."
                                    },
                                    new Paragraph {
                                        IsCode = true,
                                       Body = "private void RecipeList_SelectionChanged(object sender, SelectionChangedEventArgs e)\r\n    {\r\n        if (RecipeList.SelectedItem is Recipe selectedRecipe)\r\n        {\r\n            RecipeDetails.Text = selectedRecipe.Details;\r\n            EditButton.Visibility = Visibility.Visible;\r\n        }\r\n        else\r\n        {\r\n            RecipeDetails.Text = \"Select a recipe to view details.\";\r\n            EditButton.Visibility = Visibility.Collapsed;\r\n        }\r\n    }"
                                    },
                                }
                            },
                            new Block
                            {
                                Title = "Using the Modal",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "We will use the same <b>AddRecipeDialog modal</b> for editing. For this we will need to add a method that populates the dialog's fields with data from the selected property. Add this method to <b>MainWindow.xaml.cs</b>:"
                                    },
                                    new Paragraph {
                                        IsCode = true,
                                       Body = "private void EditRecipe_Click(object sender, RoutedEventArgs e)\r\n    {\r\n        if (RecipeList.SelectedItem is Recipe selectedRecipe)\r\n        {\r\n            var dialog = new AddRecipeDialog\r\n            {\r\n                Owner = this\r\n            };\r\n\r\n            // Populating fields with selected recipe data\r\n            dialog.NameInput.Text = selectedRecipe.Name;\r\n            dialog.DetailsInput.Text = selectedRecipe.Details;\r\n\r\n            if (dialog.ShowDialog() == true)\r\n            {\r\n                // Updating the selected recipe with new data\r\n                selectedRecipe.Name = dialog.RecipeName;\r\n                selectedRecipe.Details = dialog.Details;\r\n\r\n                RecipeDetails.Text = selectedRecipe.Details;\r\n\r\n                var index = Recipes.IndexOf(selectedRecipe);\r\n                Recipes.RemoveAt(index);\r\n                Recipes.Insert(index, selectedRecipe);\r\n            }\r\n        }\r\n        else\r\n        {\r\n            MessageBox.Show(\"Please select a recipe to edit.\");\r\n        }\r\n    }"
                                    },
                                    new Paragraph
                                    {
                                        Body = "The structure is similar to <b>AddRecipe_Click</b>, but here we're populating the fields with <b>current data from the chosen recipe</b>, so the user can update them if needed. "
                                    },
                                    new Paragraph
                                    {
                                        Body = "Within the if <b>(dialog.ShowDialog() = true)</b> block we assign the  data from the input to the selected recipe, so it updates immediately in the UI, and update the collection with the updated recipe."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Test The Changes",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                        Body = "Run the app and try updating a recipe:"
                                    },
                                    new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c5-ch12-wpf-update-modal.png"
                                    },
                                     new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c5-ch12-wpf-updated-recipe.png"
                                    }
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "You can find the code for the current state of this project <a href='https://github.com/TheCSharpAcademy/TCSA.Study.Recipes/tree/7.Update-Recipe' target='_blank'>in this link</a>." }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500112,
                        CourseDisplayId = 13,
                        Title = "Deleting a Recipe",
                        Slug = "intro-to-wpf-deleting-recipe",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {

                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "In <b>MainWindow.xaml</b>, let's add a second button, which will have similar properties to the Edit button. Notice we nested a second StackPanel inside the first: "
                                    },
                                    new Paragraph {
                                        IsCode = true,
                                       Body = "&lt;StackPanel Grid.Column=&quot;1&quot; Margin=&quot;10&quot;&gt;\r\n    &lt;TextBlock Text=&quot;Recipe Details&quot; \r\n               FontSize=&quot;16&quot; FontWeight=&quot;Bold&quot; \r\n               Margin=&quot;0 0 0 10&quot; /&gt;\r\n    &lt;TextBlock Name=&quot;RecipeDetails&quot; \r\n               Text=&quot;Select a recipe to view details&quot; \r\n               TextWrapping=&quot;Wrap&quot; /&gt;\r\n    &lt;StackPanel Orientation=&quot;Horizontal&quot; HorizontalAlignment=&quot;Right&quot;&gt;\r\n        &lt;Button x:Name=&quot;EditButton&quot; \r\n                Content=&quot;Edit Recipe&quot;\r\n                Width=&quot;100&quot;\r\n                Margin=&quot;0 0 10 0&quot;\r\n                Visibility=&quot;Collapsed&quot;\r\n                Click=&quot;EditRecipe_Click&quot; /&gt;\r\n\r\n        &lt;Button x:Name=&quot;DeleteButton&quot; \r\n                Content=&quot;Delete Recipe&quot;\r\n                Width=&quot;100&quot;\r\n                Visibility=&quot;Collapsed&quot;\r\n                Click=&quot;DeleteRecipe_Click&quot; /&gt;\r\n    &lt;/StackPanel&gt;\r\n&lt;/StackPanel&gt;\r\n&lt;/Grid&gt;\r\n"
                                    },
                                    new Paragraph {
                                       Body = "In MainWindow.xaml.cs, let's add the method that will handle clicks on the new button. "
                                    },
                                    new Paragraph {
                                        IsCode = true,
                                       Body = " private void DeleteRecipe_Click(object sender, RoutedEventArgs e)\r\n    {\r\n        if (RecipeList.SelectedItem is Recipe selectedRecipe)\r\n        {\r\n            var result = MessageBox.Show($\"Are you sure you want to delete '{selectedRecipe.Name}'?\",\r\n                                         \"Confirm Delete\",\r\n                                         MessageBoxButton.YesNo,\r\n                                         MessageBoxImage.Warning);\r\n\r\n            if (result == MessageBoxResult.Yes)\r\n            {\r\n                Recipes.Remove(selectedRecipe);\r\n                RecipeDetails.Text = \"Select a recipe to view details\";\r\n                EditButton.Visibility = Visibility.Collapsed;\r\n                DeleteButton.Visibility = Visibility.Collapsed;\r\n            }\r\n        }\r\n        else\r\n        {\r\n            MessageBox.Show(\"Please select a recipe to delete.\",\r\n                            \"No Recipe Selected\",\r\n                            MessageBoxButton.OK,\r\n                            MessageBoxImage.Exclamation);\r\n        }\r\n    }\r\n}"
                                    },
                                    new Paragraph {
                                       Body = "You'll also need to make the button visible when a recipe is selected. Modify the RecipeList_SelectionChanged method:"
                                    },
                                    new Paragraph {
                                        IsCode = true,
                                       Body = "private void RecipeList_SelectionChanged(object sender, SelectionChangedEventArgs e)\r\n    {\r\n        if (RecipeList.SelectedItem is Recipe selectedRecipe)\r\n        {\r\n            RecipeDetails.Text = selectedRecipe.Details;\r\n            EditButton.Visibility = Visibility.Visible;\r\n            DeleteButton.Visibility = Visibility.Visible;\r\n        }\r\n        else\r\n        {\r\n            RecipeDetails.Text = \"Select a recipe to view details.\";\r\n            EditButton.Visibility = Visibility.Collapsed;\r\n            DeleteButton.Visibility = Visibility.Collapsed;\r\n        }\r\n    }"
                                    },
                                     new Paragraph {
                                       Body = "Once we click on this button, we will show a simple confirmation modal, which is good practice when deleting data. For that we use WPF's MessageBox class. In case of confirmation we remove the recipe from the collection and in case of cancellation, nothing changes."
                                    },
                                }
                            },
                            new Block
                            {
                                Title = "Test the changes",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "Run the app and try deleting a recipe:"
                                    },
                                    new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c5-ch13-wpf-delete-modal.png"
                                    },
                                     new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c5-ch13-wpf-deleted-recipe.png"
                                    }
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "You can find the code for the current state of this project <a href='https://github.com/TheCSharpAcademy/TCSA.Study.Recipes/blob/8.Delete-Recipe' target='_blank'>in this link</a>." }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500113,
                        CourseDisplayId = 14,
                        Title = "Connecting to a Database",
                        Slug = "intro-to-wpf-database",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {

                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "Needless to say, our recipes app won't be of much value if we can't persist data. For this purpose we will be using SQLite. Here’s why SQLite is a good choice for WPF apps:<br>\r\n\r\n\U0001f9f1 <b>Zero Setup</b>: SQLite runs in-process with your application. It’s just a file on disk, making deployment very simple.<br>\r\n\r\n🚀 <b>Performance</b>: For read-heavy operations or modest write workloads, SQLite is super efficient. It can handle thousands of records easily for everyday apps.<br>\r\n\r\n💾 <b>Persistence</b>: Data is stored in a .db file, giving users durable storage even between sessions or reboots.<br>\r\n\r\n🔌 <b>EF Core Compatibility</b>: You can pair SQLite with Entity Framework Core for smooth data modeling and LINQ queries, which plays nicely with WPF.<br>\r\n\r\n🛠️ <b>Great for Prototyping</b>: Whether you're testing out new UI concepts or iterating fast, SQLite lets you focus on features without fretting over the backend."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Configuring SQLite",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "To use SQLite in our project, install the latest version of the  <b>Microsoft.EntityFrameworkCore.Sqlite</b> package."
                                    },
                                     new Paragraph
                                    {
                                        Body = "Then, in a new file, create a <b>DBContext</b>, where you'll define your <b>DbSet</b>, which will represent a Recipes table in the database and set up the path to your SQLite file. I'm explicitly using the root folder of my project as a path, as I want to visualize the database file from Visual Studio when it's created:"
                                    },
                                    new Paragraph {
                                        IsCode = true,
                                       Body = "public class RecipeDbContext : DbContext\r\n{\r\n    public DbSet<Recipe> Recipes { get; set; }\r\n\r\n    protected override void OnConfiguring(DbContextOptionsBuilder options)\r\n        => options.UseSqlite(\"Data Source=C:\\\\pablo\\\\TCSA.Recipes\\\\TCSA.Recipes\\\\recipes.db\");\r\n}"
                                    },
                                    new Paragraph
                                    {
                                        Body = "In <b>MainWindow.xaml.cs</b>, we need to instantiante the context in the constructor:"
                                    },
                                    new Paragraph {
                                        IsCode = true,
                                       Body = "public partial class MainWindow : Window\r\n{\r\n    private RecipeDbContext dbContext;\r\n\r\n    public MainWindow()\r\n    {\r\n        InitializeComponent();\r\n\r\n        dbContext = new RecipeDbContext();\r\n        dbContext.Database.EnsureCreated();\r\n\r\n        LoadRecipes();\r\n    }\r\n\r\n    private void LoadRecipes()\r\n    {\r\n        RecipeList.ItemsSource = dbContext.Recipes.ToList();\r\n    }\r\n\r\n    // ... Event handlers for buttons\r\n }"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Using EF Core",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                        Body = "Let's start with the AddRecipe_Click method:"
                                    },
                                    new Paragraph {
                                        IsCode = true,
                                       Body = "private void AddRecipe_Click(object sender, RoutedEventArgs e)\r\n    {\r\n        var dialog = new AddRecipeDialog\r\n        {\r\n            Owner = this\r\n        };\r\n\r\n        if (dialog.ShowDialog() == true)\r\n        {\r\n            var newRecipe = new Recipe\r\n            {\r\n                Name = dialog.RecipeName,\r\n                Details = dialog.Details \r\n            };\r\n\r\n            dbContext.Recipes.Add(newRecipe);\r\n            dbContext.SaveChanges();\r\n            LoadRecipes();\r\n        }\r\n    }"
                                    },
                                    new Paragraph {
                                        Body = "We're now using <b>dbContext.Recipes.Add(newRecipe)</b> to insert a recipe object into our table. We can't forget to save the changes with <b>dbContext.SaveChanges()</b>; we then proceed to reload the recipes. The same pattern should be followed for the edit and delete methods:"
                                    },
                                    new Paragraph {
                                        IsCode = true,
                                       Body = "private void EditRecipe_Click(object sender, RoutedEventArgs e)\r\n    {\r\n        if (RecipeList.SelectedItem is Recipe selectedRecipe)\r\n        {\r\n            var dialog = new AddRecipeDialog\r\n            {\r\n                Owner = this\r\n            };\r\n\r\n            dialog.NameInput.Text = selectedRecipe.Name;\r\n            dialog.DetailsInput.Text = selectedRecipe.Details;\r\n\r\n            if (dialog.ShowDialog() == true)\r\n            {\r\n                selectedRecipe.Name = dialog.RecipeName;\r\n                selectedRecipe.Details = dialog.Details;\r\n\r\n                RecipeDetails.Text = selectedRecipe.Details;\r\n\r\n                dbContext.Recipes.Update(selectedRecipe);\r\n                dbContext.SaveChanges();\r\n                LoadRecipes();\r\n            }\r\n        }\r\n        else\r\n        {\r\n            MessageBox.Show(\"Please select a recipe to edit.\");\r\n        }\r\n    }\r\n\r\n    private void DeleteRecipe_Click(object sender, RoutedEventArgs e)\r\n    {\r\n        if (RecipeList.SelectedItem is Recipe selectedRecipe)\r\n        {\r\n            var result = MessageBox.Show($\"Are you sure you want to delete '{selectedRecipe.Name}'?\",\r\n                                         \"Confirm Delete\",\r\n                                         MessageBoxButton.YesNo,\r\n                                         MessageBoxImage.Warning);\r\n\r\n            if (result == MessageBoxResult.Yes)\r\n            {\r\n                dbContext.Recipes.Remove(selectedRecipe);\r\n                dbContext.SaveChanges();\r\n                LoadRecipes();\r\n\r\n                RecipeDetails.Text = \"Select a recipe to view details\";\r\n                EditButton.Visibility = Visibility.Collapsed;\r\n                DeleteButton.Visibility = Visibility.Collapsed;\r\n            }\r\n        }\r\n        else\r\n        {\r\n            MessageBox.Show(\"Please select a recipe to delete.\",\r\n                            \"No Recipe Selected\",\r\n                            MessageBoxButton.OK,\r\n                            MessageBoxImage.Exclamation);\r\n        }\r\n    }    }"
                                    },
                                    new Paragraph {
                                        Body = "Run the app again. If everything works correctly you'll see the database file created in your root folder as per the picture below. Initially it won't contain any recipes. Test the add, update and delete functionality to make sure everything works!"
                                    },
                                     new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c5-ch14-wpf-db-created.png"
                                    },
                                     new Paragraph {
                                        Body = "You can use an app like Db Browser to interact with the Sqlite file independently from Visual Studio:"
                                    },
                                     new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c5-ch14-wpf-dbbrowser.png"
                                    },
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "You can find the code for the current state of this project <a href='https://github.com/TheCSharpAcademy/TCSA.Study.Recipes/tree/7.Update-Recipe' target='_blank'>in this link</a>." }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500114,
                        CourseDisplayId = 15,
                        Title = "Resource Dictionaries",
                        Slug = "intro-to-wpf-dictionaries",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {

                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "In this chapter let's have a look at how to add some basic styling to our Recipe List. WPF offers a comprehensive set of tools for building beautiful applications, but we will keep it simple for now, explaining the fundamental concepts with a few examples."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "CSS-Like",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "Much like CSS in web development, WPF styles let you set properties—such as fonts, colors, margins, or even control templates—for multiple elements in a consistent and reusable way. A style is typically defined in a XAML <Style> tag, which can be scoped at different levels: applied directly to a control, placed in a window’s resources, or declared in a separate resource dictionary for broader reuse. Each style targets a specific type, like Button or TextBox, and you can define property setters or triggers to apply changes dynamically."
                                    },
                                     new Paragraph
                                    {
                                        Body = "In a new folder called ResourceDictionaries, create a new Resource Dictionary with the help of Visual Studio. Name it <b>GlobalStyles.xaml</b>."
                                    },
                                    new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c5-ch15-wpf-dictionary.png"
                                    },
                                    new Paragraph
                                    {
                                        Body = "A <b>Resource Dictionary</b> is like your app’s style toolkit—it stores reusable resources such as styles, brushes, templates, and more, all keyed for easy reference. Think of it as a centralized place to define visual elements and behaviors that you want to apply consistently across your UI."
                                    },
                                     new Paragraph
                                    {
                                        Body = "Include the following code:"
                                    },
                                     new Paragraph {
                                        IsCode = true,
                                       Body = "&lt;ResourceDictionary xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;\r\n                    xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;&gt;\r\n\r\n    &lt;!-- 🎨 Rounded Button Style --&gt;\r\n    &lt;Style TargetType=&quot;Button&quot; x:Key=&quot;RoundedButtonStyle&quot;&gt;\r\n        &lt;Setter Property=&quot;FontSize&quot; Value=&quot;16&quot; /&gt;\r\n        &lt;Setter Property=&quot;FontFamily&quot; Value=&quot;Segoe UI Semibold&quot; /&gt;\r\n        &lt;Setter Property=&quot;Foreground&quot; Value=&quot;White&quot; /&gt;\r\n        &lt;Setter Property=&quot;Padding&quot; Value=&quot;8,4&quot; /&gt;\r\n        &lt;Setter Property=&quot;Margin&quot; Value=&quot;5&quot; /&gt;\r\n        &lt;Setter Property=&quot;Background&quot; Value=&quot;#007ACC&quot; /&gt;\r\n        &lt;Setter Property=&quot;BorderBrush&quot; Value=&quot;#005A9E&quot; /&gt;\r\n        &lt;Setter Property=&quot;Template&quot;&gt;\r\n            &lt;Setter.Value&gt;\r\n                &lt;ControlTemplate TargetType=&quot;Button&quot;&gt;\r\n                    &lt;Border Background=&quot;{TemplateBinding Background}&quot;\r\n                            BorderBrush=&quot;{TemplateBinding BorderBrush}&quot;\r\n                            BorderThickness=&quot;{TemplateBinding BorderThickness}&quot;\r\n                            CornerRadius=&quot;8&quot;&gt;\r\n                        &lt;ContentPresenter HorizontalAlignment=&quot;Center&quot;\r\n                                          VerticalAlignment=&quot;Center&quot; /&gt;\r\n                    &lt;/Border&gt;\r\n                &lt;/ControlTemplate&gt;\r\n            &lt;/Setter.Value&gt;\r\n        &lt;/Setter&gt;\r\n        &lt;Style.Triggers&gt;\r\n            &lt;Trigger Property=&quot;IsMouseOver&quot; Value=&quot;True&quot;&gt;\r\n                &lt;Setter Property=&quot;Background&quot; Value=&quot;#005A9E&quot; /&gt;\r\n            &lt;/Trigger&gt;\r\n            &lt;Trigger Property=&quot;IsPressed&quot; Value=&quot;True&quot;&gt;\r\n                &lt;Setter Property=&quot;Background&quot; Value=&quot;#003F73&quot; /&gt;\r\n            &lt;/Trigger&gt;\r\n        &lt;/Style.Triggers&gt;\r\n    &lt;/Style&gt;\r\n\r\n    &lt;!-- 📝 Heading Text Style --&gt;\r\n    &lt;Style TargetType=&quot;TextBlock&quot; x:Key=&quot;HeadingTextStyle&quot;&gt;\r\n        &lt;Setter Property=&quot;FontSize&quot; Value=&quot;24&quot; /&gt;\r\n        &lt;Setter Property=&quot;FontWeight&quot; Value=&quot;Bold&quot; /&gt;\r\n        &lt;Setter Property=&quot;Foreground&quot; Value=&quot;#444&quot; /&gt;\r\n        &lt;Setter Property=&quot;Margin&quot; Value=&quot;0 0 0 10&quot; /&gt;\r\n    &lt;/Style&gt;\r\n\r\n    &lt;!-- 📄 Standard Text Style --&gt;\r\n    &lt;Style TargetType=&quot;TextBlock&quot; x:Key=&quot;BodyTextStyle&quot;&gt;\r\n        &lt;Setter Property=&quot;FontSize&quot; Value=&quot;16&quot; /&gt;\r\n        &lt;Setter Property=&quot;Foreground&quot; Value=&quot;#333&quot; /&gt;\r\n        &lt;Setter Property=&quot;TextWrapping&quot; Value=&quot;Wrap&quot; /&gt;\r\n    &lt;/Style&gt;\r\n\r\n    &lt;!-- 🌈 Panel Background Style --&gt;\r\n    &lt;Style TargetType=&quot;Border&quot; x:Key=&quot;CardStyle&quot;&gt;\r\n        &lt;Setter Property=&quot;Background&quot; Value=&quot;#F0F0F0&quot; /&gt;\r\n        &lt;Setter Property=&quot;CornerRadius&quot; Value=&quot;10&quot; /&gt;\r\n        &lt;Setter Property=&quot;Padding&quot; Value=&quot;10&quot; /&gt;\r\n        &lt;Setter Property=&quot;Margin&quot; Value=&quot;10&quot; /&gt;\r\n    &lt;/Style&gt;\r\n\r\n    &lt;Style TargetType=&quot;Border&quot; x:Key=&quot;HeaderBannerStyle&quot;&gt;\r\n        &lt;Setter Property=&quot;Height&quot; Value=&quot;60&quot; /&gt;\r\n        &lt;Setter Property=&quot;Background&quot;&gt;\r\n            &lt;Setter.Value&gt;\r\n                &lt;LinearGradientBrush StartPoint=&quot;0,0&quot; EndPoint=&quot;1,0&quot;&gt;\r\n                    &lt;GradientStop Color=&quot;#007ACC&quot; Offset=&quot;0&quot; /&gt;\r\n                    &lt;GradientStop Color=&quot;#00C2CB&quot; Offset=&quot;1&quot; /&gt;\r\n                &lt;/LinearGradientBrush&gt;\r\n            &lt;/Setter.Value&gt;\r\n        &lt;/Setter&gt;\r\n    &lt;/Style&gt;\r\n\r\n&lt;/ResourceDictionary&gt;\r\n"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Setters, Templates and Triggers",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "So how does it work? Each Style targets a specific control type (e.g., Button, TextBlock, Border). The Setter tags are the backbone of styling. We use them to assign values to properties inside the Style tag."
                                    },
                                    new Paragraph
                                    {
                                        Body = "A regular Setter just applies a value until something changes it. But inside a Trigger, a setter responds to events—like mouse hover or press—and temporarily updates values:"
                                    },
                                    new Paragraph {
                                        Body = "The ControlTemplate inside a Setter.Value is where you take full creative control over how a control looks, while keeping its behavior intact. It defines the visual structure of a control. It's like stripping a button down to its skeleton and rebuilding it however you like—from borders and gradients to animations and layout."
                                    },
                                     new Paragraph {
                                        IsCode = true,
                                       Body = "&lt;Setter Property=&quot;Template&quot;&gt;\r\n    &lt;Setter.Value&gt;\r\n        &lt;ControlTemplate TargetType=&quot;Button&quot;&gt;\r\n            &lt;!-- Custom visual tree here --&gt;\r\n        &lt;/ControlTemplate&gt;\r\n    &lt;/Setter.Value&gt;\r\n&lt;/Setter&gt;\r\n"
                                    },
                                     new Paragraph {
                                        Body = "When placing a ControlTemplate you’re telling WPF: “Forget the default visuals, use this instead.”"
                                    },
                                     new Paragraph {
                                        Body = "As for the TemplateBinding keyword in <b>Border Background=\"{TemplateBinding Background}\"</b>, it ensures the style for that button is the one in the outer button tag. Without this binding it would just use WPF's defaults.  "
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Making the Styles Available",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph
                                    {
                                        Body = "First let's make the styles available by modifying the entry-point for our app, App.xaml:"
                                    },
                                    new Paragraph {
                                        IsCode = true,
                                       Body = "&lt;Application x:Class=&quot;TCSA.Recipes.App&quot;\r\n             xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;\r\n             xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;\r\n             xmlns:local=&quot;clr-namespace:TCSA.Recipes&quot;\r\n             StartupUri=&quot;MainWindow.xaml&quot;&gt;\r\n    &lt;Application.Resources&gt;\r\n        &lt;ResourceDictionary&gt;\r\n            &lt;ResourceDictionary.MergedDictionaries&gt;\r\n                &lt;ResourceDictionary Source=&quot;ResourceDictionaries/GlobalStyles.xaml&quot; /&gt;\r\n            &lt;/ResourceDictionary.MergedDictionaries&gt;\r\n        &lt;/ResourceDictionary&gt;\r\n    &lt;/Application.Resources&gt;\r\n&lt;/Application&gt;\r\n"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Here we use the <b>MergedDictionaries</b> tag to potentially use several dictionaries. That is advisable when our application and number of styles grow. In that case we can, for example, create one dictionary for each control."
                                    },
                                    new Paragraph {
                                        Body = "These dictionaries can be loaded with <b>ResourceDictionary Source</b> which will receive the file path. This approach creates a centralized styling system that keeps your app visually consistent and maintainable."
                                    }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500115,
                        CourseDisplayId = 16,
                        Title = "Applying Styles",
                        Slug = "intro-to-wpf-styling",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "In the previous chapter we've wired up styles in a Resource Dictionary and made them available in <b>App.xaml</b>. Now it's time to apply it. "
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "MainWindow.xaml",
                                Paragraphs = new List<Paragraph>
                                {
                                     new Paragraph {
                                        IsCode = true,
                                       Body = "&lt;Window x:Class=&quot;TCSA.Recipes.MainWindow&quot;\r\n        xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;\r\n        xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;\r\n        xmlns:local=&quot;clr-namespace:TCSA.Recipes&quot;\r\n        Title=&quot;MainWindow&quot; \r\n        Height=&quot;450&quot; \r\n        Width=&quot;800&quot;\r\n        Background=&quot;#FAFAFA&quot;&gt;\r\n\r\n    &lt;DockPanel&gt;\r\n        &lt;!-- 🎨 Gradient Banner --&gt;\r\n        &lt;Border Style=&quot;{StaticResource HeaderBannerStyle}&quot; DockPanel.Dock=&quot;Top&quot;&gt;\r\n            &lt;TextBlock Text=&quot;🍲 Recipe Manager&quot;\r\n               VerticalAlignment=&quot;Center&quot;\r\n               HorizontalAlignment=&quot;Center&quot;\r\n               FontSize=&quot;26&quot;\r\n               FontWeight=&quot;Bold&quot;\r\n               Foreground=&quot;White&quot; /&gt;\r\n        &lt;/Border&gt;\r\n\r\n        &lt;Grid Margin=&quot;10&quot;&gt;\r\n            &lt;Grid.ColumnDefinitions&gt;\r\n                &lt;ColumnDefinition Width=&quot;2*&quot; /&gt;\r\n                &lt;ColumnDefinition Width=&quot;3*&quot; /&gt;\r\n            &lt;/Grid.ColumnDefinitions&gt;\r\n\r\n            &lt;StackPanel Grid.Column=&quot;0&quot; Margin=&quot;10&quot;&gt;\r\n                &lt;TextBlock Text=&quot;📖 Recipes&quot; FontWeight=&quot;Bold&quot; FontSize=&quot;24&quot; Foreground=&quot;#444&quot; /&gt;\r\n\r\n                &lt;ListView Name=&quot;RecipeList&quot;\r\n                  SelectionChanged=&quot;RecipeList_SelectionChanged&quot;&gt;\r\n                    &lt;ListView.View&gt;\r\n                        &lt;GridView&gt;\r\n                            &lt;GridViewColumn Header=&quot;Recipe Name&quot; \r\n                                    DisplayMemberBinding=&quot;{Binding Name}&quot; /&gt;\r\n                        &lt;/GridView&gt;\r\n                    &lt;/ListView.View&gt;\r\n                &lt;/ListView&gt;\r\n\r\n                &lt;StackPanel Grid.Column=&quot;1&quot; Margin=&quot;10&quot;&gt;\r\n                    &lt;Button Content=&quot;Add Recipe&quot; \r\n                            Click=&quot;AddRecipe_Click&quot;\r\n                            Background=&quot;#4CAF50&quot; \r\n                            Style=&quot;{StaticResource RoundedButtonStyle}&quot; /&gt;\r\n                &lt;/StackPanel&gt;\r\n            &lt;/StackPanel&gt;\r\n\r\n            &lt;StackPanel Grid.Column=&quot;1&quot; Margin=&quot;10&quot;&gt;\r\n                &lt;TextBlock Text=&quot;🍽️ Recipe Details&quot; FontWeight=&quot;Bold&quot; FontSize=&quot;22&quot; Foreground=&quot;#555&quot; /&gt;\r\n\r\n                &lt;TextBlock Name=&quot;RecipeDetails&quot; \r\n                           Text=&quot;Select a recipe to view details&quot; \r\n                           TextWrapping=&quot;Wrap&quot;\r\n                           Margin=&quot;0 0 0 10&quot; /&gt;\r\n\r\n                &lt;StackPanel Orientation=&quot;Horizontal&quot; HorizontalAlignment=&quot;Right&quot;&gt;\r\n                    &lt;Button x:Name=&quot;EditButton&quot; \r\n                            Content=&quot;Edit&quot;\r\n                            Width=&quot;100&quot;\r\n                            Margin=&quot;0 0 10 0&quot;\r\n                            Visibility=&quot;Collapsed&quot;\r\n                            Style=&quot;{StaticResource RoundedButtonStyle}&quot;\r\n                            Click=&quot;EditRecipe_Click&quot; /&gt;\r\n\r\n                    &lt;Button x:Name=&quot;DeleteButton&quot; \r\n                            Content=&quot;Delete&quot;\r\n                            Width=&quot;100&quot;\r\n                            Margin=&quot;0 0 10 0&quot;\r\n                            Visibility=&quot;Collapsed&quot;\r\n                            Style=&quot;{StaticResource RoundedButtonStyle}&quot;\r\n                            Background=&quot;#F44336&quot;\r\n                            Click=&quot;DeleteRecipe_Click&quot; /&gt;\r\n                &lt;/StackPanel&gt;\r\n            &lt;/StackPanel&gt;\r\n        &lt;/Grid&gt;\r\n    &lt;/DockPanel&gt;\r\n&lt;/Window&gt;\r\n"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Here we're introducing the DockPanel tag. It arranges child elements by “docking” them to the edges of the container (top, bottom, left, right), with an optional area that fills whatever space remains. The first element, Border, uses DockPanel.Doc='Top' to position itself in the DockPanel."
                                    },
                                    new Paragraph
                                    {
                                        Body = "We've also added several styles to each control and used the styles in GlobalStyles.xaml using the Style property. For example, <b>Style=\"{StaticResource RoundedButtonStyle}\"</b> "
                                    },
                                }
                            },
                            new Block
                            {
                                Title = "AddRecipeDialog.xaml",
                                Paragraphs = new List<Paragraph>
                                {
                                     new Paragraph {
                                        IsCode = true,
                                       Body = "&lt;Window x:Class=&quot;TCSA.Recipes.AddRecipeDialog&quot;\r\n        xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;\r\n        xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;\r\n        xmlns:local=&quot;clr-namespace:TCSA.Recipes&quot;\r\n        Title=&quot;Add Recipe&quot;\r\n        Height=&quot;450&quot;\r\n        Width=&quot;800&quot;&gt;\r\n    &lt;Grid&gt;\r\n        &lt;Border Style=&quot;{StaticResource CardStyle}&quot;&gt;\r\n            &lt;StackPanel&gt;\r\n                &lt;!-- 📝 Heading --&gt;\r\n                &lt;TextBlock Text=&quot;Add New Recipe&quot; Style=&quot;{StaticResource HeadingTextStyle}&quot; /&gt;\r\n\r\n                &lt;!-- \U0001f9fe Recipe Name --&gt;\r\n                &lt;TextBlock Text=&quot;Recipe Name:&quot; Style=&quot;{StaticResource BodyTextStyle}&quot; /&gt;\r\n                &lt;TextBox x:Name=&quot;NameInput&quot; Margin=&quot;0 5 0 10&quot;/&gt;\r\n\r\n                &lt;!-- 📋 Recipe Details --&gt;\r\n                &lt;TextBlock Text=&quot;Details:&quot; Style=&quot;{StaticResource BodyTextStyle}&quot; /&gt;\r\n                &lt;TextBox x:Name=&quot;DetailsInput&quot; Height=&quot;80&quot; AcceptsReturn=&quot;True&quot; TextWrapping=&quot;Wrap&quot; Margin=&quot;0 5 0 10&quot;/&gt;\r\n\r\n                &lt;!-- 🎯 Action Buttons --&gt;\r\n                &lt;StackPanel Orientation=&quot;Horizontal&quot; HorizontalAlignment=&quot;Right&quot; Margin=&quot;0 10 0 0&quot;&gt;\r\n                    &lt;Button Content=&quot;OK&quot;\r\n                            Width=&quot;80&quot;\r\n                            Margin=&quot;5&quot;\r\n                            Style=&quot;{StaticResource RoundedButtonStyle}&quot;\r\n                            Background=&quot;#4CAF50&quot; \r\n                            Click=&quot;Ok_Click&quot;/&gt;\r\n                    &lt;Button Content=&quot;Cancel&quot;\r\n                            Width=&quot;80&quot;\r\n                            Margin=&quot;5&quot;\r\n                            Style=&quot;{StaticResource RoundedButtonStyle}&quot;\r\n                            Background=&quot;#F44336&quot;\r\n                            Click=&quot;Cancel_Click&quot;/&gt;\r\n                &lt;/StackPanel&gt;\r\n            &lt;/StackPanel&gt;\r\n        &lt;/Border&gt;\r\n    &lt;/Grid&gt;\r\n&lt;/Window&gt;\r\n"
                                    },
                                    new Paragraph
                                    {
                                        Body = "Carefully study the changes in this file. We've added styles to most elements. Try tweaking some of the styles to reinforce what you've learned 😎. Run the app and you should now see a much more interesting UI: "
                                    },
                                     new Paragraph
                                    {
                                        IsPicture = true,
                                        PictureUrl = "c5-ch15-wpf-styling.png"
                                    },
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "You can find the code for the current state of this project <a href='https://github.com/TheCSharpAcademy/TCSA.Study.Recipes/tree/10.Styling' target='_blank'>in this link</a>." }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500116,
                        CourseDisplayId = 17,
                        Title = "Where to Go From Here",
                        Slug = "intro-to-wpf-from-here",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {

                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "Congratulations! You've complete the Intro To WPF course and should now be able to create your own applications using this popular technology and creating a good foundation for learning more advanced techniques such as the MVVM pattern. You've also learned the fundamentals of XAML, an important stepping-stone to work with any many other frameworks, such as WinUI, MAUI and Avalonia."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Challenges",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "There's no better way to reinforce your knowledge than tweaking and enhancing this app, using your creativity to express yourself as a developer, adding your personal touch. Here are a few ideas:"
                                    },
                                    new Paragraph {
    Body =
    "<b>🟢 Easy</b><br>" +
    "<b>🔹 Deploy</b>: Try deploying your app so it can be used by anyone using Windows, regardless of Visual Studio.<br>" +
    "<b>🔹 More Detail</b>: Let the users add ingredients that can be used across different recipes.<br>" +
    "<b>🔹 Theming</b>: Let the users choose themes. A common example of themes is day/night mode.<br><br>" +

    "<b>🟣 Intermediate</b><br>" +
    "<b>🔹 Photos</b>: Allow users to upload pictures of recipes/ingredients.<br>" +
    "<b>🔹 Interactive</b>: Make the content interactive by creating a checklist that the user can tick as they go through the recipe.<br><br>" +

    "<b>🔴 Advanced</b><br>" +
    "<b>🔹 Voice</b>: Make the user's lives easier by getting the app to read the instructions as they follow a recipe. How about letting the user speak to the app to go forward or back a step so they don't need to take their hands off the food?<br>"
}

                                }
                            },
                            new Block
                            {
                                Title = "Feedback",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "Please let us know how we went! If something doesn't work, or you saw typos, errors or if you found it too easy, too hard, or even if it's perfect for you, drop your opinion on the <b>feedback channel</b> in The C# Academy <a href='https://discord.com/invite/aDMDET8ywB' target='_blank' style='color: #7DA2C8;'>Discord Server</a>. "
                                    },
                                    new Paragraph {
                                       Body = "Thanks for going through the course! We hope you enjoyed it and see you in the next one! 🙏 "
                                    }
                                }
                            },
                        }
                    }
                }
        };
    }
}
