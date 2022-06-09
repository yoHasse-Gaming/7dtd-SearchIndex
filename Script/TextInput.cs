using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchIndex
{
    public class TextInput : XUiC_TextInput
    {
        public void TriggerChange()
        {
            if (this is null || UIInput.current == null)
                return;
            this.OnChange();
        }
    }
}
