using System;
using System.Linq;

namespace LINQpractice {
    class Program {

        static int[] xints = {
                863, 550, 970, 341, 293, 732, 356, 699, 593, 553,
                726, 865, 646, 737, 986, 231, 288, 314, 132, 628,
                839, 465, 137, 905, 456, 204, 181, 144, 285, 409,
                970, 135, 313, 351, 701, 535, 572, 571, 813, 160,
                435, 773, 564, 344, 608, 115, 490, 965, 142, 543,
                813, 802, 274, 342, 812, 976, 184, 291, 720, 267,
                144, 200, 299, 292, 458, 294, 263, 823, 932, 375,
                631, 962, 916, 448, 622, 711, 510, 765, 474, 904,
                310, 460, 963, 934, 375, 203, 488, 894, 655, 807,
                254, 464, 565, 463, 872, 965, 733, 289, 720, 904 };

        static int[] yints = {
                918, 211, 821, 528, 339, 871, 751, 446, 379, 556,
                294, 127, 390, 385, 466, 254, 811, 784, 864, 732,
                790, 347, 574, 190, 335, 694, 794, 356, 122, 505,
                678, 233, 103, 174, 439, 926, 417, 878, 900, 618,
                341, 654, 389, 763, 910, 165, 667, 630, 834, 528,
                992, 618, 407, 559, 394, 184, 745, 338, 195, 551,
                932, 935, 414, 432, 172, 438, 491, 605, 532, 905,
                767, 917, 386, 531, 180, 713, 696, 934, 953, 958,
                866, 231, 403, 100, 856, 653, 368, 799, 755, 641,
                524, 715, 522, 155, 704, 214, 174, 594, 689, 392 };

        static int[] zints = {
                822, 287, 886, 897, 398, 163, 868, 800, 977, 766,
                847, 926, 644, 438, 971, 961, 638, 676, 423, 630,
                546, 680, 638, 549, 354, 310, 630, 817, 483, 459,
                648, 253, 820, 810, 237, 179, 343, 313, 553, 618,
                475, 686, 715, 676, 823, 348, 235, 231, 417, 829,
                917, 354, 515, 858, 324, 718, 297, 808, 853, 825,
                461, 701, 989, 903, 949, 373, 596, 163, 166, 983,
                407, 313, 186, 428, 254, 298, 673, 687, 396, 915,
                968, 585, 144, 888, 402, 590, 376, 470, 575, 794,
                927, 357, 911, 389, 853, 451, 927, 412, 725, 659 };

        static int[] ints = {
            340,380,691,470,699,
            447,115,837,466,592,
            418,358,195,217,562,
            811,647,687,846,411
            };

        static void TestLinqQuerySyntaxNotes() {

            //LINQ query call
            var qResult = from i in ints
                          where i >= 300 && i <= 499
                          //orderby i descending
                          select i;
            Console.WriteLine($"{qResult.Sum()}");

            //LINQ query call alternative
            var qResult2 = (from i in ints
                           where i >= 300 && i <= 499
                           //orderby i descending
                           select i).Sum();
            Console.WriteLine($"{qResult2}");

            //LINQ Method call
            var mResult = ints.Where(i => i >= 300 && i <= 499)
                                .Sum(i => i);
            Console.Write($"{mResult}");
        }

        static void QueryPractice() {
            var qResult = (from i in ints
                           where i < 300 || i > 800
                           select i).Sum();
            Console.Write($"{qResult}");
        }

        static void MethodPractice() {
            var mResult = ints.Where(i => i < 300 || i > 800).Sum();
            Console.Write($"{mResult}");
        }

        static void xIntsMethodPractice() {
            var xMin = xints.Min();
            Console.WriteLine($"xMin = {xMin}");

            var xMax = xints.Max();
            Console.WriteLine($"xMax = {xMax}");

            var xAvg = xints.Max();
            Console.WriteLine($"xAvg = {xAvg}");
        }

        static void xIntsQueryPractice() {
            var xMin = (from xi in xints select xi).Min();
            Console.WriteLine($"xMin = {xMin}");

            var xMax = (from xi in xints select xi).Max();
            Console.WriteLine($"xMax = {xMax}");

            var xAvg = (from xi in xints select xi).Average();
            Console.WriteLine($"xAvg = {xAvg}");
        }

        static void yIntsQueryPractice() {
            var yOddsSum = (from yi in yints
                            where yi <= 100 && yi < 200 ||
                                   yi >= 300 && yi <= 399 ||
                                   yi >= 500 && yi <= 599 ||
                                   yi >= 700 && yi <= 799 ||
                                   yi >= 900 && yi <= 999
                                   select yi).Sum();
            Console.WriteLine($"yOddSum = {yOddsSum}");
        }

        static void yIntsMethodPractice() {
            var yOddHundredsSum = yints.Where(yi => yi >= 100 && yi <= 199 ||
                                            yi >= 300 && yi <= 399 ||
                                            yi >= 500 && yi <= 599 ||
                                            yi >= 700 && yi <= 799 ||
                                            yi >= 900 && yi <= 999).Sum();
            Console.WriteLine($"yOddSum = {yOddHundredsSum}");

        }

        static void JoinXZintsPractice() {
            var inCommon = from x in xints
                           join z in zints
                           on x equals z
                           orderby z
                           select z;
            Console.WriteLine("In Common: ");
            foreach (var i in inCommon)
                Console.Write($"{i}, ");
        }

        static void PrintZintsGreaterThanZaverage() { 
            var zAvg = from zi in zints
                        where zi > zints.Average()
                        orderby zi
                        select zi;
            Console.WriteLine($"\n\nZints Avg: {zints.Average()}" +
                $"Cnt: {zAvg.Count()}\n");
            foreach(var i in zAvg)
                Console.WriteLine($"{i} ");
            Console.WriteLine();
        }

        static void Main(string[] args) {
            PrintZintsGreaterThanZaverage();
        }
    }
}
