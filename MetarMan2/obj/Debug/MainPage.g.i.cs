﻿

#pragma checksum "C:\Users\cpros_000\Documents\Visual Studio 2012\Projects\MetarMan2\MetarMan2\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D11368CAA560B3500A2C79793E048A41"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;

namespace MetarMan2
{
    partial class MainPage : Windows.UI.Xaml.Controls.Page
    {
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private Windows.UI.Xaml.Controls.Button AddButton; 
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private Windows.UI.Xaml.Controls.GridView MainGrid; 
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private bool _contentLoaded;

        [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent()
        {
            if (_contentLoaded)
                return;

            _contentLoaded = true;
            Application.LoadComponent(this, new System.Uri("ms-appx:///MainPage.xaml"), Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
 
            AddButton = (Windows.UI.Xaml.Controls.Button)this.FindName("AddButton");
            MainGrid = (Windows.UI.Xaml.Controls.GridView)this.FindName("MainGrid");
        }
    }
}



