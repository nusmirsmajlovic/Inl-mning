using System;
using System.Threading;

namespace Inlämning
{   // The Originator holds some important state that may change over time. It
    // also defines a method for saving the state inside a memento and another
    // method for restoring the state from it.
    class Originator
    {
        // For the sake of simplicity, the originator's state is stored inside a
        // single variable.
        public string _state;
        private Func<int> read;

        public Originator(string state)
        {
            this._state = state;
            Console.WriteLine("Originator: min state: " + state);
        }

        public Originator(Func<int> read)
        {
            this.read = read;
        }

        // The Originator's business logic may affect its internal state.
        // Therefore, the client should backup the state before launching
        // methods of the business logic via the save() method.
        public void DoSomething()
        {
            Console.WriteLine("Originator: Jag gör något viktigt.");
            this._state = this.GenerateRandomString(10);
            Console.WriteLine($"Originator: och min state har ändrats till: {_state}");
        }

        private string GenerateRandomString(int length = 10)
        {
            string allowedSymbols = "tttttt";
            string result = string.Empty;

            while (length > 0)
            {
                result += allowedSymbols[new Random().Next(0, allowedSymbols.Length)];

                Thread.Sleep(12);

                length--;
            }

            return result;
        }

        // Saves the current state inside a memento.
        public IMemento Save()
        {
            return new ConcreteMemento(this._state);
        }

        // Restores the Originator's state from a memento object.
        public void Restore(IMemento memento)
        {
            if (!(memento is ConcreteMemento))
            {
                throw new Exception("Unknown memento class " + memento.ToString());
            }

            this._state = memento.GetState();
            Console.Write($"Originator: Min state har ändrats till: {_state}");
        }
    }
}

    
