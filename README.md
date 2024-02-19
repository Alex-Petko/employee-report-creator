<a name="readme-top"></a>

<!-- PROJECT LOGO -->
<br />
<div align="center">
<h3 align="center">WpfTest</h3>
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

