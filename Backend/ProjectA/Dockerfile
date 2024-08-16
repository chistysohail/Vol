# Use the .NET SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory
WORKDIR /app

# Copy the project files using adjusted relative paths
COPY Backend/ProjectA/ProjectA.csproj ProjectA/
COPY Backend/SharedLibrary/SharedLibrary.csproj SharedLibrary/

# List the files to check if they are copied correctly
RUN ls -la /app

# Restore the dependencies
RUN dotnet restore ProjectA/ProjectA.csproj

# Copy the entire source code of ProjectA and SharedLibrary
COPY Backend/ProjectA/. ProjectA/
COPY Backend/SharedLibrary/. SharedLibrary/

# Build the project
RUN dotnet build ProjectA/ProjectA.csproj -c Release -o /app/build

# Use the .NET runtime image to run the project
FROM mcr.microsoft.com/dotnet/runtime:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/build .
ENTRYPOINT ["dotnet", "ProjectA.dll"]

#To Build from Vol 
#Vol>docker build -t projecta-image111 -f Backend/ProjectA/Dockerfile .