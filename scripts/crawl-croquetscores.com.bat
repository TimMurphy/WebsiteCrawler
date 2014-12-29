@echo off

pushd ..\src\WebsiteCrawler.Console\bin\Debug

WebsiteCrawler.exe --startUrl "http://www.croquetscores.com" --resultPath "%temp%\crawl-croquetscores.com.json" --waitAfterPageLoad 200

if errorlevel 1 goto finally

start "%temp%\crawl-croquetscores.com.json"

:finally
popd

echo.
echo.
pause