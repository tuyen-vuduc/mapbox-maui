dotnet nuget locals -c all
dotnet pack -c Release -t:Clean,Rebuild mapbox-maui.sln --output $PWD/nugets