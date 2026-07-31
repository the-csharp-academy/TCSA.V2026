using TCSA.V2026.Data.Models;
using static TCSA.V2026.Helpers.CourseContentHelper;
using static TCSA.V2026.Data.Curriculum.ArticleHelper;

namespace TCSA.V2026.Data.Curriculum;

public class UnityMovingObjectCourse
{
    public static Course GetUnityMovingObjectCourse()
    {
        return new Course
        {
            Id = 10,
            Theme = CourseTheme.Unity,
            Title = "Build Your First 2D Unity Game",
            Description = "Build a top-down collector game in Unity 6 with C#: movement, trigger collisions, scoring, win and restart UI, imported sprites, and reusable apple prefabs.",
            ImgUrl = "icons8-board-game-64.png",
            Articles = new List<Article>
            {
                IntroChapter(
                    1,
                    "About This Course",
                    "about-build-your-first-2d-unity-game",
                    "Understand what this course covers, what you will build, and the recommended C# experience.",
                    new Block
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Welcome to <b>Build Your First 2D Unity Game</b>. This beginner course introduces Unity by guiding you through a complete top-down collector game rather than an isolated movement demonstration."),
                            Text("You will become familiar with Unity Hub, the Unity editor, scenes, GameObjects, components, the Hierarchy, Scene and Game views, the Inspector, C# scripts, Transforms, the modern Input System, 2D physics, UI, scene management, assets, and prefabs. The objective is not to memorise the whole editor. It is to understand how these pieces cooperate to create a small but complete game."),
                            Text("By the end, you will have created a Unity 6 Universal 2D project named <code class='inline-code'>CollectorGame</code>. A farmer moves with W, A, S, and D, collects five apples, increases a visible score, displays a win panel, and can restart the scene. The game also uses imported grass and character artwork plus reusable Collectible prefabs.")
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
                            Text("This course builds the foundations of a small collector game: player movement, collectibles, 2D colliders, trigger detection, score UI, a winning condition, scene restarting, imported 2D assets, and reusable prefabs. Timers, animation, random spawning, and multiple levels are useful later steps, but they are not part of what we are building yet."),
                            Text("Most chapters provide guided, step-by-step practice. The final chapter gives you five small challenges to complete independently so you can reinforce the concepts and begin making the game your own.")
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
                            Text("This course uses a <b>top-down</b> style inspired by the movement and presentation of games such as <i>Stardew Valley</i>: the player looks down into a 2D world and can move horizontally and vertically across it."),
                            Text("<i>Stardew Valley</i> is more specifically a country-life role-playing and farming simulation, but <b>2D top-down</b> is the useful technical description for the perspective and movement we are beginning with."),
                            Text("A top-down project is an excellent introduction for C# students because movement can be understood directly as changes to X and Y. We can learn GameObjects, components, input, collisions, collectibles, UI, and game state without first dealing with jumping, gravity, platforms, or a complicated 3D camera."),
                            Text("The Player begins as a square so movement and components are easy to inspect. Later in this same course, you replace that temporary shape with a farmer sprite and turn the simple movement prototype into a recognisable collector game.")
                        }
                    },
                    new Block
                    {
                        Title = "One Game Across Several Courses",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("This is the first course in a sequence. It delivers a complete small game while establishing the Unity and C# foundations that future tutorials will build upon."),
                            Text("This course already covers artwork, a simple world, trigger collisions, collectibles, scoring UI, a win condition, scene restarting, and prefabs. Future Unity tutorials can continue with animation, sound, enemies, richer levels, improved game state, physics-driven movement, and preparing a game for release."),
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
                            Video("/vid/Unity.4.Tryinspector.mp4", "Using the Inspector to change the Player's Transform.")
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
                            Video("/vid/Unity.5.Playercontroller.mp4", "Creating the PlayerController script.")
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
                             Video("/vid/Unity.6.Inputactions.mp4", "Creating the PlayerInputActions asset.")
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
                    }),
                Step(
                    7,
                    "Detect the Collectible",
                    "detect-the-collectible",
                    "Configure 2D physics components and detect when the Player enters the Collectible's trigger.",
                    new Block
                    {
                        Title = "Visual Shape and Physics Shape",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("The Player and Collectible already have visible shapes because their <b>Sprite Renderer</b> components draw sprites. A Sprite Renderer affects appearance only. The physics system does not use the visible pixels as a collision boundary."),
                            Text("A <b>Collider 2D</b> gives a 2D GameObject an invisible physics shape. Unity uses that shape to determine whether it overlaps or touches another 2D collider. The shape is shown as an outline in the Scene view when the object is selected, but it is not drawn in the finished game."),
                            Text("Unity provides several 2D collider shapes. A <b>Box Collider 2D</b> is efficient and suits rectangular objects such as the Player. A <b>Circle Collider 2D</b> suits the circular Collectible. Other options include Capsule, Polygon, Edge, and Tilemap colliders. Choose the simplest shape that reasonably fits the object."),
                            Text("The words <b>2D</b> matter. Collider 2D and Rigidbody 2D belong to Unity's 2D physics system. The similarly named Collider and Rigidbody components belong to the separate 3D physics system. A 2D collider does not interact with a 3D collider.")
                        }
                    },
                    new Block
                    {
                        Title = "Add Colliders",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Stop Play mode. Select Player, click <b>Add Component</b>, and add a <b>Box Collider 2D</b>. Select Collectible and add a <b>Circle Collider 2D</b>. Unity may already have added appropriate colliders when the sprites were created; if so, use the existing components instead of adding duplicates."),
                            Text("Check each collider's green outline in the Scene view. Its <b>Size</b> or <b>Radius</b> determines the dimensions of the physics shape, while <b>Offset</b> moves that shape relative to the GameObject's Transform. For these simple sprites, the default fit should be suitable."),
                            Text("With two ordinary colliders, Unity treats contact as a physical collision: the shapes are intended to block one another. A collectible needs different behaviour. The Player should be able to enter its area so the game can detect the overlap and collect it.")
                        }
                    },
                    new Block
                    {
                        Title = "Make the Collectible a Trigger",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("On the Collectible's Collider 2D component, enable <b>Is Trigger</b>. A trigger still detects overlaps, but it does not produce a physical collision response. In other words, Unity reports that something entered the area without using that collider to push or stop the object."),
                            Text("This is ideal for collectibles, checkpoints, interaction zones, doors, and other invisible regions. A wall normally uses a non-trigger collider because it should block movement; a coin normally uses a trigger because the player should pass into it."),
                            Text("Only the Collectible collider should be a trigger for this setup. The Player's collider defines its shape, while the Collectible's trigger defines the detection area.")
                        }
                    },
                    new Block
                    {
                        Title = "Add Rigidbody 2D to the Player",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Select Player and add a <b>Rigidbody 2D</b>. A collider defines an object's shape, but a Rigidbody 2D registers the object as a body controlled or tracked by the 2D physics simulation. For trigger callbacks between two Collider 2D components, at least one of the participating GameObjects needs a Rigidbody 2D."),
                            Text("A Rigidbody 2D stores physics properties such as body type, mass, velocity, linear damping, angular damping, gravity scale, and constraints. It also lets Unity track the moving Player and send physics messages such as <code class='inline-code'>OnTriggerEnter2D</code>."),
                            Text("The three body types serve different purposes:<br>🔹 <b>Dynamic</b> bodies respond to forces, gravity, collisions, and velocity.<br>🔹 <b>Kinematic</b> bodies are moved deliberately by game code and do not respond to forces in the same way.<br>🔹 <b>Static</b> bodies are intended not to move, such as floors and walls."),
                            Text("Keep the Player as <b>Dynamic</b> for this lesson and set <b>Gravity Scale</b> to <code class='inline-code'>0</code>. Unity's default 2D gravity pulls Dynamic bodies down along the Y axis. That is useful in a side-view platform game, but this is a top-down game: down on the screen is a movement direction, not falling toward the ground. A gravity scale of zero prevents the Player from drifting downward when no key is pressed."),
                            Text("Gravity Scale multiplies the global 2D gravity for this one body. A value of 1 applies normal gravity, 2 applies twice as much, and 0 applies none. It does not disable collisions or trigger detection."),
                            Text("PlayerController currently changes <code class='inline-code'>transform.position</code> in Update. That is enough for this first trigger test, as you have seen in the Console, but it moves the Transform directly instead of asking the Rigidbody 2D to move. Physics-heavy movement is normally performed through the Rigidbody 2D during <code class='inline-code'>FixedUpdate()</code>. We will keep the current movement focused and refactor it when the course introduces physics-driven movement."),
                            Text("Under <b>Constraints</b>, freeze rotation on the Z axis if the Player turns after touching other colliders. In a simple top-down game, the square usually should remain upright.")
                        }
                    },
                    new Block
                    {
                        Title = "Detect the Trigger in PlayerController",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Open <code class='inline-code'>PlayerController.cs</code> and add this method inside the PlayerController class, but outside its other methods:"),
                            Code("private void OnTriggerEnter2D(Collider2D other)\r\n{\r\n    Debug.Log(\"Something entered the trigger!\");\r\n}"),
                            Text("<code class='inline-code'>OnTriggerEnter2D</code> is another Unity message method. Unity calls it automatically on the frame when this object's Collider 2D first enters a trigger Collider 2D. You do not call it from <code class='inline-code'>Update()</code>."),
                            Text("The method must have the recognised name and signature. <code class='inline-code'>private</code> means other classes do not call it directly. <code class='inline-code'>void</code> means it returns no value. The <code class='inline-code'>2D</code> suffix tells you that it belongs to the 2D physics system."),
                            Text("Unity supplies the <code class='inline-code'>Collider2D other</code> parameter when it calls the method. <code class='inline-code'>other</code> refers to the other collider involved in the overlap—in this case, the Collectible's collider. Later, you can inspect <code class='inline-code'>other.gameObject</code>, compare its tag, read one of its components, or destroy that specific collectible."),
                            Text("<code class='inline-code'>Debug.Log(...)</code> writes a message to Unity's Console. It is a temporary observation tool that proves the callback occurred; it does not collect or remove anything yet.")
                        }
                    },
                    new Block
                    {
                        Title = "Test the Trigger Message",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Save the script and return to Unity. Wait for compilation to finish and confirm that the Console has no red errors. Enter Play mode and move the Player into the Collectible."),
                            Text("The Console should print <code class='inline-code'>Something entered the trigger!</code> once when the colliders begin overlapping. Remaining inside does not repeatedly call OnTriggerEnter2D. Leaving and entering again creates a new entry and prints another message."),
                            Text("Unity also provides <code class='inline-code'>OnTriggerStay2D</code>, which runs repeatedly while the overlap continues, and <code class='inline-code'>OnTriggerExit2D</code>, which runs when the colliders stop overlapping. Entry is the correct event for a collectible because collection should normally happen once."),
                            Text("If nothing prints, confirm that both objects have Collider 2D components, Collectible has Is Trigger enabled, Player has a Rigidbody 2D, PlayerController is attached to Player, the script compiled, and you used the 2D versions of every component and callback."),
                            Video("/vid/Unity.9.Colliders.mp4", "Adding 2D colliders and a Rigidbody 2D, then detecting the Collectible trigger.")
                        }
                    }),
                Step(
                    8,
                    "Collect and Destroy Objects",
                    "collect-and-destroy-objects",
                    "Identify Collectibles with a tag and remove them when the Player enters their trigger.",
                    new Block
                    {
                        Title = "Create and Assign the Collectible Tag",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("The callback currently responds to anything that enters the trigger. As the game grows, the Player might overlap enemies, doors, checkpoints, or other trigger zones. Before destroying an object, the script needs a reliable way to confirm that it really is a collectible."),
                            Text("A <b>tag</b> is a short label assigned to a GameObject. Select Collectible in the Hierarchy. At the top of the Inspector, open the <b>Tag</b> menu, choose <b>Add Tag...</b>, add a tag named <code class='inline-code'>Collectible</code>, then return to the Collectible GameObject and assign that tag to it."),
                            Text("Creating a tag does not automatically assign it. Confirm that the Collectible's Tag field now displays <b>Collectible</b>. Tag names are case-sensitive, so the Inspector and code must use exactly the same spelling and capitalisation."),
                            Text("The GameObject's name and tag serve different purposes. Its name helps people identify it in the Hierarchy; its tag gives scripts a category they can check. Several differently named objects can share the Collectible tag.")
                        }
                    },
                    new Block
                    {
                        Title = "Destroy the Collectible",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Replace the temporary logging callback with this version:"),
                            Code("private void OnTriggerEnter2D(Collider2D other)\r\n{\r\n    if (other.CompareTag(\"Collectible\"))\r\n    {\r\n        Destroy(other.gameObject);\r\n    }\r\n}"),
                            Text("<code class='inline-code'>other</code> is the Collider 2D on the object that entered the trigger overlap with the Player. Calling <code class='inline-code'>other.CompareTag(\"Collectible\")</code> asks whether the GameObject carrying that collider has the Collectible tag."),
                            Text("<code class='inline-code'>CompareTag</code> is Unity's purpose-built tag check. It clearly expresses the intention and validates the tag name. If the other object has a different tag, the condition is false and the body of the <code class='inline-code'>if</code> statement is skipped."),
                            Text("<code class='inline-code'>other.gameObject</code> retrieves the GameObject to which the other collider belongs. This is important: destroying <code class='inline-code'>gameObject</code> without <code class='inline-code'>other.</code> would refer to the PlayerController's own GameObject and destroy the Player instead."),
                            Text("<code class='inline-code'>Destroy(other.gameObject)</code> tells Unity to remove that Collectible GameObject. Destroy is processed safely by Unity after the current event-processing step, rather than removing the object halfway through the callback."),
                            Text("Because Destroy receives the complete GameObject, its Transform, Sprite Renderer, Collider 2D, and any other attached components are removed together. The scene asset itself is not deleted, and the Collectible returns when you stop and restart Play mode because Play mode changes are temporary.")
                        }
                    },
                    new Block
                    {
                        Title = "Test Collecting the Object",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Save PlayerController, return to Unity, and wait for it to compile. Enter Play mode and move the Player into the Collectible. The Collectible should disappear as soon as the colliders overlap."),
                            Text("If it does not disappear, confirm that the tag was both created and assigned, its spelling is exactly <code class='inline-code'>Collectible</code>, the Collectible owns the collider received as <code class='inline-code'>other</code>, and the earlier trigger test worked."),
                            Text("This condition makes the callback safe around other triggers: only GameObjects tagged Collectible are destroyed. Other tagged or untagged trigger objects are ignored."),
                            Video("/vid/Unity.10.Destroy.mp4", "Assigning the Collectible tag and destroying the collected GameObject.")
                        }
                    }),
                Step(
                    9,
                    "Add Multiple Collectibles and a Score",
                    "add-multiple-collectibles-and-a-score",
                    "Duplicate Collectibles and keep track of how many the Player collects.",
                    new Block
                    {
                        Title = "Create Multiple Collectibles",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Stop Play mode. Select Collectible in the Hierarchy and duplicate it several times. You can use <b>Ctrl+D</b> on Windows and Linux or <b>Cmd+D</b> on macOS. Move each copy to a different position using its Transform."),
                            Text("Duplicating the GameObject copies all of its components and settings. Each duplicate keeps its Sprite Renderer, Circle Collider 2D, Is Trigger setting, and Collectible tag. This is faster and less error-prone than rebuilding every collectible from scratch."),
                            Text("Unity gives the copies names such as Collectible (1), Collectible (2), or similar. Their names do not affect the collection code because PlayerController checks their shared <b>Collectible tag</b>, not their individual names."),
                            Text("Place the objects far enough apart that the Player can enter each trigger separately. The scene should now contain several independently collectable objects."),
                            Picture("c9-c11-multiple-collectibles.png", "Several Collectible GameObjects placed around the Player.")
                        }
                    },
                    new Block
                    {
                        Title = "Store the Score",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("PlayerController needs a field that survives between trigger callbacks. Add this field inside the PlayerController class, near the existing <code class='inline-code'>inputActions</code> field:"),
                            Code("private int score;"),
                            Text("<code class='inline-code'>int</code> stores a whole number. <code class='inline-code'>score</code> is a field rather than a local variable, so the same value remains available for as long as this PlayerController instance exists."),
                            Text("C# initializes an instance <code class='inline-code'>int</code> field to <code class='inline-code'>0</code> automatically. Writing <code class='inline-code'>private int score = 0;</code> would also be valid, but the explicit assignment is not required."),
                            Text("The field is private because only PlayerController currently needs to change it. The score will reset to zero whenever Play mode starts again because Unity creates a fresh runtime instance of the component.")
                        }
                    },
                    new Block
                    {
                        Title = "Increase and Print the Score",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Update <code class='inline-code'>OnTriggerEnter2D</code> so a successful collection increments the score before destroying the object:"),
                            Code("private void OnTriggerEnter2D(Collider2D other)\r\n{\r\n    if (other.CompareTag(\"Collectible\"))\r\n    {\r\n        score++;\r\n        Debug.Log($\"Score: {score}\");\r\n        Destroy(other.gameObject);\r\n    }\r\n}"),
                            Text("<code class='inline-code'>score++</code> is the increment operator. It adds one to the current value and stores the result back in the score field. The first collectible changes the score from 0 to 1, the second changes it from 1 to 2, and so on."),
                            Text("<code class='inline-code'>$\"Score: {score}\"</code> is an interpolated string. The leading <code class='inline-code'>$</code> allows the value inside braces to be inserted into the text. If score is 2, the resulting Console message is <code class='inline-code'>Score: 2</code>."),
                            Text("All three statements are inside the tag check, so unrelated trigger objects do not increase the score. The order is also intentional: increment the stored value, print the new value, and then destroy the collected GameObject.")
                        }
                    },
                    new Block
                    {
                        Title = "Collect and Verify",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Save PlayerController and return to Unity. After compilation finishes, enter Play mode and collect the objects one at a time. Each object should disappear and the Console should display the next score."),
                            Text("The screenshot shows <code class='inline-code'>Score: 1</code> followed by <code class='inline-code'>Score: 2</code>, confirming that the field retained its value between separate calls to OnTriggerEnter2D."),
                            Picture("c9-c11-score.png", "The Console displaying the score after collecting two objects."),
                            Text("If every message says Score: 1, make sure score is a field declared at class level. Declaring <code class='inline-code'>int score = 0;</code> inside OnTriggerEnter2D would create and reset a new local variable every time the callback runs."),
                            Text("The score currently appears only in the developer Console. A later chapter can display it to the player with a user-interface text element.")
                        }
                    }),
                Step(
                    10,
                    "Display the Score with TextMeshPro",
                    "display-the-score-with-textmeshpro",
                    "Create a Canvas and keep a TextMeshPro score display synchronized with PlayerController.",
                    new Block
                    {
                        Title = "Create a Canvas",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Stop Play mode. In the Hierarchy, create <b>UI &gt; Canvas</b>. A Canvas is the root container Unity uses to lay out and render user-interface elements such as text, images, buttons, health bars, and menus."),
                            Text("World sprites use positions in the game scene. Canvas children use a <b>Rect Transform</b>, which adds width, height, anchors, and a pivot for UI layout. Anchors describe where a UI element should remain when the Game view changes size."),
                            Text("For this simple score, keep the Canvas in its default <b>Screen Space - Overlay</b> render mode. Overlay UI is drawn over the game and does not need a camera reference. Unity may also create an EventSystem; that object handles input for interactive UI controls and can remain in the scene.")
                        }
                    },
                    new Block
                    {
                        Title = "Add TextMeshPro UI Text",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Right-click the Canvas in the Hierarchy and create <b>UI &gt; Text - TextMeshPro</b>. If Unity asks you to import TMP Essentials, choose <b>Import TMP Essentials</b>. These resources contain the default font assets and settings TextMeshPro needs."),
                            Text("TextMeshPro, usually shortened to <b>TMP</b>, is Unity's modern text-rendering system. <code class='inline-code'>TextMeshProUGUI</code> is the component used for text inside a Canvas; it is different from a world-space TextMeshPro component."),
                            Text("Rename the new GameObject <code class='inline-code'>ScoreText</code>. In its TextMeshPro component, set the initial text to <code class='inline-code'>Score: 0</code>. Use its Rect Transform to position it somewhere easy to read, such as near the upper-left corner."),
                            Text("The Inspector value gives you an immediate preview, but PlayerController will become the source of truth at runtime. This prevents the displayed text and the numeric score from drifting apart.")
                        }
                    },
                    new Block
                    {
                        Title = "Reference TextMeshPro from PlayerController",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Add the TextMeshPro namespace at the top of <code class='inline-code'>PlayerController.cs</code>:"),
                            Code("using TMPro;"),
                            Text("A namespace groups related types. The using directive lets the script refer to <code class='inline-code'>TextMeshProUGUI</code> without writing its full namespace every time."),
                            Text("Add this field inside PlayerController, near the score field:"),
                            Code("[SerializeField]\r\nprivate TextMeshProUGUI scoreText;"),
                            Text("<code class='inline-code'>TextMeshProUGUI</code> is the type of the component the script needs to update. The <code class='inline-code'>scoreText</code> field will hold a reference to the specific ScoreText component in this scene."),
                            Text("The field remains <code class='inline-code'>private</code>, so other scripts cannot freely replace it. <code class='inline-code'>[SerializeField]</code> tells Unity to serialize the private field and show it in the Inspector. This combines encapsulation in C# with scene configuration in Unity.")
                        }
                    },
                    new Block
                    {
                        Title = "Assign the Inspector Reference",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Save the script and return to Unity. After it compiles, select Player. The Player Controller component now contains a <b>Score Text</b> field."),
                            Text("Drag the ScoreText GameObject from the Hierarchy into that field. Unity stores a reference to its TextMeshProUGUI component. You can also click the small object-picker circle and select ScoreText."),
                            Text("Declaring a serialized field does not make Unity discover the correct text automatically. The assignment connects this particular PlayerController to this particular UI component. If the field displays <b>None (TextMeshProUGUI)</b>, the reference has not been assigned.")
                        }
                    },
                    new Block
                    {
                        Title = "Create UpdateScoreText",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Add a method that converts the numeric score into the text the player sees:"),
                            Code("private void UpdateScoreText()\r\n{\r\n    scoreText.text = $\"Score: {score}\";\r\n}"),
                            Text("<code class='inline-code'>scoreText.text</code> is the TextMeshPro component's displayed string. Assigning a new value changes the UI. The interpolated string inserts the current score after the label."),
                            Text("Keeping this operation in a named method avoids duplicating the formatting expression. Whenever the score needs to appear on screen, PlayerController can call <code class='inline-code'>UpdateScoreText()</code>.")
                        }
                    },
                    new Block
                    {
                        Title = "Initialize and Refresh the Display",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Add <code class='inline-code'>Start()</code> and call the method once when the scene begins:"),
                            Code("private void Start()\r\n{\r\n    UpdateScoreText();\r\n}"),
                            Text("<code class='inline-code'>Awake()</code> runs first and creates the input-actions object. <code class='inline-code'>OnEnable()</code> then enables the component's actions. <code class='inline-code'>Start()</code> runs before the first Update, after the object has been enabled. It is a suitable place to display the initial score of zero."),
                            Text("In <code class='inline-code'>OnTriggerEnter2D</code>, replace the Console log with a UI refresh immediately after incrementing the score:"),
                            Code("private void OnTriggerEnter2D(Collider2D other)\r\n{\r\n    if (other.CompareTag(\"Collectible\"))\r\n    {\r\n        score++;\r\n        UpdateScoreText();\r\n        Destroy(other.gameObject);\r\n    }\r\n}"),
                            Text("The order keeps the UI accurate: first change the number, then display the new number, and finally remove the collected object.")
                        }
                    },
                    new Block
                    {
                        Title = "Complete PlayerController",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("The complete script should now look like this:"),
                            Code("using TMPro;\r\nusing UnityEngine;\r\n\r\npublic class PlayerController : MonoBehaviour\r\n{\r\n    private PlayerInputActions inputActions;\r\n    private int score;\r\n\r\n    [SerializeField]\r\n    private TextMeshProUGUI scoreText;\r\n\r\n    private void Start()\r\n    {\r\n        UpdateScoreText();\r\n    }\r\n\r\n    private void Update()\r\n    {\r\n        Vector2 movement = inputActions.Player.Move.ReadValue<Vector2>();\r\n\r\n        transform.position += new Vector3(movement.x, movement.y, 0) * 5f * Time.deltaTime;\r\n    }\r\n\r\n    private void Awake()\r\n    {\r\n        inputActions = new PlayerInputActions();\r\n    }\r\n\r\n    private void OnEnable()\r\n    {\r\n        inputActions.Enable();\r\n    }\r\n\r\n    private void OnDisable()\r\n    {\r\n        inputActions.Disable();\r\n    }\r\n\r\n    private void OnTriggerEnter2D(Collider2D other)\r\n    {\r\n        if (other.CompareTag(\"Collectible\"))\r\n        {\r\n            score++;\r\n            UpdateScoreText();\r\n            Destroy(other.gameObject);\r\n        }\r\n    }\r\n\r\n    private void UpdateScoreText()\r\n    {\r\n        scoreText.text = $\"Score: {score}\";\r\n    }\r\n}"),
                            Text("Calling <code class='inline-code'>inputActions.Enable()</code> enables every action map in this input-actions asset. Earlier, the course enabled only <code class='inline-code'>inputActions.Player</code>. Both work in this project because it currently has only the Player map; enabling the individual map is more selective if additional maps are added later.")
                        }
                    },
                    new Block
                    {
                        Title = "Play and Troubleshoot",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Enter Play mode. The Canvas should initially display <code class='inline-code'>Score: 0</code>. Each collected object should disappear and immediately increase the on-screen number."),
                            Text("If Unity reports a <code class='inline-code'>NullReferenceException</code> on <code class='inline-code'>scoreText.text</code>, select Player and assign ScoreText to the serialized Score Text field. The script has a variable, but it cannot use a scene component until that reference points to an object."),
                            Text("If the text exists but is not visible, check that ScoreText is a child of Canvas, the GameObject is active, its font size and colour are visible, its Rect Transform is on screen, and the Canvas is enabled."),
                            Text("The Console is still useful for developers, but the Canvas turns the internal score into information the person playing the game can see."),
                            Video("/vid/Unity.11.Score.mp4", "Creating a TextMeshPro score display and updating it when Collectibles are collected.")
                        }
                    }),
                Step(
                    11,
                    "Display a Win Panel",
                    "display-a-win-panel",
                    "Create a victory panel and show it after the Player collects all five Collectibles.",
                    new Block
                    {
                        Title = "Define the Win Condition",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("The game now has an activity—collecting objects—but it does not have an ending. A <b>win condition</b> is a rule that changes the game from its playing state to a won state."),
                            Text("This scene contains five Collectibles, so the rule is straightforward: the player wins when score reaches 5. The score already records progress, which means the same field can determine when to reveal a victory message."),
                            Text("Movement and input continue after winning for now. This chapter focuses only on recognising success and presenting immediate feedback.")
                        }
                    },
                    new Block
                    {
                        Title = "Create the Win Panel",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Stop Play mode. Right-click Canvas in the Hierarchy and create <b>UI &gt; Panel</b>. Rename the new GameObject <code class='inline-code'>WinPanel</code>."),
                            Text("A Panel is a UI GameObject with a Rect Transform and an Image component. It provides a background behind related controls and text. Keep it full-screen or resize it into a centred message box."),
                            Text("Choose a background colour and alpha that make the message readable while still allowing some of the game to remain visible. Alpha controls transparency."),
                            Text("Right-click WinPanel and create <b>UI &gt; Text - TextMeshPro</b>. Rename the child <code class='inline-code'>WinText</code>, set its text to <code class='inline-code'>You Win!</code>, increase its font size, and centre it inside the panel."),
                            Text("The hierarchy should contain Canvas with ScoreText and WinPanel beneath it, and WinText beneath WinPanel.")
                        }
                    },
                    new Block
                    {
                        Title = "Hide the Panel at the Start",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Select WinPanel and clear the active checkbox beside its name at the top of the Inspector. The panel and its WinText child should disappear from the Game view."),
                            Text("A disabled GameObject remains part of the scene, but Unity does not render it or run its attached behaviours. Its children also become inactive through the hierarchy."),
                            Text("Leave the panel disabled when you save the scene. The current Start method initializes the score text but does not hide WinPanel from code.")
                        }
                    },
                    new Block
                    {
                        Title = "Reference the Panel from PlayerController",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Add this field inside PlayerController, beneath the existing scoreText field:"),
                            Code("[SerializeField]\r\nprivate GameObject winPanel;"),
                            Text("The field uses <code class='inline-code'>GameObject</code> because the script needs to activate the entire panel rather than change one text property. <code class='inline-code'>[SerializeField]</code> keeps it private while exposing an assignment slot in Unity's Inspector."),
                            Text("Save the script and return to Unity. Select Player, then drag WinPanel from the Hierarchy into the <b>Win Panel</b> field on Player Controller."),
                            Text("Assign the WinPanel parent, not only its WinText child. Activating the parent reveals the background and every UI element beneath it.")
                        }
                    },
                    new Block
                    {
                        Title = "Show the Panel After Five Collectibles",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Extend OnTriggerEnter2D with a win check after destroying the collected object:"),
                            Code("private void OnTriggerEnter2D(Collider2D other)\r\n{\r\n    if (other.CompareTag(\"Collectible\"))\r\n    {\r\n        score++;\r\n        UpdateScoreText();\r\n        Destroy(other.gameObject);\r\n\r\n        if (score >= 5)\r\n        {\r\n            winPanel.SetActive(true);\r\n        }\r\n    }\r\n}"),
                            Text("The condition runs only after a correctly tagged Collectible increases the score. When the fifth Collectible is collected, score becomes 5 and SetActive activates the hidden WinPanel."),
                            Text("Using <code class='inline-code'>&gt;=</code> instead of <code class='inline-code'>==</code> is defensive: the condition remains true if a later version awards multiple points at once.")
                        }
                    },
                    new Block
                    {
                        Title = "Complete PlayerController",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("The complete script should now match this version:"),
                            Code("using TMPro;\r\nusing UnityEngine;\r\n\r\npublic class PlayerController : MonoBehaviour\r\n{\r\n    private PlayerInputActions inputActions;\r\n    private int score;\r\n\r\n    [SerializeField]\r\n    private TextMeshProUGUI scoreText;\r\n\r\n    [SerializeField]\r\n    private GameObject winPanel;\r\n\r\n    private void Start()\r\n    {\r\n        UpdateScoreText();\r\n    }\r\n\r\n    private void Update()\r\n    {\r\n        Vector2 movement = inputActions.Player.Move.ReadValue<Vector2>();\r\n\r\n        transform.position += new Vector3(movement.x, movement.y, 0) * 5f * Time.deltaTime;\r\n    }\r\n\r\n    private void Awake()\r\n    {\r\n        inputActions = new PlayerInputActions();\r\n    }\r\n\r\n    private void OnEnable()\r\n    {\r\n        inputActions.Enable();\r\n    }\r\n\r\n    private void OnDisable()\r\n    {\r\n        inputActions.Disable();\r\n    }\r\n\r\n    private void OnTriggerEnter2D(Collider2D other)\r\n    {\r\n        if (other.CompareTag(\"Collectible\"))\r\n        {\r\n            score++;\r\n            UpdateScoreText();\r\n            Destroy(other.gameObject);\r\n\r\n            if (score >= 5)\r\n            {\r\n                winPanel.SetActive(true);\r\n            }\r\n        }\r\n    }\r\n\r\n    private void UpdateScoreText()\r\n    {\r\n        scoreText.text = $\"Score: {score}\";\r\n    }\r\n}"),
                            Text("This version deliberately has no timer, restart button, SceneManager import, gameWon field, or movement lock.")
                        }
                    },
                    new Block
                    {
                        Title = "Test the Win Panel",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Enter Play mode. Score should begin at 0 and WinPanel should be hidden. Collect four objects and confirm the panel remains hidden while the score reaches 4."),
                            Text("Collect the fifth object. The score should change to 5, the last Collectible should disappear, and WinPanel should become visible with the You Win message."),
                            Text("If WinPanel appears immediately, stop Play mode and disable it in the Inspector before saving the scene. If it never appears, confirm that all five objects use the Collectible tag and WinPanel is assigned on PlayerController."),
                            Text("If Unity reports a NullReferenceException on SetActive, drag the WinPanel GameObject—not only WinText—into the Player Inspector."),
                            Text("Restarting is introduced in the next chapter. Locking movement after winning and timing attempts are useful extensions for a future tutorial."),
                            Video("/vid/Unity.12.WinPanel.mp4", "Creating and displaying the win panel.")
                        },
                    }),
                Step(
                    12,
                    "Add and Connect a Restart Button",
                    "add-and-connect-a-restart-button",
                    "Create a TextMeshPro button, reload the active scene with SceneManager, and connect the click event.",
                    new Block
                    {
                        Title = "Create the Button",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Stop Play mode. In the Hierarchy, right-click <code class='inline-code'>WinPanel</code> and select <b>UI &gt; Button - TextMeshPro</b>. Unity creates a Button GameObject as a child of the panel and adds a TextMeshPro label beneath it."),
                            Text("Rename the new Button GameObject <code class='inline-code'>RestartButton</code>. Clear names make the hierarchy easier to read and will help you find the correct object when the button's behaviour is configured later."),
                            Text("Because RestartButton is a child of WinPanel, it follows the panel's active state. It is hidden while WinPanel is disabled and becomes visible automatically when the fifth Collectible activates the panel.")
                        }
                    },
                    new Block
                    {
                        Title = "Change the Button Label",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Expand RestartButton in the Hierarchy. Select its child, normally named <code class='inline-code'>Text (TMP)</code> or <code class='inline-code'>Text</code>."),
                            Text("In the child's TextMeshProUGUI component, change the displayed text to <code class='inline-code'>Restart</code>. The parent owns the clickable Button component; the child renders the label the player sees."),
                            Text("You can adjust the font size, colour, and alignment, but keep the label centred and easy to read.")
                        }
                    },
                    new Block
                    {
                        Title = "Position the Button",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Select RestartButton and use its Rect Transform to place it below the You Win message. Resize it if necessary so the label has comfortable spacing."),
                            Text("The hierarchy should now look like this:<br><code class='inline-code'>Canvas</code><br>├── <code class='inline-code'>ScoreText</code><br>└── <code class='inline-code'>WinPanel</code><br>&nbsp;&nbsp;&nbsp;&nbsp;├── <code class='inline-code'>WinText</code><br>&nbsp;&nbsp;&nbsp;&nbsp;└── <code class='inline-code'>RestartButton</code><br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;└── <code class='inline-code'>Text (TMP)</code>"),
                            Text("The button is only visual at this point. Clicking it does nothing until the next section creates a restart method and connects the Button's On Click event.")
                        }
                    },
                    new Block
                    {
                        Title = "Check the Layout",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Temporarily enable WinPanel in the Inspector to preview the complete message and button. Confirm that the objects do not overlap and both remain inside the panel."),
                            Text("Disable WinPanel again before saving the scene. The next sections will make RestartButton reload the game.")
                        }
                    },
                    new Block
                    {
                        Title = "What Scene Management Does",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("A Unity <b>scene</b> contains the GameObjects and component state that make up a level or screen. Restarting this game means loading a fresh copy of the current scene."),
                            Text("Unity's <code class='inline-code'>SceneManager</code> provides methods for loading scenes and inspecting the scene that is currently active. Reloading MainScene recreates the Player, Collectibles, score, and UI from their saved starting values.")
                        }
                    },
                    new Block
                    {
                        Title = "Import SceneManager",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("At the top of <code class='inline-code'>PlayerController.cs</code>, add the Scene Management namespace alongside the existing using directives:"),
                            Code("using UnityEngine.SceneManagement;"),
                            Text("SceneManager does not live directly in the UnityEngine namespace. Importing <code class='inline-code'>UnityEngine.SceneManagement</code> makes the SceneManager and Scene types available by their short names.")
                        }
                    },
                    new Block
                    {
                        Title = "Create RestartGame",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Add this method inside PlayerController:"),
                            Code("public void RestartGame()\r\n{\r\n    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);\r\n}"),
                            Text("<code class='inline-code'>SceneManager.GetActiveScene()</code> returns the scene that is currently running."),
                            Text("<code class='inline-code'>.buildIndex</code> reads that scene's numeric position in the project's build scene list."),
                            Text("<code class='inline-code'>SceneManager.LoadScene(...)</code> loads the scene at that index. Loading it again creates a fresh runtime copy, so the Player returns to its starting position, the Collectibles return, score becomes zero, and WinPanel is hidden again."),
                            Text("The method is <code class='inline-code'>public</code> because Unity's Button Inspector must be able to list and invoke it. It returns <code class='inline-code'>void</code> because the click event does not need a result.")
                        }
                    },
                    new Block
                    {
                        Title = "Include MainScene in the Build Profile",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Save MainScene. In Unity 6, open <b>File &gt; Build Profiles</b> and confirm MainScene is included in the active profile's Scene List. Depending on the editor layout, you may see an option such as <b>Add Open Scenes</b>."),
                            Text("The build index comes from this ordered list. If the scene is not included, its build index is not available for reliable reloading and LoadScene can report an error.")
                        }
                    },
                    new Block
                    {
                        Title = "Add an On Click Event",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Select RestartButton in the Hierarchy. In the Inspector, find its <b>Button</b> component and scroll to the <b>On Click ()</b> section."),
                            Text("Click the <b>+</b> button. Unity adds an event entry containing an object field and a function menu. This entry describes which component should receive the click and which method it should run."),
                            Text("Drag the Player GameObject from the Hierarchy into the empty object field. If drag-and-drop is unavailable, click the small object-picker circle and select Player.")
                        }
                    },
                    new Block
                    {
                        Title = "Choose RestartGame",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Open the <b>No Function</b> dropdown in the event entry. Select <b>PlayerController &gt; RestartGame ()</b>."),
                            Text("The Button now stores a reference to PlayerController and the selected public method. When the player clicks, Unity invokes RestartGame without requiring extra button-handling code."),
                            Text("This is an example of a UnityEvent configured through the Inspector. It lets designers connect UI interactions to compatible public methods without hard-coding a reference to the Button inside PlayerController.")
                        }
                    },
                    new Block
                    {
                        Title = "Complete Script Addition",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("The only C# additions in this chapter are the namespace import and restart method:"),
                            Code("using UnityEngine.SceneManagement;\r\n\r\n// Inside PlayerController:\r\npublic void RestartGame()\r\n{\r\n    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);\r\n}"),
                            Text("Keep <code class='inline-code'>using TMPro;</code> and <code class='inline-code'>using UnityEngine;</code> in the file as well. The rest of PlayerController remains unchanged from the win-panel chapter.")
                        }
                    },
                    new Block
                    {
                        Title = "Test the Complete Game",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Press Play and collect all five Collectibles. WinPanel should appear with You Win and the Restart button."),
                            Text("Click Restart. MainScene should reload: the Player returns to its original position, all Collectibles reappear, ScoreText returns to Score: 0, and WinPanel is hidden."),
                            Text("If clicking does nothing, confirm that the On Click entry references Player—not RestartButton—and that PlayerController &gt; RestartGame is selected. If LoadScene reports an invalid build index, add MainScene to the active Build Profile."),
                            Text("<b>Congratulations!</b> You have completed your first Unity game. It now has input, movement, collectibles, scoring, a win condition, player-facing UI, and a restartable game loop."),
                            Video("/vid/Unity.13.Restart.mp4", "Creating the Restart button, reloading the active scene, and connecting the Button's On Click event.")
                        }
                    }),
                Step(
                    13,
                    "Import Grass and Farmer Assets",
                    "import-grass-and-farmer-assets",
                    "Import static 2D artwork, create a grass background, and replace the Player's square sprite with a farmer.",
                    new Block
                    {
                        Title = "Choose and Download Your Own Sprites",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("We are intentionally not providing the grass, farmer, or apple sprites for this project. Choosing the artwork yourself gives you a chance to make the game feel like your own instead of producing an exact visual copy of the tutorial."),
                            Text("Look specifically for <b>2D sprites</b> made for a <b>top-down game</b>. Do not download 3D models, materials, or first-person and side-view character art for this project. A useful starter set includes a grass or ground image, one top-down character, and an apple or another small collectible."),
                            Text("These are popular places to find game artwork:<br>🔹 <a href='https://itch.io/game-assets/tag-2d' target='_blank'>itch.io 2D Game Assets</a> — free and paid asset packs with filters for sprites, pixel art, top-down games, formats, and licences.<br>🔹 <a href='https://opengameart.org/' target='_blank'>OpenGameArt</a> — community-created 2D artwork published under a range of open licences.<br>🔹 <a href='https://kenney.nl/assets' target='_blank'>Kenney Assets</a> — consistent game-asset packs that are especially useful for prototypes and learning projects.<br>🔹 <a href='https://assetstore.unity.com/2d' target='_blank'>Unity Asset Store: 2D</a> — free and paid 2D packages that can be imported into Unity projects."),
                            Text("For this tutorial, the easiest files to use are separate <code class='inline-code'>.png</code> images with transparent backgrounds. A sprite sheet can contain several characters or animation frames in one image and requires slicing, which is outside this course. Choose individual static sprites where possible."),
                            Text("<b>Always read the licence on the exact asset page before downloading.</b> Check whether commercial use, modification, redistribution, and attribution are allowed. Save the licence or a link to it with your project, and credit the artist in your README when required."),
                            Text("Try to choose sprites that belong to the same pack or have a similar pixel size, perspective, and art style. They do not need to match the tutorial video. Your farmer could be another character, and your apple could be any collectible, provided the object still uses the Collectible tag and the same gameplay setup.")
                        }
                    },
                    new Block
                    {
                        Title = "What an Asset Is",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("An <b>asset</b> is a file used to build the game. Sprites, textures, audio clips, fonts, materials, animation clips, scenes, and scripts are all assets. Unity displays project assets in the Project window and stores them inside the project's Assets folder."),
                            Text("This chapter uses static 2D artwork only. Do not create animations or import 3D models. A grass image and one farmer sprite are enough to improve the scene while keeping the lesson focused on importing and arranging assets."),
                            Text("Before using downloaded artwork, check its licence. Confirm that your intended use is allowed and preserve any attribution or licence file the artist requires. Do not assume that an image is free to redistribute simply because it can be downloaded.")
                        }
                    },
                    new Block
                    {
                        Title = "Organize the Assets Folder",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Stop Play mode. In the Project window, create a folder named <code class='inline-code'>Art</code> inside Assets. Inside Art, create a folder named <code class='inline-code'>Sprites</code>."),
                            Text("The resulting structure can look like:<br><code class='inline-code'>Assets</code><br>├── <code class='inline-code'>Art</code><br>│&nbsp;&nbsp;&nbsp;└── <code class='inline-code'>Sprites</code><br>├── <code class='inline-code'>Input Actions</code><br>└── <code class='inline-code'>Scripts</code>"),
                            Text("Folders do not change how the game runs, but clear organisation becomes essential as the number of assets grows.")
                        }
                    },
                    new Block
                    {
                        Title = "Import the Grass and Farmer",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Drag the grass image and farmer image into <code class='inline-code'>Assets/Art/Sprites</code> in the Project window. You can also copy the files into that folder outside Unity and return to the editor so Unity imports them."),
                            Text("Select each imported image. In the Inspector, set <b>Texture Type</b> to <b>Sprite (2D and UI)</b> if Unity did not choose it automatically, then click <b>Apply</b>. This makes the image available to Sprite Renderer components."),
                            Text("For pixel art, use <b>Filter Mode: Point (no filter)</b> to preserve sharp edges. For smooth painted artwork, the default bilinear filtering may be more appropriate. Pixels Per Unit controls how large the sprite appears in world units; keep related artwork consistent."),
                            Text("If the source file is a sprite sheet containing multiple images, it would need Sprite Mode Multiple and slicing. That workflow belongs with animation and is intentionally outside this chapter. Use one already-separated sprite here.")
                        }
                    },
                    new Block
                    {
                        Title = "Create the Grass Background",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Drag the grass sprite from the Project window into the Scene. Rename the new GameObject <code class='inline-code'>Grass</code> and position it at the centre of the play area."),
                            Text("Scale the Grass object until it covers the camera's visible area. If the image is designed as a tile, duplicating adjacent grass objects is acceptable for this first scene; a Tilemap can be introduced in a later course."),
                            Text("In Grass's Sprite Renderer, set <b>Order in Layer</b> to a value lower than the Player and Collectibles, such as <code class='inline-code'>-10</code>. Unity draws lower-order sprites behind higher-order sprites."),
                            Text("Grass is visual scenery, so it does not need a Rigidbody 2D or Collider 2D in this project.")
                        }
                    },
                    new Block
                    {
                        Title = "Replace the Player Square",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Select Player in the Hierarchy. In its Sprite Renderer component, drag the farmer sprite into the <b>Sprite</b> property."),
                            Text("Changing the Sprite property replaces only the image. PlayerController, Rigidbody 2D, Box Collider 2D, input configuration, and UI references remain attached to the same Player GameObject."),
                            Text("Adjust the Player's Transform scale until the farmer fits the scene. Inspect the Box Collider 2D outline and change its Size or Offset so it reasonably covers the farmer's body."),
                            Text("Keep the farmer as one static pose. Sprite sheets, slicing, Animation Clips, Animator Controllers, and walking animations are intentionally deferred to a later course.")
                        }
                    },
                    new Block
                    {
                        Title = "Test the New Artwork",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Save the scene and enter Play mode. Confirm that the farmer appears in front of the grass, responds to W, A, S, and D, and can still collect every placeholder Collectible."),
                            Text("If the farmer appears behind the grass, give the Player's Sprite Renderer a higher Order in Layer or lower Grass's value. If collision detection behaves strangely, recheck the Player's collider after changing the sprite."),
                            Text("The game now has a visual environment and character without introducing animation."),
                            Video("/vid/Unity.14.GrassAndFarmer.mp4", "Importing static grass and farmer sprites, building the background, and replacing the Player square.")
                        }
                    }),
                Step(
                    14,
                    "Create an Apple Collectible Prefab",
                    "create-an-apple-collectible-prefab",
                    "Import an apple sprite, update the Collectible, and create reusable prefab instances.",
                    new Block
                    {
                        Title = "Import the Apple Sprite",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Stop Play mode. Drag the apple image into <code class='inline-code'>Assets/Art/Sprites</code>. Select it and confirm <b>Texture Type: Sprite (2D and UI)</b>, then apply any changes."),
                            Text("Use the same Pixels Per Unit and filtering approach as the farmer and grass where appropriate so the art feels visually consistent.")
                        }
                    },
                    new Block
                    {
                        Title = "Replace the Collectible Artwork",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Select one existing Collectible in the Hierarchy. Drag the apple sprite into its Sprite Renderer's <b>Sprite</b> property."),
                            Text("The GameObject keeps its Collectible tag, Circle Collider 2D, and Is Trigger setting. Only its rendered image changes."),
                            Text("Adjust its Transform scale and inspect the Circle Collider 2D. Change the Radius or Offset if the trigger area no longer fits the apple."),
                            Text("Enter Play mode briefly and verify that the apple still disappears and increases the score, then stop Play mode.")
                        }
                    },
                    new Block
                    {
                        Title = "Why Use a Prefab",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("The five Collectibles currently repeat the same setup. Rebuilding or independently editing each copy invites inconsistencies: one might lose its tag, use a different collider size, or have Is Trigger disabled."),
                            Text("A <b>prefab</b> is a reusable GameObject template stored as an asset. It can contain a hierarchy of child objects, components, serialized values, tags, and other configuration. Scene objects created from it are called <b>prefab instances</b>."),
                            Text("A prefab is not C# inheritance and it is not an animation. It is Unity's way to save a configured object and create consistent copies of it.")
                        }
                    },
                    new Block
                    {
                        Title = "Create the Collectible Prefab",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Make sure the selected Collectible is fully configured before turning it into a prefab. Confirm that it has the desired sprite, the <b>Collectible</b> tag, a Collider 2D with <b>Is Trigger</b> enabled, and an appropriate scale."),
                            Text("Drag the Collectible GameObject from the Hierarchy into the <code class='inline-code'>Assets/Prefabs</code> folder in the Project window. Rename the new asset <code class='inline-code'>Collectible</code> if necessary."),
                            Text("Unity changes the scene object's icon and name colour to indicate that it is now linked to a prefab asset. The asset in the Project window is the reusable template; the object in the Hierarchy is one instance of that template."),
                            Text("Do not drag only the sprite asset into Prefabs. Drag the configured GameObject from the Hierarchy so the prefab includes its Sprite Renderer, tag, collider, and trigger settings.")
                        }
                    },
                    new Block
                    {
                        Title = "Replace the Other Collectibles",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Delete the other independently duplicated Collectible GameObjects from the scene, leaving the prefab-linked instance. Do not delete the Collectible prefab asset from the Project window."),
                            Text("Drag the Collectible prefab from <code class='inline-code'>Assets/Prefabs</code> into the Scene or Hierarchy four times. Move the instances into the desired positions so the scene again contains five Collectibles."),
                            Text("Each instance begins with the same sprite, tag, collider, and trigger configuration. Position is allowed to differ per instance because every Collectible needs its own location."),
                            Text("Check the Hierarchy and count the instances. The win condition currently expects five collections, so accidentally placing four or six objects would make the hard-coded score threshold inconsistent with the scene.")
                        }
                    },
                    new Block
                    {
                        Title = "Prefab Overrides and Applying Changes",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("When you change a property on one prefab instance, Unity records that difference as an <b>override</b>. Different Transform positions are expected overrides in this scene."),
                            Text("If a change should affect every Collectible—such as a better sprite, colour, or collider size—edit the prefab asset in Prefab Mode, or change an instance and use the Inspector's <b>Overrides</b> menu to apply the appropriate change to the prefab."),
                            Text("Applying an override changes the shared prefab asset and can update every linked instance. Reverting an override restores the value from the prefab. Review overrides carefully so you do not accidentally apply a scene-specific position to every instance.")
                        }
                    },
                    new Block
                    {
                        Title = "Test the Prefab Instances",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Save the scene and enter Play mode. Collect every prefab instance. Each should increase the score and disappear exactly as the earlier circle objects did."),
                            Text("After the fifth instance is collected, WinPanel should appear. Use RestartButton and confirm that reloading the scene restores all five prefab instances."),
                            Text("If one object cannot be collected, compare its tag and Collider 2D with the prefab. If all objects fail, inspect the prefab asset itself and confirm that Is Trigger and the Collectible tag are configured."),
                            Text("The game now uses apple artwork and a reusable Collectible template while deliberately leaving animation for a later course."),
                            Video("/vid/Unity.15.ApplePrefab.mp4", "Importing the apple sprite and creating reusable Collectible prefab instances.")
                        }
                    }),
                Step(
                    15,
                    "Congratulations and Next Challenges",
                    "congratulations-and-next-challenges",
                    "Celebrate your first completed Unity game and practise your new skills with five independent challenges.",
                    new Block
                    {
                        Title = "Congratulations!",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("<b>Congratulations—you have completed your first Unity game!</b> You created a scene, moved a player with input, detected trigger collisions, collected objects, displayed a score, recognised a win, restarted the game, imported artwork, and created a reusable prefab."),
                            Text("That is a lot of ground to cover. More importantly, you now have a small working game that you can change and make your own. The best way to make these ideas stick is to experiment without following exact instructions.")
                        }
                    },
                    new Block
                    {
                        Title = "Five Challenges to Try by Yourself",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Try the following challenges independently. Make a backup or commit your working project first, tackle one change at a time, and test after every small step. It is completely normal to search Unity's documentation, reread earlier chapters, and make mistakes."),
                            Text("<b>1. Change the winning score.</b> Add more or fewer apple prefab instances and update the game so WinPanel appears only after every apple has been collected."),
                            Text("<b>2. Customise the interface.</b> Change the fonts, colours, sizes, and positions of ScoreText, WinText, and RestartButton while keeping everything readable."),
                            Text("<b>3. Create a second collectible.</b> Duplicate the apple prefab, give the new collectible different artwork or a different colour, and place a few instances around the scene. Make sure the Player can still collect them."),
                            Text("<b>4. Change the player's speed.</b> Find the movement speed in PlayerController, try several values, and choose one that feels comfortable rather than simply making the player as fast as possible."),
                            Text("<b>5. Design your own level.</b> Reposition the Player and collectibles, adjust the grass layout, and create a scene that feels different while preserving the complete collect-score-win-restart loop."),
                            Text("These challenges intentionally do not include solutions. Work through each problem slowly, read Console errors carefully, and compare your changes with the last working version whenever something breaks.")
                        }
                    },
                    new Block
                    {
                        Title = "This Is Only the Beginning",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("We will add another Unity tutorial soon. This course is only the beginning of The C# Academy's Unity curriculum, and future tutorials will build on these foundations with more game-development concepts."),
                            Text("In the meantime, keep experimenting with this project. Small changes are real practice, and every feature you add will make the next Unity project easier to understand.")
                        }
                    },
                    new Block
                    {
                        Title = "Submit Your Game for Review",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Your Unity game uses C#, so you can submit it to The C# Academy as a <a href='https://thecsharpacademy.com/project/100001/free-style' target='_blank'>Freestyle Project</a>. A review gives you feedback on your code and project presentation, and an approved submission awards Academy experience points."),
                            Text("Freestyle Projects can award <b>10 to 200 XP</b> based on creativity, complexity, and quality. You can submit more than one Freestyle Project, so this first Unity game does not need to be your last."),
                            Text("Before submitting, place the project in a public repository and add a clear README. Explain what the game does, which version of Unity it uses, how to open and play it, which controls it uses, what you learned, and where the sprites came from. Include screenshots or a short gameplay recording and any attribution required by the asset licences."),
                            Text("You are welcome to submit the tutorial result as it is, but completing some of the independent challenges will make the project more personal and give reviewers more of your own decisions to discuss.")
                        }
                    },
                    new Block
                    {
                        Title = "Help Us Improve",
                        Paragraphs = new List<Paragraph>
                        {
                            Text("Please tell us what you thought of the course. Let us know what was clear, what was confusing, what felt too easy or too difficult, and what you would like to learn next in the <a href='https://discord.com/invite/aDMDET8ywB' target='_blank'>feedback channel on our Discord server</a>. Your feedback helps us improve this course and plan the next Unity tutorials."),
                            Text("If you enjoyed the course and The C# Academy, please consider making a <a href='/contribute'>donation on our contribution page</a>. Your support helps us keep the Academy free and create more learning material."),
                            Text("Thank you for completing the course. Keep building, keep experimenting, and we will see you in the next Unity tutorial!")
                        }
                    })
            }
        };
    }

}
