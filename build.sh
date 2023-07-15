dotnet nuget locals -c all
dotnet pack -c Release -t:Clean,Rebuild src/libs/Mapbox.Maui/Mapbox.Maui.csproj --output $PWD/nugets