using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ReactiveUI;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace UwpCalculator
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : IViewFor<MainViewModel>
    {
        public MainPage()
        {
            InitializeComponent();
            ViewModel = new MainViewModel();
            //this.WhenActivated(d=> 
            //{
            //    d(this.Bind(ViewModel, x => x.ShowText, x => x.TxtInner.Text));
            //    d(this.Bind(ViewModel, x => x.ResultText, x => x.TxtSurface.Text));
            //    d(this.BindCommand(ViewModel,x=>x.AddNumberAndSign,x=>x.BtnSeven,()=> "7"));
            //});
        }

        public MainViewModel ViewModel
        {
            get { return (MainViewModel)GetValue(ViewModelProperty); }
            set
            {
                SetValue(ViewModelProperty, value);
            }
        }
        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (MainViewModel)value; }
        }
        public static readonly DependencyProperty ViewModelProperty =
    DependencyProperty.Register("ViewModel", typeof(MainViewModel), typeof(MainPage),new PropertyMetadata(null));
    }
}
