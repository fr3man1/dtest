using System;
using System.Collections;
using System.Collections.Generic;


namespace testas_danske
{
    class MainClass
    {
        public static Array ReadFromFile() {
            string[] lines = System.IO.File.ReadAllLines(@"/Users/andrius/Projects/testas_danske/testas_danske.txt/EmptyTextFile.txt");
            return lines;
        }

        public static bool IsEven(int value)
        {
            return value % 2 == 0;
        }

        public static ArrayList readList()
        {
            var arrayList = new ArrayList();

            foreach (string line in ReadFromFile())
            {
                string[] elementList = line.Split(new Char[] { ' ' });

                var arrayRow = new ArrayList();

                foreach (string number in elementList)
                {
                    if (number.Trim() != "") {
                        int first_no;
                        Int32.TryParse( number, out first_no);
                        arrayRow.Add(first_no);

                    }

                    //Console.WriteLine(s);
                }
                arrayList.Add(arrayRow);
            }
            return arrayList;
        }


        public static ArrayList OddEvenArray (int length, bool is_even) {
            var OEarray  = new ArrayList();
            var i = 0;
            if (is_even) {
                for (i = 0; i < length; i++)
                {
                    OEarray.Add(i % 2);
                    //Console.WriteLine(OEarray[i]);
                }
            } else {
                length = length + 1;
                for (i = 1; i < length; i++)
                {
                    OEarray.Add(i % 2); 
                    //Console.WriteLine(OEarray[i-1]);
                }
            }



            return OEarray;
        }

        public static void Main(string[] args) {
            var i = 0;
            var b = 0;
            Console.WriteLine(readList().Count);
            //Determining if first member is even or odd
            //Then create a definition array of odd and even lines
            int count = readList().Count;
            bool first_is_even;
            //Int32.TryParse((string)((ArrayList)readList()[0])[0], out first_no);
            first_is_even = IsEven((int)((ArrayList)readList()[0])[0]);
            Console.WriteLine(first_is_even);
            var odd_even_array_def =  OddEvenArray(count, first_is_even);

            var all_even_vals = new ArrayList();
            var all_odd_vals = new ArrayList();
            var all_even_index = new ArrayList();
            var all_odd_index = new ArrayList();
            var even_array = new ArrayList();
            var odd_array = new ArrayList();

            for (i = 0; i < count; i++)
            {



                var index = 0;
                int odd_max = 0;
                int even_max = 0;


                for (b = 0; b < ((ArrayList)readList()[i]).Count; b++) {
                    var value = (int)((ArrayList)readList()[i])[b];
                    //if 0 even, if 1 odd
                    if( (int) odd_even_array_def[i] == 0) { 
                        if(value % 2 == 0) {
                            //get all odd vals with index
                            all_even_vals.Add(value);
                            all_even_index.Add(i,b)
                            if (value > odd_max)
                            {
                                odd_max = value;
                                index = b+1;
                            }
                        }
                    } else {
                        if (value % 2 != 0)
                        {
                            //get all odd vals with index
                            all_even_vals.Add(value);
                            all_even_index.Add(i, b);

                            if (value > even_max)
                            {
                                even_max = value;
                                index = b+1;
                            }
                        }
                    }
                }
                even_array.Add(all_even_vals, all_even_index);
                odd_array.Add(all_odd_vals, all_odd_index);

                //if (even_max != 0) Console.Write(even_max.ToString()+ " " + "odd_max" + "index:" + index + " ");
                //if (odd_max != 0) Console.Write(odd_max.ToString() + " " + "even_max" + "index:" + index + " ");
            }


            Console.Write(even_array[0][0] + "testas");







            //var i =0;
            //for (i = 0; i < readList().Count; i++)
            //{
            //    Console.WriteLine(readList()[i].ToString());
            //}



            //bool first = true;

            //foreach (ArrayList arr in readList())
            //{   
            //    foreach (string element in arr)
            //    {
            //        if (first) {
            //            int firstNo;
            //            Int32.TryParse(element, out firstNo);
            //            Console.WriteLine(IsOdd(firstNo));
            //            first = false;
            //        }
            //    }
            //}

        }

    }
}
