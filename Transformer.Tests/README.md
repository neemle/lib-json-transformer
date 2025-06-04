# Tests for Neemle.Utils.JsonTransformer

## Running Tests

To run tests with code coverage, use the following command:

```bash
./test-report.sh
```

This script performs the following actions:

1. Cleans previous test results
2. Runs tests with generation of a coverage file in Cobertura format
3. Finds the generated coverage file in a folder with a UUID name
4. Creates an HTML report with code coverage results

## Viewing Coverage Report

After running the tests, an HTML report will be created in the directory:

```
./TestResults/CoverageReport/
```

Open the `index.html` file in your browser to view a detailed report on code coverage.

## Adding New Tests

When adding new tests, follow these rules:

1. Use the same folder structure as in the main project
2. Name test classes using the pattern `[ClassName]Tests`
3. Use xUnit for writing tests
4. Try to achieve maximum code coverage

## Current Code Coverage

Current code coverage can be checked in the generated HTML report after running the tests.
