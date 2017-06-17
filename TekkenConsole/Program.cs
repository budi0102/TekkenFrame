using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekkenDB;
using TekkenDB.Helpers;
using TekkenDB.Enums;

namespace TekkenConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            testweb();
        }
        private static void test1()
        {
            Moves basicMoves = new Moves();
            Move first = new Move();
            Command command = new Command();
            command.Directions = new Directions();
            command.Limb = new Limb(LimbEnum.LeftPunch);
            command.ActiveFrame = new Frame(10);
            command.GuardedFrame = new FrameAdvantage(1);
            command.HitFrame = new FrameAdvantage(5);
            command.CounterHitFrame = new FrameAdvantage(6);
            command.Damage = new Damage(8);
            command.HitPosition = HitPosition.High;
            first.Commands = new Commands(command);
            basicMoves.Add(first);

            Tekken TekkenTagTournament2 = new Tekken();
            TekkenTagTournament2.Name = new Name();
            TekkenTagTournament2.Name.English = "Tekken Tag Tournament 2";

            TekkenTagTournament2.Version = TekkenVersion.TekkenTagTournament2;

            TekkenTagTournament2.Characters = new Characters();

            Character Law = new Character();
            Law.BasicMoves = basicMoves;
            TekkenTagTournament2.Characters.Add(Law);



            string filepath = "law3.json";
            string filepath2 = "TTT2.json";
            TekkenDB.DBWriter.DbWriter.Write(basicMoves, filepath);
            TekkenDB.DBWriter.DbWriter.Write(TekkenTagTournament2, filepath2);

            Console.WriteLine(basicMoves);

            try
            {
                Moves moves = TekkenDB.DbReader.DbReader.Read<Moves>(filepath);
                Tekken newTekken = TekkenDB.DbReader.DbReader.Read<Tekken>(filepath2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        private static void testweb()
        {
            
        }
    }
}
