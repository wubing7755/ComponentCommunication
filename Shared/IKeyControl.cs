using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentCommunication.Shared
{
    public interface IKeyControl
    {
        void OnKeyDown(KeyboardEventArgs e);
    }
}
