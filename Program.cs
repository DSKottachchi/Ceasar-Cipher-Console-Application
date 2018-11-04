using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
                                  //UCLan ID: G20761896      UCL ID: 3000031
namespace ProgrammingAssignment
{    
    class Program
    {
        
            static char[] alphabet = new char[26] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' }; //Upper case alphabet array

            static void Main(string[] args)
            {
                ShowMenu(); //Displays menu screen
                Console.ReadLine();
            }//end Main


            static void ShowMenu()
            {
                Console.WriteLine("\n***********************Welcome************************");
                Console.WriteLine("\n\nEnter choice:\n[1]Encrypt Secret Message\n[2]Decrypt Secret Message\n[3]Quit");
                int choice = 0;
                do
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            EncryptMsg(); //call encrypt method
                            Console.Read();
                            break;
                        case 2:
                            DecryptMsg(); //call decrypt method
                            Console.Read();
                            break;
                        case 3: //Exit screen
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid Choice\nEnter choice again");
                            break;
                    }//end switch case

                } while (choice != 3);

            }//end ShowMenu

            static void EncryptMsg()
            {
                Console.WriteLine("Enter the Plain text message:");
                string PlainText = Console.ReadLine();
                string uppercase = PlainText.ToUpper();   // converts the text into uppercase characters
                char[] character = uppercase.ToCharArray();   // splits the text into seperate characters

            Console.WriteLine("Enter the Offset Key");
                int num = Convert.ToInt32(Console.ReadLine());
                int key = OffsetKey(num); //offset key is called from the method

            
                for (int i = 0; i < character.Length; i++)
                {
                  for (int j = 0; j < alphabet.Length; j++)
                  {
                    if (alphabet[j] == character[i]) //checks whether the character of the alphabet is equal to the character in the text)
                    {
                        int newindex = (j + key) % 26;  //adding the offset key to the old index (j)
                        string encrymesg = alphabet[newindex].ToString();
                        Console.Write(encrymesg);
                    }
                  }// end inner for loop
               
                    if (char.IsPunctuation(character[i])) //checks whether the character is a punctuation mark
                    {
                        Console.Write(character[i]);
                    }

                    else if (char.IsSymbol(character[i])) //checks whether the character is a symbol
                    {
                        Console.Write(character[i]);
                    }

                    else if (char.IsNumber(character[i])) //checks whether the user enters a number and doesn't encrypt it
                    {
                        Console.Write(character[i]);
                    }

                    else if (char.IsWhiteSpace(character[i])) //whitespace characters would not be decrypted 
                    {
                        Console.Write(character[i]);
                    }

                } //end outer for loop

            }//end Encrypt()


            static void DecryptMsg()
            {
                Console.WriteLine("Enter the Cipher Text message:");
                string Ciphertext = Console.ReadLine();
                string uppercase = Ciphertext.ToUpper(); // converts the text into uppercase characters
                char[] character = uppercase.ToCharArray(); // splits the text into seperate characters

                Console.WriteLine("Enter the Offset Key");
                int num = Convert.ToInt32(Console.ReadLine());
                int key = OffsetKey(num); //offset key is called from the method
                string decryptmesg;
                for (int i = 0; i < character.Length; i++)
                {
                    for (int j = 0; j < alphabet.Length; j++)
                    {
                      if (alphabet[j] == character[i]) //checks whether the character of the alphabet is equal to the character in the text)
                      {
                        int newindex = (j - key) % 26;
                        if (newindex < 0)
                        {
                            newindex += alphabet.Length;
                            decryptmesg = alphabet[newindex].ToString();
                            Console.Write(decryptmesg);
                        }
                        else
                        {
                            decryptmesg = alphabet[newindex].ToString();
                            Console.Write(decryptmesg);
                        }
                      }// end outer if
                    }//end inner for

                    if (char.IsPunctuation(character[i])) //checks whether the character is a punctuation mark
                    {
                        Console.Write(character[i]);
                    }

                    else if (char.IsSymbol(character[i])) //checks whether the character is a symbol
                    {
                        Console.Write(character[i]);
                    }

                    else if (char.IsNumber(character[i])) //checks whether the user enters a number and doesn't encrypt it
                    {
                        Console.Write(character[i]);
                    }

                    else if (char.IsWhiteSpace(character[i])) //whitespace characters would not be decrypted 
                    {
                        Console.Write(character[i]);
                    }

                }//end outer for

            }//DecryptMsg


          
        static int OffsetKey(int key)
        {
            if (key >= 0 & key <= 25)  //The OffsetKey should be in the range of (0 - 25)
            {
                for (int k = 0; k <= 0; k++)
                {
                    for (int d = 0; d < key; d++)
                    {
                        Console.Write("-");
                    }
                    Console.Write(alphabet);
                    Console.WriteLine();
                    for (int c = 0; c < key; c++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine("|");
                    Console.WriteLine(alphabet);
                }
            }
            else
            {
                Console.WriteLine("Invalid Key\nEnter Offset once again:");
                
                Console.Read();
            }
            return key;
        }


    }//end class
}//end namespace


