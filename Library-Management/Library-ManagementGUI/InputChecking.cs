using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_ManagementGUI
{
    public class InputChecking
    {

        private static InputChecking instance;
        public static InputChecking Instance
        {
            get
            {
                if (instance == null)
                    instance = new InputChecking();
                return instance;
            }
        }

       

        //This function will Convert the TextBox's text into proper case.
        public void TextBoxToProperCase(TextBox txt)
        {
            // Save the selection's start and length.
            int sel_start = txt.SelectionStart;
            int sel_length = txt.SelectionLength;

            CultureInfo culture_info = Thread.CurrentThread.CurrentCulture;
            TextInfo text_info = culture_info.TextInfo;
            txt.Text = text_info.ToTitleCase(txt.Text);

            // Restore the selection's start and length.
            txt.Select(sel_start, sel_length);
        }

        //Check Name
        public bool IsValidName(string pText)
        {
            Regex regex = new Regex(@"[a-zA-Z]");
            if (regex.IsMatch(pText))
                return true;
            else
                return false;
        }
        
        public bool IsValidDate(DevComponents.Editors.DateTimeAdv.DateTimeInput dt)
        {
            if (DateTime.Now.Year - dt.Value.Year < 0) 
                return false;
            else
                return true;

        }

        public bool IsValidEmail(TextBox txtEmail)
        {
            string match = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Regex reg = new Regex(match);

            if ((reg.IsMatch(txtEmail.Text)) && (!string.IsNullOrEmpty(txtEmail.Text)))
                return true;
            else
                return false;

        }

        public bool IsNullOrEmpty(TextBox txt)
        {
            if (String.IsNullOrEmpty(txt.Text))
                return true;
            else
                return false;
        }

       
        public List<string> SeparateWords(string pText)
        {
            List<string> newList = new List<string>();
            string[] strWord = pText.Split(new char[] { ' ', ',', '.', ':', '-' });

            foreach(string str in strWord)
            {
                if(str.Trim() != "")
                {
                    newList.Add(str);
                }
            }
            return newList;
        }

        public bool IsNumber(string str)
        {
            foreach (char c in str)
            {
                if (!Char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsOnlyAlphabet(string str)
        {
            foreach (char c in str)
            {
                if (Char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }


    }
}
