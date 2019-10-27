// 27.10.2019 20:07 CREATED. HOORAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAY! :D
// Author: Armadillo-cld or FormatC
// A good use!
// 27.10.2019 RELEASE!


// Import libraries
using System;
using System.IO;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace Bot_Generator
{
    public partial class Form1 : MaterialForm
    {
        // function to get code for "Python in conference" parameters
        string getCodePythonConf (string login, string password)
        {
            // Code
            return "# CREATED BY VK-BOT GENERATOR 0.1 VERSION \n" +
            "# Author: Danil Romanov (vk.com/sha1.encryption) \n" +
            "import vk_api \n" +
            "import requests \n" +
            "\n" +
            "session = requests.Session() \n" +
            "login, password = '" + login + "', '" + password + "' \n" +
            "vk_session = vk_api.VkApi(login, password) \n" +
            "try : \n" +
            "vk_session.auth(token_only = True) \n" +
            "except vk_api.AuthError as error_msg : \n" +
            "\tprint(error_msg) \n" +
            "\treturn \n" +
            "for event in longpoll.listen(): \n" +
            "\tif event.type == VkEventType.MESSAGE_NEW: # NEW MESSAGE \n" +
            "\t\tif event.to_me: # Message to me \n" +
            "\t\t\trequest = event.text # Event = message text \n" +
            "\t\t\tif request == \"Hello!\": \n" +
            "\t\t\t\t# YOUR CODE \n";
        }

        // function to get code for "Python in group" parameters
        string getCodePythonGroup (string token)
        {
            // Code
            return "# CREATED BY VK-BOT GENERATOR 0.1 VERSION \n" +
            "# Author: Danil Romanov (vk.com/sha1.encryption) \n" +
            "import vk_api \n" +
            "from vk_api.longpoll import VkLongPoll, VkEventType \n" +
            "\n" +
            "def write_msg(user_id, message): \n" +
            "\tvk.method('messages.send', { 'user_id': user_id, 'message' : message }) \n" +
            "token = \"" + token + "\" \n" +
            "vk = vk_api.VkApi(token=token) \n" +
            "longpoll = VkLongPoll(vk) \n" +
            "for event in longpoll.listen():\n" +
            "\tif event.type == VkEventType.MESSAGE_NEW: # NEW MESSAGE \n" +
            "\t\tif event.to_me: # Message to me \n" +
            "\t\t\trequest = event.text # Event = message text \n" +
            "\t\t\tif request == \"Hello!\": \n" +
            "\t\t\t\t# YOUR CODE \n";
        }

        // function to get code for "languague: Php" parameters
        string getCodePhp(string confCode, string token, string secretK)
        {
            // Php bot on VK Api
            return "// CREATED BY VK-BOT GENERATOR 0.1 VERSION \n" +
            "// Author: Danil Romanov (vk.com/sha1.encryption) \n" +
            "< ? php \n" +
            "\n" +
            "if (!isset($_REQUEST)) { \n" +
            "\treturn; \n" +
            "} \n" +
            "\n" +
            "$confirmationToken = '" + confCode + "'; \n" +
            "\n" +
            "$token = '" + token + "'; \n" +
            "// Secret key \n" +
            "$secretKey = '" + secretK + "'; \n" +
            "$data = json_decode(file_get_contents('php://input')); \n" +
            "if (strcmp($data->secret, $secretKey) != = 0 && strcmp($data->type, 'confirmation') != = 0) \n" +
            "\treturn; \n" +
            "switch ($data->type) { \n" +
            "\tcase 'confirmation': \n" +
            "\t\techo $confirmationToken; \n" +
            "\t\tbreak; \n" +
            "\tcase 'message_new': \n" +
            "\t\t// YOUR CODE \n" +
            "\t\tbreak; \n" +
            "\tcase 'group_join': \n" +
            "\t\t// YOUR CODE \n" +
            "\t\tbreak; \n" +
            "} \n" +
            "? > \n";
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // If the fields are not empty
            if (comboBox1.Text != "" && comboBox2.Text != "" && textBox2.Text != "" && textBox3.Text != "" && 
                textBox4.Text != "" &&
                textBox5.Text != "" && textBox6.Text != "")
            {
                // And if languague == Python
                if (comboBox1.Text.ToLower() == "python")
                {
                    // and if location == conference\conversation
                    if (comboBox2.Text.ToLower().Contains("conference"))
                    {
                        // Get code
                        string code = getCodePythonConf(textBox5.Text, textBox6.Text);
                        // Open save file dialog
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                        saveFileDialog1.Filter = "Python file|*.py|All files (*.*)|*.*";
                        saveFileDialog1.FilterIndex = 1;
                        saveFileDialog1.RestoreDirectory = true;

                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            // Create file and
                            StreamWriter file = new StreamWriter(saveFileDialog1.FileName);
                            // Write code in file
                            file.WriteLine(code);
                            // Close
                            file.Close();
                            // success
                            MessageBox.Show("Successfull!");
                        }
                    }
                    // If location == group
                    else if (comboBox2.Text.ToLower().Contains("group"))
                    {
                        // get code
                        string code = getCodePythonGroup(textBox2.Text);
                        // Show saveFileDialog
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                        saveFileDialog1.Filter = "Python file|*.py|All files (*.*)|*.*";
                        saveFileDialog1.FilterIndex = 1;
                        saveFileDialog1.FileName = "yourbot";
                        saveFileDialog1.RestoreDirectory = true;

                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            // Create file and
                            StreamWriter file = new StreamWriter(saveFileDialog1.FileName);
                            // Write code in file
                            file.WriteLine(code);
                            // close
                            file.Close();
                            // SuccessFull
                            MessageBox.Show("Successfull!");
                        }
                    }
                }
                // If languague == php
                else if (comboBox1.Text.ToLower() == "php")
                {
                    // get code
                    string code = getCodePhp(textBox4.Text, textBox2.Text, textBox3.Text);
                    // show saveFileDialog
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                    saveFileDialog1.Filter = "PHP file|*.php|All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 1;
                    saveFileDialog1.RestoreDirectory = true;
                    saveFileDialog1.FileName = "yourbot";

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        // Create file and
                        StreamWriter file = new StreamWriter(saveFileDialog1.FileName);
                        // write code in file
                        file.WriteLine(code);
                        // close file
                        file.Close();
                        // successfull!
                        MessageBox.Show("Successfull!");
                    }
                }
            }
            // if all textBox is empty
            else
            {
                // Error! Fill fuckin textboxes
                MessageBox.Show("Please fill in all the fields, if you do not have any - write \"None\"");
            }
        }

        // Author
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Author: FormatC (Armadillo-cld) \nVK: https://vk.com/sha1.encryption " +
                "\nGithub: https://github.com/armadillo-cld \n" +
                "Telegram: @cyber_andrey \n" +
                "\nA good use! Copyright NOT SAVED, FUCK IT! :D\n" +
                "But specify the author, please)");
        }
    }
}
