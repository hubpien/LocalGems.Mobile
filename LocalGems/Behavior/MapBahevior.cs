using Syncfusion.Maui.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGems.Behavior
{
    public class MapsBehavior : Behavior<ContentPage>
    {
        private MapTileLayer tileLayer;
        private MapMarker marker;

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.tileLayer = bindable.FindByName<MapTileLayer>("tileLayer");
            this.marker = bindable.FindByName<MapMarker>("CurrentLocationMarker");
            GetLocation();
        }

        private async void GetLocation()
        {
            try
            {
                PermissionStatus status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

                Location location = await Geolocation.Default.GetLastKnownLocationAsync();

                if (location != null)
                {
                    tileLayer.Center = new MapLatLng(location.Latitude, location.Longitude);

                    marker.Latitude = location.Latitude;
                    marker.Longitude = location.Longitude;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            this.tileLayer = null;
            this.marker = null;
        }
    }
}
