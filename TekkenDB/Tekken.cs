using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TekkenDB.Helpers;
using TekkenDB.Enums;

namespace TekkenDB
{
    [DataContract]
    public class Tekken
    {
        #region Public Members
        [DataMember]
        public Name Name { get; set; }
        [DataMember]
        public TekkenVersion Version { get; set; }

        [DataMember]
        public Characters Characters { get; set; }

        [IgnoreDataMember]
        public string FilePath
        {
            get
            {
                return filePath;
            }
            set
            {
                filePath = value;
            }
        }
        #endregion

        #region Constructors
        public Tekken()
        {
            Name = new Name();
            Version = TekkenVersion.Unknown;
        }
        
        public Tekken(Name name, TekkenVersion version, Characters characters = null)
        {
            Name = new Name(name);
            Version = version;
            if (characters != null)
            {
                Characters = new Characters(characters);
            }
            else
            {
                Characters = null;
            }
        }

        public Tekken(Tekken tekken)
        {
            Name = new Name(tekken.Name);
            Version = tekken.Version;
            Characters = new Characters(tekken.Characters);
            filePath = tekken.filePath;
        }
        #endregion

        #region Public Methods
        public void ReadCharacters(string directoryPath)
        {
            if (!string.IsNullOrEmpty(directoryPath) && Directory.Exists(directoryPath))
            {
                Characters = Characters.ReadFromFiles(directoryPath);
            }
        }
        public async Task ReadCharactersAsync(string directoryPath)
        {
            if(!string.IsNullOrEmpty(directoryPath) && Directory.Exists(directoryPath))
            {
                Characters = await Characters.ReadFromFilesAsync(directoryPath);
            }
        }
        #endregion

        #region private members
        private string filePath;
        #endregion
    }
}
