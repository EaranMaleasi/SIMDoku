# Solution-wide Explanations
Here you will find Explanations to the patterns, libraries and packages used, that affect the whole project.

## Using an IoC-Container
In order to keep everything apart, or in other words, achieve "loose coupling", I intend to use an IoC-Container. This may be extra work in the beginning that maybe doesn't seem to pay off, but in later stages when things like Unit-Tests or the MVVM-Pattern in WPF is introduced, this will make things considerably easier.

### Using Autofac as IoC-Container
I decided to use Autofac as IoC Container. This doesn't stem from a comparison between all possibilities but the fact, that I used it before at my workplace and am familiar with it. If you have concerns, suggestions or other Ideas in this regard feel free to create an Issue and tell me about it.