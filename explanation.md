# Solution-wide Explanations
Here you will find Explanations to the patterns, libraries and packages used, that affect the whole project.

## Using an IoC-Container
In order to keep everything apart, or in other words, achieve "loose coupling", I intend to use an IoC-Container. This may be extra work in the beginning that maybe doesn't seem to pay off, but in later stages when things like Unit-Tests or the MVVM-Pattern in WPF is introduced, this will make things considerably easier.

### Using Autofac as IoC-Container
I decided to use Autofac as IoC Container. This doesn't stem from a comparison between all possibilities but the fact, that I used it before at my workplace and am familiar with it. If you have concerns, suggestions or other Ideas in this regard feel free to create an Issue and tell me about it.

### The Autofac inheritance pipeline
In order to use everything with autofac I decided to use something I call the inheritance pipeline. This pipeline consists of a certain sub namespace within every project, in my case `.Bootstrap`, wherein classes are defined that inherit from the classes further down the inheritance pipeline.

Let's take a look at how this is achieved with WinForms and start from the top:
```csharp
//SIMDoku.WinForms/Bootstrap/WinFormsBootstrapper.cs
using SIMDoku.DataManagement.Bootstrap;
using SIMDoku.FileManagement.Bootstrap;

namespace SIMDoku.WinForms.Bootstrap
{
    public class WinFormsBootstrapper : DataManagementFileBootstrapper
    {
        public WinFormsBootstrapper() : base(FileType.JSON)
        {  }

        public override void RegisterServices()
        {
            base.RegisterServices();
        }
    }
}
```

This is the Bootstrapper of the WinForms project. Here you can see, that it inherits from the `DataManagementFileBootstapper` but also defines the desired file type to use for the FileManagementBootstrapper down the line.
Also it overrides `RegisterServices` which is only needed if it has Services that need to be injected. If you override `RegisterServices` be sure to call the base before registering new services.

Let's go one step down:
```csharp
//SIMDoku.DataManagement/Bootstrap/DataManagementFileBootstrapper.cs
using Autofac;

using SIMDoku.FileManagement;
using SIMDoku.FileManagement.Bootstrap;

namespace SIMDoku.DataManagement.Bootstrap
{
    public class DataManagementFileBootstrapper : FileHandlerBootstrapper
    {
        public DataManagementFileBootstrapper(FileType type) : base(type)
        {   }

        public override void RegisterServices()
        {
            base.RegisterServices();
            Container.RegisterType<FileDataAccess>().As<IDataProvider>().SingleInstance();
        }
    }
}
```
Now we are in the SIMDoku.DataManagement project. Here you can see very much the same. This bootstapper inherits from the one further down and overrides the `RegisterServices` method, but this time also actually registers an actual service. Also the FileType defined in the WinFormsBootstrapper is just passed down to the next 