using System;


namespace Inlämning
{
   public  interface IMemento
    {

        string GetName();

        string GetState();

        DateTime GetDate();
    }
}
