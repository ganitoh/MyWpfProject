// Updated by XamlIntelliSenseFileGenerator 05.03.2023 20:46:55
#pragma checksum "..\..\..\..\..\View\MainView\ParserView\ParserControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "028A77CEA57FE0B4D4D321C7994C488AADB77C86855367356D9C054C5690F056"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MyWpfProject.View.MainView.ParserView;
using MyWpfProject.View.MainView.ParserView.controls;
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


namespace MyWpfProject.View.MainView.ParserView
{


    /// <summary>
    /// ParserControl
    /// </summary>
    public partial class ParserControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector
    {


#line 43 "..\..\..\..\..\View\MainView\ParserView\ParserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfProject.View.MainView.ParserView.controls.NumericUpDown startPoint;

#line default
#line hidden


#line 45 "..\..\..\..\..\View\MainView\ParserView\ParserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfProject.View.MainView.ParserView.controls.NumericUpDown endPoint;

#line default
#line hidden


#line 58 "..\..\..\..\..\View\MainView\ParserView\ParserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl headersParserContentcontroll;

#line default
#line hidden


#line 63 "..\..\..\..\..\View\MainView\ParserView\ParserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel valuePageStackPanel;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MyWpfProject;component/view/mainview/parserview/parsercontrol.xaml", System.UriKind.Relative);

#line 1 "..\..\..\..\..\View\MainView\ParserView\ParserControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler)
        {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.startPoint = ((MyWpfProject.View.MainView.ParserView.controls.NumericUpDown)(target));
                    return;
                case 2:
                    this.endPoint = ((MyWpfProject.View.MainView.ParserView.controls.NumericUpDown)(target));
                    return;
                case 3:

#line 46 "..\..\..\..\..\View\MainView\ParserView\ParserControl.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GoWorkParser);

#line default
#line hidden
                    return;
                case 4:
                    this.headersParserContentcontroll = ((System.Windows.Controls.ContentControl)(target));
                    return;
                case 5:
                    this.headersPanel = ((System.Windows.Controls.StackPanel)(target));
                    return;
                case 6:
                    this.valuePageStackPanel = ((System.Windows.Controls.StackPanel)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.TextBlock page;
    }
}

