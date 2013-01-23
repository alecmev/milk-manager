using System;
using System.Diagnostics;
using System.Resources;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace NotEdible
{
    public partial class App : Application
    {
        public static PhoneApplicationFrame RootFrame { get; private set; }

        public App()
        {
            UnhandledException += ApplicationUnhandledException;

            InitializeComponent();
            InitializePhoneApplication();
            InitializeLanguage();

            //HSBColor tmpHSB = HSBColor.FromRGB((App.Current.Resources["PhoneAccentBrush"] as SolidColorBrush).Color);
            //tmpHSB.B = 24;
            //Resources.Add("PhoneAccentDarkBrush", new SolidColorBrush(tmpHSB.ToRGB()));
            //Resources.Add("PhoneAccentDarkBrush", new SolidColorBrush(Colors.Black));

            if (Debugger.IsAttached)
            {
                //Application.Current.Host.Settings.EnableFrameRateCounter = true;
                //Application.Current.Host.Settings.EnableRedrawRegions = true;
                PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            }
        }

        private void ApplicationLaunching(object sender, LaunchingEventArgs e)
        {
        }

        private void ApplicationActivated(object sender, ActivatedEventArgs e)
        {
        }

        private void ApplicationDeactivated(object sender, DeactivatedEventArgs e)
        {
        }

        private void ApplicationClosing(object sender, ClosingEventArgs e)
        {
        }

        private void RootFrameNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (Debugger.IsAttached)
                Debugger.Break();
        }

        private void ApplicationUnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
                Debugger.Break();
        }

        #region Phone application initialization
        private bool phoneApplicationInitialized = false;

        private void InitializePhoneApplication()
        {
            if (phoneApplicationInitialized)
                return;

            RootFrame = new TransitionFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;
            RootFrame.NavigationFailed += RootFrameNavigationFailed;
            RootFrame.Navigated += CheckForResetNavigation;

            phoneApplicationInitialized = true;
        }

        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            if (RootVisual != RootFrame)
                RootVisual = RootFrame;

            RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }

        private void CheckForResetNavigation(object sender, NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Reset)
                RootFrame.Navigated += ClearBackStackAfterReset;
        }

        private void ClearBackStackAfterReset(object sender, NavigationEventArgs e)
        {
            RootFrame.Navigated -= ClearBackStackAfterReset;

            if (e.NavigationMode != NavigationMode.New && e.NavigationMode != NavigationMode.Refresh)
                return;

            while (RootFrame.RemoveBackEntry() != null);
        }
        #endregion

        private void InitializeLanguage()
        {
            try
            {
                RootFrame.Language = XmlLanguage.GetLanguage("en-US");
                FlowDirection flow = FlowDirection.LeftToRight;
                RootFrame.FlowDirection = flow;
            }
            catch
            {
                if (Debugger.IsAttached)
                    Debugger.Break();

                throw;
            }
        }
    }
}