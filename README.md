# HtmlParser
## Программа для парсинга текста со страницы и нахождения вхождений слов на этой странице
***
### Руководство по запуску программы
***
> Как запустить программу?
* Сама программа располагается в папке bin\Release
* Запуск через WinFormParserHtml.exe
***
### Руководство пользователя
***
> Руководство пользователя
* Для корректной работы программы необходимо заполнить текствое поле Url
* Условие для вводимого url 
    * Url должен начинаться с протокола https или http
    * сайт должен оканчиваться либо на домен либо на файл каталога сервера и не должен оканчиваться на слеш '/'(см пример)
        * пример правильного url: https://www.simbirsoft.com
        * пример неправильного url: google.com, https://google
    * Не страшно если вы ошиблись с url и нажали кнопку start. Программа вежливо сообщит вам об ошибке
* После ввода url нажать на кнопку start
    * После этого необходимо подождать, время ожидания зависит от объема запрашиваемой страницы и скорости интернета
    * По окончанию работы программа оповестит вас оповещением о завершении работы основного цикла
* Страница будет сохранена в главном каталоге программы в файле html.txt
* Результат работы алгоритма будет в представлении таблиц данных
#### Примеры для тестирования программы
* https://www.simbirsoft.com
* https://ru.stackoverflow.com/questions/1197983/В-react-div-должен-содержать-один-дочерний-элемент
* google.com
* https://ru.wikipedia.org/wiki/Утомлённые_солнцем_2:_Цитадель
