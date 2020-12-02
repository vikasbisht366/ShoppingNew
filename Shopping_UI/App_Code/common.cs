using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;



/// <summary>
/// Summary description for common
/// </summary>
public class common
{
    public common()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public string pAutoNoResult(string strNumber)
    {
        int intcounter = 1;
        int inttrynumber = 0;
        string strtext = "";
        string strresult = "";
        while (strNumber.Length + 1 > intcounter)
        {
            if (int.TryParse(strNumber.Substring(strNumber.Length - intcounter, intcounter), out inttrynumber) == true)
            {
                strtext = strNumber.Substring(strNumber.Length - intcounter, intcounter);
            }
            else
            {
                strtext = Convert.ToString(Convert.ToInt64(strtext) + 1);
                strresult = strNumber.Substring(0, strNumber.Length - strtext.Length) + strtext;
                return strresult;
            }
            intcounter++;
        }
        strtext = Convert.ToString(Convert.ToDouble(strtext) + 1);
        strresult = strNumber.Substring(0, strNumber.Length - strtext.Length) + strtext;
        return strresult;
    }

    public static void DropDownMasterBind(DropDownList DropDownName, DataTable DatatableName, string DisplayField, string ValueField)
    {
        DataRow dr = DatatableName.NewRow();
        DropDownName.DataSource = DatatableName;
        DropDownName.DataTextField = DisplayField;
        DropDownName.DataValueField = ValueField;
        DropDownName.DataBind();
        System.Web.UI.WebControls.ListItem lititem = new System.Web.UI.WebControls.ListItem { };
        lititem.Text = "--Select--";
        lititem.Value = "-1";
        DropDownName.Items.Insert(0, lititem);

    }
}


//    private static readonly char[] _Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

//    private static readonly char[] _Numbers = "1234567890".ToCharArray();

//    private static readonly char[] _Symbols = "!@#$%^&*.?".ToCharArray();

//    public static string GenerateRandomKey(int minimumLength, int maximumLength,bool allowCharacters, bool allowNumbers, bool allowSymbols)
//    {
//          string[] _CharacterTypes;
//          _CharacterTypes = getCharacterTypes(allowCharacters, allowNumbers, allowSymbols);
//          StringBuilder randomKey = new StringBuilder(maximumLength);
//          int currentRandomKeyLength = RandomNumber.Next(maximumLength);
//          if (currentRandomKeyLength < minimumLength)
//          {
//              currentRandomKeyLength = minimumLength;
//          }

//        //Generate the randomKey

//        for (int i = 0; i < currentRandomKeyLength; i++)
//        {

//            randomKey.Append(getCharacter(_CharacterTypes));

//        }

//        return randomKey.ToString();

//    }

 

//    public static string GenerateRandomKey()
//    {

//        return GenerateRandomKey(5, 5, true, true, true);

//    }

//    // Getting character types allowed in the key //(UpperCase,LowerCase,Number,Special)

//    //Parameters

//    //Whether to allow characters

//    //Whether to allow numbers

//    //Whether to allow symbols

//    //Return type as string array.

//    private static string[] getCharacterTypes(bool allowCharacters, bool allowNumbers, bool allowSymbols)
//    {

//        ArrayList alCharacterTypes = new ArrayList();
//        foreach (string characterType in Enum.GetNames(typeof(CharacterType)))
//        {

//            CharacterType currentType =(CharacterType)Enum.Parse(typeof(CharacterType),characterType, false);
//            bool addType = false;

//            switch (currentType)
//            {
//                    case CharacterType.LowerCase:addType = allowCharacters;
//                    break;
//                    case CharacterType.Number:addType = allowNumbers;
//                    break;
//                    case CharacterType.Special:addType = allowSymbols;
//                    break;
//                    case CharacterType.UpperCase:addType = allowCharacters;
//                    break;

//            }

//            if (addType)

//            {

//                alCharacterTypes.Add(characterType);

//            }

//        }

//        return (string[])alCharacterTypes.ToArray(typeof(string));

//    }

 

 

//    // Getting character type randomly from the array of character types

//    //Parameter is Array of allowed character types.

//    // One of the types as string

     

//    private static string getCharacter(string[] characterTypes)
//    {
//        string characterType = characterTypes[RandomNumber.Next(characterTypes.Length)];
//        CharacterType typeToGet = (CharacterType)Enum.Parse(typeof(CharacterType), characterType, false);
//        switch (typeToGet)
//        {
//                case CharacterType.LowerCase:
//                return _Letters[RandomNumber.Next(_Letters.Length)].ToString().ToLower();
//                case CharacterType.UpperCase:
//                return _Letters[RandomNumber.Next(_Letters.Length)].ToString().ToUpper();
//                case CharacterType.Number:
//                return _Numbers[RandomNumber.Next(_Numbers.Length)].ToString();
//                case CharacterType.Special:
//                return _Symbols[RandomNumber.Next(_Symbols.Length)].ToString();
//        }
//        return null;

//    }




//}

//public class Random
//{
//    byte[] bytes1 = new byte[100];
//byte[] bytes2 = new byte[100];
//Random rnd1 = new Random();
//Random rnd2 = new Random();

//rnd1.NextBytes(bytes1);
//rnd2.NextBytes(bytes2);

//Console.WriteLine("First Series:");
//for (int ctr = bytes1.GetLowerBound(0); 
//     ctr <= bytes1.GetUpperBound(0); 
//     ctr++) { 
//   Console.Write("{0, 5}", bytes1[ctr]);
//   if ((ctr + 1) % 10 == 0) Console.WriteLine();
//} 
//Console.WriteLine();
//Console.WriteLine("Second Series:");        
//for (int ctr = bytes2.GetLowerBound(0);
//     ctr <= bytes2.GetUpperBound(0);
//     ctr++) {
//   Console.Write("{0, 5}", bytes2[ctr]);
//   if ((ctr + 1) % 10 == 0) Console.WriteLine();
//}   

//}
