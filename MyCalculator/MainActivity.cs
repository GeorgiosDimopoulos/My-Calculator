using System;
using System.Globalization;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace MyCalculator
{
    [Activity(Label = "@string/app_name", Icon ="@drawable/calculator", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        enum Operation
        {
            Plus,
            Minus,
            Mul,
            Log,
            Div,
            Mod
        }
        
        private TextView _resultTextview;
        private double _result;
        private bool _cleared, _comma, _afterComma;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                _cleared = true;
                _comma = false;
                _afterComma = false;
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.activity_main);
                _result = 0;
                Operation choice = Operation.Plus;
                //settingView();
                //settingACtions();

                TextView _resultTextview = FindViewById<TextView>(Resource.Id.textviewResult);
                Button _clearButton = FindViewById<Button>(Resource.Id.buttonClear);
                Button _buttontwo = FindViewById<Button>(Resource.Id.buttonTwo);
                Button _zerobutton = FindViewById<Button>(Resource.Id.buttonZero);
                Button _buttonComma = FindViewById<Button>(Resource.Id.buttonComma);
                Button _oneButton = FindViewById<Button>(Resource.Id.buttonOne);
                Button _threeButton = FindViewById<Button>(Resource.Id.buttonThree);
                Button _fourButton = FindViewById<Button>(Resource.Id.buttonFour);
                Button _fiveButton = FindViewById<Button>(Resource.Id.buttonFive);
                Button _sixButton = FindViewById<Button>(Resource.Id.buttonSix);
                Button _sevenButton = FindViewById<Button>(Resource.Id.buttonSeven);
                Button _eightButton = FindViewById<Button>(Resource.Id.buttonEight);
                Button _nineButton = FindViewById<Button>(Resource.Id.buttonNine);
                Button _plusButton = FindViewById<Button>(Resource.Id.buttonPlus);
                Button _minusButton = FindViewById<Button>(Resource.Id.buttonMinus);
                Button _percentButton = FindViewById<Button>(Resource.Id.buttonPercent);
                Button _divButton = FindViewById<Button>(Resource.Id.buttonDiv);
                Button _mulButton = FindViewById<Button>(Resource.Id.buttonMul);
                Button _logButton = FindViewById<Button>(Resource.Id.buttonLog);
                Button _rootButton = FindViewById<Button>(Resource.Id.buttonRoot);
                Button _equalButton = FindViewById<Button>(Resource.Id.buttonEqual);
                
                Typeface tf = Typeface.CreateFromAsset(Application.Context.Assets, "Roboto-Light.ttf");
                _clearButton.Typeface = tf;
                _equalButton.Typeface = tf;
                _rootButton.Typeface = tf;
                _mulButton.Typeface = tf;
                _percentButton.Typeface = tf;
                _minusButton.Typeface = tf;
                _plusButton.Typeface = tf;
                _nineButton.Typeface = tf;
                _eightButton.Typeface = tf;
                _fiveButton.Typeface = tf;
                _sixButton.Typeface = tf;
                _fourButton.Typeface = tf;
                _threeButton.Typeface = tf;
                _buttonComma.Typeface = tf;
                _zerobutton.Typeface = tf;
                _buttontwo.Typeface = tf;
                _oneButton.Typeface = tf;
                _sevenButton.Typeface = tf;
                _resultTextview.Typeface = tf;

                _buttonComma.Click += delegate
                {
                    if (_cleared)
                    {
                        _resultTextview.Text += ","; //.
                        _comma = true;
                        _cleared = false;
                        //_result = double.Parse(_resultTextview.Text);
                    }
                    else Toast.MakeText(this, "ΑΔΥΝΑΤΟ", ToastLength.Long).Show();

                };
                _clearButton.Click += delegate
                {
                    _result = 0;
                    _resultTextview.Text = "";
                    _cleared = true;
                };
                _percentButton.Click += delegate
                {
                    choice = Operation.Mod;
                    _result += double.Parse(_resultTextview.Text);
                    _resultTextview.Text = _result.ToString(CultureInfo.InvariantCulture);
                    _cleared = true;
                };
                _divButton.Click += delegate
                {
                    choice = Operation.Div;
                    _result += double.Parse(_resultTextview.Text);
                    _resultTextview.Text = "";
                    _cleared = false;
                };
                _logButton.Click += delegate
                {
                    choice = Operation.Log;
                    var temp=_resultTextview.Text;
                    _resultTextview.Text = Math.Log10(double.Parse(temp)).ToString(CultureInfo.InvariantCulture);
                    _cleared = true;
                };
                _minusButton.Click += delegate
                {
                    choice = Operation.Minus;
                    _result += double.Parse(_resultTextview.Text);
                    _resultTextview.Text = "";
                    _cleared = false;
                };
                _mulButton.Click += delegate
                {
                    choice = Operation.Mul;
                    _result += double.Parse(_resultTextview.Text);
                    _resultTextview.Text = "";
                    _cleared = false;
                };
                _rootButton.Click += delegate
                {
                    double root = double.Parse(_resultTextview.Text);
                    _resultTextview.Text = Math.Pow(root, 1.0 / 2).ToString(CultureInfo.InvariantCulture);
                    _cleared = true;
                };
                _plusButton.Click += delegate
                {
                    choice = Operation.Plus;
                    _result += double.Parse(_resultTextview.Text);
                    _resultTextview.Text = "";
                    _cleared = false;
                };
                _equalButton.Click += delegate
                {
                    if (choice.Equals(Operation.Plus))
                    {
                        _result += double.Parse(_resultTextview.Text);
                    }
                    else if (choice.Equals(Operation.Minus))
                    {
                        _result -= double.Parse(_resultTextview.Text);
                    }
                    else if (choice.Equals(Operation.Mod))
                    {
                        _result %= double.Parse(_resultTextview.Text);
                    }
                    else if (choice.Equals(Operation.Mul))
                    {
                        _result *= double.Parse(_resultTextview.Text);
                    }
                    else if (choice.Equals(Operation.Div))
                    {
                        _result /= double.Parse(_resultTextview.Text);
                    }
                    _resultTextview.Text = _result.ToString(CultureInfo.InvariantCulture);
                    _result = 0;
                    _cleared = true;
                };
                _eightButton.Click += delegate
                {
                    if (_cleared)
                    {
                        _resultTextview.Text = "";
                    }
                    _comma = false;
                    _afterComma = true;
                    _resultTextview.Text += "8";
                };
                _nineButton.Click += delegate
                {
                    if (_cleared)
                    {
                        _resultTextview.Text = "";
                    }
                    _comma = false;
                    _afterComma = true;
                    _resultTextview.Text += "9";
                };
                _sevenButton.Click += delegate
                {
                    if (_cleared)
                    {
                        _resultTextview.Text = "";
                    }
                    _comma = false;
                    _afterComma = true;
                    _resultTextview.Text += "7";
                };
                _fiveButton.Click += delegate
                {
                    if (_cleared)
                    {
                        _resultTextview.Text = "";
                    }
                    _comma = false;
                    _afterComma = true;
                    _resultTextview.Text += "5";
                };
                _buttontwo.Click += delegate
                {
                    if (_cleared)
                    {
                        _resultTextview.Text = "";
                    }
                    _comma = false;
                    _resultTextview.Text += "2";
                };
                _zerobutton.Click += delegate
                {
                    if (_cleared)
                    {
                        _resultTextview.Text = "";
                    }
                    _comma = false;
                    _afterComma = true;
                    _resultTextview.Text += "0";
                };
                _oneButton.Click += delegate
                {
                    if (_cleared)
                    {
                        _resultTextview.Text = "";
                    }
                    _comma = false;
                    _afterComma = true;
                    _resultTextview.Text += "1";
                };
                _threeButton.Click += delegate
                {
                    if (_cleared)
                    {
                        _resultTextview.Text = "";
                    }
                    _comma = false;
                    _afterComma = true;
                    _resultTextview.Text += "3";
                };
                _fourButton.Click += delegate
                {
                    if (_cleared)
                    {
                        _resultTextview.Text = "";
                    }
                    _comma = false;
                    _afterComma = true;
                    _resultTextview.Text += "4";
                };
                _sixButton.Click += delegate
                {
                    if (_cleared)
                    {
                        _resultTextview.Text = "";
                    }
                    _resultTextview.Text += "6";
                    _comma = false;
                    _afterComma = true;
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Toast.MakeText(this, e.Message, ToastLength.Long).Show();
            }
        }
    }
}

