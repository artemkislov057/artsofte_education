Чтобы локально запускался backend необходимо:
1. Установить на компьютер dotnet 6.0 (или выше)

https://dotnet.microsoft.com/en-us/download/dotnet/6.0

2. Установить на компьютер СУБД SQL Server Express 2019 LocalDB

https://learn.microsoft.com/ru-ru/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver16

	2.1. В скачанном файле выбираем пункт "Скачать носитель"

	2.2. Выбираем LocalDB и скачиваем

	2.3. Запускаем скачанный файл SqlLocalDB.msi

3. Добавить роли на сервер в базу данных
	
	3.1. Запускаем файл adminWebApi.local.run.bat

	3.2. Открываем браузер и переходим по ссылке https://localhost:7009/swagger/index.html

	3.3. Находим вкладку Roles

	3.4. Кидаем запрос POST /api/roles/default (Добавить используемые на сервере роли (User, Admin))

Теперь можно пользоваться бэкендом локально.

webApi.local.run.bat нужен для локального запуска сервера со всеми нужными для фронтенда запросами

adminWebApi.local.run.bat нужен для управления ролями и другими операциями с базой данных (например, там можно выдать пользователю права на админку, то есть добавлять, изменять, удалять курсы).

fileLoaderApi.local.run.bat нужен для загрузки файлов на сервер