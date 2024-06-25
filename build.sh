dotnet nuget locals -c all

# Build to trigger gradle process
dotnet build -t:Clean,Rebuild src/qs/MapboxMauiQs/MapboxMauiQs.csproj \
    -property:MAPBOX_DOWNLOADS_TOKEN=$MAPBOX_DOWNLOADS_TOKEN

dotnet pack -c Release -t:Clean,Rebuild src/libs/Mapbox.Maui/Mapbox.Maui.csproj \
    --output $PWD/nugets