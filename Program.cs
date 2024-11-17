using System;
using System.Drawing;
using System.Windows.Forms;
using System.Web;

namespace WindowsFormsTest
{
    public class TestForm : Form
    {
        private WebBrowser webBrowser;
        public TestForm()
        {
            // Set up the form
            this.Text = "Windows Forms Test";
            this.Size = new Size(600, 700);
            this.AutoScroll = true;

            int currentY = 10; // Start Y-coordinate for controls
            int margin = 10;  // Margin between controls

            // TextBox
            TextBox textBox = new TextBox
             {
                 Text = "Hi textbox",
                 Location = new Point(80, currentY),
                 Width = 200
             };
            this.Controls.Add(textBox);

            currentY += 30; // Move to the next row

            // RichTextBox
            RichTextBox richTextBox = new RichTextBox
            {
                Location = new Point(10, currentY + 20),
                Size = new Size(850, 100),
                Text = "A LinkLabel control is a label control that can display a hyperlink..."
            };
            this.Controls.Add(richTextBox);

            currentY += 140;

            // Buttons for Font Styles
            Button boldButton = new Button
            {
                Text = "B",
                Font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold),
                Location = new Point(10, currentY)
            };
            boldButton.Click += (sender, e) => ToggleFontStyle(richTextBox, FontStyle.Bold);
            this.Controls.Add(boldButton);

            Button italicButton = new Button
            {
                Text = "I",
                Font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Italic),
                Location = new Point(50, currentY)
            };
            italicButton.Click += (sender, e) => ToggleFontStyle(richTextBox, FontStyle.Italic);
            this.Controls.Add(italicButton);

