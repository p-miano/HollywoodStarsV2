# Hollywood Stars V2

Hollywood Stars V2 is a web-based application that allows users to manage information about movies and companies in the Hollywood industry. This application is built using ASP.NET Core and includes functionality to manage the relationships between companies and movies.

## Features

- Manage movie information: Add, update, and delete movies.
- Manage company information: Add, update, and delete companies.
- Handle relationships between companies and movies.
- User authentication and session management.

## Technologies

- **ASP.NET Core MVC**: Used for creating the web interface and handling requests.
- **Entity Framework Core**: For database operations and managing data.
- **Bootstrap**: For responsive and user-friendly UI design.
- **Identity**: For managing user authentication and authorization.

## How to Run

1. Clone the repository.
2. Open the project in Visual Studio.
3. Set up your database connection string in the `appsettings.json`.
4. Run the migrations using the command `Update-Database` to set up the database schema.
5. Build and run the project on your local machine.

## Screenshots

Include screenshots of your app to give users a visual idea of its interface and functionality.

1. **Home Screen**
   - The main page where users can view basic app information.

2. **Manage Movies**
   - Screen for managing the list of movies.

3. **Manage Companies**
   - Screen for managing the list of companies.

## How it Works

1. Users can browse and manage movies and companies via the application interface.
2. Companies and movies can be connected to each other using the relationship management feature.
3. The application allows authenticated users to create, update, and delete records.
4. User authentication is handled via ASP.NET Identity.

## Files

- **HomeController.cs**: Handles the main logic for routing users to the home and privacy pages.
- **Index.cshtml**: The homepage view that provides links to ASP.NET resources and app features.
- **HollywoodStarsContext.cs**: Defines the database context and relationships for companies and movies.
- **Movie.cs**: The movie model that contains attributes such as movie ID, title, and release year.
- **_Layout.cshtml**: The main layout file that defines the structure and navigation of the application.

## License

This project is open-source and available under the [MIT License](LICENSE).
