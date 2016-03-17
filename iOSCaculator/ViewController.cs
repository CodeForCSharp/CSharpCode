
using ReactiveUI;
using System;
using System.Reactive.Linq;
using UIKit;

namespace iOSCalculator
{
    public partial class ViewController : ReactiveViewController, IViewFor<MainViewModel>
    {
        private MainViewModel mainViewModel;
        public MainViewModel ViewModel
        {
            get
            {
                return mainViewModel;
            }

            set
            {
                this.RaiseAndSetIfChanged(ref mainViewModel, value);
            }
        }

        object IViewFor.ViewModel
        {
            get
            {
                return mainViewModel;
            }

            set
            {
                ViewModel = (MainViewModel)value;
            }
        }

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ViewModel = new MainViewModel();
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
            this.BindCommand(ViewModel, x => x.AddNumberAndSign, x => x.BtnSix, () => "6");
            this.BindCommand(ViewModel, x => x.AddNumberAndSign, x => x.BtnSeven, () => "7");
            this.BindCommand(ViewModel, x => x.AddNumberAndSign, x => x.BtnEight, () => "8");
            this.BindCommand(ViewModel, x => x.AddNumberAndSign, x => x.BtnNine, () => "9");
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}