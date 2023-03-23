# Mapbox for MAUI

A dedicated library and starting sample for integrating Mapbox into your MAUI application.

## Setup

1/ MAPBOX_DOWNLOADS_TOKEN

All Mapbox libraries required an access token to download them for use. 
Please follow [the guide from Mapbox](https://docs.mapbox.com/android/maps/guides/install/) and go the dashboard of your Mapbox account and grab one.

a/ Android
On Android, we will leverage the gradle way of downloading Mapbox native libraries, please set `MAPBOX_DOWNLOADS_TOKEN` property and put it in `~/.gradle/gradle.properties` as below example

```
MAPBOX_DOWNLOADS_TOKEN=YOUR_MAPBOX_DOWNLOADS_TOKEN
```

b/ iOS
oOn iOS, we will need to edit iOS's CSPROJ file to have `MAPBOX_DOWNLOADS_TOKEN` property as below example.

```
<Project ...>
    ...

	<PropertyGroup>
		<MAPBOX_DOWNLOADS_TOKEN>YOUR_MAPBOX_DOWNLOADS_TOKEN</MAPBOX_DOWNLOADS_TOKEN>
	</PropertyGroup>
    ...
</Project>
```

2/ Android addtional setup
As Mapbox has its own private Gradle repository, we need to add these lines to Android's CSPROJ file.

```
<Project ...>
    ...

	<ItemGroup>
		<GradleRepository Include="https://api.mapbox.com/downloads/v2/releases/maven">
			<Repository>
			maven {
				url 'https://api.mapbox.com/downloads/v2/releases/maven'
				authentication {
					basic(BasicAuthentication)
				}
				credentials {
					// Do not change the username below.
					// This should always be `mapbox` (not your username).
					username = "mapbox"
					// Use the secret token you stored in gradle.properties as the password
					password = MAPBOX_DOWNLOADS_TOKEN
				}
			}
			</Repository>
		</GradleRepository>
	</ItemGroup>

    ...
</Project>
```

2/ YOUR_ACCESS_TOKEN

To display Mapbox Map in your app, you will need another access token which can be easily grabbed by following [the guide from Mapbox](https://docs.mapbox.com/help/getting-started/access-tokens/).

You can set it conventionally in `strings.xml` for Android or in `info.plist` for iOS. Otherwise, you can also set the value in code as the guide from Mapbox documetation.

a/ Android's `strings.xml`
```
<string name="mapbox_access_token">YOUR_MAPBOX_ACCESS_TOKEN</string>
```

b/ iOS's `info.plist`
```
<key>MBXAccessToken</key>
<string>YOUR_MAPBOX_ACCESS_TOKEN</string>
```