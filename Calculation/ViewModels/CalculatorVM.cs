using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Calculation.Models;
using WPF_CommonTypes;

namespace Calculation.ViewModels
{
    public class CalculatorVM : WPF_CommonTypes.Observable.ObservableObject
    {
        private Sum _sum;
        private int _max = 5;
        private int _userResult = -1;
        private ImageSource _currentResultImage = null;

        public CalculatorVM()
        {
            this.GenerateRandom();
        }

        #region Properties
        public int Max
        {
            get
            {
                return this._max;
            }
            set
            {
                this._max = value;
            }
        }
        public string Number1
        {
            get
            {
                return this._sum.Num1Display;
            }
        }
        public string Number2
        {
            get
            {
                return this._sum.Num2Display;
            }
        }
        public string UserResultDisplay
        {
            get
            {
                if (this._userResult <= 0)
                {
                    return "";
                }
                else
                {
                    return this._userResult.ToString();
                }

            }
            set
            {
                try
                {
                    this._userResult = Int32.Parse(value);
                }
                catch
                {
                    this._userResult = -1;
                }

                OnPropertyChanged("UserResultDisplay");
            }
        }
        public string Operator
        {
            get
            {
                return this._sum.Operator;
            }
        }
        public ImageSource CurrentImage
        {
            get
            {
                return this._currentResultImage;
            }
            set
            {
                this._currentResultImage = value;
                OnPropertyChanged("CurrentImage");
            }
        }
        #endregion

        private void GenerateRandom()
        {
            Random ran = new Random();
            this._sum = new Sum(ran.Next(1, this.Max), ran.Next(1, this.Max));
            this._userResult = -1;
            OnPropertyChanged("Number1");
            OnPropertyChanged("Number2");
            OnPropertyChanged("Operator");
            OnPropertyChanged("UserResultDisplay");
        }

        #region Commands

        /// <summary>
        /// Command for the refresh button
        /// </summary>
        public ICommand RefreshCalculation
        {
            get
            {
                return new WPF_CommonTypes.Command.RelayCommand(new Action(this.Refresh));
            }
        }

        public void Refresh()
        {
            this.GenerateRandom();
            this.CurrentImage = null;
        }

        /// <summary>
        /// Command for the result button
        /// </summary>
        public ICommand CheckCalculation
        {
            get
            {
                return new WPF_CommonTypes.Command.RelayCommand(new Action(this.Check));
            }
        }

        public void Check()
        {
            try
            {
                int inputValue = Int32.Parse(this.UserResultDisplay);
                if (this._sum.Result == inputValue)
                {
                    //Right
                    this.CurrentImage = new BitmapImage(new Uri(@"C:\Users\yishil\Documents\Local_Yishi\Programming\Calculation\Calculation\Resources\paw_patrol_1.jpg", UriKind.Absolute));

                }
                else
                {
                    //Wrong
                    this.CurrentImage = new BitmapImage(new Uri(@"C:\Users\yishil\Documents\Local_Yishi\Programming\Calculation\Calculation\Resources\wrong.jpg", UriKind.Absolute));
                }
            }
            catch { }
        }
        
        #endregion

    }
}
