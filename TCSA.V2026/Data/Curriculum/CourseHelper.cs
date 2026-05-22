using TCSA.V2026.Data.Models;

namespace TCSA.V2026.Data.Curriculum;

public class CourseHelper
{
    public static List<Course> GetCourses()
    {
        return new List<Course>
        {
            OopCourse.GetOopCourse(),
            WebApiCourse.GetWebApiCourse(),
            SqlCourse.GetSqlCourse(),
            WpfCourse.GetWpfCourse(),
            DiCourse.GetDiCourse(),
            ReactCourse.GetReactCourse()
        };
        //return new List<Course>
        //{

        //    new Course
        //    {
        //        Id = 2,
        //        Title = "Azure AI Speech",
        //        Description = "Master speech capabilities in Azure AI for dynamic, voice-driven applications!",
        //        Articles = new List<Article>
        //        {
        //            new Article
        //            {
        //                Id = 500026,
        //                CourseDisplayId = 1,
        //                Title = "Introduction",
        //                Slug = "ai-speech-introduction",
        //                Description = "",
        //                Area = Area.Course,
        //                ExperiencePoints = 1,
        //                Blocks = new List<Block>
        //                {
        //                    new Block
        //                    {
        //                        Paragraphs = new List<Paragraph>
        //                        {
        //                            new Paragraph { Body = "Welcome to our Azure AI Speech course! In this course we will learn about this amazing Azure-powered AI functionality while building a cool project. You should be excited! This course will be an e-eye-opener for the possibilities of AI integration!" }
        //                        }
        //                    },
        //                    new Block
        //                    {
        //                        Title = "Who's This Course For?",
        //                        Paragraphs = new List<Paragraph>
        //                        {
        //                            new Paragraph {
        //                               Body = "This course <b>isn't for absolute beginners in C#</b>. You might struggle if you don't know basic topics such as basic C# syntax (variables, loops, methods, data types, basic data structures, control flow), how to navigate Visual Studio or Visual Studio Code and how to create a console apps, to mention a few. If you're an absolute beginner, <a href='project/53/math-game' target='_blank'>we recommend you go back to this article and build a solid foundation first</a>." },
        //                            new Paragraph {
        //                               Body = "It's also advisable to have some experience with <b>asynchronous programming</b>. While you don't need to be an expert, Azure Speech APIs provide asynchronous endpoints, so we need to code accordingly. Having zero experience with the <b>\"Task\", \"async\" and \"await\"</b> keywords might pose some challenges. You'll still be able to follow along, but make sure you research the keywords and concepts you haven't seen before." }
        //                        }
        //                    },
        //                    new Block
        //                    {
        //                        Title = "What to Expect?",
        //                        Paragraphs = new List<Paragraph>
        //                        {
        //                            new Paragraph {
        //                               Body = "By the end of this course you should be comfortable using the Azure Speech Services API. Most importantly, you'll understand what this integration is capable of, leading to your own ideas for interesting projects. " },
        //                            new Paragraph {
        //                               Body = "Basic understanding of how to interact with Azure Speech Services will also give you a foundation for how to interact with other Azure services in your projects. There are similarities across all of these services and you'll be more confident to tackle them on your own." }
        //                        }
        //                    },
        //                     new Block
        //                    {
        //                        Title = "AI Building vs AI Integration",
        //                        Paragraphs = new List<Paragraph>
        //                        {
        //                            new Paragraph {
        //                               Body = "In this course <b>we won't be building AI systems</b>. Instead we will <b>integrate AI into an app</b>. It's important to make this distinction. Even though both skills are important to learn, they're fundamentally different." },
        //                            new Paragraph {
        //                               Body = "<b>Building AI</b> involves data collection and preparation, machine or deep learning algorithm development and model training. <b>Integrating AI</b> refers to using existing AI services, libraries, or pre-trained models to add intelligent features to an app." }
        //                        }
        //                    },
        //                     new Block
        //                    {
        //                        Title = "What We Recommend",
        //                        Paragraphs = new List<Paragraph>
        //                        {
        //                            new Paragraph {
        //                               Body = "<b>Study each chapter carefully</b>. Make quick notes with important observations and remaining doubts. <b>Don't rush through the chapters</b>. Make sure you understand what each key word does. Ask follow-up questions from Chat GPT. Use it as an assistant. Its biggest strength is the ability to explain concepts in different ways in a conversational style." },
        //                            new Paragraph {
        //                               Body = "Finally, we highly recommend you do <b>at least one of the challenges</b> provided at the end of this course. They'll reinforce your learning and help with knowledge retention. There's nothing quite like building something yourself!" }
        //                        }
        //                    }
        //                }
        //            },
        //            new Article
        //            {
        //                Id = 500027,
        //                CourseDisplayId = 2,
        //                Title = "About AI Programming",
        //                Slug = "ai-speech-programming",
        //                Description = "",
        //                Area = Area.Course,
        //                ExperiencePoints = 1,
        //                Blocks = new List<Block>
        //                {
        //                    new Block
        //                    {
        //                        Paragraphs = new List<Paragraph>
        //                        {
        //                            new Paragraph { Body = "In the 2020s, the role of an <b>AI engineer</b> has become more crucial than ever, as artificial intelligence continues to reshape industries and change the way we live and work. With AI technologies like machine learning, natural language processing, and computer vision reaching new levels of maturity, businesses are increasingly relying on AI engineers to develop intelligent solutions that drive innovation and competitive advantage. " }
        //                        }
        //                    },
        //                    new Block
        //                    {
        //                        Title = "CRUD Isn't Enough",
        //                        Paragraphs = new List<Paragraph>
        //                        {
        //                            new Paragraph {
        //                               Body = "Gone are the days when it would suffice to know how to implement <b>CRUD operations</b> to survive in the tech Industry. As companies across various sectors, from healthcare to finance, seek to leverage the power of AI for efficiency and insights, the demand for skilled AI engineers is growing rapidly, making it a promising career path for those interested in cutting-edge technology." },
        //                            new Paragraph {
        //                               Body = "The rise of AI in 2024 lead to transformative changes in the job market, with new opportunities emerging in areas such as autonomous systems, data-driven decision-making, and AI-enhanced software development. AI engineers are not only responsible for creating and maintaining algorithms but also for <b>integrating AI into existing systems</b> to solve complex problems and automate tasks.  With organizations striving to incorporate AI into their business models, AI engineers are positioned to play a key role in shaping the future of work and driving digital transformation." }
        //                        }
        //                    },
        //                    new Block
        //                    {
        //                        Title = "How Does it Fit In Your Learning Journey?",
        //                        Paragraphs = new List<Paragraph>
        //                        {
        //                            new Paragraph {
        //                               Body = "Given all these transformations, the best approach to learn programming in our decade is thinking of AI <b>not as a replacement</b> to the current skill set necessary to get into the industry, but as part of it. Engineers still need to know front-end, back-end, SQL and everything else we currently study. AI will purely be part of the tech stack. That's not to mention <b>using AI for learning</b>. LLMs play a crucial role in helping students understand concepts due to its conversational style. Albeit imperfect, studying with the help of an LLM is akin to having a personal instructor available 24/7." },
        //                            new Paragraph {
        //                               Body = "The great news is that <b>it's all just getting started</b>. The current impact of AI in our lives and in software development is just the tip of the iceberg. If you're getting into the industry now, <b>you're getting in early</b>. And The C# Academy will take you by the hand in your AI pathway with .NET/Azure. You should be excited! Let's open our doors to the future and embark on our AI Journey." }
        //                        }
        //                    }
        //                }
        //            },
        //            new Article
        //            {
        //                Id = 500028,
        //                CourseDisplayId = 3,
        //                Title = "The Course's Project",
        //                Slug = "ai-speech-course-project",
        //                Description = "",
        //                Area = Area.Course,
        //                ExperiencePoints = 1,
        //                Blocks = new List<Block>
        //                {
        //                    new Block
        //                    {
        //                        Paragraphs = new List<Paragraph>
        //                        {
        //                            new Paragraph { Body = "In this course we will create a <b>Coding Tracker</b>. An application that will log the amount of study time and generate reports on these logs. As a programming student, we find it of the most useful applications you can build. When learning, you should have a weekly and monthly goals and compare it to your performance so you can adjust and plan your schedule around your goals. And a great way to do it is developing an app yourself!" },
        //                            new Paragraph { Body = "Users will provide input using their voice. The program's output will be via text and voice. These functionalities are powered by <b>Azure Cognitive Services</b>. More specifically, Azure Speech Services. " }
        //                        },
        //                    },
        //                    new Block
        //                    {
        //                        Title = "What are Azure Speech Services",
        //                        Paragraphs = new List<Paragraph>
        //                        {
        //                            new Paragraph {
        //                               Body = "Azure Speech Services is a cloud-based service that provides advanced speech-to-text and text-to-speech capabilities. It enables applications to <b>convert spoken language into written text</b> and synthesize spoken language from text, making interactions with software more natural and accessible. Azure Speech Services supports <b>multiple languages and dialects</b>, and can be integrated with other Azure Cognitive Services for a more comprehensive AI-driven experience." }
        //                        }
        //                    },
        //                    new Block
        //                    {
        //                        Title = "Accessibility",
        //                        Paragraphs = new List<Paragraph>
        //                        {
        //                            new Paragraph {
        //                               Body = "Speech-to-text and text-to-speech are some of the tools that can help developers improve accessibility, a crucial concept in modern software development, as it ensures that applications are usable by <b>people with a range of abilities</b>. Integrating voice input and output can make an application more accessible to those who may have difficulty using traditional input devices like a keyboard or mouse. By embracing accessibility, developers can create <b>inclusive experiences</b> that cater to a broader audience, ensuring that everyone has the opportunity to benefit from technology." }
        //                        }
        //                    },
        //                    new Block
        //                    {
        //                        Title = "Why Learn With Projects?",
        //                        Paragraphs = new List<Paragraph>
        //                        {
        //                            new Paragraph {
        //                               Body = "Learning with projects is important because it allows students to apply theoretical knowledge in a <b>practical context</b>. Building real-world applications helps solidify concepts and gives students a sense of accomplishment. Working on projects like the Coding Tracker also exposes learners to <b>common challenges they will face in the industry</b>, such as integrating APIs, handling user input, and implementing accessibility features, preparing them for future development tasks." }
        //                        }
        //                    }
        //                }
        //            },
        //            new Article
        //            {
        //                Id = 500029,
        //                CourseDisplayId = 4,
        //                Title = "Creating an Azure Account",
        //                Slug = "ai-speech-azure-account",
        //                Description = "",
        //                Area = Area.Course,
        //                ExperiencePoints = 1,
        //                Blocks = new List<Block>
        //                {
        //                    new Block
        //                    {
        //                        Paragraphs = new List<Paragraph>
        //                        {
        //                            new Paragraph { Body = "Let's go through the steps to set up a free Azure Account. First navigate to <a href='project/53/math-game' target='_blank'>Azure's Website</a>. If you already have an Azure account, mark this article as read and proceed to the next." },
        //                            new Paragraph { Body = "<b>Click on the </b>\"Start free\" button</b> on the homepage. This will guide you to sign up for a free Azure account, which provides credits to use on various Azure services for the first 30 days." },
        //                            new Paragraph { Body = "<b>Sign In or Create a Microsoft Account</b>: If you don't have a Microsoft account, you'll need to create one. If you already have one, sign in with your existing credentials." },
        //                            new Paragraph { Body = "<b>Provide Basic Information</b>: Fill out the required details, such as your name, email address, and phone number. <b>Verify your identity</b> using a phone number to receive a verification code." },
        //                            new Paragraph { Body = "Although you won't be charged if you delete your learning resources after using them, <b>you must provide a credit or debit card for identity verification</b>. Microsoft uses this card to ensure that you're a real person, but <b>you won’t be charged</b> as long as you stay within the free services and credits." },
        //                            new Paragraph { Body = "<b>Read the terms and conditions</b> and privacy statement, then accept them." },
        //                            new Paragraph { Body = "<b>Complete the Setup</b>: Once the account is set up, you'll get free access to various Azure services and <b>$200 in credit</b> for the first 30 days to explore Azure services." },
        //                            new Paragraph { Body = "<b>Once your credits expire</b>, you can still use Azure for learning. You can still use most features for free, as long as you delete the resources once you're done using them." },
        //                            new Paragraph { Body = "After completing these steps, you'll have a <b>fully functional Azure account</b> and can start using services like Cognitive Services, Azure Machine Learning, and more." }
        //                        }
        //                    }
        //                }
        //            },
        //            new Article
        //            {
        //                Id = 500030,
        //                CourseDisplayId = 5,
        //                Title = "Creating a Speech Service",
        //                Slug = "ai-speech-creating-service",
        //                Description = "",
        //                Area = Area.Course,
        //                ExperiencePoints = 1,
        //                Blocks = new List<Block>
        //                {
        //                    new Block
        //                    {
        //                        Paragraphs = new List<Paragraph>
        //                        {
        //                            new Paragraph { Body = "In the Azure Console, search for <b>Azure Speech</b>. You'll be taken to the Azure AI Services dashboard. <b>Click on Create</b>." },
        //                            new Paragraph {
        //                                IsPicture = true,
        //                                PictureUrl = "tcsa-speech-azure-1.png"
        //                            },
        //                            new Paragraph { Body = "Choose a Resource Group and a Name For Your Service and <b>Standard S0</b> as your price tier. Click on Review + Create." },
        //                            new Paragraph {
        //                                IsPicture = true,
        //                                PictureUrl = "tcsa-speech-azure-2.png"
        //                            },
        //                            new Paragraph { Body = "Once the resource is created, open a text note and copy and paste your Location/Region value and your Key 1. You'll need those values to connect to the service API." },
        //                            new Paragraph {
        //                                IsPicture = true,
        //                                PictureUrl = "tcsa-speech-azure-3.png"
        //                            }
        //                        }
        //                    }
        //                }
        //            },
        //            new Article
        //            {
        //                Id = 500031,
        //                CourseDisplayId = 6,
        //                Title = "Creating the Course Project",
        //                Slug = "ai-speech-creating-project",
        //                Description = "",
        //                Area = Area.Course,
        //                ExperiencePoints = 1,
        //                Blocks = new List<Block>
        //                {
        //                    new Block
        //                    {
        //                        Paragraphs = new List<Paragraph>
        //                        {
        //                            new Paragraph { Body = "Let's start by creating a console application and installing the <b>Microsoft.CognitiveServices.Speech</b> NuGet package. This package is part of Azure's Cognitive Services and provides functionalities for integrating speech-related capabilities into applications. " },
        //                            new Paragraph { Body = "Next, in Program.cs, let's implement the following code:" },
        //                            new Paragraph {
        //                                IsCode = true,
        //                                Body = "while (true)\r\n{\r\n    Console.WriteLine(\"What would you like to do?\");\r\n    //collect input\r\n    var menuChoices = MenuChoices.ViewRecords;\r\n\r\n    switch (menuChoices)\r\n    {\r\n        case MenuChoices.ViewRecords:\r\n            {\r\n                ViewRecords();\r\n                break;\r\n            }\r\n        case MenuChoices.AddRecord:\r\n            {\r\n                AddRecord();\r\n                break;\r\n            }\r\n        case MenuChoices.DeleteRecord:\r\n            {\r\n                DeleteRecord();\r\n                break;\r\n            }\r\n        case MenuChoices.CreateReport:\r\n            {\r\n                Report();\r\n                break;\r\n            }\r\n    }\r\n\r\n    Console.WriteLine(\"Waiting for Input\");\r\n}\r\n\r\nvoid ViewRecords()\r\n{\r\n\r\n}\r\n\r\nvoid AddRecord()\r\n{\r\n\r\n}\r\n\r\nvoid DeleteRecord()\r\n{\r\n\r\n}\r\n\r\nvoid Report()\r\n{\r\n\r\n}\r\n\r\npublic enum MenuChoices\r\n{\r\n    ViewRecords,\r\n    AddRecord,\r\n    DeleteRecord,\r\n    CreateReport\r\n}"
        //                            },
        //                            new Paragraph { Body = "This code has a simple menu of choices. Users will be able to add, delete and view coding records. Powering the menu is a switch statement based on an <b>Menu Choices enum</b> (at the end of the file). The switch runs inside a loop so it keeps running after each operation. The call to collect the voice input will be after the <b>What would you like to do?</b> message. The operations will be handled by methods that can be found after the loop." },
        //                        }
        //                    }
        //                }
        //            },
        //        }
        //    },

        //};
    }
}
