using System;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;

namespace ConsoleApp66
{ public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Form pol = new MyForm("Интерактивная форма");
            Application.Run(pol);
        }
    }
         class MyForm : Form
        {
            private TextBox _nameField;
            private Button _sendName;
            private Label _greetingLbl;
            private delegate void NameEntered(string text);
            private event NameEntered _nameEntered;

        public MyForm(string title)
        { 
            Text = title;
            Height = 500;
            Width= 700;
            FormBorderStyle = FormBorderStyle.None;
            _nameField = new TextBox();
            _sendName = new Button();
            _greetingLbl = new Label();
            InitializeNameField(new Point(100, 100), new Size(222, 222), "Введите свое имя");
            InitializeGreetingLabel(new Point(220, 110), new Size(100, 33), "");
            InitializeSendNameButton(new Point(40, 222), new Size(340, 202), "Отправьте");
            ActiveControl = _sendName;
        }

        private void InitializeNameField(Point location, Size size, string defaultText)
            {
                SetInitialParams(location, size, defaultText, _nameField);
                _nameField.Enter += (sender, e) =>
                {
                    if (_nameField.Text == defaultText)
                        _nameField.Clear();

                };
                _sendName.Click += (sender, e) =>
                {
                    _nameEntered(_nameField.Text);
                };


            }
            private void InitializeGreetingLabel(Point location, Size size, string defaultText)
            {
            SetInitialParams(location, size, defaultText, _greetingLbl);
                _greetingLbl.TextAlign = ContentAlignment.MiddleCenter;
                _greetingLbl.Visible = false;
                _nameEntered += ShowUserName;

            }
            private void InitializeSendNameButton(Point location, Size size, string defaulText)
            {
                SetInitialParams(location, size, defaulText, _sendName);

            }
            private void SetInitialParams(Point location, Size size, string defaultText, Control element)
            {
                element.Text = defaultText;
                element.Location = location;
                element.Size = size;
                Controls.Add(element);

            
            }
            private void ShowUserName(string username)
            {
                _greetingLbl.Text = $"Приветсвую вас, {username}!";
                _greetingLbl.Visible = true;

                _nameField.Visible = false;
            }
        }
    }
