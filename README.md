# 

#### By [Will W.](https://wjwat.com/)

#### 

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

## :gear: Setup/Installation & Usage Instructions

TODO: Add instructions for migrations

- [Install the MySQL Community Server & MySQL Workbench](https://dev.mysql.com/downloads/mysql/)
- [Install the .NET 5 SDK](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-c-and-net)
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
- Run `dotnet build HairSalon` in the top level directory of this repo.
- Run `dotnet run --project HairSalon` to get the program running, and the site hosted locally.
- Visit `http://localhost:5000` to try the site out.
  - Please make sure to look at your terminal to determine the port number you should be visiting in your browser. It may change between runs.
  - Ex:
    ```shell
    $ dotnet run --project HairSalon
      Hosting environment: Production
      Content root path: /path/to/HairSalon.Solution/HairSalon
      Now listening on: http://localhost:5000
      Now listening on: https://localhost:5001
      Application started. Press Ctrl+C to shut down.
    ```

## :world_map: Roadmap

## :lady_beetle: Known Bugs

* If any are found please feel free to open an issue or email me at wjwat at
  onionslice dot org

## :warning: License

[MIT License](https://opensource.org/licenses/MIT)

Copyright (c) 2022 Will W. (ｙﾟ 益ﾟ;)ｙ
