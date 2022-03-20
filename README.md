# Factory Engineer & Machine Tracker

#### By [Will W.](https://wjwat.com/)

#### Implement a vendor & ord... wait, I mean a engineer & machine tracker! Now with database migrations!

## :computer: Technologies Used

* C#
* .NET 5.0
* ASP.NET Core
* Razor
* Entity Framework Core
* MySQL
* dotnet script REPL
* HTML
* CSS | [YACCK](https://github.com/sphars/yacck)
* JQuery

## :memo: Description

Use many-to-many relationships to build an app that allows you to see objects,
the relationships between objects, and modify or delete those objects &
relationships.

## :gear: Setup/Installation & Usage Instructions

TODO: Add instructions for migrations

- [Install the MySQL Community Server & MySQL Workbench](https://dev.mysql.com/downloads/mysql/)
- [Install the .NET 5 SDK](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-c-and-net)
- Install the [dotnet-ef](https://docs.microsoft.com/en-us/ef/core/cli/dotnet) tool with this command:

  ```dotnet tool install --global dotnet-ef```

- [Clone this
  repository](https://docs.github.com/en/repositories/creating-and-managing-repositories/cloning-a-repository)
  to your device
- Import the SQL database located in the top level of this project
  - Using `MySQL Workbench`
    - Open `MySQL Workbench`
    - Under `Import Options` select `Import from self-contained file`.
    - Navigate to the directory where you've downloaded this repository & select `will_watkins.sql`
    - Click OK
    - Go to the tab called `Import Progress` and click `Start Import` at the bottom right
    - Reopen the `Schemas` tab under `Navigator`
    - Right click and select `Refresh All` to verify that the database `will_watkins` appears
- Create `appsettings.json` in the top level of this repo
  - Copy the contents of the code below into this file. *Make sure to change the password to the password you used to setup your MySQL server*
  ```JSON
  {
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=will_watkins;uid=root;pwd=<PASSWORD>;"
    }
  }
  ```
- [Using your
  terminal](https://www.freecodecamp.org/news/how-you-can-be-more-productive-right-now-using-bash-29a976fb1ab4/)
  navigate to the directory where you have cloned this repo.
- Run `dotnet build Factory` in the top level directory of this repo.
- Once the project has been built run `dotnet ef database update --project Factory` to create the database necessary to run the app.
- Run `dotnet run --project Factory` to get the program running, and the site hosted locally.
- Visit `http://localhost:5000` to try the site out.

## :page_facing_up: Notes

- Work with datetime objects to add shifts to Engineers, and uptime tracking to
  machines.
- Validate models server side as well as client side.
- Catch exceptions when attempting to create rows with duplicate keys rather than
  checking before hand and skipping creation if found.

## :lady_beetle: Known Bugs

* If any are found please feel free to open an issue or email me at wjwat at
  onionslice dot org

## :warning: License

[MIT License](https://opensource.org/licenses/MIT)

Copyright (c) 2022 Will W. (ｙﾟ 益ﾟ;)ｙ
