using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TekkenDB
{
    [DataContract]
    public class Characters : ObservableCollection<Character>, IEnumerable<Character>, ICollection<Character>, IList<Character>
    {
        #region Constructors
        public Characters()
            : base()
        {
        }
        public Characters(IEnumerable<Character> characters)
            : base(characters)
        {
        }
        public Characters(Characters characters)
            : base(characters.Items)
        {
        }
        #endregion


        #region Public Members
        [DataMember(Name = "Characters")]
        protected internal List<Character> Members
        {
            get
            {
                return members;
            }
            set
            {
                members = value;
                this.Clear();
                foreach (Character member in members)
                {
                    this.Add(member);
                }
            }
        }

        public static Characters ReadFromFiles(string directoryPath)
        {
            if (!string.IsNullOrEmpty(directoryPath) && Directory.Exists(directoryPath))
            {
                Characters result = new Characters();
                foreach (string file in Directory.GetFiles(directoryPath))
                {
                    result.Add(new Character(file));
                }
                return result;
            }
            return null;
        }
        public static async Task<Characters> ReadFromFilesAsync(string directoryPath)
        {
            if (!string.IsNullOrEmpty(directoryPath) && Directory.Exists(directoryPath))
            {
                Characters result = new Characters();
                foreach (string file in Directory.GetFiles(directoryPath))
                {
                    result.Add(await new Character().ReadFileAsync(file));
                }
                return result;
            }
            return null;
        }
        #endregion

        #region private members
        private List<Character> members;
        #endregion


    }
}
