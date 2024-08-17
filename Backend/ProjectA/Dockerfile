######################## Dockerfile if want to build from Vol (\Vol\Backend\ProjectA\Dockerfile) ##################################################################
# Use the .NET SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory
WORKDIR /app

# Copy the project files using paths relative to the Vol directory
COPY Backend/ProjectA/ProjectA.csproj ProjectA/
COPY Backend/SharedLibrary/SharedLibrary.csproj SharedLibrary/
COPY Common/Configuration/config.json Common/Configuration/

# List the files to check if they are copied correctly
RUN ls -la /app

# Restore the dependencies
RUN dotnet restore ProjectA/ProjectA.csproj

# Copy the entire source code of ProjectA, SharedLibrary, and the Common configuration
COPY Backend/ProjectA/. ProjectA/
COPY Backend/SharedLibrary/. SharedLibrary/
COPY Common/. Common/

# Build the project
RUN dotnet build ProjectA/ProjectA.csproj -c Release -o /app/build

# Use the .NET runtime image to run the project
FROM mcr.microsoft.com/dotnet/runtime:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/build .
COPY --from=build /app/Common/Configuration/config.json /app/Common/Configuration/config.json
ENTRYPOINT ["dotnet", "ProjectA.dll"]


#To Build from Vol 
#Vol>docker build -t projecta-image111 -f Backend/ProjectA/Dockerfile .


#C:\dev>docker exec -it 6a84c1f80918 sh
## ls
#Common    ProjectA.deps.json  ProjectA.pdb                 SharedLibrary.deps.json  SharedLibrary.pdb
#ProjectA  ProjectA.dll        ProjectA.runtimeconfig.json  SharedLibrary.dll
## cd Common
## ls
#Configuration
## cd Configuration
## ls
#config.json



###TODO##################### Below commented Dockerfile is to build from Backend (\Vol\Backend\ProjectA\Dockerfile) But its not fully working as its not copying Common folde###############

## Use the .NET SDK image to build the project
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#
## Set the working directory to /app
#WORKDIR /app
#
## Copy the project files needed for restoring dependencies
#COPY ProjectA/ProjectA.csproj ProjectA/
#COPY SharedLibrary/SharedLibrary.csproj SharedLibrary/
#
#
#
## Restore the dependencies
#RUN dotnet restore ProjectA/ProjectA.csproj
#
## Copy the entire source code and necessary resources
#COPY . .
#
## Build the project
#RUN dotnet build ProjectA/ProjectA.csproj -c Release -o /app/build
#
## Use the .NET runtime image to run the project
#FROM mcr.microsoft.com/dotnet/runtime:6.0 AS runtime
#
## Set the working directory to /app in the runtime image
#WORKDIR /app
#
## Copy the build output to the runtime image
#COPY --from=build /app/build .
#
#
## Set the entry point to run the application
#ENTRYPOINT ["dotnet", "ProjectA.dll"]

