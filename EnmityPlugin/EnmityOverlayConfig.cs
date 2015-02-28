﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using RainbowMage.OverlayPlugin;

namespace Tamagawa.EnmityPlugin
{
    [Serializable]
    public class EnmityOverlayConfig : RainbowMage.OverlayPlugin.OverlayConfig
    {
        public event EventHandler<ScanIntervalChangedEventArgs> ScanIntervalChanged;

        private int scanInterval;
        [XmlElement("ScanInterval")]
        public int ScanInterval
        {
            get
            {
                return this.scanInterval;
            }
            set
            {
                if (this.scanInterval != value)
                {
                    this.scanInterval = value;
                    if (ScanIntervalChanged != null)
                    {
                        ScanIntervalChanged(this, new ScanIntervalChangedEventArgs(this.scanInterval));
                    }
                }
            }
        }

        public EnmityOverlayConfig()
        {
            this.scanInterval = 100;
        }
    }
}