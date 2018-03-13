using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace B6.Core
{
    public class Customer
    {
        public Customer(string firstName, string lastName, int age, string docTitle, string docContent)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            DocumentFile = new DocumentFile(docTitle, docContent);
        }

        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }
        public DocumentFile DocumentFile { get; }
        
        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
