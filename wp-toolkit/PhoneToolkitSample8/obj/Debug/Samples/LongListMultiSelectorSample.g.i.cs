﻿#pragma checksum "D:\downloads\wp-toolkit\PhoneToolkitSample8\Samples\LongListMultiSelectorSample.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "87F3A3AADDC314EC740FB8AA5EA00B24"
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
    
    
    public partial class LongListMultiSelectorSample : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.Pivot SamplePivot;
        
        internal Microsoft.Phone.Controls.PivotItem MultiselectLbxItem;
        
        internal Microsoft.Phone.Controls.LongListMultiSelector EmailList;
        
        internal Microsoft.Phone.Controls.PivotItem BuddiesPivotItem;
        
        internal Microsoft.Phone.Controls.LongListMultiSelector buddies;
        
        internal Microsoft.Phone.Controls.PivotItem GridModeItem;
        
        internal Microsoft.Phone.Controls.LongListMultiSelector GridSelector;
        
        internal Microsoft.Phone.Controls.PivotItem DataboundPivotItem;
        
        internal Microsoft.Phone.Controls.LongListMultiSelector BoundBuddies;
        
        internal System.Windows.Controls.Grid ZoomGrid;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/PhoneToolkitSample8;component/Samples/LongListMultiSelectorSample.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.SamplePivot = ((Microsoft.Phone.Controls.Pivot)(this.FindName("SamplePivot")));
            this.MultiselectLbxItem = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("MultiselectLbxItem")));
            this.EmailList = ((Microsoft.Phone.Controls.LongListMultiSelector)(this.FindName("EmailList")));
            this.BuddiesPivotItem = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("BuddiesPivotItem")));
            this.buddies = ((Microsoft.Phone.Controls.LongListMultiSelector)(this.FindName("buddies")));
            this.GridModeItem = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("GridModeItem")));
            this.GridSelector = ((Microsoft.Phone.Controls.LongListMultiSelector)(this.FindName("GridSelector")));
            this.DataboundPivotItem = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("DataboundPivotItem")));
            this.BoundBuddies = ((Microsoft.Phone.Controls.LongListMultiSelector)(this.FindName("BoundBuddies")));
            this.ZoomGrid = ((System.Windows.Controls.Grid)(this.FindName("ZoomGrid")));
        }
    }
}
