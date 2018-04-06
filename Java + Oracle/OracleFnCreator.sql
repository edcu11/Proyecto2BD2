create or replace and compile java source named "FUNCIONESJAVA" as
import java.io.*;
import java.net.*;

public class FUNCIONESJAVA{


   public static double PMT(double ti, int npr, double pv)
   {
       return  ((pv*ti)/(1 - (Math.pow((1 + ti), -npr))));
   }

   public static int BIN2DEC(String bin)
   {
       return Integer.parseInt(bin, 2);
   }

 

   public static int cel2fah(double c)
   {
       return ((int)(c * 1.8) + 32);
   }

   public static int fah2cel(double f)
   {
       return ((int)((f-32) *  0.5556));
   }

   public static int Factorial(int val)
   {
       int res = 1;

       for(int x=1;x<=val;x++){
           res=res*x;
       }
       return res;
   }

   public static int HEX2DEC(String hexadecimal)
   {
       return Integer.parseInt(hexadecimal, 16);
   }

   public static String DEC2HEX(int decimal)
   {
       return Integer.toHexString(decimal);
   }

   public static int CompareString(String cadena1, String cadena2)
   {
       if(cadena1.length() < cadena2.length())
           return -1;
        else if(cadena1.equals(cadena2))
           return 0;
       else if(cadena1.length() > cadena2.length())
           return 1;
       return 9999999;
   }

   public static int ping(String ipAddress) throws UnknownHostException, IOException
   {
        Socket s = new Socket(ipAddress, 9000);
        s.getOutputStream().write((byte) '\n');
        int ch = s.getInputStream().read();
        s.close();
        if (ch == '\n')
            return 1;
        return 0;
   }
   
   public static String DEC2BIN(int num)
   {
     StringBuilder bin = new StringBuilder();
        while(num > 0)
        {
            bin.append(num%2);
            num = num/2;
        }
        return bin.reverse().toString();
   }

   public static String Trim(String cadena, String remover){
    int beginIndex = 0;
    int endIndex = cadena.length();
    
    while (cadena.substring(beginIndex, endIndex).startsWith(remover)) {
        beginIndex += remover.length();
    } 
    
    while (cadena.substring(beginIndex, endIndex).endsWith(remover)) {
        endIndex -= remover.length();
    }
    
    return cadena.substring(beginIndex, endIndex);
   }
    

   public static String Repeat(String cadena, int rep){
       String temp = "";
       for(int x = 0; x<rep; x++){
           temp+=cadena;
       }
       return temp;
   }
};



