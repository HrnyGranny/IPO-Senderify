﻿#pragma checksum "..\..\..\..\Presentacion\Formularios\InfoPdi.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D555AA62B965D1EF6C21D2666D29C92D161EB9FB16C61B2892EBD8BA6E065522"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using AppSenderismo.Presentacion.Formularios;
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


namespace AppSenderismo.Presentacion.Formularios {
    
    
    /// <summary>
    /// InfoPdi
    /// </summary>
    public partial class InfoPdi : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\Presentacion\Formularios\InfoPdi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Nombre_Lbl;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Presentacion\Formularios\InfoPdi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Nombre_Txt;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Presentacion\Formularios\InfoPdi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Descripcion_Lbl;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Presentacion\Formularios\InfoPdi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Descripcion_Txt;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Presentacion\Formularios\InfoPdi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Tipologia_Lbl;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Presentacion\Formularios\InfoPdi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Tipologia_Txt;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Presentacion\Formularios\InfoPdi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Pdi_Foto;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Presentacion\Formularios\InfoPdi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Cancelar_Btm;
        
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
            System.Uri resourceLocater = new System.Uri("/AppSenderismo;component/presentacion/formularios/infopdi.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Presentacion\Formularios\InfoPdi.xaml"
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
            this.Nombre_Lbl = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.Nombre_Txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Descripcion_Lbl = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.Descripcion_Txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Tipologia_Lbl = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.Tipologia_Txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Pdi_Foto = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.Cancelar_Btm = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\Presentacion\Formularios\InfoPdi.xaml"
            this.Cancelar_Btm.Click += new System.Windows.RoutedEventHandler(this.Cancelar_Btm_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

