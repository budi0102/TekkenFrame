using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TekkenDB.Helpers;
using TekkenDB.Enums;
using Newtonsoft.Json;

namespace TekkenDB
{
    [DataContract]
    public class Character
    {
        [DataMember]
        public Name Name { get; set; }
        [DataMember]
        public string Introduction { get; set; }
        [DataMember]
        public TekkenVersion TekkenVersion { get; set; }
        [DataMember]
        public Moves BasicMoves { get; set; }
        [DataMember]
        public Moves TenHits { get; set; }
        [DataMember]
        public Moves Specials { get; set; }
        [DataMember]
        public Moves Throws { get; set; }
        [DataMember]
        public Moves Combos { get; set; }
        [DataMember]
        public PunishMoves Punishes{ get; set; }

        public Character()
        {
            Name = null;
            Introduction = null;
            TekkenVersion = Enums.TekkenVersion.Unknown;
        }
        public Character(string filepath)
        {
            ReadFile(filepath);
        }
        public Character(Name name, string introduction, TekkenVersion tekkenVersion, Moves basicMoves, Moves tenHits, Moves specials, Moves throws, Moves combos, PunishMoves punishMoves)
        {
            Name = new Name(name);
            Introduction = introduction;
            TekkenVersion = tekkenVersion;
            BasicMoves = new Moves(basicMoves);
            TenHits = new Moves(tenHits);
            Specials = new Moves(specials);
            Throws = new Moves(throws);
            Combos = new Moves(combos);
            Punishes = new PunishMoves(punishMoves);
        }
        public Character(Character character)
            : this(character.Name, character.Introduction, character.TekkenVersion, character.BasicMoves, character.TenHits, character.Specials, character.Throws, character.Combos, character.Punishes)
        {
        }

        public void ReadFile(string filepath)
        {
            if (!string.IsNullOrEmpty(filepath) && File.Exists(filepath))
            {
                using (StreamReader sr = File.OpenText(filepath))
                {
                    string text = sr.ReadToEnd();
                    try
                    {
                        Character achar = JsonConvert.DeserializeObject<Character>(text);
                        if (achar != null)
                        {
                            Name = new Name(achar.Name);
                            Introduction = achar.Introduction;
                            TekkenVersion = achar.TekkenVersion;
                            BasicMoves = new Moves(achar.BasicMoves);
                            TenHits = new Moves(achar.TenHits);
                            Specials = new Moves(achar.Specials);
                            Throws = new Moves(achar.Throws);
                            Combos = new Moves(achar.Combos);
                            Punishes = new PunishMoves(achar.Punishes);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
        }
        public async Task<Character> ReadFileAsync(string filepath)
        {
            if (!string.IsNullOrEmpty(filepath) && File.Exists(filepath))
            {
                using (StreamReader sr = File.OpenText(filepath))
                {
                    string text = await sr.ReadToEndAsync();
                    try
                    {
                        Character achar = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Character>(text));
                        if (achar != null)
                        {
                            Name = new Name(achar.Name);
                            Introduction = achar.Introduction;
                            TekkenVersion = achar.TekkenVersion;
                            BasicMoves = new Moves(achar.BasicMoves);
                            TenHits = new Moves(achar.TenHits);
                            Specials = new Moves(achar.Specials);
                            Throws = new Moves(achar.Throws);
                            Combos = new Moves(achar.Combos);
                            Punishes = new PunishMoves(achar.Punishes);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
            return this;
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
