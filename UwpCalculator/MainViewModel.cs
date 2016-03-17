using System;
using System.Collections.Generic;
using System.Linq;
using ReactiveUI;
using System.ComponentModel;
using System.Reactive;
using System.Windows.Input;

namespace UwpCalculator
{
    public class MainViewModel : ReactiveObject
    {
        private string showText;
        public string ShowText
        {
            get { return showText; }
            set { this.RaiseAndSetIfChanged(ref showText, value); }
        }
        private string resultText;
        public string ResultText
        {
            get { return resultText; }
            set { this.RaiseAndSetIfChanged(ref resultText, value); }
        }
        public ReactiveCommand<object> AddNumberAndSign { get; } = ReactiveCommand.Create();
        public ReactiveCommand<object> RemoveNumberAndSign { get; } = ReactiveCommand.Create();
        public ReactiveCommand<object> CalculateResult { get; } = ReactiveCommand.Create();
        public ReactiveCommand<object> ClearText { get; } = ReactiveCommand.Create();
        public MainViewModel()
        {
            AddNumberAndSign.Subscribe(x=> { ShowText += x; });
            RemoveNumberAndSign.Subscribe(x =>ShowText = ShowText.Remove(ShowText.Length-1));
            CalculateResult.Subscribe(x => { ResultText = new StringCalculate().RunExpress(ShowText); });
            ClearText.Subscribe(x=> ShowText="" );
        }
    }
}