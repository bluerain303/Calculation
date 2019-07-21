using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace WPF_Services
{
    public class LogService : IService
    {
        private ObservableCollection<String> _logs;

        #region Constructors
        public LogService()
        {
            this._logs = new ObservableCollection<string>();
        }
        #endregion

        #region Properties
        public ObservableCollection<String> CurrentLogs
        {
            get
            {
                return (this._logs);
            }
        }
        #endregion

        #region Public methods
        public void Write(String log)
        {
            this._logs.Add(log);
        }

        public void Clear()
        {
            this._logs.Clear();        
        }
        #endregion

        #region IService Members

        public ServiceType Type
        {
            get 
            {
                return ServiceType.LogService;
            }
        }

        public string Name
        {
            get;
            set;
        }
        #endregion
    }
}
