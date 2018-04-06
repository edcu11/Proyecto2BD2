using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTBD2FB
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source = edgar.dbo");
            connection.Open();
            var pingCommand = new SQLiteCommand("select ping('127.0.0.1')", connection);
            var pmtCommand = new SQLiteCommand("select pmt(0.10, 20, 2000)", connection);
            var bin2decCommand = new SQLiteCommand("select bin2dec('0101')", connection);
            var dec2binCommand = new SQLiteCommand("select dec2bin('5')", connection);
            var c2fCommand = new SQLiteCommand("select c2f(23)", connection);
            var f2cCommand = new SQLiteCommand("select f2c(79)", connection);
            var factorialCommand = new SQLiteCommand("select factorial(5)", connection);
            var hex2decCommand = new SQLiteCommand("select hex2dec('c')", connection);
            var dec2hexCommand = new SQLiteCommand("select dec2hex(12)", connection);
            var compareCommand = new SQLiteCommand("select CompareS('adios', 'adios')", connection);
            var trimCommand = new SQLiteCommand("select trim('adios', 'a')", connection);
            var repeatCommand = new SQLiteCommand("select repeat('adios', 2)", connection);

            Console.WriteLine("PING: " + pingCommand.ExecuteScalar());
            Console.WriteLine("pmtCommand: " + pmtCommand.ExecuteScalar());
            Console.WriteLine("dec2binCommand: " + dec2binCommand.ExecuteScalar());
            Console.WriteLine("bin2decCommand: " + bin2decCommand.ExecuteScalar());
            Console.WriteLine("c2fCommand: " + c2fCommand.ExecuteScalar());
            Console.WriteLine("f2cCommand: " + f2cCommand.ExecuteScalar());
            Console.WriteLine("factorialCommand: " + factorialCommand.ExecuteScalar());
            Console.WriteLine("hex2decCommand: " + hex2decCommand.ExecuteScalar());
            Console.WriteLine("dec2hexCommand: " + dec2hexCommand.ExecuteScalar());
            Console.WriteLine("compareCommand: " + compareCommand.ExecuteScalar());
            Console.WriteLine("trimCommand: " + trimCommand.ExecuteScalar());
            Console.WriteLine("repeatCommand: " + repeatCommand.ExecuteScalar());
            Console.ReadLine();
        }
    }



    [SQLiteFunction(Name = "pmt", Arguments = 3, FuncType = FunctionType.Scalar)]
    public class pmt : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            var ti = double.Parse(args[0].ToString());
            var npr = double.Parse(args[1].ToString());
            var pv = double.Parse(args[2].ToString());

            return ((pv * ti) / (1 - (Math.Pow((1 + ti), -npr))));
        }
    }

    [SQLiteFunction(Name = "ping", Arguments = 1, FuncType = FunctionType.Scalar)]
    public class PING : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            string ip = args[0].ToString();
            var ping = new Ping();

            var reply = ping.Send(ip);
            if (reply.Status == IPStatus.Success)
                return 1;
            return 0;

        }
    }


    [SQLiteFunction(Name = "BIN2DEC", Arguments = 1, FuncType = FunctionType.Scalar)]
    public class BIN2DEC : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            var number = args[0].ToString();
            return Convert.ToInt32(number, 2); ;
        }
    }

    [SQLiteFunction(Name = "DEC2BIN", Arguments = 1, FuncType = FunctionType.Scalar)]
    public class DEC2BIN : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            string binary = "";
            int number = Int32.Parse(args[0].ToString());
            int i = 0;
            while (number > 0)
            {
                binary += (number % 2);
                i++;
                number = number / 2;
            }
            return binary;
        }
    }

    [SQLiteFunction(Name = "C2F", Arguments = 1, FuncType = FunctionType.Scalar)]
    public class C2F : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            int c = Int32.Parse(args[0].ToString());
            return ((int)(c * 1.8) + 32);
        }
    }

    [SQLiteFunction(Name = "F2C", Arguments = 1, FuncType = FunctionType.Scalar)]
    public class F2C : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            int f = Int32.Parse(args[0].ToString());
            return ((int)((f - 32) * 0.5556));
        }
    }

    [SQLiteFunction(Name = "Factorial", Arguments = 1, FuncType = FunctionType.Scalar)]
    public class Factorial : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            int res = 1;
            int val = Int32.Parse(args[0].ToString());
            for (int x = 1; x <= val; x++)
                res = res * x;
            return res;
        }
    }

    [SQLiteFunction(Name = "HEX2DEC", Arguments = 1, FuncType = FunctionType.Scalar)]
    public class HEX2DEC : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            var hexadecimal = args[0].ToString();
            return int.Parse(hexadecimal, System.Globalization.NumberStyles.HexNumber);
        }
    }

    [SQLiteFunction(Name = "DEC2HEX", Arguments = 1, FuncType = FunctionType.Scalar)]
    public class DEC2HEX : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            int _decimal = Int32.Parse(args[0].ToString());
            return _decimal.ToString("X"); ;
        }
    }

    [SQLiteFunction(Name = "CompareS", Arguments = 2, FuncType = FunctionType.Scalar)]
    public class CompareS : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            var cadena1 = args[0].ToString();
            var cadena2 = args[1].ToString();

            if (cadena1.Length < cadena2.Length)
                return -1;
            else if (cadena1 == cadena2)
                return 0;
            else if (cadena1.Length > cadena2.Length)
                return 1;
            return 9999999;
        }
    }

    [SQLiteFunction(Name = "trim", Arguments = 2, FuncType = FunctionType.Scalar)]
    public class trim : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            var cadena = args[0].ToString();
            var myChar = args[1].ToString()[0];

            return cadena.Trim(myChar);
        }
    }

    [SQLiteFunction(Name = "Repeat", Arguments = 2, FuncType = FunctionType.Scalar)]
    public class Repeat : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            string temp = "";
            var cadena = args[0].ToString();
            int rep = Int32.Parse(args[1].ToString());

            for (int x = 0; x < rep; x++)
            {
                temp += cadena;
            }

            return temp;
        }
    }





}
