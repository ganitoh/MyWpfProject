﻿#pragma checksum "..\..\..\..\..\View\MainView\MyFinanceView\AddPurposeWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "643CF5A0AA1B086FB9B9D66BEADC29D5FF99D4FBEA91E902C8A7FFDC9285F2FA"
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
using MyWpfProject.View.MainView.MyFinanceView;
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


namespace MyWpfProject.View.MainView.MyFinanceView {
    
    
    /// <summary>
    /// AddPurposeWindow
    /// </summary>
    public partial class AddPurposeWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\..\..\View\MainView\MyFinanceView\AddPurposeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel mainStackPanel;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\..\View\MainView\MyFinanceView\AddPurposeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox titleTextBox;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\..\View\MainView\MyFinanceView\AddPurposeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox discriptionTextBox;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\..\View\MainView\MyFinanceView\AddPurposeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox finalAmountMonyTextBox;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\..\View\MainView\MyFinanceView\AddPurposeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox collectedAmountMonyTextBox;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\..\View\MainView\MyFinanceView\AddPurposeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox isMainPurposesCheckBox;
        
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
            System.Uri resourceLocater = new System.Uri("/MyWpfProject;component/view/mainview/myfinanceview/addpurposewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\MainView\MyFinanceView\AddPurposeWindow.xaml"
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
            
            #line 18 "..\..\..\..\..\View\MainView\MyFinanceView\AddPurposeWindow.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Drag);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 24 "..\..\..\..\..\View\MainView\MyFinanceView\AddPurposeWindow.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Drag);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 27 "..\..\..\..\..\View\MainView\MyFinanceView\AddPurposeWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CollapseWindow);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 30 "..\..\..\..\..\View\MainView\MyFinanceView\AddPurposeWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CloseWindow);
            
            #line default
            #line hidden
            return;
            case 5:
            this.mainStackPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.titleTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.discriptionTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.finalAmountMonyTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.collectedAmountMonyTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.isMainPurposesCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 11:
            
            #line 40 "..\..\..\..\..\View\MainView\MyFinanceView\AddPurposeWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddPurpose);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

