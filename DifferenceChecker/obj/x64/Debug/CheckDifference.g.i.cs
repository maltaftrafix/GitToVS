﻿#pragma checksum "..\..\..\CheckDifference.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "250239192DD29CF0028D57311DA49D6B6DB4AAD3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Xpf.DXBinding;
using DifferenceChecker;
using DifferenceChecker.View;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Trafix.Client.Controls;


namespace DifferenceChecker {
    
    
    /// <summary>
    /// CheckDifference
    /// </summary>
    public partial class CheckDifference : Trafix.Client.Controls.SKWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\CheckDifference.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button compare;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\CheckDifference.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DifferenceChecker.View.DifferencePanelUC pnlOldFile;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\CheckDifference.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DifferenceChecker.View.DifferencePanelUC pnlNewFile;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DifferenceChecker;component/checkdifference.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\CheckDifference.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.compare = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\CheckDifference.xaml"
            this.compare.Click += new System.Windows.RoutedEventHandler(this.Compare_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.pnlOldFile = ((DifferenceChecker.View.DifferencePanelUC)(target));
            return;
            case 3:
            this.pnlNewFile = ((DifferenceChecker.View.DifferencePanelUC)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

