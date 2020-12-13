using System;
using System.Threading;

namespace Inlämning
{  
    class Originator
    {
        
        public string _state;
        public Func<int> read;

        public Originator(string state)
        {
            this._state = state;
            Console.WriteLine("Originator: min state: " + state);
        }

        public Originator(Func<int> read)
        {
            this.read = read;
        }

      
        public void DoSomething()
        {
            Console.WriteLine("Originator: Jag gör något viktigt.");
            this._state = this.GenerateRandomString(10);
            Console.WriteLine($"Originator: och min state har ändrats till: {_state}");
        }

        private string GenerateRandomString(int length = 10)
        {
            string allowedSymbols = "alen voli milovana";
            string result = string.Empty;

            while (length > 0)
            {
                result += allowedSymbols[new Random().Next(0, allowedSymbols.Length)];

                Thread.Sleep(12);

                length--;
            }

            return result;
        }

        
        public Memento Save()
        {
            return new ConcreteMemento(this._state);
        }

        
        public void Restore(Memento memento)
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

    
