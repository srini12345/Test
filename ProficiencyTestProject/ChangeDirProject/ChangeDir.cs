using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace ChangeDirProject
{
    public class Path
    {
        public string CurrentPath { get; private set; }

        /// <summary>
        /// Constructor for Current Path of the Folder 
        /// </summary>
        /// <param name="path"></param>
        public Path(string path)
        {
            this.CurrentPath = path;

        }
        /// <summary>
        /// Using the File.IO methods
        /// </summary>
        /// <param name="newPath"></param>
        /// <returns></returns>
        public Path Cd(string newPath)
        {
            string PreviousPath = CurrentPath;
            try
            {
                if (Directory.Exists(CurrentPath))
                {
                    Directory.SetCurrentDirectory(CurrentPath);
                    DirectoryInfo dirinfo = new DirectoryInfo(CurrentPath);
                    string[] asznewPath = newPath.Split('/');
                    for (int i = 0; i < asznewPath.Length; i++)
                    {
                        if (asznewPath[i] == "..")
                        {
                            dirinfo = Directory.GetParent(CurrentPath);
                            if (dirinfo != null)
                            {
                                CurrentPath = dirinfo.FullName;
                            }
                            else
                            {
                                //Already Reached Parent Directory and still trying to move one level up so returing
                                CurrentPath = PreviousPath;
                                Console.WriteLine("Reached Parent Directory and still trying to move one level up");
                            }
                        }
                        else
                        {
                            CurrentPath = CurrentPath + "\\" + asznewPath[i];
                        }
                    }
                }

                return this;
            }
            catch (Exception Ex)
            {
                CurrentPath = string.Empty;
                Console.WriteLine(Ex.ToString());
                return this;
            }
        }
        public static void Main(string[] args)
        {
            Path path = new Path(@"c:\Android_SDK_Installs\android-sdk\add-ons");
            Console.WriteLine(path.Cd("../build-tools/20.0.0").CurrentPath);
            Console.ReadKey();
        }
    }
}
