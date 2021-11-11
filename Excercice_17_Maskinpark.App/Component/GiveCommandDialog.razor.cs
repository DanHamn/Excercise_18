using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excercice_17_Maskinpark.App.Component
{
    public partial class GiveCommandDialog
    {
        public bool ShowDialog { get; set; }

        public void Show()
        {
            ShowDialog = true;
            StateHasChanged();
        }    
        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

    }
}
