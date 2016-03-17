using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Text.Method;
using ReactiveUI;

namespace AndroidCalculator
{
    [Activity(Label = "AndroidCalculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ReactiveActivity<MainViewModel>
    {
        private EditText TxtInner { get; set; }
        private EditText TxtSurface { get; set; }
        private Button BtnSeven { get; set; }
        private Button BtnEight { get; set; }
        private Button BtnSix { get; set; }
        private Button BtnNine { get; set; }
        private Button BtnFive { get; set; }
        private Button BtnFour { get; set; }
        private Button BtnThree { get; set; }
        private Button BtnTwo { get; set; }
        private Button BtnOne { get; set; }
        private Button BtnZero { get; set; }
        private Button BtnAdd { get; set; }
        private Button BtnCut { get; set; }
        private Button BtnMuilt { get; set; }
        private Button BtnDiv { get; set; }
        private Button BtnLeftBracket { get; set; }
        private Button BtnRightBracket { get; set; }
        private Button BtnDot { get; set; }
        private Button BtnEqual { get; set; }
        private Button BtnBack { get; set; }
        private Button BtnClear { get; set; }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.Main);
            // Get our button from the layout resource,
            // and attach an event to it
            ViewModel = new MainViewModel();
            this.WireUpControls();
            this.Bind(ViewModel, x => x.ShowText, x => x.TxtInner.Text);
            this.Bind(ViewModel, x => x.ResultText, x => x.TxtSurface.Text);
            this.BindCommand(ViewModel, x => x.CalculateResult, x => x.BtnEqual);
            this.BindCommand(ViewModel, x => x.ClearText, x => x.BtnClear);
            this.BindCommand(ViewModel, x => x.RemoveNumberAndSign, x => x.BtnBack);
            this.BindCommand(ViewModel, x => x.AddNumberAndSign, x => x.BtnDiv, () => "/");
            this.BindCommand(ViewModel, x => x.AddNumberAndSign, x => x.BtnMuilt, () => "*");
            this.BindCommand(ViewModel, x => x.AddNumberAndSign, x => x.BtnCut, () => "-");
            this.BindCommand(ViewModel, x => x.AddNumberAndSign, x => x.BtnAdd, () => "+");
            this.BindCommand(ViewModel, x => x.AddNumberAndSign, x => x.BtnRightBracket, () => ")");
            this.BindCommand(ViewModel, x => x.AddNumberAndSign, x => x.BtnLeftBracket, () => "(");
            this.BindCommand(ViewModel, x => x.AddNumberAndSign, x => x.BtnZero, () => "0");
            this.BindCommand(ViewModel, x => x.AddNumberAndSign, x => x.BtnOne, () => "1");
            this.BindCommand(ViewModel, x => x.AddNumberAndSign, x => x.BtnTwo, () => "2");
            this.BindCommand(ViewModel, x => x.AddNumberAndSign, x => x.BtnThree, () => "3");
            this.BindCommand(ViewModel, x => x.AddNumberAndSign, x => x.BtnFour, () => "4");
            this.BindCommand(ViewModel, x => x.AddNumberAndSign, x => x.BtnFive, () => "5");
            this.BindCommand(ViewModel, x => x.AddNumberAndSign, x => x.BtnSix,()=>"6");
            this.BindCommand(ViewModel, x => x.AddNumberAndSign, x => x.BtnSeven,()=> "7");
            this.BindCommand(ViewModel, x => x.AddNumberAndSign, x => x.BtnEight,()=>"8");
            this.BindCommand(ViewModel, x => x.AddNumberAndSign, x => x.BtnNine,()=>"9");
        }
    }
}

