﻿#pragma checksum "..\..\Garden.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "72134838DDCA21A42B61895192E74542E9964ACEDDB3866BEE4288A6944881A2"
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
    /// Garden
    /// </summary>
    public partial class Garden : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\Garden.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Viewbox Contener1;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Garden.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Space1;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Garden.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Cell1;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Garden.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ContentCell1;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\Garden.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem ContentName;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\Garden.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox FloverSelect1;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\Garden.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Flover1;
        
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
            System.Uri resourceLocater = new System.Uri("/RegisterBotanicGarden;component/garden.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Garden.xaml"
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
            
            #line 9 "..\..\Garden.xaml"
            ((RegisterBotanicGarden.Garden)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Contener1 = ((System.Windows.Controls.Viewbox)(target));
            return;
            case 3:
            this.Space1 = ((System.Windows.Controls.Grid)(target));
            
            #line 12 "..\..\Garden.xaml"
            this.Space1.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Grid_MouseDown);
            
            #line default
            #line hidden
            
            #line 12 "..\..\Garden.xaml"
            this.Space1.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Grid_MouseUp);
            
            #line default
            #line hidden
            
            #line 12 "..\..\Garden.xaml"
            this.Space1.MouseMove += new System.Windows.Input.MouseEventHandler(this.Grid_MouseMove);
            
            #line default
            #line hidden
            
            #line 12 "..\..\Garden.xaml"
            this.Space1.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Grid_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 31 "..\..\Garden.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.AddCells);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 32 "..\..\Garden.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.RemoveCells);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Cell1 = ((System.Windows.Controls.Border)(target));
            return;
            case 7:
            this.ContentCell1 = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.ContentName = ((System.Windows.Controls.MenuItem)(target));
            
            #line 52 "..\..\Garden.xaml"
            this.ContentName.Click += new System.Windows.RoutedEventHandler(this.AddFlovers);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 53 "..\..\Garden.xaml"
            ((System.Windows.Controls.MenuItem)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.After_MouseEnter);
            
            #line default
            #line hidden
            
            #line 53 "..\..\Garden.xaml"
            ((System.Windows.Controls.MenuItem)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.After_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 10:
            this.FloverSelect1 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 54 "..\..\Garden.xaml"
            this.FloverSelect1.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.FloverSelect1_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 56 "..\..\Garden.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.RemoveFlovers);
            
            #line default
            #line hidden
            return;
            case 12:
            this.Flover1 = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

