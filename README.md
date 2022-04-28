# MoviesAPI
Разработать решение для просмотра информации о фильмах и актерах.(ASP.NET + Entity Framework + для базы данных можно использовать MS SQL Server, PostgreSQL, SQLite)

Получить список фильмов по алфавитному порядку
GET: api/Sorter/Name

Получить список фильмов по дате выходы в прокат
GET: api/Sorter/Year

Получить список самых популярных фильмов
GET: api/Sorter/Rating

Получить список самых популярных актеров
GET: api/Sorter/ActorRating

Получить список фильмов в которых участвовал актер
GET: api/Select/(Actors Name)

