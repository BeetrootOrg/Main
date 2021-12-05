#!/bin/sh
find ./ -name "*.sln" | xargs --max-lines=1 -i sh -c 'echo "Build {}" && \
	dotnet restore {} && \
	dotnet build --no-restore {} && \
	dotnet publish --no-restore --no-build {} && \
	echo "Build Finished {}"'