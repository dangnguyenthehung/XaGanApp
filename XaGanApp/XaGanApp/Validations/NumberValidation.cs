using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XaGanApp.Validations
{
    public class NumberValidation : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)

        {

            entry.TextChanged += OnEntryTextChanged;

            base.OnAttachedTo(entry);

        }


        protected override void OnDetachingFrom(Entry entry)

        {

            entry.TextChanged -= OnEntryTextChanged;

            base.OnDetachingFrom(entry);

        }


        void OnEntryTextChanged(object sender, TextChangedEventArgs args)

        {
            // number input validation type
            double result;



            bool isValid = double.TryParse(args.NewTextValue, out result);


            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;

        }
    }
}
