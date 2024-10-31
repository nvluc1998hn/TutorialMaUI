﻿using Maui.GoogleMaps;
using Maui.GoogleMaps.Android.Factories;
using System.Collections.Concurrent;
using AndroidBitmapDescriptor = Android.Gms.Maps.Model.BitmapDescriptor;

namespace TutorialMaUI.Platforms.Android
{
    public sealed class CachingNativeBitmapDescriptorFactory : IBitmapDescriptorFactory
    {
        private readonly ConcurrentDictionary<string, AndroidBitmapDescriptor> _cache = new();
        public AndroidBitmapDescriptor ToNative(BitmapDescriptor descriptor, IMauiContext mauiContext)
        {
            var defaultFactory = DefaultBitmapDescriptorFactory.Instance;

            if (!string.IsNullOrEmpty(descriptor.Id))
            {
                var cacheEntry = _cache.GetOrAdd(descriptor.Id, _ => defaultFactory.ToNative(descriptor, mauiContext));
                return cacheEntry;
            }

            return defaultFactory.ToNative(descriptor, mauiContext);
        }
    }
}
