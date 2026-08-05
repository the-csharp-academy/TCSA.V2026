using TCSA.V2026.Data.Models;
using static TCSA.V2026.Data.Curriculum.ArticleHelper;
using static TCSA.V2026.Helpers.CourseContentHelper;

namespace TCSA.V2026.Data.Curriculum;

public static class UnityCSharpCourse
{
    public static Course GetUnityCSharpCourse()
    {
        return new Course
        {
            Id = 11,
            Level = CourseLevel.Beginner,
            Theme = CourseTheme.Unity,
            Title = "C# for Unity: Extend Your 2D Game",
            Description = "Continue the top-down collector game while learning practical C# through cleaner components, varied collectibles, collections, interfaces, events, ScriptableObjects, and simple game states.",
            ImgUrl = "icons8-games-folder-100.png",
            Articles =
            [
                new Article
                {
                    Id = 500450,
                    CourseDisplayId = 1,
                    Title = "About This Course",
                    Slug = "about-csharp-for-unity-extend-your-2d-game",
                    Description = "See how this course continues your first Unity game and what you will build while learning practical C#.",
                    Area = Area.Course,
                    ExperiencePoints = 1,
                    Blocks =
                    [
                        new Block
                        {
                            Paragraphs =
                            [
                                Text("Welcome to <b>C# for Unity: Extend Your 2D Game</b>. In the first course, you built a complete top-down collector game in Unity. A farmer moves around a scene, collects apples, increases a score, wins after collecting every apple, and can restart the game."),
                                Text("This course continues from that finished project. You will not discard your work or begin another game from an empty scene. Instead, you will improve the game one small feature at a time while learning C# concepts that become useful as a Unity project grows."),
                                Text("The purpose is not to transform the collector game into a large commercial game. It is to help you move from <i>making a small game work</i> to <i>writing C# that makes the game easier to understand and extend</i>.")
                            ]
                        },
                        new Block
                        {
                            Title = "What You Will Build",
                            Paragraphs =
                            [
                                Text("You will expand the original collector game into a more flexible version with several kinds of collectibles, better-organised scripts, collection tracking, UI and audio that react to gameplay events, reusable item data, simple playing and pause states, a timed mode, and a high score."),
                                Text("Every chapter will make a visible change to the same game. When you learn a new C# concept, you will immediately use it to solve a real problem rather than study it in isolation."),
                                Text(RedDotList(
                                    "Refactor the original scripts into smaller, focused components.",
                                    "Add coins and bonus items through a shared collectible design.",
                                    "Use <code class='inline-code'>List&lt;T&gt;</code> to track what the player collects.",
                                    "Introduce a small interface so different objects can be collected consistently.",
                                    "Use events to update UI and play audio without connecting every script directly.",
                                    "Define reusable item settings with ScriptableObjects.",
                                    "Represent the game's Playing, Won, and Paused states.",
                                    "Finish with a timed mode, bonus collectibles, a high score, and extra polish."))
                            ]
                        },
                        new Block
                        {
                            Title = "A Gentle Next Step",
                            Paragraphs =
                            [
                                Text("This is still a beginner course. Each concept will be introduced only when the game gives us a reason to use it. We will begin by cleaning up code you already recognise, then add one new idea at a time."),
                                Text("You do not need to understand software architecture before starting. We will discuss responsibilities and communication between components in plain language, using the Player, collectibles, score, UI, and audio systems you already know."),
                                Text("Some useful game-development topics are deliberately saved for later courses. We will not add enemy AI, complex state machines, generic object pools, multiplayer, or a large saving system here. Keeping the scope small gives you time to understand the C# behind every improvement.")
                            ]
                        },
                        new Block
                        {
                            Title = "What You Need Before Starting",
                            Paragraphs =
                            [
                                Text("Complete <a href='/course/10/article/1/500400/false'>Build Your First 2D Unity Game</a> before beginning this course. The instructions assume you have its completed <code class='inline-code'>CollectorGame</code> project, including player movement, apple prefabs, score UI, a win panel, and scene restarting."),
                                Text("You should also be comfortable with basic C# classes, fields, methods, conditions, and variables. We will revisit concepts when we use them, but this course focuses on applying C# inside Unity rather than teaching the language from the beginning."),
                                Text("Use the same Unity 6 project and editor version you used for the first course. You do not need to find new artwork or install additional Unity packages before starting.")
                            ]
                        },
                        new Block
                        {
                            Title = "Starting Project Repository",
                            CssClass = "article-ads-help-block",
                            Paragraphs =
                            [
                                Text("The completed game from the first course is available in the <a href='https://github.com/TheCSharpAcademy/TCSA.UnityCourse.Collector' target='_blank'>TCSA.UnityCourse.Collector GitHub repository</a>. If you no longer have your original project, clone or download this repository and use it as the starting point for this course. You can also keep it open as a reference while continuing with your own version.")
                            ]
                        },
                        new Block
                        {
                            Title = "Protect Your Finished Game",
                            Paragraphs =
                            [
                                Text("Before changing the project, create a safe copy of the completed first-course version. If you use Git, commit the working game and create a new branch for this course. Otherwise, close Unity and duplicate the entire project folder."),
                                Text("Open the copy and play the game once before making changes. Confirm that the player moves, all apples can be collected, the score updates, the win panel appears, and restart works. A known working starting point makes every later problem easier to diagnose.")
                            ]
                        },
                        new Block
                        {
                            Title = "How the Course Will Work",
                            Paragraphs =
                            [
                                Text("Each chapter begins with a limitation in the current game. We will describe the problem, introduce the smallest C# concept that helps, apply it to the project, and test the result in Play mode."),
                                Text("Do not rush through the code. Type the examples, read Unity's Console, test after small changes, and experiment with values. The goal is to understand why the improved design is easier to change, not merely to reach the final screenshot."),
                                Text("By the end, you will still recognise the simple collector game you created in the first courseâ€”but its C# will support more behaviours, more content, and your own future ideas.")
                            ]
                        }
                    ]
                },
                new Article
                {
                    Id = 500451,
                    CourseDisplayId = 2,
                    Title = "Review and Prepare the Existing Game",
                    Slug = "review-and-prepare-the-existing-unity-game",
                    Description = "Open and verify the collector game, examine the responsibilities in PlayerController, and complete a small behaviour-preserving refactor.",
                    Area = Area.Course,
                    ExperiencePoints = 1,
                    Blocks =
                    [
                        new Block
                        {
                            Paragraphs =
                            [
                                Text("Before adding new collectibles or C# features, we need to understand the game we already have. In this chapter, you will verify the completed project, inspect <code class='inline-code'>PlayerController</code>, and make one small improvement without changing how the game plays."),
                                Text("This kind of change is called <b>refactoring</b>. Refactoring improves the internal structure of working code while preserving its observable behaviour. The player should move, collect apples, score, win, and restart in exactly the same way before and after our change.")
                            ]
                        },
                        new Block
                        {
                            Title = "Choose Your Starting Project",
                            Paragraphs =
                            [
                                Text("If you completed the first course on this computer, continue with your own finished <code class='inline-code'>CollectorGame</code> project. Your version may contain personal changes, and that is completely fine."),
                                Text("If you need a clean starting point, use the <a href='https://github.com/TheCSharpAcademy/TCSA.UnityCourse.Collector' target='_blank'>completed collector game on GitHub</a>. Clone the repository with Git, or download it and extract it to a folder where you keep development projects."),
                                Text("When cloning, make sure Git LFS downloads the image and font files. If the sprites appear as tiny text pointer files or are missing in Unity, install <a href='https://git-lfs.com/' target='_blank'>Git LFS</a>, then run <code class='inline-code'>git lfs pull</code> inside the repository.")
                            ]
                        },
                        new Block
                        {
                            Title = "Open the Project and Main Scene",
                            Paragraphs =
                            [
                                Text("Open Unity Hub, select <b>Add</b> or <b>Add project from disk</b>, and choose the folder that contains the project's <code class='inline-code'>Assets</code>, <code class='inline-code'>Packages</code>, and <code class='inline-code'>ProjectSettings</code> folders. Open it with the Unity editor version recorded by the project."),
                                Text("In Unity's Project panel, open <code class='inline-code'>Assets/Scenes/MainScene.unity</code>. Check the top of the Hierarchy: it must say <b>MainScene</b>. Selecting a scene asset once only highlights it; double-click it to open it."),
                                Text("Open <b>File &gt; Build Profiles &gt; Scene List</b>. Confirm that MainScene is present and enabled. If it is missing, keep MainScene open and select <b>Add Open Scenes</b>, or drag the MainScene asset from the Project panel into the list. This registration is required by the current restart code, which reloads the active scene by build index.")
                            ]
                        },
                        new Block
                        {
                            Title = "Verify the Working Baseline",
                            Paragraphs =
                            [
                                Text("Enter Play mode and test the complete loop before editing any code. Use W, A, S, and D to move the farmer. Collect all five apples and watch the score increase after each one. Confirm that the win panel appears after the fifth apple and that its restart button restores the scene."),
                                Text("Open <b>Window &gt; General &gt; Console</b> if the Console is not already visible. Resolve any red compile errors before continuing. Refactoring code that is already broken makes it difficult to tell whether a later change caused the problem."),
                                Text("Exit Play mode when the test is complete. Changes made to scene objects during Play mode are normally discarded, so all code and scene editing in this chapter should happen after you stop the game.")
                            ]
                        },
                        new Block
                        {
                            Title = "Protect This Version",
                            CssClass = "article-ads-help-block",
                            Paragraphs =
                            [
                                Text("Create a safe checkpoint now. If you use Git, commit the working project before changing <code class='inline-code'>PlayerController</code>. You can also create a branch for this course. If you are not using Git yet, close Unity and duplicate the complete project folder. A checkpoint lets you experiment without being afraid of losing the finished first-course game.")
                            ]
                        },
                        new Block
                        {
                            Title = "Read PlayerController as a Story",
                            Paragraphs =
                            [
                                Text("In the Project panel, open <code class='inline-code'>Assets/Scripts/PlayerController.cs</code>. Do not change anything yet. Read from the fields at the top to the methods at the bottom and try to describe what each part contributes to the game."),
                                Text(RedDotList(
                                    "<code class='inline-code'>inputActions</code> stores the generated Input System controls.",
                                    "<code class='inline-code'>score</code> stores the number of collected apples.",
                                    "<code class='inline-code'>scoreText</code> and <code class='inline-code'>winPanel</code> reference UI objects from the scene.",
                                    "<code class='inline-code'>Awake</code>, <code class='inline-code'>OnEnable</code>, and <code class='inline-code'>OnDisable</code> create and control the input actions.",
                                    "<code class='inline-code'>Start</code> displays the initial score.",
                                    "<code class='inline-code'>Update</code> reads input and moves the player every frame.",
                                    "<code class='inline-code'>OnTriggerEnter2D</code> recognises collectibles, changes the score, destroys the collected object, and checks for a win.",
                                    "<code class='inline-code'>UpdateScoreText</code> displays the current score.",
                                    "<code class='inline-code'>RestartGame</code> reloads the scene."))
                            ]
                        },
                        new Block
                        {
                            Title = "One Script, Several Responsibilities",
                            Paragraphs =
                            [
                                Text("The script works, but it has accumulated several <b>responsibilities</b>: input, movement, collection detection, score data, UI, winning, and restarting. A responsibility is simply a job the code performs."),
                                Text("A small script can perform several jobs without immediately causing trouble. The problem appears when we add features. A bonus collectible might change the score differently; a timed mode might affect winning; audio might react to collection; and pausing must stop movement. If all of those changes keep entering the same class, it becomes harder to read and easier to break."),
                                Text("We will not split everything today. Large refactors are difficult to understand and test. Instead, we will begin with the smallest useful improvement: give player movement its own clearly named method.")
                            ]
                        },
                        new Block
                        {
                            Title = "Extract Player Movement",
                            Paragraphs =
                            [
                                Text("Find the current <code class='inline-code'>Update</code> method. It reads the movement input and changes the Player's position:"),
                                Code("private void Update()\r\n{\r\n    Vector2 movement = inputActions.Player.Move.ReadValue<Vector2>();\r\n\r\n    transform.position += new Vector3(movement.x, movement.y, 0) * 5f * Time.deltaTime;\r\n}"),
                                Text("Create a new private method named <code class='inline-code'>MovePlayer</code>. Move the two statements from Update into it, then call that method from Update:"),
                                Code("private void Update()\r\n{\r\n    MovePlayer();\r\n}\r\n\r\nprivate void MovePlayer()\r\n{\r\n    Vector2 movement = inputActions.Player.Move.ReadValue<Vector2>();\r\n\r\n    transform.position += new Vector3(movement.x, movement.y, 0) * 5f * Time.deltaTime;\r\n}"),
                                Text("Save the script and return to Unity. Wait for Unity to finish compiling. The Console should contain no red errors before you enter Play mode.")
                            ]
                        },
                        new Block
                        {
                            Title = "Why Keep Update?",
                            Paragraphs =
                            [
                                Text("Unity calls <code class='inline-code'>Update</code> automatically once per rendered frame while the component is enabled. Unity does not automatically call our new <code class='inline-code'>MovePlayer</code> method. Update remains the Unity entry point and delegates the movement job to the method we named."),
                                Text("The amount of code has not decreased, and the game has no new feature. The improvement is clarity: Update now reads like a short list of actions performed each frame. Later, pausing the game or adding other per-frame behaviour will be easier to see and organise."),
                                Text("Keeping <code class='inline-code'>MovePlayer</code> private communicates that it is an internal detail of PlayerController. No other component needs to command this method directly.")
                            ]
                        },
                        new Block
                        {
                            Title = "Test the Refactor",
                            Paragraphs =
                            [
                                Text("Enter Play mode and repeat the baseline test. Movement should feel identical. Collect all five apples, confirm the score and win panel, then restart the scene. A successful refactor changes the code structure without changing this behaviour."),
                                Text("If the player does not move, check that Update contains <code class='inline-code'>MovePlayer();</code>, that the new method is inside the PlayerController class, and that you moved both movement statements into it. Read the first red Console error before making further changes."),
                                Text("Once the game passes the same test as before, save your work and create another Git commit or backup. You now have a clean, verified foundation for the next chapter.")
                            ]
                        },
                        new Block
                        {
                            Title = "Chapter Checkpoint",
                            CssClass = ExerciseBlockClass,
                            Paragraphs =
                            [
                                Text("Before marking this chapter complete, confirm that:"),
                                Text(ExerciseList(
                                    "MainScene opens and is enabled in the Build Profiles scene list.",
                                    "The original collect-score-win-restart loop works without Console errors.",
                                    "You created a Git commit, branch, or backup of the working starting project.",
                                    "You can name the main responsibilities currently handled by PlayerController.",
                                    "Update calls a private MovePlayer method.",
                                    "The game behaves exactly as it did before the refactor."))
                            ]
                        },
                        new Block
                        {
                            Title = "Next Step",
                            Paragraphs =
                            [
                                Text("We have made movement easier to find, but PlayerController still owns collection, scoring, UI, and winning. In the next chapter, we will make another small separation so the project is ready to support more than one kind of collectible.")
                            ]
                        }
                    ]
                },
                new Article
                {
                    Id = 500452,
                    CourseDisplayId = 3,
                    Title = "Separate Player Movement",
                    Slug = "separate-player-movement-into-a-unity-component",
                    Description = "Move input and movement into a focused PlayerMovement component while preserving the collector game's behaviour.",
                    Area = Area.Course,
                    ExperiencePoints = 1,
                    Blocks =
                    [
                        new Block
                        {
                            Paragraphs =
                            [
                                Text("In the previous chapter, we extracted movement into a clearly named method. That made <code class='inline-code'>PlayerController</code> easier to read, but the class still handles movement alongside collecting, scoring, UI, winning, and restarting."),
                                Text("Now we will take one gentle step further: move all input and movement code into a separate <code class='inline-code'>PlayerMovement</code> component. The Player GameObject will use both components, and the game will continue to behave exactly as it did before.")
                            ]
                        },
                        new Block
                        {
                            Title = "GameObjects Are Built from Components",
                            Paragraphs =
                            [
                                Text("Unity encourages <b>composition</b>: a GameObject gains capabilities from the components attached to it. The Player already combines a Transform, a Sprite Renderer, a Collider 2D, and your PlayerController script. Each component contributes a different part of the final object."),
                                Text("Our C# scripts are components too because they inherit from <code class='inline-code'>MonoBehaviour</code>. A GameObject can have several script components, so one script does not need to own every behaviour associated with the player."),
                                Text("After this chapter, <code class='inline-code'>PlayerMovement</code> will own input and movement. <code class='inline-code'>PlayerController</code> will temporarily retain collection, score, UI, winning, and restart behaviour. We will improve those responsibilities gradually in later chapters.")
                            ]
                        },
                        new Block
                        {
                            Title = "Create the PlayerMovement Script",
                            Paragraphs =
                            [
                                Text("In the Project panel, open the <code class='inline-code'>Assets/Scripts</code> folder. Right-click an empty area and select <b>Create &gt; Scripting &gt; MonoBehaviour Script</b>. Name the new script <code class='inline-code'>PlayerMovement</code>. The filename and class name must match exactly."),
                                Text("Open PlayerMovement.cs and replace the generated contents with this starting structure:"),
                                Code("using UnityEngine;\r\n\r\npublic class PlayerMovement : MonoBehaviour\r\n{\r\n}\r\n"),
                                Text("Save the file and let Unity compile. Do not attach it to the Player yet; first we will transfer the complete movement behaviour into it.")
                            ]
                        },
                        new Block
                        {
                            Title = "Move the Input Field",
                            Paragraphs =
                            [
                                Text("Open PlayerController and find the <code class='inline-code'>inputActions</code> field. Cut this field from PlayerController and paste it inside the PlayerMovement class:"),
                                Code("private PlayerInputActions inputActions;"),
                                Text("A field belongs to the class that needs the data. Once PlayerController no longer reads input, keeping the input actions there would make the relationship misleading. PlayerMovement will create, enable, read, and disable them.")
                            ]
                        },
                        new Block
                        {
                            Title = "Move the Input Lifecycle Methods",
                            Paragraphs =
                            [
                                Text("Cut <code class='inline-code'>Awake</code>, <code class='inline-code'>OnEnable</code>, and <code class='inline-code'>OnDisable</code> from PlayerController and paste them into PlayerMovement:"),
                                Code("private void Awake()\r\n{\r\n    inputActions = new PlayerInputActions();\r\n}\r\n\r\nprivate void OnEnable()\r\n{\r\n    inputActions.Enable();\r\n}\r\n\r\nprivate void OnDisable()\r\n{\r\n    inputActions.Disable();\r\n}"),
                                Text("These methods form one small lifecycle. Awake creates the input-actions object, OnEnable starts listening for input, and OnDisable stops listening. Moving all three together prevents one component from creating input that another component must manage.")
                            ]
                        },
                        new Block
                        {
                            Title = "Move Update and MovePlayer",
                            Paragraphs =
                            [
                                Text("Cut the <code class='inline-code'>Update</code> and <code class='inline-code'>MovePlayer</code> methods from PlayerController and paste them into PlayerMovement. PlayerMovement should now contain the entire input-and-movement behaviour:"),
                                Code("using UnityEngine;\r\n\r\npublic class PlayerMovement : MonoBehaviour\r\n{\r\n    private PlayerInputActions inputActions;\r\n\r\n    private void Awake()\r\n    {\r\n        inputActions = new PlayerInputActions();\r\n    }\r\n\r\n    private void OnEnable()\r\n    {\r\n        inputActions.Enable();\r\n    }\r\n\r\n    private void OnDisable()\r\n    {\r\n        inputActions.Disable();\r\n    }\r\n\r\n    private void Update()\r\n    {\r\n        MovePlayer();\r\n    }\r\n\r\n    private void MovePlayer()\r\n    {\r\n        Vector2 movement = inputActions.Player.Move.ReadValue<Vector2>();\r\n\r\n        transform.position += new Vector3(movement.x, movement.y, 0) * 5f * Time.deltaTime;\r\n    }\r\n}\r\n"),
                                Text("Save both scripts. PlayerController should no longer contain <code class='inline-code'>inputActions</code>, Awake, OnEnable, OnDisable, Update, or MovePlayer. If either script has a red underline, check that every method is inside the correct class braces.")
                            ]
                        },
                        new Block
                        {
                            Title = "Check the Remaining PlayerController",
                            Paragraphs =
                            [
                                Text("After removing movement, PlayerController should still contain the score and UI fields plus Start, RestartGame, OnTriggerEnter2D, and UpdateScoreText. Compare your script with this version:"),
                                Code("using TMPro;\r\nusing UnityEngine;\r\nusing UnityEngine.SceneManagement;\r\n\r\npublic class PlayerController : MonoBehaviour\r\n{\r\n    private int score;\r\n\r\n    [SerializeField]\r\n    private TextMeshProUGUI scoreText;\r\n\r\n    [SerializeField]\r\n    private GameObject winPanel;\r\n\r\n    private void Start()\r\n    {\r\n        UpdateScoreText();\r\n    }\r\n\r\n    public void RestartGame()\r\n    {\r\n        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);\r\n    }\r\n\r\n    private void OnTriggerEnter2D(Collider2D other)\r\n    {\r\n        if (other.CompareTag(\"Collectible\"))\r\n        {\r\n            score++;\r\n            UpdateScoreText();\r\n            Destroy(other.gameObject);\r\n\r\n            if (score >= 5)\r\n            {\r\n                winPanel.SetActive(true);\r\n            }\r\n        }\r\n    }\r\n\r\n    private void UpdateScoreText()\r\n    {\r\n        scoreText.text = $\"Score: {score}\";\r\n    }\r\n}\r\n"),
                                Text("The existing Score Text and Win Panel assignments remain on PlayerController in the Inspector. Moving methods out of the script does not remove these serialized fields, so you should not need to assign those references again.")
                            ]
                        },
                        new Block
                        {
                            Title = "Attach PlayerMovement to the Player",
                            CssClass = "article-ads-help-block",
                            Paragraphs =
                            [
                                Text("Creating a script asset does not make it run. Select the <b>Player</b> GameObject in the Hierarchy, choose <b>Add Component</b> in the Inspector, search for <b>Player Movement</b>, and add it. The Player should now have both Player Controller and Player Movement script components.")
                            ]
                        },
                        new Block
                        {
                            Title = "Test Each Responsibility",
                            Paragraphs =
                            [
                                Text("Wait for Unity to finish compiling and confirm that the Console has no red errors. Enter Play mode and test the full game. PlayerMovement should move the farmer, while PlayerController should still collect apples, update the score, display the win panel, and restart the scene."),
                                Text("You can see the separation directly. Exit Play mode, disable only the Player Movement component using its Inspector checkbox, and play again. The farmer should stop moving while PlayerController remains attached. Re-enable Player Movement after this experiment."),
                                Text("If the farmer does not move, first confirm that Player Movement is attached and enabled. If Unity reports that <code class='inline-code'>inputActions</code> does not exist, check that the field and all input lifecycle methods were moved into the new class.")
                            ]
                        },
                        new Block
                        {
                            Title = "Expose the Movement Speed",
                            Paragraphs =
                            [
                                Text("The movement calculation still contains the unexplained number <code class='inline-code'>5f</code>. Values written directly inside an expression are often called <b>magic numbers</b> because their meaning is not obvious from the number alone."),
                                Text("Add a serialized field near the top of PlayerMovement:"),
                                Code("[SerializeField]\r\nprivate float moveSpeed = 5f;"),
                                Text("Then replace <code class='inline-code'>5f</code> in MovePlayer with <code class='inline-code'>moveSpeed</code>:"),
                                Code("transform.position += new Vector3(movement.x, movement.y, 0) * moveSpeed * Time.deltaTime;"),
                                Text("Save the script and return to Unity. The Player Movement component now displays a <b>Move Speed</b> field. Try values such as 2, 5, and 8 in Play mode, then return it to a value that feels comfortable. The field remains private to other C# classes while SerializeField makes it configurable in the Inspector.")
                            ]
                        },
                        new Block
                        {
                            Title = "What Improved?",
                            Paragraphs =
                            [
                                Text("The Player GameObject still has the same overall capabilities, but they are now composed from two script components. PlayerMovement can change without placing input details among score and UI code. PlayerController can evolve without risking the movement loop."),
                                Text("This does not mean every method deserves its own component. Useful components group behaviour and data that change for the same reason. Input actions, movement speed, and movement calculations naturally belong together, so PlayerMovement has a clear purpose."),
                                Text("The name PlayerController is becoming less accurate now that it no longer controls movement. We will avoid renaming it mid-refactor and continue shrinking its responsibilities safely. Later, its remaining jobs can move into names that describe them more precisely.")
                            ]
                        },
                        new Block
                        {
                            Title = "Chapter Checkpoint",
                            CssClass = ExerciseBlockClass,
                            Paragraphs =
                            [
                                Text("Before marking this chapter complete, confirm that:"),
                                Text(ExerciseList(
                                    "PlayerMovement.cs exists inside Assets/Scripts.",
                                    "PlayerMovement owns the input field, input lifecycle, Update, and MovePlayer.",
                                    "PlayerController no longer contains movement or input code.",
                                    "Both script components are attached to the Player GameObject.",
                                    "Move Speed is visible and configurable in the Inspector.",
                                    "Movement, collection, scoring, winning, and restarting all still work.",
                                    "The Console contains no red errors."))
                            ]
                        },
                        new Block
                        {
                            Title = "Next Step",
                            Paragraphs =
                            [
                                Text("Player movement now has a focused home. In the next chapter, we will turn the single apple behaviour into a small collectible design so the game can support coins and bonus items without filling PlayerController with a separate condition for every item.")
                            ]
                        }
                    ]
                },
                new Article
                {
                    Id = 500453,
                    CourseDisplayId = 4,
                    Title = "Add Different Collectibles",
                    Slug = "add-different-unity-collectibles-with-inheritance",
                    Description = "Create a reusable Collectible component and a higher-value bonus collectible while learning base classes, inheritance, virtual members, and overrides.",
                    Area = Area.Course,
                    ExperiencePoints = 1,
                    Blocks =
                    [
                        new Block
                        {
                            Paragraphs =
                            [
                                Text("The game currently recognises every collectible through the same tag and awards exactly one point. That was enough for five identical apples, but it gives us no way to ask an object how many points it is worth."),
                                Text("In this chapter, each collectible will become a C# component with its own behaviour. Regular apples will remain worth one point, and a new banana will be worth three. We will use a base class and inheritance so PlayerController can treat both objects as collectibles without checking their names or writing a separate condition for each type.")
                            ]
                        },
                        new Block
                        {
                            Title = "The Limitation of the Tag Check",
                            Paragraphs =
                            [
                                Text("PlayerController currently begins its collision logic with this condition:"),
                                Code("if (other.CompareTag(\"Collectible\"))"),
                                Text("A tag identifies a broad category, but it does not provide collectible-specific data or methods. Once this condition succeeds, PlayerController still assumes the object is worth one point."),
                                Text("We will replace the tag-only decision with a component check. If the collided object has a Collectible componentâ€”or a component derived from Collectibleâ€”the player can safely read its point value.")
                            ]
                        },
                        new Block
                        {
                            Title = "Create the Collectible Base Class",
                            Paragraphs =
                            [
                                Text("In <code class='inline-code'>Assets/Scripts</code>, create a new MonoBehaviour script named <code class='inline-code'>Collectible</code>. Open it and replace the generated contents with:"),
                                Code("using UnityEngine;\r\n\r\npublic class Collectible : MonoBehaviour\r\n{\r\n    public virtual int Points => 1;\r\n}\r\n"),
                                Text("The <code class='inline-code'>Points</code> property describes the score value of a collectible. Code outside the class can read it, but there is no public setter that allows other scripts to replace the value."),
                                Text("The <code class='inline-code'>virtual</code> keyword allows a more specific collectible class to provide a different implementation. A normal Collectible returns 1, which preserves the behaviour of the existing apples.")
                            ]
                        },
                        new Block
                        {
                            Title = "Attach Collectible to the Apple Prefab",
                            Paragraphs =
                            [
                                Text("In the Project panel, select <code class='inline-code'>Assets/Prefabs/Collectible.prefab</code>. Open the prefab, choose <b>Add Component</b>, search for <b>Collectible</b>, and attach your new script."),
                                Text("Save the prefab and return to MainScene. Because the apples are prefab instances, they should now inherit the Collectible component from the shared prefab. Select two or three apple instances and confirm that Collectible appears in each Inspector."),
                                Text("Leave the existing Collectible tag in place for now. We will stop relying on it in code, but removing unrelated configuration during a refactor would make troubleshooting harder.")
                            ]
                        },
                        new Block
                        {
                            Title = "Read the Component During a Collision",
                            Paragraphs =
                            [
                                Text("Open PlayerController and replace the complete <code class='inline-code'>OnTriggerEnter2D</code> method with:"),
                                Code("private void OnTriggerEnter2D(Collider2D other)\r\n{\r\n    if (other.TryGetComponent(out Collectible collectible))\r\n    {\r\n        score += collectible.Points;\r\n        UpdateScoreText();\r\n        Destroy(other.gameObject);\r\n\r\n        if (score >= 5)\r\n        {\r\n            winPanel.SetActive(true);\r\n        }\r\n    }\r\n}"),
                                Text("<code class='inline-code'>TryGetComponent</code> searches the collided GameObject for the requested component. It returns true when the component exists and places the reference into the <code class='inline-code'>collectible</code> variable. Inside the block, it is safe to read <code class='inline-code'>collectible.Points</code>."),
                                Text("Notice that <code class='inline-code'>score++</code> became <code class='inline-code'>score += collectible.Points</code>. A regular apple reports 1, so the game should still behave exactly as it did before.")
                            ]
                        },
                        new Block
                        {
                            Title = "Test Before Adding a New Type",
                            CssClass = ExerciseBlockClass,
                            Paragraphs =
                            [
                                Text("Save the scripts, return to Unity, and wait for compilation. Play the game and collect all five apples. Each apple should still add one point, the win panel should appear at five, and restart should work."),
                                Text("Do not continue until this test passes. If apples no longer register, confirm that the Collectible script is attached to the prefab root containing the Collider 2D. TryGetComponent searches the same GameObject represented by <code class='inline-code'>other</code>.")
                            ]
                        },
                        new Block
                        {
                            Title = "Create a BananaCollectible Class",
                            Paragraphs =
                            [
                                Text("Create another script in <code class='inline-code'>Assets/Scripts</code> named <code class='inline-code'>BananaCollectible</code>. Replace its contents with:"),
                                Code("public class BananaCollectible : Collectible\r\n{\r\n    public override int Points => 3;\r\n}\r\n"),
                                Text("The colon means BananaCollectible <b>inherits from</b> Collectible. A BananaCollectible is a more specific kind of Collectible, so code asking for a Collectible component can also receive a BananaCollectible."),
                                Text("The <code class='inline-code'>override</code> keyword replaces the virtual Points implementation inherited from the base class. Regular apples report 1; bananas report 3. BananaCollectible does not need to inherit from MonoBehaviour directly because Collectible already does.")
                            ]
                        },
                        new Block
                        {
                            Title = "Base Type and Derived Type",
                            Paragraphs =
                            [
                                Text("Collectible is the <b>base class</b>, containing behaviour shared by the category. BananaCollectible is a <b>derived class</b>, reusing the base identity while changing one detail."),
                                Text("PlayerController deliberately declares the collision variable as the base type:"),
                                Code("Collectible collectible"),
                                Text("That lets the same block handle apples and bananas. PlayerController does not ask which fruit the object represents. It asks whether it is a Collectible, then uses the Points implementation supplied by the actual component.")
                            ]
                        },
                        new Block
                        {
                            Title = "Import a Banana Sprite",
                            Paragraphs =
                            [
                                Text("Choose a small banana image that you have permission to use and save its source for attribution. Drag the image into <code class='inline-code'>Assets/Art/Sprites</code>. Select it and confirm that <b>Texture Type</b> is <b>Sprite (2D and UI)</b>, then apply any changes."),
                                Text("Use the same Pixels Per Unit and filtering settings as the apple where appropriate. This keeps the two fruit sprites visually consistent before you adjust the prefab scale.")
                            ]
                        },
                        new Block
                        {
                            Title = "Create and Place the Banana Prefab",
                            Paragraphs =
                            [
                                Text("In the Project panel, duplicate <code class='inline-code'>Collectible.prefab</code> and name the copy <code class='inline-code'>BananaCollectible.prefab</code>. Open the duplicate in Prefab Mode."),
                                Text("The duplicate currently has a Collectible component. Remove that script component, then add <b>Banana Collectible</b>. Do not keep both scripts on the same prefab: BananaCollectible already is a Collectible through inheritance, and two matching components would make the intended point source unclear."),
                                Text("Drag the imported banana sprite into the Sprite Renderer's <b>Sprite</b> property. Adjust the Transform scale and the Collider 2D radius or offset so they fit the banana. Keep <b>Is Trigger</b> enabled, save the prefab, and leave Prefab Mode."),
                                Text("In MainScene, delete one regular apple instance and drag one BananaCollectible prefab into its place. The level should still contain five objects in total: four apples and one banana."),
                                Text("Four apples are worth four points, and the banana is worth three, so collecting everything now produces a total score of seven. The current winning score of five would allow the game to finish too early."),
                                Text("Add a serialized winning-score field to PlayerController near the other fields:"),
                                Code("[SerializeField]\r\nprivate int winningScore = 7;"),
                                Text("Then replace the hard-coded win check:"),
                                Code("if (score >= winningScore)\r\n{\r\n    winPanel.SetActive(true);\r\n}"),
                                Text("Select the Player in the Inspector and confirm that Winning Score is 7. Naming and exposing this value makes the rule clear and prevents it from being hidden inside collision code.")
                            ]
                        },
                        new Block
                        {
                            Title = "Test Both Implementations",
                            Paragraphs =
                            [
                                Text("Enter Play mode and collect an apple first. The score should increase by one. Then collect the banana; the score should increase by three. Collect every remaining fruit and confirm that the final score is seven and the win panel appears."),
                                Text("Restart and try collecting the banana at a different point in the sequence. The winning rule should depend on the score rather than the order of collection."),
                                Text("If the banana adds only one point, inspect its prefab and confirm that Banana Collectible is attached instead of Collectible. If it does nothing, confirm that the component and trigger collider are on the same GameObject.")
                            ]
                        },
                        new Block
                        {
                            Title = "When Is Inheritance Useful?",
                            Paragraphs =
                            [
                                Text("Inheritance is useful when one type genuinely <b>is a</b> more specific version of another and should be accepted wherever the base type is expected. Here, a bonus collectible is a collectible, and both expose the same Points contract."),
                                Text("Inheritance is not the answer to every variation. Creating a new subclass for every point value would eventually produce many tiny classes. Later in the course, ScriptableObjects will let us represent item data without creating a class for every configured item."),
                                Text("For now, this small example gives inheritance an immediate purpose: PlayerController handles two behaviours through one base type, without item-name checks or duplicate collision branches.")
                            ]
                        },
                        new Block
                        {
                            Title = "Chapter Checkpoint",
                            CssClass = ExerciseBlockClass,
                            Paragraphs =
                            [
                                Text("Before marking this chapter complete, confirm that:"),
                                Text(ExerciseList(
                                    "Collectible defines a virtual Points property worth 1.",
                                    "Every regular apple prefab instance has the Collectible component.",
                                    "PlayerController uses TryGetComponent instead of relying on the Collectible tag.",
                                    "BananaCollectible inherits from Collectible and overrides Points with 3.",
                                    "The banana prefab has BananaCollectible, not both collectible scripts.",
                                    "The scene contains four apples and one banana.",
                                    "Winning Score is 7.",
                                    "Apples add one, the banana adds three, and the complete loop still works."))
                            ]
                        },
                        new Block
                        {
                            Title = "Next Step",
                            Paragraphs =
                            [
                                Text("The game now supports different collectible behaviours, but it only stores one total score. In the next chapter, we will use a generic List to remember each collected item and display a small collection summary.")
                            ]
                        }
                    ]
                },
                new Article
                {
                    Id = 500454,
                    CourseDisplayId = 5,
                    Title = "Remember Collected Items with a List",
                    Slug = "remember-unity-collectibles-with-list",
                    Description = "Use List<T> and a loop to remember collected fruit and display separate apple and banana totals.",
                    Area = Area.Course,
                    ExperiencePoints = 1,
                    Blocks =
                    [
                        new Block
                        {
                            Paragraphs =
                            [
                                Text("Our game knows the current score, but it forgets how that score was earned. A score of seven does not tell us whether the player collected an apple, a banana, or some future collectible."),
                                Text("In this chapter, we will store the name of every collected item in a <code class='inline-code'>List&lt;string&gt;</code>. We will then loop through the list, count each fruit, and show a collection summary on the screen.")
                            ]
                        },
                        new Block
                        {
                            Title = "Give Each Collectible a Name",
                            Paragraphs =
                            [
                                Text("Open <code class='inline-code'>Collectible.cs</code> and add a second virtual property beneath Points:"),
                                Code("public virtual string DisplayName => \"Apple\";"),
                                Text("The base Collectible represents our regular apple, so its display name is Apple. Like Points, the property is virtual so a derived collectible can provide a different value."),
                                Text("Now open <code class='inline-code'>BananaCollectible.cs</code> and add this property beneath its Points override:"),
                                Code("public override string DisplayName => \"Banana\";"),
                                Text("PlayerController can now ask any Collectible for both its point value and its display name without checking the GameObject name or tag.")
                            ]
                        },
                        new Block
                        {
                            Title = "Create the Collection List",
                            Paragraphs =
                            [
                                Text("Open <code class='inline-code'>PlayerController.cs</code>. At the top of the file, add the collections namespace:"),
                                Code("using System.Collections.Generic;"),
                                Text("Then add this field inside PlayerController near the score field:"),
                                Code("private readonly List<string> collectedItems = new List<string>();"),
                                Text("A <code class='inline-code'>List&lt;string&gt;</code> stores an ordered group of strings. Unlike an array, a list can grow while the game is running. Each time the player collects a fruit, we will add its display name."),
                                Text("The field is <code class='inline-code'>readonly</code> because PlayerController should keep using the same list. The contents can still change: we can add items to it and clear it when restarting.")
                            ]
                        },
                        new Block
                        {
                            Title = "Remember Each Collected Fruit",
                            Paragraphs =
                            [
                                Text("Find <code class='inline-code'>OnTriggerEnter2D</code>. Inside the successful TryGetComponent block, add the collectible name before destroying the GameObject:"),
                                Code("collectedItems.Add(collectible.DisplayName);"),
                                Text("That part of the method should now look like this:"),
                                Code("if (other.TryGetComponent(out Collectible collectible))\r\n{\r\n    score += collectible.Points;\r\n    collectedItems.Add(collectible.DisplayName);\r\n\r\n    UpdateScoreText();\r\n    Destroy(other.gameObject);\r\n\r\n    if (score >= winningScore)\r\n    {\r\n        winPanel.SetActive(true);\r\n    }\r\n}"),
                                Text("We store the string rather than the Collectible component itself. The collectible GameObject is destroyed immediately afterward, but the name remains safely stored in the list.")
                            ]
                        },
                        new Block
                        {
                            Title = "Add Collection Text to the Canvas",
                            Paragraphs =
                            [
                                Text("In the Hierarchy, expand Canvas. Duplicate the existing ScoreText object and rename the copy <code class='inline-code'>CollectionText</code>. Move it below the score so the two labels do not overlap."),
                                Text("Change its temporary text to <b>Apples: 0 | Bananas: 0</b>. Keep the same font and styling as the score, but widen its Rect Transform if the text is clipped."),
                                Text("In PlayerController, add a new serialized field beside the existing UI references:"),
                                Code("[SerializeField]\r\nprivate TextMeshProUGUI collectionText;"),
                                Text("Return to Unity, select Player, and drag CollectionText from the Hierarchy into the new Collection Text field. This reference lets the script update that specific label.")
                            ]
                        },
                        new Block
                        {
                            Title = "Count the Items with a Loop",
                            Paragraphs =
                            [
                                Text("Add this method to PlayerController:"),
                                Code("private void UpdateCollectionText()\r\n{\r\n    int appleCount = 0;\r\n    int bananaCount = 0;\r\n\r\n    foreach (string item in collectedItems)\r\n    {\r\n        if (item == \"Apple\")\r\n        {\r\n            appleCount++;\r\n        }\r\n        else if (item == \"Banana\")\r\n        {\r\n            bananaCount++;\r\n        }\r\n    }\r\n\r\n    collectionText.text = $\"Apples: {appleCount} | Bananas: {bananaCount}\";\r\n}"),
                                Text("The foreach loop visits every string currently stored in the list. Each matching name increases the appropriate local counter. After the loop finishes, the UI displays the two totals."),
                                Text("This is intentionally straightforward. Later, as the game gains more item types, we can replace the string comparisons with a more scalable design.")
                            ]
                        },
                        new Block
                        {
                            Title = "Update the Display",
                            Paragraphs =
                            [
                                Text("Call the new method immediately after adding an item to the list:"),
                                Code("collectedItems.Add(collectible.DisplayName);\r\nUpdateCollectionText();"),
                                Text("Also call it once from Start, alongside the initial score update, so the label begins at zero:"),
                                Code("private void Start()\r\n{\r\n    UpdateScoreText();\r\n    UpdateCollectionText();\r\n}"),
                                Text("If your existing Start method performs other setup, keep that code and add only the UpdateCollectionText call. Do not create a second Start method.")
                            ]
                        },
                        new Block
                        {
                            Title = "Test the List",
                            CssClass = ExerciseBlockClass,
                            Paragraphs =
                            [
                                Text("Enter Play mode. The new label should initially show zero apples and zero bananas. Collect one apple and confirm that only the apple count changes. Collect the banana and confirm that the banana count changes while the score increases by three."),
                                Text("Collect the remaining fruit. The final summary should show <b>Apples: 4 | Bananas: 1</b>, the score should be seven, and the win panel should appear."),
                                Text("If collecting works but the summary does not change, check that UpdateCollectionText is called after Add. If Unity reports a NullReferenceException, select Player and confirm that CollectionText is assigned in the Inspector.")
                            ]
                        },
                        new Block
                        {
                            Title = "Chapter Checkpoint",
                            CssClass = ExerciseBlockClass,
                            Paragraphs =
                            [
                                Text("Before marking this chapter complete, confirm that:"),
                                Text(ExerciseList(
                                    "Collectible exposes Apple as its virtual DisplayName.",
                                    "BananaCollectible overrides DisplayName with Banana.",
                                    "PlayerController owns a List<string> named collectedItems.",
                                    "Each collision adds the collectible's display name before destroying it.",
                                    "CollectionText is assigned through the Inspector.",
                                    "A foreach loop counts apples and bananas.",
                                    "The display starts at zero and updates after every collection.",
                                    "The completed level shows four apples, one banana, and seven points."))
                            ]
                        },
                        new Block
                        {
                            Title = "Next Step",
                            Paragraphs =
                            [
                                Text("The list gives the game a memory of what the player collected. Next, we will use events so PlayerController can announce that the score changed without directly controlling every interested system.")
                            ]
                        }
                    ]
                },
                new Article
                {
                    Id = 500455,
                    CourseDisplayId = 6,
                    Title = "Update the UI with Events",
                    Slug = "update-unity-ui-with-csharp-events",
                    Description = "Use a C# event to let PlayerController announce collection changes and a separate GameUI component update the display.",
                    Area = Area.Course,
                    ExperiencePoints = 1,
                    Blocks =
                    [
                        new Block
                        {
                            Paragraphs =
                            [
                                Text("PlayerController currently detects collectibles, changes the score, stores collected items, counts the fruit, and updates two UI labels. It works, but gameplay code now needs to know how the interface is built."),
                                Text("We will separate those responsibilities. PlayerController will continue owning the gameplay data, but it will announce when that data changes. A new GameUI component will listen for the announcement and update the labels.")
                            ]
                        },
                        new Block
                        {
                            Title = "The Theory: Publishers and Subscribers",
                            CssClass = "article-ads-help-block",
                            Paragraphs =
                            [
                                Text("An <b>event</b> is a notification sent by one object without calling a specific receiving object directly. The object that raises the event is the <b>publisher</b>. Objects that choose to listen are <b>subscribers</b>."),
                                Text("In our game, PlayerController is the publisher: it knows when collection data changes. GameUI is the subscriber: it reacts by changing text. PlayerController does not need a GameUI field or any knowledge of TextMeshPro."),
                                Text("This reduces <b>coupling</b>, which means the two components depend less directly on one another. We could later add sound, achievements, or analytics as additional subscribers without putting those systems inside PlayerController."),
                                Text("Events describe something that has already happened. A useful event name therefore reads like a fact, such as <code class='inline-code'>CollectionChanged</code>.")
                            ]
                        },
                        new Block
                        {
                            Title = "Declare the Event",
                            Paragraphs =
                            [
                                Text("Open <code class='inline-code'>PlayerController.cs</code> and add this namespace at the top:"),
                                Code("using System;"),
                                Text("Then add the event inside PlayerController, near its fields:"),
                                Code("public event Action<int, int, int> CollectionChanged;"),
                                Text("Action represents a method that returns no value. The three int type arguments describe the values sent with the notification: total score, apple count, and banana count."),
                                Text("Only PlayerController can raise this event. Other components may subscribe and unsubscribe, but they cannot pretend that the player's collection changed.")
                            ]
                        },
                        new Block
                        {
                            Title = "Replace the UI Method with a Notification",
                            Paragraphs =
                            [
                                Text("Rename <code class='inline-code'>UpdateCollectionText</code> to <code class='inline-code'>NotifyCollectionChanged</code>. Keep its counting loop, remove the line that changes collectionText, and raise the event after the loop:"),
                                Code("private void NotifyCollectionChanged()\r\n{\r\n    int appleCount = 0;\r\n    int bananaCount = 0;\r\n\r\n    foreach (string item in collectedItems)\r\n    {\r\n        if (item == \"Apple\")\r\n        {\r\n            appleCount++;\r\n        }\r\n        else if (item == \"Banana\")\r\n        {\r\n            bananaCount++;\r\n        }\r\n    }\r\n\r\n    CollectionChanged?.Invoke(score, appleCount, bananaCount);\r\n}"),
                                Text("The question mark performs a null check. If at least one subscriber is listening, Invoke calls its subscribed method and passes the three values. If nobody is listening, the line safely does nothing."),
                                Text("Replace every call to UpdateCollectionText with <code class='inline-code'>NotifyCollectionChanged()</code>. Keep the call in Start and the call immediately after an item is added to the list.")
                            ]
                        },
                        new Block
                        {
                            Title = "Create the GameUI Subscriber",
                            Paragraphs =
                            [
                                Text("In <code class='inline-code'>Assets/Scripts</code>, create a script named <code class='inline-code'>GameUI</code>. Replace its contents with:"),
                                Code("using TMPro;\r\nusing UnityEngine;\r\n\r\npublic class GameUI : MonoBehaviour\r\n{\r\n    [SerializeField]\r\n    private PlayerController playerController;\r\n\r\n    [SerializeField]\r\n    private TextMeshProUGUI scoreText;\r\n\r\n    [SerializeField]\r\n    private TextMeshProUGUI collectionText;\r\n\r\n    private void OnEnable()\r\n    {\r\n        playerController.CollectionChanged += UpdateDisplay;\r\n    }\r\n\r\n    private void OnDisable()\r\n    {\r\n        playerController.CollectionChanged -= UpdateDisplay;\r\n    }\r\n\r\n    private void UpdateDisplay(int score, int appleCount, int bananaCount)\r\n    {\r\n        scoreText.text = $\"Score: {score}\";\r\n        collectionText.text = $\"Apples: {appleCount} | Bananas: {bananaCount}\";\r\n    }\r\n}"),
                                Text("The <code class='inline-code'>+=</code> line subscribes UpdateDisplay to the event. Whenever PlayerController raises CollectionChanged, Unity runs UpdateDisplay with the supplied values."),
                                Text("The <code class='inline-code'>-=</code> line unsubscribes when the component is disabled. Pairing subscription and unsubscription prevents an inactive or destroyed listener from continuing to receive notifications.")
                            ]
                        },
                        new Block
                        {
                            Title = "Connect GameUI in Unity",
                            Paragraphs =
                            [
                                Text("Return to Unity and wait for compilation. Select Canvas in the Hierarchy and add the <b>Game UI</b> component."),
                                Text("The component has three empty Inspector fields. Drag <b>Player</b> from the Hierarchy into Player Controller. Drag <b>ScoreText</b> into Score Text, then drag <b>CollectionText</b> into Collection Text."),
                                Text("These references belong to GameUI now. PlayerController publishes numbers; GameUI owns the TextMeshPro objects that display them.")
                            ]
                        },
                        new Block
                        {
                            Title = "Remove the Old UI Responsibility",
                            Paragraphs =
                            [
                                Text("Return to PlayerController and remove its scoreText and collectionText fields. Remove the old UpdateScoreText method as well."),
                                Text("Inside OnTriggerEnter2D, remove the call to UpdateScoreText. NotifyCollectionChanged already sends the new score together with the fruit counts, so GameUI updates both labels in one place."),
                                Text("Your Start method should now notify subscribers of the initial zero values:"),
                                Code("private void Start()\r\n{\r\n    NotifyCollectionChanged();\r\n}"),
                                Text("Do not remove the winPanel field or winning logic. Showing the win panel is still part of the current gameplay flow; this chapter only moves the score and collection labels.")
                            ]
                        },
                        new Block
                        {
                            Title = "Check the Order of Execution",
                            Paragraphs =
                            [
                                Text("Unity calls enabled components' OnEnable methods before it calls Start. GameUI therefore subscribes during OnEnable, and PlayerController sends the initial values during Start."),
                                Text("If the labels keep their temporary Inspector text when Play mode begins, confirm that GameUI is enabled, all three references are assigned, and PlayerController calls NotifyCollectionChanged from Start.")
                            ]
                        },
                        new Block
                        {
                            Title = "Test the Event",
                            CssClass = ExerciseBlockClass,
                            Paragraphs =
                            [
                                Text("Enter Play mode. The labels should start at Score: 0 and Apples: 0 | Bananas: 0. Collect an apple and then the banana. Both labels should update after each collision, and the banana should still add three points."),
                                Text("Disable the Game UI component during Play mode, collect a fruit, and confirm that collection still works even though the labels stop changing. Enable Game UI again. It will listen for future changes; it will not receive events that happened while it was disabled."),
                                Text("Stop and restart Play mode after that experiment. Collect all fruit and confirm the final score, collection totals, win panel, and restart behavior still work.")
                            ]
                        },
                        new Block
                        {
                            Title = "Chapter Checkpoint",
                            CssClass = ExerciseBlockClass,
                            Paragraphs =
                            [
                                Text("Before marking this chapter complete, confirm that:"),
                                Text(ExerciseList(
                                    "PlayerController declares CollectionChanged as an Action<int, int, int> event.",
                                    "NotifyCollectionChanged counts the stored fruit and invokes the event.",
                                    "GameUI subscribes in OnEnable and unsubscribes in OnDisable.",
                                    "GameUI owns the score and collection text references.",
                                    "All three GameUI Inspector fields are assigned.",
                                    "PlayerController no longer directly updates the two text labels.",
                                    "The display initializes at zero and updates after every collection.",
                                    "Scoring, winning, and restarting still work without Console errors."))
                            ]
                        },
                        new Block
                        {
                            Title = "Next Step",
                            Paragraphs =
                            [
                                Text("Our components now communicate through an event, but the game still relies on string values such as Apple and Banana. Next, we will introduce an interface so collectible behaviour is described by a clear C# contract rather than a specific base class.")
                            ]
                        }
                    ]
                },
                new Article
                {
                    Id = 500456,
                    CourseDisplayId = 7,
                    Title = "Define Collectibles with an Interface",
                    Slug = "define-unity-collectibles-with-an-interface",
                    Description = "Create an ICollectible contract, give apples their own class, and separate shared structure from concrete fruit behaviour.",
                    Area = Area.Course,
                    ExperiencePoints = 1,
                    Blocks =
                    [
                        new Block
                        {
                            Paragraphs =
                            [
                                Text("Our current Collectible class has two jobs: it represents the general collectible category, but its default values also represent an apple. That shortcut helped us introduce inheritance gently, but it now makes Apple a hidden default rather than an explicit game type."),
                                Text("In this chapter, Apple will receive its own AppleCollectible class. We will also create an ICollectible interface so PlayerController depends on the capabilities it needs instead of a particular class hierarchy.")
                            ]
                        },
                        new Block
                        {
                            Title = "The Theory: Interface, Base Class, and Concrete Class",
                            CssClass = "article-ads-help-block",
                            Paragraphs =
                            [
                                Text("An <b>interface</b> is a contract. It states which members a type must provide, but it does not represent a Unity component by itself. ICollectible will promise that every collectible has Points and a DisplayName."),
                                Text("A <b>base class</b> is a shared foundation. Collectible inherits from MonoBehaviour, so it can live on a GameObject, and it gives related collectible classes one common place for shared behaviour we may add later."),
                                Text("A <b>concrete class</b> represents something we can actually use. AppleCollectible and BananaCollectible provide the real values and are the scripts attached to their respective prefabs."),
                                Text("The resulting design is: <b>ICollectible</b> defines the promise, <b>Collectible</b> provides the Unity foundation, and the apple and banana classes describe the actual fruit. PlayerController only needs the promise.")
                            ]
                        },
                        new Block
                        {
                            Title = "Create ICollectible",
                            Paragraphs =
                            [
                                Text("In <code class='inline-code'>Assets/Scripts</code>, create a C# script named <code class='inline-code'>ICollectible</code>. Because this is a plain C# interface rather than a MonoBehaviour, replace the generated contents with:"),
                                Code("namespace Assets.Scripts\r\n{\r\n    public interface ICollectible\r\n    {\r\n        int Points { get; }\r\n        string DisplayName { get; }\r\n    }\r\n}"),
                                Text("The leading I is the standard C# naming convention for interfaces. Each property has only a getter, so the contract says the values can be read without requiring them to be publicly changeable."),
                                Text("This is a block-scoped namespace, which is compatible with the project's C# 9 language version. Use the same namespace in all scripts from this chapter.")
                            ]
                        },
                        new Block
                        {
                            Title = "Turn Collectible into a Shared Base Class",
                            Paragraphs =
                            [
                                Text("Open <code class='inline-code'>Collectible.cs</code> and replace it with:"),
                                Code("using UnityEngine;\r\n\r\nnamespace Assets.Scripts\r\n{\r\n    public abstract class Collectible : MonoBehaviour, ICollectible\r\n    {\r\n        public abstract int Points { get; }\r\n        public abstract string DisplayName { get; }\r\n    }\r\n}"),
                                Text("The colon shows that Collectible inherits from MonoBehaviour and implements ICollectible. Implementing the interface means the class must provide its two properties."),
                                Text("Collectible is now <code class='inline-code'>abstract</code>. It defines a foundation but is not a finished collectible, so it should not be attached directly to a GameObject. Its abstract properties force each concrete fruit class to supply meaningful values.")
                            ]
                        },
                        new Block
                        {
                            Title = "Create AppleCollectible",
                            Paragraphs =
                            [
                                Text("Create <code class='inline-code'>AppleCollectible.cs</code> inside Assets/Scripts and replace its contents with:"),
                                Code("namespace Assets.Scripts\r\n{\r\n    public class AppleCollectible : Collectible\r\n    {\r\n        public override int Points => 1;\r\n        public override string DisplayName => \"Apple\";\r\n    }\r\n}"),
                                Text("Apple is no longer an unnamed default. AppleCollectible is a concrete type with an explicit name and point value, just like BananaCollectible.")
                            ]
                        },
                        new Block
                        {
                            Title = "Update BananaCollectible",
                            Paragraphs =
                            [
                                Text("Open <code class='inline-code'>BananaCollectible.cs</code> and confirm that it contains the same namespace and both required overrides:"),
                                Code("namespace Assets.Scripts\r\n{\r\n    public class BananaCollectible : Collectible\r\n    {\r\n        public override int Points => 3;\r\n        public override string DisplayName => \"Banana\";\r\n    }\r\n}"),
                                Text("Both concrete classes now follow the same shape. Their values differ, but each satisfies the ICollectible contract through the Collectible base class.")
                            ]
                        },
                        new Block
                        {
                            Title = "Update the Apple Prefab",
                            Paragraphs =
                            [
                                Text("Return to Unity and wait for compilation. Select <code class='inline-code'>Assets/Prefabs/Collectible.prefab</code> and open it in Prefab Mode."),
                                Text("The old Collectible component is no longer a finished component and may appear as missing or invalid after becoming abstract. Remove it, choose <b>Add Component</b>, and add <b>Apple Collectible</b>. Save the prefab and leave Prefab Mode."),
                                Text("Select a few apple instances in MainScene and confirm that they inherited Apple Collectible from the prefab. Do not add AppleCollectible separately to every scene instance; changing the shared prefab updates them together."),
                                Text("Open BananaCollectible.prefab as well and confirm that it still has Banana Collectible and does not also have Apple Collectible or the abstract base component.")
                            ]
                        },
                        new Block
                        {
                            Title = "Depend on the Interface",
                            Paragraphs =
                            [
                                Text("Open <code class='inline-code'>PlayerController.cs</code>. In OnTriggerEnter2D, change the type requested by TryGetComponent from Collectible to ICollectible:"),
                                Code("if (other.TryGetComponent(out ICollectible collectible))\r\n{\r\n    score += collectible.Points;\r\n    collectedItems.Add(collectible.DisplayName);\r\n\r\n    NotifyCollectionChanged();\r\n    Destroy(other.gameObject);\r\n\r\n    if (score >= winningScore)\r\n    {\r\n        winPanel.SetActive(true);\r\n    }\r\n}"),
                                Text("PlayerController still reads Points and DisplayName, but it no longer requires the collided component to inherit from Collectible. Any component that implements ICollectible can participate in the collection system."),
                                Text("Our apple and banana still share the base class because that structure is useful. The important difference is that PlayerController now depends on the smallest contract it actually needs.")
                            ]
                        },
                        new Block
                        {
                            Title = "Why Keep Both an Interface and a Base Class?",
                            Paragraphs =
                            [
                                Text("An interface and a base class solve different problems. The interface describes a capability; the base class shares implementation and Unity inheritance."),
                                Text("C# classes can inherit from only one base class, but they can implement multiple interfaces. A future object could inherit from a completely different MonoBehaviour class and still implement ICollectible. PlayerController would accept it because the required contract is unchanged."),
                                Text("We are not adding an interface merely to make the project look more advanced. It creates a real boundary: the player knows what information a collectible supplies without knowing how that collectible is built.")
                            ]
                        },
                        new Block
                        {
                            Title = "Test the New Structure",
                            CssClass = ExerciseBlockClass,
                            Paragraphs =
                            [
                                Text("Enter Play mode and collect one apple. Confirm that it disappears, adds one point, and increases the apple count. Collect the banana and confirm that it adds three points and increases the banana count."),
                                Text("Collect everything and verify the final score of seven, Apples: 4 | Bananas: 1, the win panel, and restart behavior."),
                                Text("If a fruit does nothing, inspect its prefab and confirm that its concrete script is attached to the same GameObject as the Collider 2D. If scripts cannot find one another, confirm that ICollectible, Collectible, AppleCollectible, BananaCollectible, and PlayerController all use the same Assets.Scripts namespace.")
                            ]
                        },
                        new Block
                        {
                            Title = "Chapter Checkpoint",
                            CssClass = ExerciseBlockClass,
                            Paragraphs =
                            [
                                Text("Before marking this chapter complete, confirm that:"),
                                Text(ExerciseList(
                                    "ICollectible defines read-only Points and DisplayName properties.",
                                    "Collectible is an abstract MonoBehaviour that implements ICollectible.",
                                    "AppleCollectible explicitly provides Apple and 1.",
                                    "BananaCollectible explicitly provides Banana and 3.",
                                    "The apple and banana prefabs each contain only their correct concrete script.",
                                    "PlayerController requests ICollectible from the collided object.",
                                    "All scripts consistently use the C# 9-compatible Assets.Scripts namespace.",
                                    "Collection, UI events, scoring, winning, and restarting still work."))
                            ]
                        },
                        new Block
                        {
                            Title = "Next Step",
                            Paragraphs =
                            [
                                Text("Our collectible types now have a clean contract, but their names and point values are still hard-coded in separate scripts. Next, we will introduce ScriptableObjects so collectible data can be created and edited as Unity assets without adding a new class for every fruit.")
                            ]
                        }
                    ]
                },
                new Article
                {
                    Id = 500457,
                    CourseDisplayId = 8,
                    Title = "Move Collectible Data into ScriptableObjects",
                    Slug = "unity-collectible-data-with-scriptableobjects",
                    Description = "Create reusable collectible data assets and configure apples and bananas without needing a separate component class for every fruit.",
                    Area = Area.Course,
                    ExperiencePoints = 1,
                    Blocks =
                    [
                        new Block
                        {
                            Paragraphs =
                            [
                                Text("AppleCollectible and BananaCollectible now make our fruit types explicit, but each class exists only to return a name and point value. Adding an orange would require another nearly identical script."),
                                Text("In this chapter, we will move those values into ScriptableObject assets. Both prefabs will use the same Collectible component, while separate Apple Data and Banana Data assets provide their configuration.")
                            ]
                        },
                        new Block
                        {
                            Title = "The Theory: Code and Data",
                            CssClass = "article-ads-help-block",
                            Paragraphs =
                            [
                                Text("A <b>MonoBehaviour</b> is a component attached to a GameObject. It participates in scene behaviour. A <b>ScriptableObject</b> is a data asset stored in the Project rather than attached to a scene object."),
                                Text("The Collectible component answers <i>how does a collectible participate in the game?</i> The data asset answers <i>which collectible is this and what is it worth?</i> Separating those questions lets several prefabs reuse the same behaviour with different settings."),
                                Text("This is <b>composition</b>: a Collectible is configured with a CollectibleData object. Instead of creating another subclass for every fruit, a designer can create another data asset and assign it in the Inspector."),
                                Text("The previous inheritance chapter was still valuable. It showed how concrete classes can satisfy the same interface. We are now evolving the design after noticing that the only differences between those classes are data.")
                            ]
                        },
                        new Block
                        {
                            Title = "Why Did We Create Those Classes First?",
                            CssClass = "article-ads-help-block",
                            Paragraphs =
                            [
                                Text("We created AppleCollectible and BananaCollectible to demonstrate inheritance with a small, visible example. They showed how two concrete classes can share a base class, provide different implementations, and still be handled through the same ICollectible contract."),
                                Text("Now that you have seen that design working, we can also see its limitation: both classes exist only to return two different values. Creating another nearly identical class for every fruit would add code without adding meaningful behaviour."),
                                Text("That is why this chapter replaces the fruit-specific classes with data assets. We are <b>not</b> deleting ICollectible. PlayerController will continue depending on that interface, and it will not need to change when the implementation becomes data-driven."),
                                Text("This is a normal part of software development: begin with a clear working design, observe where repetition appears, and refactor when a better structure becomes justified.")
                            ]
                        },
                        new Block
                        {
                            Title = "Create CollectibleData",
                            Paragraphs =
                            [
                                Text("In <code class='inline-code'>Assets/Scripts</code>, create a script named <code class='inline-code'>CollectibleData</code>. Replace its contents with:"),
                                Code("using UnityEngine;\r\n\r\nnamespace Assets.Scripts\r\n{\r\n    [CreateAssetMenu(\r\n        fileName = \"New Collectible Data\",\r\n        menuName = \"Collector/Collectible Data\")]\r\n    public class CollectibleData : ScriptableObject\r\n    {\r\n        [SerializeField]\r\n        private string displayName;\r\n\r\n        [SerializeField]\r\n        private int points = 1;\r\n\r\n        public string DisplayName => displayName;\r\n        public int Points => points;\r\n    }\r\n}"),
                                Text("CollectibleData inherits from ScriptableObject, not MonoBehaviour. The serialized fields are editable in the Inspector, while the public read-only properties let gameplay code safely read their values."),
                                Text("CreateAssetMenu adds a convenient entry to Unity's Create menu. It does not create an asset automatically; we will use that menu next.")
                            ]
                        },
                        new Block
                        {
                            Title = "Create Apple and Banana Data Assets",
                            Paragraphs =
                            [
                                Text("Return to Unity and wait for compilation. In the Project panel, create a folder named <code class='inline-code'>Assets/Data</code>, then create a Collectibles folder inside it."),
                                Text("Right-click inside <code class='inline-code'>Assets/Data/Collectibles</code> and choose <b>Create &gt; Collector &gt; Collectible Data</b>. Name the asset <code class='inline-code'>AppleData</code>. Select it and set Display Name to <b>Apple</b> and Points to <b>1</b>."),
                                Text("Create a second asset named <code class='inline-code'>BananaData</code>. Set Display Name to <b>Banana</b> and Points to <b>3</b>."),
                                Text("These are project assets, so changing one updates every component that references it. They are not copies created separately for each scene instance.")
                            ]
                        },
                        new Block
                        {
                            Title = "Make Collectible Data-Driven",
                            Paragraphs =
                            [
                                Text("Open <code class='inline-code'>Collectible.cs</code> and replace it with:"),
                                Code("using UnityEngine;\r\n\r\nnamespace Assets.Scripts\r\n{\r\n    public class Collectible : MonoBehaviour, ICollectible\r\n    {\r\n        [SerializeField]\r\n        private CollectibleData data;\r\n\r\n        public virtual int Points => data.Points;\r\n        public virtual string DisplayName => data.DisplayName;\r\n    }\r\n}"),
                                Text("Collectible is concrete again because it now has everything required to represent a configured fruit. Its properties delegate to the assigned data asset."),
                                Text("We temporarily leave the properties virtual so the existing AppleCollectible and BananaCollectible scripts continue compiling while we migrate their prefabs. This avoids another broken-component state in Unity.")
                            ]
                        },
                        new Block
                        {
                            Title = "Migrate the Apple Prefab",
                            Paragraphs =
                            [
                                Text("Open <code class='inline-code'>Collectible.prefab</code> in Prefab Mode. Right-click the <b>Apple Collectible</b> component header and choose <b>Remove Component</b>. Then choose <b>Add Component</b> and add the base <b>Collectible</b> component."),
                                Text("A Data field appears on the new component. Drag <code class='inline-code'>AppleData</code> from the Project panel into that field, then save the prefab."),
                                Text("Do not leave both Apple Collectible and Collectible attached. The prefab needs one component implementing ICollectible, configured with AppleData.")
                            ]
                        },
                        new Block
                        {
                            Title = "Migrate the Banana Prefab",
                            Paragraphs =
                            [
                                Text("Open <code class='inline-code'>BananaCollectible.prefab</code>. Remove the <b>Banana Collectible</b> component and add <b>Collectible</b>. Drag <code class='inline-code'>BananaData</code> into its Data field and save the prefab."),
                                Text("Check both prefabs before continuing: the apple prefab should reference AppleData, and the banana prefab should reference BananaData. Their Sprite Renderers and Collider 2D components should remain unchanged.")
                            ]
                        },
                        new Block
                        {
                            Title = "Test Before Removing the Old Classes",
                            CssClass = ExerciseBlockClass,
                            Paragraphs =
                            [
                                Text("Enter Play mode and collect an apple and the banana. Their score values and collection counts should behave exactly as before."),
                                Text("If Unity reports a NullReferenceException from Collectible, a prefab's Data field is empty. Stop Play mode, open that prefab, and assign the correct data asset."),
                                Text("Do not delete the old fruit scripts until both prefabs work. Migrating references before deleting their source prevents Unity from leaving missing scripts on the prefabs.")
                            ]
                        },
                        new Block
                        {
                            Title = "Remove the Redundant Fruit Classes",
                            Paragraphs =
                            [
                                Text("After the test passes, delete <code class='inline-code'>AppleCollectible.cs</code> and <code class='inline-code'>BananaCollectible.cs</code> from the Unity Project panel. Unity also removes their associated .meta files correctly when deletion is performed inside the editor."),
                                Text("Return to both prefabs and confirm that neither shows a Missing Script component. Each should contain the shared Collectible component and its assigned data asset."),
                                Text("PlayerController requires no changes. It still requests ICollectible, and Collectible still implements that contract. The interface protected the player from this internal redesign.")
                            ]
                        },
                        new Block
                        {
                            Title = "Add a New Fruit Without Writing a Class",
                            CssClass = ExerciseBlockClass,
                            Paragraphs =
                            [
                                Text("To prove the design is data-driven, create another Collectible Data asset named <code class='inline-code'>OrangeData</code>. Give it the display name Orange and a point value of 2."),
                                Text("Duplicate one fruit prefab, assign OrangeData, and use any temporary sprite while testing. You do not need an OrangeCollectible class."),
                                Text("The score will increase correctly because PlayerController reads Points through ICollectible. The current collection summary only counts Apple and Banana strings, so Orange will not yet receive its own UI count. That limitation gives us a useful target for a later refactor."),
                                Text("After proving it works, you may remove the temporary orange prefab and data asset to keep the scene focused on apples and bananas.")
                            ]
                        },
                        new Block
                        {
                            Title = "Chapter Checkpoint",
                            CssClass = ExerciseBlockClass,
                            Paragraphs =
                            [
                                Text("Before marking this chapter complete, confirm that:"),
                                Text(ExerciseList(
                                    "CollectibleData is a ScriptableObject containing a display name and points.",
                                    "AppleData contains Apple and 1.",
                                    "BananaData contains Banana and 3.",
                                    "Collectible reads its ICollectible properties from an assigned data asset.",
                                    "Both prefabs use the shared Collectible component.",
                                    "Each prefab references the correct data asset.",
                                    "AppleCollectible.cs and BananaCollectible.cs were removed only after prefab migration.",
                                    "Apples, bananas, UI events, scoring, winning, and restarting still work."))
                            ]
                        },
                        new Block
                        {
                            Title = "Next Step",
                            Paragraphs =
                            [
                                Text("Collectible data is now easy to configure, but PlayerController still uses string comparisons to build the collection summary. Next, we will replace those fixed counters with a dictionary so the UI can summarize any collectible created from data.")
                            ]
                        }
                    ]
                },
                new Article
                {
                    Id = 500458,
                    CourseDisplayId = 9,
                    Title = "Count Any Collectible with a Dictionary",
                    Slug = "count-unity-collectibles-with-a-dictionary",
                    Description = "Replace fixed apple, banana, and orange counters with a dictionary that can summarize any collectible automatically.",
                    Area = Area.Course,
                    ExperiencePoints = 1,
                    Blocks =
                    [
                        new Block
                        {
                            Paragraphs =
                            [
                                Text("Adding an orange exposed another rigid part of the game. PlayerController now declares an orangeCount variable, adds another else-if branch, and sends another integer through CollectionChanged."),
                                Text("That approach works for three fruits, but every future collectible would force us to edit both PlayerController and GameUI. We will replace the fixed counters with a dictionary that associates each collectible name with its count.")
                            ]
                        },
                        new Block
                        {
                            Title = "The Theory: Key-Value Pairs",
                            CssClass = "article-ads-help-block",
                            Paragraphs =
                            [
                                Text("A <b>Dictionary&lt;TKey, TValue&gt;</b> stores values under unique keys. In this game, the key is a collectible name such as Apple, and the value is the number collected."),
                                Text("A list answers <i>what did the player collect, in order?</i> A dictionary answers <i>how many of each type did the player collect?</i> Those are different questions, so we will keep the List as the history and build a Dictionary as the summary."),
                                Text("Looking up a key is direct. We do not need a separate variable or condition for every possible fruit. When Orange appears for the first time, the dictionary creates an Orange entry; the next orange increments that existing value."),
                                Text("This makes the code <b>data-driven</b>. New CollectibleData assets can flow through the counting and UI systems without requiring new fruit-specific branches.")
                            ]
                        },
                        new Block
                        {
                            Title = "Simplify the Event",
                            Paragraphs =
                            [
                                Text("Open <code class='inline-code'>PlayerController.cs</code>. Replace the current four-integer event:"),
                                Code("public event Action<int, int, int, int> CollectionChanged;"),
                                Text("with an event that sends the score and one dictionary:"),
                                Code("public event Action<int, Dictionary<string, int>> CollectionChanged;"),
                                Text("The first int is still the total score. The dictionary carries every item count, so its shape does not need to change when another collectible is introduced."),
                                Text("PlayerController already imports <code class='inline-code'>System.Collections.Generic</code> for List, so Dictionary is available without another using directive.")
                            ]
                        },
                        new Block
                        {
                            Title = "Build the Summary Dictionary",
                            Paragraphs =
                            [
                                Text("Replace the complete <code class='inline-code'>NotifyCollectionChanged</code> method with:"),
                                Code("private void NotifyCollectionChanged()\r\n{\r\n    Dictionary<string, int> itemCounts = new Dictionary<string, int>();\r\n\r\n    foreach (string item in collectedItems)\r\n    {\r\n        if (itemCounts.ContainsKey(item))\r\n        {\r\n            itemCounts[item]++;\r\n        }\r\n        else\r\n        {\r\n            itemCounts[item] = 1;\r\n        }\r\n    }\r\n\r\n    CollectionChanged?.Invoke(score, itemCounts);\r\n}"),
                                Text("The loop still visits the collection history. ContainsKey checks whether that fruit already has an entry. Existing entries increase by one; new names begin at one."),
                                Text("Notice what disappeared: there are no appleCount, bananaCount, or orangeCount variables, and there are no fruit-name comparisons. The same loop handles every display name supplied by CollectibleData.")
                            ]
                        },
                        new Block
                        {
                            Title = "Update the GameUI Subscription",
                            Paragraphs =
                            [
                                Text("Open <code class='inline-code'>GameUI.cs</code> and add the collections namespace at the top:"),
                                Code("using System.Collections.Generic;"),
                                Text("The OnEnable and OnDisable methods do not change. They still subscribe and unsubscribe UpdateDisplay. However, UpdateDisplay must now match the event's new parameter list."),
                                Text("Replace the complete UpdateDisplay method with:"),
                                Code("private void UpdateDisplay(\r\n    int score,\r\n    Dictionary<string, int> itemCounts)\r\n{\r\n    scoreText.text = $\"Score: {score}\";\r\n\r\n    List<string> summaries = new List<string>();\r\n\r\n    foreach (KeyValuePair<string, int> item in itemCounts)\r\n    {\r\n        summaries.Add($\"{item.Key}s: {item.Value}\");\r\n    }\r\n\r\n    collectionText.text = summaries.Count == 0\r\n        ? \"Nothing collected yet\"\r\n        : string.Join(\" | \", summaries);\r\n}"),
                                Text("Each KeyValuePair exposes a Key and a Value. For example, an Apple entry provides Apple as the key and its collected count as the value."),
                                Text("We append an s for the simple fruit names in this game, then join the summaries with a vertical separator. The empty-list check gives the player a useful message before collecting anything.")
                            ]
                        },
                        new Block
                        {
                            Title = "Why Create Another List in GameUI?",
                            Paragraphs =
                            [
                                Text("The original collectedItems list stores gameplay history. The summaries list is temporary formatting data used only while building one UI message."),
                                Text("For Apple, Banana, and Orange it will contain strings similar to Apples: 3, Bananas: 1, and Oranges: 1. string.Join combines those pieces into one label, then the temporary list can be discarded when UpdateDisplay finishes."),
                                Text("We could build the text in several other ways, but this approach reinforces List and keeps each transformation visible to a learner.")
                            ]
                        },
                        new Block
                        {
                            Title = "Keep the Winning Score at Eight",
                            Paragraphs =
                            [
                                Text("Your scene now has a total collectible value of eight, so keep this PlayerController setting:"),
                                Code("[SerializeField] private int winningScore = 8;"),
                                Text("The dictionary changes how item counts are summarized; it does not change scoring. Collectible Points still come from AppleData, BananaData, and OrangeData.")
                            ]
                        },
                        new Block
                        {
                            Title = "Test All Three Fruits",
                            CssClass = ExerciseBlockClass,
                            Paragraphs =
                            [
                                Text("Enter Play mode. Before collecting anything, the summary should say <b>Nothing collected yet</b> and the score should be zero."),
                                Text("Collect the orange first. The score should increase by two and the summary should add Oranges: 1. Then collect a banana and an apple. Each name should appear automatically without a matching condition in PlayerController."),
                                Text("Collect everything and confirm that the score reaches eight, the win panel appears, and the collection summary contains the correct totals for your scene."),
                                Text("The dictionary preserves the order in which names are first added in this version of C#. Therefore, the displayed fruit order may depend on which type you collect first. That is acceptable for now.")
                            ]
                        },
                        new Block
                        {
                            Title = "Prove It Is Extensible",
                            CssClass = ExerciseBlockClass,
                            Paragraphs =
                            [
                                Text("Optionally create another CollectibleData asset and configure a temporary collectible prefab with it. Give it a unique Display Name."),
                                Text("When collected, its name and count should appear without adding another counter, event parameter, else-if branch, or UI parameter. Remove the temporary object afterward unless you want it to remain part of the level."),
                                Text("If the score changes but no summary appears, confirm that GameUI's UpdateDisplay accepts exactly an int and a Dictionary<string, int>. A subscribed method's parameters must match its event delegate.")
                            ]
                        },
                        new Block
                        {
                            Title = "Chapter Checkpoint",
                            CssClass = ExerciseBlockClass,
                            Paragraphs =
                            [
                                Text("Before marking this chapter complete, confirm that:"),
                                Text(ExerciseList(
                                    "collectedItems remains a List<string> containing collection history.",
                                    "NotifyCollectionChanged builds a Dictionary<string, int> from that history.",
                                    "PlayerController no longer contains fruit-specific counters or comparisons.",
                                    "CollectionChanged sends only the score and dictionary.",
                                    "GameUI loops over KeyValuePair<string, int> values.",
                                    "The empty summary says Nothing collected yet.",
                                    "Apple, banana, and orange counts appear automatically.",
                                    "The score reaches eight and winning and restarting still work."))
                            ]
                        },
                        new Block
                        {
                            Title = "Next Step",
                            Paragraphs =
                            [
                                Text("The collection system can now grow without fruit-specific code. Next, we will introduce a simple game-state enum so Playing and Won become explicit states rather than behaviour controlled only by whether a panel is visible.")
                            ]
                        }
                    ]
                }
            ]
        };
    }
}
