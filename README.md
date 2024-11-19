# SeriesRenamer

Консольная программа, которая переименовывает файлы с эпизодами сериала.

До:
```
Lost.S03E01.1080p.OKKO.WEB-DL-SOFCJ.mkv
Lost.S03E02.1080p.OKKO.WEB-DL-SOFCJ.mkv
Lost.S03E03.1080p.OKKO.WEB-DL-SOFCJ.mkv
```

После:
```
S3E1. A Tale of Two Cities.mkv
S3E2. The Glass Ballerina.mkv
S3E3. Further Instructions.mkv
```

## Как запустить

Скачать и установить [.NET 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

Скачать ZIP-архив из последнего [релиза](https://github.com/MolinRE/SeriesRenamer/releases), распаковать.

Запустить файл `SeriesRenamer.exe` или в консоли набрать:
```shell
dotnet SeriesRenamer.dll
```

Следовать инструкциям приложения.

Параметры запуска:
```
-t --test   Запуск без переименовывания файлов.
```