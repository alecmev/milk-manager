﻿#pragma checksum "D:\downloads\wp-toolkit\PhoneToolkitSample8\..\PhoneToolkitSample\Samples\ListPickerSample.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E33763216BAE649C07B953A6FFB99B81"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18010
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace PhoneToolkitSample.Samples {
    
    
    public partial class ListPickerSample : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal Microsoft.Phone.Controls.ListPicker PrintInColors;
        
        internal Microsoft.Phone.Controls.ListPicker RegionList;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/PhoneToolkitSample8;component/Samples/ListPickerSample.xaml", System.UriKind.Relative));
            this.PrintInColors = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("PrintInColors")));
            this.RegionList = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("RegionList")));
        }
    }
}
