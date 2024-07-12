# dotnet nuget locals -c all

# Add this option to view detail output
# -v d
dotnet pack -c Release -t:Clean,Rebuild src/libs/Mapbox.Maui/Mapbox.Maui.csproj --output $PWD/nugets 