            Button underlineButton = new Button
            {
                Text = "U",
                Font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Underline),
                Location = new Point(90, currentY)
            };
            underlineButton.Click += (sender, e) => ToggleFontStyle(richTextBox, FontStyle.Underline);
            this.Controls.Add(underlineButton);

            currentY += 50;

            // CheckBoxes
            Label checkBoxLabel = new Label
            {
                Text = "Choose products:",
                Location = new Point(10, currentY),
                AutoSize = true
            };
            this.Controls.Add(checkBoxLabel);

            CheckBox checkBoxPencil = new CheckBox { Text = "Pencil", Location = new Point(10, currentY + 20) };
            CheckBox checkBoxSharpener = new CheckBox { Text = "Sharpener", Location = new Point(10, currentY + 50) };
            CheckBox checkBoxPen = new CheckBox { Text = "Pen", Location = new Point(10, currentY + 80) };
            this.Controls.Add(checkBoxPencil);
            this.Controls.Add(checkBoxSharpener);
            this.Controls.Add(checkBoxPen);

            Button buyButton = new Button
            {
                Text = "Buy",
                Location = new Point(150, currentY + 50)
            };
            buyButton.Click += (sender, e) =>
            {
                string selectedItems = "";
                if (checkBoxPencil.Checked) selectedItems += "Pencil ";
                if (checkBoxSharpener.Checked) selectedItems += "Sharpener ";
                if (checkBoxPen.Checked) selectedItems += "Pen ";
                MessageBox.Show(string.IsNullOrWhiteSpace(selectedItems) ? "No item selected!" : $"You selected: {selectedItems}");
            };
            this.Controls.Add(buyButton);

            currentY += 120;

            // RadioButtons
            Label radioButtonLabel = new Label
            {
                Text = "Select gender:",
                Location = new Point(10, currentY),
                AutoSize = true
            };
            this.Controls.Add(radioButtonLabel);

            RadioButton radioButtonMale = new RadioButton { Text = "Male", Location = new Point(10, currentY + 20) };
            RadioButton radioButtonFemale = new RadioButton { Text = "Female", Location = new Point(10, currentY + 50) };
            this.Controls.Add(radioButtonMale);
            this.Controls.Add(radioButtonFemale);

            Button genderButton = new Button
            {
                Text = "Submit",
                Location = new Point(150, currentY + 35)
            };
            genderButton.Click += (sender, e) =>
            {
                if (radioButtonMale.Checked)
                    MessageBox.Show("You selected: Male");
                else if (radioButtonFemale.Checked)
                    MessageBox.Show("You selected: Female");
                else
                    MessageBox.Show("No gender selected!");
            };
            this.Controls.Add(genderButton);

            currentY += 100;

            // DateTimePicker and MonthCalendar
            Label dateTimePickerLabel = new Label
            {
                Text = "Select Date:",
                Location = new Point(10, currentY),
                AutoSize = true
            };
            this.Controls.Add(dateTimePickerLabel);

            DateTimePicker dateTimePicker = new DateTimePicker
            {
                Location = new Point(100, currentY)
            };
            this.Controls.Add(dateTimePicker);

            currentY += 50;

            Label monthCalendarLabel = new Label
            {
                Text = "Month Calendar:",
                Location = new Point(10, currentY),
                AutoSize = true
            };
            this.Controls.Add(monthCalendarLabel);

            MonthCalendar monthCalendar = new MonthCalendar
            {
                Location = new Point(10, currentY + 20)
            };
            this.Controls.Add(monthCalendar);

            currentY += 250;

            // ProgressBar
            Label progressBarLabel = new Label
            {
                Text = "Progress Bar:",
                Location = new Point(10, currentY),
                AutoSize = true
            };
            this.Controls.Add(progressBarLabel);

            ProgressBar progressBar = new ProgressBar
            {
                Location = new Point(10, currentY + 20),
                Size = new Size(300, 30)
            };
            this.Controls.Add(progressBar);

            Button incrementProgressButton = new Button
            {
                Text = "Increment",
                Location = new Point(320, currentY + 20)
            };
            incrementProgressButton.Click += (sender, e) =>
            {
                if (progressBar.Value < progressBar.Maximum)
                {
                    progressBar.Value += 10;
                }
            };
            this.Controls.Add(incrementProgressButton);

            currentY += 80;

            // WebBrowser
            Label webBrowserLabel = new Label
            {
                Text = "Web Browser:",
                Location = new Point(10, currentY),
                AutoSize = true
            };
            this.Controls.Add(webBrowserLabel);

            TextBox urlTextBox = new TextBox
            {
                Location = new Point(10, currentY + 20),
                Size = new Size(300, 20),
                Text = "https://www.google.com"
            };
            this.Controls.Add(urlTextBox);

            Button navigateButton = new Button
            {
                Text = "Go",
                Location = new Point(320, currentY + 20)
            };
            navigateButton.Click += (sender, e) => webBrowser.Navigate(urlTextBox.Text);
            this.Controls.Add(navigateButton);

            webBrowser = new WebBrowser
            {
                Location = new Point(10, currentY + 50),
                Size = new Size(850, 300)
            };
            this.Controls.Add(webBrowser);
            // NumericUpDown Section
            Label labelPrice = new Label();
            labelPrice.Text = "Price";
            labelPrice.Location = new Point(10, 350);
            labelPrice.AutoSize = true;
            this.Controls.Add(labelPrice);

            NumericUpDown numericUpDownPrice = new NumericUpDown();
            numericUpDownPrice.DecimalPlaces = 2;
            numericUpDownPrice.Minimum = 0;
            numericUpDownPrice.Maximum = 1000;
            numericUpDownPrice.Value = 4.50M;
            numericUpDownPrice.Location = new Point(100, 350);
            this.Controls.Add(numericUpDownPrice);

            Label labelQuantity = new Label();
            labelQuantity.Text = "Quantity";
            labelQuantity.Location = new Point(10, 380);
            labelQuantity.AutoSize = true;
            this.Controls.Add(labelQuantity);

            NumericUpDown numericUpDownQuantity = new NumericUpDown();
            numericUpDownQuantity.Minimum = 0;
            numericUpDownQuantity.Maximum = 100;
            numericUpDownQuantity.Value = 2;
            numericUpDownQuantity.Location = new Point(100, 380);
            this.Controls.Add(numericUpDownQuantity);

            Button calculateButton = new Button();
            calculateButton.Text = "Calculate";
            calculateButton.Location = new Point(100, 420);
            calculateButton.Click += (sender, e) =>
            {
                decimal price = numericUpDownPrice.Value;
                decimal quantity = numericUpDownQuantity.Value;
                decimal totalPrice = price * quantity;
                MessageBox.Show($"The total price is ${totalPrice:F2}", "Calculation Result");
            };
            this.Controls.Add(calculateButton);

            // Inside the TestForm constructor

            // ComboBox for selecting cities
            Label comboBoxLabel = new Label
            {
                Text = "Select City:",
                Location = new Point(10, currentY),
                AutoSize = true
            };
            this.Controls.Add(comboBoxLabel);

            ComboBox comboBoxCities = new ComboBox
            {
                Location = new Point(100, currentY),
                Width = 150
            };
            comboBoxCities.Items.AddRange(new string[] { "Chennai", "Trichy", "Pondicherry", "Madurai", "Kanchipuram" });
            comboBoxCities.DropDownStyle = ComboBoxStyle.DropDownList; // Set to DropDownList to restrict user input
            comboBoxCities.SelectedIndex = 0; // Set a default selected item
            this.Controls.Add(comboBoxCities);

            currentY += 40; // Update currentY to move below the ComboBox

            // Button to display selected ComboBox value
            Button displayComboBoxButton = new Button
            {
                Text = "Show Selection",
                Location = new Point(100, currentY)
            };
            displayComboBoxButton.Click += (sender, e) =>
            {
                MessageBox.Show($"You selected: {comboBoxCities.SelectedItem}");
            };
            this.Controls.Add(displayComboBoxButton);

            currentY += 50; // Move to the next position for following controls


            // PictureBox Section
            Label pictureBoxLabel = new Label();
            pictureBoxLabel.Text = "PictureBox";
            pictureBoxLabel.Location = new Point(10, 550);
            pictureBoxLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            pictureBoxLabel.AutoSize = true;
            this.Controls.Add(pictureBoxLabel);

            // PictureBox for Upload
            PictureBox pictureBoxUpload = new PictureBox();
            pictureBoxUpload.Location = new Point(10, 580);
            pictureBoxUpload.Size = new Size(150, 150);
            pictureBoxUpload.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxUpload.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxUpload.BackColor = Color.White;
            pictureBoxUpload.Click += (sender, e) =>
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        pictureBoxUpload.Image = Image.FromFile(openFileDialog.FileName);
                    }
                }
            };
            pictureBoxUpload.Paint += (sender, e) =>
            {
                if (pictureBoxUpload.Image == null)
                {
                    e.Graphics.DrawString(
                        "Click to upload picture",
                        new Font("Arial", 10, FontStyle.Regular),
                        Brushes.Black,
                        new PointF(10, pictureBoxUpload.Height / 2 - 10)
                    );
                }
            };
            this.Controls.Add(pictureBoxUpload);

            // PictureBox for Display
            PictureBox pictureBoxDisplay = new PictureBox();
            pictureBoxDisplay.Location = new Point(200, 580);
            pictureBoxDisplay.Size = new Size(150, 150);
            pictureBoxDisplay.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxDisplay.SizeMode = PictureBoxSizeMode.Zoom;
            this.Controls.Add(pictureBoxDisplay);

            // Button to Transfer Image
            Button transferButton = new Button();
            transferButton.Text = "Display Image";
            transferButton.Location = new Point(370, 630);
            transferButton.Click += (sender, e) =>
            {
                if (pictureBoxUpload.Image != null)
                {
                    pictureBoxDisplay.Image = pictureBoxUpload.Image;
                }
                else
                {
                    MessageBox.Show("Please upload an image first.");
                }
            };
            this.Controls.Add(transferButton);
            
        }

        private void ToggleFontStyle(RichTextBox rtb, FontStyle style)
        {
            if (rtb.SelectionFont != null)
            {
                FontStyle newStyle = rtb.SelectionFont.Style ^ style; // Toggle the selected style
                rtb.SelectionFont = new Font(rtb.SelectionFont, newStyle);
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new TestForm());
        }
    }
}
