
using System;
namespace library{
    public class Book
    {
        public int AvailableCopies { get; private set; }


        public Book(int initialCopies){
            if(initialCopies < 0){
                throw new ArgumentException("Initial copies cannot be negative");
            }
            AvailableCopies = initialCopies;
        }

        public bool Borrow(){
            if(AvailableCopies > 0){
                AvailableCopies--;
                return true;
            }
            return false;
        }

        

        public void ReturnBook(){
            AvailableCopies++;
        }

        
        

    }
}