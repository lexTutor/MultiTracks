## Welcome!

Thank you for checking out this project! Here's how you can get started quickly:

### Getting Started

1. **Clone the Repository:**
   ```
   git clone https://github.com/lexTutor/MultiTracks.git
   ```
   Clone the repository to your local machine to get started.

2. **Open in Visual Studio:**
   - Open the solution file (.sln) in Visual Studio.

3. **Update Packages:**
   - Run the following command in the Package Manager Console to ensure you have the necessary packages:
   ```
   Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
   ```

### Web Application

- **Default Startup Project:**
  - The default startup project is the WebForms project.

- **Default View:**
  - When you run the application, you will land on the `artistDetails.aspx` page, showcasing details about Hillsong Worship, one of my favorite artists.

- **Explore Other Artists:**
  - You can view details of other artists by appending the artist ID to the URL, like this: `/artistDetails.aspx?artistID=172`.

### API Project

- **To Run the API Project:**
  - Set the startup project to the `Multitracks.api` project. Right-click on the project and select "Set as startup project."

- **Run the API:**
  - Press `Ctrl + F5` to run the API project.

### Technical Details

- **Technology Stack:**
  - The API project is built with .NET 6, offering the latest features and performance enhancements.

- **Data Access:**
  - The API leverages Entity Framework 6 (EF6) for all database operations, utilizing a generic repository.
 
- **Infrastructure:**
  - The domain and service layer logic is encapsulated within the  `Core/MTEFDataAccess project`.
  - This design choice promotes separation of concerns and enhances reusability throughout the application.

- **DTO Mapping:**
  - DTO (Data Transfer Object) to Entity mapping is handled seamlessly through Automapper, ensuring efficient communication between layers.

- **Exception Handling:**
  - The API includes a global exception handler to gracefully manage and handle any exceptions that may occur during runtime.

Feel free to explore this application! If you have any questions or feedback, don't hesitate to reach out.