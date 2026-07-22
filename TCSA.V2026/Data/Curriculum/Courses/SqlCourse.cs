using TCSA.V2026.Data.Models;

namespace TCSA.V2026.Data.Curriculum;

public class SqlCourse
{
    public static Course GetSqlCourse()
    {
        return new Course
        {
            Id = 4,
            Title = "Introduction to SQL",
            Description = "Learn SQL fundamentals through practical queries, relational database concepts, and an e-commerce scenario.",
            ImgUrl = "icons8-sql-database-administrators-96.png",
            Articles = new List<Article>
                {
                    new Article
                    {
                        Id = 500070,
                        CourseDisplayId = 1,
                        Title = "Introduction",
                        Slug = "intro-to-sql-intro",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "Welcome to the fascinating world of SQL! We're excited to have you on this journey, where you'll build a solid foundation in the <b>world's most widely used database language</b>." },
                                    new Paragraph {
                                       Body = "Learning SQL is essential for anyone working with data, whether in software development, business analysis, or data science. It enables you to query and analyze information, which is critical for making informed decisions. Additionally, <b>SQL is universally recognized</b>, meaning the skills you gain will transfer across various database systems and industries. Whether you're building applications, managing databases, or diving into data analytics, SQL serves as a foundational tool that opens up countless opportunities." },
                                     new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "sql-image.jpeg"}
                                }
                            },
                            new Block
                            {
                                Title = "Pre-requisites",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "This course is designed for <b>absolute beginners</b>, so you don’t need to have any SQL knowledge to get started. All concepts will be introduced step-by-step, with clear explanations and practical examples to help you understand and apply what you learn. Whether you’re completely new to SQL or looking to expand your skills into database management, this course will guide you from the very basics to confidently working with SQL." },
                                    new Paragraph {
                                       Body = "This course is part of The C# Academy's curriculum. While we won’t be using C# in this project, learning SQL in isolation will give you the essential skills needed to interact with databases effectively when you use it with C# in future projects. By focusing on SQL in this course, you’ll gain a clear understanding of how databases work, preparing you to integrate these concepts with C# in other areas of the curriculum." }
                                }
                            },
                            new Block
                            {
                                Title = "What to Expect",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "This is a beginner-friendly course, so advanced concepts like database management and administration will not be included. Instead, we’ll focus on <b>foundational SQL skills</b> and learn in the context of an <b>e-commerce business case scenario</b>. This practical approach will help you understand how SQL can be applied to real-world problems while keeping the learning process straightforward and accessible." }
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                        BackgroundColor="#1C236D",
                                        FontColor="#FFF",
                                        Body = "Did you know that SQL was initially called \"SEQUEL\" (Structured English Query Language)? It was later renamed SQL due to a trademark conflict, but the pronunciation \"sequel\" is still widely used today!" }
                                }
                            },
                        }
                    },
                    new Article
                    {
                        Id = 500071,
                        CourseDisplayId = 2,
                        Title = "Working With Sqlite",
                        Slug = "intro-to-sql-sqlite",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "SqLite is a lightweight, self-contained, serverless database engine that <b>stores data in a single file</b>. Unlike traditional database systems like MySQL or SQL Server, SQLite doesn’t require a separate server to manage its databases, making it incredibly portable and easy to use. Despite its simplicity, it is a powerful and reliable tool that is widely used in mobile applications, small-scale projects, and embedded systems. Its ability to handle basic SQL operations while remaining fast and efficient makes it ideal for learning and experimentation."},
                                    new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c4-ch2-sql-sqlite.png"}
                                },
                            },
                            new Block
                            {
                                Title = "Why Sqlite?",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "SQLite is perfect for beginners because of its simplicity. There’s no need for complicated installations or configurations; you can start working with a database almost immediately. Its self-contained nature ensures you can focus on learning SQL concepts without being distracted by the complexities of setting up a database server. Additionally, <b>SQLite adheres to standard SQL syntax</b>, which means the skills you develop here will translate directly to other database systems in the future." }
                                }
                            },
                            new Block
                            {
                                Title = "Can you use SQL Server?",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "Absolutely. All tutorials in this course can be followed with both with Sqlite and SQL Server. Keep in mind there will be small differences in syntax, particularly in regards to <b>data types</b> but most of the queries in this course will be identical for both. We do suggest you use Sqlite, as it will make it slightly easier to follow this tutorial." }
                                }
                            },
                            new Block
                            {
                                Title = "Setting Up",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "Setting up Sqlite is very easy. <a href='https://sqlitebrowser.org/' target='_blank'><b><u>All you need to do is download DB Browser</u></b></a>, a popular cross-platform graphical interface tool that provides a user-friendly way to create and manage your databases. When installing, <b>choose the option to create shortcuts</b> to save you some time. You'll be using the application frequently."
                                    },
                                     new Paragraph {
                                       Body = "Once you click on the shorcut, if the installation was successful, you'll see the following interface:" },
                                      new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c4-ch2-sql-sqlite2.png"}
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                        BackgroundColor="#1C236D",
                                        FontColor="#FFF",
                                        Body = "SQLite is so lightweight and self-contained that it has been used in everything from web browsers to spacecraft. It doesn’t require a separate server to operate, making it incredibly versatile!" }
                                }
                            },
                        }
                    },
                    new Article
                    {
                        Id = 500072,
                        CourseDisplayId = 3,
                        Title = "SQL Data Types",
                        Slug = "intro-to-sql-data-types",
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
                                        Body = "Data types <b>define the kind of data that can be stored in database table</b>, such as text, numbers, or dates. They play a critical role in ensuring data consistency and optimizing database performance. While SQL as a language supports a wide variety of data types, each database system implements them differently. SQLite uses a more flexible and <b>simplified approach</b> to data types, while SQL Server adheres to strict typing with an extensive set of predefined types.\r\n"
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Data Types in SQLite",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                        Body = "SQLite employs dynamic typing, meaning it doesn’t strictly enforce column data types. Instead, it uses type affinities, which are broad categories for data: <b>TEXT, INTEGER, REAL, BLOB, and NULL</b>. For example, a column defined as TEXT can store numbers, text, or even date strings, though SQLite will attempt to interpret and store values in the most appropriate format. This flexibility can simplify development but requires careful handling to avoid inconsistent data."
                                    }
                                }
                            },
                            new Block
                            {
                                Title = "Data Types in SQL Server",
                                Paragraphs = new List<Paragraph>
                                {
                                      new Paragraph {
                                          Body = "The widely used SQL Server, in contrast, enforces strict data typing. Columns are explicitly defined with specific types like <b>INT, VARCHAR, DECIMAL, or DATETIME</b>, and only data matching the defined type can be stored. This ensures data integrity and allows for advanced optimizations, especially in large-scale applications. SQL Server also offers a much larger variety of types, including specialized ones like <b>UNIQUEIDENTIFIER</b> for globally unique identifiers or XML for storing structured data."
                                      }
                                }
                            },
                            new Block
                            {
                                Title = "How They Differ",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "As we move forward, understanding the differences between SQL Server and Sqlite will help you choose the right database for your projects and prepare you to adapt your SQL knowledge to different systems. For now, we will focus on SQLite's simpler type system, keeping things accessible and beginner-friendly." },
                                     new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c4-ch3-sql-sqlite-vs-sqlserver.png"}

                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "BLOBs for Everything: The BLOB type in SQLite is the ultimate wildcard — it can store any kind of binary data, including images, files, or serialized objects." }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500073,
                        CourseDisplayId = 4,
                        Title = "Table Creation",
                        Slug = "intro-to-sql-data-types-table-creation",
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
                                        Body = "It's time to start writing SQL! In this chapter, we will focus on creating a table for managing products in an e-commerce store. This is one of the core aspects of building a database, as tables store the data for the system. We will explore how to define the table structure, choose appropriate data types for each column, and understand the relationships between the fields."
                                    },
                                     new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c4-ch4-sql-ecommerce.jpg"}
                                }
                            },
                            new Block
                            {
                                Title = "Understanding Table Creation",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "A table in SQL consists of <b>rows and columns</b>, where each column holds a specific type of data. To create a table, we use the <b>CREATE TABLE</b> statement, followed by the table name and column definitions. Each column is defined with a name and a corresponding data type. You can also set constraints on the columns to ensure data integrity."},
                                    new Paragraph { Body = "Let’s start by creating a simple <b>Products</b> table for an e-commerce store. This table will store basic information about each product available for sale."},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "CREATE TABLE Products (\r\n    ProductID INTEGER PRIMARY KEY AUTOINCREMENT,\r\n    ProductName TEXT NOT NULL,\r\n    Description TEXT,\r\n    Price REAL NOT NULL,\r\n    StockQuantity INTEGER NOT NULL,\r\n    DateAdded DATE\r\n);"},
                                    new Paragraph { Body = "Now Line 1: CREATE TABLE</b>: This SQL command is used to define a new table in the database. <b>Products</b>: This is the name of the table being created. You can give the table any name you want. The name should be descriptive of the data it will contain. In this case, the table will hold product-related information. "},
                                    new Paragraph { Body = "<b>\U0001f7e2 Line 2: ProductID INTEGER PRIMARY KEY AUTOINCREMENT</b>." +
                                    "<br>🔹 <b>ProductID</b>: This is the name of the column. It serves as a <b>unique identifier</b> for each row in the table." +
                                    "<br>🔹 <b>INTEGER</b>: The data type of the column. It specifies that ProductID will store whole numbers. " +
                                    "<br>🔹 <b>PRIMARY KEY</b>: This keyword designates ProductID as the primary key of the table. A primary key uniquely identifies each row in the table and ensures that no two rows have the same value for this column. " +
                                    "<br>🔹 <b>AUTOINCREMENT</b>: This ensures that the value of ProductID is automatically incremented by the database each time a new row is added. It starts at 1 and increases sequentially."},
                                    new Paragraph { Body = "<b>\U0001f7e2 Line 3: ProductName TEXT NOT NULL</b>. " +
                                    "<br>🔹 <b>ProductName</b>: The name of the column, which will store the name of the product. " +
                                    "<br>🔹 <b>TEXT</b>: The data type for the column. It specifies that ProductName will store string values (e.g., product names). " +
                                    "<br>🔹 <b>NOT NULL</b>: This constraint ensures that the ProductName column cannot contain NULL values. A value must be provided for every row."},
                                    new Paragraph { Body = "<b>\U0001f7e2 Line 4: Description TEXT</b>. Description: The name of the column, which will store additional details about the product. It also has TEXT as its data type."},
                                    new Paragraph { Body = "<b>\U0001f7e2 Line 5: Price REAL NOT NULL</b>. Price: The name of the column, which will store the product's price. REAL: The data type for the column. It is used to store floating-point numbers (decimal values). A valid price must always be provided."},
                                    new Paragraph { Body = "<b>\U0001f7e2 Line 6: StockQuantity INTEGER NOT NULL</b>. StockQuantity: The name of the column, which will store the number of products available in stock. The data type is integer and cannot contain null values."},
                                     new Paragraph { Body = "<b>\U0001f7e2 Line 7: DateAdded DATE</b>. DateAdded: The name of the column, which will store the date when the product was added to the database. The DATE type It is used to store date values (in the format YYYY-MM-DD in most SQL databases).It doesn't have the NOT NULL , meaning it’s optional."}
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "You have probably noticed that some words in our SQL statement are in upper-case. By convention, upper-case is used for SQL keywords, while lower case is used for custom words, such as names of properties and tables. It's also advisable to declare each property of a table in a new line. These approaches are optional, but help improving readability." }
                                }
                            },
                            new Block
                            {
                                Title = "Constraints and Data Integrity",
                                Paragraphs = new List<Paragraph>
                                {
                                      new Paragraph { Body = "In SQL, <b>constraints</b> are rules applied to the columns in a table to ensure that the data entered into the database adheres to certain conditions. These rules are crucial for maintaining <b>data integrity</b>, accuracy, and reliability within the database. Constraints help enforce the correctness of the data by ensuring that it follows predefined criteria before being saved." },
                                      new Paragraph { Body = "As shown above, we’ve applied a few constraints to the table: <b>PRIMARY KEY</b> on ProductID: Ensures uniqueness and helps optimize queries that retrieve a product by its ID. <b>NOT NULL</b> on columns like ProductName, Price, and StockQuantity: Ensures that essential data is always provided for every product. No <b>NOT NULL</b> on Description and DateAdded: This allows for flexibility, enabling optional information while still keeping the table structured.\r\n" },
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "Columns like Description and DateAdded are optional because they allow NULL values. Keep in mind that a NULL value doesn’t mean \"zero\" or \"empty\" — it means \"unknown\" or \"not applicable,\" making databases a bit philosophical when it comes to missing information!" }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500074,
                        CourseDisplayId = 5,
                        Title = "Practice Creating a Table",
                        Slug = "intro-to-sql-practice-create",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "In DB Browser Menu, click on the first item: <b>New Database</b>. Choose a location in your file system, a name and save. We're naming our file ecommerce, but you can choose any name you prefer. Navigate to the folder where you created the file and if everything worked correctly, you'll see this:" },
                                     new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c4-ch5-sql-new-db.png"},
                                    new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c4-ch5-sql-db-file.png"},
                                }
                            },
                            new Block
                            {
                                Title = "Applying Your First Script",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "Just below the Top Menu, you'll see a few tabs. In the <b>Execute SQL</b> tab, paste the script from the previous chapter to  and click on the <b>Play button</b>, which executes the script:"},
                                    new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c4-ch5-sql-sqlite-practice-create.png"}
                                }
                            },
                            new Block
                            {
                                Title = "Examine the Table",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "Now choose the <b>Database Structure</b> tab. If everything worked correctly you'll see the table's properties:"},
                                    new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c4-ch5-sql-examine-table.png"}
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "SQLite tables can theoretically store up to 2^64 - 1 rows, which is about 18 quintillion rows. However, the practical limit is often much lower, depending on: 1. Database file size: The total database size cannot exceed 140 terabytes (TB) for a single SQLite database file. 2.Memory and disk space: While SQLite supports very large numbers of rows, the actual limit will be constrained by available system memory and storage.\r\nSQLite is designed to be lightweight, so while it can handle a massive number of rows, it is best used for smaller to medium-sized applications rather than as a large-scale enterprise database solution." }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500075,
                        CourseDisplayId = 6,
                        Title = "Inserting Data",
                        Slug = "intro-to-sql-insert",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "In SQL, the <b>INSERT</b> statement is used to add new rows of data into a table. This is a fundamental operation when working with databases because it allows you to populate tables with data and create records. It can be written in different ways, depending on how much information you want to provide and whether or not you want to include columns that allow NULL values." },
                                    new Paragraph { Body = "Here’s an example of inserting data into our Products table, which includes all columns. Execute it in the <b>Execute SQL</b> tab and don't forget to save your changes:" },
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "INSERT INTO Products (ProductID, ProductName, Description, Price, StockQuantity, DateAdded)\r\nVALUES (NULL, 'Wireless Headphones', 'Noise-canceling over-ear headphones', 59.99, 100, '2024-11-24');\r\n"},
                                    new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c4-ch6-sql-writechanges.png"},
                                    new Paragraph { Body = "You can then visualise the inserted row inserted by clicking on the <b>Browse Data</b> tab: " },
                                    new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c4-ch6-sql-browsedata.png"},
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "In DbBrowser, When executing commands that modify data, such as INSERT, <b>you need to save your changes or they won't persist</b>. You can do that by clicking on <b>File > Write Changes</b> in the left of the top menu." }
                                }
                            },
                            new Block
                            {
                                Title = "Inserting All Values",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "<b>INSERT INTO Products</b>: This part specifies the table where we want to insert the data (Products)"},
                                    new Paragraph { Body = "<b>ProductID, ProductName, Description, Price, StockQuantity, DateAdded</b>: These are the columns that we are inserting values into."},
                                    new Paragraph { Body = "<b>VALUES (NULL, 'Wireless Headphones', 'Noise-canceling over-ear headphones', 59.99, 100, '2024-11-24')</b>: These are the actual values being inserted. They need to be in the same order as the columns declared in the previous part of the query."},
                                    new Paragraph { Body = "<b>We use NULL for the ProductID column</b> because this column is set to auto-increment. The database will automatically assign a unique ID value to it."},
                                    new Paragraph { Body = "This method is ideal when you have data for all columns and don't mind providing values for the columns that allow NULL values."},
                                }
                            },
                            new Block
                            {
                                Title = "Inserting Partial Values",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "INSERT INTO Products (ProductName, Price, StockQuantity)\r\nVALUES ('Wireless Headphones', 59.99, 100);\r\n"},
                                    new Paragraph {
                                        Body = "In cases where a column can accept NULL values, <b>you don't need to explicitly include them</b> in your INSERT statement. If you omit a column that allows NULL, the database will automatically insert a NULL value for that column (or the default value, if specified). This approach is useful when you only have data for some of the columns and the others are optional."}
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "INSERT is one of the most universally understood SQL commands across different database systems. Whether you’re using MySQL, PostgreSQL, SQL Server, or Oracle, the syntax is strikingly similar, making it easy to work across platforms." }
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       Body = "Click on the button below to see a script to insert 100 products into our database. We'll be using this dataset for practice in the next lessons." }
                                }
                            },
                            new Block
                            {
                                IsCourseCodePage = true,
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       IsCode = true,
                                       Body = "INSERT INTO Products (ProductName, Description, Price, StockQuantity, DateAdded) VALUES\r\n('Wireless Headphones', 'Noise-canceling over-ear headphones', 59.99, 100, '2024-01-05'),\r\n('Bluetooth Speaker', 'Compact and portable with powerful sound', 79.99, 50, '2024-02-10'),\r\n('Smart Watch', 'Tracks fitness and daily activities', 199.99, 30, '2024-03-15'),\r\n('Gaming Mouse', 'High precision and customizable buttons', 49.99, 200, '2024-04-01'),\r\n('4K Monitor', 'Ultra HD display with vibrant colors', 299.99, 25, '2024-05-20'),\r\n('Noise-Canceling Earbuds', 'Compact design with superior sound', 89.99, 120, '2024-06-11'),\r\n('Portable Charger', 'High-capacity power bank for on-the-go', 39.99, 300, '2024-07-04'),\r\n('Smartphone', 'Latest model with advanced features', 999.99, 15, '2024-08-18'),\r\n('Tablet', 'Lightweight and powerful for all tasks', 399.99, 20, '2024-09-30'),\r\n('Laptop', 'High-performance laptop for work and play', 1299.99, 10, '2024-10-12'),\r\n('Smart Thermostat', 'Energy-efficient home temperature control', 149.99, 40, '2024-01-22'),\r\n('VR Headset', 'Immersive virtual reality experience', 349.99, 18, '2024-02-18'),\r\n('Electric Scooter', 'Eco-friendly transportation solution', 799.99, 8, '2024-03-12'),\r\n('Action Camera', 'Capture adventures in stunning detail', 249.99, 70, '2024-04-25'),\r\n('Smart Doorbell', 'Secure and convenient home monitoring', 99.99, 50, '2024-05-14'),\r\n('Gaming Console', 'Next-gen gaming at its finest', 499.99, 12, '2024-06-22'),\r\n('Robot Vacuum', 'Effortless cleaning for any home', 299.99, 30, '2024-07-18'),\r\n('Fitness Tracker', 'Track your fitness goals daily', 59.99, 150, '2024-08-10'),\r\n('Wireless Keyboard', 'Ergonomic design and long battery life', 29.99, 200, '2024-09-05'),\r\n('External Hard Drive', 'Portable storage solution', 79.99, 80, '2024-10-27'),\r\n('Photography Drone', 'High-quality drone for photography', 599.99, 10, '2024-01-03'),\r\n('Smart Home Hub', 'Centralized control for smart devices', 129.99, 45, '2024-02-14'),\r\n('Streaming Device', 'Stream your favorite content on TV', 49.99, 90, '2024-03-01'),\r\n('Gaming Chair', 'Ergonomic chair for long gaming sessions', 199.99, 25, '2024-04-11'),\r\n('Graphic Tablet', 'Professional tablet for digital art', 349.99, 12, '2024-05-06'),\r\n('E-Reader', 'Lightweight e-reader with long battery life', 129.99, 60, '2024-06-15'),\r\n('Portable Projector', 'Mini projector for presentations', 249.99, 20, '2024-07-09'),\r\n('Mechanical Keyboard', 'Tactile and durable mechanical keyboard', 79.99, 110, '2024-08-03'),\r\n('Noise Meter', 'Handheld device for measuring noise levels', 39.99, 50, '2024-09-18'),\r\n('Smart Light Bulbs', 'Customizable smart lighting', 59.99, 100, '2024-10-02'),\r\n('Power Drill', 'Cordless power drill with accessories', 99.99, 80, '2024-01-25'),\r\n('Cookware Set', 'Non-stick cookware set for your kitchen', 149.99, 35, '2024-02-05'),\r\n('Espresso Machine', 'Professional-grade coffee maker', 399.99, 10, '2024-03-16'),\r\n('Digital Thermometer', 'Accurate readings for home use', 19.99, 150, '2024-04-30'),\r\n('Stand Mixer', 'Powerful stand mixer for baking', 249.99, 15, '2024-05-20'),\r\n('Gaming Laptop', 'High-performance gaming laptop', 1499.99, 8, '2024-06-11'),\r\n('Smart Air Purifier', 'Improve indoor air quality', 299.99, 25, '2024-07-04'),\r\n('Smart Lock', 'Keyless entry smart lock', 199.99, 50, '2024-08-01'),\r\n('Wireless Router', 'Fast and secure internet connectivity', 79.99, 100, '2024-09-14'),\r\n('Electric Kettle', 'Stylish and efficient kettle', 39.99, 150, '2024-10-18'),\r\n('Bluetooth Headset', 'Lightweight and reliable headset', 49.99, 200, '2024-01-10'),\r\n('Dash Cam', 'High-resolution dash camera', 99.99, 75, '2024-02-25'),\r\n('Smart Pen', 'Digitize your handwritten notes', 129.99, 30, '2024-03-05'),\r\n('Portable Fridge', 'Compact fridge for outdoor use', 299.99, 10, '2024-04-20'),\r\n('Wi-Fi Extender', 'Expand your home Wi-Fi coverage', 49.99, 120, '2024-05-25'),\r\n('Digital Camera', 'Capture high-quality images and videos', 799.99, 15, '2024-06-30'),\r\n('Electric Toothbrush', 'Improve oral health with advanced features', 99.99, 90, '2024-07-15'),\r\n('Waterproof Speaker', 'Durable speaker for outdoor use', 129.99, 50, '2024-08-25'),\r\n('Air Fryer', 'Healthy cooking with less oil', 179.99, 30, '2024-09-06'),\r\n('Smart Scale', 'Track your weight and health metrics', 59.99, 100, '2024-10-20'),\r\n('Handheld Vacuum', 'Compact vacuum for quick cleanups', 89.99, 40, '2024-11-01'),\r\n('Cordless Hair Clippers', 'Professional grooming kit', 49.99, 70, '2024-11-12'),\r\n('Wireless Door Sensor', 'Monitor door activity in real-time', 19.99, 150, '2024-11-23'),\r\n('Smart Ceiling Fan', 'Energy-efficient fan with remote control', 149.99, 20, '2024-12-05'),\r\n('Portable Air Conditioner', 'Cooling solution for small rooms', 299.99, 15, '2024-12-16'),\r\n('Rechargeable Flashlight', 'Bright and durable flashlight', 39.99, 200, '2024-12-27'),\r\n('Digital Alarm Clock', 'Modern design with multiple features', 29.99, 100, '2024-11-08'),\r\n('Electric Blanket', 'Stay warm with adjustable heat levels', 69.99, 50, '2024-11-19'),\r\n('Smart Garden System', 'Automated plant care for home', 199.99, 10, '2024-12-01'),\r\n('Home Security Camera', 'Monitor your property with ease', 99.99, 80, '2024-12-12'),\r\n('Smart Outlet', 'Control appliances from your phone', 24.99, 120, '2024-12-23'),\r\n('Wireless Charger', 'Fast charging for compatible devices', 29.99, 150, '2024-11-02'),\r\n('Electric Griddle', 'Perfect for pancakes and more', 59.99, 40, '2024-11-13'),\r\n('Smart Bike Lock', 'Secure your bike with smartphone access', 99.99, 30, '2024-11-24'),\r\n('Automatic Soap Dispenser', 'Hygienic and touch-free', 29.99, 100, '2024-12-06'),\r\n('Home Theater System', 'Premium surround sound experience', 799.99, 10, '2024-12-17'),\r\n('Robot Lawn Mower', 'Effortless lawn maintenance', 899.99, 8, '2024-12-28'),\r\n('Electric Skillet', 'Multi-functional electric skillet', 49.99, 60, '2024-11-09'),\r\n('Cordless Screwdriver', 'Handy tool for small projects', 29.99, 200, '2024-11-20'),\r\n('Thermal Camera', 'Infrared imaging for professionals', 399.99, 5, '2024-12-02'),\r\n('Electric Wine Opener', 'Open bottles with ease', 39.99, 100, '2024-12-13'),\r\n('Portable Blender', 'Smoothies on the go', 49.99, 80, '2024-12-24'),\r\n('Desktop Air Purifier', 'Keep your workspace fresh', 99.99, 25, '2024-11-03'),\r\n('Solar Power Bank', 'Eco-friendly portable charger', 59.99, 150, '2024-11-14'),\r\n('Digital Picture Frame', 'Display cherished memories', 129.99, 50, '2024-11-25'),\r\n('Instant Camera', 'Capture memories with instant prints', 79.99, 40, '2024-12-07'),\r\n('Portable Heater', 'Stay warm anywhere', 69.99, 30, '2024-12-18'),\r\n('Electric Pressure Cooker', 'Quick and healthy meals', 99.99, 20, '2024-12-29'),\r\n('Cordless Hand Mixer', 'Mix ingredients effortlessly', 39.99, 100, '2024-11-04'),\r\n('Motion Sensor Light', 'Automatic lighting for your home', 19.99, 200, '2024-11-15'),\r\n('Electric Standing Desk', 'Improve posture and productivity', 399.99, 10, '2024-11-26'),\r\n('Smart Coffee Mug', 'Keep beverages at the perfect temperature', 49.99, 80, '2024-12-08'),\r\n('Home Gym Set', 'Compact and versatile workout equipment', 299.99, 15, '2024-12-19'),\r\n('Water Filtration System', 'Clean and safe drinking water', 99.99, 25, '2024-12-30'),\r\n('Electric Bike', 'Eco-friendly transportation', 1199.99, 5, '2024-11-05'),\r\n('Wireless Mouse', 'Reliable and ergonomic', 19.99, 200, '2024-11-16'),\r\n('Adjustable Dumbbells', 'Space-saving fitness solution', 199.99, 20, '2024-11-27'),\r\n('Neck Massager', 'Relieve tension and stress', 59.99, 100, '2024-12-09'),\r\n('Smartphone Gimbal', 'Smooth and steady video recording', 99.99, 50, '2024-12-20'),\r\n('Electric Water Kettle', 'Fast boiling with modern design', 29.99, 150, '2024-12-31'),\r\n('Smart Mirror', 'Interactive mirror with built-in assistant', 299.99, 10, '2024-11-06'),\r\n('Pet Tracker', 'GPS tracking for your furry friends', 49.99, 100, '2024-11-17'),\r\n('Smart Toothbrush', 'Improve dental health with smart features', 99.99, 60, '2024-11-28'),\r\n('Mini Dehumidifier', 'Combat humidity in small spaces', 49.99, 50, '2024-12-10'),\r\n('Electric Hand Warmer', 'Stay warm during cold days', 19.99, 200, '2024-12-21'),\r\n('Smart Water Bottle', 'Track your hydration habits', 39.99, 150, '2024-12-22'),\r\n('Portable Speaker', 'Enjoy music anywhere', 79.99, 70, '2024-12-11'),\r\n('Smart Thermostat', 'Automated home temperature control', 129.99, 40, '2024-12-25'),\r\n('Electric Skateboard', 'Eco-friendly transportation alternative', 499.99, 10, '2024-12-26'),\r\n('Wireless Gaming Headset', 'Immersive sound for gaming', 79.99, 50, '2024-12-27');\r\n\r\n\r\n" }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500076,
                        CourseDisplayId = 7,
                        Title = "Querying Data",
                        Slug = "intro-to-sql-querying",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "The <b>SELECT</b> statement is one of the most fundamental and frequently used operations in SQL. It allows you to retrieve data from a table, enabling you to query and view the information stored within your database. It can be customized to fetch specific columns, apply filters, sort results, and even perform complex operations like joins, aggregations, and grouping. Its flexibility makes it a powerful tool for interacting with your data." },
                                }
                            },
                            new Block
                            {
                                Title = "Basic Select statement",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "The most basic form of a SELECT query <b>retrieves all columns from a table</b>. In DB Browser, run the following command in the <b>Execute SQL</b> tab. This query will return all 100 records added in the previous chapter."},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "SELECT * FROM Products"},
                                    new Paragraph { Body = "See the outcome below. Notice there's a pane under the queried data with information about the execution of the query."},
                                    new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c4-ch7-sql-query-result.png"}
                                }
                            },
                            new Block
                            {
                                Title = "Selecting Specific columns",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "Rather than retrieving every column with `*`, <b>you can specify which columns you want</b> to see by naming them. This is useful when you need only specific data from the table."},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "SELECT ProductName, Price FROM products"},
                                     new Paragraph { Body = "Notice only the requested columns are showing."},
                                    new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c4-ch7-sql-query-result-2.png"}
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500077,
                        CourseDisplayId = 8,
                        Title = "Filtering and Ordering Data",
                        Slug = "intro-to-sql-filtering",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {

                            new Block
                            {
                                Title = "Filtering Data with WHERE",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "One of the most powerful features of the <b>SELECT</b> statement is the <b>WHERE</b> clause. This allows you to filter the data returned based on certain conditions. It can be used to retrieve only the rows that meet specific criteria."},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "SELECT ProductName, Price FROM Products\r\nWHERE StockQuantity > 100;"},
                                    new Paragraph { Body = "Running the query above using our dataset <b>should return 21 products</b>. The <b>WHERE StockQuantity > 100</b> condition filters the rows, returning only those where the <b>StockQuantity is greater than 100</b>. You can use various operators in the WHERE clause, such as =, >, <, BETWEEN, IN, LIKE, and more. You can see the number of rows returned by scrolling down the rows or amongst the info in the bottom pane."},
                                    new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c4-ch8-sql-filter.png"},
                                }
                            },
                            new Block
                            {
                                Title = "Sorting Results with ORDER BY",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "You can sort the results of a`SELECT query using the <b>ORDER BY</b> clause. By default, SQL sorts results in ascending order (<b>ASC</b>), but you can also sort in descending order (<b>DESC</b>)."},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "SELECT ProductName, Price, StockQuantity FROM Products\r\nWHERE StockQuantity > 100 \r\nORDER BY Price DESC;"},
                                    new Paragraph { Body = "Run the query above and see if the highest prices will appear first. Also try removing the DESC keyword. In this case the order will be by price ascending, by default."},
                                }
                            },
                            new Block
                            {
                                Title = "Limiting the Number of Results",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "SELECT ProductName, Price FROM Products\r\nWHERE StockQuantity > 100\r\nORDER BY Price DESC\r\nLIMIT 5;"},
                                    new Paragraph { Body = "This limits the number of rows returned to 5. You can adjust this number to suit your needs. This query will return the <b>top 5 products</b> (based on Price) with more than 100 units in stock."},
                                }
                            },
                            new Block
                            {
                                Title = "Eliminate Duplicates",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "The <b>DISTINCT</b> keyword is used to eliminate duplicate rows from the result set. It is useful when you want to retrieve only unique values for a specific column or combination of columns."},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "SELECT DISTINCT StockQuantity FROM Products;"
                                    },
                                    new Paragraph { Body = "Using our data set, this query will return a list of 24 distinct StockQuantity values from the Products table."},
                                }
                            },
                            new Block
                            {
                                Title = "Combining Multiple Conditions",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "<b>You can combine multiple conditions</b> in the WHERE clause using logical operators like AND and OR. This allows you to create more complex filters."},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "SELECT ProductName, Price, StockQuantity FROM Products\r\nWHERE StockQuantity > 100 AND Price < 50;"},
                                    new Paragraph { Body = "This logical operator ensures that both conditions must be true for a row to be included in the result. In this case, the `StockQuantity` must be greater than 100 <b>and</b> the `Price` must be less than 50. This query will return the `ProductName`, `Price`, and `StockQuantity` of 17 products that meet both conditions in our dataset. "},
                                }
                            },
                            new Block
                            {
                                Title = "Exercises",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body =
                                    "<p>✔️ Write a query to find all products with a <b>Price</b> greater than 20.</p>\r\n  " +
                                    "<p>✔️ Write a query to retrieve products that have a <b>StockQuantity</b> between 50 and 200.</p>\r\n  " +
                                    "<p>✔️ Write a query to list all distinct <b>StockQuantity</b> values in the <b>Products</b> table.</p>\r\n  " +
                                    "<p>✔️ Write a query to find the top 3 most expensive products using <b>ORDER BY</b> and <b>LIMIT</b>.</p>\r\n  " +
                                    "<p>✔️ Write a query to retrieve all products with a <b>Price</b> less than 30 or a <b>StockQuantity</b> greater than 300.</p>\r\n  " +
                                    "<p>✔️ Write a query to find all products added to the database after the the 30th of March, 2024, using the <b>DateAdded</b> column.</p>\r\n  " +
                                    "<p>✔️ Write a query to count the number of products with <b>StockQuantity</b> equal to 100 and a <b>Price</b> greater than 50.</p>\r\n  " +
                                    "<p>✔️ Write a query to list all products with <b>StockQuantity</b> greater than 200 and <b>Price</b> between 20 and 80, sorted by <b>Price</b> in ascending order.</p>\r\n  " +
                                    "<p>✔️ Write a query to find all products with <b>StockQuantity</b> less than 150 or a <b>Price</b> greater than 500, and that were added to the database before the the 30th of September, 2024.</p>\r\n  " +
                                    "<p>✔️ Combine the use of <b>WHERE</b>, <b>ORDER BY</b>, and <b>LIMIT</b> to find the top 5 cheapest products that have more than 50 units in stock, were added to the database after the the 1st of June, 2024, and have a <b>Price</b> less than 100.</p>\r\n"
                                    }
                                }
                            },
                        }
                    },
                    new Article
                    {
                        Id = 500078,
                        CourseDisplayId = 9,
                        Title = "Aggregate Functions",
                        Slug = "intro-to-sql-aggregate-functions",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {

                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "Aggregate functions in SQL are essential tools for analyzing and summarizing data. These functions perform calculations on a set of values and return a single result. They are commonly used in combination with the <b>GROUP BY</b> clause but can also work independently. This chapter will introduce key aggregate functions, explain their use cases, and provide examples to help you understand how to use them effectively. Examples include calculating sums, averages, counts, and finding the maximum or minimum values in a column."},
                                }
                            },
                            new Block
                            {
                                Title = "Counting Rows with COUNT",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "The <b>COUNT</b> function is used to count the number of rows or non-null values in a column."},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "SELECT COUNT(*) AS TotalProducts\r\nFROM Products;"},
                                    new Paragraph { Body = "The output for the above query should be a single row with a single Total Products column with the value of 100. Notice we're using an Alias for the first time, using the keyword <b>AS</b> to define a custom name for the column."},
                                }
                            },
                            new Block
                            {
                                Title = "Summing Values with SUM",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "The <b>SUM</b> function adds up all the values in a numeric column."},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "SELECT SUM(Price * StockQuantity) AS TotalCatalogValue\r\nFROM Products\r\n"},
                                    new Paragraph { Body = "The result of this query should be the sum of all products multiplied by their prices. In our data set, this value would be 578079.59."},
                                }
                            },
                            new Block
                            {
                                Title = "Finding Averages with AVG",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "The <b>AVG</b> function calculates the average value of a numeric column."},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "SELECT AVG(Price) AS AveragePrice\r\nFROM Products;\r\n"},
                                    new Paragraph { Body = "The average product price in our catalogue should be 209.44"},
                                }
                            },
                            new Block
                            {
                                Title = "Finding Minimum and Maximum Values",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "The <b>MIN</b> and <b>MAX</b> functions identify the smallest and largest values in a column, respectively."},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "SELECT MIN(Price) AS CheapestProduct, MAX(Price) AS MostExpensiveProduct\r\nFROM Products;"},
                                    new Paragraph { Body = "The result should be two custom columns with the values of 19.99 and 1499.99"},
                                }
                            },
                            new Block
                            {
                                Title = "Combining Aggregate Functions",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "You can use multiple aggregate functions in a single query to get a comprehensive summary."},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "SELECT COUNT(*) AS TotalProducts,\r\n       SUM(Price) AS TotalPrice,\r\n       AVG(Price) AS AveragePrice,\r\n       MIN(Price) AS CheapestProduct,\r\n       MAX(Price) AS MostExpensiveProduct\r\nFROM Products;\r\n"},
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "Unlike SUM or AVG, which require adding up or dividing numbers, MIN and MAX just scan for the smallest or largest value. They're the speediest of aggregate functions and are great for quick stats." }
                                }
                            },
                            new Block
                            {
                                Title = "Exercises",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                        Body = "<ol>\r\n  <li>✔️ Write a query to count the total number of rows in the <b>Products</b> table where the <b>StockQuantity</b> is greater than 50.</li>\r\n  <li>✔️ Write a query to find the total value of the 5  most expensive products by summing the <b>Price</b> multiplied by <b>StockQuantity</b>.</li>\r\n  <li>✔️ Write a query to calculate the average <b>Price</b> of all products added in the last 6 months.</li>\r\n  <li>✔️ Write a query to retrieve the minimum and maximum <b>Date</b> of all products, displaying them in custom columns named <b>EarliestProduct</b> and <b>LatestProduct</b>.</li>\r\n  <li>✔️ Write a query to count how many products have a <b>Price</b> greater than 200.</li>\r\n  <li>✔️ Write a query to find the total value of all products added to the catalog after the 1st of July, 2024, by summing the <b>Price</b> multiplied by <b>StockQuantity</b>.</li>\r\n  <li>✔️ Write a query to calculate the average <b>Price</b> of products with a <b>StockQuantity</b> greater than 100 and less than 300.</li>\r\n  <li>✔️ Write a query to find the total number of products and their total catalog value for products added to the catalog before the 1st of November, 2024.</li>\r\n  <li>✔️ Write a query to retrieve the minimum and maximum <b>Price</b>, the average <b>Price</b>, and the total number of products for the 10 cheapest products.</li>\r\n  <li>✔️ Write a query to calculate the total number of products, total catalog value, average price, and the minimum and maximum prices for products with a <b>Price</b> greater than 100, a <b>StockQuantity</b> less than 500, and added after the 1st of October, 2024.</li>\r\n</ol>\r\n" }
                                }
                            },
                        }
                    },
                    new Article
                    {
                        Id = 500079,
                        CourseDisplayId = 10,
                        Title = "Deleting Data",
                        Slug = "intro-to-sql-deleting",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {

                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "In SQL, the <b>DELETE</b> statement is used to remove data from a table. This operation is crucial when you want to clean up or remove obsolete information. While deleting data is straightforward, it’s important to understand how it works, as it can permanently remove data from your database."}
                                }
                            },
                            new Block
                            {
                                Title = "Deleting Filtered Data",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "The most common use of the `DELETE` statement is to remove specific rows from a table based on a condition. The condition is specified using the `WHERE` clause, which ensures that only the rows matching that condition are deleted. Without a `WHERE` clause, all rows in the table will be deleted. In the query below we will delete products with the specified Ids."},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "DELETE FROM Products\r\nWHERE Id IN (49,59,69,99)"},
                                }
                            },
                            new Block
                            {
                                Title = "Deleting All Rows from a Table",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "If you want to delete all rows in a table, you can use the `DELETE` statement without a `WHERE` clause. This will remove all data from the table but leave the table structure intact, so the table can still be used to insert new data."},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "DELETE FROM Products;"},
                                    new Paragraph { Body = "Be very cautious when using this type of query, as it will erase all data from the table. This is often used for cleaning up tables but should be done with care to avoid losing valuable data."},
                                }
                            },
                            new Block
                            {
                                Title = "Deleting a Table",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "In some cases, you may want to remove an entire table, including both its data and structure. To do this, you can use the `DROP` statement, which completely removes the table from the database."},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "DROP TABLE Products;"},
                                    new Paragraph { Body = "This operation is more drastic than a `DELETE` statement, as it completely removes the table from the database. This is typically used when you no longer need the table or when you're restructuring your database. Once a table is dropped, it can’t be recovered unless you have backups."},
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "Deleting large numbers of rows can affect database performance, especially in tables with many records. If you need to delete millions of rows, consider doing so in smaller batches to avoid locking issues or performance slowdowns." }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500080,
                        CourseDisplayId = 11,
                        Title = "Updating Data",
                        Slug = "intro-to-sql-updating",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {

                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "The <b>UPDATE</b> statement in SQL allows you to modify existing records in a table. Whether you're correcting data, updating prices, or adjusting stock quantities, it's an essential operation for maintaining and adjusting the information stored in your database. Like DELETE, UPDATE should be used with caution to avoid unintended changes."}
                                }
                            },
                            new Block
                            {
                                Title = "Updating With WHERE",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "To update data in a table, you use the `UPDATE` statement, followed by the table name and the `SET` clause to specify which columns should be modified and the new values they should take. To ensure you only update the intended rows, you should always include a `WHERE` clause. If no `WHERE` clause is provided, all rows in the table will be updated."},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "UPDATE Products\r\nSET Price = 19.99 WHERE ProductID = 5;"}
                                }
                            },
                            new Block
                            {
                                Title = "Updating Multiple Columns",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "You can also update multiple columns in a single `UPDATE` statement by separating each column update with a comma."},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "UPDATE Products\r\nSET Price = 29.99, StockQuantity = 50 WHERE ProductID = 5;"},
                                    new Paragraph { Body = "This query will change both the price and stock quantity for the product with <b>ProductID = 5</b>."},
                                }
                            },
                            new Block
                            {
                                Title = "Updating All Rows",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "If you omit the `WHERE` clause, all rows in the table will be updated with the new values specified in the `SET` clause. This can be useful in certain scenarios, but it should be used with caution. Not only it will affect all records, but it could take a long time depending on the number of rows."},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "UPDATE Products\r\nSET StockQuantity = 100;"}
                                }
                            },
                            new Block
                            {
                                Title = "Updating with Complex Conditions",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "You can use more complex conditions in the `WHERE` clause to perform more refined updates. This allows you to target rows based on multiple criteria or conditions."},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "UPDATE Products\r\nSET Price = 9.99 WHERE StockQuantity > 100 AND Price > 20;"},
                                    new Paragraph { Body = "This query will only update the products that meet both conditions (stock quantity greater than 100 and price greater than 20)."},
                                    new Paragraph { Body = "You can also use expressions in the SET clause to dynamically calculate the new values based on the existing data in the table."},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "UPDATE Products\r\nSET Price = Price * 1.1 WHERE StockQuantity > 100;"},
                                    new Paragraph { Body = "This query will increase the price of all products with more than 100 units in stock by 10%."},
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "SQL is faster when you’re precise about which rows to update. For instance, UPDATE Orders SET Status = 'Shipped' WHERE OrderID = 1234 is much faster than scanning an entire table with a vague condition like Status = 'Pending'" }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500081,
                        CourseDisplayId = 12,
                        Title = "Relational Data",
                        Slug = "intro-to-sql-relational-data",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {

                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "In relational databases, relationships between tables are essential for structuring data efficiently. To establish these relationships, we use <b>Foreign Keys</b>, which link records in one table to those in another. These relationships help maintain data integrity and allow for more efficient queries and operations on the database."}
                                }
                            },
                            new Block
                            {
                                Title = "Creating Two Tables",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "Let's extend the database we created earlier by adding a new table for product categories and one for reviews of products. Each product will belong to a category, which means we will establish a relationship between the Products table and the new <b>Categories</b> table. Each review will have a mandatory ProductId."},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "DROP TABLE Products;\r\n\r\nCREATE TABLE Categories (\r\n    CategoryID INTEGER PRIMARY KEY AUTOINCREMENT,\r\n    CategoryName TEXT NOT NULL\r\n);\r\n\r\nCREATE TABLE Products (\r\n    ProductID INTEGER PRIMARY KEY AUTOINCREMENT,\r\n    ProductName TEXT NOT NULL,\r\n    Price REAL NOT NULL,\r\n    StockQuantity INTEGER NOT NULL,\r\n    CategoryID INTEGER NOT NULL,\r\n    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)\r\n    ON DELETE CASCADE\r\n    ON UPDATE CASCADE\r\n);\r\n\r\nCREATE TABLE Reviews (\r\n    ReviewId INT PRIMARY KEY,\r\n    ProductId INT NOT NULL,\r\n    ReviewText NVARCHAR(500),\r\n    Rating INT,\r\n    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)\r\nON DELETE CASCADE\r\n    ON UPDATE CASCADE\r\n);"},
                                    new Paragraph { Body = "\U0001f7e2 <b>FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)</b>: This establishes the foreign key relationship. It tells the database that the CategoryID in the Products table refers to the CategoryID in the Categories table. This ensures that every product is linked to a valid category. A similar foreign key is created in the Reviews table, linking it to Products."},
                                    new Paragraph { Body = "\U0001f7e2 <b>ON DELETE CASCADE</b>: If a category is deleted from the Categories table, all products associated with that category (i.e., having the same CategoryID) will be automatically deleted from the Products table."},
                                    new Paragraph { Body = "\U0001f7e2 <b>ON UPDATE CASCADE</b>: If the CategoryID in the Categories table is updated, the corresponding CategoryID in the Products table will automatically be updated as well."},
                                }
                            },
                            new Block
                            {
                                Title = "What is a Foreign Key?",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "A foreign key is a column or combination of columns in one table that refers to the primary key of another table. In our example, CategoryID in the Products table is a foreign key that points to CategoryID in the Categories table. The foreign key enforces referential integrity by ensuring that every CategoryID in the Products table matches a valid CategoryID in the Categories table."}
                                }
                            },
                            new Block
                            {
                                Title = "Cascading behaviors",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "Cascading behaviors are rules that determine what happens to the related rows when a change is made to the parent table. For example, if you delete a category, should all the products in that category also be deleted automatically? Or should the foreign key value in the Products table just be set to `NULL`? These behaviors are defined when creating or altering a foreign key."},
                                    new Paragraph {
                                        Body = "There are several cascading options in SQL:"},
                                    new Paragraph { Body = "🔹<b>CASCADE</b>: Automatically updates or deletes the dependent rows in the child table when the corresponding row in the parent table is updated or deleted."},
                                    new Paragraph { Body = "🔹<b>SET NULL</b>: Sets the foreign key in the child table to `NULL` when the corresponding row in the parent table is deleted or updated."},
                                    new Paragraph { Body = "🔹<b>SET DEFAULT</b>: Sets the foreign key in the child table to its default value when the corresponding row in the parent table is deleted or updated."},
                                    new Paragraph { Body = "🔹<b>NO ACTION</b>: No action is taken on the dependent rows when the corresponding row in the parent table is deleted or updated. If a dependent row violates referential integrity, an error is thrown."},
                                    new Paragraph { Body = "🔹<b>RESTRICT</b>: Similar to `NO ACTION`, but this ensures that no changes to the parent table will be allowed if there are dependent rows in the child table."},
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "With the schema defined above, a product cannot exist without a category. If you try to delete a record in the Categories table, and there's a product associated with it, you'll get an error. The same is true for deleting products that have reviews associated with them." },
                                     new Paragraph { Body = "Click in <b>View Source Code</b> below to see a script to populate the tables with 5 categories, 100 products and 20 reviews."}
                                }
                            },
                            new Block
                            {
                                IsCourseCodePage = true,
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       IsCode = true,
                                       Body = "INSERT INTO Categories (CategoryName)\r\nVALUES \r\n    ('Electronics'),\r\n    ('Apparel'),\r\n    ('Home & Kitchen'),\r\n    ('Health & Beauty'),\r\n    ('Sports & Outdoors');\r\n" },
                                    new Paragraph {
                                       IsCode = true,
                                       Body = "-- Electronics (CategoryID = 1)\r\nINSERT INTO Products (ProductName, Price, StockQuantity, CategoryID) VALUES\r\n('Wireless Earbuds', 59.99, 150, 1),\r\n('Smartphone Case', 14.95, 300, 1),\r\n('Bluetooth Speaker', 39.99, 200, 1),\r\n('4K Monitor', 299.99, 80, 1),\r\n('Gaming Mouse', 49.90, 120, 1),\r\n('Laptop Sleeve', 25.50, 180, 1),\r\n('Noise Cancelling Headphones', 199.99, 70, 1),\r\n('USB-C Charger', 29.99, 250, 1),\r\n('Portable SSD 1TB', 89.95, 60, 1),\r\n('LED Desk Lamp', 23.75, 150, 1),\r\n('Action Camera', 149.99, 50, 1),\r\n('Smartwatch', 129.99, 110, 1),\r\n('VR Headset', 249.99, 40, 1),\r\n('WiFi Router', 99.95, 90, 1),\r\n('Streaming Device', 49.95, 130, 1),\r\n('Keyboard (Mechanical)', 89.99, 100, 1),\r\n('Webcam HD', 39.99, 200, 1),\r\n('Smartphone Tripod', 19.95, 180, 1),\r\n('Fitness Tracker', 74.90, 140, 1),\r\n('Power Bank', 39.50, 160, 1);\r\n\r\n-- Apparel (CategoryID = 2)\r\nINSERT INTO Products (ProductName, Price, StockQuantity, CategoryID) VALUES\r\n('Mens Cotton T-Shirt', 19.99, 220, 2),\r\n('Womens Athletic Leggings', 29.99, 180, 2),\r\n('Unisex Hoodie', 49.95, 150, 2),\r\n('Baseball Cap', 15.99, 250, 2),\r\n('Running Shoes', 89.95, 100, 2),\r\n('Winter Scarf', 25.00, 120, 2),\r\n('Denim Jacket', 79.90, 75, 2),\r\n('Leather Belt', 34.95, 130, 2),\r\n('Sunglasses', 49.99, 200, 2),\r\n('Dress Shirt', 39.95, 90, 2),\r\n('Womens Summer Dress', 44.99, 140, 2),\r\n('Ankle Socks (Pack of 5)', 12.95, 300, 2),\r\n('Mens Shorts', 24.50, 190, 2),\r\n('Raincoat', 59.95, 70, 2),\r\n('Beanie Hat', 17.95, 160, 2),\r\n('Sports Bra', 29.99, 150, 2),\r\n('Flip-Flops', 12.95, 210, 2),\r\n('Casual Pants', 49.99, 120, 2),\r\n('Womens Blouse', 34.99, 140, 2),\r\n('Sleepwear Set', 39.99, 160, 2);\r\n\r\n-- Home & Kitchen (CategoryID = 3)\r\nINSERT INTO Products (ProductName, Price, StockQuantity, CategoryID) VALUES\r\n('Ceramic Dinner Set (16 pcs)', 59.95, 90, 3),\r\n('Non-Stick Frying Pan', 29.95, 120, 3),\r\n('Memory Foam Pillow', 24.95, 140, 3),\r\n('Kitchen Utensil Set', 39.95, 110, 3),\r\n('Electric Kettle', 44.95, 100, 3),\r\n('Bath Towel Set', 49.99, 130, 3),\r\n('Air Fryer', 99.99, 75, 3),\r\n('Wall Clock', 29.95, 150, 3),\r\n('Essential Oil Diffuser', 34.95, 90, 3),\r\n('Indoor Plant Pot Set', 21.99, 200, 3),\r\n('LED String Lights', 18.95, 240, 3),\r\n('Table Lamp', 39.99, 100, 3),\r\n('Toaster Oven', 69.95, 80, 3),\r\n('Laundry Basket', 24.95, 140, 3),\r\n('Throw Blanket', 29.99, 180, 3),\r\n('Reusable Food Containers (Set of 5)', 19.95, 160, 3),\r\n('Pressure Cooker', 89.99, 60, 3),\r\n('Water Filter Pitcher', 34.99, 110, 3),\r\n('Wall Art Canvas', 49.90, 95, 3),\r\n('Ironing Board', 44.99, 85, 3);\r\n\r\n-- Health & Beauty (CategoryID = 4)\r\nINSERT INTO Products (ProductName, Price, StockQuantity, CategoryID) VALUES\r\n('Vitamin C Serum', 29.95, 120, 4),\r\n('Shampoo & Conditioner Set', 25.99, 140, 4),\r\n('Body Lotion', 19.95, 200, 4),\r\n('Electric Toothbrush', 49.95, 90, 4),\r\n('Hair Dryer', 59.90, 80, 4),\r\n('Facial Cleansing Brush', 39.95, 100, 4),\r\n('Eye Cream', 34.95, 110, 4),\r\n('Lip Balm (Pack of 3)', 12.95, 250, 4),\r\n('Yoga Mat', 29.99, 180, 4),\r\n('Protein Powder', 49.95, 100, 4),\r\n('Herbal Tea Sampler', 24.90, 160, 4),\r\n('Essential Oil Kit', 44.90, 80, 4),\r\n('Makeup Organizer', 34.95, 130, 4),\r\n('Massage Roller', 27.95, 150, 4),\r\n('Hand Sanitizer Gel (3 Pack)', 14.95, 220, 4),\r\n('Organic Face Mask', 19.90, 140, 4),\r\n('Travel Toiletry Bag', 24.95, 170, 4),\r\n('Sleep Aid Supplement', 39.99, 90, 4),\r\n('Foot Spa Massager', 69.95, 70, 4),\r\n('Bamboo Toothbrushes (Pack of 4)', 16.99, 190, 4);\r\n\r\n-- Sports & Outdoors (CategoryID = 5)\r\nINSERT INTO Products (ProductName, Price, StockQuantity, CategoryID) VALUES\r\n('Camping Tent (2-person)', 99.95, 60, 5),\r\n('Hiking Backpack', 89.95, 70, 5),\r\n('Stainless Steel Water Bottle', 24.95, 200, 5),\r\n('Cycling Gloves', 19.95, 150, 5),\r\n('Resistance Bands Set', 29.95, 180, 5),\r\n('Portable Hammock', 49.99, 90, 5),\r\n('Fishing Rod Combo', 79.99, 50, 5),\r\n('Binoculars', 59.95, 80, 5),\r\n('Running Belt Pouch', 17.95, 130, 5),\r\n('Jump Rope', 12.95, 240, 5),\r\n('Inflatable Kayak', 199.95, 30, 5),\r\n('Trekking Poles', 39.95, 100, 5),\r\n('Outdoor Lantern', 29.99, 140, 5),\r\n('Golf Balls (Pack of 12)', 34.95, 160, 5),\r\n('Picnic Blanket', 21.95, 200, 5),\r\n('Sports Water Jug', 19.99, 180, 5),\r\n('Sunscreen Spray', 16.95, 170, 5),\r\n('Basketball', 29.99, 120, 5),\r\n('Beach Umbrella', 44.95, 75, 5),\r\n('Camping Cookware Set', 49.90, 85, 5);\r\n" },
                                    new Paragraph {
                                       IsCode = true,
                                       Body = "INSERT INTO Reviews (ReviewId, ProductId, ReviewText, Rating) VALUES\r\n(1, 1, 'Great clarity and comfortable fit for workouts.', 5),\r\n(2, 1, 'Battery lasts long, good value for the price.', 4),\r\n(3, 4, 'Crisp resolution, excellent for editing videos.', 5),\r\n(4, 4, 'Sleek design, but needs better cable management.', 4),\r\n(5, 5, 'Responsive and smooth control for gaming.', 4),\r\n(6, 11, 'Takes stunning action shots during outdoor hikes.', 5),\r\n(7, 13, 'Comfortable headset with amazing immersion.', 5),\r\n(8, 13, 'Slight motion blur on fast scenes but overall solid.', 4),\r\n(9, 15, 'Setup was easy, and performance is reliable.', 4),\r\n(10, 20, 'Compact and fast-charging power bank, travel friendly.', 5),\r\n(11, 23, 'Warm hoodie, perfect for chilly evenings.', 4),\r\n(12, 27, 'Quality leather belt, durable buckle.', 5),\r\n(13, 31, 'Excellent heat distribution, non-stick works well.', 5),\r\n(14, 38, 'Lovely aroma, feels calming after a long day.', 4),\r\n(15, 41, 'Skin feels smoother after daily use.', 5),\r\n(16, 53, 'Comfortable, lots of room for gear.', 5),\r\n(17, 53, 'Weatherproof and sturdy, great for trail hikes.', 4),\r\n(18, 55, 'Keeps my drink cold for hours, lightweight bottle.', 5),\r\n(19, 59, 'Quick to inflate, great quality material.', 4),\r\n(20, 63, 'Easy to clean and ideal for camping meals.', 5);\r\n" }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500082,
                        CourseDisplayId = 13,
                        Title = "Joins",
                        Slug = "intro-to-sql-joins",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {

                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "One of the most powerful features of SQL is the ability to combine data from multiple tables using <b>joins</b>. In relational databases, data is often spread across different tables, and using joins allows you to retrieve and display this data in a more meaningful way. This chapter will explore the different types of joins, how they work, and when to use them."},
                                }
                            },
                            new Block
                            {
                                Title = "Inner Join",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "An <b>inner join</b> retrieves only the rows where there is a match in both tables. If a record in the first table has no corresponding record in the second table, it is excluded from the results. The is the default if no join type is specified."},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "SELECT * FROM Products\r\nINNER JOIN Reviews\r\nON Products.CategoryID = Reviews.ProductId;"},
                                    new Paragraph { Body = "In our case running this query will return all products, since the CategoryId foreign key is <NOT NULL</b>"},
                                    new Paragraph { Body = "🔹<b>SELECT</b>: In the SELECT part when using JOIN, since we have multiple tables, we have to specify which table the column belongs to."},
                                    new Paragraph { Body = "🔹<b>INNER JOIN Categories</b>: This part tells SQL to join the Products table with the Categories table."},
                                    new Paragraph { Body = "🔹<b>ON Products.CategoryID = Categories.CategoryID🔹</b>: This is the condition that defines how the tables should be joined. The query will match rows in Products where the <b>CategoryID</b> field matches the <b>CategoryID</b> in the Categories table." },
                                    new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c4-ch14-sql-inner-join.png"},
                                    new Paragraph { Body = "Notice only 20 rows were returned. All with products that contained a review. If a product contains more than one review, it will be repeated." },
                                },
                            },
                            new Block
                            {
                                Title = "Left Join",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "A left join (or <b>left outer join</b>) retrieves all rows from the <b>left table</b> (the table listed first in the query) and the matching rows from the <b>right table</b> (the table listed second). If there is no match, the result will still include all rows from the left table, but with NULL values for columns from the right table."},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "SELECT * FROM Products \r\nLEFT JOIN Reviews\r\nOn Products.ProductID = Reviews.ProductId"},
                                    new Paragraph { Body = "<b>LEFT JOIN Products</b>: This means that all records from the Categories table will be returned, even if they don’t have a matching Product. If there’s no matching ProductId, the ProductName will be NULL."},
                                    new Paragraph { Body = "Before running the query above, create an insert statement for a new category. Supposing you have added a Books category, the result of the the left join will show this: "},
                                    new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c4-ch14-sql-left-join.png"}
                                }
                            },
                            new Block
                            {
                                Title = "Right Join",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "A right join (or right outer join) works the opposite way to a left join. It retrieves all rows from the right table and the matching rows from the left table. If there’s no match, the result <b>will still include all rows from the right table</b> with NULL values for columns from the left table."},
                                     new Paragraph {
                                        IsCode = true,
                                        Body = "SELECT \r\n    Products.ProductName,\r\n    Reviews.ReviewText\r\nFROM \r\n    Reviews\r\nRIGHT JOIN \r\n    Products\r\nON \r\n    Reviews.ProductId = Products.ProductId;"},
                                    new Paragraph {
                                        Body = "Here we're joining reviews with products and selecting all reviews. It will show the twenty reviews plus the 80 products without reviews."},
                                     new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c4-ch14-sql-right-join.png"}
                                }
                            },
                            new Block
                            {
                                Title = "Full Join (Full Outer Join)",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "A full join (or full outer join) returns <b>all rows from both the left and right tables</b>. If there’s a match between the tables, the corresponding rows are combined. If there’s no match, the result will include NULL values for columns in the table that doesn't have a match."},
                                     new Paragraph {
                                        IsCode = true,
                                        Body = "SELECT * FROM Products\r\nFULL OUTER JOIN Categories\r\nON Products.CategoryID = Categories.CategoryID;\r\n"},
                                    new Paragraph {
                                        Body = "This means that all records from <b>both the Products and Categories tables</b> will be returned, even if they don’t have a match in the other table. If there’s no match, the corresponding columns from the other table will be NULL."},
                                    new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c4-ch14-sql-full-join.png"}
                                }
                            },
                            new Block
                            {
                                Title = "Summary",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c4-ch14-sql-join-summary.png"}
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "Join Types Are Like Relationships: SQL joins can be compared to different types of relationships. A LEFT JOIN is like an open-minded friend who listens to your stories even if you don’t return the favor. A RIGHT JOIN is the opposite: it listens to your stories but only shares their own if you’ve shared first. An INNER JOIN only cares about the stories you both agree on—no story without the other!" }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500083,
                        CourseDisplayId = 14,
                        Title = "Relationships",
                        Slug = "intro-to-sql-relationships",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {

                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "Let's include two more tables. The <b>Orders</b> table will track individual orders and <b>OrderProducts</b> will allow us to track products in an order."},
                                     new Paragraph {
                                        IsCode = true,
                                        Body = "CREATE TABLE Orders (\r\n    OrderID INTEGER PRIMARY KEY AUTOINCREMENT,\r\n    OrderDate TEXT NOT NULL,\r\n    CustomerName TEXT NOT NULL\r\n);\r\n\r\nCREATE TABLE OrderProducts (\r\n    OrderID INTEGER,\r\n    ProductID INTEGER,\r\n    Quantity INTEGER NOT NULL,\r\n    PRIMARY KEY (OrderID, ProductID),\r\n    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON DELETE CASCADE,\r\n    FOREIGN KEY (ProductID) REFERENCES Products(ProductID) ON DELETE CASCADE\r\n);\r\n"},
                                      new Paragraph { Body = "And let's seed data for both tables:"},
                                     new Paragraph {
                                        IsCode = true,
                                        Body = "INSERT INTO Orders (OrderDate, CustomerName) VALUES\r\n('2025-08-01', 'Alice Nguyen'),\r\n('2025-08-02', 'Bruno Silva'),\r\n('2025-08-03', 'Chloe Dubois'),\r\n('2025-08-04', 'Daniel Okafor'),\r\n('2025-08-05', 'Emma Tan');"},
                                     new Paragraph {
                                        IsCode = true,
                                        Body = "INSERT INTO OrderProducts (OrderID, ProductID, Quantity) VALUES\r\n(1, 1, 2),\r\n(1, 2, 1),\r\n(2, 3, 1),\r\n(2, 4, 2),\r\n(3, 5, 1),\r\n(3, 6, 1),\r\n(4, 7, 3),\r\n(4, 8, 1),\r\n(5, 9, 2),\r\n(5, 10, 1);"},
                                }
                            },
                            new Block
                            {
                                Title = "One-To-One",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "Let's say we had a table called ProductDetails, which linked back to the product table and would prevent the product table from being bloated. A product can only have one 'Product Detail'. And a 'Product Detail' in its turn can only have one product. We call this a <b>One-To-One Relationship</b>"},
                                },
                            },
                            new Block
                            {
                                Title = "One-To-Many",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "In our database, each Product belongs to one Category (via the CategoryID foreign key). <b>Each Category can have multiple products</b>. This is called a <b>One-To-Many Relationship</b> and it's the most common type of relationship."},
                                },
                            },
                            new Block
                            {
                                Title = "Many-to-Many",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "A single order can contain multiple products, and a single product can be part of many different orders. This creates a <b>many-to-many relationship</b> between Orders and Products."},
                                    new Paragraph {
                                        Body = "So <b>why do we need a join table</b> for this type of relationship? A relational table can only directly represent one-to-many or one-to-one relationships. A many-to-many relationship (e.g., students enrolled in courses) requires a third table to connect the two. Without a join table, you'd have to duplicate rows or embed arrays, which would complicate things a lot. For example, if we put multiple orderIds in a product row (for example with a comma-separated string) it will be much harder to query and to work with, in general."}
                                },
                            },
                            new Block
                            {
                                Title = "Composite Keys",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "In the OrderProducts table, we are using a <b>composite primary key</b>, which means the combination of multiple columns is used as a unique identifier for each row. For each combination of OrderID and ProductID, there can only be one row in the OrderProducts table. This prevents multiple entries of the same product in an order. For example, if an order has three products, there will be three rows in the OrderProducts table, one for each product in the order."},
                                    new Paragraph {
                                        Body = "The combination of OrderID and ProductID <b>ensures that each product in an order is unique</b> (no duplicate entries for the same product within the same order)."}
                                }
                            },
                            new Block
                            {
                                Title = "Example of a Many to Many Query",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "To find all the products ordered in a particular order:"},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "SELECT Products.ProductName, OrderProducts.Quantity\r\nFROM Products\r\nJOIN OrderProducts ON Products.ProductID = OrderProducts.ProductID\r\nWHERE OrderProducts.OrderID = 1;\r\n"},
                                    new Paragraph {
                                        Body = "This query joins the Products and OrderProducts tables, matching ProductID, and retrieves all products with their quantities for OrderID = 1."},
                                    new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c4-ch15-sql-many-query.png"},
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "A one-to-many relationship is like a parent with many children. The parent (the \"one\" side) can have many children (the \"many\" side), but each child can only have one parent. For example, a Category can have many Products, but each Product belongs to only one Category. In a family, each person (e.g., a cousin) can have multiple cousins, and each cousin can also have multiple cousins. So, the relationship is reciprocal and can involve many-to-many interactions." }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500084,
                        CourseDisplayId = 15,
                        Title = "Group By",
                        Slug = "intro-to-sql-groupby",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {

                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "The <b>GROUP BY</b> clause is a powerful feature in SQL that allows you to aggregate data into groups based on the values in one or more columns. It is commonly used alongside aggregate functions such as <b>COUNT, SUM, AVG, MAX, and MIN</b> to perform calculations on grouped data. This chapter will explain how to use GROUP BY, why it's useful, and provide detailed examples for various use cases."},

                                }
                            },
                            new Block
                            {
                                Title = "Syntax of Group By",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "To find all the products ordered in a particular order we use this structure:"},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "SELECT column_name, aggregate_function(column_name)\r\nFROM table_name\r\nGROUP BY column_name;\r\n"}
                                }
                            },
                            new Block
                            {
                                Title = "Example 1: Counting the Number of Products in Each Category",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "This query groups the products by category and counts how many products belong to each category."},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "SELECT CategoryID, COUNT(*) AS ProductCount\r\nFROM Products\r\nGROUP BY CategoryID;\r\n"},
                                    new Paragraph {
                                        Body = "🔹<b>CategoryId</b>: The column we want to group data by.\r\n" +
                                        "<br><b>🔹Count(*)</b>: The aggregate function applied to the data.\r\n" +
                                        "<br><b>🔹GROUP BY</b>: Specifies the column(s) to group the rows.\r\n"}
                                }
                            },
                            new Block
                            {
                                Title = "Example 2: Calculating the Total Quantity Ordered for Each Product Id",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "This query calculates the total quantity of each product ordered, grouped by ProductID"},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "SELECT ProductID, SUM(Quantity) AS TotalQuantityOrdered\r\nFROM OrderProducts\r\nGROUP BY ProductID;\r\n"}
                                }
                            },
                            new Block
                            {
                                Title = "Example 3: Calculating the Total Quantity Ordered for Each Product Name",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "In this slightly more advanced query we first join the tables before grouping the products by their names."},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "SELECT Products.ProductName AS Name, SUM(op.Quantity) AS TotalQuantity\r\nFROM OrderProducts op\r\nJOIN Products ON op.ProductID = Products.ProductID\r\nGROUP BY Products.ProductName;"}
                                }
                            },
                            new Block
                            {
                                Title = "Example 4: Count of Total Money Spent Per Category",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "Here we are joining both the Products and Categories to OrderProducts and displaying the Category name along with the Sum of all product prices multiplied by quantity sold. We're also using aliases (OP, C, P) to save some typing"},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "SELECT \r\n    C.CategoryName,\r\n    SUM(OP.Quantity * P.Price) AS TotalMoneySpent\r\nFROM OrderProducts OP\r\nJOIN Products P ON OP.ProductID = P.ProductID\r\nJOIN Categories C ON P.CategoryID = C.CategoryID\r\nGROUP BY C.CategoryName;\r\n"}
                                }
                            },
                            new Block
                            {
                                Title = "Example 5: Grouping by Price Range",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "Here it gets even more interesting. We're creating custom rows conditionally. Depending on the price, we count a product as a part of a custom row with the help of the <b>CASE</b> keyword."},
                                    new Paragraph {
                                        IsCode = true,
                                        Body = "SELECT \r\n    CASE \r\n        WHEN P.Price < 25 THEN 'Under $25'\r\n        WHEN P.Price BETWEEN 10 AND 50 THEN '$25–$50'\r\n        ELSE 'Over $50'\r\n    END AS PriceRange,\r\n    COUNT(*) AS ProductCount\r\nFROM Products P\r\nGROUP BY PriceRange;"}
                                }
                            },
                        }
                    },
                    new Article
                    {
                        Id = 500085,
                        CourseDisplayId = 16,
                        Title = "Database Design",
                        Slug = "intro-to-sql-design",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {

                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "Proper database design is key for efficient data management and application performance. This chapter explains when to create tables, how to decide relationships between them, and how to structure your database to meet business needs effectively."},
                                    new Paragraph { Body = "Keep in mind that database design is a vast topic, with several books written about it. We'll just scratch the surface to give you some tools for designing simple relational databases. "},

                                }
                            },
                            new Block
                            {
                                Title = "When to Create Tables",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "A table should represent a <b>single, logical entity</b> in your business domain. For example, In an eCommerce system, <b>Products, Categories and Orders</b> are distinct entities that require separate tables. Avoid combining unrelated data into one table, as this leads to redundancy and difficulties in querying."},
                                    new Paragraph {
                                        Body = "Ask yourself these questions: Does this data describe a specific entity? If yes, create a table. Will this data need to relate to other entities? If yes, determine relationships (e.g., one-to-many, many-to-many)."}
                                }
                            },
                            new Block
                            {
                                Title = "Fact vs Dimension Tables",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "In database design—especially in data warehousing—fact tables and dimension tables serve distinct but complementary roles. Here's a clear breakdown:"},
                                     new Paragraph {
                                        IsPicture = true,
                                        PictureUrl = "c4-ch16-sql-fact-dimension.png"},
                                    new Paragraph {
                                        Body = "Think of a fact table as a spreadsheet of transactions—each row is a sale, a click, or a shipment. The dimension tables are like lookup sheets that explain what each product is, who the customer was, and when it happened."}
                                }
                            },
                            new Block
                            {
                                Title = "Structuring Tables for Scalability",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "When designing tables, <b>think beyond the immediate data needs</b>. Ask: Will this structure still work if the business grows tenfold? For example, storing customer addresses directly in the Customers table might seem fine at first—but what if customers have multiple shipping addresses? In that case, a separate Addresses table linked by a foreign key to Customers ensures flexibility and avoids duplication."},
                                    new Paragraph {
                                        Body = "Use primary keys to uniquely identify each row, and foreign keys to enforce relationships between tables. This not only <b>maintains data integrity</b> but also improves query performance by allowing the database engine to optimize joins and lookups."},
                                }
                            },
                             new Block
                            {
                                Title = "Normalization vs. Practicality",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "<b>1NF</b>: <i>Eliminate repeating groups—each field should contain atomic values</i>. <b>Example</b>: A Customers table originally has columns like Phone1, Phone2, Phone3. <b>Fix</b>: Create a separate CustomerPhones table with one row per phone number, linked by CustomerID. <b>Why</b>: This makes phone numbers atomic and allows unlimited numbers per customer."},
                                    new Paragraph { Body = "<b>2NF</b>: <i>Ensure that all non-key attributes are fully dependent on the primary key</i>.  <b>Example</b>: A CourseEnrollments table has StudentID, CourseID, and StudentName. <b>Fix</b>: Move StudentName to the Students table, since it depends only on StudentID, not the full composite key. <b>Why</b>: Ensures that all non-key attributes depend on the whole primary key."},
                                    new Paragraph { Body = "<b>3NF</b>: <i>Remove transitive dependencies—non-key attributes should not depend on other non-key attributes</i>.  <b>Example</b>: A Products table includes CategoryID and CategoryName. <b>Fix</b>: Move CategoryName to a separate Categories table. <b>Why</b>: CategoryName depends on CategoryID, not directly on ProductID."},
                                    new Paragraph { Body = "However, over-normalization can lead to excessive joins and complexity. In reporting-heavy systems, it's sometimes better to denormalize selectively for performance. For example, storing a CategoryName directly in the Products table might be acceptable if categories rarely change and you need fast access."},
                                }
                            },
                              new Block
                            {
                                Title = "Exercises",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "📚 <b>Design a Library Database</b>. Create tables for Books, Authors, and Genres. Decide how to model the many-to-many relationship between books and authors."},
                                    new Paragraph { Body = "🏫 <b>Build a Student Enrollment System</b>. Design tables for Students, Courses, and Enrollments. Include fields like enrollment date and grade."},
                                    new Paragraph { Body = "🏢<b>Create a Real Estate Schema. Model Homes, Customers, and Sales and Rentals</b>. Include rental dates and return status. Think about how to track overdue rentals."},
                                    new Paragraph { Body = "🍽️<b>Design a Restaurant Ordering System</b>. Create tables for MenuItems, Orders, and OrderItems. Use a join table to link orders to multiple menu items."},
                                    new Paragraph { Body = "🗨️<b>Model a Chat App Database</b>. Design tables for Users, Workouts, and Exercises. Each workout can include multiple exercises, and each user can log multiple workouts."},
                                    new Paragraph { Body = "📉Choose one or more of the systems above and draw a <a href='https://www.youtube.com/watch?v=JYZPdU5F2iM' target='_blank'> <b><u>Entity Relationship Diagram</u></b></a>"},
                                }
                            },
                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph {
                                       BackgroundColor="#1C236D",
                                       FontColor="#FFF",
                                       Body = "Instead of creating a Status or Type table for simple, finite options (like Pending, Completed, Cancelled), use enums or a predefined column with constraints. Reserve a separate table only if these values are dynamic or need additional attributes." }
                                }
                            }
                        }
                    },
                    new Article
                    {
                        Id = 500086,
                        CourseDisplayId = 17,
                        Title = "Conclusion",
                        Slug = "intro-to-sql-conclusion",
                        Description = "",
                        Area = Area.Course,
                        ExperiencePoints = 1,
                        Blocks = new List<Block>
                        {

                            new Block
                            {
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "Congratulations! You've complete the Intro To SQL course and should now be able to create your own databases and query and modify them. You've also learned what to think about when designing a database schema. What relationships should you use? Which entities need to be represented for your business case?"},
                                    new Paragraph { Body = "As .NET/C# developers it's often the case that we jump straight into Entity Framework without understanding what's happening behind the scenes. This course should provide a good foundation to understand the queries that EF is generating. "},
                                    new Paragraph { Body = "Needless to say, you'll be better equipped to work in companies that don't use Entity Framework, but instead opted for ADO.NET or Dapper, which gives you more control of your queries. Now you can definitely add SQL to your CV!"},

                                }
                            },
                            new Block
                            {
                                Title = "What to do from here?",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "We can't stress enough the importance of getting comfortable with SQL. That will only come with a lot of practice. We recommend you get into the habit of completing SQL Challenges. We have a <a href='dashboard/challenges' target='_blank'><b><u>challenges section</b></u></a> in our platform, powered by <a href='http://' target='_blank'><b><u>Code Wars</b></u></a>. Other strong platforms for SQL are <a href='https://leetcode.com/' target='_blank'><b><u>Leet Code</b></u></a> and <a href='https://www.sql-practice.com/' target='_blank'><b><u>SQL Practice</b></u></a>." }
                                }
                            },
                            new Block
                            {
                                Title = "Advanced Topics",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "Here's a list of topics you can use as a reference if you'd like to continue studying SQL while we don't release an advanced course:"},
                                    new Paragraph { Body = "🔸<b>Common Table Expressions (CTEs)</b>: Temporary named result sets used within a query."},
                                    new Paragraph { Body = "🔸<b>Recursive Queries</b>: Use CTEs to traverse hierarchical structures (e.g. categories, comments)."},
                                    new Paragraph { Body = "🔸<b>Set Operations</b>: UNION, INTERSECT, EXCEPT — combine or compare result sets."},
                                    new Paragraph { Body = "🔸<b>Pivoting and Unpivoting</b>: Transform rows into columns (PIVOT) and vice versa (UNPIVOT)."},
                                    new Paragraph { Body = "🔸<b>CASE Statements</b>: Conditional logic inside queries."},
                                    new Paragraph { Body = "🔸<b>Advanced JOIN Techniques</b>: FULL OUTER JOIN, CROSS JOIN, SELF JOIN."},
                                    new Paragraph { Body = "🔸<b>Subqueries (Correlated and Non-Correlated)</b>: Embed queries inside SELECT, FROM, or WHERE."},
                                    new Paragraph { Body = "🔸<b>EXISTS vs IN vs JOIN</b>: Different ways to filter based on related data."},
                                    new Paragraph { Body = "🔸<b>NULL Handling</b>: IS NULL, COALESCE, NULLIF, IFNULL."},
                                }
                            },
                            new Block
                            {
                                Title = "Feedback",
                                Paragraphs = new List<Paragraph>
                                {
                                    new Paragraph { Body = "Please let us know how we went! If something doesn't work, or you saw typos, errors or if you found it too easy, too hard, or even if it's perfect for you, drop your opinion on the feedback channel in <a href='https://discord.com/invite/aDMDET8ywB' target='_blank'>our Discord Server</a>.\r\n\r\nThanks for going through the course! We hope you enjoyed it and see you in the next one! 🙏"}
                                }
                            },
                        }
                    }
                }
        };
    }
}
