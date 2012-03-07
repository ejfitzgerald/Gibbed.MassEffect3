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
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Vector2D : Unreal.ISerializable, INotifyPropertyChanged
    {
        private float _X;
        private float _Y;

        public void Serialize(Unreal.ISerializer stream)
        {
            stream.Serialize(ref this._X);
            stream.Serialize(ref this._Y);
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}",
                this._X, this._Y);
        }

        #region Properties
        public float X
        {
            get { return this._X; }
            set
            {
                if (value != this._X)
                {
                    this._X = value;
                    this.NotifyPropertyChanged("X");
                }
            }
        }

        public float Y
        {
            get { return this._Y; }
            set
            {
                if (value != this._Y)
                {
                    this._Y = value;
                    this.NotifyPropertyChanged("Y");
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