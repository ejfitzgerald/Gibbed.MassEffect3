﻿/* Copyright (c) 2012 Rick (rick 'at' gibbed 'dot' us)
 * 
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 * 
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 * 
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

using System.ComponentModel;

namespace Gibbed.MassEffect3.FileFormats.Save
{
    public class SaveTimeStamp : Unreal.ISerializable, INotifyPropertyChanged
    {
        private int _SecondsSinceMidnight;
        private int _Day;
        private int _Month;
        private int _Year;

        public void Serialize(Unreal.ISerializer stream)
        {
            stream.Serialize(ref this._SecondsSinceMidnight);
            stream.Serialize(ref this._Day);
            stream.Serialize(ref this._Month);
            stream.Serialize(ref this._Year);
        }

        #region Properties
        public int SecondsSinceMidnight
        {
            get { return _SecondsSinceMidnight; }
            set
            {
                if (value != this._SecondsSinceMidnight)
                {
                    this._SecondsSinceMidnight = value;
                    this.NotifyPropertyChanged("SecondsSinceMidnight");
                }
            }
        }

        public int Day
        {
            get { return this._Day; }
            set
            {
                if (value != this._Day)
                {
                    this._Day = value;
                    this.NotifyPropertyChanged("Day");
                }
            }
        }

        public int Month
        {
            get { return this._Month; }
            set
            {
                if (value != this._Month)
                {
                    this._Month = value;
                    this.NotifyPropertyChanged("Month");
                }
            }
        }

        public int Year
        {
            get { return this._Year; }
            set
            {
                if (value != this._Year)
                {
                    this._Year = value;
                    this.NotifyPropertyChanged("Year");
                }
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}