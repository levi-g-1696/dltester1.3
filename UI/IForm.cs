using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    interface IForm
    {
        public bool UIinputValidation();
        public void Save();
        public void RefreshPreviousWindow();
        

    }
}
