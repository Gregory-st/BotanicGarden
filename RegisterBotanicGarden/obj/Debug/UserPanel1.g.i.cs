﻿#pragma checksum "..\..\UserPanel1.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BB1573F75BFB3660285BF085382A2AEA736BCB71A34D8C33A0A944B5049F5BB5"
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
    /// UserPanel1
    /// </summary>
    public partial class UserPanel1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 47 "..\..\UserPanel1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel Content1;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\UserPanel1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MenuContent1;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\UserPanel1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Menu1;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\UserPanel1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PersonPage1;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\UserPanel1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TasksPage1;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\UserPanel1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Info1;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\UserPanel1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel Persons1;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\UserPanel1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel Tasks1;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\UserPanel1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchLine3;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\UserPanel1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SearchButton3;
        
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
            System.Uri resourceLocater = new System.Uri("/RegisterBotanicGarden;component/userpanel1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UserPanel1.xaml"
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
            this.Content1 = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 2:
            this.MenuContent1 = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.Menu1 = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\UserPanel1.xaml"
            this.Menu1.Click += new System.Windows.RoutedEventHandler(this.Menu1_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.PersonPage1 = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\UserPanel1.xaml"
            this.PersonPage1.Click += new System.Windows.RoutedEventHandler(this.Pages_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TasksPage1 = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\UserPanel1.xaml"
            this.TasksPage1.Click += new System.Windows.RoutedEventHandler(this.Pages_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Info1 = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.Persons1 = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 8:
            this.Tasks1 = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 9:
            this.SearchLine3 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.SearchButton3 = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

