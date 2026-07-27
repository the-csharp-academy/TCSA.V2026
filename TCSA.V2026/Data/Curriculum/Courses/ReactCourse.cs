using TCSA.V2026.Data.Models;

namespace TCSA.V2026.Data.Curriculum;

public class ReactCourse
{
    public static Course GetReactCourse()
    {
        return new Course
        {
            Id = 7,
            Title = "Introduction to React",
            Description = "Build beautiful and efficient applications with the most popular Javascript Framework!",
            ImgUrl = "icons8-react-100.png",
            Articles = new List<Article>
                {
                    new Article
                    {
                        Id = 500200,
                        CourseDisplayId = 1,
                        Title = "Introduction",
                        Slug = "intro-to-react-intro",
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
                        }
                    },
                    new Article
                    {
                        Id = 500201,
                        CourseDisplayId = 2,
                        Title = "Setup",
                        Slug = "intro-to-react-setup",
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
                        }
                    },
                    new Article
                    {
                        Id = 500202,
                        CourseDisplayId = 3,
                        Title = "Creating Project",
                        Slug = "intro-to-react-project-creation",
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
                                       Body = "It's time to finally get our hands dirty and create our project. In VSC's terminal, run the following command: "
                                    },
                                    new Paragraph {
                                       IsCode = true,
                                       Body = "npm create vite@latest medbooking -- --template react-ts"
                                    },
                                    new Paragraph {
                                       Body = "This command uses npm (Node Package Manager) to scaffold a new project using Vite, a fast frontend build tool. Medbooking is the name of the project folder, we chose it as the same name as our app but you can choose a different one. The double dash (--)tells npm to pass the following arguments directly to the Vite CLI."
                                    },
                                    new Paragraph {
                                       Body = "If you get asked to choose a template, choose React, followed by Typescript:"
                                    },
                                    new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c7-ch3-project-creation.png"
                                    },
                                    new Paragraph {
                                       Body = "Now run this command to install dependencies (libraries upon which React relies to run):"
                                    },
                                    new Paragraph {
                                       IsCode = true,
                                       Body = "cd medbooking\nnpm install"
                                    },
                                    new Paragraph {
                                       Body = "Once the dependencies are installed, run the following command to start the app:"
                                    },
                                    new Paragraph {
                                       IsCode = true,
                                       Body = "npm run dev"
                                    },
                                    new Paragraph {
                                       Body = "Click on the localhost link you see in the terminal and choose follow link (or alternatively copy and paste the link onto a browser) and you should see React's default page:"
                                    },
                                    new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c7-ch3-default-page.png"
                                    },

                                }
                            },
                        }
                    },
                    new Article
                    {
                        Id = 500203,
                        CourseDisplayId = 4,
                        Title = "Exploring the Files",
                        Slug = "intro-to-react-exploring",
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
                                       Body = "React's basic template has several a couple of folders and several files. Let's have a look at what they are:"
                                    },
                                    new Paragraph {
                                       IsCode = true,
                                       Body = "c7-ch4-project-structure.png"
                                    },
                                    new Paragraph {
   Body = "📁 <b>node_modules folder:</b>: Contains all the installed npm packages. Auto-generated when you run <b>npm install</b>.<br>" +
   "📁 <b>public folder:</b>: Static files like images, fonts, etc. that are directly accessible via URL (e.g., /logo.png). Anything here is not processed by Vite.<br>" +
   "📁 <b>src folder:</b>: Main source code folder.<br>" +
   "📁 <b>assets folder:</b>: Typically holds static assets like images, logos, etc. used in your app.<br>" +
   "🖼️ <b>react.svg and vite.svg</b>: Images used in the starter app.<br>" +
   "📃 <b>App.tsx</b>: Main React component (often the root component). Used by main.tsx to render the app.<br>" +
   "📃 <b>App.css</b>: CSS styles scoped or related to App.tsx.<br>" +
   "📃 <b>index.css</b>: Global CSS styles applied throughout the app.<br>" +
   "📃 <b>main.tsx</b>: Entry point of the React app. Renders the <App /> component into the DOM.<br>" +
   "📃 <b>vite-env.d.ts</b>: Type declarations for Vite-specific features (like import.meta.env).<br>" +
   "📃 <b>.gitignore</b>: Specifies which files/folders Git should ignore (e.g., node_modules, .env).<br>" +
   "📃 <b>eslint.config.js</b>: ESLint configuration file to enforce consistent code quality and style.<br>" +
   "📃 <b>index.html</b>: Main HTML file. Vite injects scripts and mounts your app here.<br>" +
   "📃 <b>package.json</b>: Defines project metadata, dependencies, and scripts.<br>" +
   "📃 <b>package-lock.json</b>: Automatically generated file that locks the versions of installed dependencies.<br>" +
   "📃 <b>README.md</b>: Markdown file that typically includes project overview and setup instructions.<br>" +
   "📃 <b>tsconfig.json</b>: Base TypeScript configuration file.<br>" +
   "📃 <b>tsconfig.app.json</b>: TypeScript config specifically for the application source code.<br>" +
   "📃 <b>tsconfig.node.json</b>: TypeScript config used for Node-specific code like tooling and config files.<br>" +
   "📃 <b>vite.config.ts</b>: Vite’s main configuration file written in TypeScript. Used for plugins, server config, etc."
},

                                    new Paragraph {
                                       Body = "To start fresh, you can safely remove react.svg and vite.svg and remove the contents of App.css, App.tsx and index.css."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Mini.css",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "Mini.css is a minimal, responsive, style-agnostic CSS framework. It's similar to Bootstrap but lighter and requires fewer CSS classes so you can focus on learning React but still get a professional look. To install it, open a new command prompt in VSC and run the following command. Warnings can be ignored but Errors indicate there was a problem:"
                                    },
                                    new Paragraph {
                                       IsCode = true,
                                       Body = "npm install mini.css@3.0.1"
                                    },
                                    new Paragraph {
                                       Body = "Verify mini.css was added as a dependency of the project in package.json:"
                                    },
                                    new Paragraph {
                                       IsPicture = true,
                                       PictureUrl = "c7-ch4-mini-css.png"
                                    },
                                    new Paragraph {
                                       Body = "Then open index.css and copy the following code: "
                                    },
                                    new Paragraph {
                                       IsCode = true,
                                       Body = "@import '../node_modules/mini.css/dist/mini-default.min.css';"
                                    },
                                    new Paragraph {
                                       Body = "Alternatively you could use <b>mini-dark.min.css</b> or <b>mini-nord.min.css</b> for different themes."
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
                                       Body = "You can find the code for the current state of this project <a href='https://github.com/TheCSharpAcademy/TCSA.React.Medbooking/tree/0.Initial-Project' target='_blank'>in this link</a>." }
                                }
                            }
                        }
                    },
                }
        };
    }
}
