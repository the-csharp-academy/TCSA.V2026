using TCSA.V2026.Data.Models;
using static TCSA.V2026.Helpers.CourseContentHelper;

namespace TCSA.V2026.Data.Curriculum;

public class UnityMovingObjectCourse
{
    public static Course GetUnityMovingObjectCourse()
    {
        return new Course
        {
            Id = 10,
            Title = "Intro to Unity - Moving an object",
            Description = "Create a Unity 6 project and move a 2D object with WASD using Unity's modern Input System.",
            ImgUrl = "article-placeholder.png",
            Articles = new List<Article>
            {
                IntroChapter(
                    1,
                    "About This Course",
                    "about-intro-to-unity-moving-an-object",
                    "Understand what this course covers, what you will build, and the recommended C# experience.",
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Welcome to <b>Intro to Unity - Moving an object</b>. This short course introduces the basic concepts and tools behind Unity by guiding you through one complete result: a square that moves when you press W, A, S, and D."),
                            Text("You will become familiar with Unity Hub, the Unity editor, scenes, GameObjects, components, the Hierarchy, Scene and Game views, the Inspector, C# scripts, Transforms, and Unity's modern Input System. The objective is not to memorise the whole editor. It is to understand how these pieces cooperate to create interactive behaviour."),
                            Text("By the end, you will have created a Unity 6 Universal 2D project named <code class='inline-code'>CollectorGame</code>, configured a Move action, generated its C# class, attached a PlayerController component, and changed a GameObject's position from code.")
                        }
                    },
                    new Block
                    {
                        Title = "Recommended Experience",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Previous C# experience is ideal. You should be comfortable with variables, classes, fields, methods, object creation, and basic arithmetic. Unity introduces enough new concepts of its own, so learning the language fundamentals first will make this course much easier."),
                            Text("If you are new to C#, begin with the <a href='/project/75/freecodecamp-certification' target='_blank'>FreeCodeCamp C# Certification</a>, then build the <a href='/project/53/math-game' target='_blank'>Math Game</a>. Those roadmap steps provide the language and project experience assumed here."),
                            Text("You do not need previous experience with Unity, game engines, graphics, physics, or game design.")
                        }
                    },
                    new Block
                    {
                        Title = "Course Scope",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("This course deliberately stops when the square moves. Collectibles, collisions, score UI, prefabs, random spawning, and winning conditions are useful next steps, but they are not part of what we are building here."),
                            Text("There are no exercises in this first draft. Follow each chapter in order and reproduce every action in your own Unity project.")
                        }
                    },
                    new Block
                    {
                        Title = "Windows, macOS, and Linux",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("You can complete this course on <b>Windows, macOS, or Linux</b>. Unity Hub and the Unity editor are available for all three operating systems, and the Unity project and C# code created in the course are the same on each one."),
                            Text("Installation and a few operating-system details differ, including file locations, keyboard shortcuts, and the way applications are authorised to run. The installation chapter provides separate instructions where necessary. Once the Unity editor is open, the tutorial follows one shared path.")
                        }
                    },
                    new Block
                    {
                        Title = "Different Ways to Describe Games",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Games can be classified in several overlapping ways. A description may refer to the game's <b>genre</b>, its <b>visual dimension</b>, its <b>camera perspective</b>, or the way the player interacts with it."),
                            Text(RedDotList(
                                "<b>Genre</b>: action, role-playing, strategy, puzzle, simulation, platformer, racing, and many others.",
                                "<b>Dimension</b>: 2D games use a flat visual plane, while 3D games represent depth and three-dimensional space.",
                                "<b>Perspective</b>: side view, first person, third person, isometric, or top-down.",
                                "<b>Movement style</b>: platform movement, grid movement, physics-driven movement, point-and-click movement, or free movement across a plane.")),
                            Text("These labels are not mutually exclusive. One game might be a 2D, top-down, role-playing and farming simulation at the same time.")
                        }
                    },
                    new Block
                    {
                        Title = "Why We Chose a Top-Down Game",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("The style you were remembering is <b>top-down</b>. Our eventual game takes inspiration from the movement and presentation of games such as <i>Stardew Valley</i>: the player looks down into a 2D world and can move horizontally and vertically across it."),
                            Text("<i>Stardew Valley</i> is more specifically a country-life role-playing and farming simulation, but <b>2D top-down</b> is the useful technical description for the perspective and movement we are beginning with."),
                            Text("A top-down project is an excellent introduction for C# students because movement can be understood directly as changes to X and Y. We can learn GameObjects, components, input, collisions, collectibles, UI, and game state without first dealing with jumping, gravity, platforms, or a complicated 3D camera."),
                            Text("It also gives us an immediately recognisable foundation. Even though the Player is only a square in this course, moving it in four directions is the first piece of the same interaction model used by a much richer top-down game.")
                        }
                    },
                    new Block
                    {
                        Title = "One Game Across Several Courses",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("This is the first course in a sequence. Future Unity courses will build on the same ideas and gradually turn this small beginning into a finished game."),
                            Text("Later courses can replace the square with artwork, create a world, add collisions and collectibles, introduce animation, build user interfaces and scoring, create reusable prefabs, manage scenes and game state, add sound, and prepare the game for release."),
                            Text("Each course will introduce a manageable set of Unity and C# concepts while producing a visible improvement to the game. By continuing from this foundation, you will learn how complete games emerge from many small, understandable systems rather than one enormous step.")
                        }
                    }),
                IntroChapter(
                    2,
                    "Unity in Game Development: Context and History",
                    "unity-game-development-context-and-history",
                    "Understand where Unity fits among game-development tools and how the engine developed.",
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            Text("A finished game combines many systems: graphics, input, audio, animation, physics, user interfaces, scenes, saved data, and platform-specific builds. Developers can create all of that technology themselves, but doing so requires a large amount of specialised work before the game itself exists."),
                            Text("A <b>game engine</b> provides reusable systems and an editor for assembling them. Unity gives developers a visual workspace for arranging a game while C# scripts define its behaviour. The engine runs the update loop, renders the scene, receives device input, and connects your components to the underlying platform.")
                        }
                    },
                    new Block
                    {
                        Title = "Where Unity Fits",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Unity is a general-purpose, cross-platform game engine. It is used for 2D and 3D games ranging from small personal projects to commercial releases. A Unity project can target several kinds of hardware without every gameplay system being rewritten from scratch."),
                            Text("Unity sits between low-level graphics and operating-system APIs and the game-specific code you write. You work with concepts such as GameObjects, components, scenes, assets, and C# scripts while Unity handles much of the platform and rendering infrastructure."),
                            Text("Unity is one option rather than the definition of game development. Other engines include Unreal Engine, Godot, and specialised tools, while some teams build custom engines. Each makes different trade-offs involving language, rendering, workflow, licensing, performance, and control.")
                        }
                    },
                    new Block
                    {
                        Title = "Unity Beyond Games",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("The same real-time 2D and 3D capabilities can also support simulations, visualisation, training, architecture, automotive experiences, and interactive installations. The workflow learned in this course—placing objects and controlling them with code—applies across those uses.")
                        }
                    },
                    new Block
                    {
                        Title = "Other Game Engines and Languages",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Unity is not the only route into game development. Different engines suit different projects, teams, platforms, and programming backgrounds."),
                            Text(RedDotList(
                                "<b>Unreal Engine</b> commonly uses C++ for native gameplay code and Blueprints for visual scripting. It is widely used for high-end 3D games and real-time visual experiences.",
                                "<b>Godot</b> supports its own GDScript language as well as C# and C++. It is open source and is popular for both 2D and 3D projects.",
                                "<b>GameMaker</b> uses GameMaker Language and provides a focused workflow that is especially approachable for 2D games.",
                                "<b>Custom engines and frameworks</b> may use C++, C, Rust, JavaScript, Java, C#, or other languages when a team needs more direct control or a specialised runtime.")),
                            Text("The engine and language are related choices, but they are not the same thing. Games can be created with many languages, and some engines support more than one. We chose Unity because it provides an approachable visual editor, strong 2D tools, broad platform support, and a direct path for applying the C# skills taught throughout the Academy.")
                        }
                    },
                    new Block
                    {
                        Title = "A Brief History of Unity",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Unity began in the mid-2000s with the goal of making game development more accessible. Unity 1.0 appeared in 2005 and initially focused on Mac OS X development. Its visual editor and component-based workflow offered smaller teams a practical alternative to building an engine from the ground up."),
                            Text("Over subsequent releases, Unity expanded its editor and added support for more deployment targets. That cross-platform approach became one of its defining strengths: developers could build a project in one environment and adapt it for desktop, web, mobile, consoles, and other devices.")
                        }
                    },
                    new Block
                    {
                        Title = "A Growing Ecosystem",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Unity's ecosystem grew alongside the engine. Documentation, tutorials, community packages, and the Unity Asset Store made it easier for developers to learn the tool and reuse art, audio, editor extensions, and code."),
                            Text("Unity also evolved from a tool strongly associated with independent games into technology used by teams of many sizes and by industries outside traditional games. During that growth, its rendering systems, editor, scripting tools, services, and release model changed substantially.")
                        }
                    },
                    new Block
                    {
                        Title = "Unity 6",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Unity launched Unity 6 on 17 October 2024. This course uses the Unity 6 workflow and its Universal 2D template rather than teaching an older editor version."),
                            Text("Unity will continue to change, so exact buttons and labels may move. The lasting ideas are more important: scenes contain GameObjects, components provide data and behaviour, scripts are components, and input can drive changes to a Transform.")
                        }
                    }),
                IntroChapter(
                    3,
                    "Install Unity",
                    "install-unity-on-windows-macos-and-linux",
                    "Install Unity Hub and the Unity 6 editor on Windows, macOS, or Linux.",
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Unity Hub manages Unity editor versions, optional platform modules, projects, and your Unity account. Install the Hub first rather than downloading an individual editor installer."),
                            Text("Go to <a href='https://unity.com/download' target='_blank'>Unity's official download page</a>, choose your operating system, and download Unity Hub. Create or sign in to a Unity account when prompted.")
                        }
                    },
                    new Block
                    {
                        Title = "Windows",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Download the Windows installer, run it, accept the licence prompt, and follow the setup wizard. Open Unity Hub after installation and allow it to sign in through your browser if requested."),
                            Text("Windows may display a security confirmation because the installer changes the computer. Confirm that the publisher and download source are Unity before continuing.")
                        }
                    },
                    new Block
                    {
                        Title = "macOS",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Download the macOS build appropriate for your Mac. Apple silicon Macs use the ARM64 version, while older Intel Macs use the Intel version. Open the downloaded file and move Unity Hub into Applications if instructed."),
                            Text("The first launch may require confirmation in macOS Privacy & Security settings. Only approve an application downloaded from Unity's official site.")
                        }
                    },
                    new Block
                    {
                        Title = "Linux",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Use Unity's Linux download instructions for your supported distribution. Depending on the current Hub release, Unity may provide a package repository or an AppImage."),
                            Text("If using an AppImage, make it executable before launching it. From the directory containing the file, the command normally looks like:"),
                            Code("chmod +x UnityHub.AppImage"),
                            Text("Linux support is distribution-specific. Check the <a href='https://docs.unity3d.com/6000.0/Documentation/Manual/system-requirements.html' target='_blank'>Unity 6 system requirements</a> before installing.")
                        }
                    },
                    new Block
                    {
                        Title = "Install the Unity 6 Editor",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("In Unity Hub, open <b>Installs</b>, choose <b>Install Editor</b>, and select a Unity 6 release. Prefer the current Long Term Support release offered by the Hub when you begin the course."),
                            Text("Keep the core editor selected. Optional build-support modules are only required when exporting to their platforms, so you do not need Android, iOS, Web, or console modules merely to complete this tutorial."),
                            Text("Finish the installation, then open the Projects section. You are ready to create <code class='inline-code'>CollectorGame</code> in the next chapter.")
                        }
                    }),
                Step(
                    1,
                    "Create a Unity Project",
                    "create-a-unity-project",
                    "Create the CollectorGame project with Unity 6 and the Universal 2D template.",
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Open <b>Unity Hub</b> and click <b>New project</b>. If the template list is filtered to Learning, change the filter to <b>All</b> or <b>Templates</b>. Learning projects are guided samples; this tutorial needs a blank project."),
                            Video("/vid/Unity.1.Createproject.mp4", "Opening Unity Hub and starting a new project."),
                            Text("Select <b>Universal 2D</b>. Unity 6 also displays older or specialised templates, but Universal 2D is the modern 2D starting point and contains everything required for this tutorial."),
                            Text("On this screen, you can optionally connect the project to <b>GitHub</b>. This creates an online copy of the project and keeps your work backed up to GitHub as you continue building it. You can leave this option disabled if you only want to store the project on your computer."),
                            Text("Name the project <code class='inline-code'>CollectorGame</code>, choose its location, and click <b>Create project</b>. Wait for Unity to create the files and open the editor.")
                        }
                    }),
                Step(
                    2,
                    "Explore the Unity Editor and Save Your Scene",
                    "meet-the-unity-editor",
                    "Explore the main Unity editor windows and save the project's first scene.",
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            Text("The Unity editor is divided into several windows, with each one responsible for a different part of game development. Learning what they show and how they work together will make the editor feel much less intimidating."),
                            Text("Your layout may look slightly different from the one in the video. Unity windows can be resized, moved, grouped into tabs, and closed. You can open a missing window from the <b>Window</b> menu, or restore the standard arrangement from the <b>Layout</b> menu in the upper-right corner.")
                        }
                    },
                    new Block
                    {
                        Title = "The Hierarchy",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("The <b>Hierarchy</b> lists every GameObject in the current scene. A GameObject can represent something visible, such as a character or camera, or something invisible that organises logic and behaviour."),
                            Text("Selecting an object in the Hierarchy also selects it in the Scene view and displays its components in the Inspector. Objects can also be placed inside other objects, creating a parent-and-child relationship that is shown through indentation."),
                            Text("You will use the Hierarchy to find the square, rename it <code class='inline-code'>Player</code>, and select it whenever you need to change its components.")
                        }
                    },
                    new Block
                    {
                        Title = "The Scene View",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("The <b>Scene</b> view is your visual workspace. It lets you inspect and arrange the objects that make up the current level or screen. Think of it as looking behind the scenes while the game is being assembled."),
                            Text("The toolbar provides tools for selecting, moving, rotating, and scaling objects. In a 2D project, you will mostly work with the Select and Move tools. You can pan and zoom around the Scene view without changing what the player sees."),
                            Text("Changes made here update the selected GameObject's Transform values. Later in the course, your C# code will change those same values to move the Player.")
                        }
                    },
                    new Block
                    {
                        Title = "The Game View",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("The <b>Game</b> view shows what the active Camera sees. This is the closest representation of what a player will see when the finished game runs."),
                            Text("Press the <b>Play</b> button at the top of the editor to enter Play mode and test the game. Press it again to stop. Changes made to objects during Play mode are normally temporary and are discarded when you stop, so make permanent edits outside Play mode."),
                            Text("The Scene view is therefore used to build and inspect the world, while the Game view is used to experience and test it.")
                        }
                    },
                    new Block
                    {
                        Title = "The Inspector",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("The <b>Inspector</b> displays the components and properties belonging to the currently selected GameObject or asset. Its contents change whenever you select something different."),
                            Text("Every GameObject has a <b>Transform</b>, which stores its position, rotation, and scale. Other components provide additional capabilities: a Sprite Renderer draws an image, a Camera displays the scene, and a C# script supplies custom behaviour."),
                            Text("The Inspector is also where you add, remove, enable, and configure components. You will use it frequently when preparing the Player later in this course.")
                        }
                    },
                    new Block
                    {
                        Title = "The Project Window",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("The <b>Project</b> window displays the files and assets stored in the project's <code class='inline-code'>Assets</code> folder. These include scenes, scripts, sprites, input actions, audio, and many other resources used by the game."),
                            Text("Folders in this window help keep a growing project organised. Moving or renaming an asset through Unity allows the editor to update its internal references, so use the Project window instead of moving project assets with your operating system's file explorer."),
                            Text("An asset in the Project window is not necessarily present in the current scene. It becomes part of a scene when it is added as, or assigned to, a GameObject.")
                        }
                    },
                    new Block
                    {
                        Title = "The Console",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("The <b>Console</b> reports messages from Unity and your C# code. Red entries are errors, yellow entries are warnings, and ordinary log messages help you observe what the game is doing."),
                            Text("A compiler error can prevent the game scripts from running, so the Console should be the first place you check when something does not work. Selecting a message shows more detail, and double-clicking many errors takes you directly to the relevant line of code."),
                            Text("You may not need the Console immediately, but it becomes essential once you create the PlayerController script.")
                        }
                    },
                    new Block
                    {
                        Title = "Save Your First Scene",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Use <b>File &gt; Save As</b> and save the scene inside the Assets folder as <code class='inline-code'>MainScene</code>. A scene stores the GameObjects that make up a level or screen."),
                            Text("The new scene already contains a Camera. Leave it in place: it determines what is visible in the Game view."),
                            Text("Save regularly while working. Unity saves assets and scenes separately, so saving the scene is an important habit."),
                            Video("/vid/Unity.2.Explore.mp4", "Exploring the main windows in the Unity editor.")
                        }
                    }),
                Step(
                    3,
                    "Create the Player and Its Controller",
                    "create-the-player-and-its-controller",
                    "Create the Player, explore its Transform, and attach its PlayerController component.",
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            Text("<b>What is a sprite?</b> A sprite is a 2D image used inside a game. It can represent a character, object, background element, icon, or anything else the player can see. Unity displays a sprite in a scene by placing it on a GameObject with a <b>Sprite Renderer</b> component. The sprite provides the image, while the GameObject and its components control where it appears and how it behaves."),
                            new Paragraph
                            {
                                Body = "<b>Why is it called a sprite?</b><br><br>In early game hardware, backgrounds were drawn separately while characters, enemies, bullets, and other small images were placed over them by dedicated graphics hardware. Because these images moved independently and appeared to float over the background, they became known as <i>sprites</i>—a word for small spirits or supernatural beings. Modern engines no longer depend on that old hardware technique, but the name remains.",
                                BackgroundColor = "#c9436e",
                                FontColor = "#FFFFFF"
                            },
                            Text("Right-click inside the Hierarchy and choose <b>2D Object &gt; Sprites &gt; Square</b>. You can also use the GameObject menu at the top of the editor."),
                            Text("Unity adds a square GameObject to the scene. Its <b>Sprite Renderer</b> component is responsible for drawing the square."),
                            Text("The square should appear near the centre of the Scene and Game views. If it does not, select it and continue to the Transform step.")
                        }
                    },
                    new Block
                    {
                        Title = "Name the GameObject",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Select the square in the Hierarchy and rename it <code class='inline-code'>Player</code>. You can rename it through the context menu or by selecting its current name."),
                            Text("GameObject names do not create behaviour, but descriptive names make a scene much easier to understand. As a project grows, names such as Player, Main Camera, and Collectible are far more useful than Square or GameObject."),
                            Text("Confirm that <code class='inline-code'>Player</code> now appears in the Hierarchy."),
                            Video("/vid/Unity.3.Createsprite.mp4", "Creating and renaming square sprite.")
                        }
                    },
                    new Block
                    {
                        Title = "Inspect the Transform",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Select Player and find its <b>Transform</b> component in the Inspector. Every GameObject has a Transform describing its position, rotation, and scale."),
                            Text("In this 2D project, X controls left and right, Y controls up and down, and Z can remain zero. Set Position X and Y to different values and see the position of the <b>Player</b> sprite change in the scene. Similarly, change the Scale properties and observe the modifications in the size of the sprite "),
                            Text("The movement script will change <code class='inline-code'>transform.position</code>. This is how the keyboard input will eventually move the square."),
                            Video("/vid/Unity.4.TryInspector.mp4", "Trying the Inspector")
                        }
                    },
                    new Block
                    {
                        Title = "Create a Scripts Folder",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("In the Project window, right-click the Assets folder and create a new folder named <code class='inline-code'>Scripts</code>. Open that folder before creating the controller."),
                            Text("Unity does not require this folder, but keeping scripts separate from scenes and input assets makes the project easier to navigate."),
                            Text("This tutorial only creates one script, but using a clear structure from the beginning prevents the Assets folder from becoming confusing later.")
                        }
                    },
                    new Block
                    {
                        Title = "Create PlayerController",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Inside the Scripts folder, create a C# script named <code class='inline-code'>PlayerController</code>. The filename and class name must match."),
                            Code("using UnityEngine;\r\n\r\npublic class PlayerController : MonoBehaviour\r\n{\r\n    private void Start()\r\n    {\r\n    }\r\n\r\n    private void Update()\r\n    {\r\n    }\r\n}"),
                            Text("<code class='inline-code'>MonoBehaviour</code> allows Unity to attach this class to a GameObject and call lifecycle methods such as <code class='inline-code'>Start()</code> and <code class='inline-code'>Update()</code>.")
                        }
                    },
                    new Block
                    {
                        Title = "Attach PlayerController",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Return to Unity and wait for the script to compile. Drag <code class='inline-code'>PlayerController</code> from the Project window onto Player in the Hierarchy."),
                            Text("Alternatively, select Player, click <b>Add Component</b> in the Inspector, and search for PlayerController."),
                            Text("Confirm that <b>Player Controller (Script)</b> appears in the Player's Inspector. Code in a MonoBehaviour does not control a GameObject until the component is attached."),
                            Video("/vid/Unity.5.PlayerController.mp4", "Creating Playercontroller script.")
                        }
                    }),
                Step(
                    4,
                    "Configure the Player Input Actions",
                    "configure-the-player-input-actions",
                    "Create and configure the Move action, bind W, A, S, and D, and generate its C# class.",
                    new Block
                    {
                        Title = "Create an Input Actions Asset",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Unity's modern Input System stores controls in an Input Actions asset. In the Project window, select the root <b>Assets</b> folder and create a new folder named <code class='inline-code'>Input Actions</code>. Open the new folder, create an <b>Input Actions</b> asset inside it, and name the asset <code class='inline-code'>PlayerInputActions</code>."),
                            Text("This asset will define what Move means without making PlayerController check W, A, S, and D separately."),
                             Video("/vid/Unity.6.Inputactions.mp4", "Creating PlayerinputActions asset.")
                        }
                    },
                    new Block
                    {
                        Title = "Create the Player Action Map",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("In the Input Actions editor, create an action map named <code class='inline-code'>Player</code>."),
                            Text("An action map groups controls that belong to the same context. A larger game might have separate maps for Player, UI, or Vehicles."),
                            Text("This project only needs the Player map. Select it before adding the movement action.")
                        }
                    },
                    new Block
                    {
                        Title = "Create the Move Action",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Inside the Player action map, create an action named <code class='inline-code'>Move</code>."),
                            Text("The script will refer to this action through <code class='inline-code'>inputActions.Player.Move</code>. The action's name therefore becomes part of the generated C# API."),
                            Text("Move describes the player's intention. The next steps define the kind of value it produces and the keys that produce it.")
                        }
                    },
                    new Block
                    {
                        Title = "Configure Move as a Vector2",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Select Move and set its <b>Action Type</b> to <b>Value</b>. Set its <b>Control Type</b> to <b>Vector2</b>."),
                            Text("A <code class='inline-code'>Vector2</code> contains two numbers. Its X value represents horizontal direction and its Y value represents vertical direction."),
                            Text("This lets one action describe left, right, up, down, and diagonal input.")
                        }
                    },
                    new Block
                    {
                        Title = "Add a 2D Vector Composite",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Add a binding to Move and choose <b>2D Vector composite</b>. The composite contains Up, Down, Left, and Right parts."),
                            Text("A composite combines multiple controls into one value. Instead of asking four separate questions, PlayerController can ask for one movement direction."),
                            Text("Expand the composite so all four directions are visible.")
                        }
                    },
                    new Block
                    {
                        Title = "Bind W, A, S, and D",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Assign the keyboard controls to the four parts of the 2D Vector composite:"),
                            Text(RedDotList(
                                "Up: W",
                                "Down: S",
                                "Left: A",
                                "Right: D")),
                            Text("Save the Input Actions asset. Pressing a key can now produce the direction represented by that part of the composite.")
                        }
                    },
                    new Block
                    {
                        Title = "Generate the Input Actions Class",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Select the <code class='inline-code'>PlayerInputActions</code> asset in the Project window. In the Inspector, enable <b>Generate C# Class</b> and click <b>Apply</b>."),
                            Text("Unity generates a class named <code class='inline-code'>PlayerInputActions</code>. This gives PlayerController strongly typed access to the Player map and Move action."),
                            Text("Do not edit the generated file manually. Make changes in the Input Actions asset and generate the class again."),
                            Video("/vid/Unity.6.Bindings.mp4", "Creating the Move action, binding W, A, S, and D, and generating the Input Actions C# class.")
                        }
                    }),
                Step(
                    5,
                    "Use Input Actions to Move the Player",
                    "use-input-actions-to-move-the-player",
                    "Connect the generated input actions to Unity's lifecycle methods and move the Player.",
                    new Block
                    {
                        Title = "Store the Input Actions",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Open <code class='inline-code'>PlayerController.cs</code>. Add this field inside the class:"),
                            Code("private PlayerInputActions inputActions;"),
                            Text("The field keeps the same input-actions object available to each lifecycle method. The next step will create that object.")
                        }
                    },
                    new Block
                    {
                        Title = "Unity Lifecycle Methods",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("<code class='inline-code'>Awake()</code>, <code class='inline-code'>OnEnable()</code>, <code class='inline-code'>OnDisable()</code>, and <code class='inline-code'>Update()</code> are built-in Unity <b>lifecycle methods</b>. They are special methods recognised by <code class='inline-code'>MonoBehaviour</code>. Unity calls them automatically at particular moments, so you do not call them yourself."),
                            Text("The method names and signatures must be written correctly for Unity to recognise them. <code class='inline-code'>Awake()</code> runs while the component is being loaded, <code class='inline-code'>OnEnable()</code> runs when it becomes active, <code class='inline-code'>OnDisable()</code> runs when it becomes inactive, and <code class='inline-code'>Update()</code> runs once per rendered frame while the component is active."),
                            Text("These methods are empty hooks provided by Unity: you decide what code should run at each point in the component's lifetime.")
                        }
                    },
                    new Block
                    {
                        Title = "Create the Input Actions in Awake",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Add an <code class='inline-code'>Awake()</code> method and create the input-actions object inside it:"),
                            Code("private void Awake()\r\n{\r\n    inputActions = new PlayerInputActions();\r\n}"),
                            Text("<code class='inline-code'>Awake()</code> is called as Unity loads the component. For now, the important point is that <code class='inline-code'>inputActions</code> must exist before the script tries to use it.")
                        }
                    },
                    new Block
                    {
                        Title = "Enable the Player Actions",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Add <code class='inline-code'>OnEnable()</code> and <code class='inline-code'>OnDisable()</code>:"),
                            Code("private void OnEnable()\r\n{\r\n    inputActions.Player.Enable();\r\n}\r\n\r\nprivate void OnDisable()\r\n{\r\n    inputActions.Player.Disable();\r\n}"),
                            Text("The Player action map must be enabled before it can report input. Disabling it when the component becomes inactive keeps its lifetime aligned with PlayerController."),
                            Text("These lifecycle methods are setup required by the Input System. A later Unity course can explore execution order in more depth.")
                        }
                    },
                    new Block
                    {
                        Title = "Read the Move Action",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Replace the empty <code class='inline-code'>Update()</code> method with:"),
                            Code("private void Update()\r\n{\r\n    Vector2 movement = inputActions.Player.Move.ReadValue<Vector2>();\r\n\r\n    transform.position += new Vector3(movement.x, movement.y, 0) * 5f * Time.deltaTime;\r\n}"),
                            Text("<code class='inline-code'>ReadValue&lt;Vector2&gt;()</code> asks the Input System for the current direction. W returns approximately (0, 1), S returns (0, -1), A returns (-1, 0), D returns (1, 0), and no key returns (0, 0)."),
                            Text("The second line applies that direction to <code class='inline-code'>transform.position</code>. X controls left and right, Y controls up and down, <code class='inline-code'>5f</code> is the speed, and <code class='inline-code'>Time.deltaTime</code> keeps the speed consistent across frame rates."),
                            Text("At this point, the entire <code class='inline-code'>PlayerController.cs</code> file should look like this:"),
                            Code("using UnityEngine;\r\n\r\npublic class PlayerController : MonoBehaviour\r\n{\r\n    private PlayerInputActions inputActions;\r\n\r\n    private void Awake()\r\n    {\r\n        inputActions = new PlayerInputActions();\r\n    }\r\n\r\n    private void OnEnable()\r\n    {\r\n        inputActions.Player.Enable();\r\n    }\r\n\r\n    private void OnDisable()\r\n    {\r\n        inputActions.Player.Disable();\r\n    }\r\n\r\n    private void Update()\r\n    {\r\n        Vector2 movement = inputActions.Player.Move.ReadValue<Vector2>();\r\n\r\n        transform.position += new Vector3(movement.x, movement.y, 0) * 5f * Time.deltaTime;\r\n    }\r\n}")
                        }
                    },
                    new Block
                    {
                        Title = "Play the Project",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Save the script, return to Unity, and check that the Console contains no red errors. Press the <b>Play</b> button, open the <b>Game</b> tab, and click once inside the Game window so it has keyboard focus."),
                            Text("Press W, A, S, and D. The square should move around the screen."),
                            Text("If it does not move, confirm that PlayerController is attached, the generated class exists, Generate C# Class was applied, Move is Value / Vector2, the WASD composite is configured, the Player map is enabled, and the Game view has focus."),
                            Text("<b>Congratulations!</b> You created your first interactive Unity project using Unity 6's modern Input System."),
                            Video("/vid/Unity.7.Play.mp4", "Moving sprite with keys.")
                        },
                    }),
                Step(
                    6,
                    "Add a Collectible",
                    "add-a-collectible",
                    "Add and style a collectible, then observe how the Player interacts with it.",
                    new Block
                    {
                        Title = "Create the Collectible",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Stop Play mode before editing the scene. In the Hierarchy, create a new <b>2D Object &gt; Sprites &gt; Circle</b> and rename the new GameObject <code class='inline-code'>Collectible</code>."),
                            Text("Select Collectible and use its Transform component to move it away from the centre of the scene. Choose a position that the Player can easily reach."),
                            Text("In the Collectible's <b>Sprite Renderer</b> component, change the <b>Color</b> property so it is visually different from the Player. The Sprite Renderer changes how the circle looks; the Transform controls where it appears.")
                        }
                    },
                    new Block
                    {
                        Title = "Test the Interaction",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Enter Play mode and use W, A, S, and D to move the square towards the circle."),
                            Text("<b>Notice that the square goes straight through the circle.</b> Both GameObjects are visible, but Unity has not been told that their shapes should physically interact."),
                            Text("A sprite only supplies an image, and a Transform only supplies position, rotation, and scale. Neither one creates collision. The Player and Collectible would need physics components such as <b>Collider 2D</b> components—and usually a <b>Rigidbody 2D</b> on the moving object—before Unity could detect or prevent an overlap."),
                            Text("For now, this is the expected result. We will build on this scene by detecting the Collectible and making the Player collect it."),
                            Video("/vid/Unity.8.Collectible.mp4", "Adding a collectible and observing the Player move through it.")
                        }
                    })
            }
        };
    }

    private static Article Step(
        int number,
        string title,
        string slug,
        string description,
        params Block[] blocks)
    {
        var courseNumber = number + 3;

        return new Article
        {
            Id = 500399 + courseNumber,
            CourseDisplayId = courseNumber,
            Title = title,
            Slug = slug,
            Description = description,
            Area = Area.Course,
            ExperiencePoints = 1,
            Blocks = blocks.ToList()
        };
    }

    private static Article IntroChapter(
        int number,
        string title,
        string slug,
        string description,
        params Block[] blocks)
    {
        return new Article
        {
            Id = 500399 + number,
            CourseDisplayId = number,
            Title = title,
            Slug = slug,
            Description = description,
            Area = Area.Course,
            ExperiencePoints = 1,
            Blocks = blocks.ToList()
        };
    }

    private static Paragraph Text(string body)
    {
        return new Paragraph { Body = body };
    }

    private static Paragraph Code(string body)
    {
        return new Paragraph
        {
            IsCode = true,
            Body = body
        };
    }

    private static Paragraph Video(string url, string? caption = null)
    {
        return new Paragraph
        {
            IsVideo = true,
            VideoUrl = url,
            Body = caption
        };
    }
}
