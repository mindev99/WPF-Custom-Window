﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Widgets.Interfaces
{
    public interface IWinModal 
    {
        void ShowModal(object content);
        void CloseModal();
        void ShowDialog(object content);
    }
}
