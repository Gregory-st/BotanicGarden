﻿#pragma checksum "..\..\AddTaskDialog.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D12FDAC10BCC6022279F62B373D74107C29211C555C67F5F43D921B296A4425E"
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
    /// AddTaskDialog
    /// </summary>
    public partial class AddTaskDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 60 "..\..\AddTaskDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TypeTasks;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\AddTaskDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TypeTaskAdd1;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\AddTaskDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TargetTask1;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\AddTaskDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MessageTask1;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\AddTaskDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox MainUser1;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\AddTaskDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CountUsers1;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\AddTaskDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CountDay1;
        
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
            System.Uri resourceLocater = new System.Uri("/RegisterBotanicGarden;component/addtaskdialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddTaskDialog.xaml"
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
            
            #line 55 "..\..\AddTaskDialog.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cancel_CLick);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 56 "..\..\AddTaskDialog.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TypeTasks = ((System.Windows.Controls.ComboBox)(target));
            
            #line 60 "..\..\AddTaskDialog.xaml"
            this.TypeTasks.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TypeTasks_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TypeTaskAdd1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TargetTask1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.MessageTask1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.MainUser1 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.CountUsers1 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.CountDay1 = ((System.Windows.Controls.TextBox)(target));
            
            #line 91 "..\..\AddTaskDialog.xaml"
            this.CountDay1.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.CountDay1_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

