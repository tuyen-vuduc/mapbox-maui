dotnet nuget locals -c all

# Build to trigger gradle process
dotnet build -t:Clean,Rebuild src/qs/MapboxMauiQs/MapboxMauiQs.csproj

dotnet pack -c Release -t:Clean,Rebuild mapbox-maui.sln --output $PWD/nugets