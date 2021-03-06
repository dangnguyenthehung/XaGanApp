﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XaGanApp.Validations
{
    public class PasswordValidation : Behavior<Entry>
    {
        const string passwordRegex = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$";



        protected override void OnAttachedTo(Entry bindable)

        {

            bindable.TextChanged += HandleTextChanged;

            base.OnAttachedTo(bindable);

        }


        void HandleTextChanged(object sender, TextChangedEventArgs e)

        {

            bool IsValid = false;

            IsValid = (Regex.IsMatch(e.NewTextValue, passwordRegex));

            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;

        }


        protected override void OnDetachingFrom(Entry bindable)

        {

            bindable.TextChanged -= HandleTextChanged;

            base.OnDetachingFrom(bindable);

        }

    }
}
