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
        private String ExpressString="";
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.Main);
            // Get our button from the layout resource,
            // and attach an event to it
            Button btnSeven = FindViewById<Button>(Resource.Id.btnSeven);
            btnSeven.Click += delegate { Click((String)btnSeven.Tag); };
            Button btnEight = FindViewById<Button>(Resource.Id.btnEight);
            btnEight.Click += delegate { Click((String)btnEight.Tag); };
            Button btnNine = FindViewById<Button>(Resource.Id.btnNine);
            btnNine.Click += delegate { Click((String)btnNine.Tag); };
            Button btnFour = FindViewById<Button>(Resource.Id.btnFour);
            btnFour.Click += delegate { Click((String)btnFour.Tag); };
            Button btnFive = FindViewById<Button>(Resource.Id.btnFive);
            btnFive.Click += delegate { Click((String)btnFive.Tag); };
            Button btnSix = FindViewById<Button>(Resource.Id.btnSix);
            btnSix.Click += delegate { Click((String)btnSix.Tag); };
            Button btnOne = FindViewById<Button>(Resource.Id.btnOne);
            btnOne.Click += delegate { Click((String)btnOne.Tag); };
            Button btnTwo = FindViewById<Button>(Resource.Id.btnTwo);
            btnTwo.Click += delegate { Click((String)btnTwo.Tag); };
            Button btnThree = FindViewById<Button>(Resource.Id.btnThree); 
            btnThree.Click += delegate { Click((String)btnThree.Tag); };
            Button btnRightBracket = FindViewById<Button>(Resource.Id.btnRightBracket);
            btnRightBracket.Click += delegate { Click((String)btnRightBracket.Tag); };
            Button btnLeftBracket = FindViewById<Button>(Resource.Id.btnLeftBracket);
            btnLeftBracket.Click += delegate { Click((String)btnLeftBracket.Tag); };
            Button btnZero = FindViewById<Button>(Resource.Id.btnZero);
            btnZero.Click += delegate { Click((String)btnZero.Tag); };
            Button btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
            btnAdd.Click += delegate { Click((String)btnAdd.Tag); SameAsPrevious((String)btnAdd.Tag); };
            Button btnCut = FindViewById<Button>(Resource.Id.btnCut);
            btnCut.Click += delegate { Click((String)btnCut.Tag); SameAsPrevious((String)btnCut.Tag); };
            Button btnMuilt = FindViewById<Button>(Resource.Id.btnMuilt);
            btnMuilt.Click += delegate { Click((String)btnMuilt.Tag); SameAsPrevious((String)btnMuilt.Tag); };
            Button btnDiv = FindViewById<Button>(Resource.Id.btnDiv);
            btnDiv.Click += delegate { Click((String)btnDiv.Tag); SameAsPrevious((String)btnDiv.Tag); };
            Button btnDot = FindViewById<Button>(Resource.Id.btnDot);
            btnDot.Click += delegate { Click((String)btnDot.Tag); SameAsPrevious((String)btnDot.Tag); };
            Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
            btnBack.Click += delegate { Back(); };
            Button btnEqual = FindViewById<Button>(Resource.Id.btnEqual);
            btnEqual.Click += delegate { Equal(); };
            Button btnClear = FindViewById<Button>(Resource.Id.btnClear);
            btnClear.Click += delegate { Clear(); };
        }
        private void Click(string Tag)
        {
            EditText txtInner = FindViewById<EditText>(Resource.Id.txtInner);
            if (!ExpressString.Equals("") && IsCalculateOver)
            {
                IsCalculateOver = false;
                txtInner.Text = "";
            }
            txtInner.Text += Tag;
        }
        private void Back()
        {
            EditText txtInner = FindViewById<EditText>(Resource.Id.txtInner);
            if(!txtInner.Text.Equals(""))
            {
                txtInner.Text = txtInner.Text.Substring(0, txtInner.Text.Length-1);
            }
        }
        private void Equal()
        {
            EditText txtInner=FindViewById<EditText>(Resource.Id.txtInner);
            EditText txtSurface = FindViewById<EditText>(Resource.Id.txtSurface);
            if(!txtInner.Text.Equals(""))
            {
                try
                {
                    StringCalculate Parse = new StringCalculate();
                    String Result=Parse.runExpress(txtInner.Text);
                    double Number=Convert.ToDouble(Result);
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
        private void SameAsPrevious(String Sign)
        {
            EditText txtInner = FindViewById<EditText>(Resource.Id.txtInner);
            if(txtInner.Text.Length>1&&txtInner.Text.Substring(txtInner.Text.Length-2,1).Equals(Sign))
            {
                txtInner.Text= txtInner.Text.Substring(0, txtInner.Text.Length - 1);
            }
        }
        private void Clear()
        {
            EditText txtInner = FindViewById<EditText>(Resource.Id.txtInner);
            txtInner.Text = "";
        }
    }
}

