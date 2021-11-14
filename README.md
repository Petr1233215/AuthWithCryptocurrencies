# AuthWithCryptocurrencies
Для того чтобы проект заработал нужно в классе: AuthWithCryptocurrencies.Helpers.ExhangeHelper - вписать ключ в переменную: API_KEY, авторизации для сайта: pro-api.coinmarketcap.com

ЗАДАНИЕ:
Необходимо создать веб-приложение, которое подсоединяется к API CoinMarketCap (https://pro.coinmarketcap.com/api/v1, для работы с ним нужно зарегистрироваться с Free аккаунтом).

Функциональные требования:

Регистрация.
Регистрация в системе включает в себя поля: email, пароль, подтверждение пароля. Email должен быть уникальным в системе. Система должна проверять валидность email и совпадение паролей.

Вход в систему.
Вход в систему осуществляется с использованием логина (email) и пароля.

Страница “Котировки криптовалют”.
Зарегистрированный пользователь видит страницу с таблицей котировок криптовалют.
Таблица содержит столбцы: название, символ, логотип, текущая цена в USD, насколько цена изменилась за последний час и 24 часа, капитализации в USD (market cap), время обновления данных. Данные по котировкам загружаются по API CoinMarketCap.
Опционально. Добавить фильтрацию и сортировку для колонок, постраничную навигацию.

Технические требования:
Asp.net MVC
MS SQL
Entity Framework
