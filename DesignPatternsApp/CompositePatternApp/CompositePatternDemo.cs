using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePatternApp
{
    // The Base Component Abstract class declares the common operations for both Leaf and Composite objects.
    public abstract class FileSystemItem
    {
        public string Name { get; }

        public FileSystemItem(string name)
        {
            this.Name = name;
        }

        //The following method is going to be overridden in both Leaf and Composite class
        public abstract decimal GetSizeinKB();
    }

    // This is going to be our Leaf class that represents the end objects. 
    // A leaf cannot have any children.
    // The Leaf object is the Object which does the actual work
    public class FileItem : FileSystemItem
    {
        //The following Property is going to hold the size of the file
        public long FileBytes { get; }
        //While creating the Leaf Object i.e. while Creating the FileItem Object,
        //we need to pass the File Name and the Size of the File
        //The File Name we need to pass the Base class constructor
        public FileItem(string name, long fileBytes) : base(name)
        {
            this.FileBytes = fileBytes;
        }

        //We need to override the following method to provide the actual implementation
        public override decimal GetSizeinKB()
        {
            //Divide the size which will be in bytes with the value of 1024 to convert into KB
            return decimal.Divide(this.FileBytes, 1024);
        }
    }

    // This is going to be our Composite class that represents the Composite objects. 
    // A Composite Object has children. 
    // The Children Can be a Leaf Object or Can be another Composite Object
    // The Composite objects delegate the actual work to their children and then combine the result.
    public class Directory : FileSystemItem
    {
        //The Following variable is going to hold all the child components of a composite components
        private List<FileSystemItem> Childrens = new List<FileSystemItem>();
        //The Constructor takes the Composite name as the input parameter
        public Directory(string name) : base(name)
        {
        }

        //The following Method is used to add Child Components inside the Composite Component
        public void AddComponent(FileSystemItem NewNode)
        {
            this.Childrens.Add(NewNode);
        }
        //The following Method is used to Remove Child Components inside the Composite Component
        public void RemoveComponent(FileSystemItem RemoveNode)
        {
            this.Childrens.Remove(RemoveNode);
        }
        //Override the FileSystemItem class GetSizeinKB Method
        public override decimal GetSizeinKB()
        {
            // Summarizing the size of children
            return this.Childrens.Sum(x => x.GetSizeinKB());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // The Client Code will work with all of the components (Both Leaf and Composite) via the base abstract class i.e. FileSystemItem.
            // FileSystemItem means the class that implements the FileSystemItem abstract class
            //Creating Leaf Objects i.e. Creating Files
            FileSystemItem MyBook = new FileItem("MyBook.txt", 12000);
            FileSystemItem MyVideo = new FileItem("MyVideo.mp4", 1000000);
            FileSystemItem MyMusic = new FileItem("MyMusic.mp3", 20000);
            FileSystemItem MyResume = new FileItem("MyResume.pdf", 18000);
            FileSystemItem MySoftware = new FileItem("MySoftware.exe", 250000);
            FileSystemItem MyDocument = new FileItem("MyDocument.doc", 87000000);

            //Create the Root Directory i.e. Composite Object 
            Directory RootDirectory = new Directory("RootDirectory");

            //Add 2 More Folders i.e. two more composite objects  
            Directory Folder1 = new Directory("Folder1");
            Directory Folder2 = new Directory("Folder2");
            //Add the above two folders under Root Directory
            RootDirectory.AddComponent(Folder1);
            RootDirectory.AddComponent(Folder1);
            //Add files to Folder 1   
            Folder1.AddComponent(MyBook);
            Folder1.AddComponent(MyVideo);
            //Create a Sub Folder1  
            Directory SubFolder1 = new Directory("Sub Folder1");
            //Add files under Sub Folder1  
            SubFolder1.AddComponent(MyMusic);
            SubFolder1.AddComponent(MyResume);
            //Add Sub Folder1 under Folder 1
            Folder1.AddComponent(SubFolder1);
            //Add files to folder 2  
            Folder2.AddComponent(MySoftware);
            Folder2.AddComponent(MyDocument);
            Console.WriteLine("Composite Objects:");
            Console.WriteLine($"Total size of (RootDirectory): {RootDirectory.GetSizeinKB()} KB");
            Console.WriteLine($"Total size of (Folder 1): {Folder1.GetSizeinKB()}KB");
            Console.WriteLine($"Total size of (Folder 2): {Folder2.GetSizeinKB()}KB");
            Console.WriteLine($"Total size of (SubFolder 1): {SubFolder1.GetSizeinKB()}KB");
            Console.WriteLine("\nLeaf Objects:");
            Console.WriteLine($"Total size of MyVideo File: {MyVideo.GetSizeinKB()}KB");
            Console.WriteLine($"Total size of MyResume File: {MyResume.GetSizeinKB()}KB");
            Console.WriteLine($"Total size of MyBook File: {MyBook.GetSizeinKB()}KB");
            Console.WriteLine($"Total size of MyDocument File: {MyDocument.GetSizeinKB()}KB");
            Console.Read();
        }
    }
}
