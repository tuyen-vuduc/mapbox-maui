using Android.OS;
using Android.Runtime;

namespace MapboxMaui;

internal class CameraOptionsParcelable : Java.Lang.Object, IParcelable
{
    public CameraOptions CameraOptions { get; private set; }

    public CameraOptionsParcelable(CameraOptions cameraOptions)
    {
        this.CameraOptions = cameraOptions;
    }

    public void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
    {
        dest.WriteFloat(CameraOptions.Zoom ?? 0);
        dest.WriteDouble(CameraOptions.Center.Latitude);
        dest.WriteDouble(CameraOptions.Center.Longitude);
        dest.WriteFloat(CameraOptions.Bearing ?? 0);
        dest.WriteFloat(CameraOptions.Pitch ?? 0);
    }

    public int DescribeContents()
    {
        return 0;
    }

    public static readonly IParcelableCreator CREATOR = new XCreator();

    class XCreator : Java.Lang.Object, IParcelableCreator
    {
        public Java.Lang.Object CreateFromParcel(Parcel source)
        {
            var zoom = source.ReadFloat();
            var latitude = source.ReadDouble();
            var longitude = source.ReadDouble();
            var bearing = source.ReadFloat();
            var pitch = source.ReadFloat();

            var cameraOptions = new CameraOptions
            {
                Zoom = zoom,
                Center = new MapPosition(latitude, longitude),
                Bearing = bearing,
                Pitch = pitch,
            };

            return new CameraOptionsParcelable(cameraOptions);
        }

        public Java.Lang.Object[] NewArray(int size)
        {
            return new CameraOptionsParcelable[size];
        }
    }
}
