﻿#pragma checksum "D:\stuff\work\random\NotEdible\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "46592BF11F0AB0EBEB32CB39E8CB12BE"
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
using NotEdible;
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


namespace NotEdible {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.DatePicker GlobalDatePicker;
        
        internal System.Windows.Controls.TextBox SearchBar;
        
        internal System.Windows.Controls.Button SearchButton;
        
        internal System.Windows.Media.ImageBrush SearchButtonImageBrush;
        
        internal System.Windows.Controls.Button AddButton;
        
        internal NotEdible.ListBoxGeneric ProductListBox;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/NotEdible;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.GlobalDatePicker = ((Microsoft.Phone.Controls.DatePicker)(this.FindName("GlobalDatePicker")));
            this.SearchBar = ((System.Windows.Controls.TextBox)(this.FindName("SearchBar")));
            this.SearchButton = ((System.Windows.Controls.Button)(this.FindName("SearchButton")));
            this.SearchButtonImageBrush = ((System.Windows.Media.ImageBrush)(this.FindName("SearchButtonImageBrush")));
            this.AddButton = ((System.Windows.Controls.Button)(this.FindName("AddButton")));
            this.ProductListBox = ((NotEdible.ListBoxGeneric)(this.FindName("ProductListBox")));
        }
    }
}

