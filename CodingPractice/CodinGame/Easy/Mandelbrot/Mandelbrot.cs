using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodingPractice.CodinGame.Easy.Mandelbrot
{
    class Mandelbrot
    {
        static void Main(string[] args)
        {
            string c = Console.ReadLine();
        int m = int.Parse(Console.ReadLine());

        Regex rx = new Regex(@"^(.+?)(\+|\-)(.+?)i$");
        Match match = rx.Match(c);
        
        double r = double.Parse(match.Groups[1].Value);
        string op = match.Groups[2].Value;
        double i = double.Parse(match.Groups[3].Value)*(op == "-" ? -1 : 1);
        
        Console.Error.WriteLine(r + " " + i + "i");
        
        Complex cComp = new Complex(r, i);
        int count = 0;
        Complex complex = new Complex(0, 0);
        double val = 0;

        while(val < 2 && count < m){
            complex = Complex.Sqr(complex) + cComp;
            count++;
            val = (double) Math.Sqrt((double)Math.Pow(complex.real, 2) + (double)Math.Pow(complex.imaginary, 2));
            Console.Error.WriteLine(count + ": " + complex.real + " " + complex.imaginary + "i" );
        }
        
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(count);
    }
    
    public struct Complex {
        public double real;
        public double imaginary;
        
        public Complex(double real, double imaginary) {
          this.real = real;
          this.imaginary = imaginary;
        }
        
        public static Complex operator +(Complex one, Complex two) {
          return new Complex(one.real + two.real, one.imaginary + two.imaginary);
        }
        
        public static Complex Sqr(Complex one) {
          return new Complex(one.real*one.real - one.imaginary*one.imaginary, 2*one.real*one.imaginary);
        }
        
        public override string ToString() {
          return (String.Format("{0} + {1}i", real, imaginary));
        }
    }
}
