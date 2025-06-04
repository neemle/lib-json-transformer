#!/bin/bash

# Додати шлях до глобальних інструментів .NET до PATH
export PATH="$HOME/.dotnet/tools:$PATH"

# Очистити попередні результати тестів
rm -rf TestResults

dotnet clean

dotnet build

dotnet test

# Запустити тести з покриттям коду
dotnet test Transformer.Tests/Transformer.Tests.csproj -c Release --no-restore \
  /p:CollectCoverage=true \
  /p:CoverletOutputFormat=cobertura

# Знайти згенерований файл покриття
COVERAGE_FILE=$(find Transformer.Tests/TestResults -name "coverage.cobertura.xml" -type f | head -1)

# Створити директорію для звіту, якщо вона не існує
mkdir -p ./TestResults/CoverageReport

# Перевірити, чи знайдено файл покриття
if [ -z "$COVERAGE_FILE" ]; then
  echo "Помилка: Файл покриття не знайдено"
  exit 1
fi

# Згенерувати HTML-звіт з результатів тестування
reportgenerator \
  -reports:"$COVERAGE_FILE" \
  -targetdir:"./TestResults/CoverageReport" \
  -reporttypes:Html

echo "Звіт про тести створено в директорії ./TestResults/CoverageReport з використанням $COVERAGE_FILE"
