﻿using System;
using System.Collections.Generic;
using System.Text;

namespace shopSU.UIForms.ViewModels
{
    public class MainViewModel
    {
        public LoginViewModel Login { get; set; }

        public MainViewModel()
        {
            this.Login = new LoginViewModel();
        }
    }
}
