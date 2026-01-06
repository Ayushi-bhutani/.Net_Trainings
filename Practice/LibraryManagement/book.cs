
using System;
namespace library{
    public class Book
    {
        private int availableCopies {get; set;}

        public Book(int initialCopies){
            if(initialCopies < 0){
                throw new ArgumentException("Initial copies cannot be negative");
            }
            availableCopies = initialCopies;
        }

        public bool Borrow(){
            if(availableCopies > 0){
                availableCopies--;
                return true;
            }
            return false;
        }

        

        public void ReturnBook(){
            availableCopies++;
        }

        
        

    }
}