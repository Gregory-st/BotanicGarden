﻿#pragma checksum "..\..\AddFloversDialog.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B7AE268ABD0A1F9C4CC6BC035154D191A08C2A9BD519CBFFAE8215CBFC0966F2"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using RegisterBotanicGarden;
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


namespace RegisterBotanicGarden {
    
    
    /// <summary>
    /// AddFloversDialog
    /// </summary>
    public partial class AddFloversDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\AddFloversDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox DescriptionFlover;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\AddFloversDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel InfoFlover;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\AddFloversDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel InfoFlover1;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\AddFloversDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox NumberFlover;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\AddFloversDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StatusFlovewer;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\AddFloversDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox DescriptionSoft;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\AddFloversDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border TypeSoft;
        
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
            System.Uri resourceLocater = new System.Uri("/RegisterBotanicGarden;component/addfloversdialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddFloversDialog.xaml"
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
            
            #line 19 "..\..\AddFloversDialog.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cancel);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 20 "..\..\AddFloversDialog.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Done);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DescriptionFlover = ((System.Windows.Controls.ComboBox)(target));
            
            #line 31 "..\..\AddFloversDialog.xaml"
            this.DescriptionFlover.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Select_Flover);
            
            #line default
            #line hidden
            return;
            case 4:
            this.InfoFlover = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.InfoFlover1 = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.NumberFlover = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.StatusFlovewer = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.DescriptionSoft = ((System.Windows.Controls.ComboBox)(target));
            
            #line 70 "..\..\AddFloversDialog.xaml"
            this.DescriptionSoft.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Soft_Select);
            
            #line default
            #line hidden
            return;
            case 9:
            this.TypeSoft = ((System.Windows.Controls.Border)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

