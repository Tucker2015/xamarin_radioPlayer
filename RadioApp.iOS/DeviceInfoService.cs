using System;
using RadioApp.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceInfoService))]
namespace RadioApp.iOS
{
    public class DeviceInfoService : IDeviceInfoService
    {
        public string GetDeviceModel()
        {
            return UIKit.UIDevice.CurrentDevice.Model;
        }
    }
}
