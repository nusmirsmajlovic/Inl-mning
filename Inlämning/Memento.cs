using System;


namespace Inlämning
{
   public  interface Memento
    {

        string GetName();

        string GetState();

        DateTime GetDate();
    }
}
