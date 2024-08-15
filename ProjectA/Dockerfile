# Use the .NET SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory
WORKDIR /app

# Copy the solution file and the necessary project files
COPY Vol.sln ./
COPY SharedLibrary/SharedLibrary.csproj SharedLibrary/
COPY ProjectA/ProjectA.csproj ProjectA/

# Restore the dependencies
RUN dotnet restore ProjectA/ProjectA.csproj

# Copy the entire source code of ProjectA and SharedLibrary
COPY ProjectA/. ProjectA/
COPY SharedLibrary/. SharedLibrary/

# Build the project
RUN dotnet build ProjectA/ProjectA.csproj -c Release -o /app/build

# Use the .NET runtime image to run the project
FROM mcr.microsoft.com/dotnet/runtime:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/build .
ENTRYPOINT ["dotnet", "ProjectA.dll"]


#Vol>docker build -t projecta-image -f ProjectA/Dockerfile .