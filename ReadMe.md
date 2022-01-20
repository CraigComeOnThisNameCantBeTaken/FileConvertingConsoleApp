# Usage
I have approached this task as though it was a high priority application. Perhaps the first feature that will grow into a larger system.

Currently data is read from csv files located in the sln folder. This could be easily changed to be a console input but to quickly run this seemed the easiest.

Type in the name in the console eg data.csv and then the type you would like to convert to eg xml or json.

## Design
The sln has been developed with a seperation between the console and the application. The application has space to add more types of converters with a factory to map the conversion types to the converters.

Currently files are persisted to the file system however this could be changed. Support could be added for multiple persistance types such as a database if desired. I also abstracted the OS file system which I like to do for testing reasons.