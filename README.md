# SIMDoku
SIMDoku is my personal training project where I explore different patterns, frameworks, databases and other things.
Functionality wise it is a simple document management system that tracks the location of physical documents within physical folders (somewhat) and saves digitalized copies of them in some kind of storage. 

My second goal for this Project is that it someday may help people understand how to get from one point to another, like from WinForms to WPF or from Desktop to Mobile or from Windows only to cross plattform. I'll try my best to write down every important choice that was made and explain how new things work. You'll find these within the `explanation.md` files which will be within each project.
## Contribution
If you'd like to help me on my way to become the ".NET God" that I'll definitly never be, feel free to open up Issues for suggestions, or blatant errors that I've made. I'm grateful for everyone who takes their time to help me get better. You'll even get mentioned at the bottom of this very Readme and within the apps About page (as soon as it gets one).

If you like this project so much, that you even use it productively and you're missing a feature, feel free to Implement them and send me a pull-request.

## Current Project
### Initial Implementation & Features
- [x]Simple data management system
  - [x] JSON based
  - [ ] Simple Database object based on `List<T>` or `Dicitonary<T,T>`
  - [x] Encrypt files so that I can back them up and sync them with the cloud easyily
- [ ] Simple GUI with WinForms that does it's job.
  - [ ] Create a TagTextBox Control
  - [ ] Either use `TreeView` or create custom `AccordeonControl` as Group and/or folder menu
  - [ ] Big table that filters based on search (either Tags or full-text)
- [ ] Keep data access, business logic and GUI as far apart as possible with service locator or IoC-Container
- [ ] Implement as much as possible with .NET Standard 2.0
- [ ] Implement all the Features
  - [ ] Track physical folders and their documents
  - [ ] Save digital copies of documents (mostly Pictures at this point)
  - [ ] Grouping of documents and/or folders
  - [ ] Groups can have multiple folders, and folders can contain multiple groups
  - [ ] File can be part of multiple groups but only be in one folder
  - [ ] Tagging of groups, folders and documents 
  - [ ] Dynamic expansion of tags
  - [ ] Easy to use GUI


## Future Projects
These are the features that I want to explore/implement in the future. These are in no particular order
- WPF Implementation with strict MVVM and nicer GUI (Animations! Modern look!)
   - Maybe even with some UWP adventures for that shiny acrylic feature of Fluent Design (XAML Islands)
- Abstracted DataAccess Layer for all the data storages
  - SQLite and Access Implementations
  - MySQL, SQL Server and Oracle Implementations (Nope, I will not go into StoredProcedure territory)
  - Implementation for NoSQL Databases (Feel free to give me suggestions)
- Using Entity Framework Core for advanced data handling
- Xamarin.Forms Implementations
  - Android, iOS and UWP. 
  - Maybe add a document scanner for a seamless workflow
    - Needs same or better document recognition as Office Lens
  - `Xamarin.Forms.Plattform.GTK` and `Xamarin.Forms.Plattform.MacOS` for full cross plattform experience
    - Also take a look at `Xamarin.Forms.Plattform.WPF`. Except for WinForms all GUI could be written once then
- Switch from .NET 4.8 to .NET Core 3.0 after it reached RTM status
  - This means both the WinForms and WPF Implementation, if possible
- Create an ASP.NET Core WebAPI REST service that the application can get the data from
- Create an ASP.NET Core Website with all the features the app holds
- Make everything easy to intall & use
  - Upload Apps to stores, create Installers, build packages
- Unit-Testing and Test Driven Design


## Finished Projects
Someday you'll be able to see the finished Projects below.


## C# Heroes
Someday you'll be able to see all the people that helped me with this project below.

## Used Libraries & Packages
Here you'll see all the libraries and NuGet Packages that I've used below.
 - Newtonsoft.JSON