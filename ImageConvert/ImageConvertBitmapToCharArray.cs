using System.IO;
using System.Drawing;
using System;


namespace ImageConvert
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter either a directory or file path to process");
            Console.WriteLine("Results will be placed in your Documents folder under bitmapToText");
            string path = Console.ReadLine();

            if (File.Exists(path))
            {
                ProcessBitmap(path);
            }
            else if (Directory.Exists(path))
            {
                ProcessDirectory(path);
            }
            else
            {
                Console.WriteLine("{0} is not a valid path", path);
            }            
        }

        static void ProcessBitmap(string path)
        {
            string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string destinationFolder = documents + "/bitmapToText/";
            string destinationFile = destinationFolder + Path.GetFileNameWithoutExtension(path) + ".txt";
            string invertedFile = destinationFolder + Path.GetFileNameWithoutExtension(path) + "_Inverted.txt";

            Directory.CreateDirectory(destinationFolder);
            
            using (var image = new Bitmap(path))
            {
                using (var fileToWrite = new StreamWriter(destinationFile))
                {
                    using (var invertFileToWrite = new StreamWriter(invertedFile))
                    {
                        int width = image.Width;
                        int height = image.Height;

                        fileToWrite.Write("{");
                        invertFileToWrite.Write("{");

                        for (int row = 0; row < height; row++)
                        {
                            fileToWrite.Write("{");
                            invertFileToWrite.Write("{");

                            for (int column = 0; column < width; column++)
                            {
                                fileToWrite.Write("'" + (image.GetPixel(column, row).R == 255 ? 0 : 1) + "', ");
                                invertFileToWrite.Write("'" + (image.GetPixel(column, row).R == 255 ? 1 : 0) + "', ");
                            }
                            fileToWrite.WriteLine("},");
                            invertFileToWrite.WriteLine("},");
                        }

                        fileToWrite.Write("}");
                        invertFileToWrite.Write("}");
                    }
                }
            }
        }        

        static void ProcessDirectory(string path)
        {
            string[] files = Directory.GetFiles(path, "*.bmp");

            foreach(string file in files)
            {
                ProcessBitmap(file);
            }
        }
    }
}      
