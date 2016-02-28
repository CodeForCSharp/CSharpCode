using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Text.Method;

namespace AndroidCalculator
{
    [Activity(Label = "AndroidCalculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private bool IsCalculateOver=false;
        private string ExpressString ="";
        private EditText txtInner = null;
        private EditText txtSurface = null;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.Main);
            // Get our button from the layout resource,
            // and attach an event to it
            Button btnSeven = FindViewById<Button>(Resource.Id.btnSeven);
            btnSeven.Click += delegate { Click("7"); };
            Button btnEight = FindViewById<Button>(Resource.Id.btnEight);
            btnEight.Click += delegate { Click("8"); };
            Button btnNine = FindViewById<Button>(Resource.Id.btnNine);
            btnNine.Click += delegate { Click("9"); };
            Button btnFour = FindViewById<Button>(Resource.Id.btnFour);
            btnFour.Click += delegate { Click("4"); };
            Button btnFive = FindViewById<Button>(Resource.Id.btnFive);
            btnFive.Click += delegate { Click("5"); };
            Button btnSix = FindViewById<Button>(Resource.Id.btnSix);
            btnSix.Click += delegate { Click("6"); };
            Button btnOne = FindViewById<Button>(Resource.Id.btnOne);
            btnOne.Click += delegate { Click("1"); };
            Button btnTwo = FindViewById<Button>(Resource.Id.btnTwo);
            btnTwo.Click += delegate { Click("2"); };
            Button btnThree = FindViewById<Button>(Resource.Id.btnThree);
            btnThree.Click += delegate { Click("3"); };
            Button btnRightBracket = FindViewById<Button>(Resource.Id.btnRightBracket);
            btnRightBracket.Click += delegate { Click("("); };
            Button btnLeftBracket = FindViewById<Button>(Resource.Id.btnLeftBracket);
            btnLeftBracket.Click += delegate { Click(")"); };
            Button btnZero = FindViewById<Button>(Resource.Id.btnZero);
            btnZero.Click += delegate { Click("0"); };
            Button btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
            btnAdd.Click += delegate { Click("+"); SameAsPrevious("+"); };
            Button btnCut = FindViewById<Button>(Resource.Id.btnCut);
            btnCut.Click += delegate { Click("-"); SameAsPrevious("-"); };
            Button btnMuilt = FindViewById<Button>(Resource.Id.btnMuilt);
            btnMuilt.Click += delegate { Click("*"); SameAsPrevious("*"); };
            Button btnDiv = FindViewById<Button>(Resource.Id.btnDiv);
            btnDiv.Click += delegate { Click("/"); SameAsPrevious("/"); };
            Button btnDot = FindViewById<Button>(Resource.Id.btnDot);
            btnDot.Click += delegate { Click("."); SameAsPrevious("."); };
            Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
            btnBack.Click += delegate { Back(); };
            Button btnEqual = FindViewById<Button>(Resource.Id.btnEqual);
            btnEqual.Click += delegate { Equal(); };
            Button btnClear = FindViewById<Button>(Resource.Id.btnClear);
            btnClear.Click += delegate { Clear(); };
            txtInner = FindViewById<EditText>(Resource.Id.txtInner);
            txtSurface = FindViewById<EditText>(Resource.Id.txtSurface);
        }
        private void Click(string Tag)
        {
            if (!ExpressString.Equals("") && IsCalculateOver)
            {
                IsCalculateOver = false;
                txtInner.Text = "";
            }
            txtInner.Text += Tag;
        }
        private void Back()
        {
            if(!txtInner.Text.Equals(""))
            {
                txtInner.Text = txtInner.Text.PadRight(1);
            }
        }
        private void Equal()
        {
            if(!txtInner.Text.Equals(""))
            {
                try
                {                
                    StringCalculate Parse = new StringCalculate();
                    var Result =Parse.runExpress(txtInner.Text);
                    var Number = Convert.ToDecimal(Result);
                    txtSurface.Text = Number.ToString();
                    IsCalculateOver = !IsCalculateOver;
                    ExpressString = Result;
                }
                catch
                {
                    txtSurface.Text="Error";
                    txtInner.Text = "";
                }
            }
        }
        private void SameAsPrevious(string Sign)
        {
            if(txtInner.Text.Length>1&&txtInner.Text.PadRight(1).Equals(Sign))
            {
                txtInner.Text= txtInner.Text.PadLeft(txtInner.Text.Length-1);
            }
        }
        private void Clear()
        {
            txtInner.Text = "";
        }
    }
}

