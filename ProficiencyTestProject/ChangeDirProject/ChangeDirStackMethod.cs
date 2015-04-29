using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace sriniChangeDirProject
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
        /// Using Standard undo machanism using Stack
        /// </summary>
        /// <param name="newPath"></param>
        /// <returns></returns>
        public Path Cd(string newPath)
        {

            string[] aszcurrentPath = CurrentPath.Split('/');   //Get each Folder name  as string array
            string[] asznewPath = newPath.Split('/');           //Get new path 


            //creating a Folder stack putting all the folders to the stack.
            var Folderstack = new Stack<string>(aszcurrentPath);

            try
            {
                
                //Loop through the New path and check if we ask for parent dir and pop one folder
                for (int i = 0; i < asznewPath.Length; i++)
                {
                    if (asznewPath[i] == "..")
                    {
                        if (Folderstack.Count > 0)
                        {
                            Folderstack.Pop();  //Now stack will have its previous folder
                        }
                    }
                    else
                    {
                        Folderstack.Push(asznewPath[i]);  //pushing the new path
                    }
                }
                CurrentPath = String.Join("/", Folderstack.ToArray().Reverse());// Current path will be reverse of Folder stack stored.
                return new Path(CurrentPath);
            }
            catch (Exception Ex)
            {
                return this;
            }
            finally
            {
                if (Folderstack != null)
                {
                    Folderstack = null;
                }
             
            }
            
        }
        //public static void Main(string[] args)
        //{
        //    Path path = new Path("/a/b/c/d");
        //    Console.WriteLine(path.Cd("../x").CurrentPath);
        //    Console.ReadKey();
        //}
    }
}
