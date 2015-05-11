using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelCompare.Classes.Events
{
    public class ProgressDataChangedEventArgs : EventArgs
    {
        public ProgressDataChangedEventArgs(object data, object userState)
        {
            this.data = data;
            this.userState = userState;
        }

        object data;
        public object Data
        {
            get { return data; }
        }

        object userState;
        public object UserState
        {
            get { return userState; }
        }
    }
}
