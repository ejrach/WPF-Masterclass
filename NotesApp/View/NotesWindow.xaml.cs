using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NotesApp.View
{
    /// <summary>
    /// Interaction logic for NotesWindow.xaml
    /// </summary>
    public partial class NotesWindow : Window
    {
        public NotesWindow()
        {
            InitializeComponent();

            //Load the font families
            var fontFamilies = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            fontFamilyComboBox.ItemsSource = fontFamilies;

            //Load the font sizes
            List<double> fontSizes = new List<double>() { 8, 9, 10, 11, 14, 16, 28, 32, 48, 72 };
            fontSizeComboBox.ItemsSource = fontSizes;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SpeechButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Need to complete per the speech recognition lesson. Problem: couldn't add the correct assembly.

            //Asking if is checked equal to null, if so then set to false
            bool isButtonEnabled = (sender as ToggleButton).IsChecked ?? false;
            if (isButtonEnabled)
            {
                //TODO: something
            }
            else
            {
                //TODO: something
            }
        }

        private void contentRichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int ammountCharacters = (new TextRange(contentRichTextBox.Document.ContentStart, contentRichTextBox.Document.ContentEnd)).Text.Length;

            statusTextBlock.Text = $"Document length: {ammountCharacters} characters";
        }

        private void boldButton_Click(object sender, RoutedEventArgs e)
        {
            //Asking if is checked equal to null, if so then set to false
            bool isButtonEnabled = (sender as ToggleButton).IsChecked ?? false;
            if (isButtonEnabled)
            {
                //Access the fontweight property and set the font to bold.
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Bold);
            }
            else
            {
                //Access the fontweight property and set the font to normal.
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Normal);
            }            
        }

        private void contentRichTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            //Get the weight of the selection and set the button to that property
            var selectedWeight = contentRichTextBox.Selection.GetPropertyValue(Inline.FontWeightProperty);
            boldButton.IsChecked = (selectedWeight != DependencyProperty.UnsetValue) && (selectedWeight.Equals(FontWeights.Bold));

            //Get the weight of the selection and set the button to that property
            var selectedStyle = contentRichTextBox.Selection.GetPropertyValue(Inline.FontStyleProperty);
            italicButton.IsChecked = (selectedStyle != DependencyProperty.UnsetValue) && (selectedStyle.Equals(FontStyles.Italic));

            //Get the weight of the selection and set the button to that property
            var selectedDecoration = contentRichTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            underlineButton.IsChecked = (selectedDecoration != DependencyProperty.UnsetValue) && (selectedDecoration.Equals(TextDecorations.Underline));

            fontFamilyComboBox.SelectedItem = contentRichTextBox.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            fontSizeComboBox.Text = (contentRichTextBox.Selection.GetPropertyValue(Inline.FontSizeProperty)).ToString();

        }

        private void italicButton_Click(object sender, RoutedEventArgs e)
        {
            //Asking if is checked equal to null, if so then set to false
            bool isButtonEnabled = (sender as ToggleButton).IsChecked ?? false;
            if (isButtonEnabled)
            {
                //Access the fontweight property and set the font to Italic.
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Italic);
            }
            else
            {
                //Access the fontweight property and set the font to normal.
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Normal);
            }
        }

        private void underlineButton_Click(object sender, RoutedEventArgs e)
        {
            //Asking if is checked equal to null, if so then set to false
            bool isButtonEnabled = (sender as ToggleButton).IsChecked ?? false;
            if (isButtonEnabled)
            {
                //Access the fontweight property and set the font to underline.
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            }
            else
            {
                TextDecorationCollection textDecorations;

                //Access the fontweight property and set the font to normal.
                (contentRichTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty) as TextDecorationCollection).TryRemove(TextDecorations.Underline, out textDecorations);
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, textDecorations);
            }
        }

        private void fontFamilyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fontFamilyComboBox.SelectedItem != null)
            {
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, fontFamilyComboBox.SelectedItem);
            }
        }

        private void fontSizeComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontSizeProperty, fontSizeComboBox.Text);
        }
    }
}
