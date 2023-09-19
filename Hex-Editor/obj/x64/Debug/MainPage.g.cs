﻿#pragma checksum "E:\Hex-Editor\Hex-Editor\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EF7355D8AA51E2191052A7B1C7FFECA8E23B1FE887CDBCF8D133BE60A6F19E4E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hex_Editor
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 55
                {
                    this.HexView = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 3: // MainPage.xaml line 60
                {
                    this.BitsRichEditBox = (global::Windows.UI.Xaml.Controls.RichEditBox)(target);
                }
                break;
            case 4: // MainPage.xaml line 113
                {
                    this.StatusText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5: // MainPage.xaml line 78
                {
                    global::Windows.UI.Xaml.Controls.Button element5 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element5).Click += this.LoadBitsButton_Click;
                }
                break;
            case 6: // MainPage.xaml line 81
                {
                    global::Windows.UI.Xaml.Controls.Button element6 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element6).Click += this.ApplyBitsButton_Click;
                }
                break;
            case 7: // MainPage.xaml line 84
                {
                    this.FillCheckBox = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                }
                break;
            case 8: // MainPage.xaml line 87
                {
                    global::Windows.UI.Xaml.Controls.Button element8 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element8).Click += this.LoadBytesButton_Click;
                }
                break;
            case 9: // MainPage.xaml line 90
                {
                    global::Windows.UI.Xaml.Controls.Button element9 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element9).Click += this.ApplyBytesButton_Click;
                }
                break;
            case 10: // MainPage.xaml line 93
                {
                    global::Windows.UI.Xaml.Controls.Button element10 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element10).Click += this.LoadHexButton_Click;
                }
                break;
            case 11: // MainPage.xaml line 96
                {
                    global::Windows.UI.Xaml.Controls.Button element11 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element11).Click += this.ApplyHexButton_Click;
                }
                break;
            case 12: // MainPage.xaml line 99
                {
                    this.FillCheckBox2 = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                }
                break;
            case 13: // MainPage.xaml line 102
                {
                    this.CapsLockCheckBox = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                }
                break;
            case 14: // MainPage.xaml line 105
                {
                    global::Windows.UI.Xaml.Controls.Button element14 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element14).Click += this.LoadTextButton_Click;
                }
                break;
            case 15: // MainPage.xaml line 108
                {
                    global::Windows.UI.Xaml.Controls.Button element15 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element15).Click += this.ApplyTextButton_Click;
                }
                break;
            case 16: // MainPage.xaml line 35
                {
                    global::Windows.UI.Xaml.Controls.Border element16 = (global::Windows.UI.Xaml.Controls.Border)(target);
                    ((global::Windows.UI.Xaml.Controls.Border)element16).PointerPressed += this.FileLocationBox_PointerPressed;
                }
                break;
            case 17: // MainPage.xaml line 44
                {
                    global::Windows.UI.Xaml.Controls.Button element17 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element17).Click += this.OpenButton_Click;
                }
                break;
            case 18: // MainPage.xaml line 45
                {
                    global::Windows.UI.Xaml.Controls.Button element18 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element18).Click += this.SaveButton_Click;
                }
                break;
            case 19: // MainPage.xaml line 46
                {
                    global::Windows.UI.Xaml.Controls.Button element19 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element19).Click += this.ClearButton_Click;
                }
                break;
            case 20: // MainPage.xaml line 48
                {
                    this.SearchTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.SearchTextBox).TextChanged += this.SearchTextBox_TextChanged;
                }
                break;
            case 21: // MainPage.xaml line 49
                {
                    global::Windows.UI.Xaml.Controls.Button element21 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element21).Click += this.NextButton_Click;
                }
                break;
            case 22: // MainPage.xaml line 50
                {
                    global::Windows.UI.Xaml.Controls.Button element22 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element22).Click += this.PreviousButton_Click;
                }
                break;
            case 23: // MainPage.xaml line 39
                {
                    this.FileLocationText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
