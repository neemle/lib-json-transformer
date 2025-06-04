#!/bin/bash

# Exit on error
set -e

echo "Compiling integration test with code trimming mode activated..."

# Clean previous builds
dotnet clean

# Publish with code trimming settings
dotnet publish -c Release -r linux-x64 \
  --self-contained true \
  /p:PublishTrimmed=true \
  /p:TrimMode=link \
  /p:InvariantGlobalization=true \
  /p:OptimizationPreference=Size \
  /p:DebuggerSupport=false \
  /p:PublishSingleFile=true

echo "\nSize of the created executable file:"
ls -lh ./bin/Release/net9.0/linux-x64/publish/Neemle.Utils.JsonTransformer.IntegrationTest

echo "\nRunning integration test..."
./bin/Release/net9.0/linux-x64/publish/Neemle.Utils.JsonTransformer.IntegrationTest

echo "\nIntegration test completed!"