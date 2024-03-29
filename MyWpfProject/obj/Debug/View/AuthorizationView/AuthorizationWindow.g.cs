﻿#pragma checksum "..\..\..\..\View\AuthorizationView\AuthorizationWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0C1A3464341DD61531DFD6C9E274C3C01260092C891AF1064380EA251F09CF53"
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
using MyWpfProject.View.AuthorizationView;
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


namespace MyWpfProject.View.AuthorizationView {
    
    
    /// <summary>
    /// AuthorizationWindow
    /// </summary>
    public partial class AuthorizationWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\View\AuthorizationView\AuthorizationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel meinPanel;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\View\AuthorizationView\AuthorizationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button regButton;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\View\AuthorizationView\AuthorizationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button infButton;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\View\AuthorizationView\AuthorizationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxLogin;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\View\AuthorizationView\AuthorizationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passwordBox;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\View\AuthorizationView\AuthorizationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button authorizationButton;
        
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
            System.Uri resourceLocater = new System.Uri("/MyWpfProject;component/view/authorizationview/authorizationwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\AuthorizationView\AuthorizationWindow.xaml"
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
            
            #line 15 "..\..\..\..\View\AuthorizationView\AuthorizationWindow.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Drag);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 17 "..\..\..\..\View\AuthorizationView\AuthorizationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CollapseWindow);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 20 "..\..\..\..\View\AuthorizationView\AuthorizationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CloseWindow);
            
            #line default
            #line hidden
            return;
            case 4:
            this.meinPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.regButton = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\View\AuthorizationView\AuthorizationWindow.xaml"
            this.regButton.Click += new System.Windows.RoutedEventHandler(this.RegistrationClickButton);
            
            #line default
            #line hidden
            return;
            case 6:
            this.infButton = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.textBoxLogin = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.passwordBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 9:
            this.authorizationButton = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\View\AuthorizationView\AuthorizationWindow.xaml"
            this.authorizationButton.Click += new System.Windows.RoutedEventHandler(this.AuthorizationUsersButton);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

