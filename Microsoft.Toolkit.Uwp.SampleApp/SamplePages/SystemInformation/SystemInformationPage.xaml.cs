// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Globalization;
using Microsoft.Toolkit.Uwp.Helpers;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.System;

namespace Microsoft.Toolkit.Uwp.SampleApp.SamplePages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SystemInformationPage : Page
    {
        // To get application's name:
        public string ApplicationName => SystemInformation.ApplicationName;

        // To get application's version:
        public string ApplicationVersion => SystemInformation.ApplicationVersion.ToFormattedString();

        // To get the most preferred language by the user:
        public CultureInfo Culture => SystemInformation.Culture;

        // To get operating syste,
        public string OperatingSystem => SystemInformation.OperatingSystem;

        // To get used processor architecture
        public ProcessorArchitecture OperatingSystemArchitecture => SystemInformation.OperatingSystemArchitecture;

        // To get operating system version
        public OSVersion OperatingSystemVersion => SystemInformation.OperatingSystemVersion;

        // To get device family
        public string DeviceFamily => SystemInformation.DeviceFamily;

        // To get device model
        public string DeviceModel => SystemInformation.DeviceModel;

        // To get device manufacturer
        public string DeviceManufacturer => SystemInformation.DeviceManufacturer;

        // To get available memory in MB
        public float AvailableMemory => SystemInformation.AvailableMemory;

        // To get if the app is being used for the first time since it was installed.
        public string IsFirstUse => SystemInformation.IsFirstRun.ToString();

        // To get if the app is being used for the first time since being upgraded from an older version.
        public string IsAppUpdated => SystemInformation.IsAppUpdated.ToString();

        // To get the first version installed
        public string FirstVersionInstalled => SystemInformation.FirstVersionInstalled.ToFormattedString();

        // To get the first time the app was launched
        public string FirstUseTime => SystemInformation.FirstUseTime.ToString(Culture.DateTimeFormat);

        // To get the time the app was launched
        public string LaunchTime => SystemInformation.LaunchTime.ToString(Culture.DateTimeFormat);

        // To get the time the app was previously launched, not including this instance
        public string LastLaunchTime => SystemInformation.LastLaunchTime.ToString(Culture.DateTimeFormat);

        // To get the time the launch count was reset, not including this instance
        public string LastResetTime
        {
            get { return (string)GetValue(LastResetTimeProperty); }
            set { SetValue(LastResetTimeProperty, value); }
        }

        public static readonly DependencyProperty LastResetTimeProperty =
            DependencyProperty.Register(nameof(LastResetTime), typeof(string), typeof(SystemInformationPage), new PropertyMetadata(string.Empty));

        // To get the number of times the app has been launched sicne the last reset.
        public long LaunchCount
        {
            get { return (long)GetValue(LaunchCountProperty); }
            set { SetValue(LaunchCountProperty, value); }
        }

        public static readonly DependencyProperty LaunchCountProperty =
            DependencyProperty.Register(nameof(LaunchCount), typeof(long), typeof(SystemInformationPage), new PropertyMetadata(0));

        // To get the number of times the app has been launched.
        public long TotalLaunchCount => SystemInformation.TotalLaunchCount;

        // To get how long the app has been running
        public string AppUptime => SystemInformation.AppUptime.ToString();

        public SystemInformationPage()
        {
            InitializeComponent();

            RefreshProperties();

            SampleController.Current.RegisterNewCommand("Reset launch count", (sender, args) =>
            {
                SystemInformation.ResetLaunchCount();
                RefreshProperties();
            });
        }

        private void RefreshProperties()
        {
            LaunchCount = SystemInformation.LaunchCount;
            LastResetTime = SystemInformation.LastResetTime.ToString(Culture.DateTimeFormat);
        }
    }
}