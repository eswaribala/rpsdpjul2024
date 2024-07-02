// See https://aka.ms/new-console-template for more information
using DesignPatternsApp;

//Console.WriteLine("Hello, World!");

    //Call the GetInstance static method to get the Singleton Instance
    PrivateSingleton fromTeacher = PrivateSingleton.GetInstance();
    fromTeacher.PrintDetails("From Teacher");
    //Call the GetInstance static method to get the Singleton Instance
    PrivateSingleton fromStudent = PrivateSingleton.GetInstance();
    fromStudent.PrintDetails("From Student");
    //Instantiating singleton from a Derived class. 
    //This violates Singleton Pattern Pattern.

  // PrivateSingleton.DerivedSingleton derivedObj = new PrivateSingleton.DerivedSingleton();
  // derivedObj.PrintDetails("From Derived");
    Console.ReadLine();


