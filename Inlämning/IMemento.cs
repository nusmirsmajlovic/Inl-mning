using System;
using System.Collections.Generic;
using System.Text;

namespace Inlämning
{
   public  interface IMemento
    {

        string GetName();

        string GetState();

        DateTime GetDate();
    }
}
