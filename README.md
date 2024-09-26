WPF File Viewer
Overview
The WPF File Viewer is a Windows Presentation Foundation (WPF) application that allows users to read and view the contents of XML, JSON, and TXT files from local storage. The application displays the file content in a ListView for easy viewing and interaction.

Features
Read and display content from XML, JSON, and TXT files.
User-friendly interface with a ListView to show file contents.
Simple file selection from local storage.
Supports multiple file formats.
Prerequisites
.NET Framework (version X.X or later)
Visual Studio (version X.X or later)
Getting Started
Installation
Clone the repository:

bash
Sao chép mã
git clone <repository-url>
Open the solution in Visual Studio.

Build the project to restore dependencies.

Usage
Run the application.
Click on the "Open File" button to select a file from your local storage.
Choose an XML, JSON, or TXT file.
The content of the selected file will be displayed in the ListView.
Supported File Formats
XML: Structured data in XML format.
JSON: Data in JavaScript Object Notation format.
TXT: Plain text files.
Code Structure
MainWindow.xaml: The main user interface layout.
MainWindow.xaml.cs: The logic for file handling and displaying data.
FileReader.cs: A helper class for reading different file formats.
Contributing
Contributions are welcome! Please feel free to submit a pull request or open an issue for any suggestions or improvements.

License
This project is licensed under the MIT License - see the LICENSE file for details.

Acknowledgements
WPF Documentation
Json.NET for JSON handling.
