using System;
using System.Collections.Generic;
using System.Linq;


namespace Inlämning
{
    class Caretaker
    {
        private List<IMemento> _mementos = new List<IMemento>();

        private Originator _originator = null;
        private object this_mementos;

        public Caretaker(Originator originator)
        {
            this._originator = originator;
            
        }

        public void Backup()
        {
            Console.WriteLine("\nSpara state");
            this._mementos.Add(this._originator.Save());
        }
        public void Redo()
        {
            if (this._mementos.Count == 0) 
            {
                return;
            }

            var memento = this._mementos.Last();
            this._mementos.Remove(memento);

            Console.WriteLine("Återställa state till: " + memento.GetName());

            try
            {
                this._originator.Restore(memento);
            }
            catch (Exception)
            {
                this.Redo();
            }
        }


        public void Undo()
        {
            if (this._mementos.Count == 0)
            {
                return;
            }

            var memento = this._mementos.Last();
            this._mementos.Remove(memento);

            Console.WriteLine("Caretaker: Återställa state till: " + memento.GetName());

            try
            {
                this._originator.Restore(memento);
            }
            catch (Exception)
            {
                this.Undo();
            }
        }
       
        public void ShowHistory()
        {
            Console.WriteLine("Caretaker:Här är  mementos:");

            foreach (var memento in this._mementos)
            {
                Console.WriteLine(memento.GetName());
            }
        }
    }
}
