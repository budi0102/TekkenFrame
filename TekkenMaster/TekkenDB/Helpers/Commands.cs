using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TekkenDB.Helpers
{
    [DataContract]
    public class Commands : IEnumerable<Command>
    {
        #region Public Members
        [DataMember]
        public ReadOnlyCollection<Command> List
        {
            get
            {
                return commands.AsReadOnly();
            }
        }

        [IgnoreDataMember]
        public Command this[int index]
        {
            get
            {
                return commands[index];
            }
        }
        [IgnoreDataMember]
        public Command this[string name]
        {
            get
            {
                return commands.FirstOrDefault(o => o.ToString().Equals(name));
            }
        }
        #endregion

        #region Constructors
        private Commands()
        {
            this.commands = new List<Command>();
        }
        public Commands(Command command)
            : this()
        {
            this.commands.Add(command);
        }
        public Commands(Commands commands)
        {
            this.commands = commands.commands;
        }
        public Commands(IEnumerable<Command> commands)
        {
            if (commands is List<Command>)
            {
                this.commands = (List<Command>)commands;
            }
            else
            {
                this.commands = commands.ToList();
            }
        }
        #endregion

        #region Public Methods
        public override string ToString()
        {
            return string.Join(";", commands);
        }

        public IEnumerator<Command> GetEnumerator()
        {
            return ((IEnumerable<Command>)commands).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Command>)commands).GetEnumerator();
        }
        #endregion

        #region private members
        private List<Command> commands;
        #endregion
    }
}
