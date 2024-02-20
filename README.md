<a name="readme-top"></a>

<!-- PROJECT LOGO -->
<br />
<div align="center">
<h3 align="center">Employee Report Creator</h3>
  <p align="center">
    Тестовое задание
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
        <li>
          <a href="#task-conditions">Task Conditions</a>
          <ul>
            <li><a href="#part-1">Part 1. Design a database</a></li>
            <li><a href="#part-2">Part 2. Develop an application</a></li>
          </ul>
        </li>
      </ul>
    </li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

Для запуска проекта измините строку подключения к oracle в `app.config`

```
<add key="ConnectionString" value="User Id=YOUR_USER_ID;password=YOUR_PASSWORD;Data Source=YOUR_DATA_SOURCE" />
```
Создайте пользователя в oracle если у вас его еще нет
```
CREATE USER YOUR_USER_ID IDENTIFIED BY YOUR_PASSWORD
```
И даем ему права
```
GRANT CONNECT, RESOURCE, DBA TO YOUR_USER_ID
```

<p align="right">(<a href="#readme-top">back to top</a>)</p>



### Built With

* [![WPF][wpf-shield]][wpf-url]
* [![Oracle][oracle-shield]][oracle-url]
  
<p align="right">(<a href="#readme-top">back to top</a>)</p>



### Task Conditions

<p align="right">(<a href="#readme-top">back to top</a>)</p>



#### Part 1. Design a database

Design a database for the following subject area:
1) Employee (name, subdivision, position, salary)
2) Subdivision (name, city)
  
DBMS: Oracle
DDL with initial filling of data (3-4 entries per table)

<p align="right">(<a href="#readme-top">back to top</a>)</p>



#### Part 2. Develop an application

Write software in C# (.NET Framework 4.8 + MVVMLight + EpPlus + Oracle Management Data Provider)
Application Type: WPF Desktop Application (MVVM).

The main screen form is a list one.
Control elements (from left to right, top to bottom): search text field, Load button, Print button, Close button, DataGrid in ReadOnly mode, StatusBar.
The search text field affects the selection of the fields “Name”, “Name of division”, “City”, Case-Insentive
The "Load" button loads data according to the filter conditions, loading is performed in the background (using BackgroundWorker, disable controls during loading, replace DataGrid with a loading icon).
The "Print" button prints the displayed data to an .xlsx file using EpPlus.
The "Close" button closes the application.
The DataGrid displays all data except the keys.
The StatusBar displays the number of records, or the corresponding record if the selection is empty.

An additional screen form (Detail), opens by double-clicking on an entry in the DataGrid, modal.
Allows you to edit information about an employee (Name, Division, Position, Salary).
After saving the information, the parent form reloads the information.

The code must comply with generally accepted market quality criteria for code (naming rules, structure, documentation, etc.).

Additions: authorization data can be hardcoded.

<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

Alexander Petko - [@alex_petko](https://t.me/alex_petko) - petko.alexander.work@gmail.com

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
<!-- https://shields.io -->
<!-- https://simpleicons.org -->
[wpf-shield]: https://img.shields.io/badge/WPF-%23512BD4?style=for-the-badge&logo=c%23
[wpf-url]: https://learn.microsoft.com/en-us/dotnet/desktop/wpf/overview/?view=netdesktop-8.0
[oracle-shield]: https://img.shields.io/badge/Oracle-%23F56640?style=for-the-badge&logo=Oracle&labelColor=%23F56640
[oracle-url]: https://www.oracle.com/

