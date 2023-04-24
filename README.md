# website-status-app-worker-service

## Description

This demo project is a .NET worker windows background service that checks if a website is working using an HTTP client and logs information to a log.txt file.

## Table of Contents

- [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)


## Installation

To install this project, follow these steps:

1. Clone the repository.
2. Open the solution in Visual Studio.
3. Build the solution.
4. Run the application.

## Usage

To use this project, follow these steps:

1. Open the worker service class.
2. Change the "webUrl" variable to the URL of the website you want to check.
3. Publish the project as a Windows Service to a folder.
4. Open Powershell as an administrator and install the service using the command ```SC.exe create websiteHealthStatus binpath= C:\temp\workerservice\[service name].exe start= auto```
5. Open the Services app on windows and start the service you just installed.
6. Check the log file in the log folder to see logs.
7. run ```SC.exe delete [service name]``` on powershell to delete.


## Contributing

To contribute to this project, follow these steps:

1. Fork this repository.
2. Create a branch: `git checkout -b <branch_name>`.
3. Make your changes and commit them: `git commit -m '<commit_message>'`.
4. Push to the original branch: `git push origin <project_name>/<location>`.
5. Create the pull request.


