﻿#pragma checksum "..\..\..\Plot.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E8B3ABD0349AB16CCFEF9A04C5747816430E2FEA"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using Aufgabe8_2;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Aufgabe8_2 {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\Plot.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rb_Sin;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Plot.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rb_Cos;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Plot.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rb_Tan;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Plot.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Aufgabe8_2.Plot plot;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Plot.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_XMin;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Plot.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_XMax;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Plot.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_YMin;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Plot.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_YMax;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Plot.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_DT;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.12.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Aufgabe8-2;component/plot.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Plot.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.12.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.12.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.rb_Sin = ((System.Windows.Controls.RadioButton)(target));
            
            #line 20 "..\..\..\Plot.xaml"
            this.rb_Sin.Checked += new System.Windows.RoutedEventHandler(this.rb_Checked);
            
            #line default
            #line hidden
            return;
            case 2:
            this.rb_Cos = ((System.Windows.Controls.RadioButton)(target));
            
            #line 21 "..\..\..\Plot.xaml"
            this.rb_Cos.Checked += new System.Windows.RoutedEventHandler(this.rb_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.rb_Tan = ((System.Windows.Controls.RadioButton)(target));
            
            #line 22 "..\..\..\Plot.xaml"
            this.rb_Tan.Checked += new System.Windows.RoutedEventHandler(this.rb_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.plot = ((Aufgabe8_2.Plot)(target));
            return;
            case 5:
            this.tb_XMin = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\..\Plot.xaml"
            this.tb_XMin.LostFocus += new System.Windows.RoutedEventHandler(this.TextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.tb_XMax = ((System.Windows.Controls.TextBox)(target));
            
            #line 35 "..\..\..\Plot.xaml"
            this.tb_XMax.LostFocus += new System.Windows.RoutedEventHandler(this.TextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 7:
            this.tb_YMin = ((System.Windows.Controls.TextBox)(target));
            
            #line 36 "..\..\..\Plot.xaml"
            this.tb_YMin.LostFocus += new System.Windows.RoutedEventHandler(this.TextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 8:
            this.tb_YMax = ((System.Windows.Controls.TextBox)(target));
            
            #line 37 "..\..\..\Plot.xaml"
            this.tb_YMax.LostFocus += new System.Windows.RoutedEventHandler(this.TextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 9:
            this.tb_DT = ((System.Windows.Controls.TextBox)(target));
            
            #line 38 "..\..\..\Plot.xaml"
            this.tb_DT.LostFocus += new System.Windows.RoutedEventHandler(this.TextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
