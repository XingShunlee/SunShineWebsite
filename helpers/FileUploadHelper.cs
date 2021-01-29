using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ehaiker
{
    public class FileUploadHelper
    {
        public static bool CheckTrueFileName(string filename, FileExtension[] fileEx)
        {
            System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.IO.BinaryReader r = new System.IO.BinaryReader(fs);
            string bx = " ";
            byte buffer;
            try
            {
                buffer = r.ReadByte();
                bx = buffer.ToString();
                buffer = r.ReadByte();
                bx += buffer.ToString();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            r.Close();
            fs.Close();
            foreach (FileExtension fe in fileEx)
            {
                if (Int32.Parse(bx) == (int)fe)
                    return true;
            }
            return false;

        }
        public static bool CheckTrueFileNameEx(System.IO.Stream fs, FileExtension[] fileEx)
        {
            System.IO.BinaryReader r = new System.IO.BinaryReader(fs);
            string bx = " ";
            byte buffer;
            try
            {
                buffer = r.ReadByte();
                bx = buffer.ToString();
                buffer = r.ReadByte();
                bx += buffer.ToString();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            r.Close();
            foreach (FileExtension fe in fileEx)
            {
                if (Int32.Parse(bx) == (int)fe)
                    return true;
            }
            return false;

        }
        public static List<string> FindImg(string sSource, string prefix)
        {
            var files = Directory.GetFiles(sSource, "*.*", SearchOption.TopDirectoryOnly)
 .Where(s => s.EndsWith(".png") || s.EndsWith(".jpg") || s.EndsWith(".gif"));
            List<string> filelist = new List<string>();
            foreach (string file in files)
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(file);
                if (fi.Extension == ".jpg" || fi.Extension == ".png" || fi.Extension == ".gif")
                {
                    string dname = prefix + fi.Name;
                    filelist.Add(dname);
                }
            }
            return filelist;
        }
        public enum FileExtension
        {
            JPG = 255216,
            GIF = 7173,
            BMP = 6677,
            PNG = 13780,
            COM = 7790,
            EXE = 7790,
            DLL = 7790,
            RAR = 8297,
            ZIP = 8075,
            XML = 6063,
            HTML = 6033,
            ASPX = 239187,
            CS = 117115,
            JS = 119105,
            TXT = 210187,
            SQL = 255254,
            BAT = 64101,
            BTSEED = 10056,
            RDP = 255254,
            PSD = 5666,
            PDF = 3780,
            CHM = 7384,
            LOG = 70105,
            REG = 8269,
            HLP = 6395,
            DOC = 208207,
            XLS = 208207,
            DOCX = 208207,
            XLSX = 208207,
        }
    }
}