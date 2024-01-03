# Asprezza Analyzer

Repository containing code for the new tool **Asprezza Analyzer** as described in chapter 9.6 of Sascha Resch's doctoral thesis at LMU Munich

# Main goal of the application

The application was built in order to analyze phonetic asprezza in (Old) Italian verse texts. The texts to be analyzed must be in TEI XML format. The analysis can be easily adjusted as the rules to identify and quantitatively measure phonetic asprezza can be adjusted at runtime of the application.

# Prerequisities

**Asprezza Analyzer** was implemented using .NET Framework 4.7.2 using Visual Studio 2019 (Community Edition) and the programming language C#. Thus. in order to install the programm you need to install .NET 4.7.2 on your (Windows) machine. If you use the setup MSI-file (or the setup.exe) published in this repository under [Setup_Asprezza/Debug](Setup_Asprezza/Debug) or [Setup_Asprezza/Release](Setup_Asprezza/Release), the setup programme should take care of this and other prerequisities such as programming libraries.

# Copyright/References

- HARDEN, Scott W. 2019 –: ScottPlot.NET, https://scottplot.net/. [last visit: 05.11.23].
- MICROSOFT CORPORATION 2021: Visual Studio 2019 version 16.10.0 Release Notes, https://learn.microsoft.com/en-us/visualstudio/releases/2019/release-notes-v16.10#16.10.0. [last visit: 05.11.23].

# Further development/Roadmap

- Update to recent .NET framework 4.8
- Update from Windows Form to WPF framework
- Implement further (statistical) calculations --> can be done after the validity of the software will have been discussed by the academic community
- Improve error handling, implement error logger
- Implement comparison window to compare asprezza of two texts or two textual portions
- Implement different visualization, maybe spatial heat map
- ...
