using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RF3ArchiveTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RF3ArchiveTool");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Drag and drop the rf3Archive.arc on this program");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("This project is not completed!!!");
            Console.ReadKey();
            Console.ResetColor();
        }
        
    }
}
    /*static void Unpackrf3Archive(string FileName)
{
    using (FileStream Input = new FileStream(FileName, FileMode.Open))
    {
        BinaryReader Reader = new BinaryReader(Input);

        int Index = 0;
        string OutFolder = Path.Combine(Path.GetDirectoryName(FileName), "rf3Archive.arc_ext");*/
