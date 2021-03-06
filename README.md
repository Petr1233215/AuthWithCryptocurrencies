# AuthWithCryptocurrencies
# Условия работы приложения
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

# Что можно улучшить
1. Добавить страницу настройки, для того чтобы ключ к Api пользователь мог менять через UI
2. Сделать логирование ошибок
3. Доделать CQRS Mediatr - чтобы констроллеры не обрабатывали действия, а перенаправляли в другие классы
4. Добавить Роли пользователям
5. Подумать над разделением UI части от бэка, например использовать React
6. Для аутентификации использовать JWt-token
7. ??? (Добавить новые страницы, API там большой)

#Ссылка на документацию
https://coinmarketcap.com/api/documentation/v1/#operation/getV1CryptocurrencyListingsHistorical
