using System;
using RadioApp.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceInfoService))]
namespace RadioApp.Droid
{
    public class DeviceInfoService : IDeviceInfoService
    {
        
        public string GetDeviceModel()
        {
            return Android.OS.Build.Model;
        }
    }
}